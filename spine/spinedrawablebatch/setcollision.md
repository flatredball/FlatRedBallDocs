# SetCollision

### Introduction

The SetCollision function can be used to assign/update collision on an ICollidable through its ShapeCollection. In other words, this method allows the creation of collision through the Spine tool which can be used to create CollisionRelationships, or to perform manual collision checks.

### Defining Collision in Spine

Spine has support for bounding boxes - which conceptually correspond to FlatRedBall Polygons.

<figure><img src="../../.gitbook/assets/image (35).png" alt=""><figcaption><p>Polygons in Spine</p></figcaption></figure>

These _bounding boxes_ can be converted to FlatRedBall Polygons which can be used in your project. These polygons are fully-featured, just like&#x20;
