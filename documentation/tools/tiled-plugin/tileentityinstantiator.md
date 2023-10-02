# tileentityinstantiator

### Introduction

FlatRedBall supports the creation of Entity instances by adding either tiles or objects in a Tiled Map (.tmx). This document shows how to do so.

### Defining an Entity for Instantiation

Before adding an entity to your screen, you must first define an entity. Once an entity is defined, it can be created through Tiled. Any entity can be instantiated in a Tiled map - even entities which are larger than the size of the tiles in your game (usually 16x16). By default FlatRedBall sets the options necessary to instantiate entities through a Tiled Map in the new entity dialog as shown in the following image:

![](../../../media/2022-01-img\_61ec1b00de44c.png)

If these options have not been set and you already have an entity created, you can adjust the values manually. To create a factory, set the **CreatedByOtherEntities** to **True.**

![](../../../media/2022-01-img\_61ec1b9fbfbf7.png)

Also, your entity type should have a corresponding list, typically in GameScreen. If your entity inherits from another entity, then a list of the base type in the GameScreen is adequate.

![](../../../media/2022-01-img\_61ec1d019c2ae.png)

For more information on how to create lists, see the [List page](../glue-reference/objects/glue-reference-positionedobjectlist.md).

### Adding an Enemy to Tiled using a Tile Layer

The easiest way to add an instance of an entity to a game is by dropping a Tile into your level map. First, we will mark which tile to use for the entity type.

1. Open your map in Tiled
2.  Select the Tileset which has your enemy. Keep in mind that each layer in Tiled can only use one tileset.

    ![](../../../media/2022-01-img\_61ec1dbf6d27f.png)
3.  Click the wrench icon to edit the tileset

    ![](../../../media/2022-01-img\_61ec1e1e6a68e.png)
4.  Select which tile you would like to use for your entity type

    ![](../../../media/2022-01-img\_61ec1e616a3ea.png)
5.  Enter the name of your entity as the \*\*Type. \*\*Capitalization matters, so be sure to match the name as it is written in the FlatRedBall Editor

    ![](../../../media/2022-01-img\_61ec1efa0ab5a.png)
6.  Save your TileSet

    ![](../../../media/2022-01-img\_61ec1fb952cd1.png)

Now you can paint the tiles onto your map and they will automatically be converted into entities when you run your game. [![](../../../media/2020-02-22\_08-18-38.gif)](../../../media/2020-02-22\_08-18-38.gif) &#x20;

### Manually Instantiating Entities in Code

By default maps create entities without any manual code. This setting is controlled by the **Create Entities From Tiles** variable, which is checked by default.

![](../../../media/2022-01-img\_61ec21f2ee3ea.png)

This setting produces the following code:

![](../../../media/2022-01-img\_61ec2335e62e9.png)

Note that this setting is only applied in the base GameScreen, so to turn it off it must be turned off on the Map object in GameScreen (or the base Screen). If it is turned off, you can manually add the code to create entities in your CustomInitialize as shown in the following snippet.

```lang:c#
void CustomInitialize()
{
    FlatRedBall.TileEntities.TileEntityInstantiator.CreateEntitiesFrom(Map1);
}
```

Using either approach will result in the same thing - entities being created from tiles.

### Instantiating Collidable Entities with Tiled Shapes

Entities which implement the ICollidable interface can also be instantiated through Tiled. Any ICollidable entity can be used, but usually entities which will have their collision set by Tiled should not have any collision objects in Glue. To create an empty ICollidable entity:

1. Right-click on the **Entites** folder in Glue
2. Select **Add Entity**
3. Make sure no shapes are checked in the add window
4. Check the **ICollidable** checkbox
5. Leave the defaults for Tiled instantiation
6. Enter a name
7. Click **OK**

![](../../../media/2020-02-img\_5e462a09581e9.png)

To create an instance of this shape in Tiled:

1. Open a TMX file in Tiled
2.  Create or select an Object Layer

    ![](../../../media/2020-02-img\_5e462a5fe7961.png)
3.  Select to insert a rectangle

    ![](../../../media/2020-02-img\_5e462aa2b05fc.png)
4.  Add a rectangle to your level

    ![](../../../media/2020-02-img\_5e462abb5acfc.png)
5.  Set the type of the rectangle to CollidableEntity (or the name of whatever entity you wish to instantiate)

    ![](../../../media/2020-02-img\_5e462af13946c.png)
6. Save the map

CreateEntitiesFrom will now automatically create an instance of the CollidableEntity, and it will use a rectangle as its collision matching the size defined in Tiled.
