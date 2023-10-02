# fromuri

### Introduction

The FromUri method games to create songs from a regular song file (such as .mp3) rather than relying on the Content Pipeline. If you are simply interested in playing a song, the easiest way to load and play a song is through Glue, as explained [on this page](../../../../../frb/docs/index.php). The FromUri method requires writing code.

The FromUri method provides the following benefits:

1. Does not require the usage of the Content Pipeline when loading songs in code.
2. Does not require adding content to the Visual Studio project, which is important if your project does not ship with all of the content it will use. Games which allow downloading DLC or modding will want to use the FromUri method. Furthermore, audio may be downloaded after a game is installed on Android to fit within the current 50 megabyte .apk limit.

### Code Example

Using the FromUri code requires loading a Song in custom code (as oppose to using Glue code to load the file). Song files which are loaded with FromUri can be added as follows:

* Glue files can be loaded, but they must have their LoadedAtRuntime value set to false. For more information, see the [LoadedAtRuntime page](../../../../../frb/docs/index.php).
* Files can be added manually to the Visual Studio/Xamarin Studio project manually.
* Files can be added by the project itself, such as by unzipping a file or downloading a file from the Internet.

Once the file is available by the project, it can be loaded as follows:

```
string songFileName = @"content/SongName.mp3";
var uri = new Uri(songFileName, UriKind.Relative);
var song = Song.FromUri("SongName", uri);

// The song should be added to the ContentManager disposable list so that it is unloaded
// when the screen is unloaded:
FlatRedBallServices.AddDisposable(songFileName, song, this.ContentManagerName);

// Finally, the song can be played with the PlaySong method:
bool isGlobalContent = this.ContentManagerName == FlatRedBallServices.GlobalContentManager;
FlatRedBall.Audio.AudioManager.PlaySong(song, false, isGlobalContent);
```

### FlatRedBall Android

The FromUri method as implemented in MonoGame 3.4 includes a bug requiring a workaround:

[http://community.monogame.net/t/solved-how-can-i-play-a-mp3-file-from-file-outside-of-the-content-folder/2687/9](http://community.monogame.net/t/solved-how-can-i-play-a-mp3-file-from-file-outside-of-the-content-folder/2687/9)
