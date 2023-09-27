## Introduction

Many game developers begin making their PC or Xbox games by using the keyboard as a controller. While using the actual keyboard hardware as a controller is a good way to develop quickly and conveniently, we recommend that games which may use Xbox360 game pads should use the [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.md "FlatRedBall.Input.Xbox360GamePad") class - even if development is to be done with the keyboard.

## Using ButtonMaps

The reason for this suggestion is because the Keyboard can be remapped to act as a [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.md "FlatRedBall.Input.Xbox360GamePad"). In other words, you can make a button map where you map the A key on the keyboard to the A button on the [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.md "FlatRedBall.Input.Xbox360GamePad") as follows:

    // assuming the controller at index 0 already has a valid button map:
    InputManager.Xbox360GamePads[0].ButtonMap.A = Keys.A;

Once this is done, development can happen with either a keyboard **or** a [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.md "FlatRedBall.Input.Xbox360GamePad"). This means that later on you can add logic as follows:

    Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];
    if(gamePad.ButtonPushed(Xbox360GamePad.Button.A))
    {
      myCharacter.Jump();
    }

The code below will work whether you are using a keyboard or a [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.md "FlatRedBall.Input.Xbox360GamePad"). This saves the extra code of having to 'or' ( \|\| ) a statement that checks both the [Xbox360GamePad](/frb/docs/index.php?title=FlatRedBall.Input.Xbox360GamePad.md "FlatRedBall.Input.Xbox360GamePad") and the Keyboard.

Furthemore, you can later on abstract your logic as follows:

    Xbox360GamePad.Button JumpButton = Xbox360GamePad.Button.A;

And then simply use JumpButton:

    Xbox360GamePad gamePad = InputManager.Xbox360GamePads[0];
    if(gamePad.ButtonPushed(JumpButton))
    {
      myCharacter.Jump();
    }

This is both more readable and also sets your game up so that users can remap their controls.
