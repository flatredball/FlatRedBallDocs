# IsFixedTimeStep

### Introduction

IsFixedTimeStep controls whether the game attempts to run at a fixed frame rate. If the game runs especially slow, then the frame rate may be reduced or frames may be dropped (this may vary from platform to platform). This property is true by default.

If your game is capable of running at a frame rate faster than specified by the [TargetElapedTime](targetelapsedtime.md) then the Game class delays calling Update and Draw to attempt to match the TargetElapsedTime. If your game is not able to run as quickly, the Game class reduces the number of Draw calls to attempt to allow the Update call to be called more frequently.

### Code Example

IsFixedTimeStep can be set to false to measure your game's frame rate. The following code will enable the game to run as fast as possible rather than being capped to 60 fps or the refresh rate of the monitor:

```csharp
IsFixedTimeStep = false;
graphics.SynchronizeWithVerticalRetrace = false;
```

Changing `graphics.SynchronizeWithVerticalRetrace` after FlatRedBall is initialized requires applying changes to the graphics object:

```csharp
graphics.ApplyChanges();
```

### Cursor behavior

If IsFixedTimeStep is false, then it is possible that your game may run at a very high frame rate. If your game's frame rate is sufficiently high, it may exceed the sampling rate of the mouse on the PC. In this situation, you may receive updates where multiple frames in a row report the same position values. This can be problematic if you are using any of the [Cursor's](../../flatredball/gui/cursor/) Velocity values. You may have many frames where the reported velocity is 0 (due to the position being the same for multiple frames) even if the user is moving the cursor. This is mostly problematic in situations where the Velocity of the Cursor can impact game behavior - such as with logic that performs kinetic scrolling.
