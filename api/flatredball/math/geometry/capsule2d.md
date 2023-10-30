# capsule2d

### Introduction

A Capsule2D is a [PositionedObject](../../../../../frb/docs/index.php) which can be used to perform collision tests. Since Capsule2Ds provide the same collision interface as other shapes, it is also considered a "shape". A Capsule2D is a shape that can be any length, but has rounded edges and a straight segment connecting the two points. ![CapsulePic.png](../../../../../media/migrated_media-CapsulePic.png)

### When are Capsules used?

Capsules are often used to determine if a collision has occurred between a moving [Circle](../../../../../frb/docs/index.php) and another object. Since capsules use rounded edges, they can represent the area that a Circle occupies during and between two subsequent frames.

### Capsule Size

Capsule size is controlled by two variables:

* Scale
* EndpointRadius

The following diagram shows hwo these values are used in a Capsule2D: ![Capsule2DVariables.png](../../../../../media/migrated_media-Capsule2DVariables.png)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
