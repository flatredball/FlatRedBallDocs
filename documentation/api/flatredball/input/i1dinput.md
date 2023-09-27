## Introduction

The I1DInput interface can be used to generalize input code for detecting a value and velocity along one dimension. A common usage of this is to control objects on one axis such as a platformer character's horizontal movement. Numerous common input devices are implemented as I1DInput. The Value property is typically between -1 and 1.

## Code Example

The following shows how to move an entity horizontally using I1DInput. It assumes that the code has an Entity called Character.

In Character.cs:

    using FlatRedBall.Input;

    namespace ProjectName.Entities
    {
        public partial class Character
        {
            public I1DInput HorizontalInput
            {
                get;
                set;
            }

            private void CustomInitialize()
            {
            }

            private void CustomActivity()
            {
                // This would normally be a Glue variable, but added
                // here to keep the example simpler
                float movementSpeed = 100;
                this.XVelocity = HorizontalInput.Value * movementSpeed;
            }

            private void CustomDestroy()
            {
            }

            private static void CustomLoadStaticContent(string contentManagerName)
            {
            }
        }
    }

In the Screen's CustomInitialize, assuming it has a CharacterInstance:

    // This sets up the horizontal input using the left and right arrow keys, but any keys can be used
    CharacterInstance.HorizontalInput = InputManager.Keyboard.Get1DInput(Keys.Left, Keys.Right);

## Common Usage

The following shows examples of I1DInput implementations:

    // Keyboard
    I1DInput input = InputManager.Keyboard.Get1DInput(Keys.Left, Keys.Right);

    // Mouse ScrollWheel
    // Value is not limited to -1 and +1
    I1DInput input = InputManager.Mouse.ScrollWheel;

    // Xbox360GamePad DPad (Horizontal)
    I1DInput input = InputManager.Xbox360GamePads[0].DPadHorizontal;

    // Xbox360GamePad DPad (Vertical)
    I1DInput input = InputManager.Xbox360GamePads[0].DPadVertical;

``` lang:c#
// Xbox360GamePad Trigger
I1DInput input = InputManager.Xbox360GamePads[0].RightTrigger;
```

    // Xbox360GamePad AnalogStick
    I1DInput input = InputManager.Xbox360GamePads[0].LeftStick.Horizontal;

 
