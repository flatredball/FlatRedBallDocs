## Introduction

Most of the work needed to perform damage dealing can be done through the FlatRedBall Editor and generated code. This tutorial shows how to set your entities up so they can deal damage.

## IDamageable and IDamageArea

Damage dealing is done through two interfaces: *IDamageable* and *IDamageArea*. As the names suggest, IDamageable entities can take damage and IDamageArea entities can deal damage. Projects which use the standard damage system should mark entities as IDamageable or IDamageArea in the FlatRedBall Editor. Keep in mind that in some cases entities can be both IDamageable and IDamageAreas.

## Player Defaults

If you have created a platformer or top-down project using the FlatRedBall Wizard, then your Player entity already implements the IDamageable interface. You can verify this by selecting the Player entity and checking the Properties tab.

![](/media/2023-01-img_63bd897ba9088.png)

If your player does not implement IDamageable, you can change this property in the Properties tab to true. Once this value is set, the Player will be ready to be used in the damage system.

## Setting IDamageable and IDamageArea on New Entities

Any entity can implement either IDamageable or IDamageArea interfaces - or both. For example, to add a Bullet entity which implements IDamageArea:

1.  Right-click on Entities
2.  Select to add a new entity
3.  Add appropriate collision (such as a Circle)
4.  Check the option for IDamageArea
5.  Keep the Team Index to 0 (Player Team) if the bullet is created by the Player. This can be set on a per-instance basis in code if your game has bullets that can damage enemies and players (such as a Shoot 'em up game).
6.  Check the **Add Opposing Team Index Collision Relationships to GameScreen**. This creates collision relationships which automatically apply damage.

![](/media/2023-01-img_63be02823e445.png)

Your Bullet entity is now marked as a IDamageArea.

![](/media/2023-01-img_63bd8ab263f30.png)

The Team Index specified in the **new Entity** window defines the default team index. The default team index can be overridden in code, but specifying a team index enables the FlatRedBall Editor to generate collision relationships automatically. For example, consider a game which already has a Bullet defined which uses the Team Index of 0 as shown above. If a new Entity is created using Team Index 1, then collision relationships can automatically be created. To test this out, we can add a new entity named Enemy:

1.  Right-click on Entities
2.  Select to add a new entity
3.  Add appropriate collision (such as an AxisAlignedRectangle)
4.  Check the option for IDamageable so the enemy can take damage from the bullet. Also, enemies may deal damage to the player so the enemy could also be marked as IDamageArea in a full game. To keep things simple we'll only check IDamageable.
5.  Change the Team Index to 1 (Enemy Team)
6.  Check the **Add Opposing Team Index Collision Relationships to GameScreen **option.

![](/media/2023-01-img_63be0357174fe.png)

In this case the game now has an IDamageArea entity (Bullet) and IDamageable entity (Enemy) on different Team Indexes. When the Enemy is added, the FlatRedBall Editor creates collision relationships between the Enemy and Bullet.

![](/media/2023-01-img_63be041e5eb06.png)

## Manually Creating Collision Relationships

In the example above, the EnemyVsBullet collision relationship was created automatically because:

1.  **Add Opposing Team Index Collision Relationships to GameScreen **was checked when creating Enemy
2.  The Enemy has a Team Index (1) different than the already-created Bullet Team Index (0)
3.  The Enemy is IDamageable and the Bullet is IDamageArea

It is possible to manually create collision relationships between IDamageable and IDamageArea lists. For example, the default Bullet Team Index matches the Player Team Index, but your game may allow Enemy instances to shoot bullets too. In this case we can still create a collision relationship between the PlayerList and BulletList. If the PlayerList is drag+dropped on the BulletList, a collision relationship is created with the damage-related checkboxes checked. [![](/wp-content/uploads/2023/01/10_18_36_39.gif.md)](/wp-content/uploads/2023/01/10_18_36_39.gif.md)

## Conclusion

This guide shows how to create entities which are IDamageable and IDamageAreas. Once these entities are created, collision relationships are either automatically created when the entity is created, or they can be added manually with a drag+drop operation. The next guide will show the automatic damage-dealing logic provided by collision relationships and the Team Index variable functionality. -- [02 - Team Index -\>](/documentation/tutorials/damage-dealing/02-team-index/.md)
