## Introduction

The TileNodeNetwork object is a type of [NodeNetwork](/documentation/api/flatredball/flatredball-ai/flatredball-ai-pathfinding-2/flatredball-ai-pathfinding-nodenetwork/.md "FlatRedBall.AI.Pathfinding.NodeNetwork") which is designed specifically for tile-based games. Since the TileNodeNetwork object inherits from [NodeNetwork](/documentation/api/flatredball/flatredball-ai/flatredball-ai-pathfinding-2/flatredball-ai-pathfinding-nodenetwork/.md "FlatRedBall.AI.Pathfinding.NodeNetwork"), all available methods in [NodeNetwork](/documentation/api/flatredball/flatredball-ai/flatredball-ai-pathfinding-2/flatredball-ai-pathfinding-nodenetwork/.md "FlatRedBall.AI.Pathfinding.NodeNetwork") are available in TileNodeNetwork. Therefore, you should check out the [NodeNetwork page](/documentation/api/flatredball/flatredball-ai/flatredball-ai-pathfinding-2/flatredball-ai-pathfinding-nodenetwork/.md "FlatRedBall.AI.Pathfinding.NodeNetwork") for additional information and features on the TileNodeNetwork object. Normally a TileNodeNetwork is used when creating a game which uses tile maps. As shown below, TileNodeNetworks can be filled from tiles in a tile map with no code, but they can also be edited and accessed in code for additional game logic.

## Benefits of the TileNodeNetwork

The TileNodeNetwork offers the following benefits:

-   Simple addition of tiles on a grid-based system using four or eight-way movement.
-   Quick index based ( O(1) ) tile finding
-   Concept of tile occupation to prevent multiple characters moving on the same tile.

## Example - Creating a TileNodeNetwork in FlatRedBall Editor

The FlatRedBall Editor supports the creation and population of TileNodeNetworks. Typically TileNodeNetworks are filled using tile maps. This section covers common ways to fill a TileNodeNetwork. We recommend using the GameScreen and Level approach, as this makes it easier to maintain games with multiple levels. Using this pattern, a TileNodeNetwork would be defined in the GameScreen:

1.  Select the **GameScreen**

2.  Click **Add Object to GameScreen** in the **Quick Actions** tab

    ![](/media/2021-08-img_61278ef517345.png)

3.  Select **TileNodeNetwork** as the type

4.  Enter a name for your TileNodeNetwork such as **WalkingNodeNetwork**

5.  Click ****OK****

    ![](/media/2021-08-img_61278f797745d.png)

Be sure to create the TileNodeNetwork in the **GameScreen** so it is included in all levels. Once you have created a TileNodeNetwork, it can be filled from certain tiles. It can also be convenient to fill a TileNodeNetwork from the absence of tiles if the tiles represent solid areas such as walls. To create nodes where there are no tiles:

1.  Select the new TileNodeNetwork

2.  Click on the **TileNodeNetwork Properties** tab

3.  Click the **From Layer** option under the **Creation Options** category

4.  Select your map and the layer. Typically this will be **Map** and **GameplayPlay** layer.

5.  Verify the **All Empty** option is selected

    ![](/media/2021-08-img_612791599f0de.png)

Optionally you may want to make the TileNodeNetwork visible so you can verify that it has been filled in:

1.  Select the TileNodeNetwork

2.  Click the **Variables** tab

3.  Check the **Visible** checkbox

    ![](/media/2021-08-img_6127925fcfb97.png)

The game should display the node network wherever no tiles are present.

![](/media/2021-08-img_61279322b6383.png)

### Filling TileNodeNetwork from Specific Types

Some games include specific tiles for pathfinding rather than all empty tiles. The first step is to determine which tile to use as walkable tiles. Whichever tile is used should have a type specified in the tileset in Tiled.

![](/media/2021-08-img_612793df73271.png)

Once this tile Type  is set (and the .tsx is saved), this tile can be used to mark walkable areas in the map.

![](/media/2021-08-img_6127946f19390.png)

To use these tiles:

1.  Select the TileNodeNetwork
2.  Click the **TileNodeNetwork Properties** tab
3.  Check the From Type property
4.  Select the **Source TMX File** (usually **Map**)
5.  Select the type for the tile you just saved. It should appear in the drop-down if the .tsx file has been saved.

The TileNodeNetwork will now place a node wherever the walkable tiles are present.

![](/media/2021-08-img_6127951030eb7.png)

## Example - Creating a TileNodeNetwork In Code

The following code creates a TileNodeNetwork that is 10X10  with has a seed (bottom left tile) at 0,0. Add the following using statement:

    using FlatRedBall.AI.Pathfinding;

Add the following to Initialize after initializing FlatRedBall:

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

![TileNodeNetwork.png](/media/migrated_media-TileNodeNetwork.png)

## Example - Creating a TileNodeNetwork from a TileMap in Code

The following code can be used to create a TileNodeNetwork using a loaded TMX file:

``` lang:c#
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

``` lang:c#
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

 
