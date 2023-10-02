# measuring-automatic-updates

### Introduction

Automatic updates can take a significant amount of time every frame if your game includes a large number of automatically updated objects. The first step in improving the performance of your game is measure the number of objects your game contains. This article will discuss how to do this.

### Requirements

This article assumes that you already have a working project in FlatRedBall - preferably one with a variety of automatically updated objects (Sprites, Shapes, Entities, Text objects, etc).

### FlatRedBall Debugger

The FlatRedBall Engine includes a class called [Debugger](../../../../../frb/docs/index.php) which can help you debug and diagnose problems in your project. In this case we'll be using a function called WriteAutomaticallyUpdatedObjectInformation. This method will print the number of managed objects to the screen in real time. It's a very simple method to use which provides a lot of useful information. To use it:

1. Open your project in Visual Studio
2. Navigate to your Game class (which is by default called Game1 in Game1.cs)
3. Navigate to the Update method
4.  Add the following code \*after\* FlatRedBallServices.Update:

    ```
    FlatRedBall.Debugging.Debugger.WriteAutomaticallyUpdatedObjectInformation();
    ```
5. Run your game

Now you should see information about the objects that are present in your game. The top-left of your screen may look similar to: ![WriteAutomaticallyUpdatedObjectInformation.png](../../../../../media/migrated\_media-WriteAutomaticallyUpdatedObjectInformation.png)

### What does this information mean?

The information printed out gives you an idea of what the engine is spending its time updating. In the picture above you can see that the game has a total of 50 automatically updated objects. The lines show the breakdown - the majority of the objects are Sprites, then PositionedObjects (which are usually Entities if using Glue) make up the second largest category.

### How many is a lot?

This question can be difficult to answer. The short answer is "it depends". Here are some considerations to keep in mind when working on a game:

1. Numbers greater than 1000 are usually bad.
2. Games with fewer than 100 are unlikely to have performance problems from managed objects.
3. Platforms without as much processing power (such as mobile platforms) can have performance problems with as few as 500 managed objects.
4. Fewer objects is always better on mobile platforms even if no performance problems are visible. Fewer objects means less processing needed per-frame, which means your game won't run down batteries as quickly.

### How can I improve each category?

For the most part the cost of each type of object is equal. In other words, managing one Text takes just as much time as managing one Sprite. Therefore, when looking to improve the performance of your game, you likely want to tackle the largest number first.

#### PositionedObjects

If you are using Glue then it's likely that a large number of your automatically updated PositionedObjects are Entities. For more information on making these manually updated, see the [ConvertToManuallyUpdated page](../../../../../frb/docs/index.php).

#### Sprites

For information on how to improve the performance of your game if it has a large number of Sprites, see [this page](../../../../../frb/docs/index.php).

#### SpriteFrames

#### Cameras

#### Shapes

#### Texts
