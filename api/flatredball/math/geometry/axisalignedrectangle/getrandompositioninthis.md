# getrandompositioninthis

### Introduction

GetRandomPositionInThis returns a [Vector3](../../../../../../frb/docs/index.php) representing a random position in the calling AxisAlignedRectangle. This value can be used for any logic, such as randomly positioning an object within an AxisAlignedRectangle.

### Code Example

The following example can be used to create 50 [Circles](../../../../../../frb/docs/index.php) inside an AxisAlignedRectangle.

The code assumes that the rectangle is called AxisAlignedRectangleInstance and that you have a CircleList to store all the created Circles:

```
int numberOfCirclesToCreate = 50;
for(int i = 0; i < numberOfCirclesToCreate; i++)
{
    Circle circle = ShapeManager.AddCircle();
    circle.Position = AxisAlignedRectangleInstance.GetRandomPositionInThis();
    CircleList.Add(circle);
}
```
