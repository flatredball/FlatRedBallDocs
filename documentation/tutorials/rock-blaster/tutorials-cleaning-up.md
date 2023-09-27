## Introduction

If you've made it this far through the RockBlaster tutorials, congratulations! We've covered a lot of topics in Glue and FlatRedBall. This last tutorial will clean up the game. All games require some polish and clean up before being finished. Normally this phase of game development takes a lot longer and covers far more than this tutorial, but we'll keep it short to focus on Glue and FlatRedBall features.

## Making Circles invisible

All entities with collision currently draw their circles. This is useful for understanding how large the collision area is and to identify bugs, but we need to turn off the shapes before marking the game as finished. To do this:

1.  In Glue, expand the **Bullet** Entity
2.  Expand the **Objects** item under Bullet
3.  Select **CircleInstance**
4.  Select the **Variables** tab
5.  Uncheck the **Visible** property

![](/media/2021-03-img_604e24ad82366.png)

Repeat this process for:

1.  **CircleInstance** in **Player**
2.  **CircleInstance** in **Rock**

Now our game looks much better without the white circles:

![](/media/2021-03-img_604e2525536e5.png)

## Creating the End Game UI

If the user dies currently the game simply sits there and doesn't let the player know what's going on. We can add an end-game UI in Gum to announce that the game has ended.

1.  Open Gum

2.  Drag+drop a **Text** object from the Standards folder onto **GameScreenGum [![](/wp-content/uploads/2016/01/2021_March_14_093302.gif)](/wp-content/uploads/2016/01/2021_March_14_093302.gif)**

3.  Rename the **Text** to **GameOverAnnouncement**

4.  Change the Text property on **GameOverAnnouncement** to **Game Over**. You may need to press the TAB key to apply the changes to the Text property. Pressing the Enter key results in a newline being added to the Text.

    ![](/media/2021-03-img_604e2624d45ef.png)

5.  Click the **Alignment** tab and then click the **Center Anchor** button

    ![](/media/2021-03-img_604e26746797a.png)

6.  Now that we've adjusted the position, we can set GameOverAnnouncement to be invisible by unchecking the Visible property under the Variables tab.

    ![](/media/2021-03-img_604e26f283407.png)

## Adding GameOverAnnouncement to GameScreen in Glue

Just like with the score hud, we will access the GameOverAnnouncement in Glue:

1.  Expand **GameScreen** in Glue
2.  Expand the **Files** folder
3.  Drag+drop **GameScreenGum** onto the **Objects** folder
4.  Use the drop-down to select **GameOverAnnouncement**
5.  Click **OK**

[![](/wp-content/uploads/2016/01/2021_March_14_090510.gif)](/wp-content/uploads/2016/01/2021_March_14_090510.gif)

## Detecting GameOver

Next we'll want to detect if the game is over and show the hud if so. To do this:

1.  Open GameScreen.cs in Visual Studio
2.  Add the following to the CustomActivity in GameScreen.cs:

&nbsp;

    EndGameActivity();

Next we'll want to implement EndGameActivity. To do this:

1.  Add the following code to GameScreen.cs in the GameScreen class:

&nbsp;

    void EndGameActivity()
    {
        // If the list has 0 ships, then all have been killed
        if (GameOverAnnouncement.Visible == false && this.Player.Count == 0)
        {
            GameOverAnnouncement.Visible = true;
        }
    }

Now the GameOver will appear after all ships have died. If you have increased the ship's health you will want to reduce it back to a reasonable number (like 6). This is important for the final state of the game as well as it will help you test the end game logic quicker. ![GameOverDisplaying.png](/media/migrated_media-GameOverDisplaying.png)

## Removing Debugger output

Not that we have the accumulation fixed we will need to remove the debugger code. To do this, open Game1.cs and locate the calls to the FlatRedBall.Debug.Debugger and remove those lines.

## Conclusion

Way to go! You've just finished the RockBlaster tutorial series. We've covered a lot of features that are commonly used in FlatRedBall games. Of course there's always more you can do to a game, and now that you've come this far we encourage you to experiment with the game. Here's some things to try, some simple, and some more complex:

-   Modifying the way the bullets fire. Possible ideas include
    -   A machine-gun that fires rapidly when holding the fire button down
    -   Spread fire
    -   Bullets which use different graphics and do area damage when exploding
-   Make the rocks rotate randomly
-   Add borders to the edge of the level so the player can't leave the screen
-   Stop rock spawning when the game has ended
-   Add a background to the GameScreen
-   Allow the user to restart the level by pushing a button when the game ends
-   Create an Explosion entity that shows whenever Rocks or the Player are destroyed

There are endless possibilities. Good luck! [\<- 13. Destroying Entities](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-destroying-entities.md "Tutorials:Rock Blaster:Destroying Entities") -- [Back to Tutorials -\>](/documentation/tutorials.md "Category:FlatRedBall XNA Tutorials")
