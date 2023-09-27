## Introduction

The TextBox control can be used to let the user enter text input such as a profile name. [![](/wp-content/uploads/2017/12/2017-12-24_20-24-50.gif)](/wp-content/uploads/2017/12/2017-12-24_20-24-50.gif)

## Layout Requirements

The TextBox control requires:

-   An Text named **TextInstance**
-   An object named **CaretInstance** of any type

Although not required, the TextInstance should be contained within an object that has its **Clips Children **set to **True.** This can be a container within the TextBox, of the TextBox component can have its **Clips Children** value set to true.

![](/media/2017-12-img_5a48d720c1694.png)

Optionally, the TextBox can contain:

-   An object named **SelectionInstance**

![](/media/2019-03-img_5c8d84e285606.png)

## TextChanged Event

The TextChanged event is raised whenever the Text on the TextBox changes. Keep in mind this occurs on every character changed, so if the user types multiple characters, the event will be raised for every character, as shown in the following code example:

``` lang:c#
TextBox textBox;

void CustomInitialize()
{
    textBox = TutorialScreenGum
        .GetGraphicalUiElementByName("TextBoxInstance")
        .FormsControlAsObject as TextBox;

    textBox.TextChanged += HandleTextChanged;
}

private void HandleTextChanged(object sender, EventArgs e)
{
    FlatRedBall.Debugging.Debugger.CommandLineWrite(
        $"Text changed to {textBox.Text}");
}
```

[![](/wp-content/uploads/2017/12/2017-12-25_14-40-10.gif)](/wp-content/uploads/2017/12/2017-12-25_14-40-10.gif)

## LosesFocusWhenClickedOff

By default the LosesFocusWhenClickedOff property is set to true. If this property is true, the TextBox instance will lose the focus when the user clicks elsewhere. This functionality matches functionality in other UI systems such as WPF and Xamarin.Forms. If a TextBox is to be associated with an OnScreenKeyboard, you may want to set this property to false so the caret doesn't become invisible when clicking on the OnScreenKeyboard buttons.
