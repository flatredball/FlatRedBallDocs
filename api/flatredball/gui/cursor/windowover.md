# windowover

### Introduction

The WindowOver returns the Window (or any object inheriting from Window such as Button, TextBox, etc.) that the Cursor is currently over. This will return the top-most window, so if the Cursor is over a Button which is contained inside a Window, the WindowOver property will contain a reference to the Button.

### Code Example

The following code performs "ClickLogic" when the user performs a primary click (left click on the mouse or a release on a touch screen) if the Cursor is not over any window. This is a common way to check if the cursor is over any UI.

```
Cursor cursor = GuiManager.Cursor;
if(cursor.PrimaryClick && cursor.WindowOver == null)
{
    ClickLogic();
}
```

### Using WindowOver to debug GUI problems

One very common bug is related to having multiple IWindows overlapping. In this case events may not be raising even though it appears they should be graphically. You can use the Cursor's WindowOver property in combination with the [FlatRedBall.Debugging.Debugger](../../../../frb/docs/index.php) to help identify the problem:

```
 FlatRedBall.Debugging.Debugger.Write( GuiManager.Cursor.WindowOver );
```

If the wrong window is being returned by WindowOver, you can diagnose/correct this by doing the following:

1. Verify that the two IWindows have different Z values if they are on the same layer **or** verify that the desired IWindows are on separate Layers
2. Call [GuiManager.SortZAndLayerBased()](../../../../frb/docs/index.php) to sort the IWindows in the GuiManager so that tests are performed in the right order.
3. See if the Window you are expecting to be over has its [Enabled](../../../../frb/docs/index.php) property set to true.

#### Gum and WindowOver

All Gum objects implement the IWindow interface, so all are (at least by interface) eligible for Cursor interaction. However, not all Gum objects will interact with the cursor. For more information, see the [Events on Gum Objects](../../../../gum/tutorials/tutorials-gum-events-on-gum-objects.md) tutorial.
