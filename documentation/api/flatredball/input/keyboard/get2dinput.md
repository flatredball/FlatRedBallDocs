## Introduction

Get2DInput returns an I2DInput instance using the argument keys. This function can be used to abstract input, allowing the same input code to use keyboards and Xbox360GamePad instances. For more information see the [I2DInput](/documentation/api/flatredball/flatredball-input/flatredball-input-i2dinput.md) page.

## Code Example

The following code can be used to create an I2DInput instance:

``` lang:c#
// at class scope:
I2DInput input;

// In some initialize code such as
// CustomInitialize in an entity:
input = InputManager.Keyboard.Get2DInput(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
```

 
