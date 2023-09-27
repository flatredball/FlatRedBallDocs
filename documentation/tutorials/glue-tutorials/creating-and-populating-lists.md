## Introduction

If you've been following the tutorials so far, then you've read through the process of adding objects to Screens and Entities. Previous examples have shown how to add a Sprite to an Entity as well as how to add an Entity to a Screen. While this provides a considerable amount of functionality, you will likely encounter situations where you will need to create an unspecified number of objects, or a large number of the same type of object. This is where lists come in handy.

## Benefits of using lists

There's a number of reasons why you might want to use a list.

1.  You want to organize your Objects in Glue. Lists can contain other Objects, and lists can collapse and expand.
2.  You want to create Entity instances in code (for programmers).
3.  You want to perform similar functionality on a group of objects such as collision (for programmers).

## How to create a list

This next example will create a list of Enemies. To do this:

-   Expand your Screens item
-   Expand your GameScreen item
-   Right-click on the Objects item and select "Add Object"
-   Name the new object "Enemies"
-   Change the Source Type to "FlatRedBall Type"![GlueSourceTypeFlatRedBallType.png](/media/migrated_media-GlueSourceTypeFlatRedBallType.png)
-   Change the Source Class Type to "PositionedObjectList\<T\>"![GlueSourceClassTypePOList.png](/media/migrated_media-GlueSourceClassTypePOList.png)
-   Change the Source Class Generic Type to "Entities\Enemy"![GlueSourceClassGenericTypeEntity.png](/media/migrated_media-GlueSourceClassGenericTypeEntity.png)

## The list is created

That's it! You've created a list of Enemies in your Screen. Let's look at exactly what this means:

-   You've added a list to your Screen that programmers can use for custom logic - such as performing collision between them and other lists like player bullets.
-   You've created a list which will have its Activity automatically called by the Screen every frame. Glue automatically called Activity on individual Entity instances, and similarly it handles Activity on the objects in the lists as well.
-   You've created a list which will automatically have all remaining Entities destroyed for you when the Screen is destroyed. This means that your game can create Entities at any point in the game and never have to worry about cleanup - it's done for you.

\>

**For Programmers:** For simplicity we've been referring to the objects created as "lists" in this tutorial. As you may have guessed from the previous steps, we're actually creating a [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList") which will contain Entities. The [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList") has a two-way relationship with any Entity it contains. This means that all contained Entities know about the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList") that they are a part of. When they destroy themselves, they will also automatically remove themselves from the List. This means that in your code all you ever have to do is add the Entity to the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList"). When its Destroy method is called (either manually or automatically when the Screen is destroyed) it will automatically be removed from the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList"). In other words, you never have to explicitly remove an object from the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList").

## Filling the list

At this point you have added a lot of useful functionality to your game regarding activity and destruction. In fact, you could simply end this tutorial right now and you will have already gained a lot of useful information...**but wait! Don't do that!** There's plenty of more useful information to be had.

The next question that you may be asking yourself is "How do I add objects to the list?" There's a few ways to do this. First, let's look at the easiest way, which is through Glue itself.

## Adding objects to a list in Glue

To add objects to a list in Glue:

1.  Expand your GameScreen
2.  Expand your Objects. You should have an object named "Enemies"
3.  Right-click on Enemies and select "Add Object". Until now you have been right-clicking on the Objects item, but you can right-click on an individual Object as long as it is a List and add instances directly to it![AddObjectToAList.png](/media/migrated_media-AddObjectToAList.png)
4.  Name your new Object "Enemy1" and click OK
5.  You should now have an Enemy in your list called Enemy1![EnemyInList.png](/media/migrated_media-EnemyInList.png)

That's it, you now have an Enemy in your list. You can repeat this for as many instances as you want. Keep in mind that you can expose variables on Entities like the Enemey, and then set individual positions for each instance in your list. This means you can populate your Screen with objects in Glue, but still keep them in a list for the convenience of programmers!

## Using External Data

In some cases you may want to populate the world by using a different file. For example, you may not want to add 100 instances of an object through Glue, but would rather define these instances in a different format, like a spreadsheet. Fortunately this is also supported in Glue using the "csv" file format. However, to use external formats, custom code is necessary. Therefore, you will either need to work with programmers on your team to build this functionality, or if you are a programmer yourself, you will need to write code to work with loaded CSVs. In either case, you will want to check [this article](/frb/docs/index.php?title=Glue:Tutorials:Using_CSVs "Glue:Tutorials:Using CSVs") for more information on CSVs and Glue.

[To the next tutorial -\>](/frb/docs/index.php?title=Glue:Tutorials:Using_Animation_Chains "Glue:Tutorials:Using Animation Chains")
