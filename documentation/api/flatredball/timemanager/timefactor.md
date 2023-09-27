## Introduction

TimeFactor is a property which can be used to make time run slower or faster. By default TimeFactor is set to 1, meaning time runs regularly. A value of 2 will make time run twice as fast. TimeFactor can modify the rate at which [Currenttime](/frb/docs/index.php?title=FlatRedBall.TimeManager.CurrentTime.md "FlatRedBall.TimeManager.CurrentTime") increases and also multiplies the [SecondDifference](/frb/docs/index.php?title=FlatRedBall.TimeManager.SecondDifference.md "FlatRedBall.TimeManager.SecondDifference") value.

## Example

The following code will make time run twice as fast:

    TimeManager.TimeFactor = 2;

The following code will make the game run at half the speed (slow motion):

    TimeManager.TimeFactor = .5f;
