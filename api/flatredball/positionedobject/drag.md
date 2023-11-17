# Drag

### Introduction

The Drag property is a linear approximation of deceleration which is tied to the PositionedObject's absolute velocity. Internally drag is applied as follows (you do not need to write this code, it's just an explanation):

```
Velocity.X -= Velocity.X * Drag * TimeManager.SecondDifference;
Velocity.Y -= Velocity.Y * Drag * TimeManager.SecondDifference;
Velocity.Z -= Velocity.Z * Drag * TimeManager.SecondDifference;
```

Drag is independently applied to each component of velocity.

Drag is typically used to slow objects down over time. A non-zero Drag value is often used on objects which are also affected by acceleration. Examples include Drag slowing down a boat that is moving through water and Drag slowing down an object so that it reaches _terminal velocity._

### Drag Example

Drag is a linear approximation of deceleration which is tied to absolute velocity. It can be used to create terminal velocities (maximum velocities) when objects are moved by acceleration. The following code shows the effect of Drag on three [Sprites](../../../frb/docs/index.php).

```
Sprite sprite1 = SpriteManager.AddSprite("redball.bmp");
sprite1.XVelocity = 10;
sprite1.Y = 3;
// default Drag is 0

Sprite sprite2 = SpriteManager.AddSprite("redball.bmp");
sprite2.XVelocity = 10;
sprite2.Drag = .4f;

Sprite sprite3 = SpriteManager.AddSprite("redball.bmp");
sprite3.XVelocity = 10;
sprite3.Drag = 1;
sprite3.Y = -3;
```

![3SpritesWithDrag.png](../../../media/migrated\_media-3SpritesWithDrag.png) Managed PositionedObjects such as [Sprites](../../../frb/docs/index.php) automatically have their Drag applied every frame.

### When Is Drag Useful?

For objects which are controlled by the player such as a space ship or car, Drag is usually only used when the object is controlled by setting its acceleration value. If an object's velocity value is set every frame based off of input, then Drag will only slightly reduce the velocity for that frame. Next frame input will overwrite the velocity - effectively making Drag a dampening value.

### Drag and Equilibrium

When an object has a non-zero Drag value and is controlled through acceleration it will always reach a maximum velocity or "terminal velocity" - a term which defines the fastest that an object can fall through an atmosphere. To understand this, let's consider the amount by which the XVelocity of a PositionedObject is reduced when Drag is non-zero:

```
float xVelocityModification = -(Velocity.X * Drag * TimeManager.SecondDifference);
```

#### Drag Equilibrium

Equilibrium is reached when acceleration and drag apply equal forces. Keep in mind that the velocity over time when using drag and acceleration is an asymptote. Mathematically this means the actual terminal velocity is never reached. However, over time the velocity will get closer and closer to terminal velocity. In practical applications, a terminal velocity may be reached due to floating point inaccuracy, but it may not be exactly the same as the terminal velocity calculated mathematically. Mathematically, equilibrium can be calculated as follows:

```
EqulibriumVelocity = Acceleration / Drag;
```

This formula is easiest to calculate when Drag is 1. If Drag is 1, that means that terminal velocity will be reached when Velocity reaches Acceleration. If Drag is 2, then terminal velocity will be reached when Velocity is half of acceleration. This makes sense because higher Drag means that top speed will be reduced.

#### Distance to Stop

Drag applies a continual acceleration proportional (and in the opposite direction of) the current Velocity. Over time, an object with drag slows down to 0 (or near 0) velocity. The distance that an object travels given a starting Velocity and Drag can be calculated with the following formula:

```
var distanceTravelled = Item.Velocity / Item.Drag;
```

#### Drag Modification Examples

For this example we will use the following values:

```
Drag = 1
TimeManager.SecondDifference = .01
```

These values will make our computations simple. Velocity.X will be variable. Now, consider the effect of Drag with different Velocity.X values:

|            |                |
| ---------- | -------------- |
| Velocity.X | Effect of Drag |
| 0          | 0              |
| 1          | -.01           |
| 5          | -.05           |
| 50         | -.5            |
| 200        | -2             |

The "Effect of Drag" column displays the amount by which velocity will decrease each frame. Consider an object which has an XAcceleration of 50. This will add 50 \* TimeManager.SecondDifference to the velocity each frame, or in our case where TimeManager.SecondDifference is fixed at .01, XAcceleration will increase velocity by .5 each frame. Consider the net change in Velocity.X at the different Velocity.X values:

|            |                |                                             |
| ---------- | -------------- | ------------------------------------------- |
| Velocity.X | Effect of Drag | Net Velocity Change with XAcceleration = 50 |
| 0          | 0              | .5                                          |
| 1          | -.01           | .49                                         |
| 5          | -.05           | .45                                         |
| 50         | -.5            | 0                                           |
| 200        | -2             | -1.5                                        |

Notice that although our XAcceleration is always .5, the increase of velocity is less and less as the velocity itself is greater when Drag is non-zero. In fact, once Velocity.X reaches 50 the object's velocity reaches an equilibrium - the Drag is reducing .5 from the velocity every frame while XAcceleration is adding .5 every frame. As a note, this technically not exact as FlatRedBall's order of operations results in an equilibrium slightly different. When Velocity.X reaches a value greater than 50 the result of Drag actually reduces the velocity. Regardless of the velocity, if XAcceleration is 50 and Drag is 1, Velocity.X will move towards an equilibrium value of 50.
