## Introduction

The ShapeCollection provides a CollideAgainstMoveWithoutSnag method which tests if any shape contained in the calling ShapeCollection collides the argument shape and moves the argument shape accordingly. This method is different from CollideAgainstMove where CollideAgainstMoveWithoutSnag is an order independent operation where CollideAgainstMove is a order dependent operation. CollideAgainstMoveWithouSnag may be slightly slower than CollideAgainstMove and is recommended only if the order of the collisions matters.

## Arguments

The CollideAgainstMoveWithoutSnag method can be used to test collision against argument shapes. At the time of this writing, some shapes are not completely supported, but this is changing. If you encounter a NotImplementedException, please post on the [forums](/frb/forum.md) requesting the implementation needed for your project.

The following overloads are available:

    bool ShapeCollection.CollideAgainstMoveWithoutSnag(AxisAlignedRectangle axisAlignedRectangle)
    bool ShapeCollection.CollideAgainstMoveWithoutSnag(Circle circle)
    bool ShapeCollection.CollideAgainstMoveWithoutSnag(Polygon polygon)
