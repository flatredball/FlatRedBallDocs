## Introduction

A SoundEffectInstance is a sound effect which provides a number of properties which can be used to modify how the sound is played back - for example volume, pitch, and whether the sound is looping. If a SoundEffectInstance is playing, it cannot be played again until the sound ends, or until the SoundEffectInstance is explicitly stopped. This can give precise control over how many sounds are playing at one time.

## How to create a SoundEffectInstance

To add a SoundEffectInstance to your project:

1.  Make sure you have a Glue project with a Screen or Entity which will contain the SoundEffectInstance.
2.  Add a new WAV file to your Screen or Entity. For more information, the [.WAV file page](/documentation/tools/glue-reference/files/glue-reference-files-wav-file-wav/.md).
3.  Once the file has been added to Glue, you need to change the RuntimeType to SoundEffectInstance:![RuntimeTypeSoundEffectInstance.png](/media/migrated_media-RuntimeTypeSoundEffectInstance.png)

At this point the SoundEffectInstance will be available in code, but you cannot change any variables on the SoundEffectInstance. To do this:

1.  Right-click on Objects
2.  Select "Add Object"
3.  Select the "From File" option
4.  Select the .wav file you added as a file
5.  Click OK
6.  Select the newly-created object
7.  Change "SourceName" to "Entire File (SoundEffectInstance)"

![SoundEffectInstanceObjectSourceName.png](/media/migrated_media-SoundEffectInstanceObjectSourceName.png)

## Modifying Variables

After setting up the object, you can modify the variables of the object in Glue. To do so, select the object and scroll to the "Unset Variables" category. ![SoundEffectInstanceObjectVariables.png](/media/migrated_media-SoundEffectInstanceObjectVariables.png) These variables can also be set through code:

    // 50% volume:
    SoundEffectInstanceObject.Volume = .5f;

    // Pan it full left:
    SoundEffectInstanceObject.Pan = -1.0f;
