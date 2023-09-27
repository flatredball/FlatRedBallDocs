## Introduction

The TargetElapsedTime member allows you to control the update frame rate of your game. **This value controls how often the Update method is called. It does not control how frequently your game is rendered to the screen.**. In other words, if your game is rendering at 60 frames per second, but you modify this value so that your game runs at 120 frames per second, that will result in the Game's Update call being executed 120 frames per second, but your game will still render at 60 frames per second. In short, your game's Update and Draw methods can run at different rates.

## Code Example

The following code will tell the game logic to run at 10 frames per second:

     // In Game1.cs
     const int framesPerSecond = 10;
     this.TargetElapsedTime = TimeSpan.FromSeconds(1/framesPerSecond);

## Fixing collision tunneling with higher frame rate

As explained in [this article](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon:Thin_Polygon_Problem.md "FlatRedBall.Math.Geometry.Polygon:Thin Polygon Problem"), tunneling occurs when the speed of a moving object is large relative to objects it is colliding against. More accurately, tunneling occurs when the amount of distance an object travels in one frame is large relative to the objects it is colliding against. By increasing the frame rate of your game, you can reduce the distance covered by an object per-frame. The following example presents a situation where a lot of tunneling is occurring, then shows how increasing the frame rate can solve this problem:

Add the following using statements:

    using FlatRedBall.Math;
    using FlatRedBall.Math.Geometry;

Add the following at class scope:

    PositionedObjectList<Circle> mCircles = new PositionedObjectList<Circle>();
    AxisAlignedRectangle mFloor;

Add the following to Initialize after initializing FlatRedBall:

    // This will increase our framerate.  Uncomment it to 
    // test it out.
    //int numberOfMillisecondsPerFrame = 2;
    //this.TargetElapsedTime = new TimeSpan(0, 0, 0, 0, numberOfMillisecondsPerFrame);

    mFloor = ShapeManager.AddAxisAlignedRectangle();
    // Make it thin and wide
    mFloor.ScaleY = .01f;
    mFloor.ScaleX = 20;
    mFloor.Y = -7;

Add the following to Update:

    const float emissionFrequency = .02f;

    if (TimeManager.SecondsSince(mLastEmissionTime) > emissionFrequency)
    {
        mLastEmissionTime = TimeManager.CurrentTime;

        Circle circle = ShapeManager.AddCircle();
        circle.Radius = .2f;
        circle.X = -13;
        circle.Y = 14;
        circle.XVelocity = 10 + (float)FlatRedBallServices.Random.NextDouble() * 10;
        circle.YVelocity = (float)-FlatRedBallServices.Random.NextDouble() * 40;
        circle.YAcceleration = -60;
        mCircles.Add(circle);
    }

    // Reverse loop since we'll be removing instances from the list
    for (int i = mCircles.Count - 1; i > -1; i--)
    {
        Circle circle = mCircles[i];
        // Make circles that are off-screen disappear so we don't get
        // an accumulation error
        if (circle.Y < -18)
        {
            ShapeManager.Remove(circle);
        }
        else
        {
            circle.CollideAgainstBounce(mFloor, 0, 1, .7f);
        }
    }

With the frame rate adjustment code commented (not used):![GameTunnelingExample.png](/media/migrated_media-GameTunnelingExample.png) With the frame rate adjustment code used:![GameWithNoTunneling.png](/media/migrated_media-GameWithNoTunneling.png)

## TargetElapsedTime and performance

While adjusting this value may seem like an effective way to solve tunneling, doing so can be dangerous. The reason for this is because reducing the TargetElapsedTime makes the game attempt to run at a higher frame rate. This means your entire update logic (all live Screens and Entities and FlatRedBall objects) will be run more frequently.

The default value for TargetElapsedTime is approximately 16 milliseconds (60 frames per second). Reducing it to 2 as we do above essentially makes your game require 8X as much processing power per frame. Or another way to look at it is that your game is 1/8 as efficient per draw call (excluding the draw calls themselves). As you can probably imagine, this is a very expensive approach to solving tunneling. But we present it here as it may be a requirement if your game needs a high degree of accuracy in its physics.
