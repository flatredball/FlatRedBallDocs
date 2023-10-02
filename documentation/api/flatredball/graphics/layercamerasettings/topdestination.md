# topdestination

### Introduction

The TopDestination, BottomDestination, LeftDestination, and RightDestination properties of the LayerCameraSettings class allow [Layers](../../../../../frb/docs/index.php) to render to only a portion of the Screen (also known as creating a mask). These coordinates are measured in pixel units in screen space. In other words, 0 is the left side of the screen for LeftDestination and RightDestination, and it increases to the right. The value of 0 is the top of the screen for TopDestination and BottomDestination, and it increases downward. The destination values are not necessarily used when a given Layer is rendered. The default value for TopDestination, BottomDestination, LeftDestination, and RightDestination is -1. If -1 is used, then the Camera's DestinationRectangle values are used.

### Code Example

The following code creates a LayerCameraSetting which has a 200 pixel border around the edges of the screen. The Layer draws a large Sprite which is masked by the destination values of the LayerCameraSettings. Add the following using statement:

```
using FlatRedBall.Graphics;
```

Add the following to Initialize after initializing FlatRedBall:

```
 // Make sure the camera is in 3D:
 SpriteManager.Camera.Orthogonal = false;
 // Create a new Layer
 Layer layer = SpriteManager.AddLayer();
 // Create a LayerCameraSettings
 LayerCameraSettings layerCameraSettings = new LayerCameraSettings();
 layerCameraSettings.Orthogonal = true;
 
 layerCameraSettings.TopDestination = 200;
 layerCameraSettings.BottomDestination = 400;
 layerCameraSettings.LeftDestination = 200;
 layerCameraSettings.RightDestination = 600;
 layerCameraSettings.OrthogonalWidth = layerCameraSettings.RightDestination - layerCameraSettings.LeftDestination;
 layerCameraSettings.OrthogonalHeight = layerCameraSettings.BottomDestination - layerCameraSettings.TopDestination;
 layer.LayerCameraSettings = layerCameraSettings;
 // Now the Layer will draw in 2D.  Let's make a Sprite:
 Sprite sprite = SpriteManager.AddSprite("redball.bmp");
 sprite.ScaleX = 400;
 sprite.ScaleY = 400;
 SpriteManager.AddToLayer(sprite, layer);
```

![LayerCameraSettingsDestinationValues.png](../../../../../media/migrated\_media-LayerCameraSettingsDestinationValues.png)

### Exceptions related to display size

If you are explicitly setting the destination rectangle of a LayerCameraSettings object, then you may encounter an exception. If FlatRedBall detects that the BottomDestination is too large, you may get an error as follows:

```
The pixel height resolution of the display is 590 but the LayerCameraSetting's BottomDestination is 600
```

Similarly you may get a message about the width, which might read:

```
The pixel width resolution of the display is 790 but the LayerCameraSetting's RightDestination is 800
```

You can fix this in one of the following ways:

* Prevent resizing of your game window
* Adjust the LayerCameraSettings for your Layer to fit within the bounds of the display
* Set the LayerCameraSettings' destination values to -1, which will result it in automatically adjusting to its contained Camera destination.
