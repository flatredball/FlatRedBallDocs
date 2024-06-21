# PaintTile

### Introduction

The PaintTile method can be used to change the texture coordinate on an existing tile in the MapDrawableBatch according to its index. This method can be used if your game requires dynamically the graphics of a tile after it is created (either from a .TMX file or manually).&#x20;

PaintTile has the following overrides:

```csharp
void PaintTile(int orderedTileIndex, int newTextureId)
```

PaintTile takes the orderedTileIndex and the texture ID.

The orderedTileIndex location depends LayeredTileMap's SortAxis. Interally the MapDrawableBatch may render tiles in different order for performance or visual reasons.

For example, the following shows the tile order index if the map is using SortAxis of Y:

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1).png" alt=""><figcaption><p>Tile index order for SortAxis.Y</p></figcaption></figure>

Note that for isometic maps, tiles are drawn top to bottom (increasing moving downward) so isometric maps use a SortAxis of YTopDown.

If your map is wider than it is tall and is not isometric, then the ordering is performed left-to-right rather than top-to-bottom. The following image shows example orderedTileIndex values for a map which is ordered left-to-right.

![](../../media/2020-10-img\_5f918eb8a684a.png)

The newTileId is the index of the texture of the tileset. This index uses a similar indexing pattern but it always begins at the top-left with a value of 0 and is ordered left-to-right. The following image shows example newTileId values in a tileset.

![](../../media/2020-10-img\_5f91902e76fb2.png)

### Code Example - Painting Tiles

This example assumes the following:

1. You have a LayeredTileMap in your game called Map
2. You have a Layer added to the LayeredTileMap called LayerForPainting. This could be created through code, but the easiest way to do this is to add this layer in Tiled. For information on how to create a layer through code, see the [MapDrawableBatch page](../../documentation/tools/tiled-plugin/flatredball-tilegraphics-mapdrawablebatch.md).
3. This layer references a tileset that you intend to paint with. This can be done by painting tiles on the layer in Tiled which will result in the layer being associated with the tileset containing the painted tiles
4. The layer is already filled with tiles. This enables the painting to adjust texture coordinates without adding new tiles.

![](../../media/2023-01-img\_63b90d11ccda1.png)

In this example, this map is the modified Level1Map.tmx which is created automatically in a platformer game. To paint on this tile, add the following code:

```csharp
void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;

    if(cursor.PrimaryDown)
    {
        var worldPosition = cursor.WorldPosition;
        
        var layer = Map.MapLayers.FindByName("LayerForPainting");

        // Usually TileMaps are positioned at 0,0, but in case they aren't
        // we need to offset the position
        var positionRelativeToMap = worldPosition - layer.Position;

        var index = layer.GetQuadIndex(
            positionRelativeToMap.X, 
            positionRelativeToMap.Y);

        if(index != null)
        {
            var tileId = 481; // change this to your tile ID
            layer.PaintTile(index.Value, tileId);
        }
    }
}
```

### Multiple Tilesets

FlatRedBall does not support multiple tilesets per layer (MapDrawableBatch). In other words, each MapDrawableBatch can only paint tiles using its current layer. Therefore, the value of 0 (the top-left most tile in the tileset) depends on the layer's current TileSet. Games which require multiple tilesets should create multiple layers.&#x20;
