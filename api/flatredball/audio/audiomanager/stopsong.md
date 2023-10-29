# stopsong

### Introduction

The StopSong stops the currently-playing song. Since only one song can be playing at a time, this does not take any arguments.

### Code Example

The following code stops the song when the user presses the space bar:

```lang:c#
if(InputManager.Keyboard.KeyPushed(Keys.Space))
{
    AudioManager.StopSong();
}
```

&#x20;
