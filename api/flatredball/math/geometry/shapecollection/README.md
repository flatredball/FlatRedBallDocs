# ShapeCollection

### Introduction

The ShapeCollection class is a container for a variety of shapes. The ShapeCollection class is often used for collision maps and to define triggers. ShapeCollections are often loaded from .shcx files created by the [PolygonEditor](../../../../../PolygonEditorWiki.md). ShapeCollections are a very common class due to the support of .shcx files in Glue.

### Accessing Shapes

The ShapeCollection provides a number of methods that can be used to perform actions on all contained Shapes (such as [AttachTo](../../../../../frb/docs/index.php)). However, you may be working on a game that requires access to individual shapes. The ShapeCollection exposes its shapes. The following members are available:

* AxisAlignedRectangles
* AxisAlignedCubes
* Capsule2Ds
* Circles
* Lines
* Polygons
* Spheres

These are all [PositionedObjectLists](../../../../../frb/docs/index.php) which can be accessed like regular lists. You can add and remove elements from these lists as well as modify the individual members inside the lists. If your need to perform special actions on all elements in a ShapeCollection you can do the following:

```csharp
// Assuming ShapeCollectionInstance is a valid ShapeCollection
for(int i = 0; i < ShapeCollectionInstance.AxisAlignedRectangles.Count; i++)
{
   // do something with ShapeCollectionInstance.AxisAlignedRectangles[i];
}
for(int i = 0; i < ShapeCollectionInstance.AxisAlignedCubes.Count; i++)
{
   // do something with ShapeCollectionInstance.AxisAlignedCubes[i];
}
// Continue writing loops for the other categories here...
```

Of course, you can also access the shapes using a foreach statement. Keep in mind that foreach statements may have performance penalties compared to regular for loops.

```csharp
foreach(var circle in ShapeCollectionInstance.Circles)
{
    // do something with circle, like perform collision
}
```

### Loading a ShapeCollection

ShapeCollections can be created by loading .shcx files.

#### Loading ShapeCollection From File

The following code loads a .shcx file into memory, adds all contained shapes to the [ShapeManager](../../../../../frb/docs/index.php). If you are using Glue you can add ShapeCollections to Screens and Entities just like other files. For an example on how to add a ShapeCollection to Glue, see [the Beefball tutorial on creating Screen collisions](../../../../../frb/docs/index.php). File used: [ShapeCollection.shcx](../../../../../frb/docs/images/b/b0/ShapeCollection.shcx) Add the following using statements:

```csharp
using FlatRedBall.Math.Geometry;
```

Add the following to Initialize after initializing FlatRedBall:

```csharp
ShapeCollection shapeCollection = FlatRedBallServices.Load<ShapeCollection>("shapeCollection.shcx");
shapeCollection.AddToManagers();
```

![ShapeCollection.png](../../../../../.gitbook/assets/migrated\_media-ShapeCollection.png)

### Saving a ShapeCollection

Although most games do not need ShapeCollection saving support, FlatRedBall provides easy-to-use classes for saving a ShapeCollection. For more information, see the [ShapeCollectionSave page](../../../../../frb/docs/index.php).

### ShapeCollection Shapes

All shapes in the ShapeCollection can be accessed through its member lists. The available lists are:

* AxisAlignedRectangles
* AxisAlignedCubes
* Circles
* Polygons
* Lines
* Spheres

The ShapeCollection can be thought of as a container for all of these lists. Therefore, you can use the individual lists to do anything you would do with a normal list such as:

```csharp
// Adding:
myShapeCollection.Circles.Add(someCircleInstance);

// Removing:
ShapeManager.Remove(myShapeCollection.AxisAlignedRectangles[0]);

// ...and anything else you'd want to do with shapes
```
