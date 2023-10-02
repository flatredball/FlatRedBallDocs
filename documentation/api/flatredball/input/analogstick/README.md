# analogstick

### Introduction

The AnalogStick class provides a variety of information about an AnalogStick on an [Xbox360GamePad](../../../../../frb/docs/index.php).

### Position

The [Xbox360GamePad](../../../../../frb/docs/index.php) class exposes two analog sticks: LeftStick and RightStick. The following code will move a [Sprite](../../../../../frb/docs/index.php) according to how the LeftStick is positioned: Add the following at class scope:

```
Sprite mySprite;
```

Add the following to Initialize after initializing FlatRedBall:

```
mySprite = SpriteManager.AddSprite("redball.bmp");
```

Add the following to Update:

```
 // Assuming mySprite is a valid Sprite
 Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];

 // Position values are between -1 and 1, inclusive.
 mySprite.XVelocity = gamePad.LeftStick.Position.X;
 mySprite.YVelocity = gamePad.RightStick.Position.Y;
```

### As DPad

The analog stick can report information as if it were a DPad, which is useful for games where you control an object or UI over a discrete set of positions, such as moving a selection cursor over a grid of characters in a fighting game. The following code shows how to move a Sprite by 16 pixels in any direction:

```
// Assuming mySprite is a valid Sprite
Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];

AnalogStick leftAnalogStick = gamePad.LeftStick;

const float amountToMove = 16;

if (leftAnalogStick.AsDPadPushed(Xbox360GamePad.DPadDirection.Up))
{
    mySprite.Y += amountToMove;
}
if (leftAnalogStick.AsDPadPushed(Xbox360GamePad.DPadDirection.Down))
{
    mySprite.Y -= amountToMove;
}
if (leftAnalogStick.AsDPadPushed(Xbox360GamePad.DPadDirection.Left))
{
    mySprite.X -= amountToMove;
}
if (leftAnalogStick.AsDPadPushed(Xbox360GamePad.DPadDirection.Right))
{
    mySprite.X += amountToMove;
}
```

### AsDPadRepeatRate

The AsDPadRepeatRate method results in the AnalogStick behaving as a DPad with repeat-rate logic. In other words, when the user holds the AnalogStick initially pushes the analog stick in a direction, the AsDPadRepeatRate method returns true. It keeps track of the last time it returned true and will continue to return true at a set frequency so long as the user holds the AnalogStick in that direction. The following code creates a [Sprite](../../../../../frb/docs/index.php) which is moved .5 units every time the analog stick is pressed or whenever the push triggers through the repeat-rate logic. Add the following at class scope:

```
Sprite mySprite;
```

Add the following to Initialize after initializing FlatRedBall:

```
mySprite = SpriteManager.AddSprite("redball.bmp");
```

Add the following to Update:

```
// Assuming mySprite is a valid Sprite
Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];

AnalogStick leftAnalogStick = InputManager.Xbox360GamePads[0].LeftStick;

const float amountToMove = .5f;

if (leftAnalogStick.AsDPadPushedRepeatRate(Xbox360GamePad.DPadDirection.Up))
{
    mySprite.Y += amountToMove;
}
if (leftAnalogStick.AsDPadPushedRepeatRate(Xbox360GamePad.DPadDirection.Down))
{
    mySprite.Y -= amountToMove;
}
if (leftAnalogStick.AsDPadPushedRepeatRate(Xbox360GamePad.DPadDirection.Left))
{
    mySprite.X -= amountToMove;
}
if (leftAnalogStick.AsDPadPushedRepeatRate(Xbox360GamePad.DPadDirection.Right))
{
    mySprite.X += amountToMove;
}
```

#### Repeat Rate Frequency

The amount of time between the initial push and the first repeat is longer than the space between subsequent repeats. This is similar to the repeat rate resulting from holding down a key on the keyboard.

\[subpages depth="1"]
