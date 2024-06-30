# Link

### Introduction

Links represent a one-way path to a [PositionedNode](../flatredball-ai-pathfinding-positionednode.md). PositionedNodes store a list of links to other PositionedNodes internally. These are used by [NodeNetworks](../flatredball-ai-pathfinding-nodenetwork/) to find the shortest path between two nodes.

### One-Way Links

Links are one-way to support wider functionality with pathfinding. In other words, if Node A and B link to each other, then A stores a link to B and B stores a link to A. The reason this is important is because the cost to travel from A to B may not necessarily be the same as the cost to travel from B to A. If A is on higher ground, then traveling to B may be considered easier because the trip is downhill.

