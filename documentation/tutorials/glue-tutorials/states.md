## Introduction

A "State" represents zero or more variables which can be set at once either in Glue or in code. States have two main purposes:

1.  Associating multiple variable states together. For example, a Text box may have its color operation change as well as becoming slightly transparent when disabled.
2.  Providing meaning for otherwise-abstract values. For example, in your game your character may have two sizes depending on which powerup the player has collected (such as Height = 30 and Height = 50). Instead of simply setting the values to numbers which have no meaning, you can create a Large state and a Small state. Using these states in code will make it much easier to read. For example, consider the above example as expressed in code:

&nbsp;

    // If states didn't exist, then you would do something like this when the character collects a power-up:
    this.Height = 50;
    // However, if we create a state, then what we are intending with our code is clearer
    this.CurrentState = VariableState.Big;

## How to create States

States are easy to create, but this tutorial will provide a real-world example of how to work with states. Therefore, we'll work with the Button entity from the [AnimationChain tutorial](/documentation/tutorials/glue-tutorials/glue-tutorials-using-animation-chains/.md).

## Adding States

To add a state:

1.  Expand your Button Entity
2.  Right-click on "States"![AddState.png](/media/migrated_media-AddState.png)
3.  Name the state "Normal" and press OK![NormalState.png](/media/migrated_media-NormalState.png)
4.  Repeat the process to add "Pressed" and "Inactive" states![3States.png](/media/migrated_media-3States.png)

Now you have 3 states, but these states don't do anything yet. We need to make each one set the appropriate AnimationChain.

## Setting variables in States

To make a State set variables:

1.  Select the Normal State
2.  Change the CurrentChain to "Normal"![NormalStateToNormal.png](/media/migrated_media-NormalStateToNormal.png)
3.  Repeat the steps for the other two States

Now you have states which can be used in Glue and in code to change the State of any object.

**Where is the CurrentChain variable?**States can set any variable on a Screen/Entity. In this tutorial the Button Entity has a CurrentChain variable. This is because this tutorial continues the [previous tutorial on AnimationChains](/frb/docs/index.php?title=Glue:Tutorials:Using_Animation_Chains.md "Glue:Tutorials:Using Animation Chains"). If your Entity doesn't have any variables you can either go back to the [previous tutorial](/frb/docs/index.php?title=Glue:Tutorials:Using_Animation_Chains.md "Glue:Tutorials:Using Animation Chains") or simply add a variable to your Screen/Entity and it will show up in the State.

## Default States

Objects with states will by default not use these states when they are created. However, you can set the starting state for objects through Glue. We'll assume that you still have a Screen which contains a 2D Layer. In this tutoria, we'll use the "GameScreen" Screen. We'll empty it out so it only contains the objects relevant for this tutorial (a 2D Layer for starters).

1.  Expand your GameScreen
2.  Right-click on the "Objects"
3.  Select "Add Object"
4.  Enter the name "ButtonInstance" and click OK
5.  Select your newly-created object and change its "Layer On" to "Layer2D" (or the name of your 2D Layer)![ButtonInGlue.png](/media/migrated_media-ButtonInGlue.png)

At this point if you run your game you should see the button in the middle of the screen.![ButtonInMiddleOfScreen.png](/media/migrated_media-ButtonInMiddleOfScreen.png) Now that you have a Button instance, you can set its default state. To do this, simply change the "Current State" property in Glue: ![CurrentStateInGlue.png](/media/migrated_media-CurrentStateInGlue.png)![InactiveButton.png](/media/migrated_media-InactiveButton.png)

## Wait, why did we go through all of that trouble?

You may be wondering why you went through the trouble of setting up states for an AnimationChain. Will it really save much time? The answer would be no if you were only going to set the AnimationChain and if it were going to never be changed in code (as we'll show below for programmers). However, it's likely that the state will change in code - very likely for something like a button which needs to react to being pressed. In other words, states can help abstract the setting of one or more variables, and they can also make a programmer's job much easier. If you're a programmer, read on.

## How to set States in code

States are very convenient in code. One reason is because they let you abstract what an actual state does away from the logic that controls it. In other words, you can simply set a Button's state according to whether the cursor has pressed on it or if it is disabled - and that's all you have to worry about. The design team (or you at a later time) can worry about what it actually means to be "Inactive" or "Pressed". However, States are also very handy because they generate enumerations and a CurrentState property. You can check it yourself in code:![AutoCompleteState.png](/media/migrated_media-AutoCompleteState.png)

## Thinking about States as "variable groups"

So far we've been talking about states as being mutually exclusive. In other words, if the Button above sets its State as "Normal", then later sets it as "Inactive", then nothing from the Normal state persists. However, this is because the three states we used above all set the Sprite's CurrentChain property. Therefore, when any State was set, it would override the old state. The next example will show that states can be used to set variables which do not have to be overridden by other states. First we'll need to expose some variables:

1.  Expand your "Button" Entity
2.  Right-click on Variables and select "Add Variable"
3.  Select X in the combo box to expose the X variable
4.  Add another variable and expose Y

Next we'll create two new states:

1.  Add a new State called "LeftSide"
2.  Select the LeftSide State and change X to be -335
3.  Add a new State called "RightSide"
4.  Select the RightSide State and change X to 335

Now we can think about the variable states we have in two categories:

-   Position
    -   LeftSide
    -   RightSide

&nbsp;

-   Clicking States
    -   Normal
    -   Pressed
    -   Inactive

This means that we could set the LeftSide or RightSide states in Glue, and then later (in code) set states like Pressed or Normal, and the position from LeftSide or RightSide would persist. In a way, it's as if multiple states can exist at the same time. In practice having states that can "coexist" is very common. When this happens, states will usually group together according to the variables they set without you (the creator of the states) even thinking about it! In this particular case the Position States are States which are set when the Button is first created, while the Clicking States are States which can change in the code. Therefore, in practice you would probably want to set the CurrentState on any Button instance to one of the Position States, and the other States would be set in code. To see this in action, try creating a second Button instance and setting its "Current State" to "RightSide", then changing the other Button instance's "Current State" to "LeftSide". ![TwoButtons.png](/media/migrated_media-TwoButtons.png)
