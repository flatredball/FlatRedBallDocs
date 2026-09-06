# ShapeCollection

### Introduction

A ShapeCollection is a container that holds shapes of mixed types - [AxisAlignedRectangles](../axisalignedrectangle/), [Circles](../circle/), [Polygons](../polygon/), [Lines](../line/), AxisAlignedCubes, Capsule2Ds, and Spheres - and lets you treat them as a single unit.

That last part is the reason to use one. A regular list holds a single type, so a collision area made of a rectangle and two circles would otherwise mean separate lists and separate calls for each. A ShapeCollection lets you:

* Collide against every contained shape with one [CollideAgainst](collideagainst.md) call, or push another object out of all of them with [CollideAgainstMove](collideagainstmove.md)
* [Attach](attachto.md) all shapes to a parent, so they follow an entity as it moves and rotates
* Show or hide all shapes at once through [Visible](visible.md), which is useful when debugging collision
* Add or remove the whole group from the [ShapeManager](../shapemanager/) in one call

Typical uses are collision areas built from more than one shape, level collision maps, and trigger regions such as doors, damage zones, and camera boundaries.

Most games do not create ShapeCollections directly. Entities marked as ICollidable get one named `Collision` automatically, and every shape added to the entity goes into it - see [Implements ICollidable](../../../../../glue-reference/entities/glue-reference-implements-icollidable.md). A ShapeCollection can also be added as an object in the FlatRedBall Editor; see [the ShapeCollection object page](../../../../../glue-reference/objects/object-types/glue-reference-shapecollection.md).

### Accessing Shapes

The ShapeCollection exposes its shapes through one list per type:

* AxisAlignedRectangles
* AxisAlignedCubes
* Capsule2Ds
* Circles
* Lines
* Polygons
* Spheres

Each is a PositionedObjectList and behaves like a regular list, so you can add to it, remove from it, and modify the shapes it holds:

```csharp
// Adding:
myShapeCollection.Circles.Add(someCircleInstance);

// Removing:
ShapeManager.Remove(myShapeCollection.AxisAlignedRectangles[0]);
```

To act on every shape of a given type, loop over the matching list:

```csharp
foreach(var circle in ShapeCollectionInstance.Circles)
{
    // do something with circle, like perform collision
}
```

A ShapeCollection has no single list containing every shape, so code that must touch all of them needs one loop per type.

### Adding a ShapeCollection to Managers

Shapes are drawn and updated only after they have been added to the [ShapeManager](../shapemanager/). A ShapeCollection adds all of its shapes at once:

```csharp
shapeCollection.AddToManagers();
```

Removing works the same way:

```csharp
shapeCollection.RemoveFromManagers();
```

ShapeCollections created in the FlatRedBall Editor are added to managers by generated code, so these calls are only needed for collections created in custom code.

### Saving a ShapeCollection

Most games do not need to save ShapeCollections at runtime, but FlatRedBall can convert one to and from a serializable form. For more information, see the [ShapeCollectionSave page](../../../content/math/geometry/flatredball-content-math-shapecollectionsave.md).
