## Introduction

Now that we have our animations set up, we can work in our platformer values. These values control the way the Player entity moves in response input (such as max speed) and the physics which impact the Player's movement (such as gravity). Our Player entity automatically gets a set of default values which is why we are already able to walk and jump around the level. This tutorial will modify the default values and add additional platformer values for running and ducking.

## Setting Resolution

Before we begin modifying the control values, we'll change the resolution of our game to match the original [Super Mario World resolution of 256x224](https://smwspeedruns.com/Version_Differences).

1.  In Glue, click the Camera icon
2.  Change the resolution width to 256
3.  Change the resolution height to 224
4.  Change the TextureFilter to Point so that pixels draw without any blurring
5.  Change the Scale so that the game is larger on your screen. A typical 1080 monitor can support the game at 400% Scale.

![](/media/2021-03-img_6053edb5bceed.png)

After making these changes the game should more closely resemble the resolution of the original Super Mario World.

![](/media/2021-03-img_606107009dcee.png)

## Creating New Platformer Values

Currently our game has two set of platformer movement values:

-   Ground
-   Air

Earlier we added running animations which play when the run button is held. We will be modifying our game so the Player entity can run faster when the run button is held. We will be creating two new set of platformer movement variables for running. We will also be creating a new type of movement for when the player is ducking. Therefore, we'll have three more sets of movement variables:

-   Running
-   RunningAir
-   Ducking

Click the Add Control Values button three times, and name the new control values as listed above.

![](/media/2021-03-img_6053f22e87865.png)

You should now have five sets of values.

![](/media/2021-03-img_6053f2886d5c9.png)

## Modifying Platformer Movement Values

Next we'll modify the values to make the game feel a little more like Super Mario World. We'll be modifying these to get close - this is not intended to be an exact copy. Of course if you want to tune the values to make the game feel different, or if you want to mimic Super Mario World even more closely, feel free to change these values.

### Ground

-   Max Speed = 100
-   Speed Up/Down
-   Speed Up Time = 0.25
-   Slow Down Time = 0.15
-   Jump Speed = 230
-   Hold to Jump Higher = true (checked)
-   Max Jump Hold Time = 0.2

### Air

-   Max Speed = 100
-   Speed Up/Down
-   Speed Up Time = 0.7
-   Slow Down Time = 0.7
-   Jump Speed = 0
-   Gravity = 900
-   Max Falling Speed = 260

### Running

-   Max Speed = 150
-   Speed Up/Down
-   Speed Up Time = 0.3
-   Slow Down Time = 0.2
-   Jump Speed = 250
-   Hold to Jump Higher = true (checked)
-   Max Jump Hold Time = 0.25

### RunningAir

-   Max Speed = 150
-   Speed Up/Down
-   Speed Up Time = 0.7
-   Slow Down Time = 0.7
-   Jump Speed = 0
-   Gravity = 900
-   Max Falling Speed = 260

### Ducking

-   Max Speed = 0
-   Speed Up/Down
-   Custom deceleration above max speed = true (checked)
-   Custom deceleration value = 200
-   Jump Speed = 230
-   Hold to Jump Higher = true (checked)
-   Max Jump Hold Time = .2

## Switching PlatformerValues in Code

Now that we have our platformer movement values created in Glue, we can assign them in code. To switch values, we can change the GroundMovement and AirMovement variables in CustomActivity. We will be looking at the VerticalInput (holding up/down) and the RunInput to decide whether the player should be using the default values, running values, or ducking. To switch between these platformer movement values, modify CustomActivity in Player.cs as shown in the following code snippet:

    private void CustomActivity()
    {
        animationController.Activity();

        if(VerticalInput.Value < 0)
        {
            this.GroundMovement = PlatformerValuesStatic["Ducking"];
        }
        else if(RunInput.IsDown)
        {
            this.GroundMovement = PlatformerValuesStatic["Running"];
            this.AirMovement = PlatformerValuesStatic["RunningAir"];
        }
        else
        {
            this.GroundMovement = PlatformerValuesStatic["Ground"];
            this.AirMovement = PlatformerValuesStatic["Air"];
        }
    }

## Additional Challenges

Now the Player will switch its values according to input, of course, the running animations are not currently being used. Use what was covered in the previous tutorial to see if you can modify the Player's animations to play the running and running jump animations as shown in the following animation. [![](/wp-content/uploads/2021/03/2021_March_28_165247.gif)](/wp-content/uploads/2021/03/2021_March_28_165247.gif)  
