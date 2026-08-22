# Climbing Ladders

### Introduction

This walkthrough covers climbing ladders. When climbing a ladder, the platformer Player moves vertically by pressing up or down on the analog stick or d-pad. Ladders and vines give access to areas that jumping alone can't reach.

{% embed url="https://youtu.be/htFJTiVH5Ao?t=1465" %}

The sample project can be downloaded from GitHub: [https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/LadderDemo](https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/LadderDemo)

<figure><img src="../../.gitbook/assets/2021-05-2021_May_08_094324.gif" alt=""><figcaption></figcaption></figure>

This walkthrough refers to LadderDemo as _this demo_ and _the demo_.

### Main Concepts

This walkthrough covers a number of concepts for climbing ladders:

* Defining ladder platformer values to control climbing speed
* Defining ladders in the TMX file
* Telling the player where a ladder's collision is, and where it ends
* Reacting to the player reaching the top or bottom of a ladder

### Climbing Values

The Player entity defines a set of movement values for climbing called **Climbing**.

![](../../.gitbook/assets/2021-05-img\_60aefd701ead6.png)

While these values are active, the player has direct control over vertical movement - climbing up and down sets the player's Y velocity from the Climbing Speed. Notice that the Player also has a non-zero **Max Speed** under the Horizontal Movement section. This means the player can move horizontally while on the ladder. Some games, like Super Mario World, allow this. Others, like Mega Man X, only allow vertical movement on ladders. This demo allows horizontal movement, but setting Max Speed to 0 removes it.

### Defining Ladders

Ladders are placed in the TMX file as tiles. The following image shows just the GameplayLayer with ladders.

![](../../.gitbook/assets/2021-05-img\_6097123e95d11.png)

Notice that the ladder tiles define the maximum height that the player can climb.

![](../../.gitbook/assets/2021-05-img\_609fd8ba05c63.png)

You can add extra climb height by adding more tiles to the map. The GameplayLayer tiles don't need to match the visual layer exactly.

![](../../.gitbook/assets/2021-05-img\_609fd97cac79a.png)

These ladder tiles use the **Ladder** type.

![](../../.gitbook/assets/2021-05-img\_60971250dca22.png)

This lets Glue create a **LadderCollision** TileShapeCollection.

![](../../.gitbook/assets/2021-05-img\_609712da913c8.png)

### Switching to Climbing Movement

Platformer entities handle ladder climbing automatically: grabbing a ladder, clamping at its top, and falling off if the player steps sideways off of it are all built in. Your code just needs to tell the entity two things: which movement values to use while climbing, and where the ladder collision is.

Assign the **ClimbingMovement** property once, in CustomInitialize:

```csharp
private void CustomInitialize()
{
    ClimbingMovement = PlatformerValuesStatic["Climbing"];
    ...
}
```

That's it for movement values - you never assign GroundMovement or AirMovement to make the player climb. ClimbingMovement is a separate slot, and the platformer entity switches to it on its own once the player grabs a ladder.

Player.cs's CustomActivity only needs to handle the movement values a real project usually wants: switching between Ducking, Running, and Ground while **not** climbing.

```csharp
private void CustomActivity()
{
    animationController.Activity();

    if (CurrentMovementType != MovementType.Climbing)
    {
        if (VerticalInput.Value < 0)
        {
            GroundMovement = PlatformerValuesStatic["Ducking"];
        }
        else if (RunInput.IsDown)
        {
            GroundMovement = PlatformerValuesStatic["Running"];
            AirMovement = PlatformerValuesStatic["RunningAir"];
        }
        else
        {
            GroundMovement = PlatformerValuesStatic["Ground"];
            AirMovement = PlatformerValuesStatic["Air"];
        }
    }
}
```

The `if (CurrentMovementType != MovementType.Climbing)` check keeps this code out of the way while the player is on a ladder. Everything else - grabbing the ladder, letting go, clamping at the top - is handled for you.

### Telling the Player Where the Ladder Is

The platformer entity still needs to know where the ladder collision actually is - that part depends on your level, so it isn't automatic. Every platformer entity has a **LastCollisionLadderRectange** property for this. You set it to the ladder rectangle the player is touching, and set it back to null when the player isn't touching one.

The ladder collision needs to run before other collision, so GameScreen calls it directly instead of letting it run automatically:

```csharp
private void DoCollisionActivity()
{
    // first we reset the collision...
    foreach (var player in PlayerList)
    {
        player.LastCollisionLadderRectange = null;
    }
    // Then we do the collision which sets LastCollisionLadderRectange if a collision happens
    PlayerVsLadderCollision.DoCollisions();
}
```

Whenever a collision happens, LastCollisionLadderRectange is set in GameScreen.Event.cs's OnPlayerVsLadderCollisionCollided:

```csharp
void OnPlayerVsLadderCollisionCollided(Player player, TileShapeCollection ladder)
{
    player.LastCollisionLadderRectange = ladder.LastCollisionAxisAlignedRectangles.First();
}
```

This results in LastCollisionLadderRectange holding a rectangle whenever the player touches a ladder, and null otherwise. Note that this simple version won't behave well if two ladders are placed right next to each other - see the next section for the code the demo actually uses, which also handles ladder height.

### Reacting to Reaching the Top or Bottom

A platformer entity automatically calls two methods you can override in your own code:

* **OnLadderTopReached** - called when the player has climbed as high as the ladder allows and isn't holding Up
* **OnLadderBottomReached** - called when the player is climbing, touches solid ground, and isn't holding Down

Both are optional. You don't need to do anything in them for climbing to work correctly - reaching the top leaves the player hanging there with gravity turned off, and reaching the bottom (or stepping off either side) switches the player back to normal ground/air movement on its own. Use these methods for extra behavior, like playing a sound or triggering an animation:

```csharp
partial void OnLadderTopReached()
{
    // for example: play a "reached the top" sound here
}

partial void OnLadderBottomReached()
{
}
```

### Limiting Ladder Height

A platformer entity has a **TopOfLadderY** property that caps how high the player can climb. You assign it yourself, since only your code knows where the top of a given ladder actually is. The demo assigns it in OnPlayerVsLadderCollisionCollided, by walking up the ladder's tiles one at a time until it finds the last one:

```csharp
void OnPlayerVsLadderCollisionCollided(Player player, TileShapeCollection ladder)
{
    player.LastCollisionLadderRectange = ladder.LastCollisionAxisAlignedRectangles.First();

    var topRectangle = player.LastCollisionLadderRectange;

    var rectangleAbove = ladder.GetRectangleAtPosition(topRectangle.X, topRectangle.Y + ladder.GridSize);

    while (rectangleAbove != null)
    {
        topRectangle = rectangleAbove;
        rectangleAbove = ladder.GetRectangleAtPosition(topRectangle.X, topRectangle.Y + ladder.GridSize);
    }

    player.TopOfLadderY = topRectangle.Top;
}
```

Use `topRectangle.Top` here, not `.Bottom` - `.Top` puts the player's feet at the actual top of the ladder, standing on whatever floor is up there. `.Bottom` stops the player a full tile short, still hanging in the air. The platformer entity clamps slightly inside the top tile automatically, so you don't need to account for that yourself.

### Custom Movement Logic vs. Player Platform Movement Values

Simple games may assign movement values automatically on collision, as shown in the [Adding Ice and Water document](ground-type-and-water-movement/03-adding-ice-and-water.md), where values are assigned through the FlatRedBall dropdowns on the Collision Relationship. Ladders don't fit that pattern - a ladder isn't something the player collides into and bounces off of, so entering and leaving the climbing state is driven by your own game logic instead. In practice this means assigning ClimbingMovement once and setting LastCollisionLadderRectange from your ladder collision, as shown above.

### Conclusion

This walkthrough covered how to add ladder climbing to a platformer game.
