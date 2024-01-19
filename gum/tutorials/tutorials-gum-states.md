# States

### Introduction

Gum supports the concept of states, which are very similar to states in Glue. This tutorial will discuss how to use States which are created in Gum when integrating Gum objects in Glue. This tutorial will cover both regular (uncategorized) as well as categorised states. If you'd like to see how to work with states in Gum, see [this tutorial](http://vchelaru.github.io/Gum/tutorials/Usage%20Guide%20\_%20States.html). If you'd like to see how to work with categorized states in Gum, see [this tutorial](http://vchelaru.github.io/Gum/tutorials/Usage%20Guide%20\_%20State%20Categories.html).

Note that this tutorial uses a component titled Button. The purpose of this tutorial is to provide an end-to-end example of how to create states and work with them in code. The purpose of this is **not to create a usable button.** Although buttons may seem simple in concept, a real world button requires lots of logic that can take a long time to implement. For actual UI that uses buttons, we recommend using FlatRedBall.Forms and the Button class/components that it includes. In other words, you should follow this tutorial to learn about states, but we do not recommend actually using the resulting component in an actual game.

### States Overview

Before we look at how to work with States in code, we'll do a brief overview of states. We'll look at how states are created, why you might want to use states, and state ownership. States can be though of as "groups of variables". For example, consider the state of a button being disabled. A disabled button may have the following variables set:

* Background.Alpha = 127 (make the background of the button half-transparent)
* Text.Red = 100 (set the Red, Green, and Blue values to make it gray instead of black)
* Text.Green = 100
* Text.Blue = 100

A disabled button could change these variables in code when it became disabled, but it's far more expressive and maintainable to create a state in Gum that assigns all of these values. This allows the code to simply set the state and not worry about the visual details. States can be added to Screens, Components, and Standard Elements in Gum. States should almost always be categorized, so for the remainder of this tutorial we will be working with categorized states. Categorized states can help avoid some of the most common pitfalls of working with states, such as unset variables when switching between states. The following screen shot shows a typical Button object with states for controlling the button in response to various UI interactions and enabled values:

<figure><img src="../../media/2019-01-img_5c46551c3c3e3-e1548113244713.png" alt=""><figcaption></figcaption></figure>

The screenshot shows a **Button** component with a category called **UiStates.** This category contains the following states:

* Normal
* Pressed
* Highlighted
* Disabled

These states can change any property on the Button or its contained instances. **Important**: Note that all of the states shown belong to the Button component. These states can change values on contained objects (such as **ColoredRectangleInstance** and **TextInstance**), but the states belong to the Button component. For example, if the **Pressed** state is selected and a variable is changed on **ColoredRectangleInstance**...

![](../../media/2019-01-img\_5c469f61080fc.png)

This change is applied to the **Pressed** state which belongs to the **Button** component. As another example, consider a screen called MenuScreenGum with three buttons:

* FullGameButton
* DemoButton
* ExitButton

If this screen were used as a main menu in a game which can be played in demo mode, it could control the visibility of its contained buttons using a Full and Demo state, as shown in the following image:

![](../../media/2019-01-img\_5c46a3a71db22.png)

The Full state may hide the DemoButton (set its Visible to false), while the Demo state may hide the FullGameButton (set its Visible to false). Even though these states may change variables on the button instances, the state is contained in the MainScreenGum.

### Simple Button Using States

Whenever you create a new State in Gum, Glue will automatically generate code for you to use this state. States are useful for creating standard UI behavior like reacting visually to a push. Typically UI elements are created as components (such as a general Button component). These components contain states to control visual behavior, and these states are set in the custom code for the component. For users of FlatRedBall.Forms, this section provides some insight into how states can be used in code. If you are using FlatRedBall.Forms, you will likely not need to write code like this because the Button class already has built-in state changing logic. For this example, consider a component named Button. For this component we will have the following states:

* Normal
* Pressed
* Highlighted

Note that in the image below the three states are categorized in a category called **UiStates**. We recommend categorizing states whenever possible.

![](../../media/2019-01-img\_5c4221d8f2808.png)

All Gum components create two code files for you: a file for custom code and a file for generated code.

![](../../media/2019-01-img\_5c4223b550fb6.png)

The generated file (in this case **ButtonRuntime.Generated.cs**) will contain entries for each of the states. Note that each category will create its own enumeration and associated property in generated code: The following screenshot shows the enumerations defined for the states:

![](../../media/2019-01-img\_5c4223faa1673.png)

The following screenshot shows the properties for the states:

![](../../media/2019-01-img\_5c422446353d2.png)

Note that categorized states are nullable, allowing the category to not be set at all (which is the default when the Button is created at runtime). These states can be used in code. For example, a simple, functional button could be created by adding events to the button in its CustomInitialize function.

```lang:c#
public partial class ButtonRuntime
{
    partial void CustomInitialize () 
    {
        this.RollOn += (arg) => this.CurrentUiStatesState = UiStates.Highlighted;
        this.RollOff += (arg) => this.CurrentUiStatesState = UiStates.Normal;
        this.Push += (arg) => this.CurrentUiStatesState = UiStates.Pressed;
        // We'll assume if clicked, we'll go back to highlighted
        this.Click += (arg) => this.CurrentUiStatesState = UiStates.Highlighted;
    }
}
```
