# BaseScreen

### Introduction

The BaseScreen value controls the base screen from which the current screen is derived. The derived screen will have all of the objects, files, events, variables, and code of the base screen, but can add more functionality and content in Glue and code. In code setting the BaseScreen sets the screen to inherit from the base screen.

![](../../.gitbook/assets/2019-07-img\_5d1ece07406ac.png)

### Level Screens Using GameScreen as BaseScreen

The recommended pattern for creating multiple levels is to create one Screen (called a level Screen) for each level, each inheriting from GameScreen. As of March 2021, Glue recommends this approach by providing options to create Level screens which inherit from GameScreen.

![](../../.gitbook/assets/2021-03-img\_604390b11a3cc.png)

In this case, all of the common objects (such as enemy lists, bullet lists, and collision TileShapeCollections) should be defined in the GameScreen. Similarly, CollisionRelationships should also be defined in the GameScreen. Since the level Screen uses the GameScreen as its base, then all level Screens will also have the same objects at runtime.
