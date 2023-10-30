# onscreenkeyboard

### Introduction

The OnScreenKeyboard, also referred to as a "software keyboard", can be used to enter text in a TextBox using a GamePad. Console games and games which use a controller as a primary input device will usually include some form of OnScreenKeyboard for text entry. Although the OnScreenKeyboard is primarily designed to be used with a GamePad, the mouse can also be used to click on the individual keys. The OnScreenKeyboard must always be paired with a TextBox. Creating an OnScreenKeyboard without pairing it to a TextBox will result in runtime exceptions when the user attempts to click on one of the keys. 

<figure><img src="../../../../../media/2021-02-2021_February_19_210140.gif" alt=""><figcaption></figcaption></figure>



### Layout Requirements

Strictly speaking, the OnScreenKeyboard has no layout requirements - it can have any controls. However, to be functional, it must contain at least one object implementing ButtonBehavior. A typical keyboard will have many ButtonBehavior-implementing instances - one for each key. Buttons can be either buttons with special functionality or regular keys. A button is designated as being special by its name. The following names provide special functionality:

* KeyBackspace - deletes the character before the caret
* KeyReturn - currently not functional as of February 19, 2021, but will provide functionality in future versions
* KeyLeft - moves the caret to the left one character
* KeyRight - moves the caret to the right one character
* KeySpace - inserts the space character at the current caret index

Any button which does not have one of the names listed above will insert the same character as its text into the text box. This behavior allows keyboards to be fully customizable - they can provide as many or as few characters as desired.

![](../../../../../media/2021-02-img_6030989f78e65.png)

Note that although the diagram above displays buttons as direct children of the OnScreenKeyboard, buttons can be added as children of containers, and the hierarchy can be of any depth. All buttons will be recursively found and used by the keyboard.

### AssociatedTextBox

The OnScreenKeyboard must be paired with a TextBox instance. Usually this is done by placing an instance of an OnScreenKeyboard in the same Screen or Component as a TextBox, and adding the following code in the initialization of the Forms object:

```
this.KeyboardInstance.AssociatedTextBox = this.TextBoxInstance;
```

The code above assumes that the OnScreenKeyboard and TextBox are named KeyboardInstance and TextBoxInstance, respectively. Once this association is made, clicking on a key will modify the TextBox. Note that by default, the TextBox will lose focus when a button on the OnScreenKeyboard is clicked. This can be solved by setting the TextBox instance's LosesFocusWhenClickedOff to false.

### Implementation Example

As mentioned above, the OnScreenKeyboard requires an associated TextBox. The easiest approach for implementing an OnScreenKeyboard is to place both controls in a Gum page.

![](../../../../../media/2021-02-img_6031dc3ac3a39.png)

This implementation will create a matching Forms class. For example, if above is in GameScreenGum, then your project would have a class called \*\*GameScreenGumForms. \*\*This Forms class will contain both the Keyboard and TextBox so the setup can be performed as shown in the following code: &#x20;

```
partial void CustomInitialize () 
{
    Forms.KeyboardInstance.AssociatedTextBox = this.TextBoxInstance;
    Forms.TextBoxInstance.LosesFocusWhenClickedOff = false;
}
```

Alternatively, initialization can happen in the FlatRedBall Screen using the Forms object as shown in the following code snippet:

```
void CustomInitialize()
{
    this.Forms.KeyboardInstance.AssociatedTextBox = this.Forms.TextBoxInstance;
    this.Forms.TextBoxInstance.IsCaretVisibleWhenNotFocused = true;
}
```

### Implementation Example - Gamepad Support

For this example, the following Gum layout will be used:

![](../../../../../media/2022-02-img_62005c691db5c.png)

Note that the button will not be used except to show that tabbing to a different control is possible when the keyboard is not active. The following code enables full control of the text box with the gamepad:

```
// Enable gamepad control
GuiManager.GamePadsForUiControl.Add(InputManager.Xbox360GamePads[0]);

// Connect the keyboard with the textbox
Forms.KeyboardInstance.AssociatedTextBox = Forms.TextBoxInstance;

// Initially hide the keyboard - it will be shown when gamepad presses
// the A button on the textbox.
Forms.KeyboardInstance.IsVisible = false;

// Assign the event for when a controller button is pushed
Forms.TextBoxInstance.ControllerButtonPushed += (button) =>
{
    // If the A button is pressed...
    if (button == Xbox360GamePad.Button.A)
    {
        // Select the entire text on the text box to make it easy
        // to replace
        Forms.TextBoxInstance.SelectionStart = 0;
        Forms.TextBoxInstance.SelectionLength = Forms.TextBoxInstance.Text.Length;

        // Continue to show the Caret on the textbox so the user knows
        // what is being edited
        Forms.TextBoxInstance.IsCaretVisibleWhenNotFocused = true;

        // Shwo the text box
        Forms.KeyboardInstance.IsVisible = true;

        // And let the keyboard receive input
        InputManager.InputReceiver = Forms.KeyboardInstance;
    }
};

// If the user confirms (presses the enter button or presses either
// start or back on the gamepad)...
Forms.KeyboardInstance.ConfirmSelected += () =>
{
    // Don't show the caret on the text box when it is not focused
    Forms.TextBoxInstance.IsCaretVisibleWhenNotFocused = false;

    // Focus the textbox again so that the user can tab away
    Forms.TextBoxInstance.IsFocused = true;

    // Hide the keyboard
    Forms.KeyboardInstance.IsVisible = false;
};

// Sets the button focus away from the keyboard so we can select the keyboard manually
Forms.ButtonInstance.IsFocused = true;
```

The code above results in a fully functional keyboard controlled by the gamepad, as shown in the following animation: 

<figure><img src="../../../../../media/2021-02-06_16-42-36.gif" alt=""><figcaption></figcaption></figure>


