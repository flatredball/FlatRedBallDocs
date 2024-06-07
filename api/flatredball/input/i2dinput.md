# I2DInput

### Introduction

The I2DInput interface can be used to generalize input code for detecting a value and velocity along two dimensions (X and Y). A common usage of this is to control an object's 2-dimensional movement such as a character in a top-down game. Examples of input devices implemented as I2DInput are the GamePad AnalogStick and the GamePad DPad. The X and Y properties typically return values between -1 and 1.

### Code Example - Implementing Movement

The following shows how to move an entity horizontally and vertically using I2DInput. It assumes that the code has an Entity called Character. Note - this example assumes your entity does not already implement the Top Down input movement in the FRB Editor.

In Character.cs:

```csharp
using FlatRedBall.Input;

namespace ProjectName.Entities
{
    public partial class Character
    {
        public I2DInput MovementInput
        {
            get;
            set;
        }

        private void CustomInitialize()
        {
        }

        private void CustomActivity()
        {
            // This would normally be a FRB variable on the entity, but added
            // here to keep the example simpler
            float movementSpeed = 100;
            this.XVelocity = MovementInput.X * movementSpeed;
            this.YVelocity = MovementInput.Y * movementSpeed;
        }

        private void CustomDestroy()
        {
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {
        }
    }
}
```

In the Screen's CustomInitialize, assuming it has a CharacterInstance:

```csharp
// This sets up the movement to use the Up, Down, Left, and Right arrow keys, but any keys could be used
CharacterInstance.MovementInput= InputManager.Keyboard.Get2DInput(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
```

### Common Usage

The following shows how to use the most common FRB input classes to get a I2DInput:

Keyboard

```csharp
var input = InputManager.Keyboard.Get2DInput(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
```

Xbox360GamePad DPad

```clike
var input = InputManager.Xbox360GamePads[0].DPad;
```

Xbox360GamePad AnalogStick

```csharp
var input = InputManager.Xbox360GamePads[0].LeftStick;
```

### Magnitude

The Magnitude property returns the distance away from (0,0) that is returned by the input device. By default most input devices return an X and Y value of (0,0) which would indicate a magnitude of 0. If the values are non-zero, then the magnitude will also be non-zero. Typically the Magnitude is between 0 and 1.

### Or Extension Method

I2DInput provides an extension method for combining multiple controls. The `Or` method allows combining multiple input devices to create a single I2DInput instance. For example, you may be developing a game where the player can be moved with both the keyboard and gamepad. When multiple inputs are combined using `Or`, the largest of either inputs will be used. For example, if one input device returns an X of 0.5f, and the other returns an X value of 1, then the value of 1 will be returned by the combined object.

The Or method returns an instance of Multiple2DInputs.

### Or Code Example

The Or method can be used to combine any number of inputs to produce a single input. For example, the following code could be used to "Or" the arrow keys with WASD:

```csharp
var arrowKeyboardInput = InputManager.Keyboard.Get2DInput(
    Microsoft.Xna.Framework.Input.Keys.Left,
    Microsoft.Xna.Framework.Input.Keys.Right,
    Microsoft.Xna.Framework.Input.Keys.Up,
    Microsoft.Xna.Framework.Input.Keys.Down);

var wasdKeyboardInput = InputManager.Keyboard.Get2DInput(
    Microsoft.Xna.Framework.Input.Keys.A,
    Microsoft.Xna.Framework.Input.Keys.D,
    Microsoft.Xna.Framework.Input.Keys.W,
    Microsoft.Xna.Framework.Input.Keys.S);
var combined = arrowKeyboardInput.Or(wasdKeyboardInput);
```

The following code can be used to "Or" arrow key movement with an Xbox360GamePad's LeftStick.

```csharp
var keyboardInput = InputManager.Keyboard.Get2DInput(
    Microsoft.Xna.Framework.Input.Keys.Left,
    Microsoft.Xna.Framework.Input.Keys.Right,
    Microsoft.Xna.Framework.Input.Keys.Up,
    Microsoft.Xna.Framework.Input.Keys.Down);

var analogStickInput = InputManager.Xbox360GamePads[0].LeftStick;

var combined = keyboardInput.Or(analogStickInput);
// combined is an I2DInput which can be used like any other I2DInput
```
