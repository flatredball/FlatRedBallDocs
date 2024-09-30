# Scoring Hud Logic

### Introduction

Now that we have a visible HUD, we need to add logic to have it update when players score. This tutorial adds code to the ScoreHud to update the displayed text according to public properties which are set by GameScreen whenever a goal is scored.

### Adding Team Score Properties

First we'll be adding properties to the Hud object for the scores of each of the players. We could do this purely in code, but the FRB Editor provides a convenient way to set the score values to integers. We will be combining two FRB Editor features for this:

* Tunneling variables - Creating a variable in an entity which is tied to the variable of a contained object. In this case we'll be creating variables which are tied to each of the score Texts' DisplayText variable.
* Built-in casting of the variable type - although DisplayText is a string, we'll tell FRB that we intend to use it as an integer.

To do this:

1. Expand ScoreHud's Objects in the FRB Editor
2. Drag+drop the **Team1Score** onto the **Variables** item
3. Select **DisplayText** as the variable
4. Set the **Alternative Name** to **Score1**
5. Set the **Converted Type** to **int**
6. Click **OK**

<figure><img src="../../.gitbook/assets/2019-05-TunnelConvertedScoreBeefball.gif" alt=""><figcaption></figcaption></figure>

Repeat the steps above, but this time use Team2Score, and create a variable called "Score2".

### Updating the HUD

Now that the ScoreHud can react to score changes, the ReactToNewScore can be modified to update the HUD. To do this, modify the ReactToNewScore method in GameScreen as follows:

```csharp
private void ReactToNewScore()
{
    PlayerBall1.X = -180;
    PlayerBall1.Y = 0;
    PlayerBall1.Velocity = Microsoft.Xna.Framework.Vector3.Zero;
    PlayerBall1.Acceleration = Microsoft.Xna.Framework.Vector3.Zero;

    PlayerBall2.X = 180;
    PlayerBall2.Y = 0;
    PlayerBall2.Velocity = Microsoft.Xna.Framework.Vector3.Zero;
    PlayerBall2.Acceleration = Microsoft.Xna.Framework.Vector3.Zero;

    Puck1.X = 0;
    Puck1.Y = 0;
    Puck1.Velocity = Microsoft.Xna.Framework.Vector3.Zero;


    ScoreHud1.Score1 = player1Score;
    ScoreHud1.Score2 = player2Score;

}
```

If we run the game now we'll notice that scores start out at 0 and increments whenever a player scores a goal.

#### Troubleshooting

If you are seeing a conversion error similar to Cannot implicitly convert type 'int' to 'string' , then you may need to modify the variables for Score1 and Score2. See the steps above where the **Variable Type** is set to **int.** If you've already created the variables, you can set the variable conversion:

1. Select the **Score1** variable
2. Select the **Properties** tab
3.  Change **OverridingPropertyType** to **int**

    ![](../../.gitbook/assets/2018-08-img\_5b7db0c6336f4.png)

### Conclusion

Well, that was easy! Now we have scoring working. At this point we could call the game done. The next tutorial adds some extra finishing touches to the controls to make it more competitive and make the game play deeper.
