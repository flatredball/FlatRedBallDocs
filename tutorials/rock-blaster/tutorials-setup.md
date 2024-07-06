# Setup

### Introduction

This tutorial begins with the creation of a new project in FlatRedBall. We'll make a new **Desktop GL .NET 6** project.

### Creating a new project

To create a new project:

1. Select **File** -> **New Project** or click the **New Project** button in the **Quick Actions** tab if you do not have a project open already
2. Enter the name **RockBlaster** (no spaces) as your project name
3. Click **Create Project!**

![Name your project RockBlaster then click Create Project!](<../../.gitbook/assets/30\_06 17 45.png>)

Wait for your project to finish downloading and the Project Setup Wizard automatically opens.

Check the **Custom (Advanced)** option.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

Select Start Wizard from Scratch.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

We will change a few of the default options. Follow along with these images and make your options match.

![](<../../.gitbook/assets/15\_07 55 56.png>)

Our game will not use **Tiled Map** files. **CloudCollision** is only used for platformer games.

![](<../../.gitbook/assets/15\_07 56 54.png>)

Our player will not use default control types like **Top-down** or **Platformer**. We will be implementing our own custom controls, so select the **None (controls will be added later)** option. Our player will rotate, so **Circle** collision is preferred to Rectangle collision. Also, our player is not a platformer character, so uncheck **Add Player vs. cloud collision**.

![](<../../.gitbook/assets/30\_06 21 04.png>)

Change **Number of levels to create** to **1**. Uncheck the other options since our game does not have any **Tiled Map** files.

![](<../../.gitbook/assets/15\_07 58 22.png>)

Leave UI options unchanged. We will use Gum to display game HUD.

![](<../../.gitbook/assets/30\_06 22 11.png>)

Set the Game Resolution to 800x600 and the Game Scale% to 100. Uncheck all other **Camera** options. Our game will not have a Camera which moves.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

Skip the option to Download/Import screens by clicking **Next**.

<figure><img src="../../.gitbook/assets/image (3) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

Skip the option to add additional objects by clicking **Next**.

![](<../../.gitbook/assets/15\_08 01 00.png>)

Click **Done**. Wait a moment and your project will be all set up.

![](<../../.gitbook/assets/15\_08 03 20.png>)

If we run our game now we will see our player which is a white circle.

![](../../media/2021-03-img\_604cda3d3d060.png)

### Conclusion

That was easy! You now have a project that we will use in the following tutorials. Next we will set up the skeleton (the general structure) of our game.
