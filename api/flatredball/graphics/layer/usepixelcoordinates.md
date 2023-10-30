# usepixelcoordinates

### Introduction

The UsePixelCoordinates can be used to easily create a 2D Layer. This method is often used in combination with attaching Entities to a Camera so that they can be placed in screen space. This method is used by [Glue](../../../../../frb/docs/index.php) if a given Layer's "Is 2D" property is set true.

### Code Example

The following example shows a situation where a Camera which is 3D (default) draws a 2D layer which contains some text. Add the following using statement:

```
using FlatRedBall.Graphics;
```

Add the following to Initialize after initializing FlatRedBall:

```
Layer layer = SpriteManager.AddLayer();
layer.UsePixelCoordinates();

Text text = TextManager.AddText("Hello I am text that sits on the top-left of the screen");
TextManager.AddToLayer(text, layer);

text.HorizontalAlignment = HorizontalAlignment.Left;
text.VerticalAlignment = VerticalAlignment.Top;
text.X = -SpriteManager.Camera.DestinationRectangle.Width / 2.0f;
text.Y = SpriteManager.Camera.DestinationRectangle.Height / 2.0f;
text.SetPixelPerfectScale(layer);
```

![Layer2D.png](../../../../../media/migrated_media-Layer2D.png)

### A note about attachments

The code above creates two different coordinate systems; however, if the Camera is moved, then the Text that is on the 2D layer will also be affected. Usually when creating 2D HUD and UI elements, they should also be attached to the Camera. If an object is attached to the Camera, it will always stay in the same place on-screen even if the Camera moves or rotates. Therefore, the positioning code could be modified as follows:

```
// After the Text is created and added to the Layer:
text.AttachTo(SpriteManager.Camera, false);

text.HorizontalAlignment = HorizontalAlignment.Left;
text.VerticalAlignment = VerticalAlignment.Top;
// Change the X and Y settings to relative
text.RelativeX = -SpriteManager.Camera.DestinationRectangle.Width / 2.0f;
text.RelativeY = SpriteManager.Camera.DestinationRectangle.Height / 2.0f;
// We want to make sure the Text is not at the same Z as the Camera.
text.RelativeZ = -40;
```
