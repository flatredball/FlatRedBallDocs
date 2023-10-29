## Introduction

The AbsolutePointPosition method returns the absolute position of the point on the polygon matching the argument index. Passing an index outside of the list of points will result in an exception.

## Code Example

The following code shows how to create a bullet at the 2nd point on a polygon (index 1):

    var position = PolygonInstance.AbsolutePointPosition(1);
    var bullet = Factories.BulletFactory.CreateNew(position);
    // The bullet velocity can be adjusted after it has been created
