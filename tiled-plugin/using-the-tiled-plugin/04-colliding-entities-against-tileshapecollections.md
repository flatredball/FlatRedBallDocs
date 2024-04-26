# Colliding Entities Against TileShapeCollections

### Introduction

This walk-through shows how to perform collision between entities and TileShapeCollection instances. The two most common types tile-based collisions are:

1. Solid collision - collision which prevents a character from passing through a tile, such as solid walls in a maze
2. True/false tests - used to perform additional logic when collisions occur, such as dealing damage to a character when touching spikes

We'll be looking at both types.

### Creating an Entity

For this guide, we'll create an entity called Player to test our collision code. This entity needs to be collidable (implements ICollidable) and needs logic for movement in response to input.&#x20;

Normally top-down and platformer games in FRB use a Player entity as the character. This is a convention which should be followed in your games to make it easier to follow documentation and to integrate with future FRB improvements.



To create a new entity:

1. In FRB, select the Quick Actions tab
2.  Select **Add Entity**\


    <figure><img src="../../.gitbook/assets/image (3) (1).png" alt=""><figcaption><p>Add Entity button in Quick Actions</p></figcaption></figure>
3. Enter the name **Player**
4. Check the **Circle** checkbox to give the entity a circle collision object
5. Verify that **ICollidable** is checked - this should happen automatically when **Circle** is checked
6. Check the Top-Down option under Input Movement Type to automatically give the Player movement logic
7. Click **OK**

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Creating a Player Entity</p></figcaption></figure>

Notice the **Include lists in all base level screens** check box. We will leave this checked so that we have a list of players in our game screen. This is a good idea, even if your game will be single player. The new entity should appear in the Entities folder in the FRB editor.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Player Entity in FRB</p></figcaption></figure>

Since the Player entity has its ImplementsICollidable set to true, any shape (Circle, Polygon, AxisAlignedRectangle) in the entity will be used in collision functions.

### Adding Player to GameScreen

Our entity is ready to go - we just need to add it to GameScreen. Note that we're adding the Player to the GameScreen rather than Level1 because we want every level to have a player. To add the entity to GameScreen, drag+drop the entity onto the screen:

<figure><img src="../../media/2016-08-2021_February_20_135021.gif" alt=""><figcaption></figcaption></figure>

The Player now appears on in game screen in the PlayerList and can move with the arrow keys.

<figure><img src="../../media/2016-08-2021_February_20_131426.gif" alt=""><figcaption></figcaption></figure>

We can change the starting position of the player by changing the Player1 X and Y values in the FRB editor.

1. Select the Player1 in the GameScreen
2. Click the Variables tab
3. Change X to 200
4. Change Y to -200

![](../../media/2021-02-img\_603171273de31.png)

Now the player appears near the center of the level.

![](../../media/2021-02-img\_6031714ab082d.png)

### Performing Solid Collision

Solid collision can be used to prevent an entity from passing through solid objects on a tile map. In this example we'll be colliding the Player instance against tiles that we set up to have rectangle collision in the previous tutorial. Collision in FlatRedBall is usually performed using CollisionRelationships. A CollisionRelationship is an object which defines what happens when two types of objects overlap (collide). In this case, we'll be creating a CollisionRelationship between our PlayerList and SolidCollision. To create a CollisionRelationship:

1. Expand GameScreen Objects
2. Drag+drop the PlayerList onto the SolidCollision object. This creates a new CollisionRelationship named **PlayerListVsSolidCollision** and automatically selects it.
3. Change the **Collision Physics** to **Move Collision**

<figure><img src="../../media/2016-08-2021_February_20_131433.gif" alt=""><figcaption></figcaption></figure>

As shown in the FRB editor, **Move Collision** prevents the objects from overlapping. If we run the game now, you will notice that the Player can no longer move through the walls.

<figure><img src="../../media/2016-08-2021_February_20_133236.gif" alt=""><figcaption></figcaption></figure>

### Colliding Platformer Entities

This guide focuses on collision between an entity that has basic top-down movement logic. Tile maps are also often used in platformers, and the platformer plugin includes support for colliding against TileShapeCollections. For more information, see the [Controlling a Platformer Entity page](../../documentation/tools/platformer-plugin/03-controlling-a-platformer-entity.md).

### Conclusion

This guide shows how to work with TileShapeCollection to perform solid collision (collision which prevents an entity from passing through the collision area) and non-solid collision (collision which is used to drive custom logic). A typical game may include many TileShapeCollection instances for different types of collision. Although we didn't cover it in this guide, the TileShapeCollection class uses axis-based partitioning for efficient collision. In most cases, even mobile platforms will be able to perform collision against TileShapeCollection instances with tens of thousands of rectangles with very little impact on performance. Developers interested in the details of this partitioning are encouraged to look at the TileShapeCollection source code.
