## Introduction

The IsPointInside method returns whether the argument X,Y are inside the Circle. The X and Y values are absolute values.

## Code Example

The following shows how to check if the [Cursor](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.md "FlatRedBall.Gui.Cursor") is inside a Circle instance:

    float worldX = GuiManager.Cursor.WorldXAt(0);
    float worldY = GuiManager.Cursor.WorldYAt(0);

    bool isInside = CircleInstance.IsPointInside(worldX, worldY);
