# implements-idamagearea

### Introduction

The IDamageArea interface creates a standard way to define that an entity can deal damage to other entities. It has built-in support for teams and damage over time.

### Setting Implements IDamageArea

To set an entity as a damage area, set the property on entity in the Properties tab.

![](../../../../media/2021-05-img_60a125377d75d.png)

A game which has entities implementing IDamageArea will also need entities which implement IDamageable.

### Example - Damaging Enemies with Bullets

For this example uses two entities:

1. Bullet - an entity which implements IDamageArea and is ICollidable
2. Enemy - an entity which implements IDamageable and is ICollidable

![](../../../../media/2021-05-img_60a65c5549716.png)

The GameScreen also has a list for each and a collision relationship with an event.

![](../../../../media/2021-05-img_60a65cb463bcd.png)

When the bullet and enemy collide, the ShouldTakeDamage method can be used to determine if the enemy should take damage from the bullet, as shown in the following code snippet.

```
void OnEnemyListVsBulletListCollisionOccurred (Entities.Enemy enemy, Entities.Bullet bullet)
{
    if(enemy.ShouldTakeDamage(bullet))
    {
        enemy.TakeDamage(bullet.DamageAmount);
    }
}
```

The ShouldTakeDamage method is available on the Enemy since it implements the IDamageable interface, but the enemy.TakeDamage and bullet.DamageAmount are not provided automatically and must be implemented in custom code.

### DamageDealer

The IDamageArea interface includes a DamageDealer property which can be used to store a reference to the damage dealer. This is typically used if the damage area is created by another entity, and that entity needs to be referenced upon collision. For example, in a multi-player game, each player may have a separate score. If an enemy is killed by a bullet, then the player who fired that bullet should be awarded points. For example, the following code could be used to assign the DamageDealer on a bullet created inside the Player class:

```
if(WasShootPressed)
{
  var bullet = Factories.BulletFactory.CreateNew(this.X, this.Y);
  bullet.XVelocity = 100;
  bullet.DamageDealer = this;
}
```

&#x20;
