## Introduction

In the previous tutorial we covered how to create entities from tiles. This approach can simplify entity creation, and works great for entities which are uniform (each instance is identical aside from position). Some entities require custom properties per-instance. For example, consider a game where players can walk through doors to enter other maps. In this case, each door entity needs to have a custom property for which level it links to. This walk-through shows how to create object layers in Tiled and how to create entities using these objects.

## Creating a New Entity

For this tutorial we will be creating a Door entity which can be used to move the player from one level to the next. This entity will need to have collision so that the player can collide with it and we can respond to the collision. To create a Door entity:

1.  Select the Quick Actions tab in the FRB editor

2.  Click **Add Entity**

3.  Enter the name **Door**

4.  Check the **Circle** check box

5.  Leave the defaults and click ****OK****

    ![](/media/2021-02-img_60317ec745a4f.png)

Now you will have a Door entity in Glue. We should change the color of the door so it doesn't look like the player (which is currently a white circle). To do this, change the CircleInstance's Color value to Green.

![](/media/2021-02-img_603182a0c63da.png)

We need to create a variable for which level to load when the Player collides with the Door:

1.  Right-click on the **Variables** folder under the **Door** entity

2.  Select ****Add Variable****

    ![](/media/2018-04-img_5adba32cc76c8.png)

3.  Select the **Create a new variable **option

4.  Select **string** as the **Type**

5.  Enter the Name **LevelToGoTo**

    ![](/media/2021-02-img_60317f1d72e36.png)

6.  Click **OK**

The name of the variable that we created (LevelToGoTo) needs to match the name of the property that we will be adding to the tile later in this guide. Note that if using a entity types XML, the property will automatically be added.

## Creating an object layer

Tiled object layers allow placing geometric shapes (such as rectangles, circles, and custom polygons) as well as free-floating images (not snapped to the grid). These images (also referred to as "tiles" in the Tiled program) can be used purely for non-interactive visuals or can be used to place entities. Objects can be created and added to tile maps, where each instance has all of its properties set individually, or objects can be given default properties in the tileset. First we'll set up the common properties on our Door tile:

1.  Open **TiledIcons.tsx** in Tiled (click the edit button if the tsx file is not already open)

2.  Select the door tile

3.  Enter **Door** as the **Type. **Note that this may already be the default.

    ![](/media/2021-02-img_60317fcf1bad9.png)

4.  Click the + button to add a new property

    ![](/media/2018-09-img_5b9d8c89e1e1b.png)

5.  Enter the name **LevelToGoTo**

6.  Verify the type is **string**

    ![](/media/2018-09-img_5b9d8cad0c40b.png)

We won't assign the value of LevelToGo yet, we'll do that per-instance. Now that we've defined the Door tile properties, we'll add a Door to the Level2Map.tmx file. Don't forget to save your tileset in Tiled. First we'll make an object layer:

1.  Open **Level2Map.tmx** in Tiled

2.  Click the Add Layer button

3.  Select **Object Layer**

    ![](/media/2021-02-img_6031801922e67.png)

4.  Name the new layer **GameplayObjectLayer**

    ![](/media/2021-02-img_60318041b1a31.png)

Next we'll add an instance of the door to the **EntityObjectLayer**:

1.  Verify that **EntityObjectLayer** is selected

2.  Select the tile to be placed in the tile set

3.  Click on the tile map to place the tile. Be careful - if you place the door in the same place as where the player starts, the player will immediately collide with the door, and will move to the next level once we add the collision code.

    ![](/media/2021-02-img_603180d6e1b28.png)

Notice that the placed door may not align with the tiles. If you wish to make it align, you use the Select Objects command to select the tile and either move it visually or change its X an Y properties:

![](/media/2021-02-img_603181115c5dd.png)

Alternatively, holding the CTRL key will snap objects to the grid while you place them. Now we can add the LevelToGoTo property to our placed tile:

1.  Click the **Select Objects** button (if not already selected)

    ![](/media/2018-09-img_5b9e5a7eab252.png)

2.  Select the placed Door object (if not already selected)

3.  Enter the value **Level1** for the **LevelToGoTo** property. More generally, the door's **LevelToGoTo** property should be the name of the screen that we want to go to when the Player entity touches the Door.

    ![](/media/2021-02-img_603181812afb8.png)

Don't forget to save the tile map.

## Verifying the Door Entity

If we run our game now, we should see the Door tile that we placed in Tile replaced by a green circle, which is the collision of the Door entity:

![](/media/2021-02-img_603182c1e11ce.png)

### Troubleshooting Entities Not Created

If you are not seeing the Door entity in the game, there may be a problem with the Tiled map, the inheritance in your game, or settings on the entity. Fortunately, the process that FlatRedBall uses to create entities on object layers is the same as the process for creating entities on tile layers. Therefore, to troubleshoot the problem you should go back to the [previous tutorial](/documentation/tools/tiled-plugin/using-the-tiled-plugin/06-creating-entities-from-tiles.md) and see if you can create entities from tiles. The previous tutorial also includes troubleshooting steps.

## Colliding Against the Door Entity

We can use the Door entity to navigate between levels. We'll check collision between the Player  and all doors in the DoorList  object (our game only has one door, but it could be expanded to have more). If a collision occurs, we'll go to the level set by the Door's LevelToGoTo variable. First we'll create a collision relationship between the PlayerList and DoorList in our GameScreen:

1.  Expand the GameScreen Objects folder in Glue
2.  Drag the PlayerList onto the DoorList to create a CollisionRelationship

[![](/wp-content/uploads/2016/08/2021_February_20_145845.gif)](/wp-content/uploads/2016/08/2021_February_20_145845.gif)

``` lang:c#
```

This time we won't change the **Collision Physics** because the purpose of the door isn't to block the movement of the player. Instead, we'll create an event which will contain code to move to a different level. To do this:

1.  Scroll down to the bottom of the Collision tab of the newly-created CollisionRelationship

2.  Click the **Add Event** button ![](/media/2021-02-img_6031845777e87.png)

3.  Leave the defaults on the **New Event** window and click ****OK****

    ![](/media/2021-02-img_60318490d6824.png)

Collision events are added to the Events file for the current screen. In this case, the events are added to GameScreen.Events.cs. To add handle the code:

1.  Open the project in Visual Studio

2.  Open **GameScreen.Event.cs**. Notice that the newly created collision event will be located under the GameScreen.cs file

    ![](/media/2021-02-img_603185bb3e375.png)

3.  Enter the code to move to a screen based on the Door's LevelToGoTo

&nbsp;

    void OnPlayerListVsDoorListCollisionOccurred (Entities.Player first, Entities.Door second)
    {
      MoveToScreen(second.LevelToGoTo);
    }

Now when the player collides with the door in Level2, the game will move to Level1. [![](/wp-content/uploads/2016/08/2021_February_20_155400.gif)](/wp-content/uploads/2016/08/2021_February_20_155400.gif)

## Conclusion

Now that we've covered object layers, you can create entities which are either all identical on tile layers or which have custom properties. Here's some things to try next:

-   Add a door in Level1 which goes back to Level2. Remember, you don't have to set up the CollisionRelationship again. It's already set up in GameScreen which covers all levels.
-   Try adding collision between the player and monsters. On collision, you can handle the event by restarting the screen (indicating the player has died)
