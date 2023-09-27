## Introduction

The Tween enables changing any numerical property on an object over a given amount of time using all of the available interpolation types provided by the Advanced Interpolation Plugin. Tween can interpolate any numerical value (like an object's X position). It works on any PositionedObject as an extension method (shown below).

## Code Example - Move Circle X

The following code shows how to tween the location of a Circle to the edge of the screen when pressing either the left or right keys. This example assumes:

1.  You have a Screen
2.  The Screen has a Circle object. For this example the Circle will be named CircleInstance.

To use Tween to change the position of the Circle based off of keyboard input:

1.  Add the following using statement:

        using StateInterpolationPlugin;

2.  Add the following to CustomActivity:

``` lang:c#
if (InputManager.Keyboard.KeyPushed(Keys.Left))
{
    CircleInstance.Tween(
        property: "X", 
        to: Camera.Main.AbsoluteLeftXEdgeAt(0), 
        during: 1, 
        interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Bounce,
        easing: FlatRedBall.Glue.StateInterpolation.Easing.Out
    );
}
if (InputManager.Keyboard.KeyPushed(Keys.Right))
{
    CircleInstance.Tween(
        property: "X",
        to: Camera.Main.AbsoluteRightXEdgeAt(0),
        during: During(1),
        interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Bounce,
        easing: FlatRedBall.Glue.StateInterpolation.Easing.Out
    );
}
```

## Code Example - Zoom Camera with Delegates

If your Camera is 2D (default, Orthogonal = true), then zooming requires modifying two values:

1.  OrthogonalHeight
2.  OrthogonalWidth (usually by calling FixAspectRatioYConstant)

Rather than creating two Tween functions that run in parallel, the Tween function allows using a delegate to assign multiple values based on a single value. The example below uses the OrthogonalHeight as the main value, and adjusts the OrthogonalWidth by calling FixAspectRatioYConstant.  

``` lang:c#
// Add the using statement to get access to the Tween extension method
using StateInterpolationPlugin;

// in your game screen:
void SetOrthogonalHeight(float newHeight)
{
    Camera.Main.OrthogonalHeight = newHeight;
    Camera.Main.FixAspectRatioYConstant();
}
void CustomActivity(bool firstTimeCalled)
{
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up))
    {
        Camera.Main.Tween(SetOrthogonalHeight,
            from: Camera.Main.OrthogonalHeight,
            to: 100,
            during: 1,// seconds
            interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Exponential,
            easing: FlatRedBall.Glue.StateInterpolation.Easing.Out
            );
    }
    if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down))
    {
        Camera.Main.Tween(SetOrthogonalHeight,
            from: Camera.Main.OrthogonalHeight,
            to: 600,
            during: 1,// seconds
            interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Exponential,
            easing: FlatRedBall.Glue.StateInterpolation.Easing.Out
            );
    }
}
```

[![](/wp-content/uploads/2016/01/2019-07-26_09-19-49.gif.md)](/wp-content/uploads/2016/01/2019-07-26_09-19-49.gif.md)

## Code Example - Lambda Assignments

Lambdas can be used to assign properties without creating dedicated functions. For example a Circle's radius can be set using the following code:

    var keyboard = InputManager.Keyboard;

    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        this.CircleInstance.Radius = 20;

        this.Tween((newValue) => CircleInstance.Radius = newValue,
            from: 20,
            to: 100,
            during: 2,
            interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Bounce,
            easing: FlatRedBall.Glue.StateInterpolation.Easing.Out);
    }

[![](/wp-content/uploads/2016/01/07_13-43-30.gif.md)](/wp-content/uploads/2016/01/07_13-43-30.gif.md)

## Tweening vs. Velocity values

The tweening logic performed internally by calling Tween is executed regardless of the variable type. That is, the variable does not need an accompanying velocity variable (such as X and XVelocity) to tween properly. Furthermore, since the tweening occurs in the TweenerManager's update, the owner of the variable that is being changed does not need to be automatically updated.
