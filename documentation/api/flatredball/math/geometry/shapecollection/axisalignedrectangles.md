## Introduction

The AxisAlignedRectangles property is a property of type [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList"). Therefore, you can use this member the same way you would use a PositionedObjectList\<AxisAlignedRectangle\>.

## Code Example

The following shows how to loop through all rectangles in a ShapeCollection and perform collision between the rectangles and a Circle named CircleInstance:

    for(int i = 0; i < ShapeCollectionInstance.AxisAlignedRectangles.Count; i++)
    {
        circle.CollideAgainstMove(ShapeCollectionInstance.AxisAlignedRectangles[i], 0, 1);
    }
