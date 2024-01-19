# TimeManager

### Introduction

The TimeManager provides functionality for measuring differences in time. The TimeManager can be used to tell how much time has passed since an event has occurred, how much time is left before a predetermined event will occur, how much time the last frame took to process and render, and to profile code performance.

### Retrieving Frame Length

For information on how long a frame has taken, see the [SecondDifference](seconddifference.md) page.

### Screen Time

The TimeManager.ScreenCurrentTime returns the number of seconds since the current screen was created. This value can be used to find the amount of time that has passed since an event has occurred, or mark the time for when an event should occur. The following code shows how to check how long it has been since an Entity has been created and then makes the CircleInstance within the entity invisible after five seconds.

```
// We'll store the value outside of any functions
// so we can set it in CustomInitialize but check against
// it in CustomActivity
double timeInitialized;

private void CustomInitialize()
{
    // Store off the time...
    timeInitialized = TimeManager.CurrentScreenTime;

}

private void CustomActivity()
{
    // Check if more than 5 seconds have passed.  If so...
    if(TimeManager.CurrentScreenSecondsSince(timeInitialized) > 5.0)
    {
        // ... make the circle invisible
        this.CircleInstance.Visible = false;
    }
}
```

### CurrentScreenTime vs CurrentTime vs CurrentSystemTime

The TimeManager provides 3 times:

* CurrentScreenTime
* CurrentTime (also known as game time)
* CurrentSystemTime

If you are writing code for game play, such as timing bullet shots or enemy spawns, you should use CurrentScreenTime and CurrentScreenSecondsSince. Since most of the timing code in a game is game play related, you will usually use these values. For a deeper understanding let's look at how the three values differ

* CurrentScreenTime reports the number of seconds since the current screen has started. The value reported by CurrentScreenTime will remain the same throughout a frame. This means it will be the same in any CustomActivity until the frame ends. This time is impacted by [TimeManager.TimeFactor](timefactor.md) and will not increment if the current screen is paused. This value resets back to 0 when moving to a new Screen.
* CurrentTime, also known as game time, reports the number of seconds since the game has started. Like CurrentScreenTime, this value will also remain the same throughout the current frame. This time is impacted by [TimeManager.TimeFactor](timefactor.md). It will continue to increment when a screen is paused, and it will never reset back to 0 unless a game is completely stopped and restarted. Since this value does not pause when a screen is paused, it can be used to uniquely identify a frame.
* CurrentSystemTime reports the number of seconds since the game has started. Unlike CurrentTime, this value will continually change throughout a frame, and it is not impacted by [TimeManager.TimeFactor](timefactor.md). This time is _real world_ time.

### TimeManager and GameTime

MonoGame provides a GameTime reference in the Game's Update and Draw methods, so question of which to use may arise - GameTime or the TimeManager? The TimeManager's CurrentTime is equal to the Game's TotalGameTime.TotalSeconds property so in Update they can be used interchangeably. Since the TimeManager is always in scope it is recommended for consistency to use this instead of passing references to the GameTime. \[subpages depth="1"]

###
