# LayerCameraSettings

### Introduction

The LayerCameraSettings class is a class which can be used to override the settings of a [FlatRedBall.Camera](../../../../frb/docs/index.php) on a by [FlatRedBall.Graphics.Layer](../../../../frb/docs/index.php) basis. LayerCameraSettings can be used to achieve the following:

* Adding a 2D layer when the main Camera is 3D
* Adding a 3D layer when the main Camera is 2D
* Adjusting the field of view on a 3D layer when the Camera is 3D
* Adjusting the orthogonal width and height values on a 2D layer when the Camera is 2D

### Code Example

The following code creates a [FlatRedBall.Graphics.Layer](../../../../frb/docs/index.php) which renders in 2D even though the camera is rendering in 3D: Add the following using statement:

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
layerCameraSettings.OrthogonalWidth = 800;
layerCameraSettings.OrthogonalHeight = 600;
layer.LayerCameraSettings = layerCameraSettings;
// Now the Layer will draw in 2D.  Let's make a Sprite:
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
// Set TextureScale to 1 to "make it 2D"
sprite.PixelSize = 1;
SpriteManager.AddToLayer(sprite, layer);
```

![2DLayerCameraSettings.png](../../../../.gitbook/assets/migrated\_media-2DLayerCameraSettings.png)

### LayerCameraSettings and Glue Layers

If a Layer is added through Glue, the generated code for the layer will instantiate a new LayerCameraSettings and add it to the Layer. By default these settings will match the camera at the time of Layer creation.
