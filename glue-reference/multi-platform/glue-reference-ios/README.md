# iOS

### Introduction

FlatRedBall support development for iOS (iPhone and iPad) using .NET 8 (as of March 2024).

### Creating a New iOS Project

To create a new iOS project, launch the FlatRedBall Editor, create a new project, and select iOS as your target platform.

### Troubleshooting

#### The MinimumOSVersion value in the Info.plist (11.0) does not match the SupportedOSPlatformVersion value (11.2)

You may see the following when deploying your project:

```
The MinimumOSVersion value in the Info.plist (11.0) does not match 
the SupportedOSPlatformVersion value (11.2) in the project file 
(if there is no SupportedOSPlatformVersion value in the project 
file, then a default value has been assumed). Either change the 
value in the Info.plist to match the SupportedOSPlatformVersion 
value, or remove the value in the Info.plist (and add a 
SupportedOSPlatformVersion value to the project file if it doesn't 
already exist).
```

Verify that your Info.plist Deployment Target matches your csproj's SupportedOSPlatformVersion.

<figure><img src="../../../.gitbook/assets/image (109).png" alt=""><figcaption><p>Match Deployment Target to SupportedOSPlatformVersion</p></figcaption></figure>

### Additional Information

* If you have a NullReferenceException in Microsoft.Xna.Framework.Audio.OpenALSoundController.Update, and you are playing on the simulator, verify that audio is working properly on your Mac.
* For information on errors playing SoundEffects and SounEffectInstances see [the SoundEffectInstance page](../../../frb/docs/index.php).
