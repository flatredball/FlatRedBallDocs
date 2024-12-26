# PlaySongs

### Introduction

PlaySongs can be used to add multiple songs to the AudioManager to play in order. Once the entire SongPlaylist has finished, it begins playing again from the beginning.

### Code Example - Playing Songs from GlobalContent

The following code can be used to play multiple songs which are part of GlobalContent.

```csharp
private void CustomInitialize()
{
    var songList = new List<Song>
    {
        GlobalContent.Song1,
        GlobalContent.Song2, 
        GlobalContent.Song3

    };
    var playlist = new SongPlaylist(songList, areSongsGlobalContent:true);

    AudioManager.PlaySongs(playlist);
}
```
