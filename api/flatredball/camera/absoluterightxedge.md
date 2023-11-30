# AbsoluteRightXEdge

### Introduction

The "absolute edge" properties returns the absolute (also known as world coordinate) value of the edge of the camera's viewable area. It is one of four properties:

* AbsoluteRightXEdge
* AbsoluteLeftXEdge
* AbsoluteTopYEdge
* AbsoluteBottomYEdge

This property is similar to calling the "At" methods, such as [AbsoluteRightXEdgeAt](absoluterightxedgeat.md), but it assumes a Z value of 0. These properties can be more convenient than the "At" methods, especially for games which have the Camera's [Orthogonal](orthogonal.md) property set to true - which is the default.

### Setting Absolute Edge Values

If the Camera's Orthogonal property is set to true, then the "absolute edge" values can be set.&#x20;

For example, to move the camera so that the coordinates (0,0) appear at the bottom left of the screen, the following code can be used:

```
Camera.Main.AbsoluteLeftXEdge = 0;
Camera.Main.AbsoluteBottomYEdge = 0;
```

