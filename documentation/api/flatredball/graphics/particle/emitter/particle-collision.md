# particle-collision

### Introduction

Particles which are emitted by Emitters are fully-functional [Sprites](../../../../../../frb/docs/index.php) which means they have the full set of functionality. This article presents code which creates an Emitter, then adds collision to the emitted [Sprites](../../../../../../frb/docs/index.php). Finally these emitted [Sprites](../../../../../../frb/docs/index.php) are collided against an [AxisAlignedRectangle](../../../../../../frb/docs/index.php).

### Update

The following example was written at a time when the SetCollision method was a common and encouraged way of setting collision for emitted Sprites. Since then, the [Entity](../../../../../../frb/docs/index.php) pattern has been created and is used for objects which require collision. The following code is still useful for showing how to interact with emitted particles, but please consider using an [Entity](../../../../../../frb/docs/index.php) instead of Sprites using the SetCollision method.

### Code

Add the following using statements:

```
using FlatRedBall.Graphics;
using FlatRedBall.Math.Geometry;
```

Add the following to Initialize at class scope:

```
 SpriteList mAllSprites = new SpriteList();
 SpriteList mNewlyEmittedSprites = new SpriteList();
 AxisAlignedRectangle mFloor;
```

Add the following to Initialize after initializing FlatRedBall:

```
mEmitter = SpriteManager.AddEmitter("redball.bmp",
    FlatRedBallServices.GlobalContentManager);

mEmitter.TimedEmission = true;
mEmitter.SecondFrequency = .05f;
mEmitter.RemovalEvent = Emitter.RemovalEventType.Timed;
mEmitter.SecondsLasting = 6;

mEmitter.EmissionSettings.VelocityRangeType = RangeType.Wedge;
mEmitter.EmissionSettings.WedgeAngle = (float)Math.PI/2.0f; // up
mEmitter.EmissionSettings.WedgeSpread = .4f;
mEmitter.EmissionSettings.RadialVelocity = 10;
mEmitter.EmissionSettings.RadialVelocityRange = 10;

mEmitter.EmissionSettings.YAcceleration = -13;

mFloor = ShapeManager.AddAxisAlignedRectangle();
mFloor.Y = -10;
mFloor.ScaleX = 20;
```

Add the following to Update:

```
// This block of code creates Sprites, gives them collision,
// and stores them in their lists
mNewlyEmittedSprites.Clear();
mEmitter.TimedEmit(mNewlyEmittedSprites);
for (int i = 0; i < mNewlyEmittedSprites.Count; i++)
{
    mNewlyEmittedSprites[i].SetCollision(new Circle());
}
mAllSprites.AddRange(mNewlyEmittedSprites);

// Perform collision against the ground:
for (int i = 0; i < mAllSprites.Count; i++)
{
    mAllSprites[i].CollisionCircle.CollideAgainstBounce(
        mFloor, 0, 1, .7f);
}
```

![EmitterWithCollision.png](../../../../../../media/migrated\_media-EmitterWithCollision.png)
