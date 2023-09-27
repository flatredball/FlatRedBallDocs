**Note**: XACT is only supported in actual XNA, not MonoGame. Using XACT limits your platforms to PC, so we recommend not using XACT for game audio. The most common way to play sounds in FlatRedBall is to use Glue. More information can be found in the [Glue .wav page](/documentation/tools/glue-reference/files/glue-reference-files-wav-file-wav.md).

## Initialization

The AudioManager needs three things to initialize - the location of the sound settings file (xgs), the location of the wave bank file (xwb), and the location of the sound bank file (xsb). These are all created by compiling the XACT Audio Project (xap). To start, add the xap file to your solution's Content project by dragging it into the solution explorer. You'll end up with something like this: ![AudioProject.png](/media/migrated_media-AudioProject.png) If you look in the directory for your audio project, you should see a "Win" and an "Xbox" folder. These folders contain the settings file, wave bank and sound bank that XACT creates when you use the "Build" command within XACT. You will not need to include these files in your project, but they will show you the names of the xgs, xwb and xsb files that you will need in order to initialize the AudioManager. If you haven't changed the sound bank or wave bank names, then these files will be named "Sound Bank.xsb" and "Wave Bank.xwb", respectively. Assuming your audio project file is named "Sounds.xap", then the settings file will be named "Sounds.xgs". Using these names, you can now initialize the AudioManager. Add the following using statement:

    using FlatRedBall.Audio;

Add this line of code in the initialization of your game:

    // Assumes your content is in a Content\Audio folder
    AudioManager.Initialize(@"Content\Audio\Sounds.xgs",
        @"Content\Audio\Wave Bank.xwb", @"Content\Audio\Sound Bank.xsb");

**Note:** You'll notice that there are a number of files created by XACT. You only need to include the XAP file. The other files (which may be in a "Win" or "Xbox" folder) do not need to be added to your project. Furthermore, when referencing these files, you do NOT need to include the Win or Xbox folder. In other words, pretend that they are sitting in the same directory as your XAP file.

Note that if you have your audio project in a nested folder, then the settings file, sound bank and wave bank files will be generated in that folder as well, and you'll need to include it in the initialization path.

## Playing a Sound

The AudioManager.PlaySound() method can be used to play a sound once through (i.e. without stopping or any modifications). To use the method, simply call it with the name of the cue you want to play. For example, if you wanted to play an "Arrow" cue, you would use the following line of code:

    AudioManager.PlaySound("Arrow");

## Getting a Sound Object

The Sound and PositionedSound objects can do a lot more with sound - including stopping, restarting, and setting variables on sounds (along with positioned audio). To get a sound object, use one of the following methods (with "Arrow" used as an example cue name):

    Sound sound = AudioManager.GetSound("Arrow");
    PositionedSound positionedSound = AudioManager.GetPositionedSound("Arrow");

These methods will return a [Sound](/frb/docs/index.php?title=FlatRedBall.Audio.Sound "FlatRedBall.Audio.Sound") and [PositionedSound](/frb/docs/index.php?title=FlatRedBall.Audio.PositionedSound "FlatRedBall.Audio.PositionedSound") object, respectively, which you much maintain a reference to while playing. These objects expose methods such as Play() and Stop(), which may be used to control the sound. Read more about them on their respective reference pages.
