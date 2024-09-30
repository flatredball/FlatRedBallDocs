# TileNodeNetwork

### Introduction

The TileNodeNetwork object is a type of [NodeNetwork](../flatredball-ai-pathfinding-nodenetwork/) which is designed specifically for tile-based games. Since the TileNodeNetwork object inherits from [NodeNetwork](../flatredball-ai-pathfinding-nodenetwork/), all available methods in [NodeNetwork](../flatredball-ai-pathfinding-nodenetwork/) are available in TileNodeNetwork. Therefore, you should check out the [NodeNetwork page](../flatredball-ai-pathfinding-nodenetwork/) for additional information and features on the TileNodeNetwork object. Normally a TileNodeNetwork is used when creating a game which uses tile maps.&#x20;

For information on creating a TileNodeNetwork in the FlatRedBall Editor (this isthe most common approach), see the FlatRedBall Editor [TileNodeNetwork](../../../../../glue-reference/objects/object-types/tilenodenetwork.md) page.

### Benefits of the TileNodeNetwork

The TileNodeNetwork offers the following benefits:

* Simple addition of tiles on a grid-based system using four or eight-way movement.
* Quick index based ( O(1) ) tile finding
* Concept of tile occupation to prevent multiple characters moving on the same tile.

### Example - Creating a TileNodeNetwork In Code

The following code creates a TileNodeNetwork that is 10X10 with has a seed (bottom left tile) at 0,0. Add the following using statement:

```
using FlatRedBall.AI.Pathfinding;
```

Add the following to Initialize after initializing FlatRedBall:

```
float xSeed = 0;
float ySeed = 0;
float distanceBetweenNodes = 32;
int numberOfNodesX = 10;
int numberofNodesY = 10;

TileNodeNetwork tileNodeNetwork = new TileNodeNetwork(
    xSeed, 
    ySeed, 
    distanceBetweenNodes, 
    numberOfNodesX, 
    numberofNodesY, 
    DirectionalType.Four);

tileNodeNetwork.FillCompletely();

tileNodeNetwork.Visible = true;
```

![TileNodeNetwork.png](../../../../../.gitbook/assets/migrated\_media-TileNodeNetwork.png)

### Example - Creating a TileNodeNetwork from a TileMap in Code

The following code can be used to create a TileNodeNetwork using a loaded TMX file:

```lang:c#
// Assuming WorldMap is a valid Tiled map

var tileNodeNetwork = new TileNodeNetwork(GridWidth / 2f,
    -WorldMap.Height + GridWidth / 2f,
    GridWidth,
    MathFunctions.RoundToInt(WorldMap.Width / WorldMap.WidthPerTile.Value),
    MathFunctions.RoundToInt(WorldMap.Height / WorldMap.HeightPerTile.Value)
    DirectionalType.Eight);

const string nameToLookFor = "PathTile";

foreach(var layer in WorldMap.MapLayers)
{
    var indexes = layer.NamedTileOrderedIndexes.ContainsKey(nameToLookFor) ? 
        layer.NamedTileOrderedIndexes[nameToLookFor] : null;

    if (indexes != null)
    {
        var count = indexes.Count;
        for (int i = count - 1; i > -1; i--)
        {
            float tileLeftX, tileBottomY;
            layer.GetBottomLeftWorldCoordinateForOrderedTile(indexes[i], out tileLeftX, out tileBottomY);
        
            // If we use the bottom-left position for adding a node network, floating point error may cause
            // the node to be positioned in one of four tiles that touch the corner. Shift the position up and
            // to the right to avoid this by GridWidth/2
            tileNodeNetwork.AddAndLinkTiledNodeWorld(tileLeftX + GridWidth/2.0f, tileBottomY + GridWidth/2.0f);
        }
    }
}
```

Note that the example above uses a name (PathTile) for simplicity, but you can also use properties. You simply have to convert the properties to a list of names:

```lang:c#
...
var tileNamesForPath = WorldMap.TileProperties
                .Where(item => item.Value
                .Any(customProperty => customProperty.Name == "IsPath" && (string)customProperty.Value == "true"))
                .Select(item => item.Key)
                .ToArray();



foreach(var layer in WorldMap.MapLayers)
{
    foreach(var nameToLookFor in tileNamesForPath)
    {
        var indexes = layer.NamedTileOrderedIndexes.ContainsKey(nameToLookFor) ? 
            layer.NamedTileOrderedIndexes[nameToLookFor] : null;

        if (indexes != null)
        {
            ...
        }
    }
}
```
