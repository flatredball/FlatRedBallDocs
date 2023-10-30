## Introduction

AddAndLinkTiledNode adds a new PositionedNode at the argument X, Y index at the argument DirectionType, or using the default DirectionType specified in the constructor if one isn't specified. This method uses indexes, where 0,0 is the bottom left of the TileNodeNetwork. Each index represents one tile, so if your TileNodeNetwork has a tile size of 16, then an X value of 1 would translate to 16 pixels further to the right than an X index of 0.

## Code Example - Adding nodes manually

The following code adds a few nodes to a TileNodeNetwork using X,Y indexes.

``` lang:c#
void CustomInitialize()
{
    var left = -150;
    var bottom = -150;
    var gridSize = 32;
    var numberOfTilesWide = 30;
    var numberOfTilesTall = 30;

    var tileNodeNetwork = new TileNodeNetwork(left, bottom,
        gridSize, numberOfTilesWide, numberOfTilesTall, DirectionalType.Four);

    // add nodes at some positions at index X, Y
    // Note this is index and not world positions, 
    // so 0,0 will always be the bottom-left location
    // of the node network regardless of its actual world
    // position
    tileNodeNetwork.AddAndLinkTiledNode(0, 0);
    tileNodeNetwork.AddAndLinkTiledNode(1, 0);
    tileNodeNetwork.AddAndLinkTiledNode(2, 0);
    tileNodeNetwork.AddAndLinkTiledNode(3, 0);


    tileNodeNetwork.AddAndLinkTiledNode(2, 1);
    tileNodeNetwork.AddAndLinkTiledNode(3, 1);
    tileNodeNetwork.AddAndLinkTiledNode(4, 1);
    tileNodeNetwork.AddAndLinkTiledNode(5, 1);


    tileNodeNetwork.AddAndLinkTiledNode(2, 2);
    tileNodeNetwork.AddAndLinkTiledNode(2, 3);
    tileNodeNetwork.AddAndLinkTiledNode(2, 4);
    tileNodeNetwork.AddAndLinkTiledNode(2, 5);

    // So we can see the node network changes
    tileNodeNetwork.Visible = true;
}
```

![](/media/2019-08-img_5d63e7723e433.png)

## Code Example - Adding Nodes with the Cursor

The following code can be used to add nodes with the cursor when the PrimaryDown value is true (left mouse button). The following code could be added to CustomActivity of a Screen which has access to a TileNodeNetwork.

    var cursor = GuiManager.Cursor;

    if(cursor.PrimaryDown)
    {
        TileNodeNetwork.WorldToIndex(cursor.WorldX, cursor.WorldY, out int xIndex, out int yIndex);

        var nodeAtPoint = TileNodeNetwork.TiledNodeAt(xIndex, yIndex);
        if(nodeAtPoint == null)
        {
            TileNodeNetwork.AddAndLinkTiledNode(xIndex, yIndex);
            TileNodeNetwork.UpdateShapes();
        }
    }



<figure><img src="/media/2019-08-j5VMYNqadR.gif" alt=""><figcaption></figcaption></figure>


