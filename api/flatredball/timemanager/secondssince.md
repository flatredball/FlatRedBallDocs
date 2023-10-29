## Introduction

The SecondsSince method can be used to detect how many seconds have passed since a given time. This method is often used in combination with the CurrentTime property.

## Code Example

The following would show how to perform a rapid-fire system if the user has pressed the rapid fire button (cursor's PrimayPush). Keep track of the variable at class scope:

    double mLastShotFired = -1000; // make it a large negative numbers so the first shot will always fire
    double mShotFrequency = .5; // this means 2 shots per second.  This should probably be a Glue variable if using Glue

Test for shots in the update method:

    Cursor cursor = FlatRedBall.Gui.GuiManager.Cursor;
    if(cursor.PrimaryDown && TimeManager.SecondsSince(mLastShotFired) > mShotFrequency)
    {
       FireShot(); // do whatever you need to do to fire
       mLastShotFired = TimeManager.CurrentTime;
    }

## Why use SecondsSince?

If you want, instead of using SecondsSince you can simply subtract the values. For example, the two are equivalent:

    double timePassed = TimeManager.SecondsSince(somePreviousTime);
    double timePassed2 = TimeManager.CurrentTime - somePreviousTime;

Both will be identical; however, the SecondsSince method reads a little cleaner. It's purely for readability and convenience. You may not like using the SecondsSince method, but the FlatRedBall team has found this method rather handy and we always use it instead of the subtraction method.
