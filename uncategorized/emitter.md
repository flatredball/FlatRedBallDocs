# emitter

### Introduction

Emitters are [PositionedObjects](../frb/docs/index.php) which are used to create [Sprites](../frb/docs/index.php). The behavior of the created [Sprites](../frb/docs/index.php) (such as Velocity and Rotation) depends on the Emitter's properties.

All [Sprites](../frb/docs/index.php) created by Emitters are regular [Sprites](../frb/docs/index.php). This means that they can be modified just like other [Sprites](../frb/docs/index.php) after they are emitted.

### How to Create an Emitter in Glue

See [this page](../frb/docs/index.php) for information on how to add Emitters in Glue.

### How to Create an Emitter in Code

**Add the following using statement:**

```
using FlatRedBall.Graphics.Particle;
```

**Declare the Emitter at class scope:**

```
Emitter emitter;
```

**Create the Emitter in Initialize after initializing FlatRedBall:**

```
emitter = new Emitter();
SpriteManager.AddEmitter(emitter);
emitter.Texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
```

**Add the following code in Update:**

```
if (InputManager.Keyboard.KeyDown(Keys.Space))
{
    emitter.Emit();
}
```

#### Loading Emitters From File

The following code loads an emitter from an .emix file.

**Add the following using statement:**

```
using FlatRedBall.Content.Particle;
using FlatRedBall.Graphics.Particle;
```

**Create the Emitter in Initialize after initializing FlatRedBall:**

```
// Assuming myEmitter.emix is a valid file.
EmitterList emitterList = FlatRedBallServices.Load<EmitterList>(
    "myEmitter.emix", "ContentManagerName");
```

Alternatively you can use the EmitterSaveList class. This code is functionally identical to the code above:

```
// Assuming myEmitter.emix is a valid file.
EmitterSaveList emitterSaveList = EmitterSaveList.FromFile(
    "myEmitter.emix");

EmitterList emitterList = emitterSaveList.ToEmitterList("ContentManagerName");
```

#### Loading Emitters through Content Pipeline

Emitters are loaded through the Content Pipeline just like any other content type. The FlatRedBallService.Load method can load from content pipeline:

```
// Assuming myEmitter.emix is a valid file and part of the content pipeline:
EmitterList emitterList = FlatRedBallServices.Load<EmitterList>(
    @"Content\myEmitter", "ContentManagerName");
```

For more information about loading through the Content Pipeline, see the [FlatRedBall XNA Content Pipeline](../frb/docs/index.php) wiki entry.

### Timed Emitters

See the [TimedEmit](../frb/docs/index.php) entry.

### Storing Particle References and Customizing Particle Behavior

See the [Emit](../frb/docs/index.php) page.

### Particle Blueprint

The ParticleBlueprint property provides control over emitted particles. The following properties are considered when emitting Sprites:

* Texture
* CustomBehavior

### Velocity Range Type

The VelocityRangeType property in the Emitter's [EmissionSettings](../frb/docs/index.php) gives control over the velocity of the particles that are emitted. The following code creates an emitter that emits in a wedge:

**Add the following using statement:**

```
using FlatRedBall.Graphics.Particle;
```

**Add the following at class scope:**

```
Emitter emitter;
```

**Add the following in Initialize after initializing FlatRedBall:**

```
emitter = SpriteManager.AddEmitter("redball.bmp", "ContentManagerName");

emitter.EmissionSettings.RadialVelocity = 3;

emitter.EmissionSettings.WedgeAngle = 0; // straight to the right

emitter.EmissionSettings.WedgeSpread = 
    Microsoft.Xna.Framework.MathHelper.PiOver4;

emitter.EmissionSettings.VelocityRangeType = RangeType.Wedge;

emitter.TimedEmission = true;
emitter.SecondFrequency = .05f;
emitter.RemovalEvent = Emitter.RemovalEventType.OutOfScreen;
```

**Add the following in Update:**

```
emitter.TimedEmit();
```

![WedgeEmission.png](../media/migrated\_media-WedgeEmission.png)

#### Velocity Range Type and Velocity Properties

The velocity properties that are used in the EmissionSettings depends on the current VelocityRangeType. The following table shows which velocity values are used depending on the VelocityRangeType:

| VelocityRangeType   | Values Considered                                                     |
| ------------------- | --------------------------------------------------------------------- |
| RangeType.Component | XVelocityXVelocityRangeYVelocityYVelocityRangeZVelocityZVelocityRange |
| RangeType.Cone      | WedgeAngleWedgeSpreadRadialVelocityRadialVelocityRange                |
| RangeType.Radial    | RadialVelocityRadialVelocityRange                                     |
| RangeType.Spherical | RadialVelocityRadialVelocityRange                                     |
| RangeType.Wedge     | WedgeAngleWedgeSpreadRadialVelocityRadialVelocityRange                |

### Emission Area

Emitters can have areas defined for emission. This can simplifying the creation of "area" emitters like rain or explosions. The following code creates an emitter that emits in a rectangular area as defined by the Emitter's scale values.

**Add the following using statement:**

```
using FlatRedBall.Graphics.Particle;
```

**Add the following at class scope:**

```
Emitter emitter;
```

**Add the following in Initialize after initializing FlatRedBall:**

```
emitter = SpriteManager.AddEmitter("redball.bmp", "ContentManagerName");

emitter.EmissionSettings.AlphaRate = -.15f;

emitter.EmissionSettings.RadialVelocity = .1f;
emitter.TimedEmission = true;
emitter.SecondFrequency = .02f; 
emitter.RemovalEvent = Emitter.RemovalEventType.Alpha0;

emitter.AreaEmission = Emitter.AreaEmissionType.Rectangle;
emitter.ScaleX = 10;
emitter.ScaleY = 2;
```

**Add the following in Update:**

```
emitter.TimedEmit();
```

![RectangleEmissionArea.png](../media/migrated\_media-RectangleEmissionArea.png)

### Emitter Members

* [FlatRedBall.Graphics.Particle.Emitter.EmissionSettings](../frb/docs/index.php)
* [FlatRedBall.Graphics.Particle.Emitter.Emit](../frb/docs/index.php)
* [FlatRedBall.Graphics.Particle.Emitter.LayerToEmitOn](../frb/docs/index.php)
* [FlatRedBall.Graphics.Particle.Emitter.NumberPerEmission](../frb/docs/index.php)
* [FlatRedBall.Graphics.Particle.Emitter.ParentVelocityChangesEmissionVelocity](../frb/docs/index.php)
* [FlatRedBall.Graphics.Particle.Emitter.RotationZ](../frb/docs/index.php)
* [FlatRedBall.Graphics.Particle.Emitter.SecondsLasting](../frb/docs/index.php)

### Additional Information

* [SpriteManager's MaxParticleCount property](../frb/docs/index.php) - This controls how many live particles can exist at one time.
* [Particle Collision](../frb/docs/index.php)
* [Particle Performance](../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../frb/forum.md) for a rapid response.
