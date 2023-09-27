## Introduction

Now that the game is somewhat playable - bullets destroy rocks and the player can lose, we need to add a scoring system and a score display. This tutorial introduces using Gum in a FlatRedBall project. Gum is a general-purpose UI tool which integrates tightly with FlatRedBall. In fact, if you used the Glue Wizard in the first tutorial, then you already have a Gum project in your game - it's just empty.

## Downloading Gum

Before we begin, you must have Gum downloaded on your machine. You can [download Gum here](/content/Tools/Gum/Gum.zip.md). For more information on Gum, see the [Gum website](http://gumui.net/). You will also want to set up the Gum tool association with the .gumx and .gusx files. For information on how to do that, see the [first Gum tutorial](/documentation/tools/gum/gum-tutorials/tutorials-gum-introduction-and-setup.md).

## Creating a Text Instance in Gum

The easiest way to open Gum is to click the Gum button in Glue.

![](/media/2021-03-img_604d7f8df22d4.png)

Gum should open (if you have the file associations set up properly). If you used the Glue Wizard in the first tutorial, you will also have a Gum screen set up for the GameScreen called GameScreenGum. Note that Glue will automatically create a Gum screen for every Glue screen.

![](/media/2021-03-img_604d80112bbec.png)

Gum follows many of the same concepts as Glue, but it is primarily a visual tool. The window on the right provides a [WYSIWYG editor](https://en.wikipedia.org/wiki/WYSIWYG), so creating visual layout is usually easier to do in Gum than in Glue. Gum also includes a list of *Standard* objects which can be used in your project with no setup. We will use a Text instance to display our score. To do this:

1.  Expand the Standard folder
2.  Drag+drop the Text object onto the GameScreenGum
3.  Adjust the position of the Text to its desired location in the Editor window

[![](/wp-content/uploads/2016/01/2021_March_13_200519.gif.md)](/wp-content/uploads/2016/01/2021_March_13_200519.gif.md)   That's all there is to it! Gum automatically saves all changes, and Glue (if open) automatically reacts to these file changes, so we can run the game and see the **Hello** TextInstance right away.

![](/media/2021-03-img_604d810fec276.png)

## Changing the TextInstance in Code

At this point our text object says "Hello". Instead, we'd like to display a player's score. To change the Text, we can get a reference to the TextInstance in code or in Glue. Both approaches have their benefits, but for simplicity we will access the TextInstance in Glue. For more information, see the [tutorial on accessing Gum objects](/documentation/tools/gum/gum-tutorials/tutorials-gum-gum-objects-in-code.md). The TextInstance is defined in the Gum screen, which has the file format .gusx. Our GameScreen already has the Gum screen added - this happened automatically when we used the wizard.

![](/media/2021-03-img_604d823aa3e8a.png)

To access the TextInstance which is inside GameScreenGum:

1.  Drag+drop the GameScreenGum onto the GameScreen's Objects folder
2.  Use the **Source Name** dropdown to select **TextInstance**
3.  Click **OK**

[![](/wp-content/uploads/2016/01/2021_March_13_200727.gif.md)](/wp-content/uploads/2016/01/2021_March_13_200727.gif.md) We can access the TextInstance in code and change any of its variables. For example, we can change the Text property in CustomActivity. As a test, open GameScreen.cs and add the following code in CustomActivity:

    void CustomActivity(bool firstTimeCalled)
    {
     TextInstance.Text = "Screen time: " + TimeManager.CurrentScreenTime;
    }

![](/media/2021-03-img_604d837571f15.png)

## Where to store player score

Now that the TextInstance can display a score, we need to actually keep track of the score so we can display it. We need to decide where to keep the score. As outlined in [this article](/frb/docs/index.php?title=Glue:Tutorials:Proper_Information_Access.md "Glue:Tutorials:Proper Information Access") information such as the player's score should not be tied to any Screen or Entity. Rather, it should be stored independently and globally as an object contained in GlobalData. We'll create two classes to store our data:

1.  PlayerData
2.  GlobalData

To add PlayerData to your game:

1.  Add a PlayerData class to the DataTypes folder (which should be part of your project automatically)

    ![](/media/2022-12-img_63a310d138ae3.png)

2.  Press CTRL+SHIFT+S in Visual Studio to save the project. This will notify Glue that the Project has changed, and that it needs to reload it.

3.  Modify PlayerData so the class looks like the following code snippet:

&nbsp;

    public class PlayerData
    {
        public int Score
        {
            get;
            set;
        }
    }

Next add GlobalData to your game:

1.  Add a GlobalData class in your Visual Studio project in the Data folder
2.  Press CTRL+SHIFT+S in Visual Studio to save the project.
3.  Modify GlobalData so the class looks as follows:

&nbsp;

    public static class GlobalData
    {
        public static PlayerData PlayerData
        {
            get;
            private set;
        } = new PlayerData();
    }

  Now we have a well-organized, globally accessible location for our score. For simplicity all players will share the same score, so we've only created one PlayerData in GlobalData.

## Updating the Score and Hud

Finally we need to update the Score in GlobalData as well as the Hud whenever a player destroys a rock. To keep things simple we'll award points whenever a rock is shot - whether it has actually been destroyed or whether it has been broken up into smaller pieces. To do this:

1.  Open GameScreen.Event.cs
2.  Find OnBulletListVsRockListCollisionOccurred
3.  Add the lines in the "new code" section so your code looks like:

&nbsp;

    void OnBulletListVsRockListCollisionOccurred (Entities.Bullet bullet, Entities.Rock rock)
    {
     bullet.Destroy();
     rock.TakeHit(); // <-----This line of code changed

     ////////////////////// new code ///////////////////////////////////////
     DataTypes.GlobalData.PlayerData.Score += second.PointValue; //
     this.TextInstance.Text = Data.GlobalData.PlayerData.Score.ToString();//
     ///////////////////////////////////////////////////////////////////////
    }

As Visual Studio will indicate, PointValue is a variable that has not yet been defined. We will need to add a PointValue variable to Rock. To do this:

1.  Select the **Rock** Entity in Glue
2.  Click the Variables tab
3.  Select **int** as the **Type**
4.  Enter the name **PointValue**
5.  Click OK
6.  Set the newly-created value to 10

![](/media/2021-03-img_604d851f8ac3c.png)

We can also change the starting TextInstance.Text value to 0 by adding the following code in GameScreen.cs in the CustomInitialize function:

    void CustomInitialize()
    {
     this.TextInstance.Text = "0";
    }

Also, don't forget to remove the temporary code we wrote earlier which set the textInstance.Text to the current screen time.

## Conclusion

![RockBlasterWithScore.png](/media/migrated_media-RockBlasterWithScore.png) Now the game includes a Score HUD that updates as the player progresses through the game. The next tutorial will add support for multiple players. [\<- 08. Rock States](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-rock-states.md "Tutorials:Rock Blaster:Rock States") -- [10. Multiple Players -\>](/documentation/tutorials/rock-blaster/tutorials-rock-blaster-multiple-players.md "Tutorials:Rock Blaster:Multiple Players")
