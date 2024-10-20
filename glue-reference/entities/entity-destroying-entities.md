# Destroying Entities

### Introduction

The Destroy method is used to completely destroy an entity. Generated code calls Destroy for any entity and any list of entities in your current Screen whenever the Screen is destroyed (when the game moves to a different screen). Destroy may need to be manually called if an entity is created manually in game code.

Destroy can also automatically called on Entities which take or receive damage based on properties assigned in their collision relationship. For more information on destroying entities when taking damage, see the [Damage Dealing Tutorials](../../tutorials/damage-dealing/).

### What does Destroy do?

When an Entity's Destroy method is called, the following happens:

* Generated code destroys any contained object which has been added through FlatRedBall Editor. For example, if your Entity has a Sprite and a Circle, both are automatically removed from the engine, resulting in the Entity no longer being visible on screen.
* The entity is removed from the engine (SpriteManager) management, so its automatic properties such as Velocity and Acceleration will no longer be applied. Specifically, FlatRedBall.SpriteManager.RemovePositionedObject is called.
* The entity is removed from any list that it is a part of. For example, if your GameScreen contains a BulletList, calling Destroy on the Bullet will remove the Bullet instance from the BulletList. This is done through the FlatRedBall.SpriteManager.RemovePositionedObject call.
* If the entity is an IWindow-implementing Entity, the entity is removed from the GuiManager so it no longer receives clicks or other UI interaction
* If the entity is a collidable entity, its collision is cleared so future collision calls will return false
* The entity's CustomDestroy is called, enabling custom code to perform additional object removal.

Note that when writing code in CustomDestroy, the entity **should not unload content**. The content manager used to load content for the Entity should be provided by the [Screen](../../frb/docs/index.php) that contains the Entity. [Screens](../../frb/docs/index.php) automatically unload their content managers, and this will clean up content loaded by the Entity.

### When is Destroy called?

As mentioned above, Destroy is automatically called by generated code in the following situations:

* Whenever a screen is destroyed, all of the entities added to the screen through the FlatRedBall Editor will also have Destroy called
* Whenever a screen is destroyed, all of the entity lists added to the screen through the FlatRedBall Editor will also have their Destroy called. Typically this includes all entities which have been created by a Factory when the GameScreen (or a derived Level Screen) is destroyed.
* Whenever an entity is destroyed, any entities that it contains will also be destroyed.

Custom code may need to call Destroy. Usually custom code only needs to destroy entities that it creates on its own. The most common case is when entities should be destroyed as a result of collision, such as when a bullet hits a wall.

### Example - Destroying in a Collision Event

The most common situation where Destroy is explicitly called is in collision handling events. For example, consider a game like Pac-Man where the Player is moved around the screen and "eats" pellets. Whenever the player collides with a Pellet, the Pellet instance should be destroyed. In this type of game, the GameScreen would contain two lists: PlayerList and PelletList. A collision relationship between the PlayerList and PelletList would define an event where the destruction of a pellet occurs:

![](<../../.gitbook/assets/11\_13 12 35.png>)

The collision relationship event handler might look like as shown in the following code snippet:

```csharp
void OnPlayerVsPelletCollided(
    Entities.Player player, Entities.Pellet pellet)
{
    pellet.Destroy();
    // award points, play sfx, etc
}
```

Situations where damage is dealt (such as a bullet hitting a player) should be handled using the IDamageable and IDamageArea interfaces. FlatRedBall provides automatic destruction of entities which use this interface.

### Destroy and membership in your game

The two-way relationship between Entities (and all other [PositionedObjects](../../frb/docs/index.php)) and the [PositionedObjectList](../../frb/docs/index.php) class is what enables the Destroy method to remove an Entity from the engine. In fact, the [PositionedObjectList](../../frb/docs/index.php) (and any class which inherits from [PositionedObjectList](../../frb/docs/index.php)) is the **only** reference that Entities know about. If you store a reference to an individual Entity, the reference will still be valid after you call Destroy unless your code handles this case. Let's look at some simple examples. In our first example we'll create some code where the user is keeping track of an individual player and enemy: At class scope:

```csharp
Player mPlayer = new Player();
Entity mEnemy= new Enemy();
```

This piece of code checks for the player attacking the enemy:

```csharp
if(mPlayer.AttachCollision.CollideAgainst(mEnemy.Collision)
{
    const float attackDamage = 10;
    mEnemy.Health -= attackDamage;

    if(mEnemy.Health <= 0)
    {
        mEnemy.Destroy();
    }
}
```

This piece of code checks for the player touching and being hurt by the enemy:

```csharp
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
```

The code above has a logic bug which will cause the game to behave improperly. When the Enemy is destroyed (through mEnemy.Destroy();) then all of its components will be removed from the engine. Its visible representation and collision will be removed from the appropriate managers. It will also be removed from the SpriteManager so that it is no longer managed by the Engine. However **the collision check between mPlayer and mEnemy is still being done!** If you think about it a bit, this makes sense. This is because your code doesn't check if mEnemy is dead. It does the check no matter what. However, since mEnemy is destroyed, it is no longer part of the engine. The result is that mEnemy will seem to completely disappear, but its Collision object will still be sitting there, invisible, in the level. Even though it is not part of the engine, it can still be used to test collisions. There are two solutions to this problem:

1. (Preferred solution) Create a PositionedObjectList\<Enemy> and add your Enemy to that list. Then replace all code which checks against mEnemy to instead loop through your PositionedObjectList\<Enemy> and test collision. This should be done **for all logic including player attacking enemy and enemy attacking player**. When your Enemy is destroyed, it will be removed from the PositionedObjectList\<Enemy> and your game will function properly.
2. (Necessary if you need to keep track of specific Entities) Check your mEnemy's Health before performing collisions. If its health is less than or equal to 0, then it is dead and you shouldn't perform collisions. For example, your collision check should look like:

```csharp
if(mEnemy.Health > 0 && mPlayer.Collision.CollideAgainst(mEnemy.Collision)
...
```

### Destroying Entities on Death and Collection

Many types of entities can die, be collected, or have other types of removal through custom logic. These entities may create additional visuals when removed. Examples include:

* A collected coin may create a sparkle
* A dead enemy may fall to the ground the flash for a second
* A barrel may create an explosion when shot
* A boss may explode and break apart gradually

Projects which include entities like the ones listed above are encouraged to destroy the entity immediately rather than modify properties to indicate that the entity is in a destroyed/dead state. For example, when a coin is collected it should be immediately destroyed and a new entity or Sprite should be created in its place to play the sparkle effect. Similarly, a dead enemy should be immediately destroyed, being replaced by an entity (such as DeadEnemy).

This approach is encouraged for a number of reasons:

1. By destroying entities immediately, collision relationship events can be simplified. If dead enemies are not destroyed immediately, then additional checks may be needed in the collision event handlers to check if an enemy is alive or dead. For example, a dead enemy should probably not damage the player or absorb bullets.
2. Game state which depends on entity instances (such as a game progressing after all enemies are dead) is simplified since it does not need to consider the state of entities. Instead it can rely on the count in the relevant entity list.

A typical game may have over a dozen collision relationships for entity lists which are core to the game logic, such as PlayerList, EnemyList, or BulletList. Simplifying the collision event handlers can make it easier to maintain the game as it grows.

Keep in mind that even though entities should be destroyed immediately when killed or collected, adding post-removal animations to their AnimationChain file (.achx) is common.

