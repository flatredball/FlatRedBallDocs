# SecondDifference

### Introduction

The SecondDifference property returns the amount of time that has passed since the last frame. This value is updated only once per frame, and will remain the same value throughout an entire frame. This value can be used to manually update a value (such as an object's position) according to time (as opposed to frames).

### Code example

The following code shows how to adjust the position of an object so that it moves at 100 pixels per second.

```lang:c#
const int PixelsPerSecond = 100;
MyObject.X += TimeManager.SecondDifference * PixelsPerSecond;
```

Note that if you are working with Entities, you can also the [Velocity property](../positionedobject/velocity.md) to achieve the same result.

### Measuring Framerate

You can use the SecondDifference property to measure how long a frame has taken. This information can be used to get how many frames per second your game is running at. To do this:

```
float framesPerSecond = 1/TimeManager.SecondDifference;
```

**The default behavior of FRB is to attempt to force a certain frame rate.** Keep in mind that by default FRB attempts to keep framerate at 60 fps so you will want to disable fixed framerate to get more accurate performance numbers. For more information see the [disabling fixed time step wiki entry](../../microsoft-xna-framework/game/isfixedtimestep.md). If your game is running slowly, or if you have very long frames (such as when the game first starts, or when transitioning between screens) frame time may be longer.

### Detailed Discussion

The TimeManager.SecondDifference returns the amount of time that the last frame took to process and render - or more specifically the second difference between the start of the current frame and the start of the last frame. This can be used to apply time based movement to objects. Keep in mind that this is usually not necessary as most [PositionedObjects](../positionedobject/) are associated with managers which automatically apply velocity to position. For information on turning off the fixed time step, see the [disabling fixed time step](../../microsoft-xna-framework/game/isfixedtimestep.md) wiki entry. The following code manually applies a velocity to a [PositionedObject](../positionedobject/).

```
// This code belongs in Update or some other method which is called every frame.
// Assume positionedObject is a valid PositionedObject, and that xVelocity,
// yVelocity, and zVelocity are defined floats which specify velocity in units
// per second.
positionedObject.X += xVelocity * TimeManager.SecondDifference;
positionedObject.Y += zVelocity * TimeManager.SecondDifference;
positionedObject.Z += yVelocity * TimeManager.SecondDifference;
```

#### Time Based Movement

When first considering how to move objects in your game, you may realize that the Update method is called every frame. Therefore, making small changes every time Update looks like a good way to move your objects. This may or may not be true depending on your implementation. One method that is often seen as the most obvious way to gradually change the value of an object is to increase or decrease it by some value as follows:

```
// Moves the object to the right .01 units every frame
myObject.X += .01;
```

While the code is very simple, there is one main problem - it's tied to framerate. The FlatRedBall XNA template **does** by default run at a set framerate; however, you may at any time decide to change this framerate, or even turn off fixed framerate calculations fo a number of reasons. If you end up doing this, your objects will all of a sudden start to run at different speeds. Furthermore, this speed may fluctuate depending on the resources available to your computer, and can vary greatly when running your game on different machines. As mentioned in the section above, accurate time based movement can be accomplished using the SecondDifference value:

```
// Moves the object to the right 1 unit per second regardless of framerate
myObject.X += 1 * TimeManager.SecondDifference;
```

This is better because it resolves the issue of being dependent on frame time, and in some cases this is the best or only solution to moving objects. However, the [PositionedObject](../positionedobject/) (and objects which inherit from it) expose velocity and rate values for many properties including position and rotation. Other objects include velocity and rate values for scale and color component values. For example, the above code to move an object by 1 unit per second can also be accomplished as follows:

```
// This only needs to be called once.  Velocity persists!
myObject.XVelocity = 1;
```

Using velocity and rate values can help reduce object management and keeps code cleaner.

#### Framerate

Since SecondDifference reports the amount of time since your last frame, then you can calculate the framerate as follows:

```
float framerate = 1 / TimeManager.SecondDifference;
```

Keep in mind that FRB XNA by default keeps framerate at 60 fps. For more information, see the [disabling fixed time step wiki entry](../../microsoft-xna-framework/game/isfixedtimestep.md).
