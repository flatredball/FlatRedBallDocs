## Introduction

The DeadzoneType property controls how the Deadzone value is applied on an Xbox360GamePad. By default Radial DeadzoneType is used.

## Code Example

The following code sets the first Xbox360GamePad to use a Cross deadzone with a 0.15 value:

    InputManager.Xbox360GamePads[0].Deadzone = .15f;
    InputManager.Xbox360GamePads[0].DeadzoneType = DeadzoneType.Cross;

## Deadzone Types

### Radial

The Radial deadzone type treats the position of the analog stick as (0,0) if the position reported by the hardware is within a circle centered at (0,0) with the Deadzone value used as the radius. Visually, this means that any value within the red area would be reduced to (0,0).

![](/media/2022-05-img_62891e2bde628.png)

Radial deadzones are recommended for top-down (four-way directional) movement games.

### Cross

The Cross deadzone type treats each axis independently regardless of the value of the other axis. In other words, if the absolute value of X as reported by the hardware is smaller than the Deadzone value, then X will be reported as 0. Visually, this creates a *cross* deadzone area as shown in the following diagram:

![](/media/2022-05-img_62891e75cffae.png)

Cross deadzones are recommended for platformer games and games where players may want to move perfectly along a particular axis.
