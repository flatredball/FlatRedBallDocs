## Introduction

Some games include enemies which turn around when reaching a platform edge. For example, in Super Mario World, the red Koopa enemies (turtles) walk until they reach an edge, then turn around. ![](http://cdn.wikimg.net/strategywiki/images/d/d5/SMW_Koopa.png)

We will add this logic to our Enemies in this tutorial.

## The Concept of Platform Edges

Currently Enemies have a single collision shape called **AxisAlignedRectangleInstance**.

![](/media/2021-04-img_607841ebcb6ab.png)

This shape acts as the Enemy's *body*. It can be used to keep the enemy from moving through the ground, walls, and ceiling (the SolidCollision TileShapeCollection). Currently this shape does not provide enough information to detect ledges. From the point of view of the AxisAlignedRectangleInstance, this first situation...

![](/media/2021-04-img_6078436a0307f.png)

... provides the same information as this second situation...

![](/media/2021-04-img_607843b53d272.png)

Both situations are identical in the collision event - they both result in collision and both have the same *RepositionDirection.* To detect if the Enemy is near the edge of a platform, we can use a new collision rectangle (displayed in green). If this green rectangle is not colliding with SolidCollision, then the player is near a ledge. For example, in the following diagram the Enemy is near the edge of a platform on the right side:

![](/media/2021-04-img_607847cdd2344.png)

If the player is not near a ledge, then the green rectangle will collide with solid collision.

![](/media/2021-04-img_6078481a2157e.png)

Since we want to detect ledges on both the left and right side, we need to have one new rectangle on each side.

![](/media/2021-04-img_6078487ae3812.png)

When we define these rectangles, we need to remember a few things:

-   These rectangles should not be used for solid collision - they should be excluded from the ICollidable interface
-   These rectangles should be smaller than the size of our tiles (16x16) so they do not reach across gaps or down pits
-   These rectangles will be used to apply logic when *not colliding* with the SolidCollision. Normally we perform logic when a collision occurs, so we will need to write custom code to handle this situation.

## Creating Edge Collision Rectangles

As mentioned above, we'll need to create two AxisAlignedRectangle instances in our Enemy entity - one for left edge collision and one for right edge collision. To create the left edge collision rectangle:

1.  Select the Enemy entity

2.  Select the Quick Actions tab and click the Add Object to Enemy button

    ![](/media/2021-04-img_60784f42b2d1b.png)

3.  Select the type **AxisAlignedRectangle**

4.  Enter the name **LeftEdgeCollision**

5.  Click ****OK****

    ![](/media/2021-04-img_60784f95cff10.png)

6.  With the **LeftEdgeCollision** object selected, click on the **Variables** tab

7.  Change **X** to -**12**

8.  Change **Y** to **-12**

9.  Change **Width** to **8**

10. Change **Height** to **8**

11. To help visualize, change the **Color** to ****Green****

    ![](/media/2021-04-img_607850a571c89.png)

Repeat the steps above to create RightEdgeCollision, but change the X value to a positive 12 so it sits on the right side of the Enemy.

![](/media/2021-04-img_607850e8cdcf7.png)

Now our enemy has two extra rectangles which it can use for detecting edges, but these rectangles are being used for solid collision. To fix this:

1.  Select the **LeftEdgeCollision**

2.  Click on the **Properties** tab

3.  Change **IncludeInICollidable** to **False** so that the rectangle is not used in default collision relationships (like EnemyListVsSolidCollision in GameScreen)

    ![](/media/2021-04-img_607851a6d3661.png)

Repeat the steps above for the **RightEdgeCollision** and the Enemy will no longer use these two rectangles for solid collision.

![](/media/2021-04-img_607851d7226fd.png)

## Adding Edge Detecting Logic

Normally when performing logic related to collision, we do so inside a collision relationship event. Detecting an edge is different because we need to respond to a situation when there is no collision. Therefore, we will be writing code which happens every frame inside of our GameScreen CustomActivity. To detect if the enemy should turn around, modify the **GameScreen.cs** file so that its **CustomActivity** matches the following code snippet:

    void CustomActivity(bool firstTimeCalled)
    {
        for(int i = 0; i < EnemyList.Count; i++)
        {
            var enemy = EnemyList[i];
            if(enemy.IsOnGround)
            {
                var enemyInput = enemy.InputDevice as Input.EnemyInput;
                if(enemyInput.DesiredDirection == Input.DesiredDirection.Right)
                {
                    var doesRightSideCollide = SolidCollision.CollideAgainst(enemy.RightEdgeCollision);
                    if(!doesRightSideCollide)
                    {
                        enemyInput.DesiredDirection = Input.DesiredDirection.Left;
                    }
                }
                else // moving left
                {
                    var doesLeftLeftSideCollide = SolidCollision.CollideAgainst(enemy.LeftEdgeCollision);
                    if(!doesLeftLeftSideCollide)
                    {
                        enemyInput.DesiredDirection = Input.DesiredDirection.Right;
                    }
                }
            }
        }
    }

This code shows that we can check collisions directly in code at any time, rather than relying purely on CollisionRelationships. Notice that we only perform this logic if the Enemy is on the ground. Otherwise, enemies would alternate directions very quickly when falling. If using the default level, this logic won't do anything since there are no raised platforms. We can modify Level1Map to add a few platforms. Feel free to adjust it however you like, as long as you have platforms with edges which we can use to test this logic.

![](/media/2021-04-img_6078544424129.png)

We should also adjust the Enemy1 starting position so it starts on a ledge instead of falling from the top of the level. Change the X and Y values on Enemy1 in Level1 so that it starts in the right spot. This may take a little trial-and-error. Once you have the Enemy on a platform, you may notice that it still runs off the edge. The reason for this is because the Enemy moves very quickly and it takes time to slow down when changing directions. [![](/wp-content/uploads/2021/04/2021_April_15_090902.gif.md)](/wp-content/uploads/2021/04/2021_April_15_090902.gif.md) To do this:

1.  Select the **Enemy** entity

2.  Click the **Entity Input Movement** tab

3.  Change the **Max Speed** to **100**

4.  Change the **Slow Down Time** to ****0.03****

    ![](/media/2021-04-img_60785758cc8b5.png)

These changes enable the enemy to turn around without falling off of the platform. It's important to note that with enough **Max Speed** or a large enough **Slow Down Time** will result in an enemy sliding off of an edge. [![](/wp-content/uploads/2021/04/2021_April_15_090312.gif.md)](/wp-content/uploads/2021/04/2021_April_15_090312.gif.md)

## Conclusion

Now our enemy has functionality for turning around based on wall collision and edge detection. The two approaches shown here could also be used to turn around when Enemies collide with other Enemies (also using reposition values), but we'll leave this and other situations to individuals who are interested.
