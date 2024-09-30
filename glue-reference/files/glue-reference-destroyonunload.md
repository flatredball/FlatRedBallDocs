# Destroy on Unload

### Introduction

The DestroyOnUnload value controls whether music files are destroyed when the Screen is destroyed. This value can be set to false if you want the song to continue playing into the next Screen. For this to occur, the Screen which you are transitioning into must also have a reference to the same Song file.

### Example Implementation

To add a song that plays on two screens:

1. Create two screens (such as GameScreen and PostGameScreen)
2. Drag+drop a .mp3 or .wma file into GameScreen
3. Drag+drop the file from the GameScreen into the PostGameScreen's Files. Be sure that the name of the file is the same in both screens ![SameNamedMp3s.png](../../.gitbook/assets/migrated\_media-SameNamedMp3s.png)
4. Set the "DestroyOnUnload" value to "False" on the Song you want to continue playing. If you set it on both, then you will be able to go back and forth between the two Screens and the song will continue playing. ![DestroyOnUnload.png](../../.gitbook/assets/migrated\_media-DestroyOnUnload.png)
5. Write custom code in your game to transition between the two Screens - notice that the song continues to play despite the transition.

Things to remember:

* You do not need to manually play Songs that have been added to Screens through Glue. Doing so may make your song restart.
