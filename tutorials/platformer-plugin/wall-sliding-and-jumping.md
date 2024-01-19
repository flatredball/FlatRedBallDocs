# Wall Sliding and Jumping

This walkthrough covers the concept of wall sliding and wall jumping. When a player is in the air and pressing against a wall, the player's fall speed will slow the player's falling speed and enable jumping.

{% embed url="https://youtu.be/wd2NqblSmIY?t=845" %}

This tutorial assumes a project that has been created with the platformer wizard options, but this is not a requirement. Wall sliding and jumping can be added to any platformer project.

### Main Concepts

This walkthrough covers a number of main concepts for wall jumping

* Detecting if the user is "pressing" against a wall when in the air
* Defining sliding platformer values
* Forcing the player to move "outward" on wall jumps
* Playing animations when wall jumping

### Defining WallSliding Movement Values

When the player is sliding against a wall, the player's movement is different than when the player is in the air. The most obvious changes are:

1. The player falls more slowly (max fall speed is reduced)
2. The player can jump off of the wall

We can create a new set of movement values by copying the existing Air movement values:

<figure><img src="http://flatredball.com/wp-content/uploads/2023/10/img_6521c28cc726f.png" alt=""><figcaption></figcaption></figure>

Once copied, change the following values:

* Movement Type = WallSliding
* Jump Speed = 250
* Max Falling Speed = 150

### Setting WallSliding vs Air Movement Values

Once the WallSliding values have been defined, we need to detect if the player has collided with a solid wall. We can do this by adding the following method which returns whether the player is wall sliding.

```
private bool GetIfIsSlidingOnWall()
{
    if(!IsOnGround && this.AxisAlignedRectangleInstance.LastMoveCollisionReposition.X != 0)
    {
        // The player is in the air, and was pushed sideways by the last solid collision. 
        return true;
    }
    else
    {
        return false;
    }
}
```

The code above assumes that any horizontal reposition on a collision allows wall jumping. You may want to further restrict wall jumping to certain collision types to prevent the player from wall jumping in some situations. For example, you may not want the player to wall jump when sliding against spikes.

To do this, you can check the LastFrameItemsCollidedAgainst or LastFrameObjectsCollidedAgainst to only allow wall jumping if colliding against certain objects. For example, your if statement may be modified as shown in the following code snippet:

```
if(!IsOnGround && this.AxisAlignedRectangleInstance.LastMoveCollisionReposition.X != 0 && LastFrameItemsCollidedAgainst.Contains("SolidCollision"))
```

The GetIfIsSlidingOnWall can then be used in the CustomActivity to decide whether the player's AirMovement should be WallSliding or Air, as shown in the following code:

```
public bool IsSlidingOnWall { get; private set; }
private void CustomActivity()
{

    IsSlidingOnWall = GetIfIsSlidingOnWall();

    if(IsSlidingOnWall)
    {
        AirMovement = PlatformerValuesStatic["WallSliding"];
    }
    else
    {
        AirMovement = PlatformerValuesStatic["Air"];
    }
}
```

Note that this code uses a property IsSlidingOnWall rather than a local variable. Although a property provides no additional benefits on this code, it will be used later when assigning animations.

With this code in place, the player can now slide down walls and jump when sliding.

<figure><img src="../../.gitbook/assets/07_15 16 17.gif" alt=""><figcaption></figcaption></figure>

### Jumping Outward

The implementation above results in the Player being able to jump against walls indefinitely. Many games push the player outward on jumps. Some games such as Mega Man X push the player outward only slightly, allowing the player to climb a wall through wall jumps. Other games such as New Super Mario Bros U Deluxe push the player outward far enough that the player cannot climb up a single wall.

Whether a player can climb a wall depends on the outward XVelocity applied on a jump.

```
private void CustomInitialize()
{
    JumpAction += HandleJumped;
}

private void HandleJumped()
{
    float outwardVelocity = 100;
    if(IsSlidingOnWall)
    {
        if (DirectionFacing == HorizontalDirection.Left)
        {
            XVelocity = outwardVelocity;
        }
        else
        {
            XVelocity = -outwardVelocity;
        }

    }
}
```

This code adds a handler to when the player jumps. The jump checks if the player is sliding on the wall and if so, pushes the player "outward". Note that the outwardVelocity is defined here in the HandleJumped method, but you may want to put this variable in the Player entity so that it can be tuned without changing code. Also, keep in mind that a smaller outwardVelocity value results in the player being pushed outward less. If the value is small enough then the player will be able to climb the wall through wall jumping. With the values used here, this value is roughly around 30.

<figure><img src="../../.gitbook/assets/07_15 27 17.gif" alt=""><figcaption></figcaption></figure>

### Playing Sliding Animations

We can add sliding animations by checking the IsSlidingOnWall variable either in code or in the Animations tab for the player. If you are already using the Animations UI, then handling the IsSlidingOnWall variable requires no code. To do so:

1. Select the Player Entity, and select the Entity Input Movement tab
2. Click on the Animation item\
   <img src="http://flatredball.com/wp-content/uploads/2023/10/img_6521ce5b2ed06.png" alt="" data-size="original">
3. Copy the CharacterFall animation row\
   ![](<../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1).png>)
4. Select **CharacterWallSlide** animation on the new row
5. Enter **IsSlidingOnWall** for the **Custom Condition** on the new row\
   ![](http://flatredball.com/wp-content/uploads/2023/10/img\_6521cf490bf72.png)

The player will now play the CharacterWallSlide animations if the IsSlidingOnWall property is set to true. Note that the .achx file contains CharacterWallSlideLeft and CharacterWallSlideRight, but the generated code selects the appropriate one based on which way the player is facing.

<figure><img src="../../.gitbook/assets/07_16 11 00 (1).gif" alt=""><figcaption></figcaption></figure>
