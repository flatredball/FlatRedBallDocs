## Introduction

SupportedOrientation controls available orientations on the app. This property is only used on devices which can be used in portrait and landscape modes (not available on desktop platforms, Xbox One).

## Code Example

The following code can be used to set the game to run in portrait mode:

``` lang:c#
GraphicsDeviceManager graphics;
public Game1() : base ()
{
    graphics = new GraphicsDeviceManager(this);
    ...
    graphics.SupportedOrientations = DisplayOrientation.Portrait;
    ...
```

Note that additional code is required for each platform, as shown below.

### Code Location

SupportedOrientations property must be assigned in the Game's constructor, after the graphics instance has been initialized. Assigning the orientation later, such as in initialize methods, may result in unexpected behavior.

## Platform Specific Considerations

Setting the orientation through SupportedOrientation also requires additional changes per-platform.

### Android

The orientations set on SupportedOrientation should match the orientations set in Activity1.cs on the Activity attribute, as shown in the following code:

``` lang:c#
[Activity(Label = "AndroidOrientation"
    , MainLauncher = true
    , Icon = "@drawable/icon"
    , Theme = "@style/Theme.Splash"
    , AlwaysRetainTaskState = true
    , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
    , ScreenOrientation = ScreenOrientation.Portrait
    , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
{
```

 
