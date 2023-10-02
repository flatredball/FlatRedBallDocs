# flatredball-ai-pathfinding-positionednode

### Introduction

The most important aspect of a PositionedNode object, is that it contains links to other PositionedNode objects within the NodeNetwork. They can also represent literal locations within the game world.

### Pathfinding

Links can be created between any two PositionedNode objects, and can be one-way or two-way. A link has an associated value, which represents the cost of traveling across that link. Once a set of PositionedNode objects have been created, linked, and then added to a NodeNetwork object, the shortest path from one node to another can be discovered.

#### Creating a Link

To create a link from one node to another, call the **LinkTo** method. This automatically creates a two-way link between the nodes. The **LinkToOneWay** method creates a one-way link from the node this method is called on, to the node that is passed on the method.

### References

* [FlatRedBall.AI.Pathfinding Namespace](../../../../../frb/docs/index.php)
* [FlatRedBall.AI.Pathfinding.Link](../../../../../frb/docs/index.php)
* [FlatRedBall.AI.Pathfinding.NodeNetwork](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
