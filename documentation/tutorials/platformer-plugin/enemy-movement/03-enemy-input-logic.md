## Introduction

This tutorial shows how to replace the default keyboard (and gamepad) input logic with movement controlled only in code.

## Removing Input Device

First we'll remove the Input Device from the Enemy entity:

1.  Select the **Enemy** entity
2.  Select the **Enemy Input Movement** tab
3.  Check **None** under **Input Device**

![](/media/2021-04-img_607797eac1c0f.png)

Now the Enemy will not move in response to keyboard or gamepad input.

## Creating an EnemyInput InputDevice

Next we will create our own custom InputDevice which will control the movement of the enemy. The reason we are creating this is because Platformer entities expect to receive commands from an input device like a keyboard. We can create a class which simulates input commands without actually having physical input. To create this class:

1.  Open the project in Visual Studio

2.  Create a new class called EnemyInput. I will place mine in an Input folder

    ![](/media/2021-04-img_6077995742261.png)

3.  Modify the code so that the EnemyInput class inherits from **FlatRedBall.Input.InputDeviceBase**

&nbsp;

    class EnemyInput : FlatRedBall.Input.InputDeviceBase
    {
    }

This class provides many virtual methods which we can override to customize the behavior of our enemy. For example, we can override the method for GetHorizontalValue to control which way the Enemy is walking, as shown in the following code snippet:

    class EnemyInput : FlatRedBall.Input.InputDeviceBase
    {
        protected override float GetHorizontalValue()
        {
            // Horizontal value is a value between 
            // -1 (left) and +1 (right)
            // By returning 1, the input device will
            // tell the Enemy to always walk to the right
            return 1;
        }
    }

To use **EnemyInput**, we can modify the **CustomInitialize** method in the **Enemy.cs** class to assign its **InputDevice.** The **Enemy.cs** file can be found in the **Entities** folder in the Visual Studio Solution Explorer.

![](/media/2021-04-img_60779b423c26b.png)

To use EnemyInput as the Enemy's InputDevice, modify the Enemy CustomInitialize method as shown in the following code snippet:

    public partial class Enemy
    {
        private void CustomInitialize()
        {
            var input = new EnemyInput();
            InitializePlatformerInput(input);
        }
        // ...

Now if we run the game, the Enemy automatically walks to the right and ignores keyboard and gamepad input. [![](/wp-content/uploads/2021/04/2021_April_14_194852.gif.md)](/wp-content/uploads/2021/04/2021_April_14_194852.gif.md)

### Jumping

This tutorial does not include adding jumping to the enemy behavior. If your game needs jumping, you can add this by including a primary input override in the EnemyInput class. Of course, you would only want to press the jump button under some condition. The following code snippet shows how this could be accomplished:

    class EnemyInput : FlatRedBall.Input.InputDeviceBase
    {
        protected override float GetHorizontalValue()
        {
            // Horizontal value is a value between 
            // -1 (left) and +1 (right)
            // By returning 1, the input device will
            // tell the Enemy to always walk to the right
            return 1;
        }
       
        protected override bool GetPrimaryActionPressed()
        {
            if(SomeCondition)
            {
                return true;
            }
            return false;
        }
    }

## Changing Directions

Our EnemyInput object can be expanded to support anything we want - we just need to have the GetHorizontalValue function return a value between 0 and 1. Note that we are only using horizontal movement for this tutorial, but we could also have the Enemy jump by implementing the GetPrimaryActionPressed method, which controls whether the jump button is down. For this tutorial we need access to a value to indicate whether the Enemy should move to the left or right. We will ignore values inbetween -1 (left) and +1 (right), but a full game may support enemies which may stand still or move at various speeds. We'll create a new enum value and expose a property in EnemyInput so that it can be controlled externally. To do this, modify the EnemyInput class as shown in the following code snippet:

    enum DesiredDirection
    {
        Left,
        Right
    }

    class EnemyInput : FlatRedBall.Input.InputDeviceBase
    {
        public DesiredDirection DesiredDirection { get; set; }

        protected override float GetHorizontalValue()
        {
            if(DesiredDirection == DesiredDirection.Left)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

## Handling Wall Collision

Many platformer games include enemies which turn around when colliding with other objects such as walls, platform edges, and other enemies. We will implement wall collision here since it is the simplest scenario to control enemies turning around. First we will add an event whenever Enemies collide with SolidCollision:

1.  Expand the **GameScreen -\> Objects -\> Collision Relationships** item in Glue

2.  Select **EnemyListVsSolidCollision**

3.  Select the **Collision** tab

4.  Click the **Add Event** button ![](/media/2021-04-img_6077b6189b433.png)

5.  Click **OK** to accept the defaults

    ![](/media/2021-04-img_6077b70441b42.png)

Glue will add an event to GameScreen.Event.cs which we can modify to adjust the EnemyInput DesiredDirection, as shown in the following snippet.

    void OnEnemyListVsSolidCollisionCollisionOccurred (Entities.Enemy first, FlatRedBall.TileCollisions.TileShapeCollection second)
    {
        var collisionReposition = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition;
        var hasCollidedWithWall = collisionReposition.X != 0;
        if(hasCollidedWithWall)
        {
            var enemyInput = first.InputDevice as EnemyMovement.Input.EnemyInput;
            var isWallToTheRight = collisionReposition.X < 0;

            if(isWallToTheRight && enemyInput.DesiredDirection == DesiredDirection.Right)
            {
                enemyInput.DesiredDirection = DesiredDirection.Left;
            }
            else if(!isWallToTheRight && enemyInput.DesiredDirection == DesiredDirection.Left)
            {
                enemyInput.DesiredDirection = DesiredDirection.Right;
            }
        }
    }

The code above is assigns the EnemyInput DesiredDirection according to the enemy's AxisAlignedRectangleInstance.LastMoveCollisionReposition. We'll take a deeper look at how this property works in the next section.

### LastMoveCollisionReposition

The collision relationship between Enemies and SolidCollision prevents Enemy instances from overlapping the SolidCollision TileShapeCollection. Whenever an Enemy overlaps one of the rectangles in the SolidCollision TileShapeCollection, the Enemy must be *repositioned* so it does not overlap the solid collision. For example, consider a falling Enemy (white). Initially the enemy may be falling but  not overlapping any solid collision (red).

![](/media/2021-04-img_60783a690fdef.png)

As the Enemy continues to fall, it eventually overlaps the solid collision.

![](/media/2021-04-img_60783bce4c53b.png)

When this happens, the Enemy must be *repositioned* up to resolve the overlapping collision.

![](/media/2021-04-img_60783cc8cb303.png)

In this case, the RepositionDirection would have a positive Y value. For example, it may be (0,1,0). Similarly, whenever an Enemy collides with a wall in the SolidCollision TileShapeCollection, the Enemy is repositioned horizontally, so the X value of the RepositionDirection is non-zero, as shown in the following diagram:

![](/media/2021-04-img_60783e6668121.png)

In the diagram above, the RepositionDirection has a negative X value (points to the left) so we know that the wall is to the right of the Enemy. If the RepositionDirection has a positive X value, then the wall is to the left of the Enemy.

![](/media/2021-04-img_60783ebc5efb7.png)

## Conclusion

Now that we have this logic in place, our Enemy will automatically walk until colliding with a wall, then it turns around and walks in the other direction. [![](/wp-content/uploads/2021/04/2021_April_15_075827.gif.md)](/wp-content/uploads/2021/04/2021_April_15_075827.gif.md) The next tutorial will enable Enemies to turn around when reaching the end of a platform.
