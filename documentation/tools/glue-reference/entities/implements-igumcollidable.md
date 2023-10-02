## Introduction

Marking an entity as implementing IGumCollidable enables the creation of shapes for standard FlatRedBall collision using a Gum object. This can be useful for visually creating complex shapes in Gum, for aligning shapes with visuals created in Gum, or for implementing collision animation using the Gum animation system.

## Example - Creating Collision in Gum

The following example shows how to create shapes in Gum and use them as the entity's collision. This example will use a default Player using the top-down controls, however it can be used on any type of entity.

![](/media/2022-01-img_61db04a727f11.png)

First, we'll delete the existing collision from the entity since it is not needed - Gum will be responsible for adding collision: [![](/media/2022-01-09_08-53-22.gif)](/media/2022-01-09_08-53-22.gif) Next, we'll define a Gum object which has collision. Keep in mind - any visuals will also be rendered on the entity, but for this example we'll use only shapes for collision.

![](/media/2022-01-img_61db05642c98a.png)

Gum objects can contain Circle and Rectangle instances, and these should not be rotated. Notice that the component uses the center alignment. The center of the FlatRedBall entity will line up with the center of the Gum entity. Once a Gum component has been created, it can be added to the Player object:

1.  Right-click on the Player's **Objects** folder
2.  Select **Add Object**
3.  Select the **Gum** Object Type
4.  Scroll down or search for the name of your Gum component - in this case **PlayerGumComponentRuntime**
5.  Click **OK**

[![](/media/2022-01-09_08-57-34.gif)](/media/2022-01-09_08-57-34.gif) Finally, verify that the Entity is both an ICollidable and IGumCollidable:

1.  Select the entity
2.  Select the **Properties** tab
3.  Set ImplementsICollidable to True (this is usually true if the Player object was created by the wizard)
4.  Set **ImplementsIGumCollidable** to **True**

![](/media/2022-01-img_61db06946c1d4.png)

Now the Player object will have its Collision populated by any Circle and Rectangle instances from any Gum objects (in this case PlayerGumComponentRuntimeInstance). Setting the collision to Visible can be helpful for debugging. Add this code in the Player's CustomInitialize method:

    private void CustomInitialize()
    {
        this.Collision.Visible = true;
    }

The Collision ShapeCollection will be visible and collides with solid collision. [![](/media/2022-01-09_09-59-12.gif)](/media/2022-01-09_09-59-12.gif)
