## Introduction

The ButtonMap on the Xbox360GamePad allows for the Keyboard to simulate input for an Xbox360GamePad. By default this value is null, therefore the Keyboard will not simulate any input. Setting this value to a non-null value will enable keyboard simulation.

## Code Example

The following example sets up a button map for the keyboard:

    Microsoft.Xna.Framework.Input.KeyboardButtonMap buttonMap = new Microsfot.Xna.Framework.KeyboardButtonMap();

    buttonMap.LeftAnalogLeft = Keys.Left;
    buttonMap.LeftAnalogRight = Keys.Right;
    buttonMap.LeftAnalogUp = Keys.Up;
    buttonMap.LeftAnalogDown = Keys.Down;

    buttonMap.A = Keys.A;
    buttonMap.B = Keys.S;
    buttonMap.X = Keys.Q;
    buttonMap.Y = Keys.W;

    InputManager.Xbox360GamePads[0].ButtonMap = buttonMap;
