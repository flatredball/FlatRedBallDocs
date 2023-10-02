# artificialintelligenceeditor-wiki-tutorials-editing-node-networks

### Introduction

Nodes and links between nodes are stored in a "node network" file (.nntx) and can be loaded in the FlatRedBall Engine for pathfinding.

### Adding a Node

To add a Node:

* Click the "Add" menu strip item.
* Click the "New Node" item. A new node will appear in the scene view as a solid green triangle.

Nodes can also be created by copying grabbed nodes.

* Select a node.
* Press CTRL+C. This creates a duplicate node in the same position.
* Move the node - the 2nd node will remain its same position.

**The first node of your level must be inside a collision map: inside an enclosed area polygons from the .plystx file**

### Editing a Node

To move a node:

* Click the "Move" button on the [Tools Window](../../../frb/docs/index.php)
* Push and hold the left mouse button down. Move the mouse while the left mouse button is down to move the selected node.

### Deleting a Node

To delete a node:

* Click on the desired node to delete. The node will show the link icon to reflect that it is selected.
* Press the Delete key to delete the selected node.

### Creating a Link

Links connect two links and indicate that it is possible to travel directly between one node and another. Therefore, links require at least two nodes to exist.

To create a link:

* Click on one of the the two nodes that will be linked. The Node Icon will appear. Push and drag on the Node Icon. As long as the mouse button is held down a line will be drawn from the selected Node to the cursor.
* Move the mouse over the node to connect to.
* Release the mouse button. The line will now connect to the second node. The nodes can now be moved and the links will update appropriately.
