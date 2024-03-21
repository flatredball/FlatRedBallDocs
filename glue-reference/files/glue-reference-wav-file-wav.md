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

![Changing a .wav's RuntimeType](../../.gitbook/assets/20\_22\_24\_42.png)

### Adding a .wav to a FRB project

To add a .wav file to FRB:

1. Right-click on a Screen or Entity's **Files** item
2. Select **Add File**->**Existing File**
3. Navigate to the location of the .wav that you would like to use and click OK

You should see the .wav file in your project:

![WAV file in the Enemy entity](../../.gitbook/assets/20\_22\_27\_04.png)

### Playing a SoundEffect in custom code

Once a .wav file has been added to your FRB project, your Screen, Entity, or GlobalContent includes an instance of a SoundEffect in generated code.&#x20;

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

For the full SoundEffect documentation, see the MonoGame [SoundEffect page](https://monogame.net/api/Microsoft.Xna.Framework.Audio.SoundEffect.html).

For more information on SoundEffect in FlatRedBall, see the [SoundEffect page](../../api/microsoft-xna-framework/audio/soundeffect.md).
