## Introduction

WindowToAbsolute converts pixel coordinates (top-left is 0,0 with Y increasing downward) to world coordinates.

## Code Example

The following code returns the world coordinates of screen pixels, assuming pixelX and pixelY are valid ints:

    float worldX = 0;
    float worldY = 0;
    float worldZ = 0;

    MathFunctions.WindowToAbsolute(
       pixelX,
       pixelY,
       ref worldX,
       ref worldY,
       worldZ,
       Camera.Main,
       CoordinateRelativity.RelativeToWorld
    );
