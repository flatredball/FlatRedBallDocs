One of the most common task in game development is stopping a game to make small changes, then restarting the game. Of course, doing this just one time is a fast process, but over the course of an entire game this can add up. The latest version of Glue focuses on speeding up the stop/tweak/restart cycle. This version introduces two big features:

1.  Hot-reload of the project
2.  Communication between Glue and the game

## Hot Reload

Glue can now automatically stop, rebuild, and restart a game when it detects a change. Glue will automatically watch for changes and will restart a game as long as the game was launched through Glue. Just click play here...

![](/media/2019-11-img_5dd6291e5df0d.png)

...or here...

![](/media/2019-11-img_5dd62968a82a0.png)

...and hot reload will be enabled:

![](/media/2019-11-img_5dd629b46fa3b.png)

While hot reload is enabled, Glue will watch for any changes to your project. If it detects a change, the project will be stopped, rebuilt, and re-launched. [![](/wp-content/uploads/2019/11/kG6hvklZUo.gif.md)](/wp-content/uploads/2019/11/kG6hvklZUo.gif.md) The game will even relaunch but not steal focus, so you can make changes in Visual Studio, save your file, and continue coding while the game compiles and re-launches! [![](/wp-content/uploads/2019/11/cN3NMjUWBD.gif.md)](/wp-content/uploads/2019/11/cN3NMjUWBD.gif.md) Changing a file referenced by your project will also result in the game reloading. For example, TMX files can be changed in Tiled. [![](/wp-content/uploads/2019/11/Rrtnku7STP.gif.md)](/wp-content/uploads/2019/11/Rrtnku7STP.gif.md) Glue will reload the project if any of the following change:

-   Variables changed in Glue
-   New screens or entities added in Glue
-   New object instances added to a Screen or Entity
-   Custom code changed (if coding in Visual Studio, for example)
-   File changes such as a changed TMX, PNG, or ACHX

As the next section shows, Glue can also inject code into a game project to enhance hot reload and other debugging functionality.

## Glue and Game Communication

The latest version of Glue introduces runtime communication between Glue and Game projects. Glue can use a TCP connection to connect to a running game and send commands. This functionality can be enabled by checking the **Generate GlueControlManager in Game1** checkbox.

![](/media/2019-11-img_5dd8aca39f110.png)

Once enabled, Glue will attempt to connect to the game if it launches your game. You may see a Windows Security Alert indicating that your game is opening a TCP port. Click **Allow access** to enable communication.

![](/media/2019-11-img_5dd8abcc120d8.png)

Once enabled, Glue will have extra control over your game.

### Play/Pause

Glue can send Pause commands to your game, which will internally call the FlatRedBall Pause function. Once paused, the game can be un-paused by pressing the play button. [![](/wp-content/uploads/2019/11/6Bmuy0rlIH.gif.md)](/wp-content/uploads/2019/11/6Bmuy0rlIH.gif.md)

### Advance One Frame

Once paused, Glue can advance the game by one frame at a time. Internally this sends an un-pause command, lets the game run for one frame, then pauses the game once again. [![](/wp-content/uploads/2019/11/Au5ZSOPx4M.gif.md)](/wp-content/uploads/2019/11/Au5ZSOPx4M.gif.md)

### Fast Forward and Slow Motion

You can change the speed of the game through Glue, from as slow as 10% to as fast as 500% speed. [![](/wp-content/uploads/2019/11/iXhCBDBXsG.gif.md)](/wp-content/uploads/2019/11/iXhCBDBXsG.gif.md)

### Restart Current Screen

The red restart icon will stop the game, rebuild it, and restart the game on the same screen. This command is useful if you need to restart the game, but do not want to navigate through menus or levels to continue testing the same part of the game. If rebuilding/restarting the game is not required, the green restart icon will send a command to the game to restart the current screen. [![](/wp-content/uploads/2019/11/orgeVh23yp.gif.md)](/wp-content/uploads/2019/11/orgeVh23yp.gif.md) The functionality of restarting on the same screen will automatically be used if hot reload is enabled, making iteration even faster compared to restarting a game from the first screen.

### Future Changes

Communication between Glue and the game at runtime opens the door for many future improvements. Later versions of Glue will include more functionality to speed up iteration and debugging, so stay tuned!  
