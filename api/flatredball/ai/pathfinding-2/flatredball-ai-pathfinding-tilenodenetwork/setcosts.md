## Introduction

Many games which have tile maps which also require pathfinding often include different terrain types. For example, a map may include regular terrain, water, and mountains. Terrain is important because certain units may be able to travel over certain terrain faster than other terrain. The SetCosts method allows for specifying the cost of travelling over certain terrain types quickly without modifying the cost of travelling across each Link in the NodeNetwork manually.

## How it works

The SetCosts method requires the following steps:

1.  The costs of each terrain type must be defined. These are defined in a float array
2.  Each point on the tile which is not of the default type must have its terrain type set through the PositionedNode's PropertyField variable.
3.  The TileNodeNetwork's SetCost method must be called with the float array containing the cost of each terrain as the argument.

## Code Example

The following pieces of code show how a TileNodeNetwork can be set up for different terrain types. First the terrain types must be defined. Since they will be reused in multiple places we'll use an enum:

       public enum TileType
       {
           Mud,
           Water,
           Lava,
           Spikes,
           Quicksand
       }

The following code assumes that tileNodeNetworkInstance is a valid TileNodeNetwork instance which has already hadd its nodes added:

     // let's make a wall of lava
     for (int i = 3; i < 8; i++)
     {
         float xCoord = i;
         float yCoord = 3;
         PositionedNode node = tileNodeNetwork.GetClosestNodeTo(xCoord, yCoord);
         // The PropertyField is a bitfield so we need to
         // shift over the number 1 by the tile type.
         // Because of this we're limited to values between 0 and 31 (inclusive)
         node.PropertyField = (1 << (int)(TileType.Lava));
     }
     // Now let's set the costs of different terrain:
     float[] costs = new float[32];
     costs[(int)TileType.Lava] = 100;
     costs[(int)TileType.Mud] = 3;
     costs[(int)TileType.Quicksand] = 6;
     costs[(int)TileType.Spikes] = 50;
     costs[(int)TileType.Water] = 1.5f;
     tileNodeNetwork.SetCosts(costs);
