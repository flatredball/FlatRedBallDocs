## Introduction

The Camera Settings (also known as Display Settings) in Glue allows you to set your Camera and resolution project-wide. To access the settings click the camera icon.

![](/media/2022-12-img_639a5e39a39d6.png)

Clicking the **Settings**-\> **Camera Settings** menu item brings up the same menu as well.

![](/media/2020-04-img_5e86035ed6651.png)

This will bring up the Display Settings window.

![](/media/2022-12-img_639a5e763ecab.png)

## Camera and Resolution Variables

### Is 2D

The "Is2D" property will control whether the camera is in 2D mode or 3D mode. In 2D mode, your screen will use pixel coordinates. In other words, if your screen resolution is 800 wide, then an object with 800 width will take up the entire screen. If Is2D is false, then the Camera will be in 3D mode, and the size of objects depends on the Z of the camera. By default, objects at Z=0 will appear the same size in both 2D and 3D cameras.

### Resolution Width

Controls the width of the game window. Increasing this value will make the game window wider and (by default) will display more of the game world.

### Resolution Height

Controls the height of the game window. Increasing this value will make the game window taller and (by default) will display more of the game world.

### Fixed Aspect Ratio

If checked, the game will maintain a fixed aspect ratio as specified by the horizontal and vertical ratio values. If the game window is does not match the desired aspect ratio, the game will be letterboxed or pillarboxed. For example, consider these variables:

-   Width = 400
-   Height = 400
-   Fixed Aspect Ratio = true
-   Aspect Ratio = 16 : 9

![](/media/2018-04-img_5ac5950d11861.png)

### Fullscreen

Whether the game runs in full screen. If unchecked the game runs in windowed mode. Note that fullscreen is "borderless fullscreen" which means it does not change the display adaptor's actual resolution. This means that alt-tabbing will be much faster and textures will not get unloaded when the game loses focus. When in fullscreen mode, the zoom value is ignored and the game will display the desired resolution.

### Allow Window Resizing

Whether the window can be resized by dragging the edges. If false, the window cannot be resized by the user by grabbing the edges.

### Scale

A percentage value used to make the window larger or smaller. A larger value will make the window larger, stretching the contents of the game window. For example, a 200x200 game window at 300 scale will draw at 600x600, with each object in the game being three times as wide and three times as tall. Note that scale is only used to set the initial window size. Manually resizing the window may make objects larger scale. When in fullscreen, the effective scale will be controlled by the resolution of the window.

### Scale (Gum)

If your game includes a Gum project then the Display Settings tab will include a Gum Scale text box. By default this value is 100%, so the Gum pixels will match your game 1:1.

![](/media/2020-09-img_5f72b0da6a76d.png)

For example, under this setting a game of 800 pixels wide and 600 pixels tall would display Gum at native resolution, as shown in the following image:

![](/media/2020-09-img_5f72b12b694db.png)

Changing the **Scale (Gum)** to 200% doubles the size of all Gum objects, as shown in the following image:

![](/media/2020-09-img_5f72b1674a6e0.png)

Values less than 100% are also supported. The following image shows the same layout with the **Scale (Gum)** set to 50%:

![](/media/2020-09-img_5f72b19f152ca.png)

**On Resize** Controls the behavior of the contents of the game window when the game window is resized. If set to **Preserve (Stretch) Visible Area**, stretching the game window will not allow the user to see more of the game world - instead objects will become larger as the window is stretched. If set to **Increase Visible Area**, stretching the game window will allow the user to see more of the game world - objects will remain the same size.

## Changing Resolution and Camera Values in Initialize Code

Glue's camera window provides an easy way to set the default behavior of your game, and it can be used to change camera settings during development. Many games allow the user to customize the window (such as by setting if the game runs in full screen), and the resolution information is then saved in a configuration file. The generated code for camera settings allows changing the Glue-assigned values prior to the window being created. To modify the settings in initialize:

1.  Open your project in Visual Studio
2.  Open **Game1.cs**
3.  Find the following line of code in the Game1's Initialize  method: CameraSetup.SetupCamera(SpriteManager.Camera, graphics);
4.  Add code to assign values to CameraSetup.Data  **before** the call to SetupCamera

For example, the following code could be used to set the values, assuming configurationData  is a valid object:

``` lang:c#
protected override void Initialize()
{
    #if IOS
    var bounds = UIKit.UIScreen.MainScreen.Bounds;
    var nativeScale = UIKit.UIScreen.MainScreen.Scale;
    var screenWidth = (int)(bounds.Width * nativeScale);
    var screenHeight = (int)(bounds.Height * nativeScale);
    graphics.PreferredBackBufferWidth = screenWidth;
    graphics.PreferredBackBufferHeight = screenHeight;
    #endif

    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    // assuming there is configuration data to load
    var configurationData = LoadConfigurationData();

    // assign the values before SetupCamera is called:
    CameraSetup.Data.ResolutionWidth = configurationData.ResolutionWidth;
    CameraSetup.Data.ResolutionHeight = configurationData.ResolutionHeight;
    CameraSetup.Data.IsFullScreen = configurationData.IsFullScreen;

    CameraSetup.SetupCamera(SpriteManager.Camera, graphics);
    ...
```

## Changing Resolution and Camera Values After Initialize

Camera and resolution values can be changed after initialize. Some games provide control over the resolution in a settings window. The generated CameraSetup object can be modified at any point in the game's execution. For example, the following code could be used to adjust the resolution and camera settings when the user presses the space bar:

``` lang:c#
// In any screen:
void CustomActivity(bool firstTimeCalled)
{
    var keyboard = InputManager.Keyboard;
    
    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Escape))
    {
        CameraSetup.Data.ResolutionWidth = 500;
        CameraSetup.Data.ResolutionHeight = 300;
        CameraSetup.Data.AspectRatio = 3;
        CameraSetup.Data.AllowWidowResizing = false;
        CameraSetup.Data.Scale = 300;
        CameraSetup.Data.IsFullScreen = true;

        CameraSetup.ResetWindow();
        CameraSetup.ResetCamera();
    }
}
```

Notice that the above code calls both ResetWindow  and ResetCamera . Typically modifications to the CameraSetup.Data require both to be called. The two functions are separated because Glue generated code calls ResetCamera inbetween each screen.

## Toggling IsFullScreen

The CameraSetup object provides code for toggling between your game running full screen and windowed. Using CameraSetup to toggle full screen is the recommended way as it handles all associated settings such as changing the camera values. The following code shows how to toggle fullscreen and windowed when the space bar is pressed:

    if(InputManager.Keyboard.KeyPushed(Keys.Space))
    {
       CameraSetup.Data.IsFullscreen = !CameraSetup.Data.IsFullScreen;
       CameraSetup.ResetWindow();
    }
