# ResolutionRrOrientationChanged

### Introduction

The ResolutionOrOrientationChanged event is an event which is raised whenever the game's resolution or orientation changes. This can happen if:

* The orientation changes (on a mobile or tablet)
* The user docks your game in Windows 8
* The user changes the window resolution - either through a command in the game or by resizing the window

### Code Example

This example assumes a desktop application. It will allow the user to resize a window by dragging the corner/edges. Whenever the user does this the new resolution will be printed to the screen. First, add the following code to your Screen's CustomInitialize:

```
FlatRedBallServices.Game.Window.AllowUserResizing = true;
```

To add the ResolutionOrOrientationChanged event:

1. Open or focus on Glue
2. Right-click on your Screen's Events item
3. Select "Add Event"
4. Verify "Expose an existing event" is selected
5. Use the drop-down to select "ResolutionOrOrientationChanged"
6. Click OK

Next, go back to Visual Studio and open your screen's Event file. If your screen is called "GameScreen" then the event file will be "GameScreen.Event.cs". Add the following code to OnResolutionOrOrientationChanged:

```
int newWidth = FlatRedBallServices.GraphicsOptions.ResolutionWidth;
int newHeight = FlatRedBallServices.GraphicsOptions.ResolutionHeight;

FlatRedBall.Debugging.Debugger.CommandLineWrite(
    "Resolution: " + newWidth +
    ", " + newHeight);
```

![ResolutionOutput.PNG](../../.gitbook/assets/migrated\_media-ResolutionOutput.PNG)
