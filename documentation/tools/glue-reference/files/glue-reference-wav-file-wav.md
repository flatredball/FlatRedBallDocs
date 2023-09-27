## Introduction

Wav files can be used for sound effects in Glue. Wav files, which are uncompressed, are used because compression can introduce latency (delay before the sound plays).

## SoundEffect and SoundEffectInstance

Glue can use .wav files to create two types of objects:

-   SoundEffect
-   SoundEffectInstance

By default .wav files are loaded as a SoundEffect, which is the simplest object to work with. The SoundEffect object allows *fire-and-forget* sound effects. Once a .wav file is added to Glue, the SoundEffect it creates can be used with a Play call as shown in the following code:

    ExplosionSound.Play();

Once a SoundEffect Play call is made, the sound cannot be modified. It will play to completion and then stop. By contrast, SoundEffectInstances are single-instance sounds which can be played, and manipulated after playing. For example, the following code plays a sound, but then adjusts its volume after 0.5 seconds:

    ExplosionSound.Volume = 1;
    ExplosionSound.Play();

    await TimeManager.DelaySeconds(0.5f);

    ExplosionSound.Volume = 0.5f;

To change whether a .wav file is loaded as a SoundEffect or SoundEffectInstance, change its **RuntimeType** in Glue:

![](/media/2021-09-img_6150ca47f1f0d.png)

## Adding a .wav to a Glue project

To add a .wav file to Glue:

1.  Right-click on a Screen or Entity's "Files" item
2.  Select "Add File"-\>"Existing File"
3.  Navigate to the location of the .wav that you would like to use and click OK

You should see the .wav file in your Glue project:

![](/media/2021-02-img_603bcad7e65c9.png)

## Playing a SoundEffect in custom code

Once a .wav file has been added to your Glue project, Glue will generate an instance of a [SoundEffect](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.audio.soundeffect.aspx) in generated code. In this example, I've added a file called GunShotSound.wav, so the object that Glue creates is called GunShotSound. The following code can be added to CustomActivity to play the sound when the space bar is pressed:

    public void CustomActivity(bool firstTimeCalled)
    {
       if (InputManager.Keyboard.KeyPushed(Keys.Space))
       {
           GunShotSound.Play();
       }
    }

For more information on SoundEffect in FlatRedBall, see the[SoundEffect page](/documentation/api/microsoft-xna-framework/microsoft-xna-framework-audio/microsoft-xna-framework-audio-soundeffect/.md).
