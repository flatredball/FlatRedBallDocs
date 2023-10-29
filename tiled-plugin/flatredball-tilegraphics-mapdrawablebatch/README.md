# flatredball-tilegraphics-mapdrawablebatch

### Introduction

The MapDrawableBatch class represents a single layer in a .tmx file. It implements the [IDrawableBatch](../../frb/docs/index.php) class to perform custom rendering. It internally creates a single vertex buffer which is drawn all at once with no render state changes for maximum performance. Usually .tmx files are loaded into a [LayeredTileMap](../../documentation/tools/tiled-plugin/flatredball-tilegraphics-layeredtilemap.md), which contains one or more MapDrawableBatch instances.

### Only painted tiles create vertices

When the MapDrawableBatch is created it will only create vertices for tiles which exist. Therefore tiles which are not painted or which have been erased in Tiled will not create vertices.

### MapDrawableBatch Color Values

MapDrawableBatch supports a Modulate color operation through its Red, Green, and Blue values. By default these values are all set to 1.0f, but they can be modified at runtime to tint or darken the map.

### Creating a MapDrawableBatch in Code

MapDrawableBatch instances are typically created by adding a TMX file to your project. By default FlatRedBall top down and platformer projects contain TMX files for each level. MapDrawableBatch instances can also be created in code. The following code shows how to create a new MapDrawableBatch which is filled with a pattern from a texture called FRBeefcakeSpritesheet The following code assumes that an existing Map exists (although this is not necessary), that the code has access to a Texture called FRBeefcakeSpritesheet, and that this code exists in the CustomInitialize of a Screen such as Level1.

```
MapDrawableBatch CustomLayer;

void CustomInitialize()
{
    var numberOfTilesWide = 32;
    var numberOfTilesHigh = 32;
    var totalTiles = numberOfTilesWide * numberOfTilesHigh;
    CustomLayer = new MapDrawableBatch(totalTiles, 16, 16, FRBeefcakeSpritesheet);

    // Adding the CustomLayer to managers enables its rendering...
    CustomLayer.AddToManagers();

    // Strictly speaking, it is not necessary to add CustomLayer to the Map's MapLayers.
    // It is recommended so that any MapDrawableBatch added in code can be accessed through
    // the Map, just like layers created through TMX. In other words, it keeps things the same
    // and avoids gotchas.
    Map.MapLayers.Add(CustomLayer);

    // Attaching the CustomLayer to the Map enables moving the entire map as a single unit:
    CustomLayer.AttachTo(Map);
    CustomLayer.RelativeZ = 1;

    CustomLayer.SortAxis = SortAxis.X;
    // add tiles for the entire map:
    for (int x = 0; x < numberOfTilesWide; x++)
    {
        for(int y = 0; y < numberOfTilesHigh; y++)
        {

            CustomLayer.AddTile(new Vector3(x * 16, (-y-1) * 16, 0), new Vector2(16, 16),
                textureTopLeftX: 16,
                textureTopLeftY: 176,
                textureBottomRightX: 32,
                textureBottomRightY: 192);
        }
    }
}
```

![](../../media/2023-01-img\_63b97849def36.png)

#### Creation Considerations

The code above includes some subtle considerations:

1. The CustomLayer MapDrawableBatch uses X axis sorting. Therefore, all tiles must be added in order of X, largest to small. Breaking this order will result in incorrect rendering and other unpredictable behavior.
2. The entire tile set is filled. This enables painting later without having to add tiles. If tiles are added on paint, this can make sorting far more difficult.
