## Introduction

The MoveToScreen method can be used to move from the current Screen to another Screen. The MoveToScreen method will destroy the current Screen and all of its contained Entities, then begin loading the Screen passed to the MoveToScreen method.

## Calling MoveToScreen

MoveToScreen accepts a string which is the fully-qualified name of the Screen you are moving to. The easiest (and safest) way to get the fully qualified name is to use the Type class. For example, if you want to move to a Screen called GameScreen, you would do:

    this.MoveToScreen(typeof(GameScreen).FullName);

**Why do we use "typeof"?** As mentioned above, you can move to a Screen by passing its fully-qualified name. To understand why we use typeof, we need to understand what "fully-qualified" means. First, let's start with a call to MoveToScreen that is not fully qualified:

    this.MoveToScreen("GameScreen");

Fully-qualified means that the namespace is included in the name:

    this.MoveToScreen("YourProject.Screens.GameScreen");

However, what happens if you remove GameScreen, or rename it, or move it to another namespace? The code above would no longer work because the qualified name may have changed to something like "YourProject.Screens.Subfolder.GameScreen"; Using typeof allows us to get the fully qualified name even if it changes...and if the Screen no longer exists you will get a compile error, so you'll know right away instead of having to run the game to find out your code is broken. Very convenient!

## Resetting a Screen

The MoveToScreen function does the following (in order):

1.  Destroys the current Screen
2.  Creates the next screen as specified by the argument to MoveToScreen.

MoveToScreen can be used to move to the same screen rather than a different screen. This results in the current screen being destroyed then recreated, resulting in the screen being reset to its original state. For example, consider a situation where the player's character is hit by a bullet. In this case the GameScreen will reset itself:

    // assuming there is a function to tell us if the player was hit by a bullet
    // This also assumes that this code is written in the GameScreen and not in an entity
    bool wasHitByBullet = GetIfHitByBullet();

    if(wasHitByBullet)
    {
       // GetType returns the GameScreen's type
       this.MoveToScreen(this.GetType());
    }

## MoveToScreen destroys the Screen

When the MoveToScreen method is called, the current Screen will be destroyed and the Screen that you are moving to will be created. The things that are destroyed are:

-   Any files loaded through Glue for the current Screen or any Entities added to the Screen through Glue
-   Any instances of Entities that have been added to Glue

If you have added objects that should be destroyed (such as additional Entities) in your custom code, then you need to make sure to destroy these objects in your CustomInitialize. For more information on whether you need to destroy an Entity or not, and how to destroy Entities which must be destroyed manually, see [the Destroying Entities article](/frb/docs/index.php?title=Glue:Tutorials:Destroying_Entity_Instances "Glue:Tutorials:Destroying Entity Instances").

## "The Screen that was just unloaded did not clean up after itself" Exception

For more information on this error and how to clean it up, see [Glue:Reference:Screens:Cleaning Up Screens](/frb/docs/index.php?title=Glue:Reference:Screens:Cleaning_Up_Screens "Glue:Reference:Screens:Cleaning Up Screens").

## Passing information to new Screens

The MoveToScreen method has only one parameter - the Screen to move to. It does not accept additional parameters. For information on how to pass additional information to new Screens, see the the [Proper Information Access](/frb/docs/index.php?title=Glue:Tutorials:Proper_Information_Access "Glue:Tutorials:Proper Information Access") tutorial.
