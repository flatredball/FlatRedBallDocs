# pathfinding-2

### Overview

The FlatRedBall.AI.Pathfinding namespace provides implementation of pathfinding. Pathfinding is used in determining the best path from one location to another.

#### [NodeNetwork](../../../../../frb/docs/index.php) Class

The NodeNetwork class provides the facility to group together PositionedNode items, and discover the best paths between them. Currently, only the [A\*](../../../../../frb/docs/index.php) pathfinding algorithm is implemented.

#### [PositionedNode](../../../../../frb/docs/index.php) Class

PositionedNode represents a location within the NodeNetwork.

#### [Link](../../../../../frb/docs/index.php) Class

PositionedNodes are linked to each other by Link objects. Link objects represent the cost from one PositionedNode to another.

###
