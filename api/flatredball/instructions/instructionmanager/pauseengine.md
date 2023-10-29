# pauseengine

### Introduction

The PauseEngine method can be used to freeze all velocity, rate, and acceleration, properties as well as delay all Instructions that belong to objects managed by engine managers. Calling PauseEngine and UnpauseEngine will temporarily stop then resume nearly all behavior for objects which are managed by the FlatRedBall, and in many cases is all that is necessary to implement pause functionality.

The PauseEngine method is used by the [PauseThisScreen](../../../../../frb/docs/index.php) method in the Screen class.

Keep in mind that calling PauseEngine does NOT stop the management of objects by the engine. In other words, if an object with a non-zero velocity is stopped by calling PauseEngine, but its velocity is then set to a non-zero value before calling UnpauseEngine, the object will resume movement.

This allows select objects to continue managed behavior despite other objects being paused. For example, pausing may freeze the behavior of all objects except a pause menu which should continue to behave as normally. Once the game is unpaused and the pause menu is removed, calling UnpauseEngine resumes the behavior of all objects.

Also keep in mind that any behavior which is not dependent on properties managed by the engine or dependent on Instructions must be manually controlled when implementing Pausing functionality.

### Code Sample

The following code creates an [Emitter](../../../../../frb/docs/index.php) which emits [Sprites](../../../../../frb/docs/index.php). The sprites have velocity, rate, and acceleration methods set. Despite the complex behavior of the Sprites, a simple call to PauseEngine stops all behavior. Similarly, calling UnpauseEngine resumes all behavior as expected.

Notice that the TimedEmit is a method which is explicitly called in the Update method. Since it is not managed by the engine, it must manually be called only when the program is not stopped.

Add the following using statements:

```
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Instructions;
using FlatRedBall.Input;
```

Add the following at class scope:

```
Emitter mEmitter;
bool mIsPaused = false;
```

Add the following in Initialize after initializing FlatRedBall:

```
mEmitter = SpriteManager.AddEmitter("redball.bmp", "ContentManagerName");

mEmitter.TimedEmission = true;
mEmitter.SecondFrequency = .06f;
mEmitter.EmissionSettings.AlphaRate = -.1f;
mEmitter.RemovalEvent = Emitter.RemovalEventType.Alpha0;
mEmitter.EmissionSettings.RadialVelocity = 12;
mEmitter.EmissionSettings.YAcceleration = -3;
mEmitter.ParticleBlueprint.CustomBehavior += BounceAgainstEdges;
```

Add the following in Update:

```
if (mIsPaused == false)
{
    mEmitter.TimedEmit();
}

if (mIsPaused == false && InputManager.Keyboard.KeyPushed(Keys.P))
{
    InstructionManager.PauseEngine();
    mIsPaused = true;
}
else if (mIsPaused == true && InputManager.Keyboard.KeyPushed(Keys.U))
{
    InstructionManager.UnpauseEngine();
    mIsPaused = false;
}
```

Define the BounceAgainstEdges CustomBehavior at class scope:

```
void BounceAgainstEdges(Sprite sprite)
{
    if (sprite.X + sprite.ScaleX > SpriteManager.Camera.RelativeXEdgeAt(0) &&
        sprite.XVelocity > 0)
    {
        sprite.XVelocity *= -1;
    }
    if (sprite.X - sprite.ScaleX < -SpriteManager.Camera.RelativeXEdgeAt(0) &&
        sprite.XVelocity < 0)
    {
        sprite.XVelocity *= -1;
    }
    if (sprite.Y - sprite.ScaleY < -SpriteManager.Camera.RelativeYEdgeAt(0) &&
        sprite.YVelocity < 0)
    {
        sprite.YVelocity *= -1;
    }
}
```

![PauseEngine.png](../../../../../media/migrated\_media-PauseEngine.png)

### PauseEngine and Screens

The PauseEngine method was written to work well with Screens. The PauseEngine does not turn off engine management - this is done so that any menu that appears while paused (allowing the user to restart or unpause) will still have its usual updates called. Therefore, the order for pausing and unpausing should be as follows:

* Call PauseEngine
* Add the Popup Screen
* \<User Unpauses>
* Remove the Pause Screen
* Call UnpauseEngine

The removal of the PauseEngine and calling of UnpauseEngine does not necessarily have to be performed in this order, but it is conceptually clean to treat these events as a stack and "remove off of the top".
