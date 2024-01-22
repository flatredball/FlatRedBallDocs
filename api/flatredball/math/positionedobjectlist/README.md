# PositionedObjectList

### Introduction

The PositionedObjectList is an object which can store lists of [PositionedObjects](../../positionedobject/). It is commonly used to store lists of [Entities](../../../../glue-reference/entities/) and shapes such as [Polygons](../../content/polygon/). The PositionedObjectList inherits from the [AttachableList](../attachablelist/) and it establishes [two-way relationships](https://docs.flatredball.com/flatredball/api/flatredball/math/attachablelist#two-way-relationships) with objects that are added to it.

### Common Usage

Most FlatRedBall games use the PositionedObjectList. The PositionedObjectList is common both in custom code as well as in generated code.

#### What types are stored in PositionedObjectLists

The PositionedObjectList is a dynamic list which is made to specifically store [PositionedObjects](../../positionedobject/) and any classes which inherit from [PositionedObject](../../positionedobject/). The most common types stored in PositionedObjectLists are:

* [Entities](../../../../glue-reference/entities/) - Any entity created in the FRB Editor can be stored in a PositionedObjectList. Lists added to Screens or other Entities inside the FRB Editor are PositionedObjects. All entity lists in GameScreen (created by default when a new entity is created) are of type PositionedObjectList.
* [FlatRedBall.Math.Geometry.Circle](../geometry/circle/)
* [FlatRedBall.Math.Geometry.Polygon](../geometry/polygon/)
* [FlatRedBall.Math.Geometry.AxisAlignedRectangle](../geometry/axisalignedrectangle/)

#### Example - Instantiating a PositionedObjectList in Code

Most PositionedObjectList instances are created through the FRB Editor. You can also create instances in custom code.

The PositionedObjectList class is a generic class. So, to instantiate one, you need to use the type that the PositionedObjectList will contain:

```csharp
// Add the following using statement
using FlatRedBall.Math;

// Here's how to make a list of Circles:
PositionedObjectList<Circle> circles = new PositionedObjectList<Circle>();

// And here's how to make one for Enemies (assuming you have an Enemy Entity):
PositionedObjectList<Enemy> enemies = new PositionedObjectList<Enemy>();
```

#### Removing items from lists

Most of the time items in PositionedObjectLists are added automatically in generated code. These include:

* Enitity instances added explicitly through the FlatRedBall Editor, such as a Player being in the PlayerList in GameScreen
* Entity instances added through factories at runtime, such as a Bullet entity being created when the player presses the shoot button. If the Bullet is created using its factory, then it will automatically be added to the BulletList in the current Screen (usually GameScreen)
* Sprites and shapes added to an Entity's Children property - this happens automatically when an object is added to an Entity.

In all of these cases, there is no need to explicitly remove objects from the list - when the Entity or Screen is destroyed then the object gets removed from its lists.&#x20;

Note that if an entity is created at runtime (such as a Bullet), it may be destroyed at runtime as well. For example, your game may include bullets which only survive for a few seconds after being fired. In this case you need to explicitly call Destroy on the bullet. By calling Destroy, the bullet is automatically removed from the PositionedObjectLists that it belongs to, including the (likely) BulletList in GameScreen.

At times you may need to perform removal of entities explicitly by accessing the list of objects. For example, your game may destroy Enemy instances when they move outside of the screen. If you do this, you will want to use a _reverse loop_ so that any removals do not result in skipping checks that frame, as shown in the following code:

```csharp
// use a reverse for-loop
for(int i = EnemyList.Count - 1; i > -1; i--)
{
   Enemy enemy = EnemyList[i];

   // Assume that IsOutsideOfScreen is a valid method
   if(enemy.IsOutsideOfScreen())
   {
       // Destroy results in the Enemy instance being
       // removed from any PositionedObjectList that it belongs to.
       enemy.Destroy();
   }
}
```
