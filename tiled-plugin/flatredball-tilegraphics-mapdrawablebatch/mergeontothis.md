# mergeontothis

### Introduction

MergeOntoThis can be used to merge tiles from one or more _source_ layers into a _destination_ layer. Merging can be used for a number of reasons:

1. To simplify management of layers
2. To improve performance

### Example - Merging Two Layers Into One

This example uses a tmx file which includes a layer named Layer2 which contains ice blocks.

![](../../../../media/2023-05-img_64779b03a728e.png)

The other tiles (the red number 1 and the orange brick surrounding blocks) are part of the GameplayLayer - the standard layout for Level1 if using the wizard. The following code shows how to merge the layers:

```
void CustomInitialize()
{
    var gameplayLayer = Map.MapLayers.FindByName("GameplayLayer");
    var quadCountBefore = gameplayLayer.QuadCount;
    var layerCountBefore = Map.MapLayers.Count;

    var layer2 = Map.MapLayers.FindByName("Layer2");

    gameplayLayer.MergeOntoThis(new List { layer2 });

    layer2.Destroy();
    var quadCountAfter = gameplayLayer.QuadCount;
    var layerCountAfter = Map.MapLayers.Count;
}
```

&#x20; The code above includes diagnostic variables to count quads and layers. These values can help verify that the layers have been merged at runtime as shown in the following screenshot:

![](../../../../media/2023-05-img_64779ba23dd1a.png)

Even though layer2 has been destroyed, the ice blocks still draw as shown in the following screenshot:

![](../../../../media/2023-05-img_64779bbcd4399.png)

### Merging and Partitioning

Note that LayeredTileMaps partition their tiles based on the X or Y axis, so merging is not simply an addition of quads at the end of the layer. Rather, merging inserts the quads to preserve the axis sorting so that efficient partitioning during drawing can be performed.
