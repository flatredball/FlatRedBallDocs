# Converting Gum Coordinates

### Introduction

Gum uses a different coordinate system compared to FlatRedBall. The separate Gum coordinate system exists for two reasons:

1. Gum objects are often positioned relative to the screen bounds rather than world coordinates. For example, a HUD should always appear at the top-left of the screen.
2. Gum objects may use different coordinate units. For example, a "Join Game" callout may be positioned 25% from the left edge of the screen rather than using pixel coordinates.

At times games may need to position FlatRedBall objects (such as entities) relative to the position of a Gum object. This document explains how to convert Gum to FlatRedBall coordinates.

Note that it is possible to add Gum components to FlatRedBall entities, and doing so results in the components being drawn in _world coordinates_ (FRB coordinates). Adding a Gum component to a FlatRedBall Entity is the easiest way to position a Gum object in world space. For more information see the [Components in FlatRedBall Entities page](adding-components-to-entities.md).

### Converting from Gum to Screen Coordinates

Gum objects which have no parents and which are using absolute X and Y coordinates are already in screen coordinates. Of course, most Gum objects are nested inside other parent Gum objects, and they may be using other X and Y units.&#x20;

The following code shows how to display the four edge bounds for a ColoredRectangleInstance:

```csharp
 var rectangle = GumScreen.ColoredRectangleInstance;
 var left = rectangle.AbsoluteLeft;
 var top = rectangle.AbsoluteTop;
 var right = rectangle.AbsoluteLeft + rectangle.GetAbsoluteWidth();
 var bottom = rectangle.AbsoluteTop + rectangle.GetAbsoluteHeight();

 FlatRedBall.Debugging.Debugger.Write(
     "Left:" + left + " Top:" + top + " Right:" + right + " Bottom:" + bottom);
```



<figure><img src="../.gitbook/assets/image (50).png" alt=""><figcaption><p>Edge coordiantes displayed for centered ColoredRectangle instance</p></figcaption></figure>

### Converting from Gum to FlatRedBall Coordinates

The high level steps for converting from Gum to FlatRedBall coordinates are:

1. Convert the Gum coordinates to _screen coordinates_ - coordinates relative to the top-left of the screen
2. Convert the screen coordinates to _world coordinates_ - the coordinates used by FlatRedBall objects
3. (Optional) position the FlatRedBall object using the world coordinates.

For this example, consider a Gum screen with a single colored rectangle named ColoredRectangleInstance:

![Blue rectangle in Gum](../.gitbook/assets/2022-02-img\_621be2f6dba1a.png)

Note that the rectangle is positioned according to its center. This example will position a FlatRedBall Circle named CircleInstance. Note that this code can be used to position any FlatRedBall positioned object (such as entities or other collision shapes).

![CircleInstance in PositioningScreen](../.gitbook/assets/2022-02-img\_621be41d3a77b.png)

The following code can be used to convert the rectangle's position (which in this case is the center) to screen coordinates:

```csharp
void CustomInitialize()
{
    // 1 convert the position of the rectangle to screen
    var rectangleScreenX = GumScreen.ColoredRectangleInstance.AbsoluteX;
    var rectangleScreenY = GumScreen.ColoredRectangleInstance.AbsoluteY;

    // 2 convert the screen to world
    var worldPosition = new Vector3();
    MathFunctions.WindowToAbsolute(
        (int)rectangleScreenX, 
        (int)rectangleScreenY, 
        ref worldPosition);

    // 3 Position the FlatRedBall object according to worldPosition
    CircleInstance.Position = worldPosition;
}
```

![Circle positioned in the center of the blue rectangle](../.gitbook/assets/2022-02-img\_621be43f015a0.png)

Notice that the example above uses the position of the ColoredRectangleInstance as defined by its XOrigin and YOrigin. If the rectangle's origin is changed to top-right in Gum...

![Blue rectangle in Gum with origin top-right](../.gitbook/assets/2022-02-img\_621be4b9beaf8.png)

...then the FlatRedBall CircleInstance will also be positioned on the Gum object's top-right corner.

![Circle positioned at the blue rectangle's top-right corner](../.gitbook/assets/2022-02-img\_621be4ee13f73.png)

### Converting from FlatRedBall to Gum Coordinates

The high level steps for converting from FlatRedBall to Gum coordinates are:

1. Convert the FlatRedBall coordinates to Screen pixel coordinates
2. Convert the screen pixel coordinates to Gum screen coordinates (considering zooming)
3. (Optional) Position a Gum object using the Gum screen coordinates

The following code creates colored rectangle instances on clicks. Notice that the Cursor's world coordinates are used to get the Gum coordinates:

```csharp
void CustomActivity(bool firstTimeCalled)
{
    var cursor = GuiManager.Cursor;

    if(cursor.PrimaryClick)
    {
        var worldX = cursor.WorldX;
        var worldY = cursor.WorldY;

        var gumCoordinates = GetGumCoordinates(worldX, worldY);

        var rectangle = new ColoredRectangleRuntime();
        rectangle.X = gumCoordinates.X;
        rectangle.Y = gumCoordinates.Y;
        rectangle.AddToManagers();
    }
}

public Vector2 GetGumCoordinates(float worldX, float worldY)
{
    var camera = FlatRedBall.Camera.Main;
    camera.WorldToScreen(worldX, worldY, 0, out int screenX, out int screenY);
    var gumZoom = SystemManagers.Default.Renderer.Camera.Zoom;
    return new Vector2(screenX, screenY) / gumZoom;
}
```

<figure><img src="../.gitbook/assets/24_23_05_17.gif" alt=""><figcaption><p>Adding ColoredRectangleRuntime instances by clicking the mouse</p></figcaption></figure>
