# using-tiled-object-types

### Referencing TiledObjects

The Tiled plugin automatically creates and maintains a file called **TiledObjects.Generated.xml** whenever an entity is created or modified. It can be used in Tiled to simplify object creation. For a more detailed discussion of using a custom XML file for tiled objects, see the Tiled manual: [http://docs.mapeditor.org/en/latest/manual/custom-properties/?highlight=object%20xml](http://docs.mapeditor.org/en/latest/manual/custom-properties/?highlight=object%20xml) This file contains a list of all entities which have their **Created by Other Entities** marked as true. It is formatted such at it can be used in Tiled to create new entity instances. This file is located in the content folder of your main project. For XNA projects, this is located in: \<solution location>/\<project name>/\<project name>Content/TiledObjects.Generated.xml

### TiledObjects is Generated

Note that TiledObjects.Generated.xml is generated automatically by the FRB editor whenever entities are added, removed, or changed. Therefore, any changes that are made to TiledObjects.Generated.xml manually (either in a text editor or by changing properties in Tiled) will be overwritten the next time the FRB editor generates these objects. In other words, if you choose to use TiledObjects.Generated.xml, then you can only define and modify types through the FRB editor.

### Referencing TiledObjects in Tiled

To use this file in Tiled:

1. Open Tiled (you can do this by double-clicking your .tmx file if it's not open already)
2.  Select **View** -> **Object Types Editor.** In newer versions of tiled, it may be called **Custom Types Editor**. \*\*\*\*

    ![](../../../media/2018-12-img_5c22ac940a2dc.png)

    ...to open the **Object Types Editor** window ![](../../../media/2017-11-img_5a0679f01841a.png)
3. Select **File** -> **Choose Object Types File...**
4.  Navigate to the location where your TiledObjects.Generated.xml (which should be in the content folder) is located and click **Open**. Note that if you are in the correct location, but the TiledObjects.Generated.xml is not visible, that you may need to specify **.xml** in the Object Types files section, as it might be searching for .json files.

    ![](../../../media/2017-11-img_5a07599a7109a.png)

After loading the file, you should see any entities in your project which are marked as **CreatedByOtherEntities** set to true.

![](../../../media/2017-11-img_5a0759e66c544.png)

### Creating Tiled Using Object Types with Tiles

Once you have imported the file, Tiled will let you apply this type to tiles in your tileset and objects in your object layers. To create entity instances using tiles:

1. Open the tileset (.tsx) file in Tiled
2. Find a tile that you would like to be associated with one of the entities (such as Monster in the example above)
3.  Right-click on the tile and select **Tile Properties...**

    ![](../../../media/2017-11-img_5a076066b498e.png)
4. In the properties window, begin typing the type. Notice that Tiled will list all available entities to help you make a selection 

<figure><img src="../../../media/2017-11-2017-11-11_13-42-57.gif" alt=""><figcaption></figcaption></figure>



&#x20; Now this tile can be painted on a tilemap.

### Creating Tiled Using Object Types with Object Layers

Creating entities with Tiles is useful if all of the entities are the same (such as coins in a Mario game). However, sometimes entities must differ from instance to instance - such as NPCs in a role playing game, each with different dialog. Tiled objects support setting different values on an instance-by-instance basis. In this case the FRB entity should probably have one or more variables which will be changed per-instance. For example, the Monster entity may have XP and Gold variables.

![](../../../media/2017-11-img_5a0785ad72bdb.png)

If we select the Monster type in Tiled we will see the XP and Gold variables as well. ![](../../../media/2017-11-img_5a0785f21b23c.png) Default values from FRB editor will even be carried over to Tiled.

![](../../../media/2017-11-img_5a07894bdab5b.png)

To create entity instances on an object layer:

1. Add an Object Layer to your tilemap 

<figure><img src="../../../media/2017-11-2017-11-11_16-22-34.gif" alt=""><figcaption></figcaption></figure>


2. Paint a new tile onto your map 

<figure><img src="../../../media/2017-11-2017-11-11_16-24-45.gif" alt=""><figcaption></figcaption></figure>


3.  Give the newly-created object a Type of **Monster** (or whatever entity type you want). Notice that doing so will automatically display the variables added in the FRB editor under the **Custom Properties** section. Notice that X, Y, and Z variables do not appear in the Custom Properties section - X and Y are already part of the regular properties of an object. The Z value is set according to the object's layer.

    ![](../../../media/2017-11-img_5a0787624b1c3.png)
4. These values can be left to their default or modified

Also, note that if a tile is already given a type, then painting that tile on an object layer will automatically result in the painted tile using the same type. This can speed up placing similar objects.

### Adding Code to Create Entities

Once tiles have been given a type, these can be converted to entities using the TileEntityInstantiator . For a full tutorial on using the TileEntityInstantiator, see this link: [http://flatredball.com/documentation/tools/tiled-plugin/using-the-tiled-plugin/06-creating-entities-from-tiles/](using-the-tiled-plugin/06-creating-entities-from-tiles.md) To instantiate all entities, add the following code to your screen's CustomInitialize:

```lang:c#
// This assumes your TMX is called Level1. Substitute the name of your TMX
FlatRedBall.TileEntities.TileEntityInstantiator.CreateEntitiesFrom(Level1);
```

### Requirements and Troubleshooting

If your entities are not showing up in game or in Tiled, the following steps may help you identify the problem.

#### Type Definition XML Files Are Global

The type definition file loaded in Tiled applies app-wide, as opposed to per map or per tileset. This means that if you are using Tiled for multiple projects you will need to remember to swap .xml files when switching between the two projects.

#### Entity CreatedByOtherEntities Must Be True

Only entities with their CreatedByOtherEntities property set to true will appear in the TiledObjects.Generated.xml file.

![](../../../media/2017-11-img_5a078306b89e8.png)

#### Screen Must Have an Entity List

Any screen where you are creating entities from a .tmx file must have a a list for each entity type.

![](../../../media/2017-11-img_5a078364558b2.png)

#### Tiled May Need to be Restarted

As of Tiled 1.0.3, the referenced Object Types file does not automatically get reloaded when it changes on disk. This means that if you add an entity, remove an entity, or add a new property to an entity, you may need to restart Tiled for the changes to apply. This bug is logged and can be tracked here: [https://github.com/bjorn/tiled/issues/1816](https://github.com/bjorn/tiled/issues/1816) Furthermore, there is sometimes an issue with your properties/variables not being loaded to your Tiled type even when the variables show up in the .xml file and after you have refreshed Tiled. If you encounter this, you may need to re-import the .xml file in the object/custom types editor again, and it should show up after doing so.

###
