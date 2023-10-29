# forms-and-xbox360gamepad

### Introduction

FlatRedBall Forms has full support for control with a mouse and keyboard as well as an Xbox360GamePad. This document discusses how to enable this behavior and details about its behavior.

### Built-In Behavior

FlatRedBall.Forms controls have built-in support for gamepad navigation. Once gamepad input is enabled for Forms objects, the user can move between controls and perform common UI operations. For example, consider the following layout using default Forms elements:

![](../../../media/2022-02-img\_61fefae41a54a.png)

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
2. Select which control should begin with focus. For example, the code above sets the button as having initial focus: Forms.ButtonInstance.IsFocused = true;

Once one of the controls on a screen has focus, the gamepad can interact with it. For example, the following images and animations show interaction which can be performed with a gamepad including clicking a button, selecting items in a list box, and moving the slider. Once the ButtonInstance IsFocused is set to true, the button appears focused with a white rectangle.

![](../../../media/2022-02-img\_61ff02b7561e7.png)

Navigation between elements can be done by pressing up, down, left, or right on the analog stick or d-pad. The A button selects the control: [![](../../../media/2022-02-05\_16-06-36.gif)](../../../media/2022-02-05\_16-06-36.gif) The tab order of the items matches the order of the items in Gum. The layout has the following tab order, as shown in Gum:

![](../../../media/2022-02-img\_61ff06ae95211.png)

### OnScreenKeyboard

FlatRedBall.Forms includes a control called OnScreenKeyboard which can be used to enter text with a gamepad into a TextBox. For information on how to use this control, see the [OnScreenKeyboard page](../../../api/flatredball-forms/controls/games/onscreenkeyboard.md).

### Slider

Slider controls can be focused with the gamepad. When a Slider has focus, pressing left or right on the analog stick or d-pad moves the slider value by its SmallChange property. For more information, see the [Slider page](../../../api/flatredball-forms/controls/slider.md).

### Skipping Focus

By default any control which implements IInputReceiver can be focused through tabbing. To skip a control, set its GamepadTabbingFocusBehavior to TabbingFocusBehavior.SkipOnTab. For example, the following code would mark a TextBox as not being selected through gamepad tabbing:

```
Forms.DurationTextBox.GamepadTabbingFocusBehavior = FlatRedBall.Forms.Controls.TabbingFocusBehavior.SkipOnTab;
```

[![](../../../media/2022-02-02\_12-44-26.gif)](../../../media/2022-02-02\_12-44-26.gif)
