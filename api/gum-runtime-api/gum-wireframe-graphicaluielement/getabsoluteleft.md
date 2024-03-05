# GetAbsoluteLeft

### Introduction

GetAbsoluteLeft returns the left edge of the calling object in world coordinates. This is in absolute pixels - it is not relative to its parent. Note that this method does not consider rotation, so rotated elements may not return correct values.

### Code Example - Detecting Collision Between GraphicalUiElements

The GetAbsolute functions provide information useful for performing collision between GraphicalUielements.

```csharp
// requires the following using statement for extension method access:
using RenderingLibrary;

// Assuming firstObject and secondObject are valid GraphicalUiElement instances
var collide = firstObject.GetAbsoluteRight() > secondObject.GetAbsoluteLeft() &&
    firstObject.GetAbsoluteLeft() < secondObject.GetAbsoluteRight() &&
    firstObject.GetAbsoluteBottom() > secondObject.GetAbsoluteTop() &&
    firstObject.GetAbsoluteTop() < secondObject.GetAbsoluteBottom();
```
