## Introduction

This tutorial will create the Enemy entity which we'll use in the remainder of the tutorials. This enemy will be similar to a Player entity - it has collision and will use Platformer physics, but it will not use input from a keyboard or gamepad - instead its movement will be controlled purely in code.

## Creating the Enemy Entity

We'll be creating an Enemy entity ourselves since it wasn't automatically created for us by the Glue Wizard. To do this:

1.  Click the **Quick Actions** tab

2.  Click the **Add Entity** button

    ![](/media/2021-04-img_60778d5b43a87.png)

3.  Enter the name **Enemy**

4.  Check **AxisAlignedRectangle**

5.  Check **Platformer** for the **Input Movement Type**

6.  Leave the rest of the defaults and click ****OK****

    ![](/media/2022-06-img_62a0d9af55429.png)

We will also change the color of the enemy rectangle so we can tell it apart from the Player:

1.  Expand the Enemy **Object** folder
2.  Select **AxisAlignedRectangleInstance**
3.  Select the **Variables** tab
4.  Change **Width** to **16**
5.  Change **Height** to **16**
6.  Change **Color** to **Red**

![](/media/2021-04-img_60778f4feef7e.png)

## Adding an Enemy to Level1

Normally entities like Enemies are added through Tiled files, as shown in the [breaking blocks tutorial](/documentation/tutorials/platformer-plugin/breaking-blocks.md). To keep the tutorial shorter, we will be directly adding Enemy instances through Glue. We could add enemies to GameScreen, but it's more common for each level to specify its own enemies, so we'll be adding the enemy instance to level1. First we will modify the EnemyList in GameScreen (which was automatically added as one of the default options when we created our Enemy entity) so it can be accessed in the levels. To do this:

1.  Expand GameScreen **Objects** folder
2.  Select **EnemyList**
3.  Click the **Properties** tab
4.  Set **ExposedInDerived** to **True**

![](/media/2021-04-img_607790a49c1d6.png)

Now that this is true, the EnemyList appears in all of the Level screens (which are derived from the GameScreen), and we can add instances to these lists.

![](/media/2021-04-img_607790f455d7c.png)

To add an enemy to Level 1, drag+drop the **Enemy** entity onto the **Level1** Screen.[![](/wp-content/uploads/2021/04/2021_April_14_192104.gif)](/wp-content/uploads/2021/04/2021_April_14_192104.gif) We also need to modify the Enemy so it is positioned inside of the solid boundary of our game screen. To do this:

1.  Select the newly-created **Enemy1** in **Level1**
2.  Select the **Variables** tab
3.  Change **X** to **160**
4.  Change **Y** to **-160**

![](/media/2021-04-img_60779420c673c.png)

## EnemyList vs SolidCollision

Now we have a fully-functional enemy, but it falls through the solid collision since we haven't yet set up an EnemyList vs SolidCollision relationship. To do this:

1.  Expand **GameScreen** **Objects** folder
2.  Drag+drop the **EnemyList** onto **SolidCollision. **Notice that we are doing this in the GameScreen rather than Level1 because we want all enemies to collide with the SolidCollision regardless of level. [![](/wp-content/uploads/2021/04/2021_April_14_195924.gif)](/wp-content/uploads/2021/04/2021_April_14_195924.gif)

Glue automatically sets the **Collision Physics** to **Platformer Solid Collision** since the Enemy entity is marked as a Platformer.

![](/media/2021-04-img_6077966149575.png)

## Conclusion

Now we have an Enemy entity and an instance of this Enemy in Level1. This instance collides with the game's SolidCollision and has full support for platformer physics. Currently both the Player and Enemy are controlled by the keyboard (or gamepad if one is plugged in). We will remove this input control from the Enemy and replace it with logic-based movement in the next tutorial.  
