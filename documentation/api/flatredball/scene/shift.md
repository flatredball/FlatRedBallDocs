## Introduction

The Shift method is a method which can be used to move an entire Scene by the argument shiftVector. This method will work on all contained objects including SpriteGrids.

## Code Example

The following code shifts a scene 3 units on the X axis and 4 units on the Y axis:

    Vector3 shiftVector = new Vector3(3, 4, 0);
    // Assuming MyScene is a valid Scene
    MyScene.Shift(shiftVector);
