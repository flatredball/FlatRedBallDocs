## Introduction

A ShapeCollectionSave instance which can be used to apply a frame's collision to an entity. By default this is null.

## Example - Setting an Entity's Collision

The most common usage is to add shapes to an AnimationChainListSave file (.achx) and to apply animations to a collidable Entity. The following example assumes that shapes have been added to a frame in the AnimationEditor.

![](/media/2022-07-img_62db40e692943.png)

    // in an Entity's CustomActivity:
    SpriteInstance.CurrentFrame?.ShapeCollectionSave?.SetValuesOn(this.Collision, this, true);

    // Optional, if you want to see the shapes visually:
    this.ForceUpdateDependenciesDeep();
    this.Collision.Visible = true;

The code performs null checks (through the null coalescing operator), since a frame may not have collision data. If a frame does not have collision data, then the collision will not be modified. Note that if one frame does have collision, but subsequent frames do not, then the collision will remain unchanged when the later frames are played. Therefore, if one frame has collision, other frames should as well to avoid confusing behavior.
