# 01-new-project-setup

### Introduction

This tutorial shows how to create an effect similar to the Actraiser spinning [Mode-7 ](https://en.wikipedia.org/wiki/Mode_7) sequence which plays before each of the platformer levels. To see this in action, see the following video: \[embed]https://youtu.be/iJTnHa9aWiA?t=68\[/embed] Fortunately FlatRedBall supports 3D cameras, so the effect is fairly easy to create. We will begin with an empty project to show how this effect can be created from scratch. My project is called **ActraiserMode7**.

![](../../../../media/2021-03-img_60550f15aa026.png)

### Creating a Screen

Normally we use the Glue Wizard to set up a project. In this case we won't use the Glue Wizard because we won't be creating a full game. Rather, we'll just create a single Screen which is not a typical FRB Screen - it won't have any collision, entities, or even any UI. Since this Screen will be fully self-contained, everything we do in this tutorial can be done in an existing project too. First, we'll add a new Screen:

1.  Click the **Add Screen/Level** button in the **Quick Actions** tab

    ![](../../../../media/2021-03-img_60551089e1858.png)
2. Enter the name **Mode7Screen**
3. Select the **Empty Screen** option
4. Click **OK**

![](../../../../media/2021-03-img_605510df9cdae.png)

### Camera Setup

Next we'll make sure our Camera is set up properly.

1. Click the Camera icon in the toolbar
2. Set the resolution to 256x224 to match the SNES resolution
3. Keep the perspective as 2D - even though our game will use 3D perspectives, in a real game the 3D perspective is temporary. We will use a 3D camera in this Screen, but we want other screens to be 2D.
4. Change the **Texture Filter** to **Point**
5.  Change the Scale to a larger number such as 300% or 400% so the window is large enough to see clearly

    ![](../../../../media/2021-03-img_605511e96c05d.png)

### Adding the WorldMap Sprite

Our game will use a single sprite for the world map. If this were a full game we might instead use a Tiled Map for the world map, especially since the real Actraiser game updates the map according to how much each town has been built. Fortunately, whether we use a single Sprite or a Tiled Map doesn't matter - the camera behavior will be the same either way. The Sprite will display the following image, so download it to your computer and remember where you saved it. ![](https://github.com/vchelaru/FlatRedBall/raw/NetStandard/Samples/Overworld/OverworldMapImage.png) Drag+drop this file into your Screen.

![](../../../../media/2021-04-img_606cf882cfa65.png)

Next, click the **Add Object to Mode7Screen** and add a Sprite.

![](../../../../media/2021-03-img_605515d9cd8c4.png)

Finally, set the SpriteInstance's **Texture** property to **OverworldMapImage.**

![](../../../../media/2021-04-img_606cf8c164fe3.png)

Our game now displays the Sprite (or at least part of it) if we run it.

![](../../../../media/2021-04-img_606cf9639c6dd.png)

### Conclusion

Our game is now set up to display the world map. The next tutorial will add the Camera behavior to mimic the behavior in ActRaiser when starting a new game.
