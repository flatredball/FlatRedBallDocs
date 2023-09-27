## Introduction

OccupyTileWorld marks the tile at the given location (in world coordinates) as occupied. Occupied tiles can have an occupier which can be checked with the GetOccupier function. Note that occupied tiles will still be considered in pathfinding.

## Code Example

The following code shows how to check if a tile is occupied, and if so, to move a character to the given tile. To keep the code shorter, it only considers moving in one direction.

``` lang:c#
// Assumes Player is a valid entity
if(InputManager.Keyboard.KeyDown(Keys.Right))
{
    var isTileOccupied = tileNodeNetwork.IsTileOccupiedWorld(
        Player.X + 16, // assumes tiles are 16 pixels
        Player.Y);

    if(!isTileOccupied)
    {
        // un-occupy the current tile:
        tileNodeNetwork.Unoccupy(this);

        tileNodeNetwork.OccupyTileWorld(
            Player.X + 16, 
            Player.Y,
            Player);

        // Move the player to the tile, either by setting the position
        // directly, or by setting velocity or doing some other form of 
        // interpolation.
    }
}
```

 
