# PlaySong

PlaySong plays the argument song, optionally restarting it if it is already playing. This method is automatically called if a song file is added to the FlatRedBall Editor, but it can also be explicitly called for more control over song playing.

### PlaySong and Microsoft.Xna.Framework.Media.Song

Microsoft.Xna.Framework.Media.Song is the default class in MonoGame and FNA for playing music. PlaySong ultimately uses the MediaPlayer.Play method to play a song, so it is inherits the limitations of MediaPlayer, including being able to play only one song at a time. MonoGame's MediaPlayer also suffers from noticeable seek time on MP3s, including looping.

### PlaySong and ISong

The PlaySong method can also receive any class which implements ISong. The most common type of ISong implementation is the NAudio song. NAudio provides additional flexibility and better seeking/looping compared to MonoGame and FNA, so it is recommended for games which require more song playing flexibility.

For more information on loading an NAudio\_Song intance, see the [MP3 loading page](../../../../glue-reference/files/glue-reference-mp3-file-mp3.md).

