# GraphicalUiElement as IWindow

### Introduction

FlatRedBall provides built-in logic which can be used for games that need cursor or touch-based UI. The three classes/interfaces providing this functionality are:

* Cursor - an object providing cursor interaction like push, click, and hit testing with UI objects
* GuiManager - a FlatRedBall manager which stores all live windows and drives every-frame logic like raising UI events
* IWindow - an interface which allows an object to be managed by the GuiManager

Gum components implement the IWindow interface, and all component instances are automatically added to the GuiManager. In other words, if you have a component in your FlatRedBall screen, it can be used as an IWindow with no additional code.

Note that the usual method for interacting with Gum objects with a Cursor is to use FlatRedBall.Forms. This document explains how to manually interact with Gum objects if the extra flexibility is needed.

### Code Example - Dragging a Window

The following code shows how to grab and drag a Gum component instance with the mouse. Note that the following requirements must be met:

1. On Windows the mouse must be visible
2. The Gum object must be a component. Standard elements (such as ColoredRectangle instances) can also be moved with the mouse, but for simplicity this guide uses a component
3. The component must have its **Has Events** value set to true. This is true by default for all components.

```lang:c#
// Use the isGrabbed value to keep track of whether the user
// grabbed the object.
bool isGrabbed = false;

void CustomInitialize()
{

}

void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;
    if (isGrabbed)
    {
        // Assuming there is a component instance in the screen called
        // UserControlInstance
        this.UserControlInstance.X += cursor.ScreenXChange;
        this.UserControlInstance.Y += cursor.ScreenYChange;
    }
    if (cursor.PrimaryPush && cursor.WindowOver == UserControlInstance)
    {
        isGrabbed = true;
    }

    if (cursor.PrimaryClick)
    {
        isGrabbed = false;
    }
}
```



<figure><img src="../media/2019-12-2019\_December\_07\_151411.gif" alt=""><figcaption></figcaption></figure>



### GuiManager Membership

Gum component instances which are added to a Gum screen in the Gum UI tool will automatically be added to the FlatRedBall GuiManager. Components which are created manually in code must be manually added to the GuiManager. Fortunately, calling AddToManagers is all that is needed. The following code is similar to the code above, except it manually creates a user control instance in code rather than using one created in a Gum screen.

```lang:c#
bool isGrabbed = false;

GumRuntimes.DefaultForms.UserControlRuntime userControl;

void CustomInitialize()
{
    userControl = new GumRuntimes.DefaultForms.UserControlRuntime();
    // Calling AddToManagers adds the userControl to all managers for rendering
    // and UI interaction
    userControl.AddToManagers();
}

void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;
    if (isGrabbed)
    {
        this.userControl.X += cursor.ScreenXChange;
        this.userControl.Y += cursor.ScreenYChange;
    }
    if (cursor.PrimaryPush && cursor.WindowOver == userControl)
    {
        isGrabbed = true;
    }

    if (cursor.PrimaryClick)
    {
        isGrabbed = false;
    }
}
```

&#x20;     &#x20;
