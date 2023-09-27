## Introduction

Typically tile-based games with multiple levels will use one LayeredTileMap (TMX) per level. In this case the base screen (typically called GameScreen) should contain most (if not all) of the logic and collision objects.

## Creating a Map Object

For this example we will begin with three screens:

1.  GameScreen (the base screen for level screens)
2.  Level1
3.  Level2

Each level has its own TMX file too.

![](/media/2020-02-img_5e3a12fdd20af.png)

First we'll add a LayeredTileMap object to the GameScreen. This will represent the current map:

1.  Right-click on Objects
2.  Select **Add Object**
3.  Verify the **FlatRedBall or Custom Type** option is selected
4.  Select **LayeredTileMap**
5.  Name the new object **Map**

[![](/wp-content/uploads/2020/02/2020_February_04_172458.gif.md)](/wp-content/uploads/2020/02/2020_February_04_172458.gif.md)

Next we'll make the newly-created Map object available to our levels:

1.  Select **Map**
2.  Set **SetByDerived** to **True**

![](/media/2020-02-img_5e3a548f53096.png)

Now we need to associate the TMX from each of our levels to the Map object:

1.  Expand **Level1**
2.  Expand **Files**
3.  Expand **Objects**
4.  Drag+drop the TMX onto Map

[![](/wp-content/uploads/2020/02/2020_February_04_183802.gif.md)](/wp-content/uploads/2020/02/2020_February_04_183802.gif.md) Repeat the process above for all levels, and anytime you create a new level. Now the Map can be used to set up the collisions on the TileShapeCollection:

![](/media/2020-02-img_5e3a14811d3f0.png)
