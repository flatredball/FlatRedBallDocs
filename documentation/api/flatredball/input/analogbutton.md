## Introduction

The AnalogButton class is used for hardware which can report a single value, typically between 0 and 1. The most common example of an analog button is the trigger buttons on the Xbox360GamePad.

## Example Code

The following shows how to use the right trigger on an Xbox360GamePad to assign the movement speed of a SpaceShip entity:

``` lang:c#
// This code assumes there is a SpaceShipInstance with a Throttle property
var gamePad = InputManager.Xbox360GamePads[0];
SpaceShipInstance.Throttle = gamePad.RightTrigger.Position;
```

 
