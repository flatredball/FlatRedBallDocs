# Melee Damage

### Introduction

The previous tutorials showed how to deal damage to an enemy with a Bullet. The Bullet entity implemented only the IDamageArea interface (not the IDamageable), so it served purely as an entity which could deal damage but could not receive damage.

Games which implement melee damage can do so by adding additional shapes to the Player entity and by marking the Player as an IDamageArea (as well as IDamageable). This tutorial shows how to modify your project to allow the Player to deal damage to an Enemy using a melee attack collision.

### Implementing IDamageArea on Player and Enemy

Melee attacks increase the complexity of games because they result in entities that can both deal and receive damage. We need both the Player and Enemy to be able to deal damage.

First, mark the Player entity as both IDamageable and IDamageArea.

<figure><img src="../../.gitbook/assets/image (1).png" alt=""><figcaption><p>Setting a Player as an IDamageable and IDamageArea</p></figcaption></figure>

Repeat the same for the Enemy entity.

<figure><img src="../../.gitbook/assets/image (7).png" alt=""><figcaption></figcaption></figure>

Next, we'll add a collision object to the Player for melee attacks. This can be any type of shape, but we'll use an AxisAlignedRectangle for this tutorial. Be sure to give the new shape a name that clearly explains its purpose, such as **MeleeCollision**.

<figure><img src="../../.gitbook/assets/image (2).png" alt=""><figcaption><p>Adding MeleeCollision to Player</p></figcaption></figure>

Adjust the MeleeCollision so that it is positioned outside of the Player entity. You can use [Live Edit](../../glue-reference/enable-live-edit.md) to iterate quickly on this.

<figure><img src="../../.gitbook/assets/image (3).png" alt=""><figcaption><p>Modifying the MeleeCollision</p></figcaption></figure>

By default this new shape is used in all relationships which use the Player's **\<Entire Object>,** which is the default for all collisions. For example, the PlayerVsSolidCollision in GameScreen uses this option, so the newly-created MeleeCollision collides with the map's SolidCollision.

<figure><img src="../../.gitbook/assets/01_07 15 08.gif" alt=""><figcaption><p>MeleeCollision blocking player movement</p></figcaption></figure>

Typically, collision shapes which are added for a special purpose (such as only dealing damage to Enemies) should not be used for all collision relationships. We can fix this by setting the MeleeCollision's IncludeInICollidable to false.

<figure><img src="../../.gitbook/assets/image (4).png" alt=""><figcaption><p>Setting MeleeCollision's IncludeInICollidable to false</p></figcaption></figure>

Now the MeleeCollision will only be considered in collision relationships which explicitly select it in the Subcollision dropdown (which we'll do later in this tutorial).

<figure><img src="../../.gitbook/assets/01_07 19 05.gif" alt=""><figcaption><p>Player MeleeCollision being ignored in PlayerVsSolidCollision relationship</p></figcaption></figure>

### Player vs Enemy CollisionRelationships

Next we will create collision relationships between players and enemies. Conceptually, we want the following behavior:

1. When the body of the enemy touches the body of the player, the player should take damage
2. When the sword of the player touches the body of the enemy, the enemy should take damage

Each entity type can deal damage to each other entity type, and the direction of damage dealing depends on which shapes have collided.

We need to have a collision relationship between players and enemies, so we can add this by drag+dropping the PlayerList onto the EnemyList in GameScreen.

<figure><img src="../../.gitbook/assets/01_07 31 06.gif" alt=""><figcaption><p>Drag+drop to create a collision relationship betwen players and enemies</p></figcaption></figure>

Notice that the newly-created collision relationship has the option for dealing damage checked, and that both the player and enemy will receive damage.

<figure><img src="../../.gitbook/assets/image (5).png" alt=""><figcaption><p>Default Deal Damage checkbox</p></figcaption></figure>

This collision relationship should only deal damage to the player if the player collides with the enemy (not also to the enemy). We will handle the melee collision in a dedicated collision relationship that has its Subcollision set to MeleeCollision  - we only want to deal damage to the enemy if the enemy collides with the melee collision that we created earlier. To handle this, uncheck the option to deal damage in the collision relationship, and click the button to add a new event.

<figure><img src="../../.gitbook/assets/image (6).png" alt=""><figcaption><p>Uncheck automatic damage dealing, add an event to the collision relationship</p></figcaption></figure>

This results in an event in GameScreen.Event.cs which we can fill in with our collision logic. To deal damage from the enemy to the player, add the following code:

```csharp
void OnPlayerVsEnemyCollided (Entities.Player player, Entities.Enemy enemy)
{
    // ShouldTakeDamage checks if
    // * Enemy and Player are on different teams
    // * The player should take damage according to
    //   the last time the player has taken damage 
    //   (for damage over time).
    if(player.ShouldTakeDamage(enemy))
    {
        // Raises all events for damage dealing and ultimately
        // modifies the player's health.
        player.TakeDamage(enemy);

        // Typically when an entity reaches 0 health, it should be destroyed
        if(player.CurrentHealth <= 0)
        {
            player.Destroy();
        }
    }
}
```

Now the player takes damage when colliding with the enemy.

<figure><img src="../../.gitbook/assets/01_08 35 49.gif" alt=""><figcaption><p>Player taking damage from the enemy and dying</p></figcaption></figure>

Note that the player dies very quickly after touching the enemy. This happens because the player takes damage every frame (10 damage), so after about 10 frames (1/6th of a second) the player's health reaches 0.

This is typically not desirable in games, so the following can be used to solve this problem:

1. Modify the Enemy's SecondsBetweenDamage so the player doesn't take damage every frame
2. Implement knockback, pushing the player away from the enemy on collision
3. Implementing solid collision, resulting in the two entities separating

It's important to note that even with knockback or solid collision, the player can get in a situation where damage is dealt very frequently. For example, the player can be sandwiched between two enemies, or between an enemy and solid collision. In these cases it's best to implement SecondsBetweenDamage.

For example, we can set the enemy to only deal damage one time every second, as shown in the following image:

<figure><img src="../../.gitbook/assets/01_08 45 26.png" alt=""><figcaption><p>Setting SecondsBetweenDamage to 1 to prevent constant damage</p></figcaption></figure>

Now, the enemy only deals damage one time every second. We can see this is the case because the player survives much longer (about 10 seconds) when overlapping the enemy.





