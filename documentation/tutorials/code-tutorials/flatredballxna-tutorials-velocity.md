## Introduction

Velocity, another term for movement, is an essential element of nearly all video games. Understanding how to work with velocity is one of the first steps in successfully creating video games. This tutorial will discuss how to use velocity to control the movement of your objects on screen.

## Frames vs. Continual Motion

Similar to movies and television, the display of video games is broken up into frames. Unlike physical movement, objects which move in video games will actually perform small "hops" from one position to the next every frame. For example, the following image shows the positions of a red ball that is moving along the X axis.

![SpriteMovement.png](/media/migrated_media-SpriteMovement.png)

As you can tell there are distinct positions that the red ball falls on every frame. While this may appear to be jarring, when played at a high frame rate the animation appears smooth to the user.

The frame-style movement is relevant for a number of reasons, but perhaps most importantly that when an object moves it will not always touch every position along the way. That is, if an object has a positive X velocity, and it starts at 0, there is no guarantee that it will ever be positioned at 1 during a given frame. Its position may be:

    .03, 06, .09, .12 ...  .99, 1.02

Consider this code:

    if(object.X == 1.0f)
    {
      DoSomething();
    }

If our numbers above show the movement of the object frame-by-frame, then the the DoSomething() will never be called. This is because the object skips from .99 to 1.02, and it's never actually positioned at 1.0 (or any number **between** .99 and 1.02).

To guarantee that the code gets hit when the object moves past 1.0, the following code would work:

    // assume hasDoneSomething is initialized to false
    if(object.X > 1.0f && !hasDoneSomething)
    {
        DoSomething();
        hasDoneSomething = true;
    }

## Every-frame Repositioning

Since implementing velocity is nothing more than the continual changing of position over time, we can implement velocity rather easily.

However, there is one thing to keep in mind when implementing movement: frame time may not be constant! In some cases, it may be constant if you are [not turning off the default constant framerate](/frb/docs/index.php?title=Microsoft.Xna.Framework.Game#Disabling_Fixed_Time_Step.md "Microsoft.Xna.Framework.Game"). However, even if your game is running at a fixed frame rate, you should not depend on this to move your object. In other words, **don't do this:**

    // NO NO NO NO NO NO NO NO!!!!
    myObject.X += 5;
    // In case you forgot, NO NO NO NO NO NO!!!!

You may at some time in the future decide to turn off the fixed frame rate, or you may want to change it. If that happens you will suddenly find that your objects are moving at a different rate - and this rate may even fluctuate as you play your game. Instead, use the [TimeManager's](/frb/docs/index.php?title=FlatRedBall.TimeManager.md "FlatRedBall.TimeManager") SecondDifference property to move your objects:

    float unitsPerSecond = 5;
    myObject.X += unitsPerSecond * TimeManager.SecondDifference;

In this code if your frame rate changes, then SecondDifference will automatically be different to reflect this change. The result is that your objects will move at the same apparent speed regardless of the frame rate.

## Every-frame management is (almost always) not necessary

As mentioned at the beginning of this article, velocity is an essential element of nearly all video games. So what kind of game engine would FlatRedBall be if it didn't provide you with support for one of the most common behaviors in game development? Surprisingly enough, there are many engines which **do not** even handle velocity for the user. But before this turns into a full commercial, let's get to the point.

The [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") is a class that is used for many common FlatRedBall objects such as [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"), [Text objects](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text"), and even custom types like [Entity classes](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Creating_a_Game_Entity.md "FlatRedBallXna:Tutorials:Creating a Game Entity"). This object has the following members available:

-   XVelocity
-   YVelocity
-   ZVelocity

All three are also available in a Vector3:

-   Velocity

Either can be used, and modifying one automatically modifies the other.

Any object which is managed by one of the FlatRedBall Managers will automatically have its position be modified by its Velocity every frame using time-based movement (using the [TimeManager's](/frb/docs/index.php?title=FlatRedBall.TimeManager.md "FlatRedBall.TimeManager") SecondDifference property). Therefore, to reproduce the above code where myObject is moving along the X axis by 5 units/second, the following code would be used:

    myObject.XVelocity = 5;

or:

    myObject.Velocity.X = 5;

Keep in mind that velocity **persists from frame to frame**. That means that you **do not** need to set an object's velocity every frame. Once you set the velocity, it will remain the same - of course unless something else modifies the velocity.

## Code Example

The following code creates 30 [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") and sets their velocities to random values. Keep in mind that the following code is placed in the Initialize method. That is, it's called **only once**. Even though you never explicitly touch the Sprite's positions, and even though velocity is never set again, the objects continue to move.

Add the following to Initialize after initializing FlatRedBall:

    for (int i = 0; i < 30; i++)
    {
        Sprite sprite = SpriteManager.AddSprite("redball.bmp");
                   
        // Set the velocity to be between -10 and 10
        sprite.XVelocity = (float)FlatRedBallServices.Random.NextDouble() * 20 - 10;
        sprite.YVelocity = (float)FlatRedBallServices.Random.NextDouble() * 20 - 10;
    }

**KABOOM!** ![VelocityTutorial.png](/media/migrated_media-VelocityTutorial.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
