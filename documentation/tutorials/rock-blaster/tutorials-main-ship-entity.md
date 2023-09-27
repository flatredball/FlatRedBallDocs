## Introduction

So far we've done a lot of work on our project, but the only visual thing in our game is a white circle. This tutorial will focus on the Player - the Entity which will be directly controlled by our input devices.

## How much to define?

Before we start working on our Player entity, keep in mind that entities do not have to be fully-defined all at once. If you are familiar with the genre you that you are creating a game for, or if you have very detailed plans about what you are creating, then you may be able to define your Entities very thoroughly the very first time you work with them. However, if you still have some questions in your head about how the game will play or how objects will behave (this is very common, so don't feel bad if you do) then you may implement some of your Entity before you play the game and possibly move on to a different area of the game. This tutorial will take an iterative approach to defining Entities, as this is more common in real game development. This means we will define some of the Player Entity now, and we'll return to add more in later tutorials.

## The art

As mentioned in the introduction to this set of tutorials, this game will be built using art from Tyrian as [provided by Dan Cook](http://www.lostgarden.com/2007/04/free-game-graphics-tyrian-ships-and.html). For simplicity these tutorials will provide a subset of the Tyrian art. Modifications have been made only to remove unused parts of various images, to add transparency, and to separate images into separate files for convenience. Otherwise all art is in its original state. If you finish this tutorial and would like to continue developing this game, visit [http://www.lostgarden.com/2007/04/free-game-graphics-tyrian-ships-and.html](http://www.lostgarden.com/2007/04/free-game-graphics-tyrian-ships-and.html) for the full set of Tyrian art. For the ship, save the following four files to any location on your computer - remember where you save them as you will need to be able to find them: ![MainShip1.png](/media/migrated_media-MainShip1.png) ![MainShip2.png](/media/migrated_media-MainShip2.png) ![MainShip3.png](/media/migrated_media-MainShip3.png) ![MainShip4.png](/media/migrated_media-MainShip4.png) We will use four files to support up to four players at the same time.  

## Adding existing files to Glue

Next we will add these four ship files to the Player entity. To do this:

1.  Expand the **Player** Entity in Glue
2.  Drag+drop the four files onto the **Files** folder in your entity

[![](/wp-content/uploads/2016/01/2021_March_13_104407.gif.md)](/wp-content/uploads/2016/01/2021_March_13_104407.gif.md) You should now see the files as part of your Player Entity.  

**Where are my files located?** If you saved the .png files in the project's Content folder, then Glue will reference the .png files from their current location. If you saved the files outside of this folder, then Glue will copy them into a folder specific to the Player Entity. If you ever need to find the files, you can right-click on the files in Glue and select **View in explorer.**

![](/media/2021-03-img_604cf326b7de3.png)

## Adding a Sprite to your Entity

Now that we have four images in our game, we need a Sprite to display them. To add a Sprite to your Player Entity:

1.  Select the **Player** entity

2.  Select the **Quick Actions** tab

3.  Click ****Add Object to Player****

    ![](/media/2021-03-img_604cf51797b87.png)

4.  Select the **Sprite** option

5.  Click **OK**

![](/media/2021-03-img_604cf5df639ac.png)

Our Player contains multiple files, so we need to tell the Sprite which Texture (.png) to use. To do this:

1.  Select the newly-created **SpriteInstance** under the **Player** entity
2.  Select the **Variables** tab
3.  Use the **Texture** drop-down to select **MainShip1**

![](/media/2021-03-img_604cf69a4fe5f.png)

If we run the game now, we will see our ship displaying the MainShip1 Texture on its Sprite.

![](/media/2021-03-img_604cf6d4c6dec.png)

## 

## Conclusion

At this point our Player instance in GameScreen is using a Sprite defined in Glue. However, nothing is happening in our game so far. The next tutorial will add some simple behavior to our Player Entity. [\<- 03. Game Skeleton](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-game-skeleton.md "Tutorials:Rock Blaster:Game Skeleton") -- [05. Player Behavior -\>](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-main-ship-behavior.md "Tutorials:Rock Blaster:Main Ship Behavior")
