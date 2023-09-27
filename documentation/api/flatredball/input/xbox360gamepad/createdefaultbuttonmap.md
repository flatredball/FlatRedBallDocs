## Introduction

The CreateDefaultButtonMap method is a method which creates a button map for the calling Xbox360GamePad. This is a quick way to bind Keyboard keys to the Xbox360Controller - especially as a fallback during development if an Xbox360 game pad is not connected. For more information on creating custom button maps, see the [Xbox360GamePad ButtonMap page](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.ButtonMap "FlatRedBall.Input.Xbox360GamePad.ButtonMap").

## Button map keys

The CreateDefaultButtonMap method performs the following logic internally:

      this.ButtonMap = new KeyboardButtonMap();
      
      ButtonMap.LeftAnalogLeft = Keys.Left;
      ButtonMap.LeftAnalogRight = Keys.Right;
      ButtonMap.LeftAnalogUp = Keys.Up;
      ButtonMap.LeftAnalogDown = Keys.Down;
      
      ButtonMap.A = Keys.A;
      ButtonMap.B = Keys.S;
      ButtonMap.X = Keys.Q;
      ButtonMap.Y = Keys.W;
      
      ButtonMap.LeftTrigger = Keys.E;
      ButtonMap.RightTrigger = Keys.R;
      ButtonMap.LeftShoulder = Keys.D;
      ButtonMap.RightShoulder = Keys.F;
      
      ButtonMap.Back = Keys.Back;
      ButtonMap.Start = Keys.Enter;

## Modifying the default ButtonMap

You can modify the ButtonMap after it's been created:

    Xbox3630GamePad gamePad = FlatRedBall.Input.InputManager.Xbox360GamePads[0];
    gamePad.CreateDefaultButtonMap();
    // now reassign the A button
    gamePad.A = Keys.Q;

For more information, see the [ButtonMap page](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.ButtonMap "FlatRedBall.Input.Xbox360GamePad.ButtonMap").
