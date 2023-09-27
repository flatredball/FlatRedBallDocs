## Introduction

FlatRedBall (Desktop GL) games on the PC have the following requirements:

-   Microsoft .NET 4.5.2 (as of the latest template)

Additional if your game uses FlatRedBall XNA, the following are required:

-   DirectX (if using an XNA version of FlatRedBall)
-   XNA (if using an XNA version of FlatRedBall)

Any regular installation method is supported, including Microsoft solutions such as ClickOnce, NSIS, or any other distribution method.

## Creating an installer using ClickOnce

For information on using ClickOnce, see [this page](https://msdn.microsoft.com/en-us/library/vstudio/31kztyey(v=vs.100)).

## Creating a launcher using AutoIt

This section shows how to use AutoIt to create a launcher for your game. The purpose of this launcher will be to detect if the user has .NET 4.5.2 and XNA 4.0 runtimes installed. If the user does not have these installed then the launcher will direct the user to a website to install them. If the requirements are installed, then the launcher will run the game.

## What is AutoIt?

From the AutoIt website:

AutoIt v3 is a freeware BASIC-like scripting language designed for automating the Windows GUI and general scripting.

AutoIt can be used for UI automation, but we'll be using it simply to detect if prerequisites are installed. If you'd like to read more about AutoIt, check the [AutoIt website](http://www.autoitscript.com/site/autoit/).

## Install AutoIt

First you'll need to install AutoIt. You can do this from the [AutoIt website](http://www.autoitscript.com/site/autoit/).

## Creating a Script

Next you'll need to create an .au3 script. To do this, you'll need to create a text file with a .au3 extension. Once you do this, you'll want to copy the following into your .au3 file:

    Const $AppTitle = 'YOUR GAME TITLE'
    Const $MB_ICONERROR = 16

    If RegRead('HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client', 'Version') < "4.5.2" RegRead('HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v4\Client', 'Version') < "4.5.2" And Then
     MsgBox($MB_ICONERROR, $AppTitle, 'The .NET Framework runtime v4.5.2 is required to run.')
     ShellExecute("https://www.microsoft.com/en-us/download/details.aspx?id=42643")
     Exit 1
    EndIf
     
    If RegRead('HKEY_LOCAL_MACHINE\Software\Microsoft\XNA\Framework\v4.0', 'Installed') <> 1 And RegRead('HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\XNA\Framework\v4.0', 'Installed') <> 1 Then
     MsgBox($MB_ICONERROR, $AppTitle, 'The Microsoft XNA Framework runtime v4.0 is required to run.')
     ShellExecute("http://www.microsoft.com/en-us/download/details.aspx?id=20914")
     Exit 1
    EndIf

    Exit RunWait('YourGameExecutable.exe')

Notice that you will have to replace YOUR GAME TITLE and YourGameExecutable above. The above script checks the registry for certain values. You can see your own registry by opening the start menu and typing **regedit**.

## Compiling the Script

Once you've created the .au3 file you should be able to right-click on the .au3 file and compile the script. The compiled script should then be moved into the same folder as your .exe file. Make sure that the relative path of the .exe in the script matches the actual path of the game's .exe relative to the compiled script file.
