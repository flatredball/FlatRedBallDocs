## Introduction

The Game Script plugin provides some classes to simplify the creation of scripted events. Examples of scripted events in games include:

-   Game cinematic sequences where characters talk, move, and play animations on their own
-   Tutorials which can display text, show UI, and enable/disable game functionality

Logically a game script defines conditions which should be checked by the game and logic which should execute when the conditions are fulfilled. This definition may sound like normal game logic, but game scripts have some unique characteristics when compared to regular game code:

-   Game scripts conditions are checked every frame. Once a condition is fulfilled, the resulting logic is executed only one time.
-   Game scripts can all be defined in one place, but may execute at different times.
-   Game scripts include special functions to control timing, such as the AfterThat  function.
-   Game scripts provide a special If/Do syntax enabling beginner programmers to write and maintain scripts more easily than fully-featured C#

The game scripting plugin for Glue does not provide a new "scripting language" nor does it use traditional scripting languages like Lua or JavaScript. Instead, it is a set of classes and interfaces which can be used in C# to simplify common scripting tasks. Note that since the game scripts are C#, they can be debugged just like any other code - a useful feature when creating more complex scripts.

## Setup

The Game Script plugin adds a set of classes and interfaces which can be used to create game scripts. Therefore, the first steps in creating a game with scripting are:

1.  Create a Glue project
2.  Have at least one Screen in your project

Once you have a project open, you can add the files to the project by clicking the "Add Game Script Core Classes" option under the Plugins menu ![AddGameScriptCoreClasses.png](/media/migrated_media-AddGameScriptCoreClasses.png) Now your project should contain all of the necessary files to begin creating scripts.

## Initializing a ScreenScript

Scripts must be associated with a Glue screen. If your game includes levels which have level-specific scripts, then you may create a different script for each level. If instead your game has one central game screen which loads and unloads levels according to player behavior, you may add your scripts to the core game screen. For this tutorial we will add scripts to a GameScreen for the sake of simplicity. It is important to note that the scripting system can be implemented in any game in just a few lines of code, but with a little extra work the scripting system can be modified to make it easier for game designers with very little C# knowledge to be effective. The easiest way to create a script is to instantiate a new ScreenScript instance in your screen. Specifically we will be adding an instance at class scope, initializing it, and calling its Activity  function as shown in the following code:

``` lang:c#
using FlatRedBall.Scripting;
public partial class GameScreen
{
    ScreenScript<GameScreen> screenScript;

    void CustomInitialize()
    {
        screenScript = new ScreenScript<GameScreen>(this);

        var If = screenScript as IScreenScriptIf;
        var Do = screenScript as IScreenScriptDo;

    }

    void CustomActivity(bool firstTimeCalled)
    {
        screenScript.Activity();
    }
    ...
```

Note that we also created two variables named If  and Do . Although not necessary, these two objects can simplify the script writing process through Visual Studio's Intellisense.

## Adding a Circle to the GameScreen

For this tutorial we will use a Circle instance to represent a controllable character. Of course a real game would have more complex entities and logic, but we'll keep it simple to focus on how scripts work. To add a Circle instance to your screen:

1.  Open your project in Glue
2.  Right click on your Screen's **Objects** folder
3.  Select **Add Object**
4.  Select the **Circle** type
5.  Click **OK**

[![](/wp-content/uploads/2016/01/2019_December_15_222804.gif)](/wp-content/uploads/2016/01/2019_December_15_222804.gif)

## Writing Game Scripts

Now that we have our GameScreen set up to support scripting and we have a Circle instance, we can begin writing scripts using our If  and Do  objects. All scripts should begin with a call on the If object. Following the If, scripts can have one or more Do calls which provide the logic to perform when the If evaluates to true. If calls can take a predicate delegate (Func\<bool\> ) to control when Do  calls occur. The Do.Call  function can take an Action  with any number of parameters to perform logic. Also, note that controlling scripting through delegates is optional, and other script writing methods exist, but these other methods require more setup, so we will use anonymous delegates in this guide. We will write scripts which will perform the following checks and actions: If the circle's X value is greater than 100, print "Hey, where do you think you're going?" If the circle's X value is greater than 200, print "Stop right there!" If the circle's X value is greater than 300, print "Stop! We have an emergency, a prisoner has escaped!" We will set the Circle's [XVelocity](/documentation/api/flatredball/flatredball-positionedobject/flatredball-positionedobject-velocity.md) to 50 so it moves to the right on its own, and we will use the [CommandLineWrite](/documentation/api/flatredball/flatredball-debugging/flatredball-debugging-debugger/flatredball-debugging-debugger-commandlinewrite.md) method to print text to the screen.

``` lang:c#
public partial class GameScreen
{
    ScreenScript<GameScreen> screenScript;

    void CustomInitialize()
    {
        InitializeScripts();

        mCircleInstance.XVelocity = 50;
    }

    private void InitializeScripts()
    {
        screenScript = new ScreenScript<GameScreen>(this);

        var If = screenScript as IScreenScriptIf;
        var Do = screenScript as IScreenScriptDo;

        If.Check(() => mCircleInstance.X > 100);
        Do.Call(() => FlatRedBall.Debugging.Debugger.CommandLineWrite("Hey, where do you think you're going?"));

        If.Check(() => mCircleInstance.X > 200);
        Do.Call(() => FlatRedBall.Debugging.Debugger.CommandLineWrite("Stop right there!"));

        If.Check(() => mCircleInstance.X > 300);
        Do.Call(() => FlatRedBall.Debugging.Debugger.CommandLineWrite("Stop! We have an emergency, a prisoner has escaped!"));
    }

    void CustomActivity(bool firstTimeCalled)
    {
        screenScript.Activity();
    }
    ...
```

If you run your game you'll see the text update as the circle moves to the right. ![RunningScripting.png](/media/migrated_media-RunningScripting.png) Of course in a real game the character wouldn't move on its own, but hopefully you can see how you would use this type of code to create your own scripts based off of player location, time, or any other kind of logic specific to your game.

## Script Details

The script above includes three sets of If/Do calls. Each If includes a function which is called every frame until it has completed. Once an If has completed, it no longer is checked every frame. Similarly, each Do call is only called one time. As far as the game script is concerned, each If/Do block is a distinct script which does not depend on other scripts. This means that If/Do blocks can be moved around without having any impact on other blocks. For example, we could reverse the order of the code and it would still execute the same as before:

``` lang:c#
private void InitializeScripts()
{
    screenScript = new ScreenScript<GameScreen>(this);

    var If = screenScript as IScreenScriptIf;
    var Do = screenScript as IScreenScriptDo;

    If.Check(() => mCircleInstance.X > 300);
    Do.Call(() => FlatRedBall.Debugging.Debugger.CommandLineWrite("Stop! We have an emergency, a prisoner has escaped!"));

    If.Check(() => mCircleInstance.X > 200);
    Do.Call(() => FlatRedBall.Debugging.Debugger.CommandLineWrite("Stop right there!"));

    If.Check(() => mCircleInstance.X > 100);
    Do.Call(() => FlatRedBall.Debugging.Debugger.CommandLineWrite("Hey, where do you think you're going?"));

}
```

The script above has a single Do call for each If, but scripts can include multiple Do calls which will all be associated with the previous If. For example, the following If/Do set represents a typical script:

``` lang:c#
If.Check(() => PlayerInstance.CollideAgainst(CinematicTrigger));
Do.Call(() => PlaySong(IntroSong));
Do.Call(() => PlayerInstance.DisableInput());
Do.Call(() => ShowDialog("I see you've arrived..."));
Do.Call(() => PlayFlashEffect());
```

In the code above, once the player collides with the cinematic trigger, all of the following Do calls will execute in the order that they have been written. It's possible (and common) for Do calls to set variables which can then be used in other If checks to continue a scripted sequence.
