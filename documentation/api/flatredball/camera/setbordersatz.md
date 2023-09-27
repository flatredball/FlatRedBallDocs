## Introduction

As explained in [this tutorial](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Camera_and_Coordinates "FlatRedBallXna:Tutorials:Camera and Coordinates") the Camera's X and Y position are the center of the screen (unless the Camera is rotated). Therefore, to keep the Camera from viewing outside of a specific area, the visible width and height must be calculated. In other words, if the Camera should not be able to see anything to the left of X = 0, then the width of the Camera needs to be calculated, and the actual minimum X becomes

    0 + cameraWidthAtSomeZ/2.0f;

The SetBordersAtZ simplifies this process by doing the calculation of cameraWidthAtSomeZ automatically, and even updating mins and maxes if the Camera moves along the Z axis. The SetBordersAtZ sets the following Camera properties:

-   MinimumX
-   MinimumY
-   MaximumX
-   MaximumY

The SetBordersAtZ calculates what the minimum and maximum values need to be set at to keep the first four argument values as the visible borders at the Z value passed (fifth argument).

## Code Example

The following code prevents the user from viewing behind +/- 40 on the X and Y axes. Note that bounds will be exceeded if the field of view or aspect ratio is too large for the argument values. The [Keyboard](/frb/docs/index.php?title=FlatRedBall.Input.Keyboard "FlatRedBall.Input.Keyboard") moves the Camera so the bounds can be tested. Add the following using statements:

    using FlatRedBall.Input;

Add the following to Initialize after initializing FlatRedBall:

    float minimumX = -40;
    float minimumY = -40;
    float maximumX = 40;
    float maximumY = 40;
    float zToSetAt = 0;

    SpriteManager.Camera.SetBordersAtZ(minimumX, minimumY, maximumX, maximumY, zToSetAt);

    // Add a Sprite so the bounds can be visibly tested
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.ScaleX = 40;
    sprite.ScaleY = 40;

Add the following to Update:

    // Use the arrow keys to move the Camera
    InputManager.Keyboard.ControlPositionedObject(SpriteManager.Camera);

![CameraBounds.png](/media/migrated_media-CameraBounds.png)
