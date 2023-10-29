# general-programming-graphics-coordinates

### Introduction

When dealing with 3D graphics, most API calls attempt to abstract out the pixel. What that means is that usually no calls directly reference pixels - rather - they use values which represent ratios.

For example, consider [TextureCoordinates](../../../frb/docs/index.php). When referending [TextureCoordinates](../../../frb/docs/index.php) you do not specify pixel values. Instead, the left edge of a texture has a coordinate of 0 and the right edge has a coordinate of 1 regardless of the actual dimensions of the memory buffer which makes up the Texture, or regardless of the source image which was used to create the Texture.

Similarly, screen coordinates by default are independent of pixels. Pixels and screen coordinates \*\*\*can\*\*\* line up \*\*\*if\*\*\* the projection matrices are set up, but a shader which does not have any matrices set or modified will use not consider pixel coordinates.

### Default Coordinate System

The default coordinate system has a visible range of -1 to 1 on the X, Y, and Z axes.

* \-1 on the X axis is the left edge of the screen while +1 is the right edge of the screen
* \-1 on the Y axis is the bottom edge of the screen while +1 is the top edge of the screen
* \-1 on the Z axis is the near clip plane while +1 is is the far clip plane

Graphically (at least considering X and Y) we can represent this as follows:

```
(-1,1)-----------(1, 1)
|                     |
|          (0,0)      |
|          +          |
|                     |
|                     |
(-1,-1)----------(1, -1)
```

Therefore, if you are drawing graphics by yourself (instead of using FlatRedBall's rendering), then this is the coordinate system you will be using if your vertex shader does not apply any transformations through matrices.
