## Introduction

IPressableInput is an interface which can be used to generalize input code for whether an input device is being pressed down, was just pressed, or was just released. Numerous common input devices are implemented as IPressableInputs.

## Code Example

The following shows how to make an entity perform actions (such as shoot bullets). It assumes that the code has an Entity called Ship, and that Ship has a function called FireBullet.

In Ship.cs:

    using FlatRedBall.Input;

    namespace ProjectName.Entities
    {
        public partial class Ship
        {
            public IPressableInput ShootingInput
            {
                get;
                set;
            }

            private void CustomInitialize()
            {
            }

            private void CustomActivity()
            {
                if (ShootingInput.WasJustPressed)
                {
                    FireBullet ();
                }
            }

            private void FireBullet()
            {
                // do the firing here
            }

            private void CustomDestroy()
            {
            }

            private static void CustomLoadStaticContent(string contentManagerName)
            {
            }
        }
    }

In the Screen's CustomInitialize, assuming it has a ShipInstance:

    // This sets up the shooting to use the space key
    ShipInstance.ShootingInput = InputManager.Keyboard.GetKey(Keys.Space);

## Common Usage

The following shows how to use the most common FRB input classes to get IPressableInputs:

``` lang:c#
// Keyboard
IPressableInput input = InputManager.Keyboard.GetKey(Keys.Space);
```

``` lang:c#
// Mouse
IPressableInput input = InputManager.Mouse.GetButton(Mouse.MouseButtons.LeftButton);
```

``` lang:c#
// Xbox360GamePad Button
IPressableInput input = InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.A);
```

``` lang:c#
// Xbox360GamePad DPad
IPressableInput input = InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.DPadLeft);
```

``` lang:c#
// Xbox360GamePad Analog Stick (Pressing to the right on the left thumb stick)
IPressableInput input = InputManager.Xbox360GamePads[0].LeftStick.RightAsButton;
```

    // Combining Multiple Inputs (Space and A will both trigger the input)
    IPressableInput input = InputManager.Keyboard.GetKey(Keys.Space)
      .Or(InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.A));

 
