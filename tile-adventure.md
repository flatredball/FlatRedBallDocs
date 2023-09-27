## Introduction

The Tile Adventure starter project provides a working example of using the Tiled plugin to create a multi-level top-down game. [![TileAdventureGif1](/wp-content/uploads/2017/01/TileAdventureGif1.gif)](/wp-content/uploads/2017/01/TileAdventureGif1.gif) Much of the game's data is defined in the tiled levels that are added to the GameSceen.

![](/media/2017-01-img_587a26a9f2063.png)

The Tiled Plugin must be installed to open this project.

![](/media/2017-01-img_587a273213f2f.png)

To install this plugin, visit the [Tiled Plugin page on Glue Vault](http://www.gluevault.com/plug/94-tiled-plugin).

## Viewing Levels in Tiled

The .tmx extension is the native file format for the Tiled program. Tiled can be downloaded on the [Tiled website](http://www.mapeditor.org/). Once Tiled is installed, levels can be edited by double-clicking on a .tmx file in Glue.

![](/media/2017-01-img_587a2f57c25e0.png)

The levels in Tiled look similar to levels in the game, except that levels also include a few extra objects in the Objects layer to provide navigation logic.

![](/media/2017-01-img_587a3023074d5.png)

Editing levels in Tiled is as easy as selecting a tile and painting it on the level. Before editing, keep in mind that tiles are not just visual but are also used in the game's logic (collision, NPCs that talk, navigating to other levels). To support this functionality, levels in Tile Adventure use a number of conventions which should be followed. Levels in Tile Adventure include four layers:

1.  Objects - Used to create unique entities, such as NPCs with dialog or doors which take the user to a particular level.
2.  Obstacles - Tiles which are drawn on top of the terrain (such as trees and fences) which create collision at runtime.
3.  GroundDecoration - Tiles purely placed for decoration, which do not create collision.
4.  Ground - The bottom-most layer, defining the level's structure. These tiles may create collision.

Note that there's nothing in the Tiled plugin or in our code which require these layers - the levels use this standard to stay organized. For example, placing a tree tile on the GroundDecoration layer will result in collision - the tiles define behavior, not the layers.

## Editing GroundDecoration

The GroundDecoration layer contains tiles which are not functional (no collision, no entities created), but which are used purely for decoration. These include grass, flowers, and animated water tiles. To add decoration:

1.  Select the **GroundDecoration** layer

2.  Select a decoration tile, such as the flower tile

3.  Paint the decoration on the tile map

    ![](/media/2017-01-img_587aeb9c06d46.png)

4.  Save the map

5.  Run the game

Changes will automatically appear in game (no code changes required).

![](/media/2017-01-img_587aecb371905.png)

## Editing Collidable Tiles

Some tiles in the tileset are collidable. These tiles use the standard HasCollision property.

![](/media/2017-01-img_587af02113160.png)

Tiles with HasCollision can be painted on any layer and the game will create collisions. The game uses the convention of placing collidable tiles in the **Ground** and **Obstacles** layers. Collisions can be seen when running the game by setting the **ShowShapes** variable in the **DebuggingVariables** entity.

![](/media/2017-01-img_587af3b514621.png)

Running the game with **ShowShapes** checked will display collisions.

![](/media/2017-01-img_587af44f57b0c.png)

## Placing Entities

Entity instances can be placed in a map through tiled. For example, **Level1.tmx** contains an instance of the **Character** entity - the girl in the house on the right side of the map. This entity is placed on the Objects layer, which is an **object layer**. Objects in Tiled allow the creation of entities with custom properties. Properties added to objects which have the **EntityToCreate** property will be assigned to the resulting instance. We can see the properties on the girl **Character** instance:

1.  Select the **Objects** layer
2.  Select the **Select Objects** tool
3.  Select the Girl entity

![](/media/2017-01-img_587b02547b9cc.png)

Although the object in Tiled is the Girl image, the appearance of the object does not matter - only its properties.

### EntityToCreate

The EntityToCreate tells the game logic that this object (which by default would be a simple tile) should be replaced with an entity instance. The following must be set for entities to be created in .tmx files:

1.  The EntityToCreate property must match an Entity in the Glue project

    ![](/media/2017-01-img_587b0df16d28e.png)

2.  The Entity in Glue must have its **CreatedByOtherEntities** property set to **true**.

    ![](/media/2017-01-img_587b0e4657686.png)

3.  The **GameScreen** must have a list of the entity type.

    ![](/media/2017-01-img_587b0e9cf4143.png)

4.  The TileEntityInstantiator.CreateEntitiesFrom  method must be called (more information on this below).

### Animation

Character instances can set their animation in the .tmx file. The character object in Level1 sets its **Animation** property to **GirlAnimations**.

![](/media/2017-01-img_587b103ca62b1.png)

Animations shows that properties on instances can be assigned through tiles, as long as the variable names match up. Tiled properties will be set on an entity if either the entity has a matching variable defined in Glue or if the custom code for the entity defines a matching property. In the case of the Character entity, the Animation property is defined in custom code.

``` lang:c#
public string Animation
{
    set
    {
        var file = GetFile(value) as AnimationChainList;

        this.SpriteInstance.AnimationChains = file;
    }
}
```

The Character contains three animation files (.achx):

1.  BoyAnimations.achx
2.  GhostAnimations.achx
3.  GirlAnimations.achx

These animations can be referenced by Character entities defined in Tiled (without the extension), and new animations can be created and added to the Character entity to be referenced by Tiled objects. For information on creating and editing animations, see the [Animation Editor page](/documentation/tools/animationeditor/glue-gluevault-component-pages-animationeditor-plugin.md).

### Dialog

The dialog property is a key in the **GameText.csv**. The CSV file defines all of the game's dialog. The first column is the name of a line of dialog (**ID**), the second column is the text that the ID represents (**Text**).

![](/media/2017-01-img_587bc3b07a825.png)

Although the game could put the dialog directly on the tile in Tiled, using a separate CSV provides a number of benefits:

-   Editing long text can be easier in a CSV rather than a property grid in Tiled.
-   Using CSVs for text simplifies localization (adding additional languages to your game)
-   CSVs are the standard approach for storing game text, and can be accessed by Tiled entities or other non-tiled entities.
-   Seeing all text in one place can make it easier to maintain dialog - especially lengthy in-game conversations.

Once text has been changed, it will show up in game.

![](/media/2017-01-img_587bc6d413d19.png)

![](/media/2017-01-img_587bc6f58e192.png)

The example above shows how to modify existing text entries, but new entries can be added to the CSV, then referenced on any Character instance.

## Multiple Levels vs. Multiple Screens

Tile Adventure includes multiple level files (**Level1.tmx** and **Level2.tmx**) in a single screen (**GameScreen**).

![](/media/2019-07-img_5d3713f84a055.png)

This setup requires a little bit of work up-front, but is easier to maintain as additional levels are created. Note that adding multiple TMX files to a single screen is one for creating a game with multiple maps. Another common approach is to create one Glue screen per TMX file, as explained in [this blog post](/news/derived-screens-as-a-levels.md). The approach used here is useful if you expect your game to have a large number of maps. For example, an RPG such as Final Fantasy II (IV in Japan) may include hundreds of levels:

-   One map per overworld (main world, underground, moon)
-   One for each town
-   One for each building interior
-   One for each floor and separate of every dungeon and castle

![](http://2.bp.blogspot.com/-gXNaEciN9GA/UTBE19RydDI/AAAAAAAAc_4/zSUMxmo2tA8/s1600/Final_Fantasy_IV_(SNES)_10.png) Typically a game will only display one map (TMX) at a time. By default TMX files will be automatically loaded, so we need to suppress this by setting the **LoadedOnlyWhenReferenced** value **true**.

![](/media/2017-01-img_587a2d7f1fa31.png)

The **LoadedOnlyWhenReferenced** property indicates that the TMX file will not be loaded automatically, but must instead be referenced by the game's custom code before it is loaded. This means that the **GameScreen** can contain any number of **.tmx** levels, but only files referenced in code will be loaded. Even a larger game with dozens of TMX files would only load one at a time (assuming all have their **LoadedOnlyWhenReferenced** set to true). For information about how the TMX files are referenced and used in code, see the **Loading Levels in Code** section below.

## Navigating Using MapNavigationTrigger and StartPoint

The **MapNavigationTrigger** and **StartPoint** entities are used to perform navigation between different levels in Tile Adventure. The **MapNavigationTrigger** is used to mark a tile which will navigate the user to another map. The **StartPoint** defines where on the map to appear. The **StartPoint** is important so that the player begins near the entrance of a map rather than at a random point in the map. **Level1.tmx** has a single **MapNavigationTrigger** entity, which is associated with the object tile that looks like a white door.

![](/media/2017-01-img_587bd16fa0a0f.png)

The properties on the tile provide the following information:

-   EntityToCreate - This tells the code to create an instance of the MapNavigationTrigger entity

-   TargetMap - This tells the code which map to load when the user collides with the MapNavigationTrigger. This should match the name of a map in the GameScreen.

-   StartPointName - The name of the StartPoint (Entrance) in the target map (Level2)

    ![](/media/2017-01-img_587bd3fbd4b37.png)

## Navigation Code

The entities use for navigation require custom code to function. GameScreen has two static fields which are used to load the level and place the character in the proper location.

``` lang:c#
public partial class GameScreen
{
    static string levelToLoad = "Level1";
    static string startPointName = "BottomOfTown";
    ...
```

The levelToLoad  field is used in LoadLevel , which in turn calls InitializeLevel  (which is discussed below).

``` lang:c#
void LoadLevel(string levelToLoad)
{
    InitializeLevel(levelToLoad);
    AdjustCamera();
    AdjustNpcs();

    ...
```

The levelToLoad  and startPointName  fields are assigned in the CollisionActivity  method.

``` lang:c#
private void CollisionActivity()
{
    foreach(var trigger in MapNavigationTriggerList)
    {
        if(CharacterInstance.BackwardCollision.CollideAgainst(trigger.Collision))
        {
            levelToLoad = trigger.TargetMap;
            startPointName = trigger.StartPointName;
            ...
```

The startPointName  field is used to position the character in the InitializeCharacter  method.

``` lang:c#
private void InitializeCharacter()
{
    var foundStartPoint = this.StartPointList.FirstOrDefault(item => item.Name == startPointName);
    if(foundStartPoint == null)
    {
        throw new Exception($"Could not find start point with a name of {startPointName}");
    }
    this.CharacterInstance.X = foundStartPoint.X;
    this.CharacterInstance.Y = foundStartPoint.Y;
    ...
```

## InitializeLevel vs. Custom Code

Tile Adventure uses the InitializeMethod which is generated automatically in any screen containing a .tmx. This method uses standard conventions to create a level using a .tmx file. The following functionality is provided by the InitializeLevel function:

-   It takes an argument TMX name (without extension or path), loads the tmx, and assigns the CurrentTileMap field, which is also generated automatically.
-   It assigns the Camera min and max X/Y values according to the loaded map's bounds
-   It populates the **SolidCollisions** object with tiles that have the **HasCollision** property set to **true** (as shown above).
-   Entities are created using the EntityToCreate property, as shown above.

This method simplifies creating levels from Tiled, but limits projects to a single shape collection. More complicated games may need multiple types of collision, such as one ShapeCollection for solid collision, one for collision which slows the player down.

## Loading Levels in Code

As mentioned earlier, each TMX file is marked with **LoadedOnlyWhenReferenced** which means it won't be loaded until it is referenced in code. The code references (and loads) files in a funcion called LoadLevel . This function takes a single parameter, which is the name of the level. It then calls InitializeLevel  which access the Glue file using the GetFile method. Keep in mind that InitializeLevel  is simple to use, but does not offer much flexibility. More advanced games may need to create their own level loading code. Feel free to copy the generated code into your custom code as a starting point if you need to expand this method.
