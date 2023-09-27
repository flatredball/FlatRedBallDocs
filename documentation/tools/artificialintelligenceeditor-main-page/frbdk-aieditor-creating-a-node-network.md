## Introduction

The AIEditor shares functionality with the rest of the FRBDK, so if you are familiar with these applications then you will be famliar with much of the functionality.

Before moving into the functionality of the tool there are a few tems that should be covered.

-   Node - A node is a named location in world coordinates. Nodes identify positions in the node network.
-   Link - A connection between one node to another. Nodes store references to nodes and the cost to move between nodes.
-   Node Network - A node network is a collection of nodes. Node networks save to .nntx files which contain nodes and links.
-   Pathfinding - Pathfinding is the process of identifying the list of nodes that must be followed to move from one point to another.

## Creating Nodes

When you first open the AIEditor you will have a blank node network. All non-empty node networks have at least one node. To create a node:

    Select Add->New Node

You should see a triangle appear in the middle of the screen. This represents a new node. Nodes can be moved by first clicking the move button (button with an M on it) on the Tools window, then clicking and dragging on the node.

Move the first node and create a second. You should now have 2 nodes.

## Creating Links

When a node is selected it will have a link icon next to it.

![LinkIcon.png](/media/migrated_media-LinkIcon.png)

To create a link between two nodes, first select one node, then push and drag on the link icon. You will see a white line connecting the selected node and the tip of the cursor. While continuing to hold the left mouse button down, move over the node that you wish to link to, then release the mouse button.

A white line will connect the two nodes representing a link between them. Notice that if you move one of the nodes the link will display its distance in real time.

## Accurately Positioning Nodes

Node Networks are usually used for AI pathfinding through levels. To assist in placing node networks the AIEditor supports loading .scnx files. These .scnx files can represent the levels that are going to be used for navigation. This allows node networks to be built on top of the levels that they will be used in for improved accuracy and development speed. To load a scene select:

    File->Load Scene

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
