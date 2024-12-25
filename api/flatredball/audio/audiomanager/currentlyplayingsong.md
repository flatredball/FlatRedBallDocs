# CurrentlyPlayingSong

The CurrentlyPlayingSong member returns the song that is currently playing. This value is set as follows:

* When [PlaySong](../../../../frb/docs/index.php) is called it is set to the song passed to the method
* When [StopSong](../../../../frb/docs/index.php) is called it is set to null
* When the CurrentlyPlayingSong finishes playing it is set to null
* If a song is played through the MediaPlayer the AudioManager checks this every frame and automatically sets the CurrentlyPlayingSong
