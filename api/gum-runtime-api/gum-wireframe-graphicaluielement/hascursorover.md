# hascursorover

### Introduction

HasCursorOver is used to return if the argument world X and world Y coordinates are inside the calling GraphicalUiElements. This is an extension method requiring the RenderingLibrary namespace. Despite its name, this can be used to detect if a pair of world coordinates are inside the caller regardless of whether this is for UI/cursor checks or otherwise.

### Code Example - Detecting GuiManager.Cursor Over Gum Object

The following code can be used to determine if the cursor is over a GraphicalUiElement. Note, this does a bounds check on the Gum object even if the Gum object is not raising events.

```
void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;

    var isCursorOver = GumScreen.ColoredRectangleInstance.HasCursorOver(cursor);

    FlatRedBall.Debugging.Debugger.Write($"Cursor over: {isCursorOver}");
}
```

[![](../../../../media/2019-09-20\_05-26-27.gif)](../../../../media/2019-09-20\_05-26-27.gif)   &#x20;

### Code Example - Detecting Screen Coordinates on GraphicalUiElement

The following code shows how to detect if a ScreenX and ScreenY pair are inside a particular GraphicalUiElement:

```lang:c#
// Since this is an extension method, the following is required:
using RenderingLibrary;

// assuming screenX and screenY are valid screen coordinates

float worldX;
float worldY;

// Assuming the game uses the default system managers
var managers = global::RenderingLibrary.SystemManagers.Default;

screenX -= managers.Renderer.GraphicsDevice.Viewport.X;
screenY -= managers.Renderer.GraphicsDevice.Viewport.Y;

managers.Renderer.Camera.ScreenToWorld(
    screenX, screenY,
    out worldX, out worldY);

var isOver = graphicalUiElement.HasCursorOver(worldX, worldY);
```

&#x20;     &#x20;
