# adding-multiple-players

### Introduction

Beefball is intended to be a competitive multiplayer game. So far we only have one PlayerBall instance, so let's add some more PlayerBall instances. Previously we added a list for our PlayerBall. We can now add a second PlayerBall with minimal changes to our project.

###

### Adding a new PlayerBall

To add a new PlayerBall:

1. Expand the GameScreen's Objects folder
2. Select the PlayerBallList object
3. Select the **Quick Actions** tab
4. Click the **Add a new PlayerBall to PlayerBall List**. Alternatively, you can right-click on the PlayerBallList and select Add Object [![](../../../media/2016-01-2021\_July\_25\_145416.gif)](../../../media/2016-01-2021\_July\_25\_145416.gif)
5.  Change the new PlayerBall's X value to 180

    ![](../../../media/2021-07-img\_60fdc6f8e4b71.png)

You should now see two PlayerBall instances under the PlayerBallList and in game. Also, since we created our collision relationships between the lists, the new PlayerBall can already collide against the walls and the Puck. [![](../../../media/2016-01-2021\_July\_25\_145219.gif)](../../../media/2016-01-2021\_July\_25\_145219.gif) &#x20;

### Player vs. Player collision

Now that we have two PlayerBall instances, we need to add a new collision relationship. This time, we will create a collision relationship between the PlayerBallList vs itself. To do this:

1. Select the **PlayerBallList**
2. Select the **Collision** tab
3. Find the **PlayerBallList** in the list of items
4. Click the **Add** button
5. Set **Collision Physics** to **Bounce**

[![](../../../media/2016-01-2021\_July\_25\_143723.gif)](../../../media/2016-01-2021\_July\_25\_143723.gif)   If you run you game now, the two PlayerBall instances will collide against each other. Also, if we added more players (a third or fourth player) those would also collide with each other automatically.

### Adding input for Player 2

We'll assign input on PlayerBall2Instance with code similar to the input-assigning code for PlayerBallInstance. To do this, open **GameScreen.cs** and modify AssignInput as shown in the following code:

```
private void AssignInput()
{
    if (InputManager.Xbox360GamePads[0].IsConnected)
    {
        PlayerBallInstance.MovementInput =
            InputManager.Xbox360GamePads[0].LeftStick;
        PlayerBallInstance.BoostInput =
            InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.A);
    }
    else
    {
        PlayerBallInstance.MovementInput =
            InputManager.Keyboard.Get2DInput(Microsoft.Xna.Framework.Input.Keys.A,
            Microsoft.Xna.Framework.Input.Keys.D,
            Microsoft.Xna.Framework.Input.Keys.W,
            Microsoft.Xna.Framework.Input.Keys.S);
        PlayerBallInstance.BoostInput =
            InputManager.Keyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.B);
    }

    if (InputManager.Xbox360GamePads[1].IsConnected)
    {
        PlayerBallInstance2.MovementInput =
            InputManager.Xbox360GamePads[1].LeftStick;
        PlayerBallInstance2.BoostInput =
            InputManager.Xbox360GamePads[1].GetButton(Xbox360GamePad.Button.A);
    }
    else
    {
        PlayerBallInstance2.MovementInput =
            InputManager.Keyboard.Get2DInput(Microsoft.Xna.Framework.Input.Keys.Left,
            Microsoft.Xna.Framework.Input.Keys.Right,
            Microsoft.Xna.Framework.Input.Keys.Up,
            Microsoft.Xna.Framework.Input.Keys.Down);
        PlayerBallInstance2.BoostInput = 
            InputManager.Keyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.RightShift);
    }
}
```

Now each PlayerBall uses a different Xbox360GamePad or set of keys.

### Conclusion

Now that we have multiple PlayerBall instances, we have a game that is playable, but it's missing scoring and game rules. The next tutorial will add in the ability to score goals. [<- Creating the Puck Entity](creating-the-puck-entity.md) -- [Scoring and Restarting Rounds ->](scoring-and-restarting-rounds.md)
