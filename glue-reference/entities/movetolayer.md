# MoveToLayer

### Introduction

The MoveToLayer method moves the calling entity instance on a Layer (if it is not already on a Layer). If the entity is already on a layer it is removed from its current Layer and place on the argument Layer. This method assigns the entity's LayerProvidedByContainer property, and moves all contained visual elements (such as Sprites) to the new Layer.

### Example Code

The following code moves an entity to a layer called HudLayer :

```csharp
EntityInstance.MoveToLayer(HudLayer);
```

### MoveToLayer Details

If an Entity calls MoveToLayer, the following changes are made:

* The Layer's LayerProvidedByContainer is assigned
* Every visual object is moved to the argument layer. This includes Sprites, shapes such as Circle and AxisAlignedRectangle, and FlatRedBall Texts. This also includes any objects rendered by IDrawableBatches such as Gum and Tiled LayeredTileMaps

Note that individual objects can be moved to a layer, so the visuals in an Entity can span multiple layers.

For example, to move a Circle that belongs to an entity to a new Layer, the ShapeManager's AddToLayer can be called:

```csharp
var circle = EntityInstance.CircleInstance;
bool makeAutomaticallyUpdated = false;
ShapeManager.AddToLayer(circle, DesiredLayer, makeAutomaticallyUpdated);
```

For more information see the [ShapeManager.AddToLayer](../../api/flatredball/math/geometry/shapemanager/addtolayer.md) page.

### Moving Parts of an Entity to Different Layers

Entities can span multiple Layers so that the render order of each part of an entity can be controlled individually. For example, an Entity may be primarily drawn un-layered (default), but its HealthBar instance may be placed on a different Layer.

This type of situation usually occurs when a part of an Entity should be moved to a Layer that is owned by a Screen, such as GameScreen. In this case, GameScreen should be responsible for initiating the movement and for passing the destination layer.

For example, consider a situation where a Player entity has a HealthBarInstance. The Player may provide a method for movign the HealthBarInstance to a different layer as shown in the following code block:

```csharp
public void MoveHealthBarToLayer(Layer layer)
{
    HealthBarinstance.MoveToLayer(layer);
}
```

The Screen that own the Player instance would be responsible for calling this method, as shown in the following code:

```csharp
void CustomInitialie()
{
    PlayerInstance.MoveHealthBarToLayer(HudLayer);
}
```
