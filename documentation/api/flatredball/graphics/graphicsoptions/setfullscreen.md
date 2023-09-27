## Introduction

SetFullScreen sets the game to run in full screen. This function can change the current resolution of the desktop. Graphics cards only support a certain number of resolution configurations. If SetFullScreen is called with a value not supported by the graphics device, an exception will be thrown.

## Code Example

The following code sets the game to run in full screen, using the current display resolution.

``` lang:c#
var displayMode = FlatRedBallServices.GraphicsDevice.DisplayMode;
FlatRedBallServices.GraphicsOptions.SetFullScreen(displayMode.Width, displayMode.Height);
```

       
