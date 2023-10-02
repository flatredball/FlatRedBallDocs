# interpolateto

### Introduction

InterpolateTo creates a tweener which will interpolate to the argument state using the standard interpolation types (such as bounce).

### Code Example

```lang:c#
gumInstance.InterpolateTo(GumRuntimes.ComponentType.CategoryName.TargetState, 
    secondsToTake: 3, 
    interpolationType: FlatRedBall.Glue.StateInterpolation.InterpolationType.Bounce,
    easing:FlatRedBall.Glue.StateInterpolation.Easing.Out);
```

&#x20;
