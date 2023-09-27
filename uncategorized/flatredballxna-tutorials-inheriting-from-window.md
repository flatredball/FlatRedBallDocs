## Introduction

The [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window.md "FlatRedBall.Gui.Window") class is the base class for all UI elements in FlatRedBall. It also provides the basic class for constructing your own custom UI element. Creating your own Window is like creating your own class in C#. Available types in C# include float, int, string, and bytes. In the FlatRedBall GUI these types include [TextBoxes](/frb/docs/index.php?title=FlatRedBall.Gui.TextBox.md "FlatRedBall.Gui.TextBox"), [TextDisplays](/frb/docs/index.php?title=FlatRedBall.Gui.TextDisplay.md "FlatRedBall.Gui.TextDisplay"), [Buttons](/frb/docs/index.php?title=FlatRedBall.Gui.Button.md "FlatRedBall.Gui.Button"), [ScrollBars](/frb/docs/index.php?title=FlatRedBall.Gui.ScrollBar.md "FlatRedBall.Gui.ScrollBar"), and [ListBoxes](/frb/docs/index.php?title=FlatRedBall.Gui.ListBox.md "FlatRedBall.Gui.ListBox"). These elements can be combined to create many types of custom UI objects.

## Creating a Window

This article contains a class called NumericalComboBox. This is a UI element which controls the brush size of a few tools in the open-source image editing software [Paint.NET](http://www.getpaint.net/).

![NumericalComboBox.png](/media/migrated_media-NumericalComboBox.png)

Files Used: [NumericalComboBox.cs](/frb/docs/images/f/f2/NumericalComboBox.cs.md "NumericalComboBox.cs"), [EventArgs.cs](/frb/docs/images/5/5e/EventArgs.cs.md "EventArgs.cs")

Adding the following using statements:

    using FlatRedBall.Gui;

Adding the following in Initialize after initializing FlatRedBall:

    IsMouseVisible = true;
    GuiManager.IsUIEnabled = true;

    NumericalComboBox numericalComboBox = new NumericalComboBox(GuiManager.Cursor);
    GuiManager.AddWindow(numericalComboBox);

    numericalComboBox.Y = 35;

    mSprite = SpriteManager.AddSprite("redball.bmp");
    numericalComboBox.Value = (int)mSprite.ScaleX;
    numericalComboBox.ValueChange += new EventHandler<EventArgs<int>>(ValueChange);

Adding the following at class scope:

    void ValueChange(object sender, EventArgs<int> e)
    {
        mSprite.ScaleX = e.Data;
    }

![NumericalComboBoxInEngine.png](/media/migrated_media-NumericalComboBoxInEngine.png)
