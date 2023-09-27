## Introduction

The TimeLine object provides a graphical element for setting numeric values. This is a useful UI element if the value has a range, such as with Color values.

## Code Example

The following code creates a TimeLine which controls the ScaleX and ScaleY values of a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite").

Add the following Using statement:

    using FlatRedBall.Gui;

Add the following at class scope:

    Sprite sprite;

Add the following to Initialize after initializing FlatRedBall:

    GuiManager.IsUIEnabled = true;
    IsMouseVisible = true;

    Window window = GuiManager.AddWindow();
    window.ScaleX = 22;
    window.ScaleY = 3.5f;
    window.X = window.ScaleX;
    window.Y = window.ScaleY;

    TimeLine timeLine = new TimeLine(GuiManager.Cursor);
    window.AddWindow(timeLine);
    timeLine.ShowValues = true;
    timeLine.ScaleX = window.ScaleX - .5f;

    // The minimum and maximum values are
    // the absolute bounds of the time line
    // These may or may not match the visible
    // bounds.  If they don't, then scrolling is
    // possible.  For this example they will match
    // the visible bounds.
    timeLine.MinimumValue = 1;
    timeLine.MaximumValue = 20;
    timeLine.Y = 4.5f;

    timeLine.Start = timeLine.MinimumValue;
    timeLine.ValueWidth = timeLine.MaximumValue - timeLine.MinimumValue;

    timeLine.VerticalBarIncrement = 1;
    timeLine.SmallVerticalBarIncrement = .5f;

    timeLine.GuiChange += ChangeSpriteScale;

    sprite = SpriteManager.AddSprite("redball.bmp");

Add the following at class scope:

    private void ChangeSpriteScale(Window callingWindow)
    {
        sprite.ScaleX = sprite.ScaleY = 
            (float)((TimeLine)callingWindow).CurrentValue;

    }

![TimeLine.png](/media/migrated_media-TimeLine.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
