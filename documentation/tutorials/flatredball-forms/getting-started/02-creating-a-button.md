## Introduction

This tutorial shows you how to access FlatRedBall.Forms controls in code to perform common logic like assigning event handlers and accessing properties. For an in-depth look at every control in FlatRedBall.Forms, see the reference section: http://flatredball.com/documentation/api/flatredball-forms/controls/

## Setup

The previous tutorial showed how to create a new project with a Button control. Most controls require no additional code to work - just drag+drop the control into a screen and it will have full functionality. For this tutorial we'll create an instance of the following controls:

-   Button (multiple versions exist, but ButtonStandard is the most common)
-   CheckBox
-   ListBox
-   TextBox

All controls are present in the Components/Controls folder.

![](/media/2023-03-img_64264c34bfb86.png)

To create these controls, drag drop them into your current screen, such as **GameScreenGum** or **MainMenuGum.** If you have a GameScreen, but would like to create a screen with only UI, you can add a new MainMenu screen to your FlatRedBall project.

![](/media/2023-08-img_64d80de02a89d.png)

You can drag+drop controls into your screen. The following screenshot shows a Gum screen with four controls:

![](/media/2023-08-img_64d80ebea7f91.png)

## Working with Button

Now we can access all of our controls from the Gum screen in code. Every Gum object can be accessed in its respective screen using the Forms object. For example, to add a click event to the button:

1.  Open the project in Visual Studio
2.  Go to your screen's code file (**GameScreen.cs **or **MainMenu.cs**, for example)
3.  Add the following code to the GameScreen:

``` lang:c#
void CustomInitialize()
{
    Forms.ButtonStandardInstance.Click += HandleButtonClick;
}

private void HandleButtonClick(object sender, EventArgs e)
{
    Forms.ButtonStandardInstance.Text = "Clicked\n" + System.DateTime.Now.ToString();
}
```

This results in the button updating its text to indicate when it was last clicked: [![](/media/2017-11-12_17-03-31.gif)](/media/2017-11-12_17-03-31.gif)

### Code Details

Let's take a look at a few parts of the code. First, we should note that the code above is all compile-time protected. This means:

-   Any changes in the Gum project may result in a compile error, notifying you that something has to change in the code. For example, we are accessing the ButtonStandardInstance. If this object is removed or renamed, your code will not compile.
-   Visual Studio provides *intellisense* (code completion) to help you fill in the code

In the code above we accessed the button through the Forms.ButtonStandardInstance property. Note that ButtonStandardInstance is the same name as the object in Gum.

![](/media/2023-08-img_64d810334fa4b.png)

Notice that we are accessing the object through Forms allows us to interact with the Gum object casted as a FlatRedBall.Forms Button. Once we have access to the button we can interact with it in a standard way, such as by assigning a click event or by setting its Text property.

## Working with CheckBox

The CheckBox  control can be used to allow the user to set true/false values. Just like with Button , before we'll get a reference to the CheckBox  through the screen.

``` lang:c#
void CustomInitialize()
{
    Forms.CheckBoxInstance.Click += HandleCheckboxClicked;
}

private void HandleCheckboxClicked(object sender, EventArgs e)
{
    FlatRedBall.Debugging.Debugger.CommandLineWrite(
        "Checkbox IsChecked: " + Forms.CheckBoxInstance.IsChecked);
}
```

Clicking the CheckBox  results in the value being printed to the screen. [![](/media/2017-11-12_20-15-00.gif)](/media/2017-11-12_20-15-00.gif)

## Working with ListBox

The ListBox control is used to display options or a collection of current items to the user (such as active quests). The following code adds items to the list box whenever the user presses a key on the keyboard. Note that this code requires code in CustomActivity  to read input from the keyboard.

``` lang:c#
void CustomActivity(bool firstTimeCalled)
{
    var keyboard = InputManager.Keyboard;
    var listBox = Forms.ListBoxInstance;
    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.A))
    {
        listBox.Items.Add("Key A");
    }
    if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.B))
    {
        listBox.Items.Add("Key B");
    }
    if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.C))
    {
        listBox.Items.Add("Key C");
    }
}
```

Typing the A, B, or C characters on the keyboard results in items added to the list box: [![](/media/2017-11-12_20-16-58.gif)](/media/2017-11-12_20-16-58.gif)

## Working with TextBox

The TextBox control provides free-form input support for users to enter string values like a character's name. Note that at the time of this writing the TextBox relies on the MonoGame key bindings which do not consider different keyboard configurations (such as languages other than English). The following code can be used to react to any changes in the TextBox Text property and print it out to the screen.

``` lang:c#
void CustomInitialize()
{
    Forms.TextBoxInstance.TextChanged += HandleTextBoxTextChanged;
}

private void HandleTextBoxTextChanged(object sender, EventArgs e)
{
    FlatRedBall.Debugging.Debugger.CommandLineWrite(
        "Text box text: " + Forms.TextBoxInstance.Text);
}
```

Note that the TextChanged event will be raised for each new character (including spaces) or whenever a character is deleted. [![](/media/2017-11-12_20-23-02.gif)](/media/2017-11-12_20-23-02.gif)          
