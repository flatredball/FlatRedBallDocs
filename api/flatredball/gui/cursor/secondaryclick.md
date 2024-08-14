# SecondaryClick

### Introduction

SecondaryClick determines whether the secondary button (right mouse button on a mouse) was pushed last frame but released this frame.

### Code Example - Detecting Click on a UI Element

The SecondaryClick property can be used to detect whether a UI element, such as a Gum GraphicalUiElement, was clicked with the right mouse button.&#x20;

```csharp
// This would be checked every frame, such as in a screen's CustomActivity
var cursor = GuiManager.Cursor;
if(cursor.SecondaryClick && cursor.WindowOver == GumScreen.SomeGumObject)
{
    // The gum object was right-clicked, so perform some action
}
```
