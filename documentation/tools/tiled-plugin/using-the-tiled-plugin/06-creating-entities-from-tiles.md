## Introduction

So far we've looked at how to create tile maps and have them display in game. We've also used these tile maps to create collision. This guide shows how to instantiate entities by placing tiles in a tile map (no code required).

## Creating an Entity

Any type of entity can be created through tile maps, which provides lots of flexibility. For this example, we'll create a simple entity which displays a yellow rectangle called Monster:

1.  Select the **Quick Actions** tab in the FRB editor and click ****Add Entity****

    ![](/media/2021-02-img_603179247a2b1.png)

2.  Name the entity **Monster**

3.  Check the **AxisAlignedRectangle** check box

4.  Leave the other options default and click ****OK****

![](/media/2021-02-img_603179528d62a.png)

We need to modify the rectangle so it stands out relative to the collision rectangles:

1.  Select the newly-created rectangle (named AxisAlignedRectangleInstance)

2.  Change Width to 12

3.  Change Height to 12

4.  Change Color to Yellow

    ![](/media/2016-08-img_57acd2692ad27.png)

## 

## Defining Monster Tiles

We will be using the **Type** property to set the entity type. For a deeper dive on how this property works, see the Type documentation here: [/documentation/tools/tiled-plugin/using-tiled-object-types.md](/documentation/tools/tiled-plugin/using-tiled-object-types.md) The documentation linked above shows how to import an XML file created using the FRB editor so that variables defined on Monster (or any other entity) automatically appear in Tiled. For simplicity we'll skip this step, but you may want to perform that additional step for larger projects. To set the Type property:

1.  Open whichever level is currently being loaded in your game in Tiled (such as Level2Map.tmx)

2.  Select the TiledIcons. We should always use TiledIcons to create entities rather than visual tilesets like dungeonTileSet

3.  Click the Edit Tileset button

    ![](/media/2021-02-img_60317aed173f1.png)

4.  Select a tile on your map to represent the monsters. For example, select the red monster icon.

    ![](/media/2021-02-img_60317b4090261.png)

5.  Enter the entity name **Monster** as the **Type** for this tile. Depending on what version of Tiled that you are using, you may see **Class **instead of **Type**, but they both mean the same thing. Also, note that the name needs to match the entity name exactly, including capitalization

    ![](/media/2021-02-img_60317b80e081e.png)

## Placing Monster Tiles

Any tiles placed with the **Type** or **Class **of **Monster** will create Monster instances at runtime. Tiles for creating entities are placed just like any other tiles. We can place a few monster tiles in either level.  

![](/media/2021-02-img_60317c045fefa.png)

As always, don't forget to save your changes on the tile map and tile set. If we run our game, we will see the monster enemies (yellow rectangles).  

![](/media/2021-02-img_60317c757a487.png)

### Troubleshooting

If enemies aren't showing up, check the following:

-   Make sure that Level2Tmx.tmx and dungeonTileSet.tsx files have both been saved
-   Verify that you entered the correct name (including capitalization) in the **Type** or **Class** property.
