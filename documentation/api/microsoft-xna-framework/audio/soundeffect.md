## Introduction

The SoundEffect class represents a sound effect that can be played at any time. The FlatRedBall Editor supports the automatic creation of SoundEffect objects by adding a WAV file to a Screen, Entity, or Global Content. For reference on the SoundEffect object, see the [MonoGame SoundEffect page](https://docs.monogame.net/api/Microsoft.Xna.Framework.Audio.SoundEffect.html). For more information on using SoundEffect through the FlatRedBall Editor, see [the tutorial page on playing sounds](/documentation/tutorials/glue-tutorials/glue-how-to-play-sounds.md "Glue:How To:Play Sounds").

## Code Example

The following example assumes that you have "mySound.wav" added to your content project. If not using Glue, you will need to pass the .WAV file through the MonoGame content pipeline. Glue will automatically process .WAV files added to Screens, Entities, and Global Content Files.

    // SoundEffects load through the content pipeline, so there is no extension
    SoundEffect soundEffect = FlatRedBallServices.Load<SoundEffect>(@"Content\mySound");
    // to play the sound, just call Play:
    soundEffect.Play();

## 
