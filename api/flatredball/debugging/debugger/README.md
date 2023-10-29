## Introduction

The Debugger class provides a quick way to get real-time information in your game. It is commonly used to track down bugs which are easier to solve with real-time information, and to verify that implemented features are working as expected.

## Write Method

The Write method can be used to display information to the Screen. The following code example shows how to display information about the Cursor to the Screen:

Add the following to Update:

    Cursor cursor = FlatRedBall.Gui.GuiManager.Cursor;
    string resultString = "World X: " + cursor.WorldXAt(0) + 
       "\nWorld Y: " + cursor.WorldYAt(0);
    FlatRedBall.Debugging.Debugger.Write(resultString);

![Debugger.Write.png](/media/migrated_media-Debugger.Write.png)

## 
