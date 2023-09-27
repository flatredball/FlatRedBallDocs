## Introduction

The IsFixedTimeStep property controls whether the game attempts to run at a fixed frame rate. If the game runs especially slow, then the frame rate may be reduced or frames may be dropped (this may vary from platform to platform). This property is true by default. If your game is capable of running at a frame rate faster than specified by the [TargetElapedTime](/frb/docs/index.php?title=Microsoft.Xna.Framework.Game.TargetElapsedTime.md "Microsoft.Xna.Framework.Game.TargetElapsedTime") then the Game class will delay calling Update and Draw to attempt to match the [TargetElapsedTime](/frb/docs/index.php?title=Microsoft.Xna.Framework.Game.TargetElapsedTime.md "Microsoft.Xna.Framework.Game.TargetElapsedTime"). If your game is not able to run as quickly, the Game class will reduce the number of Draw calls to attempt to allow the Update call to be called more frequently.

## Code Example

By default the XNA template attempts to run the game at a fixed frame rate. To accomplish this, it may reduce the number of times its Draw method is called so that it can keep its Update method called at a fixed frequency. You can turn this behavior off if you are interested in measuring the performance of your game without any artificial throttling. The following code will enable the game to run as fast as possible rather than being capped to 60 fps or the refresh rate of the monitor: Add the following to the Game Constructor

    IsFixedTimeStep = false;
    graphics.SynchronizeWithVerticalRetrace = false;

If you are going to change graphics.SynchronizeWithVerticalRetrace after FlatRedBall is initialized, then after changing the property you must call

    graphics.ApplyChanges();

## Cursor behavior

If IsFixedTimeStep is false, then it is possible that your game may run at a very high frame rate. If your game's frame rate is sufficiently high, it may exceed the sampling rate of the mouse on the PC. In this situation, you may receive updates where multiple frames in a row report the same position values. This can be problematic if you are using any of the [Cursor's](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.md "FlatRedBall.Gui.Cursor") Velocity values. You may have many frames where the reported velocity is 0 (due to the position being the same for mutliple frames) even if the user is moving the cursor. This is mostly problematic in situations where the Velocity of the Cursor can impact game behavior - such as with logic that performs kinetic scrolling.
