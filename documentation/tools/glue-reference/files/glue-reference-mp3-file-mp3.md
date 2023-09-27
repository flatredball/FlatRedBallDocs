## Introduction

The MP3 file format is a format often used for music. All information on this page also applies to the OGG file format. Glue loads MP3 files as [Song](/frb/docs/index.php?title=Microsoft.Xna.Framework.Media.Song "Microsoft.Xna.Framework.Media.Song") instances. For more information on working with the [Song class](/frb/docs/index.php?title=Microsoft.Xna.Framework.Media.Song "Microsoft.Xna.Framework.Media.Song"), see the [Song page](/frb/docs/index.php?title=Microsoft.Xna.Framework.Media.Song "Microsoft.Xna.Framework.Media.Song").

## How to play a MP3 in your game

To play an MP3 in your game:

1.  Create or select the screen that you want to have the song
2.  Expand the screen to see the **Files** item
3.  Drag+drop the MP3 file from the explorer into a Screen's **Files** node.
    1.  Alternatively you can right-click on the Files tree node and select **Add File**-\>**Existing File** and browse to the location of the MP3

[![](/wp-content/uploads/2016/01/2018-06-25_07-42-05.gif)](/wp-content/uploads/2016/01/2018-06-25_07-42-05.gif) The song will automatically play when the Screen starts up. The song will automatically stop playing when the Screen exits. You do not need write any code to play or stop the music. If a Screen contains multiple audio files, then additional settings and logic are needed to select which song should be played.

## 

## Basic Song Controls

A song can be controlled in the Song tab. To view the Song tab:

1.  Add a song file to your game (as shown above)
2.  Select the newly-created song
3.  Select the **Song** tab

![](/media/2020-01-img_5e2b20a46ac51.png)

## Moving between Screens (Glue)

Songs added in Glue belong to a particular Screen. To have songs persist between Screen transitions, see [this page](/documentation/tools/glue-reference/files/glue-reference-destroyonunload.md "Glue:Reference:Files:DestroyOnUnload").

## Optionally Playing Songs

You can add multiple songs to your Screen if you would like to select which one to play in custom code. To do this:

1.  Create a Screen
2.  Add any number of .mp3 files to your Screen ![MultipleSongsInScreen.PNG](/media/migrated_media-MultipleSongsInScreen.PNG)
3.  Set each of them to LoadedOnlyWhenReferenced. For more information on this property, see [the LoadedOnlyWhenReferenced page](/frb/docs/index.php?title=Glue:Reference:Files:LoadedOnlyWhenReferenced "Glue:Reference:Files:LoadedOnlyWhenReferenced"). ![SongLoadedOnlyWhenReferenced.png](/media/migrated_media-SongLoadedOnlyWhenReferenced.png)
4.  In custom code, play the song you would like to play. For example, if your song is called MySong, then add the following code:

&nbsp;

    // Notice the song name is identical to the file name without the extension.
    // In other words Song1.mp3 is referenced as Song1
    FlatRedBall.Audio.AudioManager.PlaySong(Song1, true, false);

For more information on the AudioManager, see the [AudioManager page](/frb/docs/index.php?title=FlatRedBall.Audio.AudioManager "FlatRedBall.Audio.AudioManager").
