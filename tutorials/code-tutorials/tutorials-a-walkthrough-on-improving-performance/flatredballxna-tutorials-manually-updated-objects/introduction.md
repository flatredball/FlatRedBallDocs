# introduction

### Introduction

Even if you've used FlatRedBall for a while you may not be familiar with exactly what a "manually updated" object is. The reason for this is because the option to make things manually updated exists almost exclusively for performance reasons. Technically one might want to manually update objects to achieve custom behavior as well, but generally this is not encouraged because it can lead to bugs and often this type of implementation duplicates functionality already present in automatically updated objects. In short, you can designate objects as manually updated to make your game run faster, and that's usually the only reason this is done.

### What is manually updated?

To answer the question of what a manually updated object is, let's look at a very common piece of code:

```
Sprite redBall = SpriteManager.AddSprite("redball.bmp");
redball.XVelocity = 5;
```

If you've used FlatRedBall you probably know that the code above will create a [Sprite](../../../../../frb/docs/index.php), then start the Sprite's movement to the right at 5 units per second. As mentioned in one of the [introductory tutorials](../../../../../frb/docs/index.php), the Velocity property changes the Position property based off of [elapsed time](../../../../../frb/docs/index.php). This is done "automatically". This "automatic" application of velocity is what it means to be "automatically updated". So, then you might be guessing that something which is manually updated does **not** have Velocity applied to it every frame - and if so you're right! If an object is manually updated, then it means that the FlatRedBall Engine is not performing every-frame automatic updates on it.

#### Properties applied to automatically updated objects

The following is a list of properties which are applied for automatically updated objects. Not all properties apply to every automatically updated object. For example, the ScaleXVelocity property doesn't apply to Scale on the [PositionedObject](../../../../../frb/docs/index.php) class because the [PositionedObject](../../../../../frb/docs/index.php) class doesn't have the ScaleX or ScaleXVelocity properties. However, looking below can give you an idea of what kind of things are done for you by the engine:

|                                                                                              |                                                                                         |                                                                                                    |
| -------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| Property that modifies                                                                       | Modified property                                                                       | Notes                                                                                              |
| Velocity                                                                                     | Position                                                                                |                                                                                                    |
| Acceleration                                                                                 | Velocity/Position                                                                       |                                                                                                    |
| Position                                                                                     | [RealVelocity](../../../../../frb/docs/index.php#Real_Velocity_and_Acceleration)     | If [KeepTrackOfReal](../../../../../frb/docs/index.php#Real_Velocity_and_Acceleration) is true. |
| Position/[RealVelocity](../../../../../frb/docs/index.php#Real_Velocity_and_Acceleration) | [RealAcceleration](../../../../../frb/docs/index.php#Real_Velocity_and_Acceleration) | If [KeepTrackOfReal](../../../../../frb/docs/index.php#Real_Velocity_and_Acceleration) is true. |
| RotationXVelocity/RotationYVelocity/ RotationZVelocity                                       | RotationX/RotationY/RotationZ RotationMatrix                                            |                                                                                                    |
| Drag                                                                                         | Velocity                                                                                |                                                                                                    |
| RelativeVelocity                                                                             | RelativePosition                                                                        |                                                                                                    |
| RelativeAcceleration                                                                         | RelativeVelocity/RelativePosition                                                       |                                                                                                    |
| RelativeRotationXVelocity RelativeRotationYVelocity RelativeRotationZVelocity                | RelativeRotationX/RelativeRotationY/ RelativeRotationZ/ RelativeRotationMatrix          |                                                                                                    |
| Relative values                                                                              | Matching absolute values                                                                | If Parent is not null.                                                                             |
| AnimationSpeed/CurrentChain                                                                  | CurrentChainIndex/Texture/Texture coordinates                                           |                                                                                                    |
| ScaleXVelocity/ScaleYVelocity                                                                | ScaleX/ScaleY                                                                           |                                                                                                    |
| Instructions                                                                                 | Potentially anything                                                                    | The engine calls Instructions on any IInstructable that it manages.                                |
| RedRate/GreenRate/BlueRate/ AlphaRate                                                        | Red/Green/Blue/Alpha                                                                    |                                                                                                    |

### How can an object be made manually updated?

So, if you have a group of objects which do not have any of the above properties then that group of objects is a good candidate for being made manually updated. That is, an object can safely be made manually updated if it doesn't have:

* Movement
* Color rate changes
* Attachments
* Scale velocities
* Animations
* Instructions

### What kind of performance gains can you expect to see?

The answer is "it depends". It depends on how much of your game time is actually spent on updates. Converting to manually updated helps the most when your game has a large number of objects (such as [Sprites](../../../../../frb/docs/index.php) or [PositionedModels](../../../../../frb/docs/index.php)) which are going to be static - such as part of a level. It's common to have games which have hundreds or even thousands of such objects - most of which aren't even on screen. In these situations the engine may be spending a considerable amount of time updating these objects unnecessarily. Grabbing a reference to these objects (perhaps through some naming convention if using [Scenes](../../../../../frb/docs/index.php)) and converting them to be manually updated can greatly improve performance. The process is fairly straight-forward so if you suspect that you may be experiencing update-related performance issues, give it a try. For an example of how this works in a very simple scenario, see the [SpriteManager's AddManualSprite wiki entry](../../../../../frb/docs/index.php).
