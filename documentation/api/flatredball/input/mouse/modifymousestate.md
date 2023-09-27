## Introduction

The ModifyMouseState event is an event you can add to the Mouse object to set/modify the Microsoft.Xna.Framework.Input.MouseState used by the mouse for positioning and clicking. This is useful if you are working on a platform which does not have mouse input but you would like to simulate mouse input, or if you are working on a platform which requires modifications of the mouse input.

## Code Example

The following code can be used in a WPF project to properly set the mouse position. Add the following to your Game's Initialize function:

    FlatRedBall.Input.Mouse.ModifyMouseState += HandleModifyMouseState;

Add the following implementation:

    private void HandleModifyMouseState(ref Microsoft.Xna.Framework.Input.MouseState mouseState)
    {
        var point = Control.MousePosition;

        var screen = mFrbControl.PointFromScreen(new System.Windows.Point(point.X, point.Y));
        var newMouseState = new Microsoft.Xna.Framework.Input.MouseState(
            MathFunctions.RoundToInt(screen.X),
            MathFunctions.RoundToInt(screen.Y),
            mouseState.ScrollWheelValue,
            mouseState.LeftButton,
            mouseState.MiddleButton,
            mouseState.RightButton,
            mouseState.XButton1,
            mouseState.XButton2);
        mouseState = newMouseState;
    }
