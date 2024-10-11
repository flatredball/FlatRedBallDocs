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

Once a SoundEffect Play call is made, the sound cannot be modified or stopped. It will play to completion and then stop. Therefore, to adjust the Play call, parameters can be added. For example to play a sound at half-volume, 0.5f could be passed as the first parameter:

```csharp
ExplosionSound.Play(volume:0.5f, pitch:0, pan:0);
```

By contrast, SoundEffectInstances are single-instance sounds which can be played, and manipulated after playing. For example, the following code plays a sound, but then adjusts its volume after 0.5 seconds:

```csharp
SoundEffectInstance.Volume = 1;
SoundEffectInstance.Play();

await TimeManager.DelaySeconds(0.5f);

ExplosionSound.Volume = 0.5f;
```

To change whether a .wav file is loaded as a SoundEffect or SoundEffectInstance, change its **RuntimeType** as shown in the following image:

![Changing a .wav's RuntimeType](../../../.gitbook/assets/20\_22\_24\_42.png)

{% hint style="info" %}
If you need to interrupt a sound after it has started playing, you must use a SoundEffectInstance.
{% endhint %}

### Adding a .wav to a FRB project

To add a .wav file to FRB:

1. Right-click on a Screen or Entity's **Files** item
2. Select **Add File**->**Existing File**
3. Navigate to the location of the .wav that you would like to use and click OK

You should see the .wav file in your project:

![WAV file in the Enemy entity](../../../.gitbook/assets/20\_22\_27\_04.png)

Alternatively you can drop WAV files into your project from Windows Explorer:

1. Open your project in the FRB Editor
2. Locate the WAV file you would like to use on disk
3. Drag+drop the file from Windows Explorer into your project in the desired Files folder. Note that if the file is not already a child of your Content folder, the file will be copied to the desired folder and the original file will be left on disk in its original location.

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

For more information on SoundEffect in FlatRedBall, see the [SoundEffect page](../../../api/microsoft-xna-framework/audio/soundeffect.md).

### WAV and XNB Files

FlatRedBall MonoGame does not require WAV files to be built and loaded from XNB files, but this is optionally supported. XNB files are built by the MonoGame content pipeline. If using the content pipeline, then the WAV file is built into an XNB file when initially added and also whenever the WAV file ever changes.

If using the content pipeline, WAV files are added as XNB files to your Visual Studio project. For example, the following SoundEffectFile.wav is part of GameScreen:

<figure><img src="../../../.gitbook/assets/image (291).png" alt=""><figcaption><p>WAV file in GameScreen</p></figcaption></figure>

This file is automatically added to your Visual Studio project by FlatRedBall, as shown in the following screenshot:

<figure><img src="../../../.gitbook/assets/image (292).png" alt=""><figcaption><p>WAV file as part of Visual Studio as a converted XNB</p></figcaption></figure>

WAV files can be explicitly rebuilt in the FRB Editor by right-clicking on the file and selecting **Rebuild Content Pipeline File (.xnb)**.

<figure><img src="../../../.gitbook/assets/image (293).png" alt=""><figcaption><p>Right click, Rebuild Content Pipeline File option</p></figcaption></figure>

When the file is built, the output window displays information about the build so you can diagnose problems.

<figure><img src="../../../.gitbook/assets/image (294).png" alt=""><figcaption><p>Content Pipline build output</p></figcaption></figure>

### Global SoundEffect, Screen/Entity SoundEffectInstance

As mentioned above, the easiest way to work with wav files is to load them as SoundEffects which provide a fire-and-forget Play method. You may want to provide additional control over SoundEffect playing in which case you can use a SoundEffectInstance. If your game pre-loads content, you can add the WAV file to global content as a SoundEffect, then add individual instances to the Screens or Entities which must play them.

Note that when this occurs, a copy is created so be careful adding instances to entities which will have multiple instances alive at once.

Note that this approach does not result in the wav file being loaded multiple times - the SoundEffect in global content is reused for each instance saving time.

To do this:

1. Add the wav file to global content. Note, this can even be done with wildcards
2.  Set the RuntimeType to SoundEffect\


    <figure><img src="../../../.gitbook/assets/image (338).png" alt=""><figcaption><p>SoundEffect in Global Content Files</p></figcaption></figure>
3. Add the same file to a Screen or Entity - you can drag+drop the file from global content, or right-click on the Files folder and select Add Existing.
4.  Change the RuntimeType to SoundEffectInstance using the dropdown\


    <figure><img src="../../../.gitbook/assets/image (339).png" alt=""><figcaption><p>SoundEffectInstance in a Screen, using the same .wav file as the SoundEffect in GlobalContent</p></figcaption></figure>

