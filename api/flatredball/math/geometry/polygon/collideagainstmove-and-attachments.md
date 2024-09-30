# CollideAgainstMove and Attachments

### Introduction

Due to the popularity of the [Entity pattern](../../../../../frb/docs/index.php), it is very common to have shapes attached to other [PositionedObjects](../../../../../frb/docs/index.php). Because of this common setup, all shapes have special behavior in their collision methods to reposition or change the velocity of their [TopParent](../../../../../frb/docs/index.php).

### The Attachment Hierarchy

The attachment hierarchy is a collection of [IAttachables](../../../../../frb/docs/index.php) and their attachments - or child/parent relationships - which define which objects control the position and rotation of other objects. The following shows a typical attachment hierarchy for an [Entity](../../../../../frb/docs/index.php).

![AttachmentHierarchy.png](../../../../../.gitbook/assets/migrated\_media-AttachmentHierarchy.png)

In this hierarchy the entity itself is considered the "root" or [TopParent](../../../../../frb/docs/index.php). This means that by default absolute changes to position and rotation will affect ONLY the root object. In other words, if the VisibleRepresentation's X is changed in code, the change will not be drawn or persist next frame. To change the VisibleRepresentation's absolute position or rotation, code must either change the root's absolute values, or the relative values of the VisibleRepresentation.

This characteristic is not unique to [Sprites](../../../../../frb/docs/index.php) - it applies to all [IAttachables](../../../../../frb/docs/index.php) including all shapes.

### Shapes and the Attachment Hierarchy

Methods like CollideAgainstMove and CollideAgainstBounce are commonly used to prevent overlapping and modify velocity in response to collisions. CollideAgainstMove modifies the absolute Position of the calling shape and the shape it is colliding with to prevent overlapping. CollideAgainstBounce prevents overlapping just like CollideAgainstMove, but also modifies the velocity of the two shapes involved.

This may seem to present a problem; shapes have their absolute properties modified through the CollideAgainstMove and CollideAgainstBounce methods; however, as shown in the entity pattern above, shapes are often not at the root of the attachment hierarchy. Therefore it would seem as if these methods will only work when the shapes involved are the roots of their respective attachment hierarchies.

Fortunately, this is not the case. Since shapes are often children of other [IAttachables](../../../../../frb/docs/index.php), any modification to position or velocity gets "pushed up" to the root of the attachment hierarchy.

![CollisionMethodModifications.png](../../../../../.gitbook/assets/migrated\_media-CollisionMethodModifications.png)

### Shared Root Conflicts

As mentioned above, the CollideAgainstMove and CollideAgainstBounce methods will update the root's absolute properties. However, if two shapes share the same root, the collision methods will not be able to reposition the objects properly. The following image shows the conflict:

![CollideAgainstMoveConflict.png](../../../../../.gitbook/assets/migrated\_media-CollideAgainstMoveConflict.png)

Notice that in this situation both children will be modifying the parents' property. However, the parent's absolute values control the absolute values of the attached shapes.

In these situations the regular CollideAgainst methods will work correctly, but the Move and Bounce versions of the method will not be able to properly modify values. Keep this in mind if you are using a shared root for multiple shapes.
