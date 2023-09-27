## Introduction

The PositionedSound class is used to play a sound using the 3D audio features of XACT. This means a sound can have a position and velocity, which will be translated into volume and pitch levels on all available speakers.

## Control and Positioning

A PositionedSound is a combination of a [Sound](/frb/docs/index.php?title=FlatRedBall.Audio.Sound.md "FlatRedBall.Audio.Sound") class and a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). This means that all the sound playback controls of the Sound class work the same way in the PositionedSound class, and all methods available in the PositionedObject class are also available to the PositionedSound class. This opens up some great posibilities, like this example:

    shipFireSound = AudioManager.GetPositionedSound("ShipFire");
    shipSprite = SpriteManager.AddSprite(@"Assets\redball");
    shipFireSound.AttachTo(shipSprite, true);

Then, whenever the ship fires, a simple call to shipFireSound.Play() will play the sound in the appropriate position.

## Controlling the Listener

To have sounds positioned correctly, the engine must know where you want the listener to be hearing the sounds from. The [AudioManager](/frb/docs/index.php?title=FlatRedBall.Audio.AudioManager.md "FlatRedBall.Audio.AudioManager") exposes a SoundListener field to control this. The SoundListener is a positioned object, so it can be placed and rotated just like other objects.

For most situations, attaching the SoundListener to the default Camera will work just fine. This line of code will do just that:

    AudioManager.SoundListener.AttachTo(SpriteManager.Camera, true);

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
