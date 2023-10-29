# z

### Introduction

The Z property controls the absolute Z position of an object. On 3D cameras (Orthogonal=false) , the smaller the Z is, the further away from the camera an object will appear. For information on setting Z in the FlatRedBall Editor, see [this page](../../../documentation/tools/glue-reference/objects/glue-reference-z.md).

### Code Example

The following code assumes an empty Screen, and the code is written in CustomInitialize.

```
// First we'll make a wide sprite:
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
sprite.Width = 100;
sprite.Height = 20;
// And it will have a Z value of 0 (which is the default)
sprite.Z = 0;

// Now let's make another Sprite in front of the first Sprite:
Sprite spriteInFront = SpriteManager.AddSprite("redball.bmp");
spriteInFront.Width = 20;
spriteInFront.Height = 100;
// and it will ahve a Z value of 1, which will put it in front:
spriteInFront.Z = 1;
```

![SpriteZ.PNG](../../../media/migrated\_media-SpriteZ.PNG)

### Z in 2D

The Z value controls the distance of an object from the Camera. When using a 2D Camera (Orthogonal=true), changing the Z will not make objects get bigger or smaller as they move closer to/away from the Camera. Despite that, the Z value still impacts a few things:

* Objects with a Z value smaller than the Camera's near clip plane (by default 39) will not be drawn
* Objects with a Z value larger than the Camera's far clip plane (by default -960) will not be drawn
* Objects will sort with each other according to their Z values (excluding shapes like Circle and AxisAlignedRectangle)

### Default values

* SpriteManager.Camera.Z = 40
* New PositionedObject.Z = 0

### Z and Sorting

For information on how Z affects the sorting of objects, check the following articles:

* [Sprite sorting and overlapping](../../../frb/docs/index.php#Setting\_Z\_Value)
