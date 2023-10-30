# rotationmatrix

### Introduction

The Camera object inherits from the PositionedObject class. Therefore, it can be rotated just like any other PositionedObject. For information on using rotation values on a PositionedObject in general, see the following pages:

* [FlatRedBall.PositionedObject.RotationX](../../../../frb/docs/index.php)
* [FlatRedBall.PositionedObject.RotationY](../../../../frb/docs/index.php)
* [FlatRedBall.PositionedObject.RotationZ](../../../../frb/docs/index.php)
* [FlatRedBall.PositionedObject.RotationMatrix](../../../../frb/docs/index.php)

By default the Camera will attempt to orient itself so that "up" is the Y vector (0,1,0). For more information see the [UpVector page](upvector.md).

### Code Example

The Camera can be rotated to be facing any direction. Keep in mind that many systems in FlatRedBall are designed to work in 2D, so making a game with a rotated Camera is more difficult. The following shows how to rotate the camera to simulate looking at an angle at a "floor" made up of the redball graphic. Add the following code to either Game1.cs's Initialize function, or your Screen's CustomInitialize function:

```
 for (int x = 0; x < 10; x++)
 {
     for (int y = 0; y < 10; y++)
     {
         Sprite sprite = SpriteManager.AddSprite("redball.bmp");
         // Default Sprites are 2x2 so we need to multiply by 2 to make
         // them sit end-to-end
         sprite.X = x * 2;
         sprite.Y = y * 2;
     }
 }

 // Now let's rotate the Camera on the Y axis so it looks at an angle:
 // Making this number larger will make the camera more at the horizon.
 // Making the number smaller will make the camera look more at the ground.
 // A value of 0 is perfectly top-down.  A value of Math.PI/2 (about 1.51)
 // will make the camera look at the horizon.
 SpriteManager.Camera.RotationX = .6f;

 SpriteManager.Camera.X = 10;

 // We need to move the camera down a bit so it can look up at the Sprites:
 SpriteManager.Camera.Y = -5;

 // Let's bring the camera "closer to the ground"
 SpriteManager.Camera.Z = 20;

 // If the camera is rotated, we need to turn off cull mode:
 SpriteManager.Camera.CameraCullMode = CameraCullMode.None;
```

![RotatedCamera.PNG](../../../../media/migrated_media-RotatedCamera.PNG)
