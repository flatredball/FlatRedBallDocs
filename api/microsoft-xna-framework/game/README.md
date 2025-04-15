# Game

### Introduction

The Game class (usually called Game1) contains the functions for:

* Initialize - setting up all game systems so FlatRedBall can run
* Update - performs every-frame logic
* Draw - performs drawing, displaying all visual objects in the game window



### Accessing Game

The Game class holds many useful methods and properties which are often needed deep inside game logic code where the Game reference is not available. [FlatRedBallServices ](../../flatredball/flatredballservices/)provides a reference to the game class:

```csharp
FlatRedBallServices.Game
```

For example, to view the mouse cursor (as shown below) outside of the game class, you would use the following code:

```csharp
FlatRedBallServices.Game.IsMouseVisible = true;
```

Since FlatRedBallServices is static this can be used anywhere in code.

### Call Order

All calls cascade from the three game calls. The following tables show how calls occur in each frame.

#### Initialize

* GeneratedInitializeEarly
  * Add FrameworkElementManager to Managers list
* FlatRedBallServices.InitializeFlatRedBall
* GeneratedInitialize
  * Gum internal system events assigned
  * Initialize Glue communication
  * Initialize Camera from FRB Editor Resolution Settings
  * Assign internal FRB events like size or orientation changed
  * Start the screen

#### Update

* FlatRedBallServices.Update
  * TimeManager.Update - update current timing values
  * InputManager.Update - read input from hardware
  * InstructionManager.Update - execute instructions
  * Manager Updates (ShapeManager, SpriteManager, TextManager, AudioManager)
    * Execute specific type instructions, such as instructions on Sprites
    * PositionedObject TimedActivity
      * Update Position, Velocity, Rotation, and Relative Position, Velocity, and Rotation
  * GuiManager logic (process UI events)
  * TimeManaer.DoTaskLogic (process `async` calls)
* ScreenManager.Activity
  * CurrentScreen.Activity (generated)
    * Update Gum Animations
    * Entity Activity (generated)
      * Inner entity Activity (generated)
      * TopDown/Platformer input logic (generated)
      * TopDown/Platformer animation logic (generated)
      * base.Activity (generated)
      * CustomActivity
    * CustomActivity
  * CurrentScreen.Destroy (if valid)
* GeneratedUpdate
  * Empty - may be used in the future

#### Draw

### Exiting

The Exit method ends the application. This can be called to exit the game as follows: If inside the Game class:

```csharp
this.Exit();
```

If the Game class is not in scope:

```csharp
FlatRedBallServices.Game.Exit();
```

This can be called at any point and your game will exit properly.

### Disabling Fixed Time Step

For more information, see the [IsFixedTimeStep](isfixedtimestep.md) page.

### Additional Information

* [Resizing the Game Window for Tools](../../../frb/docs/index.php)
* [Information about the GameWindow](../../../frb/docs/index.php)
* [Game Window as a Control](../../../frb/docs/index.php) - FlatRedBallService's Owner property returns the game window as a Control which provides more functionality.
