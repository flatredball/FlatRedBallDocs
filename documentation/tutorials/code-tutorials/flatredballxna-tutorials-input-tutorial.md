## Introduction

So far the tutorials have covered some of the basics of working with FlatRedBall. However, FlatRedBall is a Game Engine, and video games are defined as being "interactive". That means that not only does the game present information to the user, but the user must also "communicate" back to the game. The three most common input devices for interacting with a game are:

-   [Keyboard](/frb/docs/index.php?title=FlatRedBall.Input.Keyboard "FlatRedBall.Input.Keyboard")
-   [Mouse](/frb/docs/index.php?title=FlatRedBall.Input.Mouse "FlatRedBall.Input.Mouse")
-   [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad "FlatRedBall.Input.Xbox360GamePad") (Not currently available in FlatSilverBall)

Numerous other devices exist and can be used with FlatRedBall, but these three are natively supported and will satisfy most video game input requirements. The following will provide simple examples on how to use each input device. For more information check the wiki articles for each. These articles are linked above in the bullet points.

## Keyboard

The [Keyboard](/frb/docs/index.php?title=FlatRedBall.Input.Keyboard "FlatRedBall.Input.Keyboard") class contains information about the keyboard's state and activities that have occurred during the current frame. The Keyboard can give you the following information:

-   Whether a key is currently held down
-   Whether a key has been pushed down - was not down last frame, is down this frame.
-   Whether a key has been released - was down last frame, is not down this frame.
-   Whether a key has been "typed" - was either pushed or if it's being held down and its "repeat rate" has triggered.
-   The string (usually just one letter) that the user has typed. This formats information so that holding Shift + the A key will result in a capital A.

## Keyboard Example

The following code creates a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") which is controlled by the Keyboard: Add the following using statement:

    using FlatRedBall.Input;

Add the following at class scope:

    Sprite sprite;

Add the following in Initialize after Initializing FlatRedBall:

    sprite = SpriteManager.AddSprite("redball.bmp");

Add the following in Update:

    if (InputManager.Keyboard.KeyDown(Keys.Up))
    {
        sprite.YVelocity = 3;
    }
    else if (InputManager.Keyboard.KeyDown(Keys.Down))
    {
        sprite.YVelocity = -3;
    }
    else
    {
        sprite.YVelocity = 0;
    }

    if (InputManager.Keyboard.KeyDown(Keys.Right))
    {
        sprite.XVelocity = 3;
    }
    else if (InputManager.Keyboard.KeyDown(Keys.Left))
    {
        sprite.XVelocity = -3;
    }
    else
    {
        sprite.XVelocity = 0;
    }

## Mouse

The [Mouse](/frb/docs/index.php?title=FlatRedBall.Input.Mouse "FlatRedBall.Input.Mouse") class contains information about the mouse's state and activities that have occurred during the current frame. The [Mouse](/frb/docs/index.php?title=FlatRedBall.Input.Mouse "FlatRedBall.Input.Mouse") can give you the following information:

-   Whether a button is currently held down.
-   Whether a button has been pushed down - was not down last frame, is down this frame.
-   Whether a button has been "clicked" - was down last frame, is not down this frame.
-   Whether a button has been "double-clicked" - if two clicks have happened in a brief period of time.
-   The position of the cursor in both world and pixel units.
-   The movement of the scroll wheel.

## Mouse Example

The following creates a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") which reacts to the movements, pushes, and scroll wheel of the [Mouse](/frb/docs/index.php?title=FlatRedBall.Input.Mouse "FlatRedBall.Input.Mouse"). Add the following using statement:

    using FlatRedBall.Input;

Add the following at class scope:

    Sprite sprite;

Add the following in Initialize after Initializing FlatRedBall:

    sprite = SpriteManager.AddSprite("redball.bmp");

Add the following in Update:

    sprite.X = InputManager.Mouse.WorldXAt(0);
    sprite.Y = InputManager.Mouse.WorldYAt(0);

    if(InputManager.Mouse.ButtonPushed(
        FlatRedBall.Input.Mouse.MouseButtons.LeftButton))
    {
        sprite.ScaleX += .2f;
    }

    sprite.RotationZ += InputManager.Mouse.ScrollWheel / 12.0f;

## Xbox360GamePad

The [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad "FlatRedBall.Input.Xbox360GamePad") class contains information about a Xbox 360 game pad's state and activities that have occurred during the current frame. Up to four game pads can be connected at one time, so the game pads exist in an array in the [InputManager](/frb/docs/index.php?title=FlatRedBall.Input.InputManager "FlatRedBall.Input.InputManager"). The [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad "FlatRedBall.Input.Xbox360GamePad") can give you the following information:

-   The position, velocity, and angle of either analog sticks.
-   Whether a button is down, has been pushed, or has been released.
-   The position and velocity of the shoulder triggers.
-   Whether it is connected - this is used to determine whether a game pad is connected and which game pads should be polled for input.
-   Control over the vibration - the vibration can be set on the game pad in response to game events.

## Xbox360GamePad Example

The following code creates a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") which reacts to the position of the triggers, the position of the left analog stick, and pressing the A button. Add the following using statement:

    using FlatRedBall.Input;

Add the following at class scope:

    Sprite sprite;

Add the following in Initialize after Initializing FlatRedBall:

    sprite = SpriteManager.AddSprite("redball.bmp");

Add the following in Update:

    // This assumes you have an Xbox 360 controller connected
    Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];

    sprite.XVelocity = gamePad.LeftStick.Position.X * 4;
    sprite.YVelocity = gamePad.LeftStick.Position.Y * 4;

    sprite.ScaleX = 1 + gamePad.LeftTrigger.Position * 3;
    sprite.ScaleY = 1 + gamePad.RightTrigger.Position * 3;

    if (gamePad.ButtonPushed(Xbox360GamePad.Button.A))
    {
        sprite.RotationZ += .2f;
    }
