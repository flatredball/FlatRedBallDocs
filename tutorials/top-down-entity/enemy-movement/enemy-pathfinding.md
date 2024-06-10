# Enemy Pathfinding

### Introduction

Enemy pathfinding allows enemies to navigate through complex levels. This can be used to move to a target position (such as a patrol point) or follow an entity (such as enemies chasing a player). This tutorial shows how to create a pathfinding enemy. Specifically, it covers the following topics:

* Creating a TileNodeNetwork which defines the walkable parts of a map
* Creating an input device which is used to control the enemy so it follows its desired path
* Creating line-of-sight pathing for more natural movement

### Creating a TileNodeNetwork

First we'll create a TileNodeNetwork. This is defined in our GameScreen, but will use the Map for each level. For a more thorough walkthrough of creating a TileNodeNetwork, see the [TileNodeNetwork page](../../../glue-reference/objects/object-types/tilenodenetwork.md).

To create the TileNodeNetwork:

1. Select the GameScreen
2. Click the **Add Object to GameScreen** under **Quick Actions**, or right-click on GameScreen and select Add Object
3. Select the TileNodeNetwork type
4. Enter a name such as WalkingNodeNetwork
5. Click OK

<figure><img src="../../../.gitbook/assets/image (9) (1).png" alt=""><figcaption><p>WalkingNodeNetwork in GameScreen</p></figcaption></figure>

Next we'll define a tile to use for pathfinding. To do this:

1. Open any of your levels in Tiled
2. Select the Tileset that you use for your GameplayLayer. By default this is called TiledIcons
3. Click the wrench to edit the Tiles
4. Select a tile that you would like to use for pathfinding
5. Change the **Class** for that tile to WalkableTile
6. Save your tileset (TSX)

<figure><img src="../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>WalkableTile in Tiled</p></figcaption></figure>

Next, select your current level (such as Level1Map) and paint the WalkableTile onto the GameplayLayer. Note that if you would like to be able to walk on areas which already have other tiles, you can create a new layer specifically for Tiles.

<figure><img src="../../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>WalkableTile painted in the walkable areas of the Tiled map</p></figcaption></figure>

Be sure to save both your level and the tileset.

Finally, we can indicate that the WalkableTile should be used to populate the nodes in the Tile:

1. Select the **WalkingNodeNetwork** Object under **GameScreen**
2. Click the **TileNodeNetwork Properties**
3. Select the **From Type** option
4. Select **Map** as the **Source TMX File/Object**
5. Select **WalkableTile** as the **Type**

<figure><img src="../../../.gitbook/assets/image (3) (1) (1) (1).png" alt=""><figcaption><p>WalkingNodeNetwork with properties set to fill from WalkableTile Type</p></figcaption></figure>

Optionally, you may want to also set the Visible variable to true so the TileNodeNetwork shows up in your game.

<figure><img src="../../../.gitbook/assets/image (4) (1) (1).png" alt=""><figcaption><p>Setting the NodeNetwork visible to true</p></figcaption></figure>

The game should now show the TileNodeNetwork. Note that you can also make the GameplayLayer invisible in Tiled so that the TileNodeNetwork is easier to see in game.

<figure><img src="../../../.gitbook/assets/image (5) (1) (1).png" alt=""><figcaption><p>TileNodeNetwork visible in game</p></figcaption></figure>

Notice that the links between nodes are either vertical or horizontal. We will discuss diagonal movement later in the tutorial.

### Creating Enemy InputDevice

Now that we have a TileNodeNetwork defined, we can create an input device. Of course, we need to have an Enemy defined. For this tutorial I'll use a simple enemy with the following characteristics:

* It is named EnemyBase - this naming convention is used so that the enemy could be used as a base Entity for derived variants. Larger games would likely need multiple enemy types so this sets up to expand easily.
* The Enemy has a single Circle collision. More complex games may include multiple types of collision, but it's important to note which collidable object will be used as the solid collision - we'll use this for line-of-sight pathfinding later in this tutorial.
* The enemy uses the Top-Down movement types, just like the Player.
* The enemy's InputDevice is set to None. As indicated in the FRB Editor, this must be assigned in code or the game will crash.

<figure><img src="../../../.gitbook/assets/image (6) (1) (1).png" alt=""><figcaption><p>EnemyBase defined in the FRB Editor</p></figcaption></figure>

Next we'll define the InputDevice. You may be familiar with the InputDevice as hardware input which can control the movement of the Player (such as the Keyboard or Xbox360GamePad). Although these are common implementations of the input device (IInputDevice interface), the concept of an InputDevice is something which can be read by an Entity (such as the Enemy) to determine how it should move.

In this case the InputDevice will not be tied to actual hardware. Instead, we will return input values which move the EnemyBase through the map by following the path obtained from the WalkingNodeNetwork.

Fortunately, the TopDownAiInput class is an InputDevice which automatically returns these movement values according to a desired path.

First, we will assign this InputDevice in the EnemyBase's CustomInitialize:

```csharp
TopDownAiInput<EnemyBase> topDownAiInput;

private void CustomInitialize()
{
    topDownAiInput = new TopDownAiInput<EnemyBase>(this);

    // This helps us visualize the path the EnemyBase takes to get to
    // the player
    topDownAiInput.IsPathVisible = true;
    // Use a darker color so it stands out over the bright level tiles
    topDownAiInput.PathColor = Color.Purple;
    this.InitializeTopDownInput(topDownAiInput);
}

void CustomDestroy()
{
    // The top down input path must be made invisible so it cleans up
    // any shapes it creates in the path:
    topDownAiInput.IsPathVisible = false;     
}

```

Notice that the topDownAiInput is defined at class scope - this lets us access it in other methods without needing to cast the InputDevice every time. Also, the IsPathVisible and PathColor properties can be used to control the appearance of the path that the EnemyBase is going to take to get to the player. We will enable this to show the path. Also, it may be worth turning off the WalkingNodeNetwork visibility so that the EnemyBase path can be seen more clearly.

### Initializing TopDownAiInput

Next, we'll create a method to set up the node network and target player. Add the following to EnemyBase.cs:

```csharp
public void InitializePathfinding(Player player, TileNodeNetwork nodeNetwork)
{
    topDownAiInput.FollowingTarget = player;
    topDownAiInput.NodeNetwork = nodeNetwork;
}
```

For this tutorial we assume a single player which never changes. A multiplayer game may require changing the target based on which player last hit the enemy, proximity, or whether the current target is dead.&#x20;

Also, note that this method must be called by the GameScreen. We will add the code to call this method later in this tutorial.

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
    // We only call UpdatePath once every second since that doesn't need
    // to update too requently, but this should be called every frame so the
    // enemy's movement values are updated according to its path.
    topDownAiInput.DoTargetFollowingActivity();
}
```

Notice that this code only updates the path every second. Updating the path is a fairly quick operation, but it can be expensive if the game includes hundreds of EnemyBase instances. We'll check once per second to prepare for a larger game.

Now that our EnemyBase has the code it needs to pathfind to the player, we can add code to the GameScreen to call InitializePathfinding.

EnemyBase instances can be created both before and after GameScreen.CustomInitialize is called, so we must handle both cases.

To handle EnemyBase instances created before CustomInitialize is called (if they have been added directly to a level in the FRB Editor or live edit), we can loop thorugh EnemyBaseList and call InitializePathfinding.&#x20;

To handle EnemyBaseInstances created after CustomInitialize (if they are added using a factory or variant object such as through a spawner) we can subscribe to the factory method. Note that a game which has derived enemy variants must subscribe to all derived variant factories to handle creation.

Modify the GameScreen.cs to include the following code:

```csharp
void CustomInitialize()
{
    // This foreach handles enemies created before the screen's initialize.
    foreach(var enemy in EnemyBaseList)
    {
        PrepareEnemyPathfinding(enemy);
    }
    // This event handler handles enemies created after the screen's initialize.
    Factories.EnemyBaseFactory.EntitySpawned += PrepareEnemyPathfinding;
}

private void PrepareEnemyPathfinding(EnemyBase enemy)
{
    // This assumes Player1 is already created. If your game
    // creates its Player instances later, you need to make sure
    // the Player instance has already been created before this is
    // called.
    enemy.InitializePathfinding(Player1, WalkingNodeNetwork);
}

```

Finally, we can add the following code to GameScreen to create EnemyBase instances when clicking with the mouse.

```csharp
void CustomActivity(bool firstTimeCalled)
{
    FlatRedBallServices.Game.IsMouseVisible = true;
    if(GuiManager.Cursor.PrimaryClick)
    {
        Factories.EnemyBaseFactory.CreateNew(GuiManager.Cursor.WorldPosition);
    }
}
```

We can now click to place EnemyBase instances. Each EnemyBase instance follows the player according to pathfinding along the WalkingNodeNetwork and the position of the Player.

<figure><img src="../../../.gitbook/assets/29_06 22 14.gif" alt=""><figcaption><p>EnemyBase instance following the player using pathfinding</p></figcaption></figure>

Notice that the EnemyBase moves fairly quickly - the same speed as the Player. You may want to reduce the EnemyBase's movement speed to make it easier to test pathfinding.

<figure><img src="../../../.gitbook/assets/image (4) (1).png" alt=""><figcaption><p>Reduce EnemyBase's move speed to 50 to make it easier to test pathfinding</p></figcaption></figure>

### Customizing Pathfinding Behavior

So far we can create an EnemyBase by clicking in the game. The enemy base instance follows the player using the WalkingNodeNetwork. We have lots of options for customizing the way the enemy follows the player.

First, you may nave noticed that the enemy follows the player on a path by only moving horizontally or vertically. The reason for this is because our WalkingNodeNetwork is set up to only have four links per node: up, down, left, and right. we can include diagonal nodes to allow the enemy to also move diagonally.

Some games, such as the Legend of Zelda on the NES and the 2D Final Fantasy games do not allow the player, NPC, or enemies to move diagonally. If this limitation matches your game, then you can keep this default setup.

However, if your game requires diagonal movement, you can enable it in the TileNodeNetwork properties for the WalkingNodeNetwork.

<figure><img src="../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Seetting TileNodeNetwork to use eight links per node for diagonal movement</p></figcaption></figure>

Now our EnemyBase instance can travel diagonally.

<figure><img src="../../../.gitbook/assets/29_06 32 00.gif" alt=""><figcaption><p>EnemyBase instance moving diagonally to pathfind towards a player</p></figcaption></figure>

You may have noticed that at times the EnemyBase _backtracks -_ in other words at times the enemy seems to walk backwards rather than following its path. This can happen when the path is re-evaluated. The new path requires the enemy to move backwards slightly to move to its next node.

To help explain this problem we can visualize a simple path that an enemy may take. It's important to remember that each node in the TileNodeNetwork is always placed at the center of the tile. The following image shows an example path. The blue circles represent the node positions, the red circle represents the enemy, and the purple lines represent the path the Enemy takes.

<figure><img src="../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Example path</p></figcaption></figure>

Notice that the enemy moves directly towards the first node diagonally. This happens regardless of where the enemy is located - by default the very first segment in the path connects the enemy to the path. In this case the movement seems to be what we might expect, but in some situations the enemy may be positioned such that its first movement requires it to backtrack, as shown in the following image:

<figure><img src="../../../.gitbook/assets/image (2) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Example of a backgracing path</p></figcaption></figure>

Notice that in this case the closest node to the enemy is to the right of the enemy. Therefore, the first movement segment has the enemy moving to the right before it resumes moving to the left.

We can solve this by removing the first segment of the path, but only if the path has more than one point. If there is exactly one point in the path, then we should not remove it since the enemy is near its final target.

We can modify our code as shown in the following EnemyBase.CustomActivity:

```csharp
private void CustomActivity()
{
    if(TimeManager.CurrentScreenSecondsSince(lastTimePathUpdates) > pathUpdateFrequency)
    {
        lastTimePathUpdates = TimeManager.CurrentScreenTime;
        topDownAiInput.UpdatePath();

        // Remove the first node in the path to prevent backtracking
        if(topDownAiInput.Path.Count > 2)
        {
            topDownAiInput.Path.RemoveAt(0);
            topDownAiInput.NextImmediateTarget = topDownAiInput.Path[0];
        }
    }
    topDownAiInput.DoTargetFollowingActivity();
}
```

Note that while this approach does solve the backtracking problem, it can at times cause the enemy to move diagonally to the next node in a way which may result in getting stuck behind collision.

The reason we discuss this solution is not necessarily to suggest that this is the best solution for backtracking for production games, but rather to show that the TopDownAiInput object allows you to manipulate its Path at any time. You can perform more advanced logic to determine if backtracking will occur, and to remove, add, or modify existing nodes to correct for this problem according to your game's specific needs.

### Collision and Corner Clipping

At this point our enemies can pathfind but they do not respect the level's solid collision. If we enable collision we will notice that this introduces a number of problems.

To enable collision between EnemyBase and the leve's SolidCollision:

1. Expand GameScreen's Objects folder
2. Drag+drop EnemyBaseList onto SolidCollision
3. Verify that the newly-created CollisionRelationship is using BounceCollision
4. Change the elasticity to 0 so that the EnemyBase doesn't actually bounce off the wall. By setting it to 0 the wall absorbs the EnemyBase's velocity.

<figure><img src="../../../.gitbook/assets/image (3) (1) (1).png" alt=""><figcaption><p>Set EnemyBaseVsSolidCollision Elasticity to 0 to prevent bouncing</p></figcaption></figure>

If we run our game now we'll notice that the enemy gets stuck when trying to follow the player along any collision.

<figure><img src="../../../.gitbook/assets/29_07 02 00.gif" alt=""><figcaption><p>EnemyBase stuck against collision when performing pathfinding</p></figcaption></figure>

This is happening because the collision on our enemy is too big - it has a circle with a radius of 16. This prevents it from getting close enough to tiles to properly pathfind. We can fix some of the problems by changing the EnemyBase's CircleInstance radius to a smaller value. A value of 8 allows the EnemyBase to touch the center of a tile, so we will change the value to 8.

<figure><img src="../../../.gitbook/assets/image (5) (1).png" alt=""><figcaption><p>Reducing the EnemyBase CircleInstance to a Radius of 8 </p></figcaption></figure>

This change helps pathfinding, but it doesn't solve all of the problems. If your game is using diagonal movement, you may notice that the enemy slows down when colliding against corners. We can force the enemy to pathfind around a house. Notice the enemy slows down when moving around corners.

<figure><img src="../../../.gitbook/assets/29_07 15 12.gif" alt=""><figcaption><p>Enemy slowdown around corners</p></figcaption></figure>

This is occurring because we have enabled 8-way pathfinding, and this includes corner pathfinding. We can set our node network visibility to true to see that the node networks _cut corners_, in other words diagonal paths connect nodes which result in the EnemyBase attempting to push against a corner collision.

<figure><img src="../../../.gitbook/assets/image (6) (1).png" alt=""><figcaption><p>TileNodeNetworks cutting corners</p></figcaption></figure>

We can disable corner cutting through an option in the TileNodeNetwork Properties tab:

<figure><img src="../../../.gitbook/assets/image (7) (1).png" alt=""><figcaption><p>Eliminate Cut Corners</p></figcaption></figure>

Now our tile node network still supports diagonal movement, but it will not attempt to move diagonally around corners as shown in this screen shot:

<figure><img src="../../../.gitbook/assets/image (8) (1).png" alt=""><figcaption><p>Cut corners eliminated from a TileNodeNetwork</p></figcaption></figure>

### Line of Sight Pathfinding

So far we have made modifications to the EnemyBase entity and the WalkingNodeNetwork to address problems with collision, but one issue still remains - our enemy movement still feels unnatural. We can solve this problem by implementing _line-of-sight_ pathfinding. This form of pathfinding initially uses the TileNodeNetwork to determine which path it should take, but it then eliminates nodes along the path if a more direct path is available. This allows an entity to move in any direction and it can make pathfinding feel more natural.&#x20;



Of course, keep in mind that your game may intentionally have pathfinding strictly along a node network so whether you use line of sight pathfinding can be a stylistic choice.

To enable line of sight pathfinding, the TopDownAiInput must have two additional pieces of information:

1. The width of the collision. This is needed because line of sight pathfinding must check if a direct path exists to the target and also if following that direct path results in bumping against solid collision.
2. The solid collision to avoid

We can enable line of sight pathfinding by modifying the `InitializePathfinding` method as shown in the following code:

```csharp
public void InitializePathfinding(Player player, TileNodeNetwork nodeNetwork, 
    FlatRedBall.TileCollisions.TileShapeCollection collision)
{
    topDownAiInput.FollowingTarget = player;
    topDownAiInput.NodeNetwork = nodeNetwork;

    topDownAiInput.SetLineOfSightPathfinding(CircleInstance.Radius * 2, 
        // This can take multiple shape collections since some games use more than one
        // TileShapeCollection for pathfinding
        new List<FlatRedBall.TileCollisions.TileShapeCollection> { collision });
}
```

Notice that we use `CircleInstance.Radius*2` to determine the width of the entity. If using a different shape, or multiple shapes, your code needs to account for this. Also, keep in mind to also add any offsets if your shape is not centered on the X or Y. Finally, you may need to increase this value if your collision shapes can adjust during runtime - such as being modified by AnimationChains.

Since this method now requires passing in a TileShapeCollection, we need to modify GameScreen.PrepareEnemyPathfinding to pass in the SolidCollision as shown in the following code:

```csharp
private void PrepareEnemyPathfinding(EnemyBase enemy)
{
    // This assumes Player1 is already created. If your game
    // creates its Player instances later, you need to make sure
    // the Player instance has already been created before this is
    // called.
    enemy.InitializePathfinding(Player1, WalkingNodeNetwork, SolidCollision);
}
```

Now our enemy follows the player directly if there is a line of sight. If not, the enemy performs line of sight checks to skip nodes which are not necessary. Notice that when navigating tight spaces the enemy follows the node network, but when navigating open spaces the enemy moves more directly towards its target.

<figure><img src="../../../.gitbook/assets/29_07 51 30.gif" alt=""><figcaption><p>Enemy performing line of sight pathfinding</p></figcaption></figure>

### Conclusion

This tutorial has shown how to create an enemy that performs pathfinding towards a player. This pathfinding can be customized to address common problems, to enable or disable diagonal movement, and to use line of sight pathfinding for more natural movement.
