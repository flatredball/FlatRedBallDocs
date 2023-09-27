## Introduction

The MathFunctions class provides helper methods for performing common game math.

## World and Screen Coordinates

### World to Pixel

The following code returns the screen pixel coordinates of a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). Remember, by by default in world coordinates:

-   Positive X points to the right
-   Positive Y points up

In pixel coordinates

-   Positive X points to the right
-   **Positive Y points down (only when dealing with screen pixels)**

Add the following using statements

    using FlatRedBall.Math;

Assuming myObject is a valid [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject")

    int screenX = 0;
    int screenY = 0;

    MathFunctions.AbsoluteToWindow(
       myObject.X,
       myObject.Y,
       myObject.Z,
       ref screenX,
       ref screenY,
       Camera.Main // assuming using the default camera.
    );

### Pixel to World

See [FlatRedBall.Math.MathFunctions.WindowToAbsolute](/frb/docs/index.php?title=FlatRedBall.Math.MathFunctions.WindowToAbsolute.md "FlatRedBall.Math.MathFunctions.WindowToAbsolute")
