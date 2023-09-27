## Introduction

The AspectRatio of the camera is the ratio of width to height. Usually the AspectRatio will match the aspect ratio of the displayable area. For example, if the displayable area has a width of 800 pixels and a height of 600 pixels, then the aspect ratio should be 800/600, or 1.333. The AspectRatio of a Camera is used to set how wide the field of view should be. Since it is not an absolute value, but rather a ratio, changing a Camera's [FieldOfView](/frb/docs/index.php?title=FlatRedBall.Camera.FieldOfView "FlatRedBall.Camera.FieldOfView") property will change the resulting viewable width. Of course, the actual AspectRatio value will be the same.

## Code Example

The following code adds a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") then modifies the AspectRatio of the default Camera. This makes the regularly-circle graphic appear stretched out. Add the following code to Initialize after initializing FlatRedBall:

    SpriteManager.AddSprite("redball.bmp");

    // Notice the ScaleX and ScaleY are not changed
    // but changing the AspectRatio makes the ball appear
    // wider.
    SpriteManager.Camera.AspectRatio = .3f; // smaller makes things look wider

![AspectRatio.png](/media/migrated_media-AspectRatio.png)
