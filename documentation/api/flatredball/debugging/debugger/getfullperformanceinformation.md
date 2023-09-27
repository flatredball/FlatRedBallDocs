## Introduction

The GetFullPerformanceInformation is a quick way to determine why your game may be experiencing poor performance. This method will not always reveal performance problems, but it's a great place to start when working on your game's performance.

## Code Example

This method returns a string which can be printed out to screen using the Debugger's Write. The following code can be added to your Screen's CustomActivity to see information about your game:

``` lang:c#
FlatRedBall.Debugging.Debugger.TextCorner = FlatRedBall.Debugging.Debugger.Corner.TopLeft;
FlatRedBall.Debugging.Debugger.Write(FlatRedBall.Debugging.Debugger.GetFullPerformanceInformation());
```

 
