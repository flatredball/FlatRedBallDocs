## Introduction

The FRB Editor supports the creation and management of CollisionRelationship objects. This document covers the features provided by the FRB Editor, and explains common scenarios where you may need to interact with the CollisionsRelationships in code. Most cases can be handled by CollisionRelationships in the FRB Editor; however, more advanced situations can be handled in code. For information about creating and working with CollisionRelationships in code, see the [CollisionManager page](/documentation/api/flatredball/flatredball-math/collision/collisionmanager.md).

## What is a CollisionRelationship?

CollisionRelationships define how to respond when two types of objects collide (overlap). Examples of reactions to overlapping objects include:

-   A player must take damage when colliding with a bullet
-   A bullet must be destroyed when colliding with a wall
-   An enemy must be moved so that it doesn't overlap the same space as another enemy
-   A car must reduce its maximum speed when driving over grass

Even simple games will require multiple relationships, and larger games may include dozens of relationships. Glue makes the creation and management of these much simpler than management purely in code.

## What Types of Objects Can be Used in CollisionRelationships?

Collision relationships can be created between:

-   Lists of entities which implement ICollidable
-   Individual Entity instances which implement ICollidable
-   TileShapeCollections
-   ShapeCollections (regular, as opposed to TileShapeCollections)

All CollisionRelationships will at include at least one Entity or Entity list, so it is important to mark Entities which you intend to use in relationships as ICollidable. For information on ICollidable entities, see the [ICollidable Entity page](/documentation/tools/glue-reference/entities/glue-reference-entities-implements-icollidable.md).

## Creating a CollisionRelationship

CollisionRelationships can be created a few ways. Typically collision relationships are added to a screen, such as a base GameScreen. In this example we will use a screen called GameScreen which already has a few objects:

-   PlayerList (a list of Player entities)
-   BulletList (a list of Bullet entities)
-   EnemyList (a list of Enemy entities)
-   SolidCollision (a TileShapeCollection)

![](/media/2023-08-img_64e425d030d81.png)

Note that the TileShapeCollection may have its [SetByDerived](/documentation/tools/glue-reference/objects/glue-reference-objects-setbyderived.md) value set to true. This allows the creation of CollisionRelationships in a base Screen even though the TileShapeCollection is created in a derived Screen.

### Option 1 - Drag+drop

You can drag+drop one collidable object (such as a list) onto another collidable object (such as another list or a TileShapeCollection) so long as the two objects are in the same screen. This will create a CollisionRelationship between the two objects. [![](/wp-content/uploads/2019/08/21_21-07-45.gif)](/wp-content/uploads/2019/08/21_21-07-45.gif)

### Option 2 - Collision Tab

The Collision tab displays when a collidable object or list is selected

![](/media/2023-08-img_64e426fdc1df4.png)

The image above displays the **Collision** tab for the **BulletList**. Notice that the **BulletList** can collide with any of the other collidable objects in the **GameScreen** including itself. Adding collision is easy - just click the **Add** button next to the object in the Collision tab to create a new relationship. For example, clicking on the **Add** button next to **EnemyList** creates a relationship between **BulletList** and **EnemyList**. [![](/wp-content/uploads/2019/08/21_21-10-50.gif)](/wp-content/uploads/2019/08/21_21-10-50.gif)

### Option 3 - Create CollisionRelationship Object Manually

CollisionRelationships are regular Objects which can be created through the right-click menu. To create a CollisionRelationship through the right-click menu:

1.  Right-click on a Screen's **Objects**
2.  Select **Add Object**
3.  Verify **FlatRedBall or Custom Type** is selected
4.  Select the **CollisionRelationship** type
5.  Click **OK**

[![](/wp-content/uploads/2019/08/21_21-12-46.gif)](/wp-content/uploads/2019/08/21_21-12-46.gif) In this case the newly-created CollisionRelationship will not yet reference any collidable objects in the screen, and the game will not compile until the objects in the relationship are set (as shown in the next section).

## Editing a CollisionRelationship in Glue

Once a CollisionRelationship is created, it can be edited by selecting it under the Screen's **Objects** folder and clicking the **Collision** tab.

[![](/wp-content/uploads/2019/08/21_21-14-36.gif)](/wp-content/uploads/2019/08/21_21-14-36.gif)

A CollisionRelationship objects can be changed using the two drop-downs. Note that if the **Auto-name Relationship** checkbox is checked, the name of the relationship will automatically change when either of the two objects in the relationship changes. Of course, if you create CollisionRelationships using either the **Add** button or the drag-drop method, you do not need to set the object types.

### Subcollision

Subcollision allows specifying a specific shape within a collidable entity to use when performing collision. This is useful if an entity includes multiple shapes, each for different purposes. For example, an enemy may have a circle for solid collision (preventing the enemy from walking through walls) but it may also have a line for line-of-sight collision. In this case, we do not want the line to collide against the walls, so we would specify that only the enemy's circle should collide with the walls. All available shapes for subcollisions appear in the **Subcollision** dropdowns for each object. Note that changing the subcollision will also rename the CollisionRelationship if the **Auto-name Relationship** option is checked. [![](/wp-content/uploads/2019/08/2019-08-21_09-26-26.gif)](/wp-content/uploads/2019/08/2019-08-21_09-26-26.gif)

### Collision Physics

Physics can be set up through the Collision tab using one of three options:

-   **No Physics** - Colliding objects will not automatically be moved by the CollisionRelationship.

    ![](/media/2019-08-img_5d5cb7d56fab4.png)

-   **Move Collision** - Colliding objects will be separated if a collision occurs using their relative mass values. The most common values for **First Mass** and **Second Mass** are 1, 1 if both objects have equal mass and 0, 1 if the first object should not be able to push the second (in the case of colliding against a solid TileShapeCollection)

    ![](/media/2019-08-img_5d5cb850a57b1.png)

    -   **First Mass** - the mass of the first object in the relationship (the mass of enemies) relative to the mass of the second object. If this object should not be able to push the second object, it should have a mass of 0.
    -   **Second Mass** - the mass of the second object relative to the first object. If this object should not be able to push the first object, it should have a mass of 0.

-   **Bounce Collision** - Colliding objects will be separated if a collision occurs. They will also have their velocity adjusted in response to the elasticity value. An elasticity value of 1 will preserve momentum. An elasticity of 0 will be an *inelastic* collision - where momentum is lost.

    ![](/media/2019-08-img_5d5cb8df8e850.png)

    -   **First Mass/Second Mass** - see Move collision
    -   **Elasticity** - A multiplier for an object's velocity when it collides. A value of 0 will absorb momentum. A value of 1 will preserve momentum. A value greater than 1 will add momentum.

## Collision Events

In some cases games will need to perform custom logic when a collision occurs. For example:

-   A Player entity takes damage when colliding with a bullet
-   The Bullet entity being destroyed when colliding with a wall
-   An Enemy entity's movement speed being slowed when colliding with mud TileShapeCollection.

Collision events can be created by dropping a CollisionRelationship on a Screen's **Events** folder. [![](/wp-content/uploads/2019/08/2019-08-21_07-37-57.gif)](/wp-content/uploads/2019/08/2019-08-21_07-37-57.gif) For more information on Glue events, see the [Glue Events page](/documentation/tools/glue-reference/events.md). Like all other events, collision events can be edited in code. In the example above, the **GameScreen.Event.cs** file now includes an function OnEnemyListVsPlayerListCollisionOccurred  which is called whenever a collision occurs between an Enemy and Player instance. Make sure to add code to **\<YourGameScreen\>.Event.cs** and not the **\<YourScreen\>.Genererated.Event.cs**.

![](/media/2019-08-img_5d5d4a287ca7b.png)

Notice that the CollisionRelationship used in this example is between a list of Enemies and a list of Players, but the event is raised for a single Enemy and a single Player. Since each enemy may collide with each player, the event method may get raised multiple times per frame. Every time the event is raised, the arguments tell you which two objects collided.

### Code Example - Destroying Entities in Collision

For example, in the code above, you could destroy either the enemy (which is called first) or the player (which is called second) in the event. To destroy the enemy, you can do the following code:

    void OnEnemyListVsPlayerListCollisionOccurred (Entities.Enemy first, Entities.Player second)
    {
        first.Destroy();
    }

### Code Example - Detecting TileShapeCollection Collided Shapes

To identify which shapes an entity collided against in a TileShapeCollection, the LastCollisionAxisAlignedRectangles property can be used. For more information see the LastCollisionAxisAlignedRectangles [page](/documentation/tools/tiled-plugin/glue-gluevault-component-pages-tile-graphics-plugin-tileshapecollection/lastcollisionaxisalignedrectangles.md).

## Manual Collision Relationships

CollisionRelationships created in Glue will be automatically managed and will automatically perform their every-frame logic. In some cases games need to manually perform collision logic. For example, a game may need to first reset variables on an entity before collision logic is performed for that frame. In that case, the CollisionRelationships created in Glue can be modified in the CustomInitialize  method of the **GameScreen**. For example, to disable the EnemyListVsPlayerList CollisionRelationship, the following code can be used:

``` lang:c#
void CustomInitialize()
{
    EnemyListVsPlayerList.IsActive = false;
}

void CustomActivity(bool firstTimeCalled)
{
    // before calling collision, reset the Enemy's DidCollide:
    foreach(var enemy in EnemyList)
    {
        enemy.DidCollide = false;
    }
    // now do the collision. This assumes that the
    // DidCollide property gets set or used in the event
    // handling method for this relationship:
    EnemyListVsPlayerList.DoCollisions();
}
```

   
