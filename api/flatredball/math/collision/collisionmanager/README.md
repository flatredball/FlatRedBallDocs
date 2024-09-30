# CollisionManager

### Introduction

The CollisionManager class provides methods for handling collision (the touching of game objects) in FlatRedBall games. The CollisionManager has built-in methods for handling collision between collidable entities (entities which implement the ICollidable interface). Use of the CollisionManager is not necessary, but it can reduce and standardize code for handling collisions. The CollisionManager provides a rich set of functionality for performing collision in code, but usually games do not need to write code against the CollisionManager. Instead, the FlatRedBall Editor provides support for creating CollisionRelationships without any code. For more information, see the [FlatRedBall Editor CollisionRelationship page](../../../../../glue-reference/objects/object-types/collisionrelationship.md).

### Collision Relationships

The CollisionManager is built around the concept of _collision relationships_. A collision relationship is created by specifying the two objects (or groups of objects) which are used in the relationship. The following list shows common relationships in games:

* Player vs. Enemy Bullet List
* Player Bullet List vs. Environment
* Race Car List vs. Boost Entity List
* Explosion List vs. Destructible Block List

The relationship detects collision and provides automatic and custom handling of the collision. Automatic handling includes separating objects (preventing overlapping) and adjusting the velocity of colliding objects (bouncing the objects). Custom handling is done by assigning a collision event.

### Creating a Collidable Entity

The CollisionManager is built to work with collidable entities. To create a collidable entity in Glue:

1. Open Glue
2. Right-click on the Entities folder
3. Click **Add Entity**
4. Check one of the objects under the **Collisions** category, such as **Circle**
5. Notice that the ICollidable checkbox is automatically checked

![](../../../../../.gitbook/assets/2018-01-img\_5a59900256da4.png)

The entity will now implement the ICollidable interface, which means it can be used as an instance or in a list with the CollisionManager.

### Example - Entity vs. Entity Collision

A relationship may define that two individual entities should perform collision logic against one another. The following assumes that PlayerInstance and EnemyInstance are entities added to the screen in Glue:

```csharp
private void CreateCollisionRelationships()
{
    var relationship = CollisionManager.Self.CreateRelationship(
        PlayerInstance, EnemyInstance);
    relationship.CollisionOccurred = HandlePlayerVsEnemyCollision;
}

private void HandlePlayerVsEnemyCollision(Player player, Enemy enemy)
{
    enemy.TakeDamage();
    player.TakeDamage();
}
```

Notice that the HandlePlayerVsEnemyCollision is used to perform custom logic whenever a collision occurs.

### Example - Entity List Relationships

Entities which are dynamically created or destroyed during the life of a screen (such as bullets fired by a turret) are usually added to lists. The following code can be used to detect collision between a single Player instance and a list of Bullets:

```csharp
private void CreateCollisionRelationships()
{
    var relationship = CollisionManager.Self.CreateRelationship(
        PlayerInstance, BulletList);
    relationship.CollisionOccurred = HandlePlayerVsBulletCollision;
}

private void HandlePlayerVsBulletCollision(Player player, Bullet bullet)
{
    bullet.Destroy();
    player.TakeDamage();
}
```

Notice that the CollisionOccurred delegate passes a single bullet even though the type passed to CreateRelationship is a list. This allows the code to handle collision on a case-by-case basis. Similarly, relationships can be created between two lists. The following example shows how to respond to collision between a list of Enemies and a list of Bullets:

```csharp
private void CreateCollisionRelationships()
{
    var relationship = CollisionManager.Self.CreateRelationship(
        EnemyList, BulletList);
    relationship.CollisionOccurred = HandleEnemyVsBulletCollision;
}

private void HandleEnemyVsBulletCollision(Enemy enemy, Bullet bullet)
{
    bullet.Destroy();
    player.TakeDamage();
}
```

### Example - Entity/Entity List vs. TileShapeCollection

Entities can be collied against TileShapeCollections through the CollisionManager. TileShapeCollections are an efficient and convenient way to store a group of rectangles for collision.

```csharp
// Since this is an extension method, you must have the following
// using statement in your class:
using FlatRedBall.Math.Collision;

private void CreateCollisionRelationships()
{
    // SolidCollisions is assumed to be a TileShapeCollection
    var relationship = CollisionManager.Self.CreateTileRelationship(PlayerList, SolidCollisions);
    // Make it so the solid collisions can't be moved:
    relationship.SetMoveCollision(0, 1);
}
```

See the Move Collision section below for more information.

### Example - Move Collision

Collision relationships can specify automatic behavior in addition to assigning the CollisionOccurred delegate. This can be achieved by calling various _Set_ methods. For example, the following results in colliding objects being separated. The SetMoveCollision method takes the relative masses of each object. In this example the colliding player and blocks have equal mass:

```csharp
private void CreateCollisionRelationships()
{
    var relationship = CollisionManager.Self.CreateRelationship(
        Player, BlockList);
    var playerMass = 1;
    var blockMass = 1;
    relationship.SetMoveCollision(playerMass, blockMass);
    // custom collision can also be handled if needed
}
```

The most common ways to call is either with the values of (0,1) and (1,1)

* (0,1) - The first object (typically an entity) will have a mass of 0, meaning it will not be able to move the second object.
* (1,1) - Both objects have equal masses, and will push each other

### Example - Bounce Collision with Per-Entity Mass

Both Move and Bounce collisions can be performed automatically by the relationship by calling either SetMoveCollision or SetBounceCollision. While convenient, these methods require the same mass to be used for all entities in a relationship. In some cases entities may need to have a custom mass per entity. In this example a list of asteroids collides with itself (every asteroid tests for collision against every other asteroid). Each Asteroid has a different Mass value so we can't set one mass for the entire relationship. Instead, the collision is detected and an event is raised, then the bounce collision occurs inside the collision event handler.

```csharp
private void CreateCollisionRelationships()
{
    var relationship = CollisionManager.Self.CreateRelationship(
        AsteroidList, AsteroidList);
    relationship.CollisionOccurred = HandleAsteroidVsAsteroidCollision;
}

private void HandleEnemyVsBulletCollision(Asteroid first, Asteroid second)
{
    const float elasticity = .5f;
    first.CollideAgainstBounce(second, first.Mass, second.Mass, elasticity);
}
```

Note that the example above shows how to do self-collision, but the same approach of handling the move or bounce collision in an event could be performed between two different separate lists.

### Example - Partitioning

The CollisionManager can perform partitioning to improve collision performance. In most cases partitioning can make even large numbers of objects (tens of thousands) have minimal or no impact on your game's frame rate. Partitioning requires two pieces of information:

1. The axis to partition (X or Y). This should be the axis along which objects are most distributed. For example, a platformer with horizontal levels should partition on the X axis.
2. The width or height of each object involved in partitioning.

Both objects in a relationship must be partitioned on the same axis before a relationship will be able to use the partitioning to reduce collision calls. Partitioned objects must be sorted for partitioning to function properly. If the order of objects in the list can change, the CollisionManager can automatically sort the lists. If the order does not change once the list has been created, or if the order is explicitly maintained in custom code, then the sortEveryFrame parameter can be false. The following creates a partitioned collision relationship between a list of Enemies and a list of Bullets.

```csharp
private void CreateCollisionRelationships()
{
    var maxEnemyWidth = 48;
    var maxBulletWidth = 12;
    CollisionManager.Self.Partition(EnemyList, FlatRedBall.Math.Axis.X, 
        maxEnemyWidth, sortEveryFrame = true);
    CollisionManager.Self.Partition(BulletList, FlatRedBall.Math.Axis.X, 
        maxBulletWidth, sortEveryFrame = true);

    var relationship = CollisionManager.Self.CreateRelationship(EnemyList, BulletList);
    relationship.CollisionOccurred += HandeEnemyVsBulletCollision;
}

private void HandeEnemyVsBulletCollision(Enemy enemy player, Bullet bullet)
{
    ...
}
```

Partitioning must set on both objects in a relationship even if one of the objects is a single instance - in that case the Partition call is needed to get the width or height of the object's collision.

```csharp
private void CreateCollisionRelationships()
{
    var maxPlayerWidth = 30;
    var maxBulletWidth = 12;
    CollisionManager.Self.Partition(Player, FlatRedBall.Math.Axis.X, 
        maxPlayerWidth);
    CollisionManager.Self.Partition(BulletList, FlatRedBall.Math.Axis.X, 
        maxBulletWidth, sortEveryFrame = true);

    var relationship = CollisionManager.Self.CreateRelationship(Player, BulletList);
    relationship.CollisionOccurred += HandeEnemyVsBulletCollision;
}

private void HandeEnemyVsBulletCollision(Enemy enemy player, Bullet bullet)
{
    ...
}
```

The Partition method only needs to be called once, even if an object is used in multiple relationships.

```csharp
private void CreateCollisionRelationships()
{
    var maxPlayerWidth = 30;
    var maxBulletWidth = 12;
    var maxEnemyWidth = 28;

    // Partition is only called one time on Player, even though
    // Player is used in multiple relationships.
    CollisionManager.Self.Partition(Player, FlatRedBall.Math.Axis.X, 
        maxPlayerWidth);
    CollisionManager.Self.Partition(BulletList, FlatRedBall.Math.Axis.X, 
        maxBulletWidth, sortEveryFrame = true);
    CollisionManager.Self.Partition(EnemyList, FlatRedBall.Math.Axis.X, 
        maxEnemyWidth, sortEveryFrame = true);


    var playerVsBulletRelationship = CollisionManager.Self.CreateRelationship(
        Player, BulletList);
    playerVsBulletRelationship.CollisionOccurred += HandlePlayerVsBulletCollision;

    var playerVsEnemyRelationship = CollisionManager.Self.CreateRelationship(
        Player, EnemyList);
    playerVsEnemyRelationship.CollisionOccurred += HandlePlayerVsEnemyCollision;
}
```

### Counting Collisions

In general reducing collision count improves the performance of your game. To measure whether your efforts to reduce collision are working (such as by implementing partitioning), the CollisionManager returns the number of _deep collisions_ performed every frame. The term deep collision refers to collision methods which rely on the actual shapes of a collidable object, as opposed to partitioned checks which can eliminate large numbers of objects very quickly. The following code shows how to count and display the number of collisions performed every frame:

```csharp
void CustomActivity(bool firstTimeCalled)
{
    FlatRedBall.Debugging.Debugger.Write(
        CollisionManager.Self.DeepCollisionsThisFrame);
}
```

### Example - SubCollision

Entities may include multiple collision objects used for different responses. For example, a SpaceShip entity may have a small collision shape for its body (for taking damage) and a larger collision shape for a radar ( to detect enemies and display them on a radar HUD). Collision relationships will use the entire entity by default, but can be configured to only use a single shape by calling SetFirstSubCollision or SetSecondSubCollision for the first or second object in the relationship, respectively. The following code shows how to handle SpaceShip body vs. a list of Bullets:

```csharp
private void CreateCollisionRelationships()
{
    var relationship = CollisionManager.Self.CreateRelationship(SpaceShipInstance, BulletList);
    relationship.CollisionOccurred += HandleSpaceShipVsBulletCollision;
    relationship.SetFirstSubCollision(spaceShip => spaceShip.CircleInstance);
}
```

SetFirstSubCollision refers to the first argument in the CreateRelationship call, which is SpaceShipInstance in the example above. SetSecondSubCollision refers to the second argument in the CreateRelationship call, which is BulletList in the example above. Note that if the argument to CreateRelationship is a list, then the SetFirstSubCollision and SetSecondSubCollision will work with a single instance rather than a list. For example, the code above could call SetSecondSubCollision for the BulletList , but the argument would take a single bullet as shown in the following snippet:

```csharp
private void CreateCollisionRelationships()
{
    var relationship = CollisionManager.Self.CreateRelationship(SpaceShipInstance, BulletList);
    ...
    // Note we use "bullet" and not the entire list in this call:
    relationship.SetSecondSubCollision(bullet => bullet.CircleInstance);
}
```

#### SubCollision and Partitioning

When using a sub collision, the partition values may be different to account for the different collision object size. For example, the body of a space ship may be much smaller than the radar. Relationships can override the width or height values used for partitioning. The following code shows how to provide different collision width values (for X axis partitioning) for radar and body collision relationships:

```csharp
private void CreateCollisionRelationships()
{
    // The Partition calls will define the default width values for the ship, bullet, and enemy entities,
    // which can be overridden by calling SetPartitioningSize on relationships.
    var defaultShipWidth = 48;
    var maxBulletWidth = 12;
    var maxEnemyWidth = 54;
    CollisionManager.Self.Partition(SpaceShipInstance, FlatRedBall.Math.Axis.X, defaultShipWidth);
    CollisionManager.Self.Partition(BulletList, FlatRedBall.Math.Axis.X, maxBulletWidth);
    CollisionManager.Self.Partition(EnemyList, FlatRedBall.Math.Axis.X, maxEnemyWidth);
    
    var shipVsBulletRelationship = CollisionManager.Self.CreateRelationship(
        SpaceShipInstance, BulletList);
    shipVsBulletRelationship.SetFirstSubCollision(spaceShip => spaceShip.BodyCollision);
    // Only the enemy's partition size is overridden for this relationship. Bullets will use default width
    var spaceShipBodyCollisionWidth = 25;
    shipVsBulletRelationship.SetPartitioningSize(SpaceShipInstance, spaceShipBodyCollisionWidth);

    var spaceShipRadarVsEnemyRelationship = CollisionManager.Self.CreateRelationship(
        SpaceShipInstance, EnemyList);
    spaceShipRadarVsEnemyRelationship.SetFirstSubCollision(spaceShip => spaceShip.RadarCollision);
    // As with the relationship above, we only override the ship width for this collision. 
    // Enemies will use the default width.
    var spaceShipRadarCollisionWidth = 200;
    spaceShipRadarVsEnemyRelationship.SetPartitioningSize(SpaceShipInstance, spaceShipRadarCollisionWidth);


}
```

### Example: Optional Collision Physics

At times collision physics needs to be applied optionally. For example, a Player may be able to transform into a ghost. Normally the player may perform solid collision (Move or Bounce) against enemies, but while in the ghost phase the player can move through enemies. This can be done by telling the collision relationship to optionally apply collision as shown in the following code:

```csharp
// Assuming PlayerVsEnemy is a valid collision relationship
PlayerVsEnemy.ArePhysicsAppliedAutomatically = false;
PlayerVsEnemy.CollisionOccurred += PlayerVsEnemyCollided;
// handle the event:
void PlayerVsEnemyCollided (Entities.Player player, Entities.Enemy enemy)
{
    if(player.IsGhost == false)
    {
        PlayerVsEnemy.DoCollisionPhysics(player, enemy);
    }
}
```

### Manual Collision with DoCollisions

The default behavior for relationships is to perform collisions every-frame. The CollisionRelationship class provides additional control for when collisions are called. The DoCollisions method can be called in custom code to perform collisions as desired. This can be useful if collisions need to happen after certain logic has executed in a frame, or only in certain situations. The following code shows how to create a CollisionRelationship which is only collided when the user holds the Space key:

```csharp
CollisionRelationship relationship;

private void CreateCollisionRelationships()
{
    relationship = CollisionManager.Self.CreateRelationship(
        PlayerInstance, BulletList);

    // Tell the CollisionManager to not automatically run collision every-frame
    relationship.IsActive = false;
}

void CustomActivity()
{
    if(InputManager.Keyboard.KeyDown(Keys.Space))
    {
        relationship.DoCollisions();
    }
}
```
