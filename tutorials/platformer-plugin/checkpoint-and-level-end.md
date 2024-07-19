# Checkpoint and Level End

### Introduction

This walkthrough covers concepts related to creating an end-of-level entity which moves the player to the next level and creating a checkpoint which lets the player start at a midpoint in a level after dying.

{% embed url="https://youtu.be/Vxg5eOPmzHI?t=282" %}

The sample project can be downloaded from GitHub: [https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/CheckpointAndLevelEndDemo](https://github.com/vchelaru/FlatRedBall/tree/NetStandard/Samples/Platformer/CheckpointAndLevelEndDemo)

<figure><img src="../../media/2021-05-2021_May_31_131549.gif" alt=""><figcaption></figcaption></figure>

This walkthrough refers to CheckpointAndEndLevelDemo as _the demo_ and _this demo_.

### Main Concepts

This walkthrough covers a number of concepts for checkpoints and end of level:

* Creating instances of Checkpoint and EndOfLevel entities in Tiled on object layers to allow different values on each instance
* Storing the current checkpoint name in a static variable so it persists across Screen instances
* Spawning and re-spawning the player at checkpoint locations
* Collision between the Player and objects controlling spawning (Checkpoint, EndOfLevel, and PitCollision)

### Tiled Entity Creation

This demo includes two levels: Level1 and Level2. Each level has its own TMX file: Level1Map.tmx and Level2Map.TMX. If your project used the platformer plugin then it should have these by default. If your game already has existing levels, you can follow along but you will work in your existing levels rather than Level1 and Level2.

![Level1 and Level2 with TMX files](<../../.gitbook/assets/13\_05 55 20.png>)

### Adding an Object Layer

The checkpoints and doors will be added to a Tiled _object layer_. You must have at least one object layer on each level which should include a checkpoint. For this video we'll use the name GameplayObjectLayer so that it is similar to the standard GameplayLayer.

<figure><img src="../../.gitbook/assets/image (2) (1) (1).png" alt=""><figcaption><p>GameplayObjectLayer in the Tiled layer list</p></figcaption></figure>

### Creating Checkpoint and EndOfLevel Entities

We will create two entities: Checkpoint and EndOfLevel.

To add a Checkpoint entity:

1. Right-click on the Entities folder
2. Select Add Entity
3. Enter the name EndOfLevel
4. Check the AxisAlignedRectangle option
5. Click OK

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1).png" alt=""><figcaption><p>Checkpoint Entity Creation</p></figcaption></figure>

Repeat the process above to create an EndOfLevel entity

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>EndOfLevel Entity Creation</p></figcaption></figure>

Next we'll add a new variable to EndOfLevel:

1. Expand EndOfLevel
2. Right-click on Variables
3. Select Add variable
4. Select the type string
5. Enter the name NextLevel
6. Click OK

<figure><img src="../../.gitbook/assets/image (3) (1).png" alt=""><figcaption><p>Creating a NextLevel variable</p></figcaption></figure>

### Setting the Class on a Tile

Next we need to associate a particular tile with the entity. By doing this, FlatRedBall automatically instantiates the entities whenever it encounters a tile.

To do this:

1. Open your level in Tiled. Make sure you do not have other levels open as to avoid mixing tilesets
2. Select the TiledIcons tileset and click on the edit button
3. Select the tile that you would like to use as a checkpoint, such as the checkered flag
4.  Set the Class to Checkpoint - be sure to match the name of your entity exactly\


    <figure><img src="../../.gitbook/assets/image (4).png" alt=""><figcaption><p>Setting the Checkpoint tile class to Checkpoint</p></figcaption></figure>
5. Save your tileset

Now you can add instances of the Checkpoint tile to your level in the GameplayObjectLayer. You should provide a descriptive name of the Checkpoint, such as LevelStart. Note that checkpoints can exist at the beginning of a level - this is where the player may spawn when going from one level to another.

To do this:

1. Select the Checkpoint tile
2. Select the GameplayObjectLayer
3. Clck the Add Tile icon to go into tile placement mode
4. Click on the map to add the Checkpoint tile

<figure><img src="../../.gitbook/assets/image (9).png" alt=""><figcaption><p>Adding a new Checkpoint instance to your game</p></figcaption></figure>

All checkpoints must have names so that they can be referenced in code. For this project we assume that every level has at least one checkpoint with the name LevelStart. You can set this name on the newly-created Checkpoint by selecting it and setting its name in Tiled:

<figure><img src="../../.gitbook/assets/image (12).png" alt=""><figcaption><p>Checkpoint instance with the nane LevelStart</p></figcaption></figure>

Next we'll declare which tile in our tileset should create an EndOfLevel instance. To do this, open up the TiledIcons tileset in edit mode again. Select the icon that looks like a door. You may notice that it already has a Class set, so you can change it from "Door" to "EndOfLevel". As mentioned above, the name must match your entity exactly.

<figure><img src="../../.gitbook/assets/image (5).png" alt=""><figcaption><p>Setting the tile's class to EndOfLevel</p></figcaption></figure>

Next, we can add a new property to the tile. This should match the name of our variable in the FRB Editor exactly. To do this:

1. Select the tile
2. Click the + icon at the bottom of the properties
3. Keep the type as string
4. Enter a property name of NextLevel
5. Click OK

<figure><img src="../../.gitbook/assets/image (6).png" alt=""><figcaption><p>Adding a new NextLevel property</p></figcaption></figure>

The variable should appear on the tile.

<figure><img src="../../.gitbook/assets/image (7).png" alt=""><figcaption><p>NextLevel property on the EndOfLevel Tile</p></figcaption></figure>

Repeat the process above to add an EndOfLevel instance to your GameplayObjectLayer.

<figure><img src="../../.gitbook/assets/image (10).png" alt=""><figcaption><p>Adding an EndOfLevel instance</p></figcaption></figure>

Once this instance has been placed, its variable can be changed. For example, we can set the variable to Level2.

<figure><img src="../../.gitbook/assets/image (11).png" alt=""><figcaption><p>Setting Level2 on the EndOfLevel instance</p></figcaption></figure>

### LastCheckpointName and Spawning

We want our player to spawn at a checkpoint. We'll create a static variable called LastCheckpointName which indicates the starting Checkpoint.

Initially when the game starts the LastCheckpointName should be set to LevelStart so that the checkpoint that was previously created is used:

The following code shows the logic that does this:

```csharp
static string LastCheckpointName = "LevelStart";

void CustomInitialize()
{
    // ... Other code...

    var checkpoint = CheckpointList.First(item => item.Name == LastCheckpointName);
    Player1.Position = checkpoint.Position;
    Player1.Y -= 8;
    CameraControllingEntityInstance.ApplyTarget(CameraControllingEntityInstance.GetTarget(), lerpSmooth: false);
}
```

The spawning checkpoint is used to set the player's position. Notice that the player is moved down 8 units after spawning - this accounts for the position of the spawn point being the center of the object, while the player's position is at the bottom (at the player's feet).

### Player Collision

Collision between the Player and various objects controls the spawning behavior. As mentioned earlier, the LastCheckpointName variable controls which checkpoint is used to position the Player instance. The CustomInitialize method is called whenever a level is created (or recreated).&#x20;

We will use the EndOfLevel instances to move the player from one level to the next, and to set the LastCheckpointName.

To do this:

1. Create a collision relationship between the PlayerList and EndOfLevelList in GameScreen
2. Add an event to the newly-created collision relationship
3. Open GameScreen.Event.cs
4. Add the following code to move to the next level and set the LastCheckpointName:

```csharp
void OnPlayerVsEndOfLevelCollided (Entities.Player player, Entities.EndOfLevel endOfLevel)
{
    GameScreen.LastCheckpointName = "LevelStart";
    MoveToScreen(endOfLevel.NextLevel);
}
```

Notice that the code above assumes that the EndOfLevel instance has a valid NextLevel value. If the EndOfLevel NextLevel property is not set to a valid screen then this code will throw an exception. The code above resets the LastCheckpointName to LevelStart so that the Player spawns at the beginning of the level.&#x20;

We can set the LastCheckpointName whenever the player collides with a checkpoint - it doesn't have to be only when the player collides with a door. To do this:

1. Create a collision relationship between PlayerList and CheckpointList
2. Add an event to the newly-created collision relationshp
3. Open GameScreen.Event.cs
4. Add the following code:

```csharp
void OnPlayerListVsCheckpointListCollided (Entities.Player player, Entities.Checkpoint checkpoint)
{
    LastCheckpointName = checkpoint.Name;
}
```

The code above sets the LastCheckpointName to the name of the collided checkpoint, but this will ony apply when the screen changes or is restarted. The code above resets the LastCheckpointName whenever colliding with a door, so this checkpoint will only apply whenever the screen is restarted. Typically this would happen when the player dies.

Player death can be handled in a variety of ways, such as by collision with a TileShapeCollection, or even with a hotkey to test death. Regardless, the way to restart the screen is by calling this.RestartScreen().

For example if you have a TileShapeCollection named PitCollision, a collision relationship can be created between the PlayerList and PitCollision to restart the screen. This relationship would have an event with the following code in GameScreen.Event.cs:

```

void OnPlayerListVsPitCollisionCollided (Entities.Player player, FlatRedBall.Math.Geometry.ShapeCollection second)
{
    this.RestartScreen(reloadContent:false);
}
```

This code restarts the screen, which results in the entire screen being completely destroyed and recreated. Since CustomInitialize runs again, the Player will be re-positioned according to the LastCheckpointName.

### Checkpoint Visuals

The demo includes two types of checkpoints:

1. Visible checkpoints - when the player collides with these checkpoints, the checkpoint changes appearance and sets the LastCheckpointName property.
2. Invisible checkpoints - are used only to spawn the player. In the case of the demo, only at the beginning of the level.

Whether a checkpoint is visible or not is controlled by an exposed Visible property.

![](../../media/2021-06-img\_60b8cf51505df.png)

Only Visible Checkpoint instances are considered in the Player vs Checkpoint relationship event.

```csharp
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

```csharp
public void MarkAsChecked()
{
    this.FlagSprite.Visible = true;
}
```

### Conclusion

This walkthrough showed how the demo project creates checkpoints which can be used to restart the player mid-level and end of level objects (doors) which can move to the next level.
