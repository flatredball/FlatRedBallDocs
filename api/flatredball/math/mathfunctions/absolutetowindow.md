## Introduction

AbsoluteToWindow converts an absolute coordinate to a window coordinate (where 0,0 is the top left of the screen). This can be used to identify the screen coordinates of a FlatRedBall object. This is sometimes necessary to translate between 2D and 3D coordinates, or to obtain screen coordinates for systems which use screen-based coordinates (like Gum).

## Code Example

The following can be used to obtain the screen coordiantes of a FlatRedBall Sprite:

    // Assuming SpriteInstance is a valid Sprite

    int screenX;
    int screenY;

    MathFunctions.AbsoluteToWindow(SpriteInstance.X, SpriteInstance.Y, SpriteInstance.Z, ref screenX, ref screenY, Camera.Main);
