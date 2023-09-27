## Introduction

Collision shapes can be controlled through the AnimationEditor. This allows collision to align with animation frames.

## Adding Collision to an Animation

The simplest setup for using collisions from an animation requires an animated collidable entity. For example, such an entity would contain a Sprite and an AxisAlignedRectangle as shown in the following entity creation dialog:

![](/media/2022-09-img_6318aeba948b2.png)

Of course, existing entities (such as Player) can also be animated using collision so long as they contain an animated Sprite and they implement ICollidable.

![](/media/2022-09-img_6318af128fb39.png)

For this example we will use the Player object as an example, but these concepts can be applied to any entity. Animation collisions can be defined in the AnimationEditor. Each frame can contain one or more shapes. To add a shape to a frame:

1.  Open the AnimationEditor

2.  Select a frame which should have collision

3.  Right-click on the frame in the tree view and select **Add AxisAlignedRectangle**. Note that at the time of this writing only AxisAlignedRectangles are supported, but future versions of shapes will be added.

    ![](/media/2022-09-img_6318afa81afc7.png)

4.  Once added, the AxisAlignedRectangle displays in the bottom preview window

    ![](/media/2022-09-img_6318b05279e63.png)

5.  The AxisAlignedRectangle's properties can be modified in the property grid [![](/wp-content/uploads/2022/09/07_08-53-49.gif.md)](/wp-content/uploads/2022/09/07_08-53-49.gif.md)

Changes to shapes will automatically be saved to disk. The example above shows an animation with a single frame, but since each frame can contain rectangles, then this allows the collision size to change frame-by-frame. [![](/wp-content/uploads/2022/09/07_09-30-33.gif.md)](/wp-content/uploads/2022/09/07_09-30-33.gif.md)

## Using Animation Collision in Code

Once an animation contains shapes, the shapes can be used at runtime. The easiest way to implement this is to use the SetValues method on the frame's ShapeCollection as shown in the following snippet:

    private void CustomActivity()
    {
        this.SpriteInstance.CurrentFrame?.ShapeCollectionSave?.SetValuesOn(
            this.Collision, this, createMissingShapes:true);

        // This is needed if you want to see the rectangle visibly. It is not necessary
        // for proper collision functionality.
        this.ForceUpdateDependenciesDeep();

    }

This code automatically updates the collision to match how it is laid out in the AnimationEditor.

![](/media/2022-09-img_6318b594379f0.png)

### Names Matching

Entities and animation frames can each contain multiple shapes. To use the SetValuesOn method, the names between the two must match. In the example above, the rectangles on the animation and entity are both called AxisAlignedRectangleInstance (the default name).

![](/media/2022-09-img_6318b64256fe2.png)

Using matching names is especially important if you intend to have multiple shapes per frame of animation.

### Missing Shape Behavior

Animation frames which do not have any shapes will not affect the collision in the entity. In the example above the CharacterIdleRight animation contains a frame which defines a rectangle. When this animation plays, the rectangle size will be applied. When other animations are played, the rectangle will remain the same size as was set by CharacterIdleRight. Keep this in mind, as creating animations which only have some frames defining a rectangle may result in unexpected behavior. The following animation shows the behavior of the rectangle when only the idle right animation defines the shape. Notice that the rectangle grows when the player faces to the right, and then remains the same size for all other animations: [![](/wp-content/uploads/2022/09/07_09-23-17.gif.md)](/wp-content/uploads/2022/09/07_09-23-17.gif.md)

## Multiple Shapes per Frame

As mentioned above, multiple shapes can be added per frame. This can be useful if you have different subcollision behaviors in your game. For example, your Player may have a shape for its entire body, and one shape for feet so the player can stomp on enemies.

![](/media/2022-09-img_6318ba03080c3.png)

In this case you would want to also add the same shapes in your entity so that the code shown above could be used to automatically manage the rectangle positions and sizes.

![](/media/2022-09-img_6318ba37dc88d.png)
