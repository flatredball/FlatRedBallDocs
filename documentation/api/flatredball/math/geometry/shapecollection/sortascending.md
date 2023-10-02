# sortascending

### Introduction

The SortAscending method sorts all contained elements in the ShapeCollection by their position values on the given axis. In other words, if this method is called with an argument of Axis.X, then all contained shapes will be sorted so that their X values are increasing. The sort uses a stable insertion sort making it incredibly fast on nearly-sorted or already-sorted lists.

### Common usage

ShapeCollections are often sorted so that axis-based partitioning can be performed when testing for collisions. If the ShapeCollection will not change after being created, then it only needs to be sorted once (likely when it is first created). Otherwise, it needs to be sorted whenever a change occurs - which may be as frequent as every frame. However, sorting every frame and using partitioning is likely faster than performing a brute-force collision check.

### Code Example

The following code can be used to sort a ShapeCollection along its X axis, then test for collisions using axis-based partitioning:

```
// assuming myShapeCollection is a valid ShapeCollection:
Axis sortAxis = Axis.X;
myShapeCollection.SortAscending(sortAxis);
// Assuming myCharacter has a property called Collision which is a shape:
bool usePartitioning = true;
// The max radii must be calculated before calling a partitionined CollideAgainst method
myShapeCollection.CalculateMaxRadii();
if(myShapeCollection.CollideAgainst(myCharacter.Collision, usePartitioning, sortAxis))
{
   // React to the collision here
}
```

Note that CalculateMaxRadii must be called in order for the ShapeCollection to know the maximum radii of all shapes (by category).

### Additional information

* [Axis Based Partitioning and Collision](../../../../../../frb/docs/index.php) - Talks about axis-based partitioning which is what the CollideAgainst uses internally when performing partitioned collisions.
