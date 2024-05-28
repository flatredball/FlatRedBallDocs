# Forms and Xbox360GamePad

### Introduction

FlatRedBall Forms has full support for control with a mouse and keyboard as well as an Xbox360GamePad. This document discusses how to enable this behavior and details about its behavior.

### Built-In Behavior

FlatRedBall.Forms controls have built-in support for gamepad navigation. Once gamepad input is enabled for Forms objects, the user can move between controls and perform common UI operations. For example, consider the following layout using default Forms elements:

![](../../media/2022-02-img\_61fefae41a54a.png)

The layout above contains the following interactive Forms elements:

* Button
* CheckBox
* ComboBox
* ListBox
* RadioButton
* Slider
* TextBox

To enable gamepad interaction with these elements:

1.  Add the which gamepads can control focus and selection using the GuiManager.GamePadsForUiControl list as shown in the following snipet:

    ```
    GuiManager.GamePadsForUiControl.Add(InputManager.Xbox360GamePads[0]);
    ```

    This code can be added anywhere, and gamepads can be added and removed to allow only certain gamepads to control the UI.
2. Select which control should begin with focus. For example, the code above sets the button as having initial focus:  `Forms.ButtonInstance.IsFocused = true;`

Once one of the controls on a screen has focus, the gamepad can interact with it. For example, the following images and animations show interaction which can be performed with a gamepad including clicking a button, selecting items in a list box, and moving the slider. Once the ButtonInstance IsFocused is set to true, the button appears focused with a white rectangle.

![](../../media/2022-02-img\_61ff02b7561e7.png)

Navigation between elements can be done by pressing up, down, left, or right on the analog stick or d-pad. The A button selects the control:

<figure><img src="../../media/2022-02-05_16-06-36.gif" alt=""><figcaption></figcaption></figure>

The tab order of the items matches the order of the items in Gum. The layout has the following tab order, as shown in Gum:

![](../../media/2022-02-img\_61ff06ae95211.png)

### ListBox

ListBoxes can have two focused states:

* Top-level focus (the entire list box has focus)
* Item focus - the items within the list box have focus

When the list box has top-level focus, tabbing between items selects the next sibling item. For example, the following image shows the ListBox on the top left of the screen having focus. Pressing "down" to tab to the next control results in the ComboBox (with the word "Impossible") gaining focus.

<figure><img src="../../.gitbook/assets/image (7).png" alt=""><figcaption><p>A ListBox with top-level focus can tab to the next control</p></figcaption></figure>

If a ListBox has item focus ( its `DoListItemsHaveFocus` property is set to true), then tabbing up and down selects the next or previous items in the list, as shown in the following animation:

<figure><img src="../../.gitbook/assets/14_21 07 41.gif" alt=""><figcaption><p>Items in a list box are highlighted if DoListItemsHaveFocus is set to true.</p></figcaption></figure>

The DoListItemsHaveFocus property can be set to true in the following ways:

1. By explicitly setting the value in code, either directly or through data binding.
2. By giving the ListBox top-level focus, then pressing the confirm button on the gamepad. This is similar to pressing the confirm button on a ComboBox.

This two-layer selection mode is useful if the list box is part of a more complex screen and you would like the player to be able to navigate between controls. By contrast, if your screen contains a list box which must be selected before proceeding (such as a level select screen), then you may want to give the ListBox focus and also set its `DoListItemsHaveFocus` to true on screen CustomInitialize.

Note that if an item is selected with the gamepad's confirm button, then the item appears selected and `DoListItemsHaveFocus` is set to false, giving the list box top-level focus.

### OnScreenKeyboard

FlatRedBall.Forms includes a control called OnScreenKeyboard which can be used to enter text with a gamepad into a TextBox. For information on how to use this control, see the [OnScreenKeyboard page](../../api/flatredball-forms/controls/games/onscreenkeyboard.md).

### Slider

Slider controls can be focused with the gamepad. When a Slider has focus, pressing left or right on the analog stick or d-pad moves the slider value by its SmallChange property. For more information, see the [Slider page](../../api/flatredball-forms/controls/slider.md).

### Skipping Focus

By default any control which implements IInputReceiver can be focused through tabbing. To skip a control, set its GamepadTabbingFocusBehavior to TabbingFocusBehavior.SkipOnTab. For example, the following code would mark a TextBox as not being selected through gamepad tabbing:

```
Forms.DurationTextBox.GamepadTabbingFocusBehavior = FlatRedBall.Forms.Controls.TabbingFocusBehavior.SkipOnTab;
```

<figure><img src="../../media/2022-02-02_12-44-26.gif" alt=""><figcaption></figcaption></figure>
