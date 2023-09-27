## Introduction

The Game Scripting Plugin includes a Windows form which gives you real-time information about the state of your script. This is useful for the following reasons:

1.  Due to their delayed execution Scripts are harder to debug compared to regular code.
2.  Scripting is intended to be easy enough for non-technical users. These users may not be familiar with Visual Studio's debugger.
3.  Real-time information can be useful even for individuals who are comfortable debugging complex code in Visual Studio - the real-time view can often solve simpler bugs faster than debugging with Visual Studio.

## Restrictions

The debugging built in to the scripting plugin can only be used on Windows. Of course, you can still use regular Visual Studio debugging on other platforms.

## Preparing for Integration

To integrate the debugging form, you must already have:

-   A Glue project
-   Added the Game Scripting Plugin core classes
-   Created a class which inherits from ScriptEngine
-   Added an instance of the ScriptEngine-inheriting class into your game

If you are unsure about how to do any of the above steps, you should review the [game scripting implementation tutorial](/frb/docs/index.php?title=Glue:GlueVault:Component_Pages:Game_Scripting_Plugin:Implementation_Tutorial.md "Glue:GlueVault:Component Pages:Game Scripting Plugin:Implementation Tutorial"). For the rest of this tutorial we will use a Screen called GameScreen - this is the name of the Screen that was used in the [game scripting implementation tutorial](/frb/docs/index.php?title=Glue:GlueVault:Component_Pages:Game_Scripting_Plugin:Implementation_Tutorial.md "Glue:GlueVault:Component Pages:Game Scripting Plugin:Implementation Tutorial").

## Adding necessary references

You need to add references to your project which are used by the debugging code. To do this:

1.  Expand your project in Visual Studio

2.  Right-click on the **References** item

3.  Select **Add Reference...**

4.  Select the **Assemblies** -\> **Framework** category

    ![](/media/2018-04-img_5ac4cfb2eabe2.png)

5.  Check the following items:
    1.  Select System.Data
    2.  System.Drawing
    3.  System.Windows.Forms

## Adding Debug Controls to Your Project

Next we'll add debug controls to our project.

1.  Open or focus Glue

2.  Select **Plugins** -\> **Add Game Script Debugging Classes**

    ![](/media/2018-04-img_5ac4dd179a0b9.png)

The Debug control is only available on Windows platforms (because it uses Windows Forms), so the code is surrounded by a WINDOWS pre-compile directive. To access this, you will need to add WINDOWS to your project's conditional compilation symbols:

1.  Right-click on your project

2.  Select **Properties**

3.  Click the **Build** category

4.  Add WINDOWS to the **Conditional compilation symbols** text box (all values should be separated by a semicolon)

    ![](/media/2018-04-img_5ac4dfb980ee4.png)

## Creating the Debug Form

To add a debug form, open GameScreen.cs (or the custom code file that contains your ScriptEngine-inheriting class. Add the following at class scope:

    ScriptDebuggingForm mScriptDebuggingForm;

Add the following in your Screen's CustomInitialize **after you initialize your script**

    // Assuming mScripts is the name of your script instance
    mScriptDebuggingForm = new ScriptDebuggingForm();
    mScriptDebuggingForm.ShowWithScripts(mScript);

Add the following to your Screen's CustomActivity

    mScriptDebuggingForm.Activity();

**Note:** You will need to add the following using statement to qualify the ScriptDebuggingForm:

    using FlatRedBall.Scripting;

If you run the game you will now see the debug window list the events you have in your game. ![ScriptDebugWindow.png](/media/migrated_media-ScriptDebugWindow.png)

## Available information

The Script window already shows us some useful information. We can see that we have 3 scripts which have conditions "HasPlayerPassed". This name comes from the "HasPlayerPassed" function which is called in our If's in the game script. The debugging form automatically detects this as the name based off of the method that created the delegate. Also, the debugging window tells us how many actions exist in the script in parentheses. Each script has one action, so each says (1) after the If call. The scripts will default as written in black. When they execute, they will change to green, so you will be able to see how scripts execute in real-time. Finally, you can expand the scripts to see the names of the actions that will execute. ![ScriptDebugExpanded.png](/media/migrated_media-ScriptDebugExpanded.png)
