# TimeFactor

### Introduction

TimeFactor is a property which can be used to make time run slower or faster. By default TimeFactor is set to 1, meaning time runs regularly. A value of 2 will make time run twice as fast.&#x20;

Changing TimeFactor affects the following properties:

* SecondDifference - Increasing the TimeFactor reduces SecondDifference. In other words, if TimeFactor is set to 2, then the game runs twice as fast, so the amount of time each frame is half as long.
* CurrentTime - Increasing TimeFactor makes CurrentTime increase faster. In other words, if TimeFactor is set to 2, then CurrentTime advances twice as fast.
* CurrentScreenTime - Increasing TimeFactor makes CurrentScreenTime increase faster, similar to CurrentTime.

### Example

The following code will make time run twice as fast:

```csharp
TimeManager.TimeFactor = 2;
```

The following code will make the game run at half the speed (slow motion):

```csharp
TimeManager.TimeFactor = .5f;
```
