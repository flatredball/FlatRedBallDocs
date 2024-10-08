# AdjustRepositionDirectionsOnAddAndRemove

### Introduction

AdjustRepositionDirectionsOnAddAndRemove determines whether a TileShapeCollection adjusts the RepositionDirections property on contained AxisAlignedRectangles when a new rectangle is added. This value defaults to true, and in most cases it should be left unchanged. For more information on the RepositionDirections, including how it pertains to TileShapeCollections, see the [AxisAlignedRectangle.RepositionDirections](../../api/flatredball/math/geometry/axisalignedrectangle/repositiondirections.md) page.

### RepositionDirections and Multiple TileShapeCollections

By default, TileShapeCollections adjust the contained rectangle RepositionDirections to prevent snagging. For example, the following image shows how RepositionDirections are adjusted to prevent snagging on a flat surface.

![](../../.gitbook/assets/2021-04-img\_606dce4158d97.png)

The image above displays the RepositionDirections of four rectangles, all of which belong to the same TileShapeCollection. However, consider a situation where two TileShapeCollections are needed. For example, a game may have two TileShapeCollections:

* SolidCollision (white, regular ground collision)
* IceCollision (blue, slippery collision)

In this case, each TileShapeCollection would adjust the RepositionDirections of each of its contained rectangles, but areas where the TileShapeCollections touch would not be properly handled, as shown in the following image.

![](../../.gitbook/assets/2021-04-img\_606dcf722bc2a.png)

In this case if a player were to walk across the transition between SolidCollision and IceCollision, the player's may snag on the seam (horizontal velocity may stop). The RepositionDirections for the rectangles in the middle of the strip should consider adjacent rectangles in different TileShapeCollections, rather than only rectangles in their own TileShapeCollection. To solve this problem, we can use another TileShapeCollection which contains all rectangles from both the SolidCollision and IceCollision. Keep in mind, a rectangle can exist as multiple TileShapeCollections, so we can take advantage of this to properly adjust RepositionDirections. Once we solve this problem (as shown below), the center rectangles where the two TileShapeCollections meet will no longer have _inward_ reposition directions.

![](../../.gitbook/assets/2021-04-img\_606e81c6cba6b.png)

### Combining TileShapeCollections Example

For this example, consider two TileShapeCollections defined in a GameScreen in Glue: SolidCollision and IceCollision.

![](../../.gitbook/assets/2021-04-img\_606e6cc607d83.png)

We can uncheck the **Adjust Reposition Directions On Add And Remove** option in the Variables tab for both TileShapeCollections.

![](../../.gitbook/assets/2021-04-img\_606e79f5b2bd7.png)

Next we can create a combined TileShapeCollection in Glue.

![](../../.gitbook/assets/2021-04-img\_606e7af403266.png)

We'll mark this new TileShapeCollection as **Empty** so that we can fill it in code.

![](../../.gitbook/assets/2021-04-img\_606e7b17605f1.png)

Finally, we can insert the TileShapeCollections which we'd like to adjust the RepositionDirections of, in context of each other, in code. To do this, we can modify the CustomInitialize of our GameScreen:

```
void CustomInitialize()
{
    CombinedTileShapeCollection.InsertShapes(SolidCollision);
    CombinedTileShapeCollection.InsertShapes(IceCollision);
}
```

It's important to note that the purpose of inserting the collisions into CombinedTileShapeCollection is to adjust the RepositionDirections of each of the contained rectangles. Each individual TileShapeCollection (SolidCollision and IceCollision in this case) are still fully-functional TileShapeCollections, and CollisionRelationships can still be created between entities and these TileShapeCollections.
