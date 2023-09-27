## Introduction

The PositionedObjectList is an object which can store lists of [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). It is the base class of the [SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList.md "FlatRedBall.SpriteList") class and is commonly used to store lists of [Entities](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Creating_a_Game_Entity.md "FlatRedBallXna:Tutorials:Creating a Game Entity") and shapes such as [Polygons](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon"). The PositionedObjectList inherits from the [AttachableList](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList.md "FlatRedBall.Math.AttachableList") and it establishes [two-way relationships](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList.md#Two_Way_Relationships "FlatRedBall.Math.AttachableList") with objects that are added to it.

## Common Usage

Most FlatRedBall games use the PositionedObjectList. The PositionedObjectList is common both in custom code as well as in Glue generated code.

### What types are stored in PositionedObjectLists

The PositionedObjectList is a dynamic list which is made to specifically store [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") and any classes which inherit from [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). The most common types stored in PositionedObjectLists are:

-   [FlatRedBall.Math.Geometry.Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle")
-   [FlatRedBall.Math.Geometry.Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.md "FlatRedBall.Math.Geometry.Polygon")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle.md "FlatRedBall.Math.Geometry.AxisAlignedRectangle")
-   [Entities](/frb/docs/index.php?title=Category:FlatRedBall_XNA_Tutorials#Entity_Tutorials.md "Category:FlatRedBall XNA Tutorials") - Any entity created in Glue can be stored in a PositionedObjectList. Lists added to Screens or other Entities inside Glue are PositionedObjects.

Sprites are usually stored in the [FlatRedBall.SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList.md "FlatRedBall.SpriteList") class; however since PositionedObjectList is the base class for [SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList.md "FlatRedBall.SpriteList") all of the information presented here applies to [SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList.md "FlatRedBall.SpriteList") as well.

### Instantiating a PositionedObjectList

The PositionedObjectList class is a generic class. So, to instantiate one, you need to use the type that the PositionedObjectList will contain:

    // Add the following using statement
    using FlatRedBall.Math;

    // Here's how to make a list of Circles:
    PositionedObjectList<Circle> circles = new PositionedObjectList<Circle>();

    // And here's how to make one for Enemies (assuming you have an Enemy Entity):
    PositionedObjectList<Enemy> enemies = new PositionedObjectList<Enemy>();

### PositionedObjectLists in Custom Code

If a PositionedObjectList which holds entities is added to a Screen, then it will usually need to call Activity on the contained entities. For example, the following code shows how a PositionedObjectList of type Bullet (assuming Bullet is an Entity) can be added to a Screen.

``` lang:c#
// The using statement for PositionedObjectList:
using FlatRedBall.Math;

public partial class GameScreen
{
    // Declare the list at class scope
    PositionedObjectList<Entities.Bullet> bullets;

    void CustomInitialize()
    {
        // Instantiate the list in CustomInitialize
        bullets = new PositionedObjectList<Entities.Bullet>();
    }

    void CustomActivity(bool firstTimeCalled)
    {
        // Normally entities automatically have their
        // activity called by Glue kn generated code, but
        // we have to do it here in custom code if we are going
        // to instantiate the list in custom code
        foreach(var bullet in bullets)
        {
            bullet.Activity();
        }
    }

    void CustomDestroy()
    {
        // Similar to activity, entities in lists are
        // normally destroyed automatically in generated
        // code, but we have to do it manually since we created
        // the list in custom code:
        for(int i = bullets.Count; i > -1; i--)
        {
            bullets[i].Destroy();
        }
    }
}
```

 

### Combined with FlatRedBall Patterns

The PositionedObjectList class is an essential part of the standard FlatRedBall Screen. For the rest of this discussion we'll assume that you are using [Screens](/frb/docs/index.php?title=Screen.md "Screen") and [Entities](/frb/docs/index.php?title=Category:FlatRedBall_XNA_Tutorials#Entity_Tutorials.md "Category:FlatRedBall XNA Tutorials").

### PositionedObjectLists represent categories

Usually you will want to create one PositionedObjectList per category of object. What defines a category? A category of objects is anything which shares the same behavior. For example:

-   **Enemy Bullets** - All bullets in a space ship game probably need to test for collision against the player.
-   **Moving Platforms** - Platforms may need special logic performed on them so they move along a predetermined path.
-   **Destroyable objects** - Objects which can be destroyed by the player such as chairs and tables may need to have every-frame collision performed against any player attacks.
-   **Particles with special behavior** - Particles that have behavior not handled by the [Emitter](/frb/docs/index.php?title=FlatRedBall.Graphics.Particle.Emitter.md "FlatRedBall.Graphics.Particle.Emitter") may need to be stored in a PositionedObjectList for their custom behavior. For example, you may need to perform collision between rain particles and the ground, and destroy the rain particle upon collision.

### PositionedObjectList life

In most cases PositionedObjectLists should be defined at class (usually [Screen](/frb/docs/index.php?title=Screen.md "Screen") scope. The reason for this is mainly because the categories that the PositionedObjectList represents will usually live the entire life of the [Screen](/frb/docs/index.php?title=Screen.md "Screen"). The objects within the PositionedObjectList may have a short life (bullets may only have a few seconds); however, the list itself should only be created in the [Screen's](/frb/docs/index.php?title=Screen.md "Screen") Initialize method. All PositionedObjectLists should be emptied when their containing [Screen](/frb/docs/index.php?title=Screen.md "Screen") is destroyed. See the next section for information about how to properly remove items from PositionedObjectLists.

### Removing items from lists

This section might seem silly. You might be thinking, "I just call Remove, right?". Actually, the Remove method in the PositionedObjectList class is almost never called explicitly. Keep in mind that the PositionedObjectList is a [AttachableList](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList.md "FlatRedBall.Math.AttachableList") so that means that it shares a [two-way relationship](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList.md#Two_Way_Relationships "FlatRedBall.Math.AttachableList") with all of its contained elements. That means that simply removing a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") from its [manager](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md#FlatRedBall_PositionedObject-Inheriting_Classes_and_Associated_Managers "FlatRedBall.PositionedObject") will remove the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") from any list that it belongs to. Let's look at how this works in practice. In our first example we have a PositionedObjectList of [Circles](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.md "FlatRedBall.Math.Geometry.Circle") which represent enemy bullets. If the bullet collides with the player [Entity](/frb/docs/index.php?title=Entity.md "Entity"), then the bullet should be destroyed. That means it should be removed from the engine as well as from any PositionedObjectLists that contain it.

    // do a reverse loop ... see below for an explanation of why
    for(int i = mBullets.Count - 1; i > -1; i--)
    {
       Bullet bullet = mBullets[i];

       if(bullet.CollideAgainst(mPlayer.Collision))
       {
           ShapeManager.Remove(bullet);

           // There's probably something that has to happen when the player is hit:
           mPlayer.ReactToBeingHit();
       }
    }

Notice that we never remove the bullet from mBullets. That's okay, **this happens automatically when it is removed from its manager.** Let's look at one more example - one using [Entities](/frb/docs/index.php?title=Entity.md "Entity"). The common pattern for [Entities](/frb/docs/index.php?title=Entity.md "Entity") is to include a Destroy method which can be called when the [Entity](/frb/docs/index.php?title=Entity.md "Entity") is not needed anymore. The Destroy method is responsible for removing the [Entity](/frb/docs/index.php?title=Entity.md "Entity") and any objects that it contains from their respective managers. Let's say that you have a game like Contra where enemies should be removed when they are out of the screen. For the sake of simplicity we'll assume that the Enemy class has a IsInScreen method:

    // again, a reverse for loop
    for(int i = mEnemies.Count - 1; i > -1; i--)
    {
       Enemy enemy = mEnemies[i];

       if(enemy.IsOutsideOfScreen())
       {
           // Destroy should remove the enemy from its managers, which results in
           // it being removed from any PositionedObjectList that it belongs to.
           enemy.Destroy();
       }
    }

### Clearing PositionedObjectLists

All PositionedObjectLists should be cleared when their containing Screen is destroyed. The following code can be used to clear a list of Enemies.

    while(mEnemies.Count != 0)
    {
       // This should remove the Enemy from its managers, again removing it from any
       // PositionedObjectList that it belongs to.
       mEnemies.Last.Destroy();
    }

For a more detailed discussion of the Clear function and why it may not be a good idea to use it, see the [Clear wiki page](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.Clear.md "FlatRedBall.Math.PositionedObjectList.Clear").

## Reverse For Loops

One of the most common statements in programming is the incrementing for loop:

    for ( int i = 0; i < numberOfIterations; i++ )

This is a very common way to have a particular action performed numberOfIterations times. It's also used to traverse lists and perform actions on these lists. For example, if a game has a PositionedObjectList with Enemies, then each enemy should have its Activity method called. The following code would call Activity on each Enemy:

    for ( int i = 0; i < mEnemies.Count; i++)
    {
        mEnemies[i].Activity();
    }

However, there is a subtle problem here. If the Activity method can result in the destruction of an Enemy (say by checking its health or some other condition), then mEnemies may be modified. Remember, since mEnemies is a PositionedObjectList, if an Enemy destroys itself, it will likely call the [SpriteManager's](/frb/docs/index.php?title=FlatRedBall.SpriteManager.md "FlatRedBall.SpriteManager") [RemovePositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md#Managing_PositionedObjects "FlatRedBall.PositionedObject") method. This will remove itself from all PositionedObjectLists that it belongs to, including mEnemies. Now, consider what happens when this occurs. Let's say that i = 1, and mEnemies\[1\] is ready to be destroyed. When this occurs, the Enemy at index \[2\] "slides over" to index \[1\]. However, after the Activity is called, I increments to 2, which is the "new position" of the Enemy that was at index \[3\]. In other words, the removal of the enemy at index \[1\] caused the next Enemy to have its Activity method skipped over. Depending on your game this may be a very benign side-effect. That is, next frame the enemy that was moved to index \[1\] may get its Activity method called and all will be well; however, it may be the case that your Activity method needs to be called every frame. Or it may be the case that later on in development you add some logic to the Enemy class's Activity method that causes problems if not called every frame. In short, removal inside a forward for loop can cause inconsistent behavior, and this can potentially cause bugs - specifically bugs which can be very difficult to track down. Fortunately, this can be remedied by a reverse for loop. The above code could be modified to be the following:

    for ( int i = mEnemies.Count -1; i > -1; i--)
    {
        mEnemies[i].Activity();
    }

This guarantees that all Enemies will have their Activity methods called, even in the case of a removal. As in the example above, if the enemy at index \[1\] gets removed, then all Enemies with index greater than 1 will be "shifted" by one. However, that's ok, because all enemies with index greater than 1 have already been tested in the loop. The next index to be tested is index \[0\], and the Enemy at index \[0\] is the same Enemy both before and after the removal of the enemy at index \[1\].

## PositionedObjectList Members

-   [FlatRedBall.Math.PositionedObjectList.Add](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.Add.md "FlatRedBall.Math.PositionedObjectList.Add")
-   [FlatRedBall.Math.PositionedObjectList.AttachTo](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.AttachTo.md "FlatRedBall.Math.PositionedObjectList.AttachTo")
-   [FlatRedBall.Math.PositionedObjectList.Clear](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.Clear.md "FlatRedBall.Math.PositionedObjectList.Clear")
-   [FlatRedBall.Math.PositionedObjectList.GetFirstAfter](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.GetFirstAfter.md "FlatRedBall.Math.PositionedObjectList.GetFirstAfter")
-   [FlatRedBall.Math.PositionedObjectList.GetFirstAfterPosition](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.GetFirstAfter.mdPosition "FlatRedBall.Math.PositionedObjectList.GetFirstAfterPosition") (Obsolete)
-   [FlatRedBall.Math.PositionedObjectList.SortXInsertionAscending](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.SortXInsertionAscending.md "FlatRedBall.Math.PositionedObjectList.SortXInsertionAscending")
-   [FlatRedBall.Math.PositionedObjectList.SortXInsertionDescending](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.SortXInsertionDescending&action=edit&redlink=1.md "FlatRedBall.Math.PositionedObjectList.SortXInsertionDescending (page does not exist)")
-   [FlatRedBall.Math.PositionedObjectList.SortYInsertionAscending](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.SortXInsertionAscending.md "FlatRedBall.Math.PositionedObjectList.SortXInsertionAscending")
-   [FlatRedBall.Math.PositionedObjectList.SortYInsertionDescending](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.SortYInsertionDescending&action=edit&redlink=1.md "FlatRedBall.Math.PositionedObjectList.SortYInsertionDescending (page does not exist)")
-   [FlatRedBall.Math.PositionedObjectList.SortZInsertionAscending](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.SortXInsertionAscending.md "FlatRedBall.Math.PositionedObjectList.SortXInsertionAscending")
-   [FlatRedBall.Math.PositionedObjectList.SortZInsertionDescending](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.SortZInsertionDescending&action=edit&redlink=1.md "FlatRedBall.Math.PositionedObjectList.SortZInsertionDescending (page does not exist)")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
