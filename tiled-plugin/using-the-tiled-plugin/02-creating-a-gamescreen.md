# 02-creating-a-gamescreen

### Introduction

This walk-through creates two screens. The first is a screen called GameScreen which defines what our game has in every level. The second is a screen called Level1 which has files and objects for our first level. GameScreen will be a base class for Level1, and any additional levels will also use GameScreen as a base screen. At the end of this walk-through we will have a tile map rendering in a our game.

### Adding GameScreen

First we'll create a screen called GameScreen. Many FlatRedBall projects contain a GameScreen which typically contains the _main gameplay_ - as opposed to menus to set up the game. The GameScreen also contains any common objects such as lists of entities and game logic. Note that if you have used the Platformer or Top-Down wizard options, you will already have a GameScreen. To add a GameScreen:

1. In Glue, select the **Quick Actions** tab
2.  Click the **Add Screen/Level** button

    ![](../../../../media/2021-02-img_603139d62debc.png)
3. Notice that Glue suggests creating a **GameScreen**. We recommend always having one screen called GameScreen, so this default helps you set your project up quickly.
4. Click the option to \*\*Add Map LayeredTileMap. \*\*This sets up a base object for your map which will be used in all levels.
5. Click the option to **Add SolidCollision ShapeCollection**. Most games need solid collision so this will set up your game for that.
6.  Leave all other defaults and click **OK**

    ![](../../../../media/2022-05-img_6287da871fd59.png)

Once you click OK you will have a GameScreen which includes Map and SolidCollision objects.

![](../../../../media/2021-02-img_60313b3b433db.png)

For now we'll leave our GameScreen empty, but we'll return later to add objects. \[frb_toggle title="Alternative - Manually Creating Solid Collision"] Above we automatically created the SolidCollision object through a check box. If you didn't check this option, or if you are interested in how to set this up manually, this section will walk you through the process. To manually create the SolidCollision object:

1. Select the **GameScreen** in Glue
2. Go to the **Quick Actions** tab
3.  Click **Add Object to GameScreen**

    ![](../../../../media/2021-02-img_603278ee43e9b.png)
4. Search for **TileShapeCollection** in the **New Object** window
5. Enter the name **SolidCollision**
6.  Click **OK**

    ![](../../../../media/2021-02-img_603279bb85e66.png)

Now the SolidCollision should appear in the GameScreen. Next we need to modify the TileShapeCollection to properly use the SolidCollision tile.

1. Select **SolidCollision** in Glue under **GameScreen**
2. Select the **TileShapeCollection Properties** tab
3. Select the **From Type** option under **Creation Options**
4. Select the **Map** under **Source TMX File/Object**
5.  Enter or select **SolidCollision** under **Type**

    ![](../../../../media/2021-02-img_60327b3d6d252.png)

Finally we need to set the property as Set By Derived so that level screens can modify this:

1. Select **SolidCollision**
2. Select the **Properties** tab
3. Set the **SetByDerived** property to **True**

![](../../../../media/2021-02-img_60327c03e75a2.png)

\[/frb_toggle]

### Adding Level1 Screen

Next we'll create our first level. Levels are regular screens which inherit from a base class that contains common gameplay objects, files, and code. To add Level1:

1. Go to the **Quick Actions** tab
2.  Click **Add Screen/Level**

    ![](../../../../media/2021-02-img_60313b96abcf7.png)
3. Verify that the following options are set:
   1. Name **Level1** (no spaces)
   2. **Add Standard TMX File** option is selected. This will add a TMX file to this level for you, saving you extra steps.
4.  Click **OK**

    ![](../../../../media/2021-02-img_60313f4f9cca9.png)

Once you click the OK button, Glue will ask you about details for the new map.

1. Verify the name is **Level1Map**. The standard naming is to append the word **Map** to the name of the Screen containing the new TMX file
2. Leave the other options default (checked). These options will make it easier to create functional tile maps.
3.  Click OK

    ![](../../../../media/2022-05-img_6287db23aadf1.png)

You should now have a Level1Map file in your Level1 screen.

![](../../../../media/2021-02-img_6031408a58a00.png)

###

\[frb_toggle title="Alternative - Creating TMX in Tiled"] To create a tile map file in Tiled:

1. Open the Tiled program
2. Select **File**->**New**->**New Map...**
3. Set the **Tile layer format** to **Base64 (zlib compressed)**. Compressing the tile map will make the .tmx file smaller. We will need to change the type of compression used in a later step, since the new file window only lets us pick "zlib".
4. Set the **Tile size** to a **Width** of **16px** and a **Height** of **16px**. Tile sizes are usually multiples of 2 (2, 4, 8, 16, 32). This guide uses a tile set with 16x16 tiles.
5. Click **Save As...** ![](../../../../media/2018-04-img_5ad9edb5c3a12.png)
6.  Navigate to the Level1's Content folder. You can find this by right-clicking on the GameScreen's **Files** item in Glue and selecting **View in explorer**

    ![](../../../../media/2019-07-img_5d1ca326b595f.png)
7.  Save the file as Level1File.tmx

    ![](../../../../media/2019-07-img_5d1ca39751724.png)

#### Changing to GZip (Only if Created in Tiled)

Now that we've created a map, we will change the "Tile Layer Format" to "Base64 (gzip compressed)". We need to make this change after we create the map because Tiled does not let us pick gzip compression when first creating the map, and gzip compression works on all FlatRedBall platforms (zlib does not).

1. Find the map properties on the left-side of the screen
2.  If the properties window is not open, select the **Map** -> **Map Properties...** menu item

    ![](../../../../media/2018-04-img_5ad9ef60d069a.png)
3. Change the **Tile Layer Format** to **Base64 (gzip compressed)** ![](../../../../media/2016-08-img_57abb3401128c.png)

Now that the format has been changed, save the file again. Finally the file can be added to the Level1 screen by drag+dropping the file from windows explorer to the Files item under Level1. 

<figure><img src="../../../../media/2016-08-2019-07-03_06-48-05.gif" alt=""><figcaption></figcaption></figure>

 The game now references the .tmx file, and when executed the game loads the empty .tmx file. \[/frb_toggle]

### Editing the TMX File

If you have Tiled installed, then the installer should have associated the .TMX file format with the Tiled program. You can edit the file a few ways:

*   Double-click the TMX file under **Level1 Files**

    

<figure><img src="../../../../media/2016-08-2021_February_20_104104.gif" alt=""><figcaption></figcaption></figure>


* Use the drop-down in the toolbar to select the map to edit 

<figure><img src="../../../../media/2016-08-2021_February_20_102205.gif" alt=""><figcaption></figcaption></figure>



If you followed the previous steps, your map should include:

1. A single layer called **GameplayLayer**
2. A single Tileset called **TiledIcons**

![](../../../../media/2021-02-img_603142bfa74a7.png)

This tileset was automatically added in an earlier step so that you can hit the ground running on creating your game. It contains common tiles for many games, but this tutorial will focus on the solid collision tile, which is the top-left tile in the tileset.

![](../../../../media/2021-02-img_603143ca04832.png)

We can click this tile and place it on the **GameplayLayer** to create walls, floors, or any other type of solid collision. 

<figure><img src="../../../../media/2016-08-2021_February_20_103417-1.gif" alt=""><figcaption></figcaption></figure>

 Don't forget to save your work in Tiled - otherwise it won't show up in game.

![](../../../../media/2021-02-img_6031449fb6101.png)

### Playing Your Game

Once you have saved your tileset, you can play the game by pushing the play button in the FRB editor.

![](../../../../media/2021-02-img_6031452c21294.png)

Alternatively you can open your project in Visual Studio and build/run it there. Use whichever method you are most comfortable with. Either way, you should see your game run with the Level1 map displayed.

![](../../../../media/2021-02-img_6031465890171.png)

Notice the file may be offset depending on which tiles are painted. This is because the center of the screen is (0,0), which is the top-left of the tile. To adjust the camera so that the top left of the game window matches the top left of the tile map:

1.  Open Visual Studio

    ![](../../../../media/2021-02-img_6031470068e28.png)
2.  Open **GameScreen.cs**. We could do this in Level1.cs  if we wanted it to be logic specific to Level 1, but we want to have this code run for all levels.

    ![](../../../../media/2021-02-img_603147579ee3a.png)
3.  Modify the CustomInitialize  method as follows:

    ```lang:c#
    void CustomInitialize()
    {
        Camera.Main.X = Camera.Main.OrthogonalWidth / 2.0f;
        Camera.Main.Y = -1 * Camera.Main.OrthogonalHeight / 2.0f;
    }
    ```

Now the game will be focused on the map.

![](../../../../media/2021-02-img_6031479185612.png)

### Optional - Adding a Tileset

Tilesets define the appearance of a collection of tiles along with properties which can be specified per-tile to provide functionality in your game (such as collision). We recommend that games have a dedicated tileset for gameplay functionality such as collision. We used the TiledIcons tileset for this earlier. This section will show you how to add a second tileset for visuals. We will use the following image which you can download: [![dungeonTileSet](../../../../media/2016-08-dungeonTileSet.png)](../../../../media/2016-08-dungeonTileSet.png) Files which are used by TMX levels should either be saved in the content folder of one of the level screens or in the content folder in the GameScreen. For this tutorial we'll save the file in the GameScreen folder, since the file will be used by multiple levels. First we'll open the content folder for GameScreen:

1. Expand \*\*GameScreen \*\*in the FRB editor
2. Right-click on the **Files** folder under GameScreen
3. Select **View in explorer**

The content folder for GameScreen will be open (and empty). ![](../../../../media/2018-09-img_5b991adb938e1.png) Save the tileset (shown above) to the GameScreen content folder (which we just opened).



<figure><img src="../../../../media/2016-08-2018-09-12_07-57-59.gif" alt=""><figcaption></figcaption></figure>



To use the dungeonTileSet.png file in the tile map:

1. Open **Level1Map.tmx** (double-click it in the FRB editor or open it in Windows Explorer)
2. Drag+drop the **dungeonTileSet.png** file into the **Tilesets** tab (the bottom right pane in Tiled) 

<figure><img src="../../../../media/2016-08-2021_February_20_102048.gif" alt=""><figcaption></figcaption></figure>


3. Verify that **Tile width** and **Tile height** are both **16px**
4.  Click **Save As...**

    ![](../../../../media/2018-09-img_5b991d0deca5b.png)
5.  Save the file in the same location as the PNG (the GameScreen content folder)

    ![](../../../../media/2018-09-img_5b991d2a83156.png)

The tileset (called **dungeonTileSet**) will now be shown in the Tilesets section in Tiled.

![](../../../../media/2019-07-img_5d1ca4fc66f33.png)

#### Tileset Considerations

The Tiled program is very flexible when when constructing tilesets. For performance reasons, FlatRedBall does not support all tileset features. When constructing your own tilesets, keep the following in mind:

* Each tileset must use exactly one image file. Tiled supports multiple image files per tileset, but FlatRedBall does not.
* Each layer in your map can only use one tileset. Tiled supports painting multiple tilesets on one layer, but FlatRedBall does not.
* The fewer tilesets, the faster your game will load and render. If possible, try to fit your entire game on one tileset. FlatRedBall supports textures as large as 4096x4096, although some phones and older computers can only load textures as large as 2048x2048.
* For organization reasons, it's useful to save the tileset file (.tsx) and image file (.png) in the same folder. This tutorial saves the file in the GameScreen folder, a number of other common options exist. No matter which option you choose, make sure the folder is ultimately inside your game's Content folder:
  * GameScreen folder (as mentioned above)
  * Top-level Content folder
  * GlobalContentFiles folder
  * Dedicated Tiled folder inside the Content folder

#### TMX, PNG, and TSX Files

TMX files are the file format that contains the tile map. Along with the TMX file, games that use Tiled will usually reference image files (PNG) and reference external tileset files (TSX). The FRB editor is able to track these references automatically, so only the TMX file needs to be added to your screen (as was done earlier). Any PNG and TSX files referenced by the TMX file will automatically be added to your Visual Studio project by the FRB editor. In other words, once you add a TMX to your screen you don't have to do any other file management anywhere in the FRB editor or Visual Studio.

### Placing Tiles

Once a tileset has been created, tiles can be placed by clicking on a tile in the tile set, then painting on the map. As mentioned above, you cannot mix multiple tilesets into a single layer. Therefore, to place the new visual tiles, you will need a new layer.

1. Add a new tile layer to your map
2. Name the layer Visuals
3. Select the newly-created layer
4. Select the dungeonTileSet
5. Paint tiles on the new layer



<figure><img src="../../../../media/2016-08-2021_February_20_105257.gif" alt=""><figcaption></figcaption></figure>

   Keep in mind that changes made to the .tmx file in Tiled must be saved before they will show up in game. Also, the FRB editor automatically manages files referenced by .tmx files, so we do not need to manually add the dungeonTileSet.png file to the GameScreen.

###

### TextureFilter and Tile Maps

Texture filtering is a method of making objects look less-pixellated when zoomed in. Most 3D games apply a form of "non-point" linear filtering, which removes the square pixel looks of zoomed-in textures. Unfortunately, since tile maps pack each tile adjacent to one-another, this can cause lines to appear between each tile when running the game in FlatRedBall. For example, consider the horizontal lines which appear on the tree and purple ground in the following image: ![](../../../../media/2017-06-img_593acc78bff79.png) To avoid this, _point filtering_ should be used. To apply point filtering, add the following code, preferably in Game1.cs  Initialize, after initializing FlatRedBall:

```lang:c#
FlatRedBallServices.GraphicsOptions.TextureFilter = 
    Microsoft.Xna.Framework.Graphics.TextureFilter.Point;
```

For more information, see the [TextureFilter page](../../../../api/flatredball/graphics/graphicsoptions/texturefilter.md).

### Troubleshooting

If your tile map does not appear, the following section may help solve the problem.

#### Map Ordering

Loaded tile maps are drawn in the FlatRedBall engine, sorted by their Z value. A single-layer map will be drawn at Z = 0, so any object with a larger Z value will draw in front of the map. If a map has multiple layers, each layer will be 1 unit in front of the layer before it. For example, a map with four layers will have the layers at Z values 0, 1 ,2 and 3. Note that if layers are added under the GameplayLayer, and if Shift Map To Move Gameplay Layer To Z0 is checked, then the map will be shifted on the Z axis so that the GameplayLayer is at Z=0, and all other layers are above or below, each offset by one unit.

![](../../../../media/2022-02-img_620b09801d166.png)
