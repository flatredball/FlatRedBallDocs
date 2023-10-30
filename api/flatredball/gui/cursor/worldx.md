# worldx

### Introduction

The WorldX property returns the X coordinate of the cursor in world units (impacted by zooming and camera position). WorldX is typically used on 2D games, or 3D games where the Z=0 plane contains the entities. For 3D games, see the [WorldXAt method](worldxat.md).

### Code Example - Moving an Entity with the Cursor

The following code shows how to move an entity instance with the cursor.

```
// This example assumes a Screen which contains PlayerInstance
void CustomActivity(bool firstTimeCalled)
{
  var cursor = GuiManager.Cursor;
  PlayerInstance.X = cursor.WorldX;
  PlayerInstance.Y = cursor.WorldY;
}
```

### Code Example - Moving an Entity towards the Cursor

The following code shows how to move an entity instance towards the cursor.

```
var cursor = FlatRedBall.Gui.GuiManager.Cursor;

if(cursor.PrimaryDown)
{
    var cursorPosition = new Vector3(cursor.WorldX, cursor.WorldY, 0);
    var directionToPlayer = cursorPosition - PlayerInstance.Position;
    var normalized = directionToPlayer.NormalizedOrZero();
    float movementVelocity = 60;

    PlayerInstance.Velocity = normalized * movementVelocity;
}
else
{
    PlayerInstance.Velocity = Vector3.Zero;
}
```

&#x20; 

<figure><img src="../../../../../media/2021-07-19_08-21-23.gif" alt=""><figcaption></figcaption></figure>

   &#x20;
