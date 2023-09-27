## Introduction

The ShapeCollection provides a CollideAgainstBounceWithoutSnag method which tests if any shape contained in the calling ShapeCollection collides the argument shape and moves the argument shape accordingly while also adjusting velocity. The "WithoutSnag" portion of the method name indicates that the method will attempt to perform the collision such that snagging will not occur. In other words, a row of rectangles should behave the same as one long rectangle.

This method is different from CollideAgainstBounce where CollideAgainstBounceWithoutSnag is an order independent operation where CollideAgainstBounce is a order dependent operation. CollideAgainstBounceWithouSnag may be slightly slower than CollideAgainstBounce and is recommended only if the order of the collisions matters.

## Arguments

The CollideAgainstBounceWithoutSnag method can be used to test collision against argument shapes. At the time of this writing, some shapes are not completely supported, but this is changing. If you encounter a NotImplementedException, please post on the [forums](/frb/forum.md) requesting the implementation needed for your project.

The following overloads are available:

    bool ShapeCollection.CollideAgainstBounceWithoutSnag(AxisAlignedRectangle axisAlignedRectangle, float elasticity)
    bool ShapeCollection.CollideAgainstBounceWithoutSnag(Circle circle, float elasticity)
    bool ShapeCollection.CollideAgainstBounceWithoutSnag(Polygon polygon, float elasticity)
