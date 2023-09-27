## Introduction

The ShapeCollection class is a container for a variety of shapes. The ShapeCollection class is often used for collision maps and to define triggers. ShapeCollections are often loaded from .shcx files created by the [PolygonEditor](/PolygonEditorWiki.md). ShapeCollections are a very common class due to the support of .shcx files in Glue.

## Accessing Shapes

The ShapeCollection provides a number of methods that can be used to perform actions on all contained Shapes (such as [AttachTo](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.AttachTo.md "FlatRedBall.Math.Geometry.ShapeCollection.AttachTo")). However, you may be working on a game that requires access to individual shapes. The ShapeCollection exposes its shapes. The following members are available:

-   AxisAlignedRectangles
-   AxisAlignedCubes
-   Capsule2Ds
-   Circles
-   Lines
-   Polygons
-   Spheres

These are all [PositionedObjectLists](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") which can be accessed like regular lists. You can add and remove elements from these lists as well as modify the individual members inside the lists. If your need to perform special actions on all elements in a ShapeCollection you can do the following:

    // Assuming ShapeCollectionInstance is a valid ShapeCollection
    for(int i = 0; i < ShapeCollectionInstance.AxisAlignedRectangles.Count; i++)
    {
       // do something with ShapeCollectionInstance.AxisAlignedRectangles[i];
    }
    for(int i = 0; i < ShapeCollectionInstance.AxisAlignedCubes.Count; i++)
    {
       // do something with ShapeCollectionInstance.AxisAlignedCubes[i];
    }
    // Continue writing loops for the other categories here...

Of course, you can also access the shapes using a foreach statement. Keep in mind that foreach statements may have performance penalties compared to regular for loops.

    foreach(var circle in ShapeCollectionInstance.Circles)
    {
        // do something with circle, like perform collision
    }

## Loading a ShapeCollection

ShapeCollections can be created by loading .shcx files.

### Loading ShapeCollection From File

The following code loads a .shcx file into memory, adds all contained shapes to the [ShapeManager](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.md "FlatRedBall.Math.Geometry.ShapeManager"). If you are using Glue you can add ShapeCollections to Screens and Entities just like other files. For an example on how to add a ShapeCollection to Glue, see [the Beefball tutorial on creating Screen collisions](/frb/docs/index.php?title=Tutorials:Beefball:Creating_the_Screen_Collision.md "Tutorials:Beefball:Creating the Screen Collision"). File used: [ShapeCollection.shcx](/frb/docs/images/b/b0/ShapeCollection.shcx.md "ShapeCollection.shcx") Add the following using statements:

    using FlatRedBall.Math.Geometry;

Add the following to Initialize after initializing FlatRedBall:

    ShapeCollection shapeCollection = FlatRedBallServices.Load<ShapeCollection>("shapeCollection.shcx");
    shapeCollection.AddToManagers();

![ShapeCollection.png](/media/migrated_media-ShapeCollection.png)

## Saving a ShapeCollection

Although most games do not need ShapeCollection saving support, FlatRedBall provides easy-to-use classes for saving a ShapeCollection. For more information, see the [ShapeCollectionSave page](/frb/docs/index.php?title=FlatRedBall.Content.Math.Geometry.ShapeCollectionSave.md "FlatRedBall.Content.Math.Geometry.ShapeCollectionSave").

## ShapeCollection Shapes

All shapes in the ShapeCollection can be accessed through its member lists. The available lists are:

-   AxisAlignedRectangles
-   AxisAlignedCubes
-   Circles
-   Polygons
-   Lines
-   Spheres

The ShapeCollection can be thought of as a container for all of these lists. Therefore, you can use the individual lists to do anything you would do with a normal list such as:

    // Adding:
    myShapeCollection.Circles.Add(someCircleInstance);

    // Removing:
    ShapeManager.Remove(myShapeCollection.AxisAlignedRectangles[0]);

    // ...and anything else you'd want to do with shapes

## ShapeCollection Members

-   [FlatRedBall.Math.Geometry.ShapeCollection.AttachTo](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.AttachTo.md "FlatRedBall.Math.Geometry.ShapeCollection.AttachTo")
-   [FlatRedBall.Math.Geometry.ShapeCollection.AxisAlignedRectangles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.AxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.AxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainst](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainst.md "FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainst")
-   [FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainstBounceWithoutSnag](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainst.mdBounceWithoutSnag "FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainstBounceWithoutSnag")
-   [FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainstMove](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainst.mdMove "FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainstMove")
-   [FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainstMoveWithoutSnag](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainst.mdMoveWithoutSnag "FlatRedBall.Math.Geometry.ShapeCollection.CollideAgainstMoveWithoutSnag")
-   [FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedCubes](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionCapsule2Ds](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionCircles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionLines](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionPolygons](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionSpheres](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles.md "FlatRedBall.Math.Geometry.ShapeCollection.LastCollisionAxisAlignedRectangles")
-   [FlatRedBall.Math.Geometry.ShapeCollection.SortAscending](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.SortAscending.md "FlatRedBall.Math.Geometry.ShapeCollection.SortAscending")
-   [FlatRedBall.Math.Geometry.ShapeCollection.Visible](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeCollection.Visible.md "FlatRedBall.Math.Geometry.ShapeCollection.Visible")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
