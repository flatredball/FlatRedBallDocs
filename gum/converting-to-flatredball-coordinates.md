# converting-to-flatredball-coordinates

### Introduction

Gum uses a different coordinate system compared to FlatRedBall. The separate Gum coordinate system exists for two reasons:

1. Gum objects are often positioned relative to the screen bounds rather than world coordinates. For example, a HUD should always appear at the top-left of the screen.
2. Gum objects may use different coordinate units. For example, a "Join Game" callout may be positioned 25% from the left edge of the screen rather than using pixel coordinates.

At times games may need to position FlatRedBall objects (such as entities) relative to the position of a Gum object. This document explains how to convert Gum to FlatRedBall coordinates.

### Converting from Gum to FlatRedBall Coordinates

The steps for converting are:

1. Convert the Gum coordinates to _screen coordinates_ - coordinates relative to the top-left of the screen
2. Convert the screen coordinates to _world coordinates_ - the coordinates used by FlatRedBall objects
3. (Optional) position the FlatRedBall object using the world coordinates.

For this example, consider a Gum screen with a single colored rectangle named ColoredRectangleInstance:

![](../../../media/2022-02-img_621be2f6dba1a.png)

Note that the rectangle is positioned according to its center. This example will position a FlatRedBall Circle named CircleInstance. Note that this code can be used to position any FlatRedBall positioned object (such as entities or other collision shapes).

![](../../../media/2022-02-img_621be41d3a77b.png)

The following code can be used to convert the rectangle's position (which in this case is the center) to screen coordinates:

```
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

![](../../../media/2022-02-img_621be43f015a0.png)

Notice that the example above uses the position of the ColoredRectangleInstance as defined by its XOrigin and YOrigin. If the rectangle's origin is changed to top-right in Gum...

![](../../../media/2022-02-img_621be4b9beaf8.png)

...then the FlatRedBall CircleInstance will also be positioned on the Gum object's top-right corner.

![](../../../media/2022-02-img_621be4ee13f73.png)

&#x20;
