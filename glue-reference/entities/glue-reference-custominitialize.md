# CustomInitialize

### Introduction

CustomInitialize is called once per entity instance when it is initialized. Initialization happens in any of the following situations:

* When an instance is created either in code by using the "new" operator, or if an instance is added through the FRB Editor. See below for more information.
* When an instance is created through tiles in a Tiled map (tmx)
* When an Entity is recycled through a factory

### Common CustomInitialize Usage

By default CustomInitialize is an empty function.

```csharp
private void CustomInitialize()
{

}
```

Any code can be added to CustomInitialize to prepare an entity for use. Simple entities may not require any code in CustomInitialize, but code can be added for the following:

* Preparing animations (using [AnimationController](../../api/flatredball/graphics/animation/animationcontroller.md) )
* Dynamically creating FRB objects such as populating a List of Sprites
* Adding conditional debug code such as turning on the visibility of collision shapes

### CustomInitialize Should Not Depend on External Context

CustomInitialize should not include any code that depends on the current screen. For example, if an Enemy entity needs to initialize its logic according to the current PlayerList in GameScreen, CustomInitialize should not access GameScreen. Instead, initialization which requires external context (such as a list in a Screen) should do so in a function which is called by the Screen. This keeps your entity portable, and reduces the chances of errors occurring due to improper casting or unexpected access of lists before they are available.

Using the example of initializing enemy logic, an Enemy entity may have the following code for initialization:

```
private void CustomInitialize()
{
  // do any initialization here which does not depend on the GameScreen or any
  // other external context
}

public void InitializeAi(PositionedObjectList<Player> players)
{
  // do initialization here if it depends on external context
}
```

In this case, InitializeAi would be called by the GameScreen, as shown in the following example code:

```
// assuming that newEnemyPosition is a valid Vector3:
var enemy = Factories.EnemyFactory.CreateNew(newEnemyPosition);
// `this` refers to the GameScreen, so pass the GameScreen's PlayerList:
enemy.InitializeAi(this.PlayerList);
```

### CustomInitialize and AddToManagers

The CustomInitialize method will only be called when an Entity instance is added to managers. For example consider the following code:

```
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
```

### CustomInitialize and Inheritance

Entities and Screens which have base types (inheritance) have two or more CustomInitialize functions depending on the inheritance depth. For example, if a screen Level1 inherits from GameScreen, each class (Level1 and GameScreen) has its own CustomInitialize method. Both are called by generated code - a base.CustomInitialize call is not needed. CustomInitialize is called on the base class first, then to more-derived. Using the example above, GameScreen.CustomInitialize is called first, then Level1.CustomInitialize.
