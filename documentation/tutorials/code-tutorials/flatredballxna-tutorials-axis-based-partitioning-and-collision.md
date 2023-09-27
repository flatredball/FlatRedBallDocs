## Introduction

Axis-based partitioning can be used to greatly improve the performance of collision loops when dealing with large loops. Axis-based partitioning uses "naive" algorithms so it is very easy to write, debug, and understand; however, it is incredibly fast. Arguably the fastest form of spacial partitioning under certain conditions.

## Terminology

If you're new to programming or game development, then you may not be familiar with the term "spacial partitioning". Spacial partitioning is the organization of your data to eliminate unnecessary calculations. For example, consider making a first person shooter. You are considering writing some AI for the enemies in the game. You decide that for the AI to decide who to attack, it must first decide whether it can directly see the player. So, you write a fancy function that finds out whether the enemy can directly see the player by testing to see if any walls or doors are between the player and the character. The level you are working on includes an entire neighborhood that the player must move through, building by building, eliminating the enemies. However, once you run your code you find that the game runs VERY slow! You've tried your hardest to write the function that tests for visibility as efficiently as possible, but due to the number of enemies and the number of walls/doors, you have a very large number of checks. Probably something along the lines of

    numberOfEnemies * (numberOfDoors + numberOfWalls)

This gets really expensive as you start to expand your level and add enemies. If you have 100 walls and 100 doors, adding another enemy means you have 200 extra checks each frame! You can easily see that multiplying these numbers gets big **fast!** As I've mentioned before, the visibility function is written extremely efficient. So, given that you can't cut down on the number of buildings, number of enemies, or improve the speed of the visibility function, what can you do? The solution is to take a step back and consider how you can completely eliminate tests. For example, assuming there are no windows, if the player is inside of a building, then you know that he can't be seen by any enemies inside any other building. In fact, a player can only be seen by enemies if he and the enemy are in the same building, or nearby if the door is open. At this point, you have partitioned (or organized) your data depending on their position (in space). You only perform the visibility checks between the player and the enemies in the same building. Adding another building has virtually no impact on performance regarding visibility. In more general terms, spacial partitioning is the process of identifying objects which cannot possibly collide (or have some other form of relationship like being in sight of one another) at a high level, then organizing your data so that fewer (more expensive) tests are performed every frame.

## Axis Based Partitioning Introduction

The previous example was not the most practical, but gave a good example of what spacial partitioning is all about. One of the big problems with the above example is what do you do if your game is not about shooting enemies in buildings, but rather about racing cars, dodging bullets, moving through a crowd, or selecting objects with the mouse? You may not have buildings to sort your objects by. Axis-based partitioning is a more mathematical (and flexible) way to perform spacial partitioning.

## A practical example

Axis Based Partitioning can be understood in a practical level because we actually use axis based partitioning in real life. Technically we use proximity-based partitioning, but the concept is the same. Consider, for example, that you are driving on a very long road (hundreds of miles) to visit a friend. As you are driving you need to make sure that you don't drive into other cars on the road. In other words, you are doing collision avoidance. Given that the road is hundreds of miles long, it probably has lots of cars driving it at any given time. Could be hundreds, or even thousands depending on how busy the road is. If you had to pay attention to every single car on the road, you wouldn't be able to keep track of them all; however, you generally don't need to keep track of that many. In fact, you are usually only keeping track of a very small number of cars - the ones in front, and perhaps the ones on the side and behind of you. This means that you can be on a road with thousands of other cars, but you only really need to worry about the ones which are closest to you. If a car is far away, you can ignore it because it can't possibly hit your car, at least until it gets much closer. Axis Based Partitioning follows this same thought process. However, instead of doing a distance check (distance checks can be expensive) we typically pick a single Axis (such as the X or Y axis) and sort all objects along that axis. Once a list of objects is sorted, then index of an object in the list also tells you (roughly speaking) how close one object is to another. In other words, if you have a list that is sorted on the X axis, and if the object you are testing collisions on is at index 5, then the closest objects are going to be at index 4 and index 6 - at least on the X axis. The reason this is important is because if you do not collide with the object at index 6 because the X distance between the two objects is too great to possibly have a collision, then you don't have to check index 7,8,9, and so on, because they will all be further away than the object at index 6. Of course, this only performs tests on a single axis, so keep this in mind. You must know how large all objects in a list can be. The reason is the object at index 7 could be further than index 6, yet may still collide with 5 if 7 is really large.

## Conditions for Axis Based Partitioning

At a high level, axis-based partitioning is only useful under the following situations:

-   Objects do not disappear and reappear randomly. This is almost never the case - if an object is in a position one frame, it will likely be at or near the same position next frame.
-   Objects are of known maximum size.
-   Objects are uniformly, randomly, or close to randomly distributed in terms of position. The bounds do not need to be defined - this method is infinitely scalable.
-   The axis that the objects are mostly distributed on is known.

If these are true, the the following can be performed:

-   Sort the objects on the most distributed axis using a naive sorting algorithm like insertion sort.
-   Begin at index 0 and check "ahead" until the distance between the objects on the sorted axis is too great.
-   Increment the index and move forward.
-   Repeat until reaching the end of the list.

## Example

The following example creates 400 Sprites and has the perform collision against each other. If they collide, the Sprites glow, otherwise they are drawn regularly. Pastebin link: [http://pastebin.ca/985502](http://pastebin.ca/985502) File link: [AxisBasedPartitioning.cs](/frb/docs/images/f/f0/AxisBasedPartitioning.cs "AxisBasedPartitioning.cs") ![AxisBasedPartitioning.png](/media/migrated_media-AxisBasedPartitioning.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
