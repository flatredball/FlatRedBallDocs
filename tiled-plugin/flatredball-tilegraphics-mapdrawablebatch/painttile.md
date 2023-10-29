## Introduction

The PaintTile can be used to change the texture coordinate on an existing tile in the MapDrawableBatch according to its index. This method can be used if your game requires dynamically the graphics of a tile after it is created (either from a .TMX file or manually). PaintTile has the following overrides:

    void PaintTile(int orderedTileIndex, int newTextureId)

Paints the tile given the ordered tile index given the texture id. The orderedTileIndex value is the index of the tile on the tilemap. Usually, an index of 0 is the top-left tile on the map. The subsequent tiles are ordered counting left-to-right if the map is taller than it is wide. The following image shows example orderedTileIndex values for a amp which is ordered left-to-right.

![](/media/2023-01-img_63b9077c3c079.png)

The subsequent tiles are ordered top-to-bottom if the map is wider than it is tall. The following image shows example orderedTileIndex values for a map which is ordered top-to-bottom.

![](/media/2020-10-img_5f918eb8a684a.png)

The newTileId is the index of the texture of the tileset. This index uses a similar indexing pattern but it always begins at the top-left and is ordered left-to-right. The following image shows example newTileId values in a tileset.

![](/media/2020-10-img_5f91902e76fb2.png)

## Code Example - Painting Tiles

This example assumes the following:

1.  You have a LayeredTileMap in your game called Map
2.  You have a Layer added to the LayeredTileMap called LayerForPainting. This could be created through code, but the easiest way to do this is to add this layer in Tiled. For information on how to create a layer through code, see the [MapDrawableBatch page](/documentation/tools/tiled-plugin/flatredball-tilegraphics-mapdrawablebatch.md).
3.  This layer references a tileset that you intend to paint with. This can be done by painting tiles on the layer in Tiled which will result in the layer being associated with the tileset containing the painted tiles
4.  The layer is already filled with tiles. This enables the painting to adjust texture coordinates without adding new tiles.

![](/media/2023-01-img_63b90d11ccda1.png)

In this example, this map is the modified Level1Map.tmx which is created automatically in a platformer game. To paint on this tile, add the following code:

    void CustomActivity(bool firstTimeCalled)
    {
        var cursor = GuiManager.Cursor;

        if(cursor.PrimaryDown)
        {
            var position = cursor.WorldPosition;

            var layer = Map.MapLayers.FindByName("LayerForPainting");

            var index = layer.GetQuadIndex(position.X, position.Y);

            if(index != null)
            {
                layer.PaintTile(index.Value, 481);
            }
        }
    }
