# glue-how-to-play-sounds

### Introduction

FlatRedBall supports playing sound effects. Sound effects can be loaded from .wav files.

### Adding a SoundEffect to a Screen

The following will show you how to add a SoundEffect to a Screen. The same method can be used to add a SoundEffect to an Entity as well.

1. Right-click on a Screen's Files tree node
2. Add a file to the Screen
   1. If you have an existing .wav file, select **Add File**->**Existing File**
   2.  If you would like to add a placeholder .wav file, or if you would like to test playing sound effects, select \*\*Add File \*\*-> **New File** and select **Sound Effect (.wav)**

       ![](../../../media/2022-09-img\_63291e0635a58.png)

Note: WAV files are used for sound effects. MP3 and WMA files are used for songs. For information on MP3 files, see [this file](../../../frb/docs/index.php).

Your WAV file should now be part of of the Screen.

![](../../../media/2022-09-img\_63291e90d60eb.png)

### Playing the sound in code

To play the sound in code, add the following code to your GameScreen. This assumes that your file is called SoundEffectFile.wav.wav and that you are adding this code to the same Screen/Entity that contains the file:

```
if (InputManager.Keyboard.KeyPushed(Keys.Space))
{
    SoundEffectFile.Play();
}
```

The SoundEffectFile object in this example is a SoundEffect instance created by Glue. For information on working with the SoundEffect class, see [the SoundEffect code reference page](../../api/microsoft-xna-framework/audio/soundeffect.md). The SoundEffect (which is added to a Screen/Entity when adding a WAV file) can also be played using the [AudioManager](../../../frb/docs/index.php).

### Limiting Number of Playing SoundEffects

By default the SoundEffect is fire-and-forget, and the only limitation on simultaneous sound effects is from the hardware. However, using the Duration property, a SoundEffect can be limited. In concept, to accomplish this the code needs to keep track of a variable for how many sounds are playing. When a sound plays, increment the number. When a sound stops playing, decrement the number.

### Volume, Looping, and Panning

To control volume, looping, and panning, you will need to use a SoundEffectInstance object. For information on this, see the [SoundEffectInstance Glue reference page](../../../frb/docs/index.php).

### Troubleshooting

#### Audio file NAME.wav contains 24-bit audio. Only 8-bit and 16-bit audio data is supported.

You may need to convert your file to 8 or 16-bit as XNA PC may have problems with 24 bit audio. For more information, see [this page](http://gamedev.stackexchange.com/questions/57979/how-can-i-load-24-bit-audio-as-soundeffect).
