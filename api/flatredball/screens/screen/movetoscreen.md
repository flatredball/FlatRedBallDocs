# MoveToScreen

### Introduction

The MoveToScreen method can be used to move from the current Screen to another Screen. The MoveToScreen method destroys the current Screen and all of its contained Entities, then begin loading the Screen passed to the MoveToScreen method.

MoveToScreen can be called when moving between different types of screens, such as between a TitleScreen and LevelSelectScreen. MoveToScreen should also be used to transition between levels such as moving between Level1 and Level2.

### Calling MoveToScreen

MoveToScreen accepts either the type (preferred if you know it) or the name of the screen. The screen name may be fully qualified (such as "YourGame.Screens.Level2") or not fully qualified (such as "Level2"). For example, to move to Level 2, the following code would be used:

```csharp
this.MoveToScreen(typeof(Level2));
```

Alternatively, you could pass in the name of Level2:

```csharp
this.MoveToScreen("YourProject.Screens.Level2");
```

You can go to the level if it is not fully qualified. This works too:

```csharp
this.MoveToScreen("Level2");
```

### Resetting a Screen

The `MoveToScreen` function does the following (in order):

1. Destroys the current Screen
2. Creates the next screen as specified by the argument to `MoveToScreen`.

`MoveToScreen` can be used to move to the same screen rather than a different screen. This results in the current screen being destroyed then recreated, resulting in the screen being reset to its original state. For example, consider a situation where the player's character is hit by a bullet. In this case the GameScreen will reset itself:

```csharp
// assuming there is a function to tell us if the player was hit by a bullet
// This also assumes that this code is written in the GameScreen and not in an entity
bool wasHitByBullet = GetIfHitByBullet();

if(wasHitByBullet)
{
   // GetType returns the GameScreen's type
   this.MoveToScreen(this.GetType());
}
```

### MoveToScreen Destroys the Screen

When the MoveToScreen method is called, the current Screen will be destroyed and the Screen that you are moving to will be created. The things that are destroyed are:

* Any files loaded through Glue for the current Screen or any Entities added to the Screen through Glue
* Any instances of Entities that have been added to Glue

If you have added objects that should be destroyed (such as additional Entities) in your custom code, then you need to make sure to destroy these objects in your CustomInitialize. For more information on whether you need to destroy an Entity or not, and how to destroy Entities which must be destroyed manually, see [the Destroying Entities article](../../../../frb/docs/index.php).

### "The Screen that was just unloaded did not clean up after itself" Exception

For more information on this error and how to clean it up, see [Cleaning Up Screens](../../../glue-runtime-api/glue-reference-screens-cleaning-up-screens.md).

### Passing information to new Screens

The MoveToScreen method has only one parameter - the Screen to move to. It does not accept additional parameters. For information on how to pass additional information to new Screens, see the the [Proper Information Access](../../../../frb/docs/index.php) tutorial.
