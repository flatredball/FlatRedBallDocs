## Introduction

This tutorial will add a new entity to our game called Npc. This Entity will display an animated Sprite, will have a collision rectangle, and will navigate the map randomly.

## Downloading Files

Our NPC will display animations using an AnimationChainList file (.achx). We need to download this file and the accompanying .png file. Save these to a location you will remember since we'll need these files later in the tutorial:

-   <https://raw.githubusercontent.com/vchelaru/FlatRedBall/NetStandard/Samples/FinalFantasy2/Npcs.png>
-   <https://raw.githubusercontent.com/vchelaru/FlatRedBall/NetStandard/Samples/FinalFantasy2/NpcAnimations.achx>

## Creating the Npc Entity

Next we'll add the NPC entity. We'll follow the typical Entity naming convention and name it **Npc**:

1.  Click the **Add Entity** button in the **Quick Actions** tab

    ![](/media/2021-03-img_6057b3c80b16a.png)

2.  Enter the name Npc

3.  Check the Sprite checkbox

4.  Check the AxisAlignedRectangle checkbox

5.  Leave the Tiled options checked - this will automatically add an NpcList to our GameScreen

6.  Click the **OK** button

    ![](/media/2021-03-img_6057b43f20fc4.png)

Notice that we did not check the Top-Down movement type. The reason for this is we will be implementing a movement system similar to Final Fantasy 2. Rather than continuous movement, NPCs move one tile at a time, then pause on the tile for a second before moving again. This type of movement has special considerations beyond what is offered by the top down movement system, so we'll be implementing our own movement logic.

## Adding Animations

To add animations to our NPC:

1.  Drag+drop the downloaded NpcAnimations.achx file onto the Npc's Files folder in Glue. Glue will automatically copy the .png file, so we only need to drop the .achx file. [![](/media/2021-03-2021_March_21_155105.gif)](/media/2021-03-2021_March_21_155105.gif)

2.  Expand the Objects folder in Npc

3.  Drag+drop the NpcAnimations.achx file onto SpriteInstance to set its animations [![](/media/2021-03-2021_March_21_150407.gif)](/media/2021-03-2021_March_21_150407.gif)

4.  Select **SpriteInstance**

5.  Select the **Variables** tab

6.  Set the Current Chain Name to **WalkDown** so the NPC plays this animation by default

    ![](/media/2021-03-img_6057b6090c1b0.png)

## Adding an Npc Instance to GameScreen

Now we can add an Npc to our GameScreen. Drag+drop the Npc entity onto the GameScreen and Glue will add a single Npc to the NpcList. [![](/media/2021-03-2021_March_21_155510.gif)](/media/2021-03-2021_March_21_155510.gif) If you run the game you may notice the nenwly-created Npc1 behind the map.

![](/media/2021-03-img_6057b7c9b8b0a.png)

This is happening because both the map and the Npc1 object have a Z value of 0. We can move the map on the Z axis to force it to draw behind all entities:

1.  Expand GameScreen's Objects folder

2.  Select Map

3.  Change the Z to -1 in the Variables tab

    ![](/media/2021-03-img_6057b73a5eb34.png)

Now the Npc1 instance (and any other entity added to the GameScreen) will draw in front of the map.

![](/media/2021-03-img_6057b76bbb497.png)

## Adjusting NPC Starting Position and Collision

Our NPC is currently positioned at the top-left of the map, and the collision rectangle is far too large. To fix this:

1.  Expand the Npc entity's Objects folder

2.  Select AxisAlignedRectangleInstance

3.  Click the Variables tab

4.  Change both Width and Height to 16 to match the tile size

    ![](/media/2021-03-img_6057bb1f34c24.png)

We'll also want to move the NPC to start in the middle of the town. Each tile is 16 pixels, so the center of the top-left tile starts at X=8, Y=-8. We can use a math formula in the X and Y values of the NPC to offset by a certain number of tiles. For example, to move the NPC 14 tiles to the right and 20 tiles down, select **Npc1** in **GameScreen** and enter the following:

-   X: 8 + (16\*14)
-   Y: -8 - (16 \* 20)

![](/media/2021-03-img_6057bcb697dff.png)

Now the Npc1 instance is standing in the middle of the town.

![](/media/2021-03-img_6057be5cc54a3.png)
