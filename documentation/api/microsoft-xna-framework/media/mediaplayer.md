## Introduction

The MediaPlayer class is an XNA class which controls the playing of music. For full documentation, see [Microsoft's MediaPlayer reference page](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.media.mediaplayer.aspx).

## Looping Music

To have your game loop its music, add the following line of code to your Game1.cs file:

    Microsoft.Xna.Framework.Media.MediaPlayer.IsRepeating = true;

## Adjusting the volume of Music

The MediaPlayer offers an overall volume value. This volume value applies to all music. In other words, if you set this value, then change the song that is being played, the same volume value will apply to the new song.

This makes Music play at full volume:

    Microsoft.Xna.Framework.Media.MediaPlayer.Volume= 1.0f;

This makes Music play at half volume:

    Microsoft.Xna.Framework.Media.MediaPlayer.Volume= 0.5f;

This makes Music play at 0 volume (effectively mutes the music):

    Microsoft.Xna.Framework.Media.MediaPlayer.Volume= 0;

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
