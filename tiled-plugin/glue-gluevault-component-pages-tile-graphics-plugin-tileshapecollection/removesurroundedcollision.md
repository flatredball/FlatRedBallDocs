# removesurroundedcollision

### Introduction

RemoveSurroundedCollision  removes all rectangles which are surrounded by other collisions on all four sides. Calling this method removes the "inside" of solid collision areas, resulting in only the outline tiles being preserved.

![](../../../../media/2017-11-img\_5a1081a9209fb.png)

This method can be used to reduce the number of collision objects to improve runtime performance and reduce memory usage. This method should only be used when the collision is solid because solid collisions only need their outline to function properly. However, non-solid collision (such as a collision area representing water that the user can swim through) should not use this method. RemoveSurroundedCollision  can provide performance improvements similar to merged collisions (such as AddMergedCollisionFromTilesWithProperty ), but this method does not introduce snagging so it is suitable to be used in platformers.

### Code Example

The following code shows how to remove all surrounding collisions using the RemoveSurroundedCollision  method.

```lang:c#
SolidCollision.Visible = true;
SolidCollision.AddCollisionFromTilesWithProperty(Level1, "HasCollision");
SolidCollision.RemoveSurroundedCollision();
```

Note that this method can be called after multiple AddCollision methods.
