## Introduction

The PauseAdjustedSecondsSince method returns the number of seconds that have passed since the argument time, not including time spent paused. This method is similar to the [TimeManager.SecondSince](/frb/docs/index.php?title=FlatRedBall.TimeManager.SecondsSince.md "FlatRedBall.TimeManager.SecondsSince") method, however it does not include the amount of time that the current Screen has spent paused. This method is purely a convenience method - it does not provide any functionality beyond subtracting the current time from a given time and returning the result; however it may be more expressive to use in certain situations improving the readability of code. For information on pause-adjusted timing, see [the PauseAdjustedCurrentTime page](/frb/docs/index.php?title=Glue:Reference:Screens:PauseAdjustedCurrentTime.md "Glue:Reference:Screens:PauseAdjustedCurrentTime").

## Code Example - Performing some action after a set amount of time

You can use PauseAdjustedSecondsSince to see how long the Screen has been around and compare it to a fixed number. To check if the Screen has been around for a certain amount of time:

``` lang:c#
const double TimeToWait = 4;
double timeScreenHasBeenAlive = PauseAdjustedSecondsSince(0);

if(timeScreenHasBeenAlive > TimeToWait)
{
    // Do some action here
}
```

 

## Code Example - Performing a repeating action

PauseAdjustedSecondsSince can be used to perform an action after a certain amount of time has passed. The following code shows how to perform an action every 5 seconds:

    // Assuming lastTimePerformed is a valid double:

    const double Frequency = 5;

    if(PauseAdjustedSecondsSince(lastTimePerformed) >= Frequency)
    {
        lastTimePerformed += Frequency;
        // Do the action here
    }

## Code Example - Displaying time Screen has been alive

The following code shows how to create a countdown timer. It assumes that your Screen has a valid Text object called CountDownText

    // 0 means when the Screen was first created.  The code below
    // will display how many seconds the Screen has been in existence
    CountDownText.DisplayText = this.PauseAdjustedSecondsSince(0);

## Code Example - Performing Timed Logic in Entities

Entities can limit the frequency of an action (such as firing a bullet) using the PauseAdjustedSecondsSince  method. The following code limits shooting bullets using the SecondsBetweenShots  variable:

``` lang:c#
double lastTimeBulletShot;

void CustomActivity()
{
    if(ShootingInput.WasJustPressed && 
        ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(lastTimeBulletShot) > SecondsBetweenShots)
    {
        // fire bullet
        lastTimeBulletShot = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
    }

}
```

 
