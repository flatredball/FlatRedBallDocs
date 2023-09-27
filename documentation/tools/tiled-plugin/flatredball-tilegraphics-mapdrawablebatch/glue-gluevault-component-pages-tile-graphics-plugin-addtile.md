## Introduction

The MapDrawableBatch class is the heart of the Tile Graphics Plugin. It is ultimately the class responsible for rendering the tile map graphics when your game runs. Although the Tile Graphics Plugin provides ways to construct MapDrawableBatches from .scnx files, the MapDrawableBatch can also be constructed purely in code. While this does require some code, working with the MapDrawableBatch class is actually very easy.

## What does "DrawableBatch" mean anyway?

The name MapDrawableBatch comes from the fact that it's usually used for tile maps, and it implements the FlatRedBall IDrawableBatch interface. The IDrawableBatch interface allows classes to implement completely custom rendering code using XNA, yet the result of the rendering will still be properly sorted with other FRB objects. The result is that the rendering code appears to be fully integrated into FRB despite being completely custom. If you are interested in more info on IDrawableBatch, see the [IDrawableBatch page](/frb/docs/index.php?title=FlatRedBall.Graphics.IDrawableBatch "FlatRedBall.Graphics.IDrawableBatch").

## Setting up a project

The MapDrawableBatch class works very well in Screens, but it can also be used in a non-Glue project. If you are not using Glue, make sure to follow the proper initialize/activity/destroy pattern explained here. For simplicity the rest of this article will be written assuming you are using Glue Screens. First you will need to download and install the Tile Graphics Plugin from GlueVault which can be found [here](http://www.gluevault.com/plug/59-tile-map-graphics-plugin). If you are not using Glue, but instead doing everything with pure code, you can download all of the .cs files from here: [http://www.flatredball.com/FlatRedBallAddOns/Trunk/FlatRedBall.TileGraphics/FlatRedBall.TileGraphics/](/FlatRedBallAddOns/Trunk/FlatRedBall.TileGraphics/FlatRedBall.TileGraphics.md). Next you will need to create or open a Glue project. Doing so after the the Tile Graphics Plugin has been installed will automatically add the appropriate classes to your code. Once you have a project created, you can verify the Tile graphics Plugin is installed and that it has properly modified your project by checking the project in Visual Studio. You should have a TileGraphics folder in your project.![TileGraphicsInSolutionExplorer.png](/media/migrated_media-TileGraphicsInSolutionExplorer.png). The next step is to add a Screen to your Glue project. This Screen will also need to contain a .png (any will do). We will be using this .png file in code. For more information on how to add files to your Screen, and how to access files in code, see [this page](/frb/docs/index.php?title=Glue:Reference:Files:Accessing_Files_in_Code "Glue:Reference:Files:Accessing Files in Code").

## Writing Code

Now that we have a project set up and we have a file that is available to be used, we can create our map. The first step is to create an instance in our GameScreen:

-   Open your project in Visual Studio
-   Navigate to your Screen class's .cs file (the custom code file)
-   Add the following code inside your GameScreen class but outside of any function:

&nbsp;

    FlatRedBall.TileGraphics.MapDrawableBatch mMap;

Next we'll initialize our class. First I'll present the code, then break apart what each piece means. The full code is:

    SpriteManager.Camera.UsePixelCoordinates();

    int numberOfTilesWide = 32;
    int numberOfTilesHigh = 32;
    int spriteSheetCellWidth = 16;
    int spriteSheetCellHeight = 16;

    mMap = new FlatRedBall.TileGraphics.MapDrawableBatch(
        numberOfTilesWide * numberOfTilesHigh, 
        spriteSheetCellWidth, 
        spriteSheetCellHeight, Slug);

    for (int x = 0; x < numberOfTilesWide; x++)
    {
        for (int y = 0; y < numberOfTilesHigh; y++)
        {
            Vector3 bottomLeftPoint = new Vector3(
                x * spriteSheetCellWidth,
                y * spriteSheetCellHeight, 
                0);

            int cellLeft = 0;
            int cellTop = 0;
            int cellRight = cellLeft + spriteSheetCellWidth;
            int cellBottom = cellTop + spriteSheetCellHeight;

            mMap.AddTile(bottomLeftPoint, new Vector2(spriteSheetCellWidth, spriteSheetCellHeight),
                cellLeft, cellTop, cellRight, cellBottom);
        }
    }
    mMap.AddToManagers();

Let's look at each section and see what it means:

    SpriteManager.Camera.UsePixelCoordinates();

The UsePixelCoordinates code is responsible for putting our Camera in "2D mode". For more information, see [this page](/frb/docs/index.php?title=FlatRedBall.Camera.UsePixelCoordinates "FlatRedBall.Camera.UsePixelCoordinates").

    int numberOfTilesWide = 32;
    int numberOfTilesHigh = 32;
    int spriteSheetCellWidth = 16;
    int spriteSheetCellHeight = 16;

    mMap = new FlatRedBall.TileGraphics.MapDrawableBatch(
        numberOfTilesWide * numberOfTilesHigh, 
        spriteSheetCellWidth, 
        spriteSheetCellHeight, Slug);

This code creates an instance of the MapDrawableBatch. Here we specify the number of tiles we want in our map. We are specifying it as 32 x 32. Keep in mind that increasing the dimensions will increase the number of tiles much faster. For example if your map is 32 tall and 32 wide, then it will include 32x32 = 1024. However, increasing to 64x64 results in 4096 tiles. While a 4096 map will usually render without any performance slowdown, it is possible to get to very large numbers very quickly, so you will want to run performance tests on your target platforms for the size of map you are interested in creating. Next we specify the size in pixels of how big our cells on our sprite sheet (the texture used by our tile map) will be. For example, consider the following image to show how big the cells are in a sprite sheet: ![SpriteSheetCellWidth.png](/media/migrated_media-SpriteSheetCellWidth.png) In this example the size of the sprite sheet cell is 16 by 16 pixels. My image happens to be 16 by 16 pixels so there is only one cell in the sprite sheet.

    for (int x = 0; x < numberOfTilesWide; x++)
    {
        for (int y = 0; y < numberOfTilesWide; y++)
        {
            Vector3 bottomLeftPoint = new Vector3(
                x * spriteSheetCellWidth,
                y * spriteSheetCellHeight, 
                0);

            int cellLeft = 0;
            int cellTop = 0;
            int cellRight = cellLeft + spriteSheetCellWidth;
            int cellBottom = cellTop + spriteSheetCellHeight;
     
            mMap.AddTile(bottomLeftPoint, new Vector2(spriteSheetCellWidth, spriteSheetCellHeight),
                cellLeft, cellTop, cellRight, cellBottom);
        }
    }

This line of code creates each cell. Each cell needs to know 3 pieces of information:

1.  The bottom-left corner of the tile in world coordinates.
2.  The width and height of the tile. This will usually match the size of the cells.
3.  The top, bottom, left, and right pixels of the cell to use. In this case we are rendering the entire sprite sheet, so we use 0 - 16.

&nbsp;

    mMap.AddToManagers();

The AddToManagers call adds the MapDrawableBatch to the engine. In other words, once this call is made the MapDrawableBatch will be rendered to the screen when your game runs: ![SlugTileMap.PNG](/media/migrated_media-SlugTileMap.PNG)
