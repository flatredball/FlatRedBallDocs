# Player Entity

### Introduction

So far we've done a lot of work on our project, but the only visual thing in our game is a white circle. This tutorial focuses on the Player - the Entity which is directly controlled by our input devices.

### How much to define?

Before we start working on our Player entity, keep in mind that entities do not have to be fully-defined all at once. If you are familiar with the genre you that you are creating a game for, or if you have very detailed plans about what you are creating, then you may be able to define your Entities very thoroughly the very first time you work with them. However, if you still have some questions in your head about how the game will play or how objects will behave (this is very common, so don't feel bad if you do) then you may implement some of your Entity before you play the game and possibly move on to a different area of the game.

This tutorial takes an iterative approach to defining Entities, as this is more common in real game development. This means we will define some of the Player Entity now, and we'll return to add more in later tutorials.

### The art

As mentioned in the introduction to this set of tutorials, this game will be built using art from Tyrian as [provided by Dan Cook](http://www.lostgarden.com/2007/04/free-game-graphics-tyrian-ships-and.html). For simplicity these tutorials provide a subset of the Tyrian art. Modifications have been made only to remove unused parts of various images, to add transparency, and to separate images into separate files for convenience. Otherwise all art is in its original state. If you finish this tutorial and would like to continue developing this game, visit [https://lostgarden.com/2007/04/05/free-game-graphics-tyrian-ships-and-tiles/](https://lostgarden.com/2007/04/05/free-game-graphics-tyrian-ships-and-tiles/) for the full set of Tyrian art.

For the ship, save the following four files to any location on your computer - remember where you save them as you will need to be able to find them:&#x20;

![MainShip1.png](../../.gitbook/assets/migrated\_media-MainShip1.png) ![MainShip2.png](../../.gitbook/assets/migrated\_media-MainShip2.png) ![MainShip3.png](../../.gitbook/assets/migrated\_media-MainShip3.png) ![MainShip4.png](../../.gitbook/assets/migrated\_media-MainShip4.png)&#x20;

We will use four files to support up to four players at the same time. Note that we are using four separate images, one for each player. Games often combine images into a single file which is called a sprite sheet. FlatRedBall supports working with individual files and sprite sheets.

### Adding existing files to Your Project

Next we will add these four ship files to the Player entity. To do this:

1. Expand the **Player** Entity in FRB
2. Drag+drop the four files onto the **Files** folder in your entity

<figure><img src="../../.gitbook/assets/30_06 33 39.gif" alt=""><figcaption><p>Drag+drop files to add them to your project</p></figcaption></figure>

You should now see the files as part of your Player Entity.

**Where are my files located?** If you saved the .png files in the project's Content folder, then FlatRedBall references the .png files from the same location. If you saved the files outside of this folder (such as the Desktop or Downloads folder), then FRB copies them into a folder specific to the Player Entity. If you ever need to find the files, you can right-click on the files in and select **View in explorer.**

![Right-click option to view the file location on disk](<../../.gitbook/assets/30\_06 35 11.png>)

### Setting the Sprite Texture

When we created our project using the wizard, we kept the option selected to add a Sprite to the Player Entity. We can see that this exists by expanding the Objects folder:

![SpriteInstance in Player](<../../.gitbook/assets/30\_06 38 22.png>)

Our Player contains multiple files, so we need to tell the Sprite which Texture (.png) to use. To do this:

1. Select the newly-created **SpriteInstance** under the **Player** entity
2. Select the **Variables** tab
3. Use the **Texture** drop-down to select **MainShip1** (or whatever you named your PNG when you saved it earlier)

![Set the SpriteInstance Texture](<../../.gitbook/assets/30\_06 40 23.png>)

If we run the game now, we will see our ship displaying the MainShip1 Texture on its Sprite.

![Player showing MainShip1 Texture](../../.gitbook/assets/2021-03-img\_604cf6d4c6dec.png)



### Conclusion

At this point our Player instance in GameScreen is using a Sprite defined in Glue. However, nothing is happening in our game so far. The next tutorial will add some simple behavior to our Player Entity.&#x20;
