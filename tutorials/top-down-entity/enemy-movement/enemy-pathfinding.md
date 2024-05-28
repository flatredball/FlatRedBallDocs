# Enemy Pathfinding

### Introduction

Enemy pathfinding allows enemies to navigate through complex levels. This can be used to move to a target position (such as a patrol point) or follow an entity (such as enemies chasing a player). This tutorial shows how to create a pathfinding enemy. Specifically, it covers the following topics:

* Creating a TileNodeNetwork which defines the walkable parts of a map
* Creating an input device which is used to control the enemy so it follows its desired path
* Setting the desired path from the TileNodeNetwork
* Creating line-of-sight pathing for more natural movement

### Creating a TileNodeNetwork

First we'll create a TileNodeNetwork. This is defined in our GameScreen, but will use the Map for each level. For a more thorough walkthrough of creating a TileNodeNetwork, see the [TileNodeNetwork page](../../../glue-reference/objects/object-types/tilenodenetwork.md).

To create the TileNodeNetwork:

1. Select the GameScreen
2. Click the **Add Object to GameScreen** under **Quick Actions**, or right-click on GameScreen and select Add Object
3. Select the TileNodeNetwork type
4. Enter a name such as WalkingNodeNetwork
5. Click OK

<figure><img src="../../../.gitbook/assets/image.png" alt=""><figcaption><p>WalkingNodeNetwork in GameScreen</p></figcaption></figure>

Next we'll define a tile to use for pathfinding. To do this:

1. Open any of your levels in Tiled
2. Select the Tileset that you use for your GameplayLayer. By default this is called TiledIcons
3. Click the wrench to edit the Tiles
4. Select a tile that you would like to use for pathfinding
5. Change the **Class** for that tile to WalkableTile
6. Save your tileset (TSX)

<figure><img src="../../../.gitbook/assets/image (1).png" alt=""><figcaption><p>WalkableTile in Tiled</p></figcaption></figure>

Next, select your current level (such as Level1Map) and paint the WalkableTile onto the GameplayLayer. Note that if you would like to be able to walk on areas which already have other tiles, you can create a new layer specifically for Tiles.

<figure><img src="../../../.gitbook/assets/image (2).png" alt=""><figcaption><p>WalkableTile painted in the walkable areas of the Tiled map</p></figcaption></figure>

Be sure to save both your level and the tileset.

Finally, we can indicate that the WalkableTile should be used to populate the nodes in the Tile:

1. Select the **WalkingNodeNetwork** Object under **GameScreen**
2. Click the **TileNodeNetwork Properties**
3. Select the **From Type** option
4. Select **Map** as the **Source TMX File/Object**
5. Select **WalkableTile** as the **Type**

<figure><img src="../../../.gitbook/assets/image (3).png" alt=""><figcaption><p>WalkingNodeNetwork with properties set to fill from WalkableTile Type</p></figcaption></figure>

Optionally, you may want to also set the Visible variable to true so the TileNodeNetwork shows up in your game.

<figure><img src="../../../.gitbook/assets/image (4).png" alt=""><figcaption><p>Setting the NodeNetwork visible to true</p></figcaption></figure>

The game should now show the TileNodeNetwork. Note that you can also make the GameplayLayer invisible in Tiled so that the TileNodeNetwork is easier to see in game.

<figure><img src="../../../.gitbook/assets/image (5).png" alt=""><figcaption><p>TileNodeNetwork visible in game</p></figcaption></figure>

### Creating Enemy InputDevice

Now that we have a TileNodeNetwork defined, we can create an input device. Of course, we need to have an Enemy defined. For this tutorial I'll use a simple enemy with the following characteristics:

* It is named EnemyBase - this naming convention is used so that the enemy could be used as a base Entity for derived variants. Larger games would likely need multiple enemy types so this sets up to expand easily.
* The Enemy has a single Circle collision. More complex games may include multiple types of collision, but it's important to note which collidable object will be used as the solid collision - we'll use this for line-of-sight pathfinding later in this tutorial.
* The enemy uses the Top-Down movement types, just like the Player.
* The enemy's InputDevice is set to None. As indicated in the FRB Editor, this must be assigned in code or the game will crash.

<figure><img src="../../../.gitbook/assets/image (6).png" alt=""><figcaption><p>EnemyBase defined in the FRB Editor</p></figcaption></figure>

Next we'll define the InputDevice. You may be familiar with the InputDevice as hardware input which can control the movement of the Player (such as the Keyboard or Xbox360GamePad). Although these are common implementations of the input device (IInputDevice interface), the concept of an InputDevice is something which can be read by an Entity (such as the Enemy) to determine how it should move.

In this case the InputDevice will not be tied to actual hardware. Instead, we will return input values which move the EnemyBase through the map by following the path obtained from the WalkingNodeNetwork.

Fortunately, the TopDownAiInput class is an InputDevice which automatically returns these movement values according to a desired path.

First, we will assign this InputDevice in the EnemyBase's CustomInitialize:

```csharp
TopDownAiInput<EnemyBase> topDownAiInput;

private void CustomInitialize()
{
    topDownAiInput = new TopDownAiInput<EnemyBase>(this);
    this.InitializeTopDownInput(topDownAiInput);
}

```

Notice that the topDownAiInput is defined at class scope - this lets us access it in other methods without needing to cast the InputDevice every time.

Next, we'll create a method to set up the node network and target player. Add the following to EnemyBase.cs:

```csharp
public void InitializePathfinding(Player player, TileNodeNetwork nodeNetwork)
{
    topDownAiInput.FollowingTarget = player;
    topDownAiInput.NodeNetwork = nodeNetwork;
}
```

For this tutorial we assume a single player which never changes. A multiplayer game may require changing the target based on which player last hit the enemy, proximity, or whether the current target is dead.&#x20;

Also, note that this method must be called by the GameScreen. This approach is recommended to accessing the GameScreen directly from within the Enemy.

Finally, we can set the path to follow the player in CustomActivity.

```csharp
// initialize it to a large negative number so the path updates immediately
double lastTimePathUpdates = -999;
// how often the path should update. We do this to improve performance
double pathUpdateFrequency = 1;
private void CustomActivity()
{
    if(TimeManager.CurrentScreenSecondsSince(lastTimePathUpdates) > pathUpdateFrequency)
    {
        lastTimePathUpdates = TimeManager.CurrentScreenTime;
        topDownAiInput.UpdatePath();
    }
}
```

Notice that this code only updates the path every second. Updating the path is a fairly quick operation, but it can be expensive if the game includes hundreds of EnemyBase instances. We'll check once per second to prepare for a larger game.

TODO complete here...
