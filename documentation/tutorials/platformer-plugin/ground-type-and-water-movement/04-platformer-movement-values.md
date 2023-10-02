## Introduction

As of the last tutorial our game has three tile shape collections:

-   SolidCollision - the bricks that make up most of the level
-   IceCollision - floating blocks of ice which should be slippery
-   WaterCollision - an area of the level where the player should be able to swim

This tutorial shows how to create new platformer values for ice and water, and how to change between them depending on collision type.

## Creating the Platformer Values

Before we change which platformer values are used based on collision, we first need to define the platformer values for the different movement types. As mentioned before, we will have the following platformer values:

-   Ground - already defined by default
-   Air - already defined by default
-   Ice - will apply when user collides with the ice TileShapeCollection
-   Water - will apply when the user collides with the water TileShapeCollection

To add a new movement value:

1.  Click the **Player** entity

2.  Click the **Entity Input Movement** tab

3.  Click the **Add Control Values** button

    ![](/media/2023-02-img_63e03a3868fc7.png)

Set the following values:

-   Movement Type = Ice
-   Max Speed = 160
-   Speed Up/Down = true (click radio button)
-   Speed Up Time = 1
-   Slow Down Time = 1
-   Jump Speed = 270
-   Hold to Jump Higher = true (click checkbox)
-   Max Jump Hold Time = .17

![](/media/2023-02-img_63e03a942a213.png)

Repeat the process above to create a water movement. Click **Add Control Values** again, and set the following values:

-   Movement Type = Water
-   Max Speed = 120
-   Speed Up/Down = true (click radio button)
-   Speed Up Time = 1.3
-   Speed Down Time = 0.5
-   Jump Speed = 120
-   Hold to Jump Higher = true (click checkbox)
-   Max Jump Hold Time = 0.3
-   Gravity = 210
-   Max Falling Speed = 90

## Using Ice Movement

Now that we have Ice and Water movement defined, we can write code in the Player class to set the movement values according to what the player has collided with. To do this:

1.  Open the project in Visual Studio
2.  Open Player.cs
3.  Add the following code to CustomActivity:

&nbsp;

    private void CustomActivity()
    {
        // Update ground movement:
        if(this.GroundCollidedAgainst.Contains(nameof(Screens.GameScreen.IceCollision)))
        {
            GroundMovement = PlatformerValuesStatic["Ice"];
        }
        else if(this.ItemsCollidedAgainst.Contains(nameof(Screens.GameScreen.WaterCollision)))
        {
            GroundMovement = PlatformerValuesStatic["Water"];
        }
        else
        {
            GroundMovement = PlatformerValuesStatic["Ground"];
        }

        // Update the air movement:
        if (this.ItemsCollidedAgainst.Contains(nameof(Screens.GameScreen.WaterCollision)))
        {
            AirMovement = PlatformerValuesStatic["Water"];
            AfterDoubleJump = PlatformerValuesStatic["Water"];
        }
        else
        {
            AirMovement = PlatformerValuesStatic["Air"];
            AfterDoubleJump = PlatformerValuesStatic["Air"];
        }

    }

  Now our Player will change movement values when moving on ice and solid ground.

## 

## Conclusion

This concludes the platformer movement value tutorials where we use multiple TileShapeCollections to change the movement values for the player between regular ground/air movement, ice, and water movement. [![](/media/2021-04-05_16-33-47.gif)](/media/2021-04-05_16-33-47.gif)
