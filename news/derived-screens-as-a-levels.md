# derived-screens-as-a-levels

The latest version of FlatRedBall, Glue, and the Tiled plugin include features to support a new approach for creating levels - using derived screens. Screen inheritance has been available in Glue for many years, but the latest set of features revive this functionality and make level creation easier than ever.

### Old vs. New

Levels are a core concept in game development. Old and new games alike use levels to provide variety, control progression, represent a large world, and tell a story. In FlatRedBall, levels are often tied to TMX files (the native tile map format in Tiled). The old recommended approach for creating and managing levels (as documented in the old Tiled tutorial) was to create a single screen for gameplay and to include multiple TMX files.

![](../media/2018-09-img\_5b9ebe74379cd.png)

Of course the game shouldn't load every level in the Levels folder, so the **LoadedOnlyWhenReferenced** property was used to only load one file at a time, and custom code was necessary to then load a level depending on some logic, such as a current CSV row or a static CurrentScreen variable. The new approach uses a base screen for common files, objects, and logic. Additional screens (level screens) can be created, inheriting from the base screen, as shown in the following image.

![](../media/2018-09-img\_5b9ec07f2fad8.png)

Even in this simple scenario we can see some benefits:

* Each TMX file can be left as-is. They do not need to have the **LoadedOnlyWhenReferenced** property set to true.
* No custom code is needed to load, display, and destroy the current level. Each screen already has generated for this functionality.
* Setting the **StartUp Screen** results in the selected screen (level) being shown when the game starts. This means that testing new levels does not require any custom code, or code modifications.

### Benefits to Larger Games

As games get larger we see even more benefits to using derived screens for levels.

* Files which are supported either natively (such as music) or through plugins (such as Gum screens) "just work". No additional code is necessary to optionally load files depending on the current screen.
* Moving between levels uses the familiar MoveToScreen  syntax, just like moving between non-level screens (such as menus).
* Objects which can be displayed by GlueView (such as entities) can be shown in GlueView. The old level structure, which would load/create objects in custom code, prevented GlueView from showing levels.
* Level-specific code can be added in the .cs files for each level, rather than requiring large if/switch blocks or a custom component system.
* (To be implemented in the future) entire levels including TMX files and their created entities can be previewed in GlueView.

### Improvements to Glue and Tiled Plugin

This approach to creating levels is now easier to apply than before thanks to a number of changes in Glue and the Tiled Plugin.

#### Create Derived (Level) Screen

The right-click menu on screens now includes an option to create a derived level screen.

![](../media/2018-09-img\_5b9ec2a6cb224.png)

This menu option removes some steps (and possible errors) from the old process of creating a screen then assigning the base screen after-the-fact.

#### Unqualified MoveToScreen

Previously calling the MoveToScreen method requires a fully-qualified screen name. Now the screen name without namespace can be used:

```lang:c#
// We can use a constant and move to a screen without specifying the namespace:
if(shouldMoveToScreen)
{
    MoveToScreen("Level2");
}
```

This change allows entities which control level navigation to specify the level without full qualification. For example, a Door entity in Tiled could simply include the level without namespace. [![](../media/2018-09-img\_5b9e5b145d021.png)](../media/2018-09-img\_5b9e5b145d021.png) This property can be checked and used in a custom collision handler.

```lang:c#
private void HandlePlayerVsDoorCollision(Player player, Door door)
{
    MoveToScreen(door.LevelToGoTo);
}
```

Qualified names can still be used, so existing code will not be impacted by this change.

### Additional Information

This new approach has been applied to a re-written set of tutorials for creating projects using Tiled. For more information on how to use this new approach, see the [Tiled Tutorial](../documentation/tools/tiled-plugin/using-the-tiled-plugin.md). &#x20;
