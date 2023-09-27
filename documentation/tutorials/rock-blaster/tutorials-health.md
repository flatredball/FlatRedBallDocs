## Introduction

Currently our game is playable, but lacks a lot of polish and fun factor needed for a final game. As you may have noticed, if the player ship collides with a rock then the ship is destroyed and the game is over. We'll make the game a little more forgiving by providing a health bar so that the player can survive multiple hits.

## Defining the HealthBar Component in Gum

Previously we added a score Text object in Gum. This Text object existed in *screen space* - it was positioned relative to the top-left corner of our screen. Health bars will be different - they will be positioned relative to the Player instance. To create a HealthBar Component in Gum:

1.  Open Gum

2.  Right-click on the **Components** folder and select ****Add Component****

    ![](/media/2021-03-img_604d883db3d10.png)

3.  Enter the name HealthBar and click OK

## Creating HealthBar Visuals

First we'll adjust main component values to be sized properly and to be positioned according to its center. Set the following values:

-   XOrigin = Center
-   YOrigin = Center
-   Width = 48
-   Height = 12

![](/media/2021-03-img_604d8b4084d1a.png)

Next we'll add a background ColoredRectangle:

1.  Expand the Standard folder in Gum
2.  Drag+drop a **ColoredRectangle** on the **HealthBar** component
3.  Set the ColoredRectangle **Name** to **Background**
4.  Click the **Alignment** tab
5.  Click the **Center Dock** button to have the colored rectangle fill the component

[![](/wp-content/uploads/2016/01/2021_March_13_212209.gif.md)](/wp-content/uploads/2016/01/2021_March_13_212209.gif.md) This ColoredRectangle will be the background of our HealthBar which will display if the player takes damage, so we will change its color to red.

![](/media/2021-03-img_604d8d29a6a1b.png)

Repeat the steps above, except this time:

-   Set the name to Foreground
-   Set the color to a light green color

![](/media/2021-03-img_604d8da489655.png)

## Creating a Percent Variable

Our HealthBar is almost ready to be used except it doesn't have an easy way to display health percentage. First, we'll modify the Foreground object to use a percentage width:

1.  Select Foreground
2.  Change **X Units** to **Pixels From Left**
3.  Change **X Origin** to **Left**
4.  Change **Width** to **100**
5.  Change its **Width Unit** to **Percentage of Container**

![](/media/2021-03-img_604d8fb05b5ef.png)

Now the Foreground can have its width changed, and the green bar will show the appropriate percent. [![](/wp-content/uploads/2016/01/2021_March_13_213724.gif.md)](/wp-content/uploads/2016/01/2021_March_13_213724.gif.md) We want to expose this variable so that it can be accessed on the HealthBar itself:

1.  Right-click on the Foreground Width property
2.  Select **Expose Variable**
3.  Enter the name **PercentFull**

[![](/wp-content/uploads/2016/01/2021_March_13_211926.gif.md)](/wp-content/uploads/2016/01/2021_March_13_211926.gif.md)

## Adding HealthBars to the Player

Entities can contain instances of Gum objects. We will add a HealthBar to our Player, just like we added a Sprite earlier:

1.  Select the **Player** object in Glue
2.  Click the **Quick Actions** tab
3.  Click **Add Object to Player**
4.  Click the Gum object type
5.  Select the **HealthBarRuntime** option. Note that this is the same name as the **HealthBar** Component in Gum with the word "Runtime" at the end.
6.  Click **OK**

![](/media/2022-12-img_63a84de9a55de.png)

If we run the game now, we'll see the HealthBar on top of the Player. [![](/wp-content/uploads/2016/01/2021_March_13_214537.gif.md)](/wp-content/uploads/2016/01/2021_March_13_214537.gif.md) First we'll adjust the Y value of the HealthBar so that it doesn't overlap the ship.

1.  Select the HealthBar component in Gum
2.  Change Y to -28. By default, negative Y moves an object up in Gum.

![](/media/2021-03-img_604d93d39b18b.png)

Next we'll adjust the HealthBar so it doesn't rotate with the ship. At the time of this writing, this cannot be done through Gum, so it must be done in code. To do this:

1.  Open Player.cs in Visual Studio
2.  Add the following lines to CustomInitialize:

&nbsp;

    var hudParent = gumAttachmentWrappers[0];
    hudParent.ParentRotationChangesRotation = false;

Now the HealthBar appears above the player and does not rotate with the player. [![](/wp-content/uploads/2016/01/2021_March_13_220225.gif.md)](/wp-content/uploads/2016/01/2021_March_13_220225.gif.md)

## Conclusion

Now we have our HealthBars in game and ready to be used. The next tutorial will hook up the logic to display the player's health and will modify the collision code so the player takes damage when hitting rocks. [\<- 10. Multiple Players](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-multiple-players.md "Tutorials:Rock Blaster:Multiple Players") -- [12. Health Part 2 -\>](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-health-part-2.md "Tutorials:Rock Blaster:Health Part 2")
