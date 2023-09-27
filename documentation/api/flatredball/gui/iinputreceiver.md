## Introduction

The IInputReceiver interface provides methods and properties common to all UI elements which can receive [Keyboard](/frb/docs/index.php?title=FlatRedBall.Input.Keyboard.md "FlatRedBall.Input.Keyboard") input. IInputReceiver can be implemented in custom classes (such as Glue Entities) to enable more advanced input focus logic and to prevent multiple objects from receiving input. IInputReceiver is also used in the old FlatRedBall UI which is implemented in many FRB tools.

## Preventing multiple objects from receiving input

The IInputReceiver interface is designed to prevent multiple objects from receiving input. The most common way to do this is to have the IInputReceiver process input in its ReceiveInput method, then clear the input. For example, the following code can be used to move an object and clear the input.

    // This assumes that the code exists in an object (such as a Glue Entity)
    // which implements IInputReceiver
    public void ReceiveInput()
    {
       // First let's process the input:
       // This assumes that MovementSpeed is a valid variable - like a variable defined on an Entity in Glue
       Keyboard keyboard = InputManager.Keyboard;
       if(keyboard.KeyDown(Keys.Left))
       {
           this.XVelocity = -MovementSpeed;
       }
       else if(keyboard.KeyDown(Keys.Right))
       {
           this.XVelocity = MovementSpeed;
       }
       else
       {
           this.XVelocity = 0;
       }
       // Prevents anything else from getting keyboard input this frame
       keyboard.Clear();
    }

This method is especially effective because ReceiveInput is called prior to the game's activity. For more information, see [the ReceiveInput page](/frb/docs/index.php?title=FlatRedBall.Gui.IInputReceiver.ReceiveInput.md "FlatRedBall.Gui.IInputReceiver.ReceiveInput").

## FlatRedBall GUI Classes Implementing IInputReceiver

The following lists the classes which implement the IInputReceiver interface. Note that these are all classes which are part of the FRB GUI which only functions in FRB XNA 3.1, thus they are discouraged for use:

-   [CollapseListBox](/frb/docs/index.php?title=FlatRedBall.Gui.CollapseListBox.md "FlatRedBall.Gui.CollapseListBox") and [ListBox](/frb/docs/index.php?title=FlatRedBall.Gui.ListBox.md "FlatRedBall.Gui.ListBox")
-   [MessageBox](/frb/docs/index.php?title=FlatRedBall.Gui.MessageBox&action=edit&redlink=1.md "FlatRedBall.Gui.MessageBox (page does not exist)")
-   [OkCancelWindow](/frb/docs/index.php?title=FlatRedBall.Gui.OkCancelWindow.md "FlatRedBall.Gui.OkCancelWindow")
-   [TextBox](/frb/docs/index.php?title=FlatRedBall.Gui.TextBox.md "FlatRedBall.Gui.TextBox")
-   [UpDown](/frb/docs/index.php?title=FlatRedBall.Gui.UpDown&action=edit&redlink=1.md "FlatRedBall.Gui.UpDown (page does not exist)")

## Gaining Focus

IInputReceivers automatically gain focus when the user clicks on them. They can also be given focus in code. The following code creates a TextBox that automatically has focus:

Add the following using statements:

    using FlatRedBall.Gui;
    using FlatRedBall.Input;

Add the following to Initialize after initializing FlatRedBall:

    IsMouseVisible = true;
    GuiManager.IsUIEnabled = true;

    TextBox textBox = new TextBox(GuiManager.Cursor);
    GuiManager.AddWindow(textBox);
    textBox.ScaleX = 5;
    InputManager.ReceivingInput = textBox;

![IInputReceiverFocus.png](/media/migrated_media-IInputReceiverFocus.png)

## TakingInput

IInputReceivers automatically receive input from the keyboard when they have focus. To prevent this from occurring the TakingInput property can be set to false:

    // assuming the receiver is a valid receiver
    receiver.TakingInput = false; // Will not be able to take input from the keyboard

## IInputReceiver Members

-   [FlatRedBall.Gui.IInputReceiver.ReceiveInput](/frb/docs/index.php?title=FlatRedBall.Gui.IInputReceiver.ReceiveInput.md "FlatRedBall.Gui.IInputReceiver.ReceiveInput")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
