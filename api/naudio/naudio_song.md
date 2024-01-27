# NAudio\_Song

### Introduction

The NAudio\_Song class provides more control over the playing of a song compared to using MonoGame/FNA's Song class.&#x20;

### Loading an NAudio\_Song

The easiest way to load an NAudio\_Song is to use the FRB Editor, add an MP3 to a Screen's Files, and to select NAudio\_Song as the type. For more information on loading through the FRB Editor, see the [FRB Editor's MP3 page](../../glue-reference/files/glue-reference-mp3-file-mp3.md).

Alternatively, NAudio\_Song instances can also be loaded in code. The following code shows how to load an NAudio\_Song. The loaded song is registered with FlatRedBall so that it can be unloaded when the content manager is unloaded (usually for a screen).

```csharp
MainSong =  new FlatRedBall.NAudio.NAudio_Song("Content/screens/level1/mainsong.mp3");
FlatRedBall.FlatRedBallServices.AddDisposable("Content/screens/level1/mainsong.mp3", 
    MainSong, 
    contentManagerName);
```

### Playing an NAudio\_Song

Once an NAudio\_Song is loaded, it can be played in your game.&#x20;

#### Playing through the FRB Editor

If you have loaded your song through the FRB Editor, it will play by default. You can control this through  the Song tab.

<figure><img src="../../.gitbook/assets/27_06 42 20.png" alt=""><figcaption><p>NAudio_Song instances can be played through the FRB Editor</p></figcaption></figure>

#### Playing in Code

NAudio\_Song instances can be played through the AudioManager. If your game only needs one song playing at a time, then the `AudioManager.PlaySong` is a convenient way to play the song.

```csharp
AudioManager.PlaySong(MenuSong, 
    forceRestart:true, 
    // This code assumes that "this" refers to a screen
    isSongGlobalContent:this.ContentManagerName == FlatRedBallServices.GlobalContentManager);
```

The code above plays the song through the AudioManager, which means that the standard behavior for song playing is applied:

* The song plays only if songs are enabled (`AudioManager.AreSongsEnabled`)
* The song respects the default song volume (`AudioManager.MasterSongVolume`)
* The song is registered as the current song, stopping other songs from playing
* The song clears the `AudioManager`'s Playlist (`AudioManager.PlaySongs`)

Although these behaviors may be convenient in some cases, you can directly access the NAudio\_Song methods and properties for more control.

For example, a song can be played directly without using the AudioManager using the Play method as shown in the following code:

```csharp
MenuSong.Play();
```

Keep in mind that the AudioManager will not be notified of the song playing, so mixing AudioManager behavior with direct Play calls may cause overlapping songs to play, or other confusing behavior.

### Volume

NAudio\_Song's Volume property can be used to make a song play more quietly. By default the volume value is at 1, which means full volume. A value of 0 silences the song. Values above 1 can be used, and the song will play louder, but it is not recommended for final products.

The following code shows how to adjust the volume of a song using the keyboard:

```csharp
var keyboard = InputManager.Keyboard;

if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up))
{
    MySong.Volume += .1f;
}
if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down))
{
    MySong.Volume -= .1f;
}
```

The Volume property can be changed gradually over time to create a fade as well. The following method uses the TweenerManager to gradually change the volume over one second:

```csharp
if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up))
{
    _=TweenerManager.Self.TweenAsync(
        owner: MySong,
        assignmentAction: value => MySong.Volume = value,
        from: 0,
        to: 1,
        during: 1,
        interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Linear);
}
if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down))
{
    _ = TweenerManager.Self.TweenAsync(
        owner: MySong,
        assignmentAction: value => MySong.Volume = value,
        from: 1,
        to: 0,
        during: 1,
        interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Linear);
}
```

