# flatredball-tilegraphics-layeredtilemap

### Introduction

The LayeredTileMap object is the runtime type for the TMX file format (the native file format for Tiled). Whenever a TMX file is added to FlatRedBall, it will (by default) be loaded into a LayeredTileMap at runtime. The LayeredTileMap represents a collection of [MapDrawableBatches](../../../../frb/docs/index.php). It contains one [MapDrawableBatch](../../../../frb/docs/index.php) per layer in the source TMX file. The LayeredTileMap class inherits from [FlatRedBall.PositionedObject](../../../../frb/docs/index.php) so it can be moved and attached to other [PositionedObjects](../../../../frb/docs/index.php). Each MapDrawableBatch is attached to its parent LayeredTileMap, and can be moved independently by changing its [RelativePosition](../../../../frb/docs/index.php).

### Common Usage

The easiest way to use a TMX file is to create a standard GameScreen and Level. This can be accomplished using one of the following methods:

1.  Run the Wizard when creating a new project - this will automatically add TMX files to your project.

    ![](../../../../media/2021-10-img_6166edc84073b.png) Existing (empty) projects can also run the wizard through the Quick Actions tab.

    ![](../../../../media/2021-10-img_6166ee164da74.png)
2.  Create a GameScreen and Level screens and check the options for creating TMX files. ![](../../../../media/2021-10-img_6166ee3ba4c28.png)

    ![](../../../../media/2021-10-img_6166ee644e2ae.png)

### Manually Adding a MapDrawableBatch From TMX to a Screen

If you are not using the GameScreen/Level pattern, you can add your own TMX files to Screens manually. To add a LayeredTileMap from an existing TMX:

1. Create a TMX file in Tiled
2. Save the TMX file in a location relative to your game's content folder. Be sure that all PNG files and TSX files (tileset files) are also relative to the game content folder
3. Create a game screen
4. Drag+drop the TMX file into your Screen's **Files** folder



<figure><img src="../../../../media/2016-01-2020_February_04_172542.gif" alt=""><figcaption></figcaption></figure>

 No additional code is necessary - your map will now show up in the screen.

### Creating Entities From a TMX

If using the GameScreen/Level pattern, FlatRedBall will automatically set up a Map object which can be used to create entities. If you are creating your own map object manually and you would like to create entities from this map, a small amount of extra work is needed.

#### Creating a Map object for Entity Creation in Glue

Once you have a TMX file in your screen's Files folder, you can create a Map object by drag+dropping the TMX onto the Screen's Objects folder. 

<figure><img src="../../../../media/2016-01-13_08-39-26.gif" alt=""><figcaption></figcaption></figure>

 Once the Map object has been created, its **Create Entities From Tiles** property can be checked.

![](../../../../media/2021-10-img_6166f03c272a0.png)

### LayeredTileMap as a list of MapDrawableBatches

The LayeredTileMap is mostly a List of MapDrawableBatches. For example, you can print out information about a MapDrawableBatch as follows:

```
string information = "This map has " + TestLevel.MapLayers.Count + " layers\n";

foreach (var layer in TestLevel.MapLayers)
{
    information += "Number of verts: " + layer.Vertices.Length + "\n";

}
```

![MapLayerInfo.PNG](../../../../media/migrated_media-MapLayerInfo.PNG)   \[subpages depth="1"]
