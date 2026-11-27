# InfiniteScrollX

### Introduction

InfiniteScrollX and InfiniteScrollY make a layer repeat forever as the camera moves. Use them for backgrounds like clouds, water, or stars in a side scroller. The layer always fills the camera view, no matter how far the camera scrolls or how small the layer is compared to the screen.

InfiniteScrollX repeats the layer left and right. InfiniteScrollY repeats it up and down. You can turn on both.

### Setting InfiniteScroll in Tiled

To make a layer repeat:

1. Open your map in Tiled
2. Select the layer
3. Add a custom property of type **bool** named `InfiniteScrollX` (or `InfiniteScrollY`)
4. Check the property's box so its value is true
5. Save the map

The layer repeats when the game runs.

### Setting InfiniteScroll in Code

You can also turn it on in code. The layer must already have its tiles, so set it after the map loads or after you add tiles in code.

```csharp
void CustomInitialize()
{
    var cloudLayer = Map.MapLayers.FindByName("Clouds");
    cloudLayer.InfiniteScrollX = true;
}
```

Setting InfiniteScrollX on a layer with no tiles throws an exception. Turning it back off is not supported, and setting it to false after it is true also throws an exception.

### How Wide One Repeat Is

The layer repeats based on its painted tiles, from the left edge of the leftmost tile to the right edge of the rightmost tile. Tiles that are not painted do not create vertices, so empty columns at the left or right edge of a layer are not part of the repeat. If you want a gap between repeats, paint tiles that reach the edges of the space you want, such as fully transparent tiles.

### Scrolling a Repeating Layer

InfiniteScrollX works with [ParallaxX](parallaxx.md), so a repeating layer can move slower than the camera. To make a layer move on its own, such as drifting clouds, change its [OffsetX](offsetx.md) every frame.
