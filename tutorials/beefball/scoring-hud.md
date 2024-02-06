# Scoring Hud

### Introduction

This tutorial covers creating a HUD object which displays the scores of each player.

### Creating a ScoreHud Entity

First we'll create an Entity to store all of our scoring information. We could place all of our HUD objects directly in the Screen, but this approach can result in a large number of objects in the GameScreen, making it difficult to maintain. We'll create a "Hud" entity to keep all HUD objects organized. To do this:

1. Select the **Quick Actions** tab
2. Click the **Add Entity** button
3. Enter the name **ScoreHud**
4. Click **OK**

![](../../media/2021-07-img\_60fdd1776370c.png)

### Creating the ScoreHud Text objects

For the ScoreHud we'll define the Text objects in Glue (just like we defined the body of the Puck in Glue). To do this:

1. Select **ScoreHud**
2. Select the **Quick Actions** tab
3. Click the **Add Object to ScoreHud**
4. Select **Text** as the type
5. Enter the name **Team1Score**
6.  Click **OK**

    ![](../../media/2021-07-img\_60fdd21643893.png)
7. Repeat the steps above to create another Text object called Team2Score
8. Repeat the steps above to create another Text object called Team1ScoreLabel
9. Repeat the steps above to create another Text object called Team2ScoreLabel

You should now have 4 Text objects:

![](../../media/2021-07-img\_60fdd24f94751.png)

Now we'll change the following variables on the Text objects in Glue. Select the following Text objects and set the variables as defined below: **Team1Score**

* DisplayText = "99"
* X = -150
* Y = 270

**Team2Score**

* DisplayText = "99"
* X = 180
* Y = 270

**Team1ScoreLabel**

* DisplayText = "Team 1:"
* X = -205
* Y = 270

**Team2ScoreLabel**

* DisplayText = "Team 2:"
* X = 124
* Y = 270

To add the ScoreHud to the GameScreen:

1. Select the ScoreHud
2. Select the Quick Actions tab
3. Click the **Add ScoreHud Instance to GameScreen** button

![](../../media/2021-07-img\_60fdd305ee7ac.png)

You should now see everything showing up correctly in your game

![Screenshot of in-progress BeefBall game showing player one and player two score HUD at the top.](../../media/2021-05-img\_609de61e7870f.png)

### Conclusion

Now we have a score HUD that shows up when the game plays, but it doesn't react to scored goals. The next tutorial adds the necessary logic to have it react to scored goals.
