## Introduction

MenuStrips can be used to create a compact set of commands that users can access using the mouse. This UI element is a common way to interact with a program. Usually the first two commands in a MenuStrip are "File" and "Edit"; however, the MenuStrip can be used to provide access to any command.

## Code Example

The following code example creates a MenuStrip with a File MenuItem. The File MenuItem will contain two MenuItems - Load and Save. For brevity, this code example will not use the resulting files selected by the [FileWindow](/frb/docs/index.php?title=FlatRedBall.Gui.FileWindow "FlatRedBall.Gui.FileWindow"). For information on how to use the selected file, see the [FileWindow](/frb/docs/index.php?title=FlatRedBall.Gui.FileWindow "FlatRedBall.Gui.FileWindow") wiki entry.

Add the following using statement:

    using FlatRedBall.Gui;

Add the following to Initialize after initializing FlatRedBall:

    IsMouseVisible = true;
    GuiManager.IsUIEnabled = true;

    MenuStrip menuStrip = GuiManager.AddMenuStrip();

    MenuItem fileMenuItem = menuStrip.AddItem("File");

    fileMenuItem.AddItem("Load").Click += LoadClick;
    fileMenuItem.AddItem("Save").Click += SaveClick;

Add the following at class scope:

    private void LoadClick(Window callingWindow)
    {
        FileWindow fileWindow = GuiManager.AddFileWindow();
        fileWindow.SetToLoad();
    }

    private void SaveClick(Window callingWindow)
    {
        FileWindow fileWindow = GuiManager.AddFileWindow();
        fileWindow.SetToSave();
    }

![MenuStrip.png](/media/migrated_media-MenuStrip.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
