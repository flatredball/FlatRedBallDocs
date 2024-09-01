# NamedTileOrderedIndexes

### Introduction

The NameTileOrderedIndexes property can be used to find tiles by a given name. It is a Dictionary\<string, List\<int>> , where the key is a name, and the value is the index of tiles which have the given name.

### Tile Ordered Indexes

The MapDrawableBatch object stores a list of vertices (points) which are used to define the coordinates for each tile. These points are used by the rendering code in the MapDrawableBatch class to perform efficient rendering. Each tile is composed of a list of vertices, as opposed to a Sprite (as might be the case if the MapDrawableBatch were a FlatRedBall-drawn object). Therefore, to access and modify properties on a tile, its index must be known. The following image shows the indexes of a simple tile map:

![](../../media/2017-01-img\_587f9aa4ce403.png)

### Code Example

The following code example shows how to create an Entity for every tile with the name "CreateEntity".

```csharp
// The following assumes that LayeredTileMapInstance is a valid LayeredTileMap:
foreach(var layer in LayeredTileMapInstance.Layers)
{
    // See if this layer has any tiles with the name "CreateEntity"
    if(layer.NamedTileOrderedIndexes.ContainsKey("CreateEntity"))
    {
        List<int> indexes = layer.NamedTileOrderedIndexes["CreateEntity"];

        // Loop through all of the tile indexes
        foreach(int index in indexes)
        {
            float left;
            float bottom;
            layer.GetBottomLeftWorldCoordinateForOrderedTile(index, out left, out bottom);

            // This gives us the left and bottom of the tile, but we want to add half the width
            // and height to get the center of the tile.  For this we'll assume the width and height
            // of the tiles is 16 pixels, but you will want to adjust this to account for your actual width/height
            const float tileWidthAndHeight = 16;            
            float centerX = left + tileWidthAndHeight/2.0f;
            float centerY = bottom + tileWidthAndHeight/2.0f;

            // Assume that we have an Entity called Coin:
            Coin coin = new Coin();
            coin.X = centerX;
            coin.Y = centerY;
            // And assume that CoinList is a valid list of Coins
            CoinList.Add(coin);
        }
    }
}
```

### Setting the Name in Tiled

Tiles will only have properties at runtime if it uses a tile in a tileset with a Name property.

![](../../media/2016-06-img\_574f970571521.png)

### Tile Names and Automatic Naming

Tiles in a Tiled map have names at runtime if any of the following conditions apply:

* If the name has been given explicitly to the tile
* If the Tile has any other custom properties (will be automatically named)
* If the Tile has a Class

For example, a typical FlatRedBall project includes a tileset named StandardTileset.tsx with tiles for common TileShapeCollision creation such as SolidCollision.

<figure><img src="../../.gitbook/assets/image (3) (1) (1).png" alt=""><figcaption><p>SolidCollision tile in Tiled</p></figcaption></figure>

The SolidCollision tile does not have a Name property, so it is assigned an automatic name at runtime as shown in the following screenshot of Visual Studio showing the names of the tiles in a typical map:

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>NamedTileOrderedIndexes</p></figcaption></figure>

Notice that in this case the names are TiledIcons0\_autoname and TiledIcons43\_autoname. The names correspond to the IDs in the Tileset.
