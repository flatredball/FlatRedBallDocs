## Introduction

This tutorial begins with the creation of a new project in Glue. We'll make a new DesktopGL project.

## Creating a new project

First we'll make a project in Glue.

1.  Select **File **-\> **New Project** or click the **New Project** button in the **Quick Actions** tab if you do not have a project open already
2.  Enter the name **RockBlaster** (no spaces) as your project name
3.  Click **Create Project!**

![](/media/2021-03-img_604c33592c440.png)

Your project should now be open in Glue:

![](/media/2021-03-img_604c33a969fb2.png)

The play button in Glue will launch our (empty) game.

![](/media/2021-03-img_604c33fbe290b.png)

## Run Glue Wizard

Next we'll run the Glue Wizard which will jumpstart the development process by adding common Screens, Entities, and other files to our project. To run the Glue Wizard, click the **Run Glue Wizard** button in the **Quick Actions** tab.

![](/media/2021-03-img_604cca6013255.png)

We will change a few of the default options.  Follow along with these images and make your options match.

![](/media/2021-03-img_604ccb4565272.png)

Our game will not use **Tiled Map** files. **CloudCollision** is only used for platformer games.

![](/media/2021-03-img_604cd9b173eb9.png)

Our player will not use default control types like **Top-down** or **Platformer**. We will be implementing our own custom controls, so select the **None (controls will be added later)** option. Our player will rotate, so **Circle** collision is preferred to Rectangle collision. Also, our player is not a platformer character, so uncheck **Add Player vs. cloud collision**.

![](/media/2021-03-img_604ccbd094f2b.png)

Change **Number of levels to create** to **1**. Uncheck the other options since our game does not have any **Tiled Map** files.

![](/media/2021-03-img_604ccc08b53ac.png)

Leave UI options unchanged. We will use Gum to display game HUD.

![](/media/2021-03-img_604ccc47ed09b.png)

Uncheck all **Camera** options. Our game will not have a Camera which moves.

![](/media/2021-03-img_604ccc6b0057b.png)

Click **Done**. Wait a moment and your project will be all set up.

![](/media/2021-03-img_604cccc45fcc2.png)

If we run our game now we will see our player which is a white circle.

![](/media/2021-03-img_604cda3d3d060.png)

## Conclusion

That was easy! You now have a project that we will use in the following tutorials. Next we will set up the skeleton (the general structure) of our game. [\<- 01. Introduction](/documentation/tutorials/rock-blaster/tutorials-introduction.md "Tutorials:Rock Blaster:Introduction") -- [03. Game Skeleton -\>](/documentation/tutorials/rock-blaster/tutorials-game-skeleton.md "Tutorials:Rock Blaster:Game Skeleton")
