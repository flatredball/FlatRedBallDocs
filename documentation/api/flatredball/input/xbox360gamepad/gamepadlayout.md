## Introduction

The GamepadLayout property returns the type of layout that the Xbox360GamePad returns. This property is set according to the ID and Name reported by the gamepad. Note that this is not always accurate as some manufacturers reuse IDs and Names for different gamepads. If you have a gamepad which is incorrectly reported, please report this in the FlatRedBall chat or create a pull request in the Xbox360GamePad.cs file. Note that the InputManager includes an array of Xbox360GamePad objects for historical and convenience reasons - even controllers which are not Xbox360 (or Xbox One) controllers will appear in this list, such as PlayStation Dual Shock controllers.

## Code Example - Selecting a GamePad Icon According to GamepadLayout

The following code could be used to select an icon for a gamepad based on the gamepad layout.

    var gamepad = InputManager.Xbox360GamePads[0]
    switch(gamepad.GamepadLayout)
    {
        case GamepadLayout.Xbox360:
            SetIcon(Xbox360GamepadIcon);
            break;
        case GamepadLayout.SwitchPro:
            SetIcon(SwitchProIcon);
            break;
        case GamepadLayout.PlayStationDualShock:
            SetIcon(PlayStationDualShockIcon);

            break;
            // etc...
    }

 
