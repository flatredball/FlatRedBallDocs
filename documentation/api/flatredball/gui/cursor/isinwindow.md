## Introduction

The IsInWindow method can be used to tell if the Cursor is actually inside the game window. Using this can prevent clicks from being registered when the cursor is outside of the window.

## Code Example

The following example shows how to detect clicks that fall only inside of the game window:

    Cursor cursor = GuiManager.Cursor;
    if(cursor.PrimaryClick && cursor.IsInGameWindow())
    {
       // do something to respond to the click
    }
