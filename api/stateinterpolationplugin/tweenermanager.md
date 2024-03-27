# TweenerManager

### Introduction

The TweenerManager is responsible for performing ever-frame logic on tweeners. It can be used to create new Tweeners, inspect existing Tweeners, and interrupt existing Tweeners.

### Code Example - TweenAsync

TweenAsync can be used to perform tweening logic using an Action, allowing the assignment of any property. Unlike the Tween function, TweenAsync can operate on any object such as a Gum GraphicalUiElement instance.

The following code shows how to tween an object's X from 0 to 100.

```csharp
await TweenerManager.TweenAsync(
    owner: GumObjectInstance,
    assignmentAction: (newValue) => GumObjectInstance.X = newValue,
    from: 0,
    to: 100,
    during: 3, // seconds
    interpolation: InterpolationType.Quadratic,
    easing: Easing.Out);
```

