## Introduction

The RemoveWindow method can be used to remove a Window from the GuiManager. The pattern for addition and removal for the GuiManager matches the other managers. In other words, you call AddWindow to add a Window to the GuiManager, and RemoveWindow to remove it.

## Code Example

Windows are added to the GuiManager through the AddWindow method:

    Button button = new Button(GuiManager.Cursor);
    GuiManager.AddWindow(button);

Windows can be removed from the GuiManager through the RemoveWindow method:

    GuiManager.RemoveWindow(button);
