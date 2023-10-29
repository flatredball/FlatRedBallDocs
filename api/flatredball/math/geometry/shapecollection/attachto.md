## Introduction

The AttachTo method is a shortcut method which can be used to attach all contained shapes to the argument object. In other words, the following two blocks of code are identical:

    someShapeCollection.AttachTo(newParent, false);

and

    someShapeCollection.AxisAlignedRectangles.AttachTo(newParent, changeRelative);
    someShapeCollection.Circles.AttachTo(newParent, changeRelative);
    someShapeCollection.Polygons.AttachTo(newParent, changeRelative);
    someShapeCollection.Lines.AttachTo(newParent, changeRelative);
    someShapeCollection.Spheres.AttachTo(newParent, changeRelative);
    someShapeCollection.AxisAlignedCubes.AttachTo(newParent, changeRelative);
    someShapeCollection.Capsule2Ds.AttachTo(newParent, changeRelative);

## Newly-added Shapes must be manually attached

The AttachTo method is a shortcut method which attaches all contained objects to the first argument. The ShapeCollection itself does not remember the existence of an attachment. This means:

-   If a shape is later added to the ShapeCollection, it must also be manually attached to the parent object, at least if the desired behavior is to have the entire ShapeCollection be attached as a whole.
-   It is possible to have different shapes in the same ShapeCollection attached to different objects.
