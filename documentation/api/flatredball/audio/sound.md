## Introduction

The Sound class is used to manage and play a sound cue. It can be obtained from the [AudioManager](/frb/docs/index.php?title=FlatRedBall.Audio.AudioManager.md "FlatRedBall.Audio.AudioManager") using the GetSound(CueName) method.

## Sound Control

The following methods will modify the playback of a sound:

-   **Play()** - Plays the sound, resumes the sound (if paused), or restarts the sound (if stopped).
-   **Stop() / StopAsAuthored()** - Stops playback of the sound as authored in the XACT project.
-   **StopImmediately()** - Stops playback of the sound immediately.
-   **Pause()** - Pauses playback of the sound.

Additionally, there is a **Variables** field within the sound object which provides easy access to any cue instance variables. For example, if the XACT project defined a "Volume" cue instance variable, then it could be accessed using the following line:

    float soundVolume = mySound.Variables["Volume"];

It could be set using the following line:

    mySound.Variables["Volume"] = 6.0f;

For more information on setting variables in an XACT project, read the XNA Creator's Club's Advanced Audio Tutorial on [controlling pitch and volume with variables](http://creators.xna.com/Headlines/tutorialscol1/archive/2007/04/26/Advanced-Audio-Tutorial-1_3A00_-Controlling-Pitch-and-Volume-with-Variables.aspx).

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
