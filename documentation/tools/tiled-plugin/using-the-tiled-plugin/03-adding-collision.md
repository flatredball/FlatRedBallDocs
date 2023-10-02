# 03-adding-collision

### Introduction

Collisions are used in almost every game. Collisions are often used for the following functionality:

* Solid collision to keep players, enemies, and bullets from moving between rooms or out of bounds
* Damage collision to deal damage to players, slow movement, or heal players

This tutorial will show how to work with the solid collision, and how to add new types of collision to your game.

### Solid Collision

By default our game already has SolidCollision defined in the GameScreen - this was added earlier in the first tutorial by one of the options. Until now the SolidCollisions have been invisible, and we haven't created anything to collide against. Therefore, there hasn't been any functionality yet either. We can verify that the SolidCollision shape collection is actually being created by making it visible. To do this:

1. Expand the **GameScreen** in Glue
2. Select the SolidCollision object. Note that it is blue, indicating that it is visible to children screens such as Level1
3. Click the Variables tab
4. Check the Visible property

![](../../../../media/2021-02-img\_6031536268380.png)

If you run the game now, you will see that all solid collision tiles are outlined in white. This is the SolidCollision object.

![](../../../../media/2021-02-img\_60315396e0918.png)

&#x20;

###

You may want to keep collision visibility set to true to help diagnose problems in your game, but you should turn it to false when your game is ready to distribute.

####

### Creating Additional TileShapeCollections

As mentioned above, the SolidCollision shape collection is a common object, so the FRB editor provides quick defaults for this type. For the rest of this tutorial we will cover how to create a new TileShapeCollection. At a high level, the steps are:

1. Decide on a tile to use for collision
2. Set the Type on the tile
3. Create a new TileShapeCollection in GameScreen
4. Configure the TileShapeCollection to be created from the tile type specified earlier

### Setting the Tile Type

The first step is to decide which tile you would like to use for your collision. As we mentioned before, all gameplay tiles (such as collision) should be on the TiledIcons. To mark a tile as collidable:

1. Open Tiled
2.  Click the TiledIcons tileset

    ![](../../../../media/2021-02-img\_60315823db414.png)
3.  Click the Edit icon to edit the TiledIcons tileset

    ![](../../../../media/2021-02-img\_60315871cbd77.png)
4. Select a Tile that you would like to use for collision
5.  Enter a Type for that tile.

    ![](../../../../media/2021-02-img\_603159b33ab60.png)
6. Don't forget to save your tileset file

Now that the type has been set and the tileset has been saved, you can place the tile in your level. Make sure to place it on the GameplayLayer in case your game has multiple layers. [![](../../../../media/2016-08-2021\_February\_20\_112950.gif)](../../../../media/2016-08-2021\_February\_20\_112950.gif) Be sure to save your map after adding tiles.

### Creating a New TileShapeCollection

Now that we have a new tile type in our game, we can add another TileShapeCollection. To do this:

1. In Glue, select the GameScreen
2. Click the **Quick Actions** tab
3.  Select the **Add Object to GameScreen** button

    ![](../../../../media/2021-02-img\_60315b62ae54c.png)
4. Type or look for **TileShapeCollection** in the window and select this option
5. Enter the name for your tileset. Usually this should match the type of your tile.
6. Click OK

![](../../../../media/2021-02-img\_60315d0613576.png)

### Configuring the TileShapeCollection

TileShapeCollections usually come from specific tiles in tile maps. We'll set up the TileShapeCollection created in the previous section here. To do this:

1. Select the newly-created TileShapeCollection
2. Click the **TileShapeCollection Properties** tab
3. Select the **From Type** option
4. Select **Map** as the source TMX
5. Select the matching type in the **Type** dropdown

![](../../../../media/2021-02-img\_60315ebd96e51.png)

Notice that **Remove Tiles** is checked by default. Uncheck this option if you would like to see the tiles in game. We should also turn on collision visibility to make sure it is created as we expect.

![](../../../../media/2021-02-img\_60315de799ae0.png)

If you run your game, you will see the collision in game. The tiles will be removed if the **Remove Tiles** checkbox was left checked.

![](../../../../media/2021-02-img\_60315f7fc6166.png)

### Creating TileShapeCollections in Code

As mentioned earlier, TileShapeCollection instances can also be created in code. For more information on creating collision code from Tiles, see these links:

* [Creating TileShapeCollections using tile properties](../glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection/addcollisionfromtileswithproperty.md)
* [Creating TileShapeCollections using tile name or property values](../glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection/addcollisionfrom.md)
