# Checkpoint and Level End

### Introduction

This walkthrough covers concepts related to creating an end-of-level entity which moves the player to the next level and creating a checkpoint which lets the player start at a midpoint in a level after dying.&#x20;

{% embed url="https://youtu.be/Vxg5eOPmzHI?t=282" %}

The sample project can be downloaded from GitHub: [https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/CheckpointAndLevelEndDemo](https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/CheckpointAndLevelEndDemo)&#x20;

&#x20;

<figure><img src="../../media/2021-05-2021_May_31_131549.gif" alt=""><figcaption></figcaption></figure>

This walkthrough refers to CheckpointAndEndLevelDemo as _the demo_ and _this demo_.

### Main Concepts

This walkthrough covers a number of concepts for checkpoints and end of level:

* Creating instances of Checkpoint and EndOfLevel entities in Tiled on object layers to allow different values on each instance
* Storing the current checkpoint name in a static variable so it persists across Screen instances
* Spawning and re-spawning the player at checkpoint locations
* Collision between the Player and objects controlling spawning (Checkpoint, EndOfLevel, and PitCollision)

### Tiled Entity Creation

This demo includes two levels: Level1 and Level2. Each level has its own TMX file: Level1Map.tmx and Level2Map.TMX.

![](../../media/2021-05-img\_60b55bea0ba64.png)

Each level includes an object layer with Checkpoint and EndOfLevel instances. These objects must be defined on an Object layer rather than a Tiled layer so that each instance can have custom properties like Name or LevelToGoTo. For example, the following Checkpoint instance in Level1Map.tmx is named **LevelStart.**

![](../../media/2021-06-img\_60b636d787baf.png)

&#x20;The EndOfLevel instances also require a custom property to indicate which level is next. For example, the EndOfLevel instance on the right side of Level1Map.tmx has its NextLevel value set to Level2 as shown in the following image.

![](../../media/2021-06-img\_60b637403706b.png)

This custom property will automatically be assigned as long as it matches the property defined in Glue, including capitalization.

![](../../media/2021-06-img\_60b637ecdd2cf.png)

This demo assumes that each level has at least one Checkpoint instance named **LevelStart.** This instance sets where the player begins whenever the level is first created. Additional Checkpoint instances can be added. For example, Level1Map.tmx includes a second **Midpoint** checkpoint.

![](../../media/2021-06-img\_60b6395479628.png)

### LastCheckpointName and Spawning

Player spawning depends on the LastCheckpointName. By default this value is set to **LevelStart** - a convention which this game uses to determine the start location for a level. This logic is performed at the end of GameScreen.CustomInitialize.

```
void CustomInitialize()
{
    var mapPitCollision = Map.ShapeCollections.FirstOrDefault(item => item.Name == "PitCollision");
    if(mapPitCollision != null)
    {
        PitCollision.AddToThis(mapPitCollision);
    }

    var checkpoint = CheckpointList.First(item => item.Name == LastCheckpointName);
    Player1.Position = checkpoint.Position;
    Player1.Y -= 8;
    CameraControllingEntityInstance.ApplyTarget(CameraControllingEntityInstance.GetTarget(), lerpSmooth: false);
}
```

The spawning checkpoint is used to set the player's position. Notice that the player is moved down 8 units after spawning - this accounts for the position of the spawn point being the center of the object, while the player's position is at the bottom (at the player's feet).

### Player Collision

Collision between the Player and various objects controls the spawning behavior. As mentioned earlier, the LastCheckpointName variable controls which checkpoint is used to position the Player instance. The CustomInitialize method is called whenever a level is created (or recreated). This creation happens whenever the Player moves from one level to another, or whenever the Player falls into a pit. The Player moves to a different level when colliding with an EndOfLevel instance. This raises a collision event which is in **GameScreen.Event.cs**.

```
void OnPlayerListVsEndOfLevelListCollisionOccurred (Entities.Player first, Entities.EndOfLevel endOfLevel)
{
    GameScreen.LastCheckpointName = "LevelStart";
    MoveToScreen(endOfLevel.NextLevel);
}
```

Notice that the code above assumes that the EndOfLevel instance has a valid NextLevel value. If the EndOfLevel NextLevel property is not set to a valid screen then this code will throw an exception. The code above resets the LastCheckpointName to LevelStart so that the Player spawns at the beginning of the level. The LastCheckpointName variable can also change whenever the Player collides with a Checkpoint instance. This is also handled in the **GameScreen.Event.cs** file.

```
void OnPlayerListVsCheckpointListCollisionOccurred (Entities.Player first, Entities.Checkpoint checkpoint)
{
    if(checkpoint.Visible)
    {
        // This is a checkpoint that you can actually touch and "turn on"
        checkpoint.MarkAsChecked();

        LastCheckpointName = checkpoint.Name;
    }
}
```

Since the LastCheckpointName is reset whenever the Player moves to a new level, this is only used if the Player dies by falling into a pit. The next section covers how the PitCollision is defined in more detail, but ultimately a collision relationship handles collision between the player and pits, which is then handled in **GameScreen.Event.cs**.

```
void OnPlayerListVsPitCollisionCollisionOccurred (Entities.Player first, FlatRedBall.Math.Geometry.ShapeCollection second)
{
    this.RestartScreen(reloadContent:false);
}
```

This code restarts the screen, which results in the entire screen being completely destroyed and recreated. Since CustomInitialize runs again, the Player will be re-positioned according to the LastCheckpointName.

### PitCollision ShapeCollection

The PitCollision object is a ShapeCollection created in the GameScreen in Glue. It is referenced by the PlayerListVsPitCollision relationship which has a collision event as mentioned above.

![](../../media/2021-06-img\_60b6f1da20081.png)

The PitCollision is initially empty, but populated from the Map object - Level1Map.tmx or Level2Map.tmx depending on the current level. This population is done in the GameScreen's CustomInitialize using the AddToThis method.

```
void CustomInitialize()
{
    var mapPitCollision = Map.ShapeCollections.FirstOrDefault(item => item.Name == "PitCollision");
    if(mapPitCollision != null)
    {
        PitCollision.AddToThis(mapPitCollision);
    }

    var checkpoint = CheckpointList.First(item => item.Name == LastCheckpointName);
    Player1.Position = checkpoint.Position;
    Player1.Y -= 8;
    CameraControllingEntityInstance.ApplyTarget(CameraControllingEntityInstance.GetTarget(), lerpSmooth: false);
}
```

The code above searches the current Map for a ShapeCollection with the name PitCollision. The loaded TMX will automatically create ShapeCollections for every object layer with a shape in it. The Level1Map.tmx file includes a layer named PitCollision with a single large rectangle for collision.

![](../../media/2021-06-img\_60b6f592f1073.png)

A gap is left between the bottom of the map and the position of the rectangle so the player falls fully off-screen before colliding with the rectangle and respawning.&#x20;

<figure><img src="../../media/2021-06-Qo2qkk2v8Q.gif" alt=""><figcaption></figcaption></figure>

### Checkpoint Visuals

The demo includes two types of checkpoints:

1. Visible checkpoints - when the player collides with these checkpoints, the checkpoint changes appearance and sets the LastCheckpointName property.
2. Invisible checkpoints - are used only to spawn the player. In the case of the demo, only at the beginning of the level.

Whether a checkpoint is visible or not is controlled by an exposed Visible property.

![](../../media/2021-06-img\_60b8cf51505df.png)

Only Visible Checkpoint instances are considered in the Player vs Checkpoint relationship event.

```
void OnPlayerListVsCheckpointListCollisionOccurred (Entities.Player first, Entities.Checkpoint checkpoint)
{
    if(checkpoint.Visible)
    {
        // This is a checkpoint that you can actually touch and "turn on"
        checkpoint.MarkAsChecked();

        LastCheckpointName = checkpoint.Name;
    }
}
```

The Checkpoint is visually composed of two Sprites:

* PoleSprite
* FlagSprite

By default the **FlagSprite** is invisible, but is turned on in the **MarkAsChecked** function. This provides visual confirmation to the user that the checkpoint has been triggered.

```
public void MarkAsChecked()
{
    this.FlagSprite.Visible = true;
}
```

### Conclusion

This walkthrough showed how the demo project creates checkpoints which can be used to restart the player mid-level and end of level objects (doors) which can move to the next level.
