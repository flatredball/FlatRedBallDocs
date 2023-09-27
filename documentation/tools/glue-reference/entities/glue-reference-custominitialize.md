## Introduction

CustomInitialize is called once per entity instance when it is initialized. Initialization happens:

-   When an instance is created either in code by using the "new" operator, or if an instance is added through the FRB Editor. See below for more information.
-   Whenever an Entity is recycled through a factory.

## CustomInitialize and AddToManagers

The CustomInitialize method will only be called when an Entity instance is added to managers. For example consider the following code:

    // This assumes that the game has an Entity called Enemy:

    // enemy1 will have CustomInitialize called
    Enemy enemy1 = new Enemy();

    bool addToManagers = false;
    // enemy2 will not have CustomInitialize called since it is
    // not being added to managers:
    Enemy enemy2 = new Enemy(ContentManagerName, addToManagers);

    // enemy will not have CustomInitialize called since it is
    // not being added to managers (yet):
    Enemy enemy3 = new Enemy(ContentManagerName, addToManagers);
    // ...but now enemy3 will have CustomInitialize called
    enemy3.AddToManagers(null);

## CustomInitialize and Inheritance

Entities and Screens which have base types (inheritance) have two or more CustomInitialize functions depending on the inheritance depth. For example, if a screen Level1 inherits from GameScreen, each class (Level1 and GameScreen) has its own CustomInitialize method. Both are called by generated code - a base.CustomInitialize call is not needed. CustomInitialize is called on the base class first, then to more-derived. Using the example above, GameScreen.CustomInitialize is called first, then Level1.CustomInitialize.
