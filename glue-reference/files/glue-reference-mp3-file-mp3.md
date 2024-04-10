# MP3

### Introduction

The MP3 file format often used for music. All information on this page also applies to the OGG file format. FlatRedBall loads MP3 files as [Song](../../api/microsoft-xna-framework/media/song/) instances. For more information on working directly with Songs, see the [Song page](../../frb/docs/index.php).

### How to play a MP3 in your game

To play an MP3 in your game:

1. Create or select the screen that you want to have the song
2. Expand the screen to see the **Files** item
3. Drag+drop the MP3 file from the explorer into a Screen's **Files** node.
   1. Alternatively you can right-click on the Files tree node and select **Add File**->**Existing File** and browse to the location of the MP3

<figure><img src="../../media/2016-01-2018-06-25_07-42-05.gif" alt=""><figcaption><p>Adding a Song to a Screen by drag+dropping the file</p></figcaption></figure>

Note that by default the dropped song uses the Microsoft.Xna.Framework.Media.Song runtime type. See below for more information on this compared to other types.

The song automatically plays when the Screen starts. The song automatically stops playing when the Screen exits. You do not need write any code to play or stop the music. If a Screen contains multiple audio files, then additional settings and logic are needed to select which song should be played.

The song that is played uses the [AudioManager.PlaySong](../../api/flatredball/audio/audiomanager/playsong.md) method, so any properties set on the AudioManager (such as MasterSongVolume) apply to the playing of the song. For more information, see the [AudioManager.PlaySong](../../api/flatredball/audio/audiomanager/playsong.md) page.

### Adding a New Default Song

FlatRedBall provides sample songs which you can use to test song playing. To add a new song to your game:

1. Right-click on the Files folder in a Screen
2. Select Add File -> New File
3. Search for Song
4.  Select one of the song types and click OK\


    <figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Add New File window selecting one of the song types</p></figcaption></figure>

For more information on NAudio, see below.

### Basic Song Controls

FlatRedBall provides simple song controls in the Song tab. To view the Song tab:

1. Add a song file to your game (as shown above)
2. Select the newly-created song
3. Select the **Song** tab

![Song tab provides basic song controls](<../../.gitbook/assets/27\_05 17 46.png>)

### Moving between Screens

By default a Song added to a Screen plays when the Screen starts and stops when the screen is destroyed. To have songs persist between Screen transitions, check the **Keep Playing After Leaving Screen** checkbox. Note that if this is checked, the song continues to play only if either of the following conditions are true:

* The new screen does not specify a song to play
* The new screen does specify a song to play, but the song is the same as the song that was playing in the previous screen

If the new screen specifies a different song, then the new screen's song begins playing even if the old song's **Keep Playing After Leaving Screen** checkbox is checked.

### Optionally Playing Songs

You can add multiple songs to your Screen if you would like to select which one to play in custom code. To do this:

1. Create a Screen
2.  Add any number of .mp3 files to your Screen\
    &#x20;

    <figure><img src="../../media/migrated_media-MultipleSongsInScreen.PNG" alt=""><figcaption><p>A FlatRedBall Screen with multiple song files</p></figcaption></figure>
3.  Set each of them to **LoadedOnlyWhenReferenced**. For more information on this property, see [the LoadedOnlyWhenReferenced page](glue-reference-loadedonlywhenreferenced.md). \


    <figure><img src="../../media/migrated_media-SongLoadedOnlyWhenReferenced.png" alt=""><figcaption></figcaption></figure>
4. In custom code, play the song you would like to play. For example, if your song is called MySong, then add the following code:

```csharp
// Notice the song name is identical to the file name without the extension.
// In other words Song1.mp3 is referenced as Song1
FlatRedBall.Audio.AudioManager.PlaySong(Song1, true, false);
```

For more information on the AudioManager, see the [AudioManager page](../../api/flatredball/audio/audiomanager/).

### NAudio\_Song

FlatRedBall provides built-in support for NAudio. When a new song is added through the Add File -> New File right-click option, a window allows the selection of NAudio or (MonoGame) Songs.&#x20;

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Song type selection when creating a new song</p></figcaption></figure>

Already-added songs can be changed between Song and NAudio\_Song by changing the runtime type on the file's properties.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Changing a Song's RuntimeType</p></figcaption></figure>

Both MonoGame/FNA `Song` and `NAudio_Song` share much of the same functionality. Both:

* Can be managed through the Song tab in FlatRedBall
* Can be played through AudioManager.PlaySong
* Respond to the AudioManager's MasterSongVolume if played through AudioManager.PlaySong

NAudio provides additional functionality for playing songs, so games which need more control over music playing may want to use NAudio\_Song.
