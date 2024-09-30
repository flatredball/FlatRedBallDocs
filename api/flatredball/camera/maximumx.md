# MaximumX

### Introduction

The MaximumX, MaximumY, MinimumX, and MinimumY properties can set the minimum and maximum X and Y positional values for a given Camera. These properties can be used to create boundaries beyond which the camera cannot move. These are often used in games to keep the camera viewing the playable area and keep areas beyond the playable bounds from being viewed.

### Note about Cameras and Entities

If you have a Camera which is part of an Entity then the Camera will be attached to that Entity (by default). The minimum and maximum values will prevent the Camera from moving behond the values you specify, but it will not prevent the parent Entity from moving beyond the bounds. In this situation it is advised to use your own custom min and max implementation.

### Code Sample

The following code allows the user to move the camera with the arrow keys on the keyboard, but bounds the position of the Camera to the edges of the [AxisAlignedRectangle](../../../frb/docs/index.php) created in the Initialize method.

Add the following to your Screen's CustomInitialize:

```
 AxisAlignedRectangle rectangle = ShapeManager.AddAxisAlignedRectangle();
 rectangle.ScaleX = 500;
 rectangle.ScaleY = 500;

 Camera.Main.MaximumX = rectangle.X + rectangle.Width/2.0f;
 Camera.Main.MaximumY = rectangle.Y + rectangle.Height/2.0f;
 Camera.Main.MinimumX = rectangle.X - rectangle.Width/2.0f;
 Camera.Main.MinimumY = rectangle.Y - rectangle.Height/2.0f;
```

Add the following to Update

```
InputManager.Keyboard.ControlPositionedObject(Camera.Main, 100);
```

![MinimumMaximumCameraValues.png](../../../.gitbook/assets/migrated\_media-MinimumMaximumCameraValues.png)

### Removing Minimum and Maximum Values

See [FlatRedBall.Camera.ClearMinimumsAndMaximums](../../../frb/docs/index.php).
