## Introduction

The RotationZ property controls the rotation along the Z axis which impacts the orientation of the Emitter. The RotationZ value can impact child [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). For more information on all behavior inherited from [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"), see the [PositionedObject wiki entry](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject").

## Rotation and Emission

By default, the rotation values of an Emitter impact the velocity and orientation of emitted particles. The following code creates an Emitter, causes it to rotate by setting its RotationZVelocity. The Emitter will use TimedEmit and emit at a frequency of .1 seconds. The particles will emit in a spiral due to the spinning emitter.

Add the following using statements:

    using FlatRedBall.Graphics.Particle;
    using Microsoft.Xna.Framework.Graphics;

Add the following at class scope:

    Emitter emitter;

Add the following to Initialize after initializing FlatRedBall:

    emitter = new Emitter();
    emitter.EmissionSettings.VelocityRangeType = RangeType.Wedge;
    emitter.Texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
    emitter.RotationZVelocity = 1;
    emitter.TimedEmission = true;
    emitter.SecondFrequency = .1f;
    emitter.RemovalEvent = Emitter.RemovalEventType.OutOfScreen;

    // The Emitter must be added to the SpriteManager for its 
    // RotationalVelocity (or any other velocity or acceleration) to 
    // be applied.
    SpriteManager.AddEmitter(emitter);

Add the following to Update:

    emitter.TimedEmit();

![EmitterRotation.png](/media/migrated_media-EmitterRotation.png)
