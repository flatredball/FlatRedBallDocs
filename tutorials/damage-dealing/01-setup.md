# Setup

### Introduction

Most of the work needed to perform damage dealing can be done through the FlatRedBall Editor and generated code. Of course, damage dealing can also be managed in code for more flexibility.

This tutorial shows how to set your entities up so they can deal damage.

### IDamageable and IDamageArea

Damage dealing is done through two interfaces: _IDamageable_ and _IDamageArea_. As the names suggest, IDamageable entities can take damage and IDamageArea entities can deal damage. Projects which use the standard damage system should mark entities as IDamageable or IDamageArea in the FlatRedBall Editor. Keep in mind that in some cases entities (such as enemies) can be both IDamageable and IDamageAreas.

### Player Defaults

If you have created a platformer or top-down project using the new project Wizard, then your Player entity already implements the IDamageable interface. You can verify this by selecting the Player entity and checking the Properties tab.

![](../../.gitbook/assets/2023-01-img\_63bd897ba9088.png)

If your player does not already implement IDamageable, you can change this property in the Properties tab to true. Once this value is set, the Player will be ready to be used in the damage system.

### Setting IDamageable and IDamageArea on New Entities

Any entity can implement either IDamageable or IDamageArea interfaces - or both. For example, to add a Bullet entity which implements IDamageArea:

1. Right-click on Entities
2. Select to add a new entity
3. Add appropriate collision (such as a Circle)
4. Check the option for IDamageArea
5. Keep the Team Index to 0 (Player Team) if the bullet is created by the Player. This can be set on a per-instance basis in code if your game has bullets that can damage enemies and players (such as a shoot-'em-up game).

![](<../../.gitbook/assets/01\_06 11 28.png>)

Your Bullet entity is now marked as a IDamageArea.

![](../../.gitbook/assets/2023-01-img\_63bd8ab263f30.png)

The Team Index specified in the **new Entity** window defines the default team index. The default team index can be overridden in code, but specifying a team index enables the FlatRedBall Editor to generate collision relationships automatically. For example, consider a game which already has a Bullet defined which uses the Team Index of 0 as shown above. If a new Entity is created using Team Index 1, then collision relationships can automatically be created. To test this out, we can add a new entity named Enemy:

1. Right-click on Entities
2. Select to add a new entity
3. Add appropriate collision (such as an AxisAlignedRectangle)
4. Check the option for IDamageable so the enemy can take damage from the bullet. Also, enemies may deal damage to the player so the enemy could also be marked as IDamageArea in a full game. To keep things simple we'll only check IDamageable for now.
5. Change the Team Index to 1 (Enemy Team)
6. Check the **Add Opposing Team Index Collision Relationships to GameScreen** option.

![](<../../.gitbook/assets/01\_06 15 14.png>)

Notice that the new Entity window provides a preview of the collision relationships that are added to the GameScreen after creating the entity. This lets you check for unintended collision relationship creation. If the list of collision relationships matches what your game needs you can use the **Add Opposing Team Index Collision Relationships to GameScreen** option. Alternatively, if you would like to create your own collision relationships, you can uncheck this option.

In this case the game now has an IDamageArea entity (Bullet) and IDamageable entity (Enemy) on different Team Indexes. As shown in the **new entity window**, when the Enemy is added, the FRB creates collision relationships between the Enemy and Bullet.

![](../../.gitbook/assets/2023-01-img\_63be041e5eb06.png)

### Manually Creating Collision Relationships

In the example above, the EnemyVsBullet collision relationship was created automatically because:

1. **Add Opposing Team Index Collision Relationships to GameScreen** was checked when creating Enemy
2. The Enemy has a Team Index (1) different than the already-created Bullet Team Index (0)
3. The Enemy is IDamageable and the Bullet is IDamageArea

It is possible to manually create collision relationships between IDamageable and IDamageArea lists. For example, the default Bullet Team Index matches the Player Team Index, but your game may allow Enemy instances to shoot bullets too.

In this case we can still create a collision relationship between the PlayerList and BulletList. If the PlayerList is drag+dropped on the BulletList, a collision relationship is created with the damage-related checkboxes checked.

<figure><img src="../../.gitbook/assets/01_06 18 08.gif" alt=""><figcaption></figcaption></figure>

### Conclusion

This guide shows how to create entities which are IDamageable and IDamageAreas. Once these entities are created, collision relationships are either automatically created when the entity is created, or they can be added manually with a drag+drop operation. The next guide will show the automatic damage-dealing logic provided by collision relationships and the Team Index variable functionality.
