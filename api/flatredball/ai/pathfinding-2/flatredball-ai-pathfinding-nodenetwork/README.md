# flatredball-ai-pathfinding-nodenetwork

### Introduction

NodeNetworks are a collection of [PositionedNodes](../../../../../../frb/docs/index.php) which are linked to eachother using [Links](../../../../../../frb/docs/index.php). NodeNetworks are used for pathfinding.

### Loading a NodeNetwork

**Files Used:** [Sample.nntx](../../../../../../frb/docs/images/5/59/Sample.nntx) NodeNetworks can be loaded from .nntx files. Download the file and:

* Drag the file into your Solution. If you decide to use the Content Pipeline, remember to not include the extension when loading the file. This sample will use from-file loading. To load from-file:
  * Select the .nntx file once it's in the Solution Explorer.
  * Press F4 or right click and select Properties
  * Select "None" for the Build Action.
  * Select "Copy if newer" for the "Copy to Output Directory".

Add the following using statement:

```
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Content.AI.Pathfinding;
```

Add the following code to Initialize after initializing FlatRedBall:

```
NodeNetworkSave save = NodeNetworkSave.FromFile("sample.nntx");
NodeNetwork nodeNetwork = save.ToNodeNetwork();
nodeNetwork.Visible = true;
```

![NodeNetworkFromFile.png](../../../../../../media/migrated\_media-NodeNetworkFromFile.png) For more information on file loading in FlatRedBall, see the [FlatRedBall File Types](../../../../../../frb/docs/index.php) wiki entry.

### Creating a NodeNetwork

The following code creates a simple NodeNetwork and a [Sprite](../../../../../../frb/docs/index.php). Pressing the 1, 2, 3, or 4 [keys](../../../../../../frb/docs/index.php) causes the [Sprite](../../../../../../frb/docs/index.php) to move toward a given node on the NodeNetwork. This example shows simple node creation, using the node for pathfinding, and how to make the node visible. Add the following using statement:

```
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Input;
```

Add the following at class scope:

```
NodeNetwork nodeNetwork;
Sprite sprite;
List<PositionedNode> nodePath;
```

Add the following in Initialize after initializing FlatRedBall:

```
 // Instantiate the NodeNetwork.
 nodeNetwork = new NodeNetwork();

 // Create the 4 nodes.
 PositionedNode node = nodeNetwork.AddNode();
 node.Position = new Vector3(-5, 5, 0); // top left

 node = nodeNetwork.AddNode();
 node.Position = new Vector3(5, 5, 0); // top right

 node = nodeNetwork.AddNode();
 node.Position = new Vector3(5, -5, 0); // bottom right

 node = nodeNetwork.AddNode();
 node.Position = new Vector3(-5, -5, 0); // bottom left

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
 sprite = SpriteManager.AddSprite("redball.bmp");
```

Add the following in Update:

```
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
         float magnitude = 3;

         double angle = Math.Atan2(node.Y - sprite.Y, node.X - sprite.X);

         sprite.XVelocity = (float)Math.Cos(angle) * magnitude;
         sprite.YVelocity = (float)Math.Sin(angle) * magnitude;
     }
 }
```

![NodeNetwork.png](../../../../../../media/migrated\_media-NodeNetwork.png)

### References

#### Pathfinding

* [FlatRedBall.AI.Pathfinding Namespace](../../../../../../frb/docs/index.php)
* [FlatRedBall.AI.Pathfinding.Link](../../../../../../frb/docs/index.php)
* [FlatRedBall.AI.Pathfinding.PositionedNode](../../../../../../frb/docs/index.php)

#### Sprite

* [FlatRedBall.Sprite](../../../../../../frb/docs/index.php)

#### Input

* [FlatRedBall.Input.Keyboard](../../../../../../frb/docs/index.php)

&#x20;
