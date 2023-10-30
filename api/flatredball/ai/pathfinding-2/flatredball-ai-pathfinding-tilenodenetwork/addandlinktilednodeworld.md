# addandlinktilednodeworld

### Introduction

AddAndLinkTiledNodeWorld adds a new node at the given position, and links it to any adjacent nodes following the DirectionalType specified in the argument call, or using the default DirectionalType specified in the TileNodeNetwork's constructor.

### Code Example: Adding Nodes by Clicking

The following code can be added to a screen to allow the user to click the mouse and add new nodes. Newly-created nodes will be connected to adjacent nodes using the DirectionType specified in the constructor (four-way).

```lang:c#
// Define the TileNodeNetwork at class scope
// so we can access it in both CustomInitialize
// and CustomActivity
TileNodeNetwork tileNodeNetwork;

void CustomInitialize()
{
    var left = -200;
    var bottom = -200;
    var gridSize = 32;
    var numberOfTilesWide = 40;
    var numberOfTilesTall = 40;

    tileNodeNetwork = new TileNodeNetwork(left, bottom,
        gridSize, numberOfTilesWide, numberOfTilesTall, DirectionalType.Four);

    // So we can see the node network changes
    tileNodeNetwork.Visible = true;

    // So we can see the cursor
    FlatRedBallServices.Game.IsMouseVisible = true;
}

void CustomActivity(bool firstTimeCalled)
{
    var cursor = FlatRedBall.Gui.GuiManager.Cursor;

    if(cursor.PrimaryClick)
    {
        var worldX = cursor.WorldXAt(0);
        var worldY = cursor.WorldYAt(0);

        // See if there is an existing node there:
        var existingNode = tileNodeNetwork.TiledNodeAtWorld(worldX, worldY);

        if(existingNode == null)
        {
            tileNodeNetwork.AddAndLinkTiledNodeWorld(worldX, worldY);

            // So we can see the newly-added shapes
            tileNodeNetwork.UpdateShapes();
        }
    }
}
```



<figure><img src="../../../../../../media/2019-08-2019-08-26\_07-59-23.gif" alt=""><figcaption></figcaption></figure>

   &#x20;
