**For Glue users:** This article was written for individuals implementing Entities purely in code. If you are using Glue, then you can perform most of what is shown below through the Glue UI. For a working example of how to add collisions to an Entity, please read through the [Beefball tutorials](/frb/docs/index.php?title=Tutorials:Beefball.md "Tutorials:Beefball"), specifically [the tutorial which adds collision to the PlayerBall Entity](/frb/docs/index.php?title=Tutorials:Beefball.md:Creating_an_Entity "Tutorials:Beefball:Creating an Entity").

## Introduction

This article discusses the most common approach for performing collision between Entities and other objects. These other objects include collision maps as well as other Entities.

## Collision Member

The first step is to add Collision to an Entity. This is done by instantiating a [shape](/frb/docs/index.php?title=Shapes.md "Shapes") and [attaching](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.md "FlatRedBall.Math.IAttachable") it to the Entity in the Entity's constructor. The following code creates an Entity using a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") displaying the redball.bmp image as the visible representation and a [Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon") as the collision.

Code:

-   [Pastebin Link](http://pastebin.ca/2024139)
-   [SimpleEntity.cs](/frb/docs/images/1/10/SimpleEntity.cs.md "SimpleEntity.cs")

Notice that just like the visible representation, the collision is attached to the entity in its AddToManagers method.

## Performing Collision

Collision between an Entity containing a Collision member and any other object is performed nearly the same as between two [shapes](/frb/docs/index.php?title=Shapes.md "Shapes"). The following code instantiates the SimpleEntity from the links above and performs collision between the SimpleEntity instance and a list of [Polygons](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon"). This code sample is very similar to the code in the [CollideAgainstMove wiki entry](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md.CollideAgainstMove "FlatRedBall.Math.Geometry.Polygon.CollideAgainstMove").

Files Used: [Smiley.plylstx](/frb/docs/images/7/79/Smiley.plylstx.md "Smiley.plylstx")

Add the following using statements:

    using FlatRedBall.Math;
    using FlatRedBall.Math.Geometry;
    using FlatRedBall.Content.Polygon;
    using FlatRedBall.Input;

Add the following at class scope:

    SimpleEntity mEntity;
    PositionedObjectList<Polygon> mLoadedPolygons;

Add the following in Initialize after initializing FlatRedBall:

    mEntity = new SimpleEntity(FlatRedBallServices.GlobalContentManager);

    PolygonSaveList polygonSaveList = PolygonSaveList.FromFile(@"Smiley.plylstx");
    mLoadedPolygons = polygonSaveList.ToPolygonList();

    ShapeManager.AddPolygonList(mLoadedPolygons);

Add the following in Update:

    mEntity.Activity();

    foreach (Polygon polygon in mLoadedPolygons)
    {
        mEntity.Collision.CollideAgainstMove(
            polygon, 0, 1);
    }

![EntityCollision.png](/media/migrated_media-EntityCollision.png)

**Not sure how to load a file?** If you're unclear or can't remember how to add the Smiley.plylstx file linked above, then you might want to check out **[this article](/frb/docs/index.php?title=Tutorials:Adding_files_to_your_project.md "Tutorials:Adding files to your project").**

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
