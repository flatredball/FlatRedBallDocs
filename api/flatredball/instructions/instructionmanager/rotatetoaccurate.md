# rotatetoaccurate

### Introduction

The RotateToAccurate method creates and adds [Instructions](../../../../../frb/docs/index.php) for rotating the argument PositionedObject to the argument rotation. The method takes three values as it can perform rotation on the X, Y, and Z rotation components.

### Code Example

The following code creates and rotates a [Sprite](../../../../../frb/docs/index.php) so that its rotation matches the angle from the [Sprite](../../../../../frb/docs/index.php) to the [Mouse](../../../../../frb/docs/index.php) when the user clicks the left button. Add the following using statements:

```
using FlatRedBall.Input;
using FlatRedBall.Instructions;
```

Add the following at class scope:

```
Sprite sprite;
```

Add the following in Initialize after initializing FlatRedBall:

```
sprite = SpriteManager.AddSprite("redball.bmp");
sprite.ScaleX = 4;
```

Add the following in Update:

```
if (InputManager.Mouse.ButtonReleased(FlatRedBall.Input.Mouse.MouseButtons.LeftButton))
{
    float angle = (float)(System.Math.Atan2(
        InputManager.Mouse.WorldYAt(0) - sprite.Y,
        InputManager.Mouse.WorldXAt(0) - sprite.X));
    float secondsToTake = 1;
    // Just in case there are other instructions around from the 
    // last call: 
    sprite.Instructions.Clear();

    // Adds instructions to the Sprite's Instructions list. 
    InstructionManager.RotateToAccurate(sprite, 0, 0, angle, secondsToTake); 
}
```

![RotateToAccurate.png](../../../../../media/migrated_media-RotateToAccurate.png)
