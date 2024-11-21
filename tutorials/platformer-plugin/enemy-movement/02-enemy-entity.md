# Enemy Entity

### Introduction

This tutorial creates an Enemy entity which is used in the remainder of the tutorials. This enemy is similar to the Player entity - it has collision and uses Platformer physics, but it does not use input from a keyboard or gamepad - instead its movement is controlled purely in code.

### Creating the Enemy Entity

To create the Enemy entity:

1. Click the **Quick Actions** tab
2.  Click the **Add Entity** button

<figure><img src="../../../.gitbook/assets/image (357).png" alt=""><figcaption><p>Click the Add Entity quick action button</p></figcaption></figure>

3. Enter the name **Enemy**
4. Check **AxisAlignedRectangle**
5. Check **Platformer** for the **Input Movement Type**
6.  Leave the rest of the defaults and click **OK**

<figure><img src="../../../.gitbook/assets/image (358).png" alt=""><figcaption></figcaption></figure>

You can optionally change the color of your Enemy if you would like by selecting the newly-created AxisAlignedRectangle and setting its color to Red.

### Adding an Enemy to Level1

Entities such as Enemy are usually added directly to levels such as Level1. Note that it is possible to add Entities in more ways including through Tiled and directly in code, but we will be adding an instance directly in the FlatRedBall Editor.

Note that the EnemyList object is defined in GameScreen, but it is also accessible in all levels, such as Level1.

<figure><img src="../../../.gitbook/assets/image (359).png" alt=""><figcaption><p>EnemyList defined in GameScreen but also accessible in Level1</p></figcaption></figure>

The EnemyList must be accessible in both screens. It is used in GameScreen to create collision relationships, which should always be the same across all levels. It is used in each level to define which enemies should appear in a particular level. This setup is enabled by the EnemyList having its **ExposedInDerived** property set to true, which is set up by default from when we created our Enemy entity.

<figure><img src="../../../.gitbook/assets/image (360).png" alt=""><figcaption><p>Lists in GameScreen are typically ExposedInDerived</p></figcaption></figure>

To add an enemy to Level 1, drag+drop the **Enemy** entity onto the **Level1** Screen.

<figure><img src="../../../.gitbook/assets/15_05 18 23.gif" alt=""><figcaption><p>Drag drop enemy onto Level1</p></figcaption></figure>

The newly created entity is automatically added to Level1's EnemyList.

Next the Enemy should be positioned so it is standing on the ground. You can position this through trial-and-error by running the game and adjusting the position of the entity, but the fastest way to accomplish this is in Live Edit mode. For information about setting up Live Edit, see the [Live Edit](../../../glue-reference/enable-live-edit/) page.

<figure><img src="../../../.gitbook/assets/15_05 33 02.gif" alt=""><figcaption><p>Move the Enemy instance in Live Edit so it sits on the ground</p></figcaption></figure>

### EnemyList vs SolidCollision

Now we have a fully-functional enemy, but it falls through the solid collision since we haven't yet set up an EnemyList vs SolidCollision relationship. To do this:

1. Expand **GameScreen** **Objects** folder
2. Drag+drop the **EnemyList** onto **SolidCollision.** Notice that we are doing this in the GameScreen rather than Level1 because we want all enemies to collide with the SolidCollision regardless of level. By doing this in the GameScreen, this new Collision Relationship will apply to all levels, including Level1.

<figure><img src="../../../.gitbook/assets/15_05 40 35.gif" alt=""><figcaption><p>Drag+drop EnemyList onto SolidCollision to create a new collision relationship</p></figcaption></figure>

Glue automatically sets the **Collision Physics** in the new Collision Relationship to **Platformer Solid Collision** since the Enemy entity is marked as a Platformer.

<figure><img src="../../../.gitbook/assets/15_05 42 17.png" alt=""><figcaption><p>EnemyVsSolidCollision is set to Platformer Solid Collision</p></figcaption></figure>

### Conclusion

Now we have an Enemy entity and an instance of this Enemy in Level1. This instance collides with the game's SolidCollision and has full support for platformer physics. Currently both the Player and Enemy are controlled by the keyboard (or gamepad if one is plugged in). We will remove this input control from the Enemy and replace it with logic-based movement in the next tutorial.
