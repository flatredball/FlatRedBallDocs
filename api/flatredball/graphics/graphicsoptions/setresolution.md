# SetResolution

### Introduction

The SetResolution method sets the resolution (number of pixels wide and tall) of your game. This method can be called at any time after FlatRedBall is initialized.

### Code Example

The following code resizes the screen to display a resolution of 320X240.

```
FlatRedBallServices.GraphicsOptions.SetResolution(320, 240);
```

![ResizedWindow.png](../../../../.gitbook/assets/migrated\_media-ResizedWindow.png)

### Changing Resolutions

Resolutions can be changed by calling SetResolution multiple times. For example, the following code allows the user to press the 1 or 2 keys to change between two resolutions:

```
            if (InputManager.Keyboard.KeyPushed(Keys.D1))
            {
                FlatRedBallServices.GraphicsOptions.SetResolution(200, 200);
            }

            if (InputManager.Keyboard.KeyPushed(Keys.D2))
            {
                FlatRedBallServices.GraphicsOptions.SetResolution(500, 500);
            }
```

### Camera behavior when calling SetResolution

By default if SetResolution is called, the Camera will adjust its [DestinationRectangle](../../../../frb/docs/index.php) according to the changed resolution. This automatic adjustment depends on the Camera's [split screen viewport settings](../../../../frb/docs/index.php). For more information, see the [SetSplitScreenViewport page](../../../../frb/docs/index.php).

### Setting resolution to current resolution

One common piece of code that people use (incorrectly) to set the game resolution to the entire display's resolution is:

```
FlatRedBallServices.GraphicsOptions.SetResolution(GraphicsDevice.DisplayMode.Width,
    GraphicsDevice.DisplayMode.Height);
```

While this may seem fine, let's investigate what happens. The SetResolution method sets the resolution to the monitor's width/height; however, it can't actually set it to the full height. The reason for this is because Windows prevents the game window from being much taller than your current resolution. In other words, Windows resizes your game window's height to allow for the title bar and window borders. Here's a screen shot from Visual Studio showing the variables being different: ![ResolutionSettingIssue.png](../../../../.gitbook/assets/migrated\_media-ResolutionSettingIssue.png) Notice that the code above sets the resolution to the GraphicsDevice.DisplayMode.Height which clearly shows up as 768 on my monitor; however, the FlatRedBallServices.GraphicsOptions.ResolutionHeight (stored in a height variable) is only 752. The moral of the story is - when in windowed mode, don't set your resolution to the monitor's full-screen resolution.
