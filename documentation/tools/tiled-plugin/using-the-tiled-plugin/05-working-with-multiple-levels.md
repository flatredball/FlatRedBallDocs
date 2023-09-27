## Introduction

Many tile-based games include multiple levels. This walk-through shows how to set up a multi-level game.

## Review of Screens

So far our game has two screens:

1.  GameScreen - the base screen for our levels. It contains all common files, objects, and code
2.  Level1 - our first level. It contains files, objects, and code specific to level 1.

Adding additional levels is very easy in the FRB editor. We'll add a second level on this tutorial.

## Adding Level2 Screen

To add a new level we will create a new screen. These steps are the same as what we did before when we added Level 1:

1.  Select the **Quick Actions** tab
2.  Click the **Add Screen/Level** option
3.  Enter the name **Level2**
4.  Uncheck the option to **Copy Entities From Other Level**. Note, if you want to use Level1 as a copy, you can keep this checked.
5.  Check the **Add Standard TMX File** checkbox to add a TMX for the new level. Note, if you want to use Level1 as a copy, you can select to **Copy TMX from Other Level**
6.  Click **OK**
7.  On the New File window, enter the name **Level2Map** and leave the defaults checked
8.  Click **OK**

[![](/wp-content/uploads/2016/08/11_08-56-58.gif)](/wp-content/uploads/2016/08/11_08-56-58.gif) Now our game has two levels: Level1 and Level2. We can choose which level we want to play by using the drop-down next to the Play button in Glue. [![](/wp-content/uploads/2016/08/2021_February_20_132044.gif)](/wp-content/uploads/2016/08/2021_February_20_132044.gif) If we play Level2, we will have an empty level since we haven't added any tiles yet. We can edit Level2Map by selecting it in the Tiled dropdown.

![](/media/2021-02-img_603174ef881fe.png)

Level2Map already has the TiledIcons referenced, and it already has a GameplayLayer, so we can begin placing tiles immediately.

![](/media/2021-02-img_60317559d4c13.png)

As always, don't forget to save your work or the map won't appear in game. The tiles should appear in your game, along with the collision for the tiles. [![](/wp-content/uploads/2016/08/2021_February_20_134848.gif)](/wp-content/uploads/2016/08/2021_February_20_134848.gif)

## Levels and Inheritance

FlatRedBall follows an inheritance pattern for levels. the GameScreen serves as the *base screen* for all levels. This means that the GameScreen contains everything that is common to all levels. This not only includes objects (such as lists of entities) but also relationships and settings on objects. For example, the GameScreen defines a Map object which creates entities from the maps (which is covered in later tutorials). If you choose to create Screens which do not inherit, you will have to manually reconfigure some of these settings. This is not recommended for new FlatRedBall users. Readers who are more interested in how TMX Files are loaded can read the [LayeredTileMap page](/documentation/tools/tiled-plugin/flatredball-tilegraphics-layeredtilemap.md).

## Switching Levels

We can switch between levels by switching between the screens for each level. In an actual game switching between levels may happen if a user collides with an object (such as a door) or if all enemies have been killed. For the sake of simplicity we'll switch between levels whenever the space bar is pressed. Note that the logic for switching between levels can be customized per-level, but we'll be using nearly identical code for both. We can switch from Level2 to Level1 by modifying Level2's CustomActivity :

``` lang:c#
void CustomActivity(bool firstTimeCalled)
{
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        MoveToScreen(typeof(Level1));
    }
}
```

Similarly, we can modify Level1's CustomActivity to go back to Level2 whenever the space bar is pressed again:

``` lang:c#
void CustomActivity(bool firstTimeCalled)
{
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        MoveToScreen(typeof(Level2));
    }
}
```

Now we can run the game and press the space bar to switch between levels. [![](/wp-content/uploads/2016/08/2021_February_20_134150.gif)](/wp-content/uploads/2016/08/2021_February_20_134150.gif)
