# glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection

### Introduction

TileShapeCollection is a class created specifically for tile based collision. Its features include:

* Very fast collision - it has partitioning built-in.
* Eliminates snagging - Internally the TileShapeCollection modifies contained AxisAlignedRectangles' [RepositionDirections](../../../../frb/docs/index.php) to eliminate snagging.
* Full support in the FlatRedBall Editor for initial definition and collision relationships.
* Simplified syntax - Adding collisions to TileShapeCollection is very easy to do in code, whether doing so manually in code or from a loaded TMX file.

### TileShapeCollections and the Wizard

If you have created your project using the FlatRedBall Editor Wizard (either platformer or top-down), then your game already has TileShapeCollections. For example, the GameScreen should have a SolidCollision TileShapeCollection.

![](../../../../media/2023-01-img\_63bb3de436e54.png)

### Creating TileShapeCollections in the FlatRedBall Editor

To add a TileShapeCollection:

1. Expand your GameScreen or Screen which should contain the TileShapeCollection. Typically collision is added to GameScreen.
2. Right-click on Objects and select **Add Object**
3. Verify **FlatRedBall or Custom Type** is selected
4.  Select the **TileShapeCollection** option

    ![](../../../../media/2020-02-img\_5e38ef034ce17.png)
5. Click **OK**

Now that you have created a TileShapeCollection, you can fill it using a variety of methods as shown before.

### Example - Setting Collision from a Tile

The most common usage of TileShapeCollections is to add collision from a particular tile Type. Usually this is done through a Map object in the GameScreen. If your project has been set up using the wizard, then you should have a Map object in GameScreen. If so, you can:

1. Select the TileShapeCollection that you would like to fill from the map
2. Check the TileShapeCollection properties
3. Select the **From Type** option
4. Use the dropdown to select the type. These types will match the types defined in your map's Tileset (tsx) file

![](../../../../media/2022-04-img\_62686492a966c.png)

### Example - Filling a TileShapeCollection Completely

When creating a game, you may want to add some placeholder collisions to test your logic and collision relationships. To create placeholder collisions:

1. Select your TileShapeCollection in Glue
2.  Click the **TileShapeCollection Properties**

    ![](../../../../media/2020-02-img\_5e38efad33db9.png)
3. Select the **Fill Completely** option
4.  Set the **Tiles Wide** and **Tiles High** to define the size of collision block you want

    ![](../../../../media/2020-02-img\_5e38f03167fff.png)
5. Click the **Variables** tab
6.  Check the **Visible** checkbox

    ![](../../../../media/2020-02-img\_5e38f068e44d4.png)

Now the TileShapeCollection will appear in your game and can be used for testing.

![](../../../../media/2020-02-img\_5e38f096cfeac.png)

### Defining Collision from a TMX File

Testing your collision using Fill or Border Outline is a handy way to make sure your game is working as you expect it, but eventually you will want to have collision defined in a map. For this tutorial we'll work with a simple game with a single TMX file already added to the GameScreen which also contains a TileShapeCollection. ![](../../../../media/2020-02-img\_5e38f2156c957.png) First we'll specify which tiles should have collision:

1. Open Tiled
2.  Click the wrench icon to edit the tileset

    ![](../../../../media/2020-02-img\_5e38f25d139e7.png)
3.  Select one (or more) tiles which should have collision

    ![](../../../../media/2020-02-img\_5e38f27e1f95e.png)
4.  Add a Custom Property called SolidCollision. The type of the variable doesn't matter.

    [![](../../../../media/2016-01-2020\_February\_03\_211827.gif)](../../../../media/2016-01-2020\_February\_03\_211827.gif)
5. Save your tileset (tsx)
6.  Place some tiles in your map

    ![](../../../../media/2020-02-img\_5e38f2f89de53.png)
7. Save your TMX

&#x20; Now in Glue we can associate the SolidCollision with the TileShapeCollection:

1. Select the TileShapeCollection in your GameScreen
2. Click the **TileShapeCollection Properties** tab
3. Select the **From Property** option
4. Use the dropdown to select your TMX file
5.  Enter the property SolidCollision

    ![](../../../../media/2020-02-img\_5e38f3824da91.png)

Now if you run your game you will see collision wherever you placed your tiles.

![](../../../../media/2020-02-img\_5e38f3a99c37c.png)

&#x20;

### TMX (LayeredTileMap) Example

Collision can be added to a TileShapeCollection from a loaded TMX file (which loads into a LayeredTileMap). The following code shows how to add collision from all tiles with the custom property **HasCollision**.

```lang:c#
// These examples assume that a TileShapeCollection named
// solidCollision is defined somewhere (usually class scope for the screen)
TileShapeCollection solidCollision;

// Note that the TileShapeCollection is first created, then 
// collision is added. The following code might be in the Screen's CustomInitialize

solidCollision = new TileShapeCollection();
solidCollision.AddCollisionFromTilesWithProperty(TiledLevel, "HasCollision");
```

#### Code-Only Example

The following example shows how to create an AxisAlignedRectangle that moves around with the keyboard and collides against a TileShapeCollection. This project assumes a Glue project with:

1. A Screen called GameScreen
2. An AxisAlignedRectangle object named Rectangle in GameScreen

To add the TileShapeCollection:

1. Open the project in Visual Studio
2. Open GameScreen.cs
3.  Add the following using statement:

    ```
    using FlatRedBall.TileCollisions;
    ```
4.  Add the following at class scope:

    ```
    TileShapeCollection mCollision;
    ```
5.  Add the following to CustomInitialize:

    ```
    mCollision = new TileShapeCollection();
    mCollision.GridSize = 32;
    mCollision.Visible = true;

    for (int i = 0; i < 10; i++)
    {
        mCollision.AddCollisionAtWorld(i * 32 + 16, 16);
    }
    ```

To add movement and collision to your rectangle, add the following code to CustomActivity:

```
InputManager.Keyboard.ControlPositionedObject(Rectangle, 200);
mCollision.CollideAgainstSolid(Rectangle);
```

Finally you'll need to remove the TileShapeCollection. To do this, add the following to CustomDestroy:

```
mCollision.RemoveFromManagers();
```

### Defining Custom Per-Tile Collision

By default each rectangle in a TileShapeCollection occupies the entire tile (16x16). Custom shapes can be defined in Tiled to create rectangles which occupy less than the entire tile, or even polygons for sloped collision. Partial tile collisions are defined in the TSX file, typically in the StandardTileset.tsx. To add collision on tiles:

1.  Open the TSX file in Tiled

    ![](../../../../media/2022-02-img\_621ac68f5ff1a.png)
2.  Select the tile which should have partial collision

    ![](../../../../media/2022-02-img\_621ac745799f1.png)
3.  Select **View** -> **View and Toolbars** -> **Tile Collision Editor**

    ![](../../../../media/2022-02-img\_621ac7774e2f5.png)
4. Draw a rectangle or polygon on the tile [![](../../../../media/2016-01-26\_17\_38\_10.gif)](../../../../media/2016-01-26\_17\_38\_10.gif)
5.  Set the type on the tile which has the collision. Note that the same type can be given to multiple tiles. Be sure to select the tile and not the shape. You may need to deselect and re-select the tile to force its properties to display rather than the newly-drawn polygon.

    ![](../../../../media/2022-02-img\_621ac85c92bd0.png)
6. Repeat this process for any other tile which should have custom shapes.
7. Once you have added shapes to all of the tiles, and once you have set the types on the tiles, save the TSX file.
8.  Paint the tiles in their desired locations. Note that tile collision can be previewed in Tiled by selecting the **View** -> **Show Tile Collision Shapes** option

    ![](../../../../media/2022-02-img\_621b99413e7ec.png)

    ![](../../../../media/2022-02-img\_621b99668f609.png)
9. Save the Tiled (TMX) file.

To use these shapes:

1. Select an existing TileShapeCollection or create a new TileShapeCollection. Typically this TileShapeCollection would be in the GameScreen.
2. Select the **TileShapeCollection Properties** tab
3. Select the **From TMX Collision (use tileset shapes)** option
4. Set **Source TMX File/Object** to **Map**

![](../../../../media/2022-02-img\_621b97d866e9f.png)

The TileShapeCollection will now include custom shapes as defined in Tiled.   &#x20;

### Additional Information

1. [PlatformerCharacterBase and TileShapeCollection](../../../../frb/docs/index.php) - discusses how to use the PlatfromerCharacterBase with TileShapeCollection.
