# NodeNetwork

### Introduction

NodeNetworks are a collection of [PositionedNodes](../flatredball-ai-pathfinding-positionednode.md) which are linked to each other using [Links](../flatredball-ai-pathfinding-link/). NodeNetworks are used for pathfinding.

### Creating a NodeNetwork in Code

The following code creates a simple NodeNetwork and a Sprite. Pressing the 1, 2, 3, or 4 keys causes the Sprite to move toward a given node on the NodeNetwork.

```csharp
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Input;
```

Add the following to your screen:

```csharp
NodeNetwork nodeNetwork;
Sprite sprite;
List<PositionedNode> nodePath;
```

Add the following in CustomInitialize:

```csharp
 // Instantiate the NodeNetwork.
 nodeNetwork = new NodeNetwork();

 // Create the 4 nodes.
 PositionedNode node = nodeNetwork.AddNode();
 node.Position = new Vector3(-150, 150, 0); // top left

 node = nodeNetwork.AddNode();
 node.Position = new Vector3(150, 150, 0); // top right

 node = nodeNetwork.AddNode();
 node.Position = new Vector3(150, -150, 0); // bottom right

 node = nodeNetwork.AddNode();
 node.Position = new Vector3(-150, -150, 0); // bottom left

 // Link the nodes together.
 // LinkTo creates two links - one to and one from.
 float linkCost = 1;
 nodeNetwork.Nodes[0].LinkTo(nodeNetwork.Nodes[1], linkCost);
 nodeNetwork.Nodes[1].LinkTo(nodeNetwork.Nodes[2], linkCost);
 nodeNetwork.Nodes[2].LinkTo(nodeNetwork.Nodes[3], linkCost);
 nodeNetwork.Nodes[3].LinkTo(nodeNetwork.Nodes[0], linkCost);

 // Make the NodeNetwork visible.  Usually only used for debugging
 // and development.
 nodeNetwork.Visible = true;

 // Create the Sprite used to move around the NodeNetwork
 sprite = SpriteManager.AddSprite(RedBallTexture);
 sprite.TextureScale = 1;
```

Add the following in CustomActivity:

```csharp
 FlatRedBall.Input.Keyboard keyboard = InputManager.Keyboard;

 // Press 1, 2, 3, or 4 to set the Sprite's path for the target node.
 if (keyboard.KeyPushed(Keys.D1))
 {
     nodePath = nodeNetwork.GetPath(
         ref sprite.Position, ref nodeNetwork.Nodes[0].Position);
 }
 if (keyboard.KeyPushed(Keys.D2))
 {
     nodePath = nodeNetwork.GetPath(
         ref sprite.Position, ref nodeNetwork.Nodes[1].Position);
 }
 if (keyboard.KeyPushed(Keys.D3))
 {
     nodePath = nodeNetwork.GetPath(
         ref sprite.Position, ref nodeNetwork.Nodes[2].Position);
 }
 if (keyboard.KeyPushed(Keys.D4))
 {
     nodePath = nodeNetwork.GetPath(
         ref sprite.Position, ref nodeNetwork.Nodes[3].Position);
 }

 // Progress towards the goal.
 if (nodePath != null && nodePath.Count != 0)
 {
     PositionedNode node = nodePath[0];

     if ((sprite.Position - node.Position).Length() < .1f)
     {
         nodePath.RemoveAt(0);
         sprite.Velocity = new Vector3();
     }
     else
     {
         float magnitude = 50;
         var directionToMove = (node.Position - sprite.Position).AtLength(50);
         sprite.Velocity = directionToMove;
     }
 }
```

![NodeNetwork.png](../../../../../media/migrated\_media-NodeNetwork.png)

### Loading a NodeNetwork From .nntx

**The .nntx file format is a standard way to define node networks; however, there is currently no built-in .nntx creating tool supported. Therefore, apps which are interested in working with nntx will need to create their own .nntx files by using the NodeNetworkSave class.**

**If you have an existing .nntx you can load it from-file by adding it to the FlatRedBall Editor or to Visual Studio. If you add it directly to Visual Studio, you must manually load the file:**

1. Add the file to your project in Visual Studio
2. Select the .nntx file once it's in the Solution Explorer.
3. Press F4 or right click and select Properties
4. Select "None" for the Build Action.
5. Select "Copy if newer" for the "Copy to Output Directory".

Add the following using statement:

```csharp
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Content.AI.Pathfinding;
```

Add the following code to Initialize after initializing FlatRedBall:

```csharp
NodeNetworkSave save = NodeNetworkSave.FromFile("sample.nntx");
NodeNetwork nodeNetwork = save.ToNodeNetwork();
nodeNetwork.Visible = true;
```

&#x20;

<figure><img src="../../../../../media/migrated_media-NodeNetworkFromFile.png" alt=""><figcaption></figcaption></figure>

