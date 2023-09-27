## Introduction

The default FlatRedBall camera presents a 3D view - the further an object is from the camera the smaller it appears. However, the camera looks down the Z axis and its default settings assume that this is the view for performance reasons. The camera can be modified so that it doesn't have to view down the Z axis.

## Looking down a different axis

The following code creates set sthe camera to look down the Y axis rather than Z axis. It is common in 3D applications using FlatRedBall to have the ground lie on the XY axis and Z be height. Add the following in Initialize after initializing FlatRedBall:

    // Make the camera look down the Y axis so that Z is up:
    SpriteManager.Camera.RotationX = (float)System.Math.PI / 2.0f;

    // Since we're not looking down the Z axis turn off culling
    SpriteManager.Camera.CameraCullMode = CameraCullMode.None;

    // If the XY plane is the ground then Z is up.
    // Give the camera an altitude of 1 units.  
    SpriteManager.Camera.Z = 1;

    // Place a bunch of Sprites in the world on the XY plane
    for (int i = 0; i < 200; i++)
    {
        Sprite sprite = SpriteManager.AddSprite("redball.bmp");
        sprite.X = -50 + 100 * (float)FlatRedBallServices.Random.NextDouble();
        sprite.Y = 100 * (float)FlatRedBallServices.Random.NextDouble();
        
        // Make the Sprite "sit" on the ground
        sprite.Z = sprite.ScaleY;
        
        // Spin the Sprites so that they sit on the XZ plane (facing the camera)
        sprite.RotationX = (float)System.Math.PI / 2.0f;
    }

    // Set the sort type to distance along forward vector or else Sprites won't
    // sort properly.
    SpriteManager.OrderedSortType = SortType.DistanceAlongForwardVector;

![3DCamera.png](/media/migrated_media-3DCamera.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
