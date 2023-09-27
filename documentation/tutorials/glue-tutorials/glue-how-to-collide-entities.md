## Introduction

Making Entities collide with each other is a very common thing to do. For example, you may be working on a game where the player can shoot bullets which should collide with enemies, or you may have a game where the player can collide against enemies. This section will talk about the many ways to perform collision between Entities, starting with the simplest scenario, then moving to situations where more flexibility is needed.

## What is a custom response?

Whenever you are working with a collision system, there are two questions that are involved:

1.  Did a collision occur?
2.  If so, what should the game do in response?

For example, let's consider a game like Asteroids (or Rock Blaster). If we're looking specifically at the player and the asteroids, we must first check if the ship collided with any asteroids. If so we need to have a response, which might mean blowing up the player, reducing the number of lives that a player has, and beginning the sequence of re-spawning the player. Some games, like Asteroids, require a custom collision response. Common responses include destroying objects, playing sound effects, and changing game states. Some collisions do not require custom responses. For example, a player which is navigating through a maze does not need to do anything special when colliding with the walls - the collision (assuming CollideAgainstMove or CollideAgainstBounce is being used) will handle the overlap between the player and the wall.

## Simplest example - no custom response

In this example we'll show how to create simple collision between two entities. We'll use CollideAgainstMove, which prevents the instances from overlapping. First let's create an Entity:

1.  Create an Entity called CollidableEntity
2.  Select the newly-created Entity and set its "ImplementsICollidable" value to true:![ImplementsICollidable.png](/media/migrated_media-ImplementsICollidable.png)
3.  Right-click on CollidableEntity's Objects
4.  Select "Add Object"
5.  Select "FlatRedBall or Custom Type"
6.  Select Circle in the list below
7.  Click OK

Next let's create a Screen that contains two instances of CollidableEntity:

1.  Create a Screen called MyScreen
2.  Right click on MyScreen's Objects
3.  Select "Add Object"
4.  Select "Entity"
5.  Select "CollidableEntity"
6.  Click OK
7.  Repeat the steps above to create a second CollidableEntity.

Now that you have two instances, which will by default be called CollidableEntity and CollidableEntity2, you can write collision code. They will have CollideAgainst, CollideAgainstMove, and CollideAgainstBounce functions available. For example, you can use CollideAgainstMove to separate the two objects as follows:

    CollidableEntityInstance.CollideAgainstMove(CollidableEntityInstance2, 1, 1);
