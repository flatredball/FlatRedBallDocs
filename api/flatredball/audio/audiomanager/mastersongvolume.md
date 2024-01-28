# MasterSongVolume

### Introduction

MasterSongVolume is the default value used when calling PlaySong. This value can be null if no default is used, or a value between 0 and 1 can be assigned where 1 is full volume and 0 is silent.

Setting MasterSongVolume sets the currently playing song's volume as well if any of the following are true:

* The Song is a MonoGame/FNA Song which has been played through the AudioManager's PlaySong method
* The Song is a MonoGame/FNA Song which has been played through the XNA MediaPlayer
* The Song is an ISong (such as an NAudio\_Song) and has been played thorugh the AudioManager's PlaySong method.

Setting MasterSongVolume does not affect the volume of NAudio\_Song instances which have been played through the NAudio\_Song's Play method. For more information, see the [NAudio\_Song page](../../../naudio/naudio\_song.md).
