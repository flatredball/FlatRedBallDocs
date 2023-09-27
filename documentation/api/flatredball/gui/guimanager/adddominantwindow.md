## Introduction

Dominant Windows are IWindows which have higher priority over regular IWindows. If the GuiManager contains any dominant IWindows then any non-dominant IWindows will not receive any input from the Cursor. Dominant IWindows are a good way to prevent the user from interacting with regular (non-dominant) IWindows when UI such as a pause screen or exit confirmation screen is visible. Multiple IWindows can be marked as dominant windows using AddDominantWindow. AddDominantWindow can be called on a regular IWindow to convert it to a dominant window. Dominant windows can be converted back to non-dominant windows using the [MakeRegularWindow](/documentation/api/flatredball/flatredball-gui/flatredball-gui-guimanager/flatredball-gui-guimanager-makeregularwindow.md "FlatRedBall.Gui.GuiManager.MakeRegularWindow") method.

## Example - AddDominantWindow, FlatRedBall Forms, and Gum

This example shows how to use AddDominantWindow to change whether a popup is the dominant window in response to UI events. This example uses a Gum screen with two objects - UserControlInstance and PopupInstance as shown in the following treeview:

![](/media/2021-09-img_614c9aa1b0ae9.png)

Visually, the layout is shown in the following image:

![](/media/2021-09-img_614c9a921e7d7.png)

The hiding and showing of the popup is controlled as shown in the following code:

    void CustomInitialize()
    {
        GumScreen.PopupInstance.Visible = false;

        Forms.ClosePopupButton.Click += (not, used) =>
        {
            GumScreen.PopupInstance.Visible = false;
            FlatRedBall.Gui.GuiManager.MakeRegularWindow(GumScreen.PopupInstance);
        };

        Forms.ShowPopupButton.Click += (not, used) =>
        {
            GumScreen.PopupInstance.Visible = true;
            FlatRedBall.Gui.GuiManager.AddDominantWindow(GumScreen.PopupInstance);
        };
        
    }

[![](/wp-content/uploads/2016/01/23_09-19-49.gif)](/wp-content/uploads/2016/01/23_09-19-49.gif)  
