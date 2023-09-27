## Introduction

The default Platformer project creates a game with a level (Level1). We will modify this level to create ice and water tiles.

## Modifying Level1.tmx

We can open Level1Map.tmx to add additional tiles.

![](/media/2023-02-img_63e035bcbced8.png)

Level1Map.tmx should appear in the Tiled app. To make sure that no tiles from other maps are being used, be sure to close other TMX files in Tiled.

![](/media/2023-02-img_63e035fab1969.png)

Default maps include a tileset named TiledIcons. Most of these icons have no built-in functionality, so they can be used to add custom behavior to your game. In this case we will use the ice and water tiles which are part of the tileset.

![](/media/2023-02-img_63e0365f25494.png)

We can paint these tiles, along with more solid collision tiles, to create a test level with ice and water.

![](/media/2023-02-img_63e036d75a2c9.png)

## Conclusion

We have a level where the player can collide with the solid ground, but ice and water do not yet affect the Player's movement. [![](/wp-content/uploads/2021/04/05_16-10-02.gif.md)](/wp-content/uploads/2021/04/05_16-10-02.gif.md) The next tutorial shows how to add collision and change the player's movement values on ice and in water.
