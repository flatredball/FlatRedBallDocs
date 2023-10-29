## Introduction

The AddToManagers property controls whether Glue's generated code will add a given object to its associated managers - in other words it controls whether the object is added to the FlatRedBall Engine or not. This value is true by default. If an object is not added to managers, that means that the object will be instantiated, but it will not have any engine-provided behavior such as velocity, acceleration, rotational velocity, and attachments. Furthermore since the engine is responsible for rendering objects, any objects which have AddToManagers set to false will not be drawn.

## AddToManagers and Shapes

As mentioned above, AddToManagers is true by default, meaning any shape object (Circle, AxisAlignedRectangle, Polygon) will be added to the engine. This means that they will:

-   Be drawn by the engine
-   Have every-frame activity be applied automatically such as velocity, rotation, and rotational velocity

Both of these behaviors are usually not needed for shapes, especially when a game is nearing completion. Therefore, setting AddToManagers to false on shapes will generally result in improvement in your game's frame rate.

## Usage

AddToManagers is usually left to its default value of true. Most objects will not need this value changed. However, this value may be set to true if your game requires that an object not be added to managers until after its container is created, or based off of a certain condition. For example, you may want to keep a character in a role playing game from appearing in a room until the player has completed a certain quest. Therefore, you may want to manually add the character instance in code in the Screen's CustomInitialize only if the user has completed the quest. Objects which are part of FlatRedBall managers have every-frame logic performed on them by the engine. Delaying or not adding an object to managers will improve performance slightly, and you may see a significant performance improvement in your game if you do not add objects which are not needed.
