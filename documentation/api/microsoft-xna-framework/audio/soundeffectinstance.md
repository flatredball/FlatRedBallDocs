## Introduction

The SoundEffectInstance is a copy of a SoundEffect which can be played on its own. Each SoundEffectInstance can only be played once at a time. Therefore if two sounds must overlap, then two SoundEffectInstances are needed. By contrast, calling SoundEffect.Play multiple times will result in overlapping sounds. Although the SoundEffectInstance requires multiple instances for simultaneous plays, it provides the number of benefits:

-   It can be stopped at any time
-   It provides parameters for modifying how the sound effect is played (such as pitch)
-   You can inspect if a SoundEffectInstance is playing

For information on using SoundEffectInstances in the FlatRedBall Editor, see the FlatRedBall Editor's [SoundEffectInstance page](/documentation/tools/glue-reference/objects/glue-reference-objects-soundeffectinstance/.md "Glue:Reference:Objects:SoundEffectInstance"). For a more detail on the SoundEffectInstance class, see [MonoGame's SoundEffectInstance reference](https://docs.monogame.net/api/Microsoft.Xna.Framework.Audio.SoundEffectInstance.html).

## SoundEffectInstance errors on iOS

If you are running the iOS simulator on a Mac then you may experience an error at runtime. A work-around for this error has not yet been discovered but it is occurs in MonoGame and not FlatRedBall. More information on the issue can be found here: [http://community.monogame.net/t/error-while-playing-soundeffect/1605](http://community.monogame.net/t/error-while-playing-soundeffect/1605).
