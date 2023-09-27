In the past Glue's Camera Settings window generated code which could not be modified at runtime. [![](/wp-content/uploads/2018/04/img_5ac59305f0568.png)](/wp-content/uploads/2018/04/img_5ac59305f0568.png) These settings made it very easy to set up a game as desired with no code, but the code never allowed modifications to be made after the game started, at least until now. The latest version of Glue generates code which allows custom code to modify the game's resolution using the same variables as in the Display Settings (shown above). For example, a configuration file could be used to modify the values before the window shows up:

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

Or a game could even modify the camera and resolution at any time, such as when a key is pressed:

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

For more information check out the Camera Settings page: http://flatredball.com/documentation/tools/glue-reference/menu/settings/glue-reference-menu-settings-camera-settings/
