## Introduction

At this point Beefball is a fully-playable game, but we'll be adding one final feature: dashing. This provides deeper gameplay that rewards skill and adds an element of anticipation and excitement.

## Adding Dashing

A dash will give the player a burst of speed in the current direction that the player is pointing. The dash can be used to hit other players, shoot the puck, or dive in front of the puck to block a goal. To add a dash, modify **CustomActivity** in **PlayerBall.cs** as follows:

    private void CustomActivity()
    {
        MovementActivity();

        DashActivity();
    }

Next, implement DashActivity in **PlayerBall.cs**:

    private void DashActivity()
    {
        if (BoostInput?.WasJustPressed == true)
        {
            float magnitude = MovementInput?.Magnitude ?? 0;

            bool isHoldingDirection = magnitude > 0;

            if (isHoldingDirection)
            {
                // dividing by magnitude tells us what X and Y would
                // be if the user were holding the input all the way in
                // the current direction.
                float normalizedX = MovementInput.X / magnitude;
                float normalizedY = MovementInput.Y / magnitude;

                XVelocity = normalizedX * DashSpeed;
                YVelocity = normalizedY * DashSpeed;
            }
        }
    }

If you try to build your game, you'll notice that the variable DashSpeed is undefined. This is a variable that should be defined in the FRB Editor so that it can be tuned easily:

1.  Click on **PlayerBall**
2.  Select the **Variables** tab
3.  Click the **Add New Variable** button
4.  Verify that **float** is selected
5.  Enter the name **DashSpeed**
6.  Click **OK**
7.  Enter a value of **600** for **DashSpeed**

[![](/wp-content/uploads/2016/01/2021_July_25_152616.gif.md)](/wp-content/uploads/2016/01/2021_July_25_152616.gif.md) Your game should build and dashing should be fully functional.

## Limiting Dash Frequency

Currently the player can dash indefinitely. We'll modify the dash so it has a cool-down after it's used. We'll need a variable to keep track of when the dash was first used, and compare against that variable to check if the user can dash again. First, add the following variables to your **PlayerBall.cs at class scope (make it a field)**:

    // Set a large negative number so that dashing can happen immediately
    private double lastTimeDashed = -1000;

Next, add a check for the last dash time and a set to lastDashTime in **DashActivity in PlayerBall.cs**. Your entire method should look like:

    private void DashActivity()
    {
        float magnitude = MovementInput?.Magnitude ?? 0;

        bool shouldBoost = BoostInput?.WasJustPressed == true &&
            TimeManager.CurrentScreenSecondsSince(lastTimeDashed) > DashFrequency &&
            magnitude > 0;

        if (shouldBoost)
        {
            lastTimeDashed = TimeManager.CurrentScreenTime;

            // dividing by magnitude tells us what X and Y would
            // be if the user were holding the input all the way in
            // the current direction.
            float normalizedX = MovementInput.X / magnitude;
            float normalizedY = MovementInput.Y / magnitude;

            XVelocity = normalizedX * DashSpeed;
            YVelocity = normalizedY * DashSpeed;
        }
    }

Just like before, we need to create a DashFrequency variable in the FRB Editor:

1.  Click on **PlayerBall**
2.  Select the **Variables** tab
3.  Click the **Add New Variable** button
4.  Verify that **float** is selected
5.  Enter the name **DashFrequency**
6.  Click **OK**
7.  Enter a value of **2 **for **DashFrequency **to indicate a 2 second frequency

![](/media/2021-07-img_60fdd587a661f.png)

Now the player will only be able to dash once every two seconds.

**Why did we create DashFrequency and DashSpeed variables in the FRB Editor, but lastTimeDashed in Visual Studio? **You may have noticed that we defined some of our variables (like DashFrequency and DashSpeed) in the FRB Editor, but we defined lastTimeDashed in Visual Studio. When working in the FRB Editor it is important to distinguish between "data" and "logic". Variables considered data are created in the FRB Editor so that they can be easily modified. Game development is an iterative process, and even the most experienced game designers will make changes to their game throughout development. Creating variables in the FRB Editor makes changing variables easy, and communicates to other developers that these variables should be tuned. The lastTimeDashed variable, on the other hand, exists solely to support the logic of limiting dashing. The actual value of lastTimeDashed will change many times as the game executes, and setting it through the FRB Editor will either have no impact on the game or introduce an unintended bug of making dash not work (if the value is set to a large positive value).

## Adding a Cooldown Indicator

Now that the player's dashing is limited, we need to add some visible indication of when another dash can occur. We'll do this by adding a second Circle to the PlayerBall which will grow when the user has dashed, then disappear when the user can dash again. To do this:

1.  Click on **PlayerBall**
2.  Select the **Quick Actions** tab
3.  Click **Add Object to PlayerBall**
4.  Select **Circle**
5.  Enter the name **CooldownCircle**

![](/media/2021-07-img_60fdd66d44b61.png)

## Defining States

Next we'll use States (something we haven't used yet) to define what the PlayerBall should look like when the cooldown first begins and when the cooldown ends. States have the following benefits:

1.  They let you "code against concept, not content". In other words, you can define a state and use it in code, and later make changes to the state without having to modify any code. This is desirable because when you set the PlayerBall to a "Tired" state, your code shouldn't depend on anything except for the presence of a Tired state. Code should simply set the state to Tired, while the logic of Tired should be handled elsewhere.
2.  States can interpolate from one to the other. In this case, we'll have the "Tired" state set the CooldownCircle to have a small radius, and the "Rested" will have a large circle. The end result is the CooldownCircle will "grow".

All states must be categorized, so the first step is to create a new category:

1.  Right-click on the States item under PlayerBall and select ****Add State Category****

    ![](/media/2022-01-img_61d31c434473b.png)

2.  Name the category **DashCategory** and click ****OK****

    ![](/media/2022-01-img_61d31c76a0789.png)

Now the PlayerBall has a category named DashCategory.

![](/media/2022-01-img_61d31c922a1c1.png)

Next we'll add states to the category:

1.  Right-click on **DashCategory**

2.  Select ****Add State****

    ![](/media/2022-01-img_61d31cb2b4f4f.png)

3.  Enter the name **Tired** and click ****OK****

    ![](/media/2022-01-img_61d31cd31f224.png)

4.  Repeat the above steps to create a "Rested" state as well

As mentioned above, we'll want the CooldownCircle ball to grow (increase its Radius) to give the player an indication of how much time is left in the cooldown. To do this, we'll need to tunnel in to the CooldownCircle's Radius property:

1.  Drag+drop the **CooldownCircle** object onto the **Variables** item
2.  Select **Radius** for the Variable
3.  Click **OK [![](/wp-content/uploads/2016/01/2021_July_25_154225.gif.md)](/wp-content/uploads/2016/01/2021_July_25_154225.gif.md)**

Categories must be told which variables to modify. By default, categories do not modify any variables.

![](/media/2022-01-img_61d31d6a8c5dc.png)

To add a variable to a state, drag+drop the variable onto the category: [![](/wp-content/uploads/2016/01/03_09-01-31.gif.md)](/wp-content/uploads/2016/01/03_09-01-31.gif.md) In this case, the only variable is the CooldownCircleRadius. Next let's define the two states:

1.  Change Tired **CooldownCircleRadius** to 0.
2.  Change Rested **CooldownCircleRadius** to **16**. This should match the default radius for Body.

[![](/wp-content/uploads/2016/01/03_09-02-56.gif.md)](/wp-content/uploads/2016/01/03_09-02-56.gif.md)

## Using States in code

Now that our states are defined, let's use them in code. The simplest way to use states is to assign an entity's current state variable. FlatRedBall also provides functions for *interpolating* between states, which is the process of gradually changing from one state to another. We will write code to set the state to "Tired", then interpolate to rested over the course of two seconds - of course we'll use DashFrequency rather than hard-coding the value *2*. To use these newly-created states, go to **PlayerBall.cs** and modify the **DashActivity** function as follows: To use the states, add the following two lines of code inside the if-statement in DashActivity in PlayerBall.cs:

    private void DashActivity()
    {

        float magnitude = MovementInput?.Magnitude ?? 0;

        bool shouldBoost = BoostInput?.WasJustPressed == true &&
            TimeManager.CurrentScreenSecondsSince(lastTimeDashed) > DashFrequency &&
            magnitude > 0;

        if (shouldBoost)
        {
            lastTimeDashed = TimeManager.CurrentScreenTime;

            // dividing by magnitude tells us what X and Y would
            // be if the user were holding the input all the way in
            // the current direction.
            float normalizedX = MovementInput.X / magnitude;
            float normalizedY = MovementInput.Y / magnitude;

            XVelocity = normalizedX * DashSpeed;
            YVelocity = normalizedY * DashSpeed;

            CurrentDashCategoryState = DashCategory.Tired;
            InterpolateToState(DashCategory.Rested, DashFrequency);
        }
    }

[![](/wp-content/uploads/2016/01/2021_July_25_154528.gif.md)](/wp-content/uploads/2016/01/2021_July_25_154528.gif.md)

## Changing Player Colors

Lets change the color of the PlayerBall to help tell the two players apart. We will "tunnel" to the Body's Color so that it can be changed per player instance.

1.  In FlatRedBall, expand the **PlayerBall** entity
2.  Drag+drop the **CircleInstance** object onto the **Variables** folder
3.  Select **Color** as the variable.
4.  Click **OK**
5.  Repeat for the **CooldownCircle**'s Color

Now that the color variables is exposed, lets change one circle in GameScreen

1.  In GameScreen, choose PlayerBallInstance2
2.  Change both CircleInstanceColor and CooldownCircleColor custom variables to Cyan, or the color of your choosing.
3.  Run the game!

![Screenshot of BeefBall game showing player 1 in white on left, player 2 in cyan on right, and the puck in red in the middle.](/media/2021-05-img_60a440858f9f1.png)

You can now tell the difference between each player.

## You just made a game!

If you've read this far, then you have officially just finished your first FlatRedBall game. Way to go! At this point, you can continue reading other tutorials, tweak this game more, or start on your own brand new game. Good luck! [\<- Scoring HUD Logic](/documentation/tutorials/tutorials-beefball/tutorials-beefball-scoring-hud-logic.md "Tutorials:Beefball:Scoring Hud Logic")
