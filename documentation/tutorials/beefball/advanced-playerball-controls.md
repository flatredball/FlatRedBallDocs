## Introduction

This tutorial will implement more advanced controls for the PlayerBall. Most games with first-person control (that is control where you directly direct an Entity, as opposed to third person control like RTS games - not to be confused with first person view) have fairly complex control logic. We'll be implementing more advanced controls in our game, investigating the logic in detail along the way.

## Velocity vs. Acceleration

Our current implementation provides immediate control over the PlayerBall's velocity values:

    this.XVelocity = MovementInput.X * MovementSpeed;
    this.YVelocity = MovementInput.Y * MovementSpeed;

In other words, if the input for moving right is held (whether that's a keyboard key or an Xbox360 analog stick), the PlayerBall immediately moves at maximum speed. Similarly, when the movement input is released, the PlayerBall immediately stops. As mentioned earlier, this logic prevents the collision relationship from making the ball bounce. We will modify our input code to gradually add to the speed of the PlayerBall when the input is held down. To do this, we'll change our code to set the PlayerBall's **acceleration** rather than **velocity**. Modify the **MovementActivity** in **PlayerBall.cs** as follows:

    private void MovementActivity()
    {
        if (MovementInput != null)
        {
            this.XAcceleration = MovementInput.X * MovementSpeed;
            this.YAcceleration = MovementInput.Y * MovementSpeed;
        }
    }

Notice that the code above still uses the MovementSpeed variable, which can be modified in Glue. This value can be increased to make movement more responsive. You may want to increase this value from 100 to a larger number such as 300. Now our ball can bounce against the walls, and it doesn't immediately speed up or slow down - it takes some time to gain speed. [![](/wp-content/uploads/2016/01/2021_July_25_135938.gif.md)](/wp-content/uploads/2016/01/2021_July_25_135938.gif.md) Since we're no longer modifying velocity values directly (acceleration values indirectly modify velocity), the ball continues to move even after releasing input. We'll address this in the next section.

## Reducing Momentum

We'll use the [Drag](/frb/docs/index.php?title=FlatRedBall.PositionedObject.Drag.md "FlatRedBall.PositionedObject.Drag") property to slow the PlayerBall. Drag modifies velocity proportionally and in the opposite direction of current Velocity. In other words, drag slows an object regardless of its movement direction. The faster an object is moving, the more Drag reduces its velocity. Drag is a built-in variable on all Entities, so if you are creating a game which uses acceleration to move an object, you may want to also implement Drag. Drag is applied whether an object is accelerating or not. Since it slows an object down by more when the object is moving faster, it will in effect create a maximum movement speed for our PlayerBall. To add Drag to the PlayerBall Entity:

1.  Select the **PlayerBall** Entity in Glue
2.  Select the **Variable** tab
3.  Click the **Add New Variable** button
4.  Select the **Expose an existing variable** option
5.  Click the Drag variable
6.  Click OK
7.  Change the Drag variable to 1

[![](/wp-content/uploads/2016/01/2021_July_25_130242.gif.md)](/wp-content/uploads/2016/01/2021_July_25_130242.gif.md) The addition of Drag has changed the way our ball moves:

1.  The ball now has a maximum speed
2.  Releasing all input results in the ball slowing down
3.  The ball does not accelerate as quickly as it used to

We'll increase the MovementSpeed to make up for the addition of Drag on the PlayerBall's acceleration. Feel free to play with the MovementSpeed variable. A value around 350 should result in responsive movement.

## Bouncing Elasticity

The previous tutorial created a collision relationship between the PlayerBall and Walls. Now that we have bouncing implemented, we can revisit the PlayerListVsWalls collision relationship. Notice that the relationship provides an Elasticity value as shown in the following image:

![](/media/2021-07-img_60fdbfcdea17e.png)

This value controls how much velocity is preserved after a collision occurs. A value of 1 indicates that 100% of the velocity is preserved. A value less than 1 will result in some of the velocity being absorbed. Feel free to play with this number to create a bounce elasticity that you like. If you want the balls to remain bouncy, you can keep it at 1. If you want the walls to absorb some of the PlayerBall velocity, try putting a (positive) value less than 1, such as 0.5.

## Conclusion

Now we're getting somewhere! The game is starting to feel pretty solid. Next we'll add a Puck Entity which can be used to score goals. [\<- Creating the Screen Collision](/documentation/tutorials/tutorials-beefball/tutorials-beefball-creating-the-screen-collision.md "Tutorials:Beefball:Creating the Screen Collision") -- [Creating the Puck Entity -\>](/documentation/tutorials/tutorials-beefball/tutorials-beefball-creating-the-puck-entity.md "Tutorials:Beefball:Creating the Puck Entity")