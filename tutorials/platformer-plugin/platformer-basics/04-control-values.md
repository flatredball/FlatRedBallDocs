# Movement Values

### Introduction

This page covers all control values in available on a platformer entity. It also provides ways to implement common functionality such as ice physics and under-water levels.

### Modifying Control Values

If you created your game using the wizard, then the Player entity already has a set of default values. If you manually created your Player entity, the it should also have a set of default control variables.

These values serve as a starting point for platformers - they can be tuned to provide a custom feel to platformer entities. The platformer control values can be viewed and edited by selecting the **Player** entity and clicking on the **Entity Input Movement** tab.

![](<../../../.gitbook/assets/11\_06 21 02.png>)

### Max Speed

This is the maximum speed (maximum absolute horizontal velocity) that the character can move through input. Note that if using **Immediate** horizontal movement, then this is a hard value - not other forces can modify the character movement. For more information, see the next section. Increasing this value makes the character move more quickly , but doing so can make the game more difficult to control if the value is too large.

### Immediate and Speed Up/Down

This value controls whether the character reaches maximum velocity immediately, or if it takes time for the character to speed up and slow down to the maximum velocity and back to standing still. Using **Immediate** increases the responsiveness of your game, and allows players to move very accurately. Examples of immediate-movement games include Mega Man and Castlevania.

{% embed url="https://www.youtube.com/watch?v=mOTUVXrAOE8" %}

The **Speed Up/Down** option results in the platformer entity accelerating to max speed and back down to a standstill over time, instead of immediately. This option creates more natural movement and requires more planning on the player's part (such as building up speed before a big jump). Examples of speed up/down movement include the Super Mario Bros. series and the Donkey Kong Country series.

{% embed url="https://www.youtube.com/watch?v=Vxg5eOPmzHI" %}

### Speed Up Time

The **Speed Up Time** value controls how many seconds are required for the platformer entity to reach max speed. This value is only available if using **Speed Up/Down** horizontal movement.

Increasing this value makes the character makes the platformer entity feel sluggish. Decreasing this value makes the platformer entity feel more responsive. A value of 0 is identical to using **Immediate** horizontal movement. A larger speed up time can also be used for different terrains and environments. For example, a larger value can make the ground feel more slippery (if the character is walking on ice). A larger value can also make the character seem more heavy, or can be used to simulate under-water movement. A larger **Speed Up Time** can be used for air movement so that control is less precise when in the air.

{% embed url="https://youtu.be/n9G9Vzd2l8U?t=212" %}

### Slow Down Time

The **Slow Down Time** value controls how many seconds it takes for the platformer entity to decelerate from full-speed to a standstill. A larger value can make the ground seem more slippery, especially when paired with a larger **Speed Up Time**. Usually **Slow Down Time** should not be larger than **Speed Up Time**. If the two values are similar, then this makes the ground feel slippery. The following table shows common combinations of **Speed Up Time** and **Slow Down Time**. The values _High, Medium,_ and _Low_ do not have fixed meaning, but a typical setup may include these values:

* Low .15 seconds
* Medium .4 seconds
* High .8 seconds

Of course you should modify values to achieve the desired movement for your specific game.

|                                 | Speed Up Time | Slow Down Time |
| ------------------------------- | ------------- | -------------- |
| Standard Ground Movement        | Low or Medium | Low            |
| Ice Ground Movement             | High          | High           |
| Underwater Ground Movement      | High          | Medium         |
| Air Movement                    | Medium        | Medium         |
| Heavy Character Ground Movement | High          | Low            |

### Jump Speed

This value controls the velocity of the platformer entity at the moment when jumping off the ground, or when initiating a double-jump. Larger values allow the character to jump higher. This value is typically larger than **Max Speed**, but the exact value often requires multiple iterations to get the right feel.

A platformer entity's jump height is also impacted by **Gravity**, so both **Jump Speed** and **Gravity** may need to be modified together. A low jump speed can be used for double-jumps, or for swimming when under water. A large jump speed can be used for characters who can jump higher. The Jump Speed value on Air movement can control whether the character can perform a double jump. By default this value is 0 which means that the character cannot double-jump. Setting a value greater than 0 means a character can double jump. This topic will be covered in more detail in the following tutorial.

### Hold to Jump Higher

If **Hold to Jump Higher** is checked, then the player will be able to hold the jump button to cause the platformer character to jump higher. This allows players to perform shorter hops when desired, and longer jumps to clear large obstacles. The larger this value, the longer the player can hold the button to jump higher.

#### Implementation Details

Variable-height jumping can be implemented a number of different ways. The platformer entity implements variable height jumping by turning off gravity while the player is holding the button down. This approach has the following characteristics:

* Jumps feel responsive and immediate - the platformer entity does not delay jumping while the player is holding the button down. Instead, jump height is determined by not applying acceleration immediately.
* Jump motion may not appear totally fluid, especially in high-gravity games.

The following image shows two jump arcs. The first is the movement of the character when the button is held, the second is without:

![Example jump arcs](../../../media/2018-01-img\_5a6e23637b9ad.png)

Although it may be difficult to see, the entity moves in a straight line on the first part of the first jump, rather than moving in an arc. This is the result of gravity being turned off while the button is held. If we color the first part red, the linear movement is a little easier to see:

![Initial jump movement with linear portion shown in red](../../../media/2018-01-img\_5a6e249b232c5.png)

### Max Jump Hold Time

The **Max Jump Hold Time** value sets the maximum amount of time that the player can hold the jump button to extend the platformer entity's jump. A large value gives the player the option to hold the button to jump higher. A small value results in the max and min jump heights not differing by much. A very large value may result in the player appearing to "float" while jumping, so keep this in mind when setting large values (such as over 1 second). A large **Max Jump Hold Time** may be used with a small **Max Jump Speed** to create swimming controls.

### **Can Fall Through Clouds**

This value controls whether the platformer entity can press the down arrow + jump to fall down through cloud collision. If this value is false, then cloud collisions can only be jumped up through, but the player cannot fall down through them.

### Cloud Platform Thickness

This is the distance to fall when pressing down + jump on a cloud platform before testing cloud collision again. When falling through cloud collision, collision against clouds is temporarily disabled until the user has fallen far enough. Once that has happened, cloud collision is re-enabled. This value should be roughly the thickness of cloud collision objects plus the height of the player collision. For example, if the tile height is 16 and the player's collision height is 32, then the Cloud Platform Thickness value should be set to 48. If a TileShapeCollection's UpdateShapesForCloudCollision method is called, then only half of the shape will be used for collision, so only half of the tile height needs to be considered when determining the Cloud Platform Thickness.

### Gravity

**Gravity** controls how fast a character accelerates downward when falling. This value is assigned to the PositionedObject.YAcceleration property. Increasing this value makes the entity fall more quickly, while a smaller value makes the entity fall slower, or seem to float.

### Max Falling Speed

**Max Falling Speed** sets a limit to the platformer entity's y velocity. A smaller max falling speed results in the entity falling more slowly, even if **Gravity** is large. A smaller max falling speed can be used to slow a player's fall down with special abilities such as the raccoon tail in Super Mario Bros 3.

{% embed url="https://youtu.be/1DfSMLXGYRc?t=9" %}

A smaller M**ax Falling Speed** and low **Gravity** can be used to implement water physics such as the water levels in Donkey Kong Country.

{% embed url="https://www.youtube.com/watch?v=GH-UGtfGH8I" %}
