## Introduction

The PauseAdjustedCurrentTime property returns the amount of time (in seconds) since the Screen has started, excluding the amount of time the Screen has been paused.

## Code Example

The following if statement can be used to check if the Screen has been active and unpaused for five seconds:

    const float amountOfUnpausedTimeToCheckFor = 5;
    if(ScreenManager.CurrentScreen.PausedAdjustedCurrentTime > amountOfUnpausedTimeToCheckFor)
    {
        // More than 5 seconds have passed since the Screen was first initialized
    }
