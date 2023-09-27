## Introduction

The PauseThisScreen method is a method available to all Screens. The PauseThisScreen method calls [PauseEngine](/frb/docs/index.php?title=FlatRedBall.Instructions.InstructionManager.PauseEngine.md "FlatRedBall.Instructions.InstructionManager.PauseEngine") and also sets the IsPaused property to true. This is a handy simple way to pause the game. To unpause the game, use [UnpauseThisScreen](/frb/docs/index.php?title=Glue:Reference:Screens:UnpauseThisScreen&action=edit&redlink=1.md "Glue:Reference:Screens:UnpauseThisScreen (page does not exist)").

## Code Example

The following code toggles pausing when the space key is pressed. It assumes that it is executed every frame (added to CustomActivity).

    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        if(this.IsPaused)
        {
            UnpauseThisScreen();
        }
        else
        {
            PauseThisScreen();
        }
    }

 

## PauseThisScreen pauses Entities

If a Screen is paused then all contained Entities will also be paused. This includes Entities that have been directly added through Glue, or Entities that belong to PositionedObjectLists that have been added through Glue. Paused Entities will not have Engine behavior applied (velocity), will not have CustomActivity called, and will not be clickable. Entities (and other objects) which are added to Screens can ignore pausing if their [IgnoresPausing](/frb/docs/index.php?title=Glue:Reference:Objects:IgnoresPausing.md "Glue:Reference:Objects:IgnoresPausing") property is set to true.

## PauseThisScreen and Screen CustomActivity

A Paused screen will still have its CustomActivity code called.