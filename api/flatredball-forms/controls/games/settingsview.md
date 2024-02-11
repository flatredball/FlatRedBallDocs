# SettingsView

### Introduction

The SettingsView control provides common settings for controlling your game's audio and full screen status.&#x20;

Specifically, the SettingsView can be used to control:

* Song (music) volume
* Sound effect volume
* Full screen/windowed

<figure><img src="../../../../.gitbook/assets/28_05 07 17.gif" alt=""><figcaption><p>Default SettingsView</p></figcaption></figure>

Note that future versions of SettingsView may expand to include more controls and settings in the future.

### Integrating SettingsView in Your Game

The first step in using the SettingsView is to add an instance of the view to your Gum screen. If your project has included FlatRedBall.Forms then you have a default SettingsView in Gum.

<figure><img src="../../../../.gitbook/assets/image (6).png" alt=""><figcaption><p>SettingsView in Gum</p></figcaption></figure>

Once the SettingsView has been created and added to a Screen. By default the music slider modifies [AudioManager.MasterSongVolume](../../../flatredball/audio/audiomanager/mastersongvolume.md) and the sound effect slider modifies [AudioManager.MasterSoundVolume](../../../flatredball/audio/audiomanager/mastersoundvolume.md).

This behavior can be disabled by setting IsAutoApplyingChangesToEngine to false.

### Full Screen

By default the IsFullscreen property does not automatically apply a full screen/windowed status to the engine. At the time of this writing full screen status is typically controlled through generated code, so the SettingsView does not have access to the methods necessary to set full screen/windowed.

To toggle full screen you can either bind a ViewModel to the IsFullscreen property or you can subscribe to the FullscreenSet property.

The following code shows how to subscribe to the FullscreenSet property:

```csharp
void CustomInitialize()
{
    var settings = Forms.SettingsViewInstance;
    settings.FullscreenSet += HandleFullscreenSet;
}

private void HandleFullscreenSet(bool isFullscreen)
{
    CameraSetup.Data.IsFullScreen = isFullscreen;
    if (CameraSetup.GraphicsDeviceManager != null)
    {
        CameraSetup.ResetWindow();
        CameraSetup.ResetCamera();
    }
}
```

This code assumes that you are using the generated CameraSetup code provided by the [Display Settings window](../../../../glue-reference/camera.md).
