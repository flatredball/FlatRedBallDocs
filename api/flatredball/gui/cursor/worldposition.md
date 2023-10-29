## Introduction

WorldPosition returns a Vector2 of the cursor's world position (as opposed to screen position). WorldPosition can be used to place objects or perform manual detection of whether the cursor is over an object.

## Code Example - Moving an Object to the Cursor WorldPosition

The following code moves an object according to the cursor's position. Note that the ToVector3 extension method is used to convert a Vector2 to a Vector3

    circle.Position = GuiManager.Cursor.WorldPosition.ToVector3();
