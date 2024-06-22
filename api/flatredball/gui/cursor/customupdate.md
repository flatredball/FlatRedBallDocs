# CustomUpdate

### Introduction

The CustomUpdate delegate allows for customizing the Cursor's behavior. Specifically this allows setting the Cursor's position and primary/secondary/middle values.

### When is CustomUpdate used?

CustomUpdate is used if you would like to use the FRB Cursor class, but would like to provide custom input logic. The most common scenario for this is when using input devices which are not natively supported by FRB. For example, the Cursor could be used with the Wii's Remote hardware (which can be paired with a computer through bluetooth).

### CustomUpdate replaces regular update logic

If a non-null CustomUpdate delegate is specified then the regular input logic for the Cursor no longer applies. In other words, the Cursor no longer responds to Mouse input if CustomUpdate is used.

### Code Example

The following code shows how to control the cursor with the keyboard.

```csharp
// In CustomInitialize or your Game's Initialize:
GuiManager.Cursor.CustomUpdate = HandleCursorUpdate;

// Then define HandleCursorUpdate:
void HandleCursorUpdate(Cursor cursor)
{
    Keyboard keyboard = InputManager.Keyboard;

    if (keyboard.KeyDown(Keys.Up))
    {
        cursor.ScreenY--;
    }
    if (keyboard.KeyDown(Keys.Down))
    {
        cursor.ScreenY++;
    }
    if (keyboard.KeyDown(Keys.Right))
    {
        cursor.ScreenX++;
    }
    if (keyboard.KeyDown(Keys.Left))
    {
        cursor.ScreenX--;
    }

    if (keyboard.KeyDown(Keys.Space))
    {
        cursor.PrimaryDown = true;
    }
}
```
