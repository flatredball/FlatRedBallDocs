# AbsoluteRightXEdge

### Introduction

The "absolute edge" properties returns the absolute (also known as world coordinate) value of the edge of the camera's viewable area. It is one of four properties:

* AbsoluteRightXEdge
* AbsoluteLeftXEdge
* AbsoluteTopYEdge
* AbsoluteBottomYEdge

This property is similar to calling the "At" methods, such as [AbsoluteRightXEdgeAt](absoluterightxedgeat.md), but it assumes a Z value of 0. These properties can be more convenient than the "At" methods, especially for games which have the Camera's [Orthogonal](orthogonal.md) property set to true - which is the default.

The "absolute edge" values can be used to prevent the camera from viewing outside of the Camera bounds. Note that typical games use the CameraControllingEntity for camera positioning, so setting absolute edge values only applies if the camera is not controlled by a CameraControllingEntity instance.

### Setting Absolute Edge Values

If the Camera's Orthogonal property is set to true, then the "absolute edge" values can be set.&#x20;

For example, to move the camera so that the coordinates (0,0) appear at the bottom left of the screen, the following code can be used:

```csharp
Camera.Main.AbsoluteLeftXEdge = 0;
Camera.Main.AbsoluteBottomYEdge = 0;
```

### Setting Viewable Bounds

&#x20;The following code can be used to prevent the Camera from viewing outside of viewable bounds:

```csharp
//this assumes that the bound values are valid:
Camera.Main.AbsoluteLeftXEdge = Math.Max(Camera.Main.AbsoluteLeftXEdge, leftBound);
Camera.Main.AbsoluteRightXEdge = Math.Min(Camera.Main.AbsoluteRightXEdge, rightBound);
Camera.Main.AbsoluteBottomYEdge = Camera.Max(Camera.Main.AbsoluteBottomYEdge, bottomBound);
Camera.Main.AbsoluteTopYEdge = Camera.Min(Camera.Main.AbsoluteTopYEdge, topBound);
```
