# game

### Introduction

Base class for class used in default XNA Template and FlatRedBall XNA Template.

### Accessing Game

The Game class holds many useful methods and properties which are often needed deep inside game logic code where the Game reference is not available. The [FlatRedBallServices class](../../../../frb/docs/index.php) provides a reference to the game class:

```
FlatRedBallServices.Game
```

For example, to view the mouse cursor (as shown below) outside of the game class, you would use the following code:

```
FlatRedBallServices.Game.IsMouseVisible = true;
```

Since FlatRedBallServices is static this can be used anywhere in code.

### Setting Resolution

The resolution of FlatRedBall is controlled through the [GraphicsOptions object](../../../../frb/docs/index.php). For more informatin, see the [GraphicsOptions page.](../../../../frb/docs/index.php)

### Resizing

FlatRedBall will attempt to react to the window changing as a result of the user grabbing and dragging the corners or edges. The following code can be called in the Game class to enable resizing:

```
this.Window.AllowUserResizing = true;
```

### Setting Fullscreen

FlatRedBall applications can run in full screen mode. The following code (which must be called after FlatRedBall is initialized) will set the FlatRedBall application to run at full screen.

```
int desiredWidth = 640;
int desiredHeight = 480;
FlatRedBallServices.GraphicsOptions.SetFullScreen(desiredWidth, desiredHeight);
```

#### Fullscreen vs. Maximized

When FlatRedBall is in fullscreen mode, it "owns" the graphics device. This means that nothing else will be drawing underneath the Window. This can improve performance, but also makes alt-tabbing slower, and now other Windows can be drawn on top of the Window. For this code to work, you must include a reference to the System.Windows.Forms library in your project's References folder. You can sacrifice performance for this convenience by simply maximizing the game as follows: Add the following using statement:

```
using System.Windows.Forms;
```

Add the following to Initialize after initializing FlatRedBall:

```
Form ownerAsForm = FlatRedBallServices.Owner as Form;
ownerAsForm.FormBorderStyle = FormBorderStyle.None;

FlatRedBallServices.GraphicsOptions.SetResolution(
    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
```

### Exiting

The Exit method ends the application. This can be called to exit the game as follows: If inside the Game class:

```
this.Exit();
```

If the Game class is not in scope:

```
FlatRedBallServices.Game.Exit();
```

This can be called at any point and your game will exit properly.

### Disabling Fixed Time Step

For more information, see the [IsFixedTimeStep](isfixedtimestep.md) page.

### Additional Information

* [Resizing the Game Window for Tools](../../../../frb/docs/index.php)
* [Information about the GameWindow](../../../../frb/docs/index.php)
* [Game Window as a Control](../../../../frb/docs/index.php) - FlatRedBallService's Owner property returns the game window as a Control which provides more functionality.

### Game Members

* [Microsoft.Xna.Framework.Game.IsActive](../../../../frb/docs/index.php)
* [Microsoft.Xna.Framework.Game.IsFixedTimeStep](../../../../frb/docs/index.php)
* [Microsoft.Xna.Framework.Game.IsMouseVisible](../../../../frb/docs/index.php)
* [Microsoft.Xna.Framework.Game.TargetElapsedTime](../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../frb/forum.md) for a rapid response.
