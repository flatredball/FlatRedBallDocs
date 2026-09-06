# ShapeCollectionSave

### Introduction

ShapeCollectionSave is the serializable form of a [ShapeCollection](../../../math/geometry/shapecollection/). It holds the same shapes, but as plain data rather than as live objects, so it can be stored in a file and turned back into a ShapeCollection later.

The most common place to encounter one is animation collision. Frames in an AnimationChainList (.achx) can carry shapes authored in the AnimationEditor, and each frame exposes them as a ShapeCollectionSave - see [AnimationFrame ShapeCollectionSave](../../../graphics/animation/flatredball-graphics-animationframe/shapecollectionsave.md) for how to apply a frame's shapes to an entity's collision.

You would otherwise use ShapeCollectionSave directly only when writing a tool that reads or writes shape data.

### Creating a ShapeCollectionSave from a ShapeCollection

Add the following using statements:

```csharp
using FlatRedBall.Math.Geometry;
using FlatRedBall.Content.Math.Geometry;
```

Assuming `shapeCollection` is a valid [ShapeCollection](../../../math/geometry/shapecollection/):

```csharp
ShapeCollectionSave save = ShapeCollectionSave.FromShapeCollection(shapeCollection);
```

A ShapeCollectionSave can also be built by hand: instantiate one, then add "save" instances such as PolygonSave and CircleSave to it.

### Creating a ShapeCollection from a ShapeCollectionSave

Converting back produces live shapes. Assuming `save` is a valid ShapeCollectionSave:

```csharp
ShapeCollection newShapeCollection = save.ToShapeCollection();

// The shapes must be added to managers before they will draw or update:
newShapeCollection.AddToManagers();
```

### Saving to a File

ShapeCollectionSave writes itself to XML through its Save method, and reads back through the static FromFile method:

```csharp
save.Save(fileName);

ShapeCollectionSave loaded = ShapeCollectionSave.FromFile(fileName);
```
