# Melee Damage

### Introduction

The previous tutorials showed how to deal damage to an enemy with a Bullet. The Bullet entity implemented only the IDamageArea interface (not the IDamageable), so it served purely as an entity which could deal damage but could not receive damage.

Games which implement melee damage can do so by adding additional shapes to the Player entity and by marking the Player as an IDamageArea (as well as IDamageable). This tutorial shows how to modify your project to allow the Player to deal damage to an Enemy using a melee attack collision.

### Implementing IDamageArea on Player and Enemy

Melee attacks increase the complexity of games because they result in entities that can both deal and receive damage. We need both the Player and Enemy to be able to deal damage.

First, mark the Player entity as both IDamageable and IDamageArea.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Setting a Player as an IDamageable and IDamageArea</p></figcaption></figure>

Repeat the same for the Enemy entity.

<figure><img src="../../.gitbook/assets/image (7).png" alt=""><figcaption></figcaption></figure>

Next, we'll add a collision object to the Player for melee attacks. This can be any type of shape, but we'll use an AxisAlignedRectangle for this tutorial. Be sure to give the new shape a name that clearly explains its purpose, such as **MeleeCollision**.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1).png" alt=""><figcaption><p>Adding MeleeCollision to Player</p></figcaption></figure>

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

This is typically not desirable in games, so we can use damage dealing frequency and invulnerability to solve this problem. Specifically, we have two variables which can be used to solve this problem:

* Enemy SecondsBetweenDamage (how frequently the damage is dealt to the player)
* Player InvulnerabilityTimeAfterDamage (how frequently the player can receive damage)

While these two may seem similar at first, which you use can have an impact on your game. Most older games (such as Super Mario World, Zelda: Link to the Past, Mega Man X, and Super Metroid) implemented invulnerability after being dealt damage. This means that if the player took damage from any damage source, the player would remain invulnerable for a period of time after the damage was dealt. This approach can give the player a moment to recover after taking damage, and can avoid situations where the player is "sandwiched" between multiple damage sources, resulting in health draining rapidly.

By contrast, some games (such as Mega Man X) do not have invulnerability time on regular (non-boss) enemies, allowing players to mash very quickly to deal large amounts of damage. Keep in mind that invulnerability periods also prevent the use of the damage system for gradual damage, such as poison which deals damage every frame.

For this tutorial we will implement invulnerability time for the Player and Enemy, but your game may ultimately require mixing these approaches. More complicated games may also implement their own damage suppression techniques without using the built-in invulnerability and attack frequency values.

To add invulnerability time to the player, select the Player and change the **Invulnerability Time After Damage** variable.

<figure><img src="../../.gitbook/assets/image (106).png" alt=""><figcaption><p>Setting the Player's Invulnerability Time After Damage to 1 second</p></figcaption></figure>

Now, the player can only receive damage one time every second. We can see this is the case because the player survives much longer (about 10 seconds) when overlapping the enemy.

### Dealing Damage to the Enemy

Now that our Player can take damage, we can deal damage to enemies using a similar approach. At a high level the approach is:

1. Create a collision relationship for the Player vs Enemy, setting Subcollision to the Player's MeleeCollision
2. Remove the default (code generated) damage dealing logic on the collision relationship
3. Add an event
4. Implement damage dealing in the event.

To create another collision relationship for player vs enemy:

1. Drag + drop PlayerList onto Enemy list in GameScreen again.&#x20;
2. Set the Player's Subcollision to MeleeCollision  so only the MeleeCollision is considered
3. Uncheck the damage dealing check box
4. Click the **Add Event** button

<figure><img src="../../.gitbook/assets/image (104).png" alt=""><figcaption><p>PlayerMeleeCollisionVsEnemy relationship</p></figcaption></figure>

Now we can modify the damage dealing code in GameScreen.Event.cs:

```csharp
void OnPlayerMeleeCollisionVsEnemyCollided (Entities.Player player, Entities.Enemy enemy)
{
    if(enemy.ShouldTakeDamage(player))
    {
        enemy.TakeDamage(player);

        if(enemy.CurrentHealth <= 0)
        {
            enemy.Destroy();
        }
    }
}
```

Notice this code is similar to the collision code used to deal damage to the Player.&#x20;

You may also want to set the Enemy's Invulnerability Time After Damage to some non-zero value. Keep in mind that doing so will affect the invulnerability time of the enemy from all damage. If you worked through this tutorial by continuing work from previous tutorials, then this code will change the behavior of how enemies take damage.&#x20;

<figure><img src="../../.gitbook/assets/image (107).png" alt=""><figcaption><p>Setting Enemy Invulnerability Time After Damage</p></figcaption></figure>

Notice that the invulnerability time is lower for enemies than for players. You can tune this value to get the right feel for your game.

### Implementing Player Attacks

As implemented now, the player's melee collision deals damage continually to enemies so long as it continues to collide with the enemy when the enemy's invulnerability time expires. Most games with melee attacks require a button to be pushed to perform the attack. When the button is pushed, the attack is only active for a set amount of time, then the attack goes into cooldown.

We can implement this in code by keeping track of when attacks last occurred. Although this has no impact on collision, we can also change the visibility of the weapon. First we will define some variables in code in Player.cs:

```csharp
public partial class Player
{
    // Give this some large negative value so logic
    // doesn't consider attacks to happen right when 
    // the entity is created
    double LastTimeAttackStarted = -999;

    // How long the attack can deal damage
    double AttackDamageDuration = .5;

    // How long the player must wait before attacking again after the attack ends
    double AttackCooldown = 1; 
    
    public bool IsAttackActive =>
        TimeManager.SecondsSince(LastTimeAttackStarted) < AttackDamageDuration;
    
    ...
```

Note that the variables `AttackDamageDuration` and `AttackCooldown` are defined in code. In a full game these variables should be defined in the FRB Editor, but we are defining them in code for the sake of brevity.

Next we can perform attacks and modify the visibility of the melee shape in CustomActivity by adding the following code:

```csharp
private void CustomActivity()
{
    /// You may still have code here for shooting bullets
    /// ...

    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.LeftShift))
    {
        LastTimeAttackStarted = TimeManager.CurrentScreenTime;
    }

    MeleeCollision.Visible = IsAttackActive;
}
```

<figure><img src="../../.gitbook/assets/01_21 44 34.gif" alt=""><figcaption><p>MeleeCollision visibility responding to attack input.</p></figcaption></figure>

Keep in mind the visibility logic exists only for the sake of visualizing when damage can be dealt - we cannot use visibility to control whether collision occurs because invisible shapes collide just like visible shapes. However, we can use the `IsAttackActive` property in the collision event in GameScreen.Event.cs for dealing damage to the enemy, as shown in the following modified code:

```csharp
void OnPlayerVsEnemyCollided (Entities.Player player, Entities.Enemy enemy)
{
    // ShouldTakeDamage checks if
    // * Enemy and Player are on different teams
    // * The player should take damage according to
    //   the last time the player has taken damage 
    //   (for damage over time).
    // NEW: We also check IsAttackActive
    if(player.IsAttackActive && player.ShouldTakeDamage(enemy))
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

### Alternative Approach - Using ModifyDamageDealt

By using the IsAttackActive property in the OnPlayerVsEnemyCollided, we could suppress the dealing of damage unless the player is actively attacking. This approach is effetive in this simple case, but more complicated games may have multiple types of objects which can receive damage from a player. For example, the game may include destructible obstacles, or it may even support PvP. Therefore, we can use the ModifyDamageDealt event to prevent dealing damage against any type of object unless the attack is happening. We can do this by modifying the Player.cs file as shown in the following code:

```csharp
private void CustomInitialize()
{
    this.ModifyDamageDealt += HandleModifyDamageDealt;
}

private decimal HandleModifyDamageDealt(decimal unmodifiedDamage, IDamageable damageable)
{
    if(!IsAttackActive)
    {
        return 0;
    }
    else
    {
        return unmodifiedDamage;
    }
}

```

Note that this method can be used to modify damage in other scenarios. For example, you may have different attacks (strong vs weak), or multiple attacks in a combo. You are free to define variables in your Player file to support attacks of any complexity. You can then process these variables in ModifyDamageDealt to vary the damage dealt to enemies.
