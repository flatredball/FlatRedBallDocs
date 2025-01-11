# Song

### Introduction

The Song class can be used to play music in a game. The easiest way to play a song is through the FlatRedBall Editor, which requires no code. For more information on Songs in Glue, see [this page](../../../../glue-reference/files/file-types/glue-reference-mp3-file-mp3.md).

### Supported File Types

| Format | PC Desktop                                                            | Android |
| ------ | --------------------------------------------------------------------- | ------- |
| MP3    | X                                                                     | X       |
| WMA    | X                                                                     |         |
| OGG    | X [(with this codec installed)](http://www.vorbis.com/setup_windows/) | X       |

WAV files are not supported in FlatRedBall for music files. Instead, they are used by the [SoundEffect](../../../../frb/docs/index.php) and [SoundEffectInstance](../../../../frb/docs/index.php) classes.

### Example - Playing a Song in Code

To play a song in code, drag+drop a file from disk into your FlatRedBall project on a Screen. When your game runs the song plays automatically when the screen loads. For more information about playing songs in Glue, see the [MP3 page](../../../../glue-reference/files/file-types/glue-reference-mp3-file-mp3.md).

### Example - Manual Visual Studio/Code Loading and Playing

To play a song:

1. Drag a music file (MP3 or WMA) into your project's Content folder through Visual Studio. ![SongInContentProject.png](../../../../.gitbook/assets/migrated_media-SongInContentProject.png)
2. Add the following code:

Add the following using statements:

```
using Microsoft.Xna.Framework.Media;
```

Add the following to Initialize after initializing FlatRedBall:

```
string contentManagerName = "ContentManager";
Song song = 
   FlatRedBallServices.Load<Song>(@"Content/mySongWithoutExtension", contentManagerName);
Microsoft.Xna.Framework.Media.MediaPlayer.Play(song);
```

**This code uses the Content Pipeline:** Notice that when this file is loaded you do not include the extension. This is because the file needs to be added to your project using the Content Pipeline. For more information on what the Content Pipeline is, see [this link](../../../../frb/docs/index.php).

### Troubleshooting

#### Song playback failed. Please verify that the song is not DRM protected. DRM protected songs are not supported for creator games.

This error can occur in a number of cases:

* If you're using a WMA/MP3 with DRM
* If Windows Media Player is not installed on the computer running the game

1. Open Control Panel
2. Select Programs and Features
3. Turn windows features on or off
4. Expand Media Features
5. Make sure Windows Media Player is selected

#### OGG song does not play (is silent)

If attempting to play an .ogg file on the PC, you need to have the proper "DirectShow Filters" installed. To verify if you have them installed, attempt to play the .ogg file in Windows Media Player. If Windows Media Player does not recognize the file then you need the filters: ![OggError1.png](../../../../.gitbook/assets/migrated_media-OggError1.png) ![OggError2.png](../../../../.gitbook/assets/migrated_media-OggError2.png) If the song does not play, you can install the DirectShow Filders, [which can be found here](http://www.vorbis.com/setup_windows/).

### Android

#### Supported File Types

* OGG

This is dependent on the Android phone. Just because it plays on one phone doesn't mean it will play on another. If the phone doesn't have the codec, it will return a

```
Java.IO.IOException: Exception of type 'Java.IO.IOException' was thrown.
```
