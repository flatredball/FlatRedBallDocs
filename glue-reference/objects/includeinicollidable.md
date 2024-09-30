# IncludeInICollidable

### Introduction

The IncludeInICollidable property controls whether an object is included in the container Entity's Collision ShapeCollection. By default this value is set to true, which means that any shape included in an ICollidable entity will be considered in collision. This can be set to false to exclude a Shape from the Collision ShapeCollection. Typically this value is set to false for shapes which should not be used for standard (solid) collision, such as line of sight collision.

![](../../.gitbook/assets/2022-11-img\_638523b56c5c7.png)

### Example - Excluding a Circle From Collision

For this example, consider an Entity named Enemy which has two shapes:

* An AxisAlignedRectangle named Body
* A Circle named DetectionCollision

![](../../.gitbook/assets/2021-08-img\_612a53bf12bf0.png)

In game, the entity may appear as shown in the following image:

![](../../.gitbook/assets/2021-08-img\_612a569c30411.png)

In this example, the Body is used for collision against walls, the Player, and bullets. The DetectionCollision Circle is used to determine if an Enemy sees the Player. Therefore, we only want the DetectionCollision to be used in a special circumstance - a CollisionRelationship between Enemy and Player lists. Otherwise, the DetectionCollision should be excluded. The DetectionCollision can be excluded from default collision functions by setting the IncludeInICollidable to false.

![](../../.gitbook/assets/2021-08-img\_612a5791b20ff.png)

By default collision relationships will not use the DetectionCollision. For example, the following collision relationship would not collide the enemy against the walls:

![](../../.gitbook/assets/2021-08-img\_612a57dcefc4f.png)

However, the following collision relationship would still detect collisions between the Enemy's DetectionCircle and the Player:

![](../../.gitbook/assets/2021-08-img\_612a5813a78ba.png)

Notice that even though the DetectionCollision has its IncludeInICollidable set to false, collision relationships which explicitly reference this shape will still check collision.
