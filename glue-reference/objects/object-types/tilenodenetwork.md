# TileNodeNetwork

### Introduction

The TileNodeNetwork object type is used to define the walkable areas in a level. Once a TileNodeNetwork is created it can be used for pathfinding for AI-controlled entities such as Enemies.&#x20;

### Example - Creating a TileNodeNetwork in FlatRedBall Editor

The FlatRedBall Editor supports the creation and population of TileNodeNetworks. Typically TileNodeNetworks are filled using tile maps. This section covers common ways to fill a TileNodeNetwork. We recommend using the GameScreen and Level approach, as this makes it easier to maintain games with multiple levels. Using this pattern, a TileNodeNetwork would be defined in the GameScreen:

1. Select the **GameScreen**
2.  Click **Add Object to GameScreen** in the **Quick Actions** tab

    ![Add Object to GameScreen button under GameScreen](<../../../.gitbook/assets/28\_06 00 25.png>)
3. Select **TileNodeNetwork** as the type
4. Enter a name for your TileNodeNetwork such as **WalkingNodeNetwork**
5.  Click **OK**

    ![Create a TileNodeNetwork named WalkingNodeNetwork](<../../../.gitbook/assets/28\_06 01 53.png>)

Be sure to create the TileNodeNetwork in the **GameScreen** so it is included in all levels.&#x20;

TileNodeNetworks (just like normal NodeNetworks) must have nodes and links to be used for pathfinding. Each node represents a point on the map where an entity can walk. These nodes are connected by links which indicate how an entity can walk.

We can create nodes and links for each level from the tiles in our Tiled map. We have two options for doing this:

1. By indicating that all empty tiles in a map should contain nodes
2. By using a dedicated tile for marking where entities can walk

The first option is easier because it works for many simple maps without any modifications. The second option provides more flexibility.

For simplicity we'll use the first approach (empty tiles):

1. Select the new TileNodeNetwork
2. Click on the **TileNodeNetwork Properties** tab
3. Click the **From Layer** option under the **Creation Options** category
4. Select your map and the layer. Typically this is **Map** and **GameplayPlay** layer.
5.  Verify the **All Empty** option is selected

    ![Setting TileNodeNetwork's tiles to fill from "all empty" tiles on the GameplayLayer](<../../../.gitbook/assets/28\_06 42 02.png>)

Optionally you may want to make the TileNodeNetwork visible so you can verify that it has been filled in:

1. Select the TileNodeNetwork
2. Click the **Variables** tab
3.  Check the **Visible** checkbox

    ![Making the TileNodeNetwork visible in the Variables tab](<../../../.gitbook/assets/28\_06 44 00.png>)

The game should display the node network wherever no tiles are present.

![](../../../.gitbook/assets/2021-08-img\_61279322b6383.png)

#### Filling TileNodeNetwork from Specific Types

Some games include specific tiles for pathfinding rather than all empty tiles. The first step is to determine which tile to use as walkable tiles. Whichever tile is used should have its **Class** (or **Type** if using older versions of Tiled) specified in the tileset in Tiled.

![](<../../../.gitbook/assets/28\_06 45 47.png>)

Once this tile Type is set (and the .tsx is saved), this tile can be used to mark walkable areas in the map.

![](../../../.gitbook/assets/2021-08-img\_6127946f19390.png)

To use these tiles:

1. Select the TileNodeNetwork
2. Click the **TileNodeNetwork Properties** tab
3. Check the From Type property
4. Select the **Source TMX File** (usually **Map**)
5. Select the type for the tile you just saved. It should appear in the drop-down if the .tsx file has been saved.

The TileNodeNetwork will now place a node wherever the walkable tiles are present.

![](../../../.gitbook/assets/2021-08-img\_6127951030eb7.png)
