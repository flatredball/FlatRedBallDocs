# Accessing Forms Events in Gum Runtimes

### Introduction

Your game may require subscribing to various Forms for every instance of a particular type of Forms object. For example, you may want to play a sound effect whenever a Forms button is clicked. Subscribing to every instance of every Forms object can be difficult to maintain. Instead, we can create events inside the Gum runtime classes to handle behavior for every instance.

### Using Button Runtimes to Access Forms Controls

Every Forms object is backed by a Gum "runtime" object. For information about Forms vs Gum, see the [Forms vs Gum](getting-started/forms-and-gum-objects.md) tutorial. For example, the Button class has a number of types of Gum runtimes:

* ButtonClose
* ButtonConfirm
* ButtonDeny
* ButtonIcon
* ButtonStandard
* ButtonStandardIcon
* ButtonTab

We can tell that this is the case by looking at the behaviors for each of these controls.

<figure><img src="../../.gitbook/assets/image (286).png" alt=""><figcaption><p>ButtonStandard implements the ButtonBehavior</p></figcaption></figure>

Note that while a full implementation may require handling each of the Runtime classes listed above, for simplicity this tutorial discusses only ButtonStandard.

Every runtime has a code file - even runtimes which correspond to built-in Forms types such as Button. For example, all of the Button Gum components have corresponding Runtime classes in Visual Studio.

<figure><img src="../../.gitbook/assets/image (287).png" alt=""><figcaption><p>Button Runtime classes in Visual Studio</p></figcaption></figure>

Each runtime provides a CustomInitialize method which is similar to CustomInitialize on Screens and Components. The CustomInitialize is called once when a new instance of our component is created. This code runs regardless of how our Gum runtime is created. This includes if:

* The component is added to a Gum screen in the Gum tool
* The component is instantiated by calling its constructor in custom code. For example, calling `new ButtonStandardRuntime();`
* The component is instantiated through its corresponding Forms control. For example, calling `new Button();`

Therefore, we can add code to CustomInitialize to perform custom logic on all of our Button instances.

To respond to whenever a Button is clicked, we can modify our ButtonStandardRuntime as shown in the following code:

```csharp
partial void CustomInitialize () 
{
    this.FormsControl.Click += HandleFormsButtonClicked;
}

private void HandleFormsButtonClicked(object sender, EventArgs e)
{
    // Play a Sound here using the AudioManager...
    AudioManager.Play(SomeSoundEffect);
    // For the sake of the tutorial, print text to the screen
    // so we can tell that the button was clicked
    FlatRedBall.Debugging.Debugger.CommandLineWrite("Button clicked");
}
```

This code results in printing "Button clicked" when any button (with a backing ButtonStandard Component) has been clicked.

<figure><img src="../../.gitbook/assets/11_06 23 25.gif" alt=""><figcaption><p>Button printing out "Button clicked" whenever it is clicked</p></figcaption></figure>

Again, remember that the Button in Forms is a special type of control becuase it has multiple components handling its implementation, so you may need to add similar code to the other Runtime classes.
