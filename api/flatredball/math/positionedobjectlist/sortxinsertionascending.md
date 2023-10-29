# sortxinsertionascending

### Introduction

The SortXInsertionAscending (and SortYInsertionAscending/SortZInsertionAscending) function can be used to sort all contained PositionedObjects in a list by their X (or Y/Z) value.

### Code Example

The following code creates 3 [Circles](../../../../../frb/docs/index.php) and places them in a PositionedObjectList in descending X order. Then SortXInsertionAscending is called, and the positions of the Circles are printed out:

```
FlatRedBall.Math.PositionedObjectList<Circle> circleList =
    new FlatRedBall.Math.PositionedObjectList<Circle>();

// Let's create 3 Circles.  Their X values will
// be in decreasing order
Circle first = new Circle();
first.X = 10;
circleList.Add(first);

Circle second = new Circle();
second.X = 8;
circleList.Add(second);

Circle third = new Circle();
third.X = 6;
circleList.Add(third);

// Now let's sort them:
circleList.SortXInsertionAscending();

// Now let's print out the values:
foreach(Circle circle in circleList)
{
    FlatRedBall.Debugging.Debugger.CommandLineWrite(circle.Position);
}
```

![SortedCircles.PNG](../../../../../media/migrated\_media-SortedCircles.PNG)
