## Introduction

AreSoundEffectsEnabled can be used to make the [Play](/frb/docs/index.php?title=FlatRedBall.Audio.AudioManager.Play "FlatRedBall.Audio.AudioManager.Play") function produce no audio. This is often set by options screens so that the game code does not need to be cluttered with if-checks surrounding all audio playing.

## Code Example

    AudioManager.AreSoundEffectsEnabled = false;
    // This will not do anything:
    AudioManager.Play(SoundEffectObject);

## Already-playing SoundEffects will continue to play

Setting AreSoundEffectsEnabled to false will not stop any already-playing SoundEffects.
