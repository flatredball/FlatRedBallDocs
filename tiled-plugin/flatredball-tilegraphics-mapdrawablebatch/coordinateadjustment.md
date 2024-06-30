# CoordinateAdjustment

### Introduction

The CoordinateAdjustment variable is used to adjust the texture coordinate of tiles inward to prevent adjacent pixels from bleeding in to tiles. This value needs to be balanced between being too small (resulting in values bleeding in to tiles) and too large (resulting in pixels being excluded from tiles). This value is in texture coordinates as opposed to pixels, so ideally it should be adjusted according to the size texture size used on the tile map.

By default this value is a very small positive value. At the time of this writing (June 2024), this value defaults to `.00002f`.

### Visual Example

If CoordinateAdjustment is set to 0, then the texture coordinates are assigned according to the edges of the tiles. For example, a texture coordinate of 0 would use the area represented by the yellow are in the image below:

![](../../media/2019-11-img\_5dd88d86d1723.png)

Increasing the CoordinateAdjustment value results in the yellow area shrinking.

![](../../media/2019-11-img\_5dd88e0f3db47.png)

### Code Example

CoordinateAdjustment is a static property no the MapDrawableBatch so it can be assigned prior to loading a TMX. Glue projects typically load TMX files when a Screen is first created, so the CoordinateAdjustment value must be assigned prior to loading the screen to take effect.

```lang:c#
// Before loading the screen, like in Game1.cs's Initialize
MapDrawableBatch.CoordinateAdjustment = .001f;
```
