# 02-enemy-entity

### Introduction

This tutorial covers how to add an Enemy to your project. To speed up the process we'll be importing an existing entity rather than building a new one ourselves. Once imported, we will modify the entity so it has the functionality we'll need for this tutorial - specifically adding the ability for the enemy to take damage.

### Importing Enemy Entity

To import the entity

1. Download the exported entity file from here: [https://github.com/vchelaru/FlatRedBall/raw/NetStandard/Samples/Platformer/DealingDamage/Enemy.entz](https://github.com/vchelaru/FlatRedBall/raw/NetStandard/Samples/Platformer/DealingDamage/Enemy.entz)
2. In Glue, right-click on the Entities folder
3.  Select **Import Entity**

    ![](../../../../media/2021-04-img\_607e09e77abbf.png)
4. Navigate to the location where you saved the Enemy file earlier and click OK

We now have a fully-functional enemy which has:

* Collision shape named AxisAlignedRectangle
* Sprite displaying a walking animation
* Platformer values so that it can collide with solid collision
* EnemyInput object which will keep the enemy from moving (does not use the gamepad or keyboard)

![](../../../../media/2021-04-img\_607e0a6f79d2f.png)

### Adding EnemyList to GameScreen

We will add a list to our GameScreen and an instance of our Enemy to Level1 so we can see the enemy in game. To add an enemy list to GameScreen:

1. Select the **Enemy** entity
2. Select the **Quick Actions** tab
3. Click the **Add Enemy List to GameScreen** button - this creates a list of enemies which we'll use to create collision relationships later
4. Click the **Add Enemy Factory** button - this allows us to create enemies in code and Tiled maps.

![](../../../../media/2021-04-img\_607e0b2c6c289.png)

To add an enemy to your Level1:

1. Drag+drop the Enemy entity onto Level1 [![](../../../../media/2021-04-2021\_April\_19\_171821.gif)](../../../../media/2021-04-2021\_April\_19\_171821.gif)
2. Select **Enemy1** and click on the **Variables** tab
3. Set **X** to **160**
4.  Set **Y** to **-160**

    ![](../../../../media/2021-04-img\_607e10dfcde24.png)

Now we have an enemy in the game, but it falls through the level. We can fix this by telling the enemies to collide against our GameScreen's SolidCollision object:

1. Expand **GameScreen**
2. Expand the **Objects** folder
3. Drag+drop the **EnemyList** onto the **SolidCollision** object

[![](../../../../media/2021-04-2021\_April\_19\_185117.gif)](../../../../media/2021-04-2021\_April\_19\_185117.gif) If we run the game now, the enemy will fall and land in the level next to the player.

![](../../../../media/2021-04-img\_607e1e1cb80cb.png)

&#x20;
