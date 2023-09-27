## Introduction

Windows RT supports a custom cursor. This article discusses how to modify the cursor to use custom visuals.

## Setup

This project assumes a working Windows RT project. It also assumes that the cursor is visible. For more information on making the cursor visible, see [this page](/frb/docs/index.php?title=Microsoft.Xna.Framework.Game.IsMouseVisible "Microsoft.Xna.Framework.Game.IsMouseVisible").

## Creating a C++ project to house the resource

Unfortunately to create a resource to hold the Cursor graphic you must create a C++ project. Don't worry, we won't do any C++ programming, but Visual Studio requires this project to create the proper resource files. To do this:

1.  Open your project in Visual Studio
2.  Right-click on the solution
3.  Select Add-\>"New Project"
4.  On the left select the category "Visual C++"-\>"Store Apps"-\>"Windows Apps"
5.  Select the "DLL (Windows)" project type
6.  Enter the name "ProjectForCursor"![C++DllProject.PNG](/media/migrated_media-C--DllProject.PNG)
7.  Click OK

## Adding a resource to the C++ Project

Next we'll add a resource file to contain our cursor resource. To do this:

1.  Right-click on the newly-created project (ProjectForCursor)
2.  Select Add-\>"Resource..."
3.  Select "Cursor" when the popup appears and click "New"

![AddCursorToC++Project.gif](/media/migrated_media-AddCursorToC--Project.gif)

## Editing the .cur file

Visual Studio creates a .cur file which contains the visuals for a cursor. This can be edited in many image editors. Users of Paint.NET can install a plugin to edit .cur files [here](http://paintdotnet.wordpress.com/2008/09/03/icocur/).

## Adding the built resource file to our project

First we need to build the C++ project to create the compiled resource file. To do this:

1.  Right-click on the ProjectForCursor project

2.  Select "Build"

3.  Navigate to the build folder, which should be

        <GlueProjectRoot>\ProjectForCursor\Debug\

4.  Look for a .res file (mine was ProjectForCursor1.res)

We will now add this file to our game project. To do this:

1.  Right click on the game project and select Add-\>"Existing Item..."
2.  Navigate to the .res file mentioned above and select it. Notice that the file will be copied unless you explicitly select to link it.
3.  Select File-\>"Save All" to save the addition of the resource file to the project

We must now modify the Visual Studio (C#) project by-hand. To do this:

1.  Navigate to your game project's .csproj file
2.  Open it in a text editor
3.  Find the first PropertyGroup tab, which might appear as follows:

&nbsp;

      <PropertyGroup>
        <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
        <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
        ...
      </PropertyGroup>

And add the Win32Resource tag inside of the PropertyGroup as follows:

      <PropertyGroup>
        <Win32Resource>ProjectForCursor1.res</Win32Resource>
        <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
        <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
        ...
      </PropertyGroup>

Once finished save the file in the text editor.

## Setting the Cursor in code

Finally we can set the cursor in code. Unfortunately this must be done after the Game's Initialize method is called. We can do this in Update, but we only need to do it once so we will create a bool to keep track of whether the cursor has been set. First, add this bool outside of any function in Game1.cs:

    bool hasSetCursor = false;

Next, modify Game1.Update so it has the following code:

    protected override void Update(GameTime gameTime)
    {
        if (!hasSetCursor)
        {
            // the value 101 can be retrieved from the C++ project's 
            // resource1.h
            this.IsMouseVisible = true;
            Windows.UI.Core.CoreWindow.GetForCurrentThread().PointerCursor =
                new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Custom, 101);
            hasSetCursor = true;
        }
        FlatRedBallServices.Update(gameTime);

        ScreenManager.Activity();

        base.Update(gameTime);
    }
