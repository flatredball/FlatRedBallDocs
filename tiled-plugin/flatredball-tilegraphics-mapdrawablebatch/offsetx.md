# OffsetX

### Introduction

OffsetX and OffsetY move a layer away from its normal position. Use them to shift a layer, or change them every frame to make a layer scroll on its own.

### Offset in Tiled

Tiled layers have Offset X and Offset Y properties. These are loaded into OffsetX and OffsetY when the map loads. Tiled's Y axis points down and FlatRedBall's points up, so the Y value is flipped. A Tiled Offset Y of 16 becomes an OffsetY of -16.

### Why Not RelativeX?

Each layer is a PositionedObject attached to its LayeredTileMap, so you might expect to move it with RelativeX and RelativeY. That does not work. Every time the layer draws, it sets its own RelativeX and RelativeY from the camera position and its [ParallaxX](parallaxx.md) value, then adds OffsetX and OffsetY. Anything you assign to RelativeX or RelativeY is replaced before the layer draws.

Use OffsetX and OffsetY to move a single layer. To move the whole map, move the LayeredTileMap itself.

### Code Example - Scrolling a Layer

The following code makes a layer drift to the left at 30 pixels per second. It assumes the map has a layer named Clouds.

```csharp
MapDrawableBatch cloudLayer;

void CustomInitialize()
{
    cloudLayer = Map.MapLayers.FindByName("Clouds");
}

void CustomActivity(bool firstTimeCalled)
{
    cloudLayer.OffsetX -= 30 * TimeManager.SecondDifference;
}
```

On its own, the layer scrolls off the screen. Turn on [InfiniteScrollX](infinitescrollx.md) on the layer so it keeps filling the view while it scrolls.
