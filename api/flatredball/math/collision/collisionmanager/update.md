# Update

### Introduction

The Update method performs the every-frame collision checks for all CollisionRelationships contained in the CollisionManager. This includes:

* Sorting any partitioned lists
* Assigning contained ICollidable LastFrameItemsCollidedAgainst and LastFrameObjectsCollidedAgainst
* Resetting contained ICollidable ItemsCollidedAgainst and ObjectsCollidedAgainst
* Invoking the BeforeCollision method
* Performing collision on all contained CollisionRelationships

Note that most games do not need to call this method manually - it is called automatically by FlatRedBall
