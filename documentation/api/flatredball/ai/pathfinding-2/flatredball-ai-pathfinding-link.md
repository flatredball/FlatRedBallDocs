## Introduction

Links represent a one-way path to a [PositionedNode](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.PositionedNode.md "FlatRedBall.AI.Pathfinding.PositionedNode"). [PositionedNodes](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.PositionedNode.md "FlatRedBall.AI.Pathfinding.PositionedNode") store a list of links to other [PositionedNodes](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.PositionedNode.md "FlatRedBall.AI.Pathfinding.PositionedNode") internally. These are used by [NodeNetworks](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.NodeNetwork.md "FlatRedBall.AI.Pathfinding.NodeNetwork") to find the shortest path between two nodes.

## One-Way Links

Links are one-way to support wider functionality with pathfinding. In other words, if Node A and B link to each other, then A stores a link to B and B stores a link to A. The reason this is important is because the cost to travel from A to B may not necessarily be the same as the cost to travel from B to A. If A is on higher ground, then traveling to B may be considered easier because the trip is downhill.

## References

-   [FlatRedBall.AI.Pathfinding Namespace](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding_(Namespace).md "FlatRedBall.AI.Pathfinding (Namespace)")
-   [FlatRedBall.AI.Pathfinding.NodeNetwork](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.NodeNetwork.md "FlatRedBall.AI.Pathfinding.NodeNetwork")
-   [FlatRedBall.AI.Pathfinding.PositionedNode](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.PositionedNode.md "FlatRedBall.AI.Pathfinding.PositionedNode")

## Link Members

-   [FlatRedBall.AI.Pathfinding.Link.Cost](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.Link.Cost.md "FlatRedBall.AI.Pathfinding.Link.Cost")
-   [FlatRedBall.AI.Pathfinding.Link.NodeLinkingTo](/frb/docs/index.php?title=FlatRedBall.AI.Pathfinding.Link.NodeLinkingTo.md "FlatRedBall.AI.Pathfinding.Link.NodeLinkingTo")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
