## Introduction

This walkthrough covers the concepts of climbing ladders. When climbing a ladder, the platformer Player is able to move vertically by pressing up or down on the analog stick or d-pad. Ladders and vines are used to provide access to areas normally not reachable by jumping alone. \[embed\]https://youtu.be/htFJTiVH5Ao?t=1465\[/embed\] The sample project can be downloaded from GitHub: <https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/LadderDemo> [![](/wp-content/uploads/2021/05/2021_May_08_094324.gif.md)](/wp-content/uploads/2021/05/2021_May_08_094324.gif.md) This walkthrough refers to LadderDemo as *this demo* and *the demo*.

## Main Concepts

This walkthrough covers a number of concepts for climbing ladders:

-   Defining ladder platformer values to control climbing speed
-   Defining ladders in the TMX file
-   Controlling whether currently climbing or not according to ladder collision and input
-   Limiting the climbing height

## Climbing Values

The Player entity defines a set of movement values for climbing called **Climbing**.

![](/media/2021-05-img_60aefd701ead6.png)

When this is set as the CurrentMovement, the player has direct control over vertical movement. When climbing up and down, the Climbing Speed is set as the player's Y velocity. As we will see later in the walkthrough, these values are explicitly set when the player presses **Up** to grab the ladder. Notice that the Player has a non-zero **Max Speed** under the Horizontal Movement section. This means that the player can move horizontally on the ladder. Some games like Super Mario world allow horizontal movement on ladders. Other games like Mega Man X only allow vertical movement on ladders. This game allows vertical movement, but changing the value to 0 results in no horizontal movement.

## Defining Ladders

Ladders are placed in the TMX file as tiles. The following image shows just the GameplayLayer with ladders.

![](/media/2021-05-img_6097123e95d11.png)

Notice that the ladder tiles define the maximum height that the player can climb.

![](/media/2021-05-img_609fd8ba05c63.png)

The code for this is defined below, but we can add extra climb height by adding additional tiles to the map. Keep in mind the GameplayLayer tiles do not need to match the visual layer exactly.

![](/media/2021-05-img_609fd97cac79a.png)

These ladders tiles use the **Ladder** type.

![](/media/2021-05-img_60971250dca22.png)

This allows the creation of a **LadderCollision** TileShapeCollection.

![](/media/2021-05-img_609712da913c8.png)

## Changing to Climbing Movement

Platformer Entities do not (currently) support automatic switching to climbing movement values. The demo includes custom code to enable switching to climbing. The main logic controlling the movement values is in the Player.cs **CustomActivity** method.

    private void CustomActivity()
    {
        animationController.Activity();

        if(!CurrentMovement.CanClimb)
        {
            if (VerticalInput.Value < 0)
            {
                this.GroundMovement = PlatformerValuesStatic["Ducking"];
            }
            else if (RunInput.IsDown)
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
        else
        {
            if(VerticalInput.Value < 0 && IsOnGround)
            {
                this.GroundMovement = PlatformerValuesStatic["Ground"];
            }
        }

        // Even if we are colliding with it, we want to see if the player's "body" is over
        // the ladder. We can do this by checking the center.
        var isOverLadder = LastCollisionLadderRectange != null && 
            X < LastCollisionLadderRectange.Right && X > LastCollisionLadderRectange.Left;

        if (InputDevice.DefaultUpPressable.WasJustPressed && LastCollisionLadderRectange != null)
        {
            this.GroundMovement = PlatformerValuesStatic["Climbing"];
            // snap the player's position to the center of the ladder
            this.X = LastCollisionLadderRectange.X;
            this.XVelocity = 0;
            if(this.IsOnGround == false)
            {
                // force the player on ground:
                CurrentMovementType = MovementType.Ground;
            }
        }

        if(isOverLadder == false && CurrentMovement.CanClimb)
        {
            // fall off the ladder...
            CurrentMovementType = MovementType.Air;
        }
    }

The CustomActivity method checks if the current movement can climb. If CurrentMovement.CanClimb is false, then the player is not climbing a ladder so we can do regular platformer logic for ducking and running. Otherwise, if the player is climbing, the game checks if the player is on ground (solid collision is colliding with the player from below) and if the user is pressing down. If so, we set the ground movement back to **Ground** so players can climb to the bottom and leave the climbing state. The second half of CustomActivity code performs logic which switches between being on the ground, in the air, and on th eladder. Rather than only relying on a null check with LastCollisionLadderRectangle, the code also checks if the player's center point (X) is inside the bounds of the LastCollisionLadderRectangle. This prevents the player from moving too far off of the ladder horizontally before falling off. This code could be adjusted to allow the player to move more or less horizontally. If the player is colliding with the ladder and presses up, then the player can grab a ladder. The player's movement on the horizontal axis is stopped and the player snaps its X position to the ladder's position. We also force the player to be on the ground and to use the **Climbing** movement values. If the player is not over the ladder but CurrentMovement.CanClimb is true, then the player has moved horizontally off of a ladder, so the player's movement is changed to air (falling). The **LastCollisionLadderRectangle** property is necessary rather than a bool value so that the player can snap to the ladder's X position. This is a regular property defined at the top of Player.cs.  

    public partial class Player
    {
        ...
        public AxisAlignedRectangle LastCollisionLadderRectange { get; set; }
        ...

This value is controlled by GameScreen. The ladder collision requires logic to be executed before collision occurs, so the PlayerListVsLadderCollision relationship does not automatically run.

![](/media/2021-05-img_60971a6308e58.png)

Instead, all Players have their LastCollisionLadderRectangle explicitly set to null, then the PlayerListVsLadderCollision relationship is manually called in GameScreen CustomActivity.

    private void DoCollisionActivity()
    {
        // first we reset the collision...
        foreach(var player in PlayerList)
        {
            player.LastCollisionLadderRectange = null;
        }
        // Then we do the collision which sets LastCollisionLadderRectange if a collision happens
        PlayerListVsLadderCollision.DoCollisions();
    }

Whenever a collision occurs, the LastCollisionLadderRectangle is set, as shown in GameScreen.Event.cs OnPlayerListVsLadderCollisionCollisionOccurred.

     void OnPlayerListVsLadderCollisionCollisionOccurred (Entities.Player player, FlatRedBall.TileCollisions.TileShapeCollection second)
     {
         player.LastCollisionLadderRectange = second.LastCollisionAxisAlignedRectangles.First();

         ...
     }

All of this results in the LastCollisionLadderRectangle storing a rectangle if the player collides with a ladder, and storing null if not. Note that this implementation will not work effectively if two ladders are placed next to each other.

## Custom Movement Logic vs. Player Platform Movement Values

Simple games may make use of automatically assigning movement values on collision as shown in the [Adding Ice and Water document](/documentation/tutorials/platformer-plugin/ground-type-and-water-movement/03-adding-ice-and-water.md). In this document, platformer values are assigned through the FlatRedBall dropdowns on the Collision Relationship. While this is convenient, note that ladder movement is optionally assigned based on game logic rather than simple collision. Therefore, if your game uses ladders, you may need to move all assignment of movement values to code.

## Limiting Ladder Height

When a player climbs down a ladder and collides with solid collision, IsOnGround will be set to true and the climbing movement values will be undone. The demo performs extra logic to prevent the player from climbing above the top of the ladder. Platformer entities like Player automatically have a **TopOfLadderY** property which can be assigned in custom code. The demo assigns this in the OnPlayerListVsLadderCollisionCollisionOccurred.

    void OnPlayerListVsLadderCollisionCollisionOccurred (Entities.Player player, FlatRedBall.TileCollisions.TileShapeCollection second) 
    {
        player.LastCollisionLadderRectange = second.LastCollisionAxisAlignedRectangles.First();

        // a little inefficient, could use caching to save a little calculation but it won't be too bad:
        var topRectangle = player.LastCollisionLadderRectange;

        var rectangleAbove = second.GetRectangleAtPosition(topRectangle.X, topRectangle.Y + second.GridSize);

        while(rectangleAbove != null)
        {
            topRectangle = rectangleAbove;
            rectangleAbove = second.GetRectangleAtPosition(topRectangle.X, topRectangle.Y + second.GridSize);
        }

        player.TopOfLadderY = topRectangle.Bottom;
    }

Whenever a collision occurs with ladder rectangles, the code moves up one tile at a time (using GridSize) until it finds the last tile. This is marked as the TopOfLadderY which prevents the player from climbing up indefinitely. The Player's position is defined as the bottom of the player, so in this case, the code limits the height that the player to the bottom of the ladder. This can be changed by modifying the last line of code in the code above. For example, we could let the player's feet reach the top of the ladder by changing the last line to:

    player.TopOfLadderY = topRectangle.Top;

 

## Conclusion

This walkthrough has covered how to add ladder climbing to a platformer game.
