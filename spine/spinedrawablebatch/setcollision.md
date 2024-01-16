# SetCollision

### Introduction

The SetCollision function can be used to assign/update collision on an ICollidable through its ShapeCollection. In other words, this method allows the creation of collision through the Spine tool which can be used to create CollisionRelationships, or to perform manual collision checks.

Keep in mind that you are not required to define collision in a Spine file. If your game works well without the precise collision offered by Spine bounding boxes, then you can add shapes such as AxisAlignedRectangles and Circles to your entity.

### Defining Collision in Spine

Spine has support for bounding boxes - which conceptually correspond to FlatRedBall Polygons.

<figure><img src="../../.gitbook/assets/image (35).png" alt=""><figcaption><p>Polygons in Spine</p></figcaption></figure>

These _bounding boxes_ can be converted to FlatRedBall Polygons which can be used in your project. These polygons are fully-featured, just like polygons created either in the FRB Editor or in code. In other words, these polygons have the following characteristics:

* They are attached to the Entity, so solid (move/bounce) collision will result in the entity being repositioned and have its velocity changed according to the physics applied.
* They can be added to the Entity's Collision ShapeCollection so they can be used in collision relationships.
* They are named and can be exposed in the FRB Editor so that CollisionRelationships with subcollisions can reference them

Furthermore, polygons from Spine have the following features and characteristics:

* Polygons can be defined in the FRB Editor to match the names of the polygons, or they can be created at runtime without a corresponding FRB Editor entry
* Polygons respond to animations, so if a SpineDrawableBatch changes its rotation or scale, the FlatRedBall Polygon automatically adjusts

### SetCollision to Create and Modify Polygons

To use SpineDrawableBatch collisions, the SetCollision method needs to be called every frame. Typically this is called in the CustomActivity (or derived method) inside an entity which implements ICollidable as shown in the following code snippet:

```csharp
private void CustomActivity()
{
    SpineDrawableBatch.SetCollision(
        this.Collision, // The ShapeCollection to fill/modify
        this, // The parent for any newly-created polygons
        true // createMissingShapes - Whether to create new polygons
        );
}
```

This method updates the polygons in the argument ShapeCollection (`this.Collision`) every frame. The code checks for name matches between the bounding box in Spine and the name of the FlatRedBall Polygon in the ShapeCollection. If a match is found, then the FlatRedBall Polygon is updated to match the Spine object. If a match is not found, then a new FlatRedBall Polygon is created if the last argument (createMissingShapes) is `true`.

Typically, if you would like to define the collision in Spine without creating anything in the FlatRedBall Editor, then you can pass `true` as the final parameter. In this case, the Objects folder would not contain any FlatRedBall Polygons, and every bounding box in the Spine object would be used in collision relationships.

<figure><img src="../../.gitbook/assets/image (36).png" alt=""><figcaption><p>Soldier Entity with no Pre-defined Polygons</p></figcaption></figure>

By contrast if you would like to assign custom collision per-shape (such as by using CollisionRelationship subcollisions), you can define a polygon in the FlatRedBall Editor. You do not need to create the points on the newly-created Polygon in the FlatRedBall Editor since they will be updated every frame by the SetCollision call. The only requirement is that the Polygon that you create has a name that matches one of the bounding boxes in your Spine file.

<figure><img src="../../.gitbook/assets/image (37).png" alt=""><figcaption><p>Defining a Polygon named footPrintCollision</p></figcaption></figure>

In this case, the Polygon will automatically be added to the Collision ShapeCollection, and it will be modified by the SetCollision call every frame.

Note that the Polygon must be part of the Collision ShapeCollection. In other words, IncludeInICollidable must remain true, which is the default. If you set this to false in FlatRedBall, then the `SetCollision` method will not find this Polygon.

<figure><img src="../../.gitbook/assets/image (38).png" alt=""><figcaption><p>IncludeInICollidable must be true</p></figcaption></figure>

You are free to define as many or as few Polygons as you would like in FlatRedBall. If you define them, then SetCollision will update them. If you do not define them, then SetCollision will either add them (if `true` is passed as for createMissingShapes), or they will be completely ignored. Whether you define them, and whether you pass true or false for the createMissingShapes parameter depends on how much explicit control you would like over the definition of your polygons.
