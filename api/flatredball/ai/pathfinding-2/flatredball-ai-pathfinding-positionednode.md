# PositionedNode

### Introduction

PositionedNodes represent locations within a NodeNetwork which can be travelled to. PositionedNodes have a position and multiple links to other nodes.&#x20;

### Pathfinding

Links can be created between any two PositionedNode objects, and can be one-way or two-way. A link has an associated value, which represents the cost of traveling across that link. Once a set of PositionedNode objects have been created, linked, and then added to a NodeNetwork object, the shortest path from one node to another can be discovered.

#### Creating a Link

To create a link from one node to another, call the **LinkTo** method. This automatically creates a two-way link between the nodes. The **LinkToOneWay** method creates a one-way link from the node this method is called on, to the node that is passed on the method.
