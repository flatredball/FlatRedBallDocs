## Introduction

The Destroy method is used to completely destroy an entity. Generated code calls Destroy for any entity and any list of entities in your current Screen whenever the Screen is destroyed (when the game moves to a different screen). Destroy may need to be manually called if an entity is created manually in game code.

## What does Destroy do?

When an Entity's Destroy method is called, the following happens:

-   Generated code will destroy any contained object which has been added through FlatRedBall Editor. For example, if your Entity has a Sprite and a Circle, both will automatically be removed from the engine, resulting in the Entity no longer being visible on screen.
-   The entity will be removed from any list that it is a part of. For example, if your GameScreen contains a BulletList, calling Destroy on the Bullet will remove the Bullet instance from the BulletList.
-   The entity will be removed from the engine (SpriteManager) management, so its automatic properties such as Velocity and Acceleration will no longer be applied
-   If the entity is an IWindow-implementing Entity, the entity will be removed from the GuiManager so it no longer receives clicks or other UI interaction
-   If the entity is a collidable entity, its collision will be cleared so future collision calls will return false
-   The entity's CustomDestroy is called, enabling custom code to perform additional object removal.

Note that when writing code in CustomDestroy, the entity **should not unload content**. The content manager used to load content for the Entity should be provided by the [Screen](/frb/docs/index.php?title=Screen.md "Screen") that contains the Entity. [Screens](/frb/docs/index.php?title=Screen.md "Screen") automatically unload their content managers, and this will clean up content loaded by the Entity.

## When is Destroy called?

As mentioned above, Destroy is automatically called by generated code in the following situations:

-   Whenever a screen is destroyed, all of the entities added to the screen through the FlatRedBall Editor will also have Destroy called
-   Whenever a screen is destroyed, all of the entity lists added to the screen through the FlatRedBall Editor will also have their Destroy called
-   Whenever an entity is destroyed, any entities that it contains will also be destroyed.

Custom code may need to call Destroy. Usually custom code only needs to destroy entities that it creates on its own. The most common case is when entities should be destroyed as a result of collision, such as when a bullet hits a wall.

## Example - Destroying in a Collision Event

The most common situation where Destroy is called is in collision handling events. For example, consider a game where the player can shoot bullets, and bullets can hit walls (typically represented by a SolidCollision TileShapeCollection). The collision relationship may be defined as shown in the following image. Notice that the collision relationship has an event:

![](/media/2021-11-img_61814c88b1382.png)

The collision relationship event handler might look like as shown in the following code snippet:

    void OnBulletListVsSolidCollisionCollisionOccurred(
        Entities.Bullet bullet,
        FlatRedBall.TileCollisions.TileShapeCollection tileShapeCollection)
    {
        bullet.Destroy();
    }

## Entities and presence in your game

If you create a game with Entities, then you will be instantiating and storing these Entities somewhere in your game. For example, you may have a Character and Enemy entity defined as follows:

    Character mCharacter;
    PositionedObjectList<Enemy> mEnemies;

In which case you might instantiate them as follows:

    mCharacter = new Character(ContentManagerName);
    mEnemies = new PositionedObjectList<Enemy>();

    // Somewhere in code you'll be adding new enemies:
    mEnemies.Add(new Enemy(ContentManagerName));

The fist thing to note is that the code above uses the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") class. This is **very important**. Let's investigate why. The idea behind using Entities is that you should be able able to destroy your Entity completely with one call - a call to Destroy. This means that the Entity should remove itself from the FlatRedBall Engine **as well as** from your game. Well, the only way that the Entity can remove itself from your game is if it knows which objects to remove itself from in your game. This means that you **must use a class that supports two-way membership**. The [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") (or any class inheriting from it) supports two-way relationships. If you use the PositionedObjectList class, then any time you call Destroy on an Enemy, it will be automatically removed from your list - assuming of course that your Enemy's Destroy method calls

    SpriteManager.RemovePositionedObject(this);

**For Glue users:** As mentioned above, an Entity's generated code will automatically remove the Entity from the [SpriteManager](/frb/docs/index.php?title=SpriteManager.md "SpriteManager"). All you have to do is create a [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") in your game to store the Entities. Glue also supports creating PositionedObjectLists so use that type in Glue if you plan on creating lists of Entities.

## Destroy and membership in your game

The two-way relationship between Entities (and all other [PositionedObjects](/frb/docs/index.php?title=PositionedObject.md "PositionedObject")) and the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") class is what enables the Destroy method to remove an Entity from the engine. In fact, the [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList") (and any class which inherits from [PositionedObjectList](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList.md "FlatRedBall.Math.PositionedObjectList")) is the **only** reference that Entities know about. If you store a reference to an individual Entity, the reference will still be valid after you call Destroy unless your code handles this case. Let's look at some simple examples. In our first example we'll create some code where the user is keeping track of an individual player and enemy: At class scope:

    Player mPlayer = new Player();
    Entity mEnemy= new Enemy();

This piece of code checks for the player attacking the enemy:

    if(mPlayer.AttachCollision.CollideAgainst(mEnemy.Collision)
    {
        const float attackDamage = 10;
        mEnemy.Health -= attackDamage;

        if(mEnemy.Health <= 0)
        {
            mEnemy.Destroy();
        }
    }

This piece of code checks for the player touching and being hurt by the enemy:

    if(mPlayer.Collision.CollideAgainst(mEnemy.Collision)
    {
        const float attackDamage = 5;
        mPlayer.Health -= attackDamage;

        if(mPlayer.Health <= 0)
        {
            // Assuming EndTheGame is a method that you have written to handle the end of the game:
            EndTheGame();
        }
    }

The code above has a logic bug which will cause the game to behave improperly. When the Enemy is destroyed (through mEnemy.Destroy();) then all of its components will be removed from the engine. Its visible representation and collision will be removed from the appropriate managers. It will also be removed from the SpriteManager so that it is no longer managed by the Engine. However **the collision check between mPlayer and mEnemy is still being done!** If you think about it a bit, this makes sense. This is because your code doesn't check if mEnemy is dead. It does the check no matter what. However, since mEnemy is destroyed, it is no longer part of the engine. The result is that mEnemy will seem to completely disappear, but its Collision object will still be sitting there, invisible, in the level. Even though it is not part of the engine, it can still be used to test collisions. There are two solutions to this problem:

1.  (Preferred solution) Create a PositionedObjectList\<Enemy\> and add your Enemy to that list. Then replace all code which checks against mEnemy to instead loop through your PositionedObjectList\<Enemy\> and test collision. This should be done **for all logic including player attacking enemy and enemy attacking player**. When your Enemy is destroyed, it will be removed from the PositionedObjectList\<Enemy\> and your game will function properly.
2.  (Necessary if you need to keep track of specific Entities) Check your mEnemy's Health before performing collisions. If its health is less than or equal to 0, then it is dead and you shouldn't perform collisions. For example, your collision check should look like:

&nbsp;

    if(mEnemy.Health > 0 && mPlayer.Collision.CollideAgainst(mEnemy.Collision)
    ...
