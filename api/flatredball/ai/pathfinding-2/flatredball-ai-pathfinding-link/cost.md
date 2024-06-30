# Cost

The Cost member represents the difficulty in traveling the node. Cost can be based on distance, but can also be adjusted to represent terrain difficulty or other concepts related to making decisions about which path to take. Examples include:

* Difficulty in crossing due to terrain
* Difficulty in crossing due to risk (enemies, thieves)
* Resources required to perform a particular action (if node networks are used abstractly)

The cost property is used by the [NodeNetwork](../flatredball-ai-pathfinding-nodenetwork/) to find the most efficient path from one node to the next.
