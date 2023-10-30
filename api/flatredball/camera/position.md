# position

### Introduction

The Camera is a [PositionedObject](../../../../frb/docs/index.php) therefore it has a Position variable which works the same as the [PositionedObject's Position variable](../../../../frb/docs/index.php). The default position for Cameras is:

```
X = 0
Y = 0
Z = 40
```

### Camera and CameraControllingEntity

Projects which have been created with the Wizard will have a CameraControllingEntity instance in the GameScreen. This instance automatically adjusts the position of the camera according to its own settings.

![](../../../../media/2022-10-img_635b07de5a0f8.png)

If your game includes a CameraControllingEntityInstance, then the Camera's position will automatically be determined by this object. If you would like to manually control the Camera, you can delete the CameraControllingEntityInstance from your game. For more information on how to use the CameraControllingEntity, see the [CameraControllingEntity page](../entities/cameracontrollingentity.md).

### Code Example - Changing X and Y

The default (unrotated Camera) looks down the Z axis. This means that if you want the center of the screen to be at a certain coordinate, you simply need to set the Camera's X and Y value.

```
 AxisAlignedRectangle axisAlignedRectangle = ShapeManager.AddAxisAlignedRectangle();
 axisAlignedRectangle.ScaleX = 30;
 axisAlignedRectangle.ScaleY = 20;
 // make the Camera look at the top-right corner:
 Camera.Main.X =
     axisAlignedRectangle.X + axisAlignedRectangle.ScaleX;

 Camera.Main.Y =
     axisAlignedRectangle.Y + axisAlignedRectangle.ScaleY;
```

![TopRightAARect.PNG](../../../../media/migrated_media-TopRightAARect.PNG)

### Code Example - Camera and Tile Maps

By default a TileMap's top-left corner will be positioned at X=0, Y=0. By default, the camera is centered at X=0, Y=0, so the top left of the map will appear in the center of the screen. For example, the following image shows how a level will appear in Tiled and in game:

![](../../../../media/2021-07-img_60f1ebc8055fe.png)

One way to solve this problem is to change the Camera's X and Y values to be at the center of the tilemap. This can be adjusted by using the dimensions of the map, or arbitrarily by adding some constant value to the X and subtracting some value from the Y. For example, the following code will center on the map:

```
Camera.Main.X = Map.Width / 2.0f;
Camera.Main.Y = -Map.Height / 2.0f;
```

Now the Camera will be centered on the map as shown in the following image:

![](../../../../media/2021-07-img_60f1eca81d13b.png)

### Z controls panning

Changing the Z value of the Camera will make the camera move "forward" and "backward" in the world. This is a way to simulate zooming (technically "zooming" is accomplished by changing the Camera's [FieldOfView](../../../../frb/docs/index.php)). This will only work on 3D cameras. To make objects appear smaller, you will want to increase the Z value of the Camera. For example:

```
Camera.Main.Z = 50; // things will be smaller than default, because the default is 40
Camera.Main.Z = 100; // even smaller
Camera.Main.Z = 10; // things will be really big!
```
