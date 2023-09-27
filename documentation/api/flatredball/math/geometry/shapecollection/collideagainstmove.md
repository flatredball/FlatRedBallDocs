## Introduction

CollideAgainstMove is a function which takes any shape type (such as [AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle") or [Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle "FlatRedBall.Math.Geometry.Circle")) and calls CollideAgainstMove between the argument and all shapes contained in the ShapeCollection.

This method is an alternative to writing loops for all of the contained objects and manually calling CollideAgainstMove. Using CollideAgainstMove has a number of benefits:

1.  Less code to write - CollideAgainstMove will perform collision against all contained objects in a ShapeCollection. The ShapeCollection object can contain many types of objects, and manually writing for-loops means that one for loop for each type of object is required.
2.  Partitioning (optional) - CollideAgainstMove can perform partitioning which can greatly speed up collision calls. See the later part of this page for information on partitioning.

## CollideAgainstMove partitioning example

The following example creates a ShapeCollection, populates it with a very large number of AxisAlignedRectangles, then performs CollideAgainstMove between a free-floating AxisAlignedRectangle and the entire ShapeCollection.

This example assumes that the ShapeCollection and AxisAlignedRectangle (named ShapeCollectionInstance and AxisAlignedRectangleInstance) are both valid instances. The syntax used here assumes a Glue screen. AxisAlignedRectangleInstance is also colored red to help differentiate between it and the static shapes.

Add the following to CustomInitialize:


     // Use this number to create control how many rectangles are created.
     // Let's make a lot of them!
     const int numberOfRectangles = 5000;

     for (int i = 0; i < numberOfRectangles; i++)
     {
         // Let's spread out the rectangles
         const float minBoundary = -3000;
         const float range = 6000;

         AxisAlignedRectangle newRectangle = new AxisAlignedRectangle();
         newRectangle.Visible = true;
         newRectangle.X = minBoundary +
             (float)FlatRedBallServices.Random.NextDouble() * range;

         newRectangle.Y = minBoundary +
             (float)FlatRedBallServices.Random.NextDouble() * range;

         newRectangle.Width = 32;
         newRectangle.Height = 32;

         ShapeCollectionInstance.AxisAlignedRectangles.Add(newRectangle);
     }
     
     // Now that all shapes have been added, we need to have the ShapeCollection
     // Check the radii of all of its contained shapes.  If your ShapeCollection is
     // static (that is, no shapes are being added to it), then you only have to do this
     // once after all shapes have been added.  Otherwise, you will have to do it every
     // time you add a shape:
     ShapeCollectionInstance.CalculateAllMaxRadii();
     // We also need to make sure that we sort all contained objects.  If nothing is
     // moving or being added to your ShapeCollection, then you only need to call this
     // one time as well:
     ShapeCollectionInstance.SortAscending(FlatRedBall.Math.Axis.X);

Add the following to CustomActivity:

    // Move the rectangle:
    InputManager.Keyboard.ControlPositionedObject(AxisAlignedRectangleInstance, 100);

    // Have the camera follow the rectangle:
    Camera.Main.XVelocity = AxisAlignedRectangleInstance.X - Camera.Main.X;
    Camera.Main.YVelocity =  AxisAlignedRectangleInstance.Y - Camera.Main.Y;

    // Finally do the collision:
    const bool considerPartitioning = true;

    ShapeCollectionInstance.CollideAgainstMove(
        AxisAlignedRectangleInstance, considerPartitioning, FlatRedBall.Math.Axis.X,
        1, 0);

![CollideAgainstMovePartitioned.PNG](/media/migrated_media-CollideAgainstMovePartitioned.PNG)

### Performance benefits

The example above shows how to use CollideAgainstMove with the optional partitioning arguments. To recap, to perform partitioned collision, the following are required:

-   The ShapeCollection must have CalculateAllMaxRadii called prior to the CollideAgainstMove method. If the ShapeCollection adds objects, or if the objects in the ShapeCollection change size, then CalculateAllMaxRadii must be called again.
-   The ShapeCollection must have SortAscending called prior to the CollideAgainstMove method. If any objects move or are added to the ShapeCollection, then this method must be called again. Notice that the argument for which axis to sort on must match the axis used in CollideAgainstMove. This axis should equal the most distributed axis.

The benefit of this call is that it is considerably faster than simply calling CollideAgainstMove. The downside is that it requires some setup (calling the two functions), and maintenance (calling the two functions again if anything changes). Keep in mind that CalculateAllMaxRadii and SortAscending can be expensive functions for large ShapeCollections, so this method of collision is most effective when the ShapeCollection does not change at all, or if it changes very infrequently.

The number of rectangles in this sample is limited to 5000, but this number could likely be increased to to be much higher. It is very likely that a program with a larger number of rectangles would experience slowdown from rendering the rectangles before it would experience any slowdown on collision due to the efficiency of the partitioned CollideAgainstMove method. If the rectangles were invisible, then the number could go very high without any performance problems.
