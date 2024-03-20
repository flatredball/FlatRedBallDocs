# Wave (.wav)

### Introduction

Wav files can be used for sound effects in FRB. Wav files, which are uncompressed, are used because compression can introduce latency (delay before the sound plays).

### SoundEffect and SoundEffectInstance

The FRB Editor can use .wav files to create two types of objects:

* SoundEffect
* SoundEffectInstance

By default .wav files are loaded as a SoundEffect, which is the simplest object to work with. The SoundEffect object allows _fire-and-forget_ sound effects. Once a .wav file is added to FRB, the SoundEffect it creates can be used with a Play call as shown in the following code:

```csharp
ExplosionSound.Play();
```

Once a SoundEffect Play call is made, the sound cannot be modified. It will play to completion and then stop. By contrast, SoundEffectInstances are single-instance sounds which can be played, and manipulated after playing. For example, the following code plays a sound, but then adjusts its volume after 0.5 seconds:

```csharp
ExplosionSound.Volume = 1;
ExplosionSound.Play();

await TimeManager.DelaySeconds(0.5f);

ExplosionSound.Volume = 0.5f;
```

To change whether a .wav file is loaded as a SoundEffect or SoundEffectInstance, change its **RuntimeType** as shown in the following image:

![](../../media/2021-09-img\_6150ca47f1f0d.png)

### Adding a .wav to a FRB project

To add a .wav file to Glue:

1. Right-click on a Screen or Entity's "Files" item
2. Select "Add File"->"Existing File"
3. Navigate to the location of the .wav that you would like to use and click OK

You should see the .wav file in your project:

![](../../media/2021-02-img\_603bcad7e65c9.png)

### Playing a SoundEffect in custom code

Once a .wav file has been added to your FRB project, your Screen, Entity, or GlobalContent includes an instance of a [SoundEffect](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.audio.soundeffect.aspx) in generated code.&#x20;

The following example assumes a file named GunShotSound.wav, so the code instance is named GunShotSound. The following code can be added to CustomActivity to play the sound when the space bar is pressed:

```csharp
public void CustomActivity(bool firstTimeCalled)
{
   if (InputManager.Keyboard.KeyPushed(Keys.Space))
   {
       GunShotSound.Play();
   }
}
```

For more information on SoundEffect in FlatRedBall, see the [SoundEffect page](../../api/microsoft-xna-framework/audio/soundeffect.md).
