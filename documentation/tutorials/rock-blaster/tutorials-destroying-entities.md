# tutorials-destroying-entities

### Introduction

As mentioned in the conclusion of the previous tutorial the game currently has a severe accumulation bug (which some may refer to as a memory leak, although it's not quite the same thing). This bug occurs because the game is continually creating new Entity instances, but is not destroying them. Rather than simply correcting the problem, let's see how to diagnose this problem.

### Entities, PositionedObjects, and the SpriteManager

FlatRedBall includes a number of Managers which apply automatic every-frame behavior to the objects that they manage. In the case of our game, managers enable behavior such as the application of velocity, attachments, and rotational velocity. Most FlatRedBall types which have every-frame behavior have an associated manager. Entities (such as Player) are custom classes that are created by Glue and custom code; therefore, the Engine doesn't deal directly with the types that are defined in our game. The base type for all Entities, however, is PositionedObject - a class which is understood by FlatRedBall and is managed by the SpriteManager. If you are interested you can verify this by looking in any Entity's Generated.cs file and searching for this code:

```
SpriteManager.AddPositionedObject(this);
```

When a PositionedObject is added to the SpriteManager, it is added to the ManagedPositionedObjects enumerable. We can use this to keep track of how many Entities are living, and check for accumulation bugs.

### Using the FlatRedBall Debugger

The easiest way to identify if there is an accumulation bug is to write out the number of Entities in the ManagedPositionedObjects enumerable. To do this, add the following to Update in Game1.cs after the call to FlatRedBallServices.Update:

```
// Top-left is already occupied by the score
FlatRedBall.Debugging.Debugger.TextCorner = FlatRedBall.Debugging.Debugger.Corner.BottomLeft;
FlatRedBall.Debugging.Debugger.Write(SpriteManager.ManagedPositionedObjects.Count);
```

![NumberOfEntities.png](../../../media/migrated\_media-NumberOfEntities.png) Of course a large number of Entities does not necessarily mean that there is an accumulation bug; however, games should have reach a point where the number of Entities on screen level-out. However, as long as you continue to play Rock Blaster the number of Entities that are living gradually increases, indicating this really is an accumulation bug. So we now have verified that there is a problem and we have a way to measure it, but how do we know specifically which entities are causing problems? The next section will explain.

### Using the debugger to identify Entity type

Although it may seem rather obvious where our accumulation is occurring, we will nonetheless walk through the process of identifying what types of Entities are accumulating. The current state of our game makes it very easy to spot this problem because the GameScreen does not exit when the player loses. Therefore, we can simply look at the state of the engine once enough objects have accumulated and the player has died. To track down the types of Entities which are accumulating:

1. Begin playing the game
2. Survive for as long as you can. If you have trouble surviving, you can give the Player a higher StartingHealth such as 60. "Cheats" like this are common in game development.
3. Survive long enough to have a large number of accumulated Entities (such as 300 - maybe less if your computer can't handle that many)
4. Once you have died, or once you have reached this many Entities, keep the game running and switch focus to Visual Studio.
5. Place a breakpoint in any function that is called regularly, such as Update in Game1.cs or CustomActivity in GameScreen.cs
6. The breakpoint should be hit immediately
7. Add the following to the watch window in Visual Studio:

&#x20;

```
FlatRedBall.SpriteManager.ManagedPositionedObjects
```

Expand this to see all contained PositionedObjects: ![WatchWindow.png](../../../media/migrated\_media-WatchWindow.png) The order of objects in the ManagedPositionedObjects enumerable is the order that the objects were created - therefore the oldest objects will appear first in the list. This is convenient for us because (excluding objects which live as long as the Player itself) the oldest objects are the most likely to be leaked objects. If we search the list for Bullet instances we can get a sense of the problem. Bullets should be temporary objects. Furthermore it's clear that the object should not still be alive at a position which is out of the bounds of the screen:

```
X:-19391.06 Y:-26414.04
```

This means that some bullets are between 20,000 and 30,000 pixels away from the center of the Screen. Not only does this tell us that we have a problem with accumulation, but it also provides a hint of how to solve the problem - we can simply destroy any bullet which is farther away from the center of the Screen than some value. Keep in mind that this method of identifying accumulation bugs depends on context. If you are clearing out your Entities effectively, then you may have Bullets very early in ManagedPositionedObjects. Of course, if that were the case then we would have never noticed an accumulation in the ManagedPositionedObjects Count in the first place.

### Clearing Bullets

Let's fix part of the accumulation bug by destroying Bullets when they have moved far enough away from center of the screen. We'll do this simply by getting the absolute value of the X or Y of the bullet. If it's greater than some number (which needs to be big enough to guarantee it's off screen) then we will destroy the bullet. To do this, open GameScreen.cs and add the following code to CustomActivity.cs:

```
RemovalActivity();
```

Next implement the RemovalActivity as follows:

```
 void RemovalActivity()
{
    // reverse loop since we're going to Destroy
    for (int i = BulletList.Count - 1; i > -1; i--)
    {
        float absoluteX = Math.Abs(BulletList[i].X);
        float absoluteY = Math.Abs(BulletList[i].Y);

        const float removeBeyond = 600;
        if (absoluteX > removeBeyond || absoluteY > removeBeyond)
        {
            BulletList[i].Destroy();
        }
    }
}
```

Now with this code implemented you can run the game and observe the ManagedPositionedObjects count at the bottom left of the Screen. It should climb much slower than before.

### Rock Accumulation

The fix we made above has greatly reduced accumulation, thus improving performance; however the bug isn't completely solved. You'll see that the number of objects continues to climb. Of course, you have to be careful when performing tests like this. RockBlaster is designed to increase the spawn rate of rocks. This means that it's likely that as the game progresses more and more rocks will be visible on screen at once, so we expect to see an increase in the number of Entities as the game progresses. Therefore, you can't always assume that an increasing number of living Entities is a bug. However, in this case, it is - we are creating Rocks and never destroying them (unless they are being shot). We can verify this by looking at the position values of the Rocks in the Watch window (just like we did for Bullets earlier): ![RocksInDebugger.PNG](../../../media/migrated\_media-RocksInDebugger.PNG) In my case some of the rocks are so far away from the game screen that they should obviously be removed:

```
X:1740.5 Y:-11258.83
```

We can correct this by changing the RemovalActivity method to also check for rocks. Add the following after the for-loop shown earlier:

```
for (int i = RockList.Count - 1; i > -1; i--)
{
    float absoluteX = Math.Abs(RockList[i].X);
    float absoluteY = Math.Abs(RockList[i].Y);

    const float removeBeyond = 600;
    if (absoluteX > removeBeyond || absoluteY > removeBeyond)
    {
        RockList[i].Destroy();
    }
}
```

You should notice that the performance of the game will no longer drop significantly when playing for extended periods of time. Furthermore the number of live Entities doesn't climb much above 100. As mentioned earlier, some increase will occur, but this is due to there being more Rocks on screen at the same time.

### Conclusion

![LotsOfPoints.png](../../../media/migrated\_media-LotsOfPoints.png) Now that we've fixed our accumulation bug the game is far more playable and will no longer slow down when playing for a long period of time. At this point our game is nearly complete - at least in the scope of this tutorial. The next (and last) tutorial will add some polish to our game and clean up debug code and objects. [<- 12. Health Part 2](tutorials-health-part-2.md) -- [14. Cleaning Up ->](tutorials-cleaning-up.md)
