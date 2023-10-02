# play

### Introduction

The Play method can be used to play a [SoundEffect](../../../../../frb/docs/index.php), optionally specifying the volume to play at. The Play method performs the following additional logic:

* It only plays the [SoundEffect](../../../../../frb/docs/index.php) if [AreSoundEffectsEnabled](../../../../../frb/docs/index.php) is true.
* It checks if the [SoundEffect](../../../../../frb/docs/index.php) has already been played this frame, preventing the same [SoundEffect](../../../../../frb/docs/index.php) from playing twice in one frame. This behavior depends on the value of [SoundEffectPlayingBehavior](../../../../../frb/docs/index.php).
* It increments [NumberOfSoundEffectPlays](../../../../../frb/docs/index.php) which can be used to measure how many times sound effects have played.
* It checks if the argument [SoundEffect](../../../../../frb/docs/index.php) has been disposed (debug only) and throws an informative exception if so.

### Code Examples

The following assumes that Explosion is a [SoundEffect](../../../../../frb/docs/index.php). This can be created by adding a [.wav file](../../../../../frb/docs/index.php) to Glue.

```
AudioManager.Play(Explosion);
```

Sounds can be played with a custom volume:

```
// Values are 0 - 1, so .5 is 50%
float volume = .5f;
AudioManager.Play(EngineNoise, volume);
```
