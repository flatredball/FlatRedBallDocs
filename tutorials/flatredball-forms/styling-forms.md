# Styling Forms

### Introduction

FlatRedBall.Forms is a logical wrapper over standard Gum objects. As such, the Gum objects can be modified in almost any way to fit the styling needs of your game. This document covers the default FlatRedBall.Forms controls and how to make modifications.

### Forms Requirements

FlatRedBall.Forms provides flexibility in regards to Forms component structure, but some objects and states are required so that a Forms object can behave properly.

To identify the requirements you can look at the Forms behaviors in the Behaviors folder in your Gum project.

<figure><img src="../../.gitbook/assets/image (44).png" alt=""><figcaption><p>Forms Behaviors</p></figcaption></figure>

These behaviors are automatically added to your Gum project by the FlatRedBall Editor when you add a Gum project. If you used the FlatRedBall Wizard to create your project, these are also added automatically.

These behaviors indicate the requirements that a Forms control has. For example, ButtonBehavior requires that a ButtonBehavior-implementing Component must have a category called ButtonCategory, and that it must contain states with specific names.

<figure><img src="../../.gitbook/assets/image (45).png" alt=""><figcaption><p>ButtonBehavior ButtonCategory</p></figcaption></figure>

If you create a Component which satisfies these behaviors, then your component can be used as a FlatRedBall.Forms button.

Some behaviors have additional requirements such as required objects. For example, the ComboBoxBehavior requires a category called ComboBoxCategory which contains a number of states, but it also requires two objects - a ListBoxInstance and a TextInstance.

<figure><img src="../../.gitbook/assets/image (46).png" alt=""><figcaption><p>ComboBoxBehavior instance requirements</p></figcaption></figure>

If you modify any existing component which implements these behaviors, make sure you do not remove or change the name of any required categories, states, or instances.

Besides requirements from categories, some FlatRedBall.Forms can use optional instances if they exist. These are not required. For example, the Button component can optionally include an instance called TextInstance. Since this is an optional requirement, the Behavior does not include it as a requirement. However, you can find out more about optional requirements by looking at the [API documentation for FlatRedBall.Forms](./).

In general, you will almost always be safe making the following modifications:

* Changing variables such as position, size, or color
* Modifying values assigned in states
* Adding additional instances to a control, such as adding an icon Sprite to a ListBoxItem
* Renaming components

The following modifications may introduce problems depending on if they are made on requirements:

* Changing the name of states
* Changing the name of instances
* Changing the type of instances to incompatible types, such as changing an instance from Text to Sprite
* Removing behaviors - you can do this if you would like the component to no longer be associated with FlatRedBall.Forms

### Default Forms Components

Projects created through the FlatRedBall Wizard, or which have added Forms when creating a Gum project, should contain a default implementation of FlatRedBall.Forms controls in the Gum project. These can be found in the Components/Controls and Components/Elements folders. Note that as FlatRedBall.Forms is developed, new controls are created, so this list will change over time.

<figure><img src="../../.gitbook/assets/image (47).png" alt=""><figcaption><p>Example list of FlatRedBall.Forms Controls</p></figcaption></figure>

### Changing Styles

These forms controls are built to support a common, centralized style. You can make changes at the base level so that your styling changes apply to the entire project, or you can choose to modify individual components one-by-one without changing the global style.

To see how the styling is implemented, we'll look at one of the most common controls: ButtonStandard.

<figure><img src="../../.gitbook/assets/image (48).png" alt=""><figcaption><p>ButtonStandard in Gum</p></figcaption></figure>

As mentioned earlier, a Gum component must implement a Forms behavior to be considered a Forms object. We can confirm that this is the case by checking the behaviors on ButtonStandard in the Behaviors tab.

<figure><img src="../../.gitbook/assets/image (49).png" alt=""><figcaption><p>ButtonBehavior in ButtonStandard</p></figcaption></figure>

This means that the ButtonStandard is required to have a ButtonCategory which contains states for displaying the button depending on whether it is enabled/disabled, highlighted, and pressed.

As mentioned above, we should not delete or rename these states, but we are free to make changes to the states to modify the styling so it matches our game.

Selecting a category in Gum shows the variables that are modified by all states in the category. In this case, the ButtonCategory modifies

* Background.ColorCategoryState
* FocusedIndicator.Visible
* TextInstance.ColorCategoryState

If we want to change the state, we can make additional changes to the state by selecting it and modifying variables. For example, we may want to make the Text larger when the cursor is highlighting the button. To do this:

1. Select the TextInstance
2. Select the Highlighted state
3. Change FontScale from 1 to 1.5

The FontScale variable shoudl display with a white background instead of green to indicate that it is explicitly set on this state.

<figure><img src="../../.gitbook/assets/image (50).png" alt=""><figcaption><p>Font Scale modified in the Highlighted State</p></figcaption></figure>

Note that the FontScale variable is now modified by all states in the category, not just the one that you set. All of the other states explicitly set the variable to the default of 1. You can verify this by clicking on the ButtonCategory.

<figure><img src="../../.gitbook/assets/image (51).png" alt=""><figcaption><p>TextInstance.Font Scale assigned in the ButtonCategory</p></figcaption></figure>

Since these states are used at runtime automatically, we can run the game and see the font size change when the button is highlighted. Notice that the button text shrinks back to its normal size when the cursor moves off of the button. The text also shrinks when the button is pushed since we didn't modify the Pushed state.

<figure><img src="../../.gitbook/assets/19_09 06 40.gif" alt=""><figcaption><p>Button adjusting Font Scale on Highlight</p></figcaption></figure>

In this case our modification to the button added a new variable that was previously unmodified by ButtonCategory. We can also change existing values. For example, when highlighted our Button's background uses the PrimaryLight ColorCategoryState.

<figure><img src="../../.gitbook/assets/image (3) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>ColorCategoryState assigned in Highlighted State</p></figcaption></figure>

In this case, the ColorCategoryState is defined on NineSlice, which is the base type for Background. Therefore, we should not modify the Red, Green, or Blue values on the Background object because they will be in conflict with the values assigned by this state.

If we would like to modify the Background color in the Highlight (or any other) state, we have a few options:

1. We can go to the NineSlice standard object and modify the PrimaryLight state. Be careful, making modifications here is concpetually similar to making modifications to a style sheet which is used across an entire project. If you would like to change this value globally, feel free to do so, but realize that making changes to the NineSlice styles can modify many components in your project.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>PrimaryLight definition in NineSlice</p></figcaption></figure>

2. Change the state value that is being used on the background. Although this is not recommended, you can change the background to use a different ColorCategoryState, such as changing the value to Success. This is not recommended because the ColorCategoryState states are named to indicate where they should be used throughout your project, and switching to different ColorCategoryStates may result in confusing the user by using the same color for different behaviors and states.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Background using a different ColorCategoryState on Highlighted</p></figcaption></figure>

3. Add a new state to NineSlice for your specific case. This is useful if you have a case that isn't handled by the existing NineSlice category states.

<figure><img src="../../.gitbook/assets/image (3) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Adding a state to NineSlice</p></figcaption></figure>

4.  Removing the usage of ColorCategoryStates from your ButtonCategory. The states in the NineSlice exist to make global styling easier, but they are not a requirement. If you would prefer to implement your own styling method, such as direct RGB values on the background, that's okay. Keep in mind that the Background NineSlice isn't even a requirement! You can remove it and replace it with something else like a Sprite if that works better for your game.\


    <figure><img src="../../.gitbook/assets/image (4) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>ButtonCategory variables can be removed</p></figcaption></figure>



As mentioned above, using Gum to style your FlatRedBall.Forms controls provides a lot of flexibility. The existing structure exists to make changes easier to implement, but you are free to experiment and find your own preferred styling.
