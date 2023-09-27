## Introduction

The CollideAgainstBounce method can be used to have two 3D shapes collide against each other and bounce (modify their or their top parent's velocity appropriately).

This function works the same as the CollideAgainstBounce provided for 2D shapes, so for a more detailed discussion, see [this page](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.CollideAgainstBounce.md "FlatRedBall.Math.Geometry.Polygon.CollideAgainstBounce").

## Code Example

The following code creates two AxisAlignedCubes, sets the acceleration of one so it falls towards the other, and calls CollideAgainstBounce so that the two collide.

Note that for this example the project is using a 3D camera rather than a 2D camera. For information on how to set up a 3D camera in Glue, see [this page](/frb/docs/index.php?title=Glue:Reference:Menu:Settings:Camera_Settings.md "Glue:Reference:Menu:Settings:Camera Settings").

Add the following at class scope in your Screen:

     AxisAlignedCube first;
     AxisAlignedCube second;

Add the following to CustomInitialize:

    first = ShapeManager.AddAxisAlignedCube();

    second = ShapeManager.AddAxisAlignedCube();
    second.Y = 5;
    second.YAcceleration = -7;

    // Move the rectangles to the right a little so we can get some
    // perspective on them
    first.X = 5;
    second.X = 5;

    // Move the camera closer to make them bigger:
    Camera.Main.Z = 20;

Add the following to CustomActivity:

    second.CollideAgainstBounce(first, 0, 1, 1);

![AACubeCollideAgainstBounce.png](/media/migrated_media-AACubeCollideAgainstBounce.png)
