## Introduction

The ReplaceMemberUIElement method replaces the current UI element for the argument member with the argument UI element. In most cases all behavior for updating the UI element from the SelectedObject's current state as well as setting the SelectObject's member in response to the UI element's actions must be manually set up. This can be done through events.

## Code Example

The following code creates a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") PropertyGrid. To keep the code simple, the only member included is the Alpha member. A [TimeLine](/frb/docs/index.php?title=FlatRedBall.Gui.TimeLine "FlatRedBall.Gui.TimeLine") is used instead of the default [UpDown](/frb/docs/index.php?title=FlatRedBall.Gui.UpDown&action=edit&redlink=1 "FlatRedBall.Gui.UpDown (page does not exist)") UI element to provide an interface to the Alpha member.

Add the following using statement:

    using FlatRedBall.Gui;

Add the following to Initialize after initializing FlatRedBall:

    sprite = SpriteManager.AddSprite("redball.bmp");

    propertyGrid = GuiManager.AddPropertyGrid<Sprite>();
    propertyGrid.SelectedObject = sprite;

    propertyGrid.ExcludeAllMembers();

    propertyGrid.IncludeMember("Alpha");

    GuiManager.IsUIEnabled = true;
    IsMouseVisible = true;

    timeLine = new TimeLine(GuiManager.Cursor);
    timeLine.ScaleX = 6;
    timeLine.MinimumValue = 0;
    timeLine.MaximumValue = 1;

    timeLine.Start = 0;
    timeLine.ValueWidth = 1;

    timeLine.GuiChange += ChangeSpriteAlpha;
    propertyGrid.ReplaceMemberUIElement("Alpha", timeLine);

    propertyGrid.AfterUpdateDisplayedProperties += UpdateUI;
    propertyGrid.X = propertyGrid.ScaleX;
    propertyGrid.Y = propertyGrid.ScaleY;

Add the following to Update:

    propertyGrid.UpdateDisplayedProperties();

Add the following two methods at class scope:

    private void ChangeSpriteAlpha(Window callingWindow)
    {
        sprite.Alpha = (float)timeLine.CurrentValue;

    }

    private void UpdateUI(Window callingwindow)
    {
        timeLine.CurrentValue = sprite.Alpha;
    }

![ReplaceMemberUIElement.png](/media/migrated_media-ReplaceMemberUIElement.png)
