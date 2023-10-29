## Introduction

The ShapeCollection provides a CollideAgainst method which tests if any shape contained in the calling ShapeCollection collides the argument shape. The CollideAgainst method can also be called to test if two ShapeCollections have any shapes that collide between the two.

## Arguments

The CollideAgainst method can be used to test collision against argument shapes. At the time of this writing, some shapes are not completely supported, but this is changing. If you encounter a NotImplementedException, please post on the [forums](/frb/forum.md) requesting the implementation needed for your project.

The following overloads are available:

    bool ShapeCollection.CollideAgainst(AxisAlignedCube axisAlignedCube)
    bool ShapeCollection.CollideAgainst(AxisAlignedRectangle axisAlignedRectangle)
    bool ShapeCollection.CollideAgainst(Capsule2D capsule2D)
    bool ShapeCollection.CollideAgainst(Circle circle)
    bool ShapeCollection.CollideAgainst(Line line)
    bool ShapeCollection.CollideAgainst(Polygon polygon)
    bool ShapeCollection.CollideAgainst(Sphere sphere)

The ShapeCollection class can also collide against other ShapeCollections:

    bool CollideAgainst(ShapeCollection otherShapeCollection)
