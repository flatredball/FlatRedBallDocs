## Introduction

The MoveToAccurate creates a set of [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction.md "FlatRedBall.Instructions.Instruction") for moving a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") to a given point in a set amount of time.

## Code Example

The following code moves a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") to the position where the user clicks the [Mouse](/frb/docs/index.php?title=FlatRedBall.Input.Mouse.md "FlatRedBall.Input.Mouse"). Note that this could be implemented with any PositionedObject, including any Glue entity. Add the following using statements to your Glue screen:

    using FlatRedBall;
    using FlatRedBall.Input;
    using FlatRedBall.Instructions;

Add the following to your screen's CustomInitialize to show the mouse:

     // to show the cursor
     IsMouseVisible = true;

Add the following to your Screen's CustomActivity, assuming SpriteInstance is a Sprite in your Screen:

``` lang:c#
 void CustomActivity()
 {
     // The number of seconds to take to move to where the user
     // clicks.
     float secondsToTake = 2;

     // A button release is a "click".
     // Don't create new movement instructions if there are
     // already other movement instructions - things can get wacky.
     if (InputManager.Mouse.ButtonReleased(
             FlatRedBall.Input.Mouse.MouseButtons.LeftButton) &&
         SpriteInstance.Instructions.Count == 0)
     {
         // We could create the Instructions ourselves, but the
         // InstructionManager makes things easy.
         InstructionManager.MoveToAccurate(SpriteInstance,
             InputManager.Mouse.WorldXAt(SpriteInstance.Z),
             InputManager.Mouse.WorldYAt(SpriteInstance.Z),
             SpriteInstance.Z,
             secondsToTake);
     }
 }
```
