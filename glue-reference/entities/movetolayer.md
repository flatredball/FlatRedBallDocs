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

* The Layer's LayerProvidedByContainer is called
* Every visual object is moved to the argument layer. This includes Sprites, shapes such as Circle and AxisAlignedRectangle, and FlatRedBall Texts

Note that individual objects can be moved to a layer, so the visuals in an Entity can span multiple layers.

For example, to move a Circle that belongs to an entity to a new Layer, the ShapeManager's AddToLayer can be called:

```csharp
var circle = EntityInstance.CircleInstance;
bool makeAutomaticallyUpdated = false;
ShapeManager.AddToLayer(circle, DesiredLayer, makeAutomaticallyUpdated);
```

For more information see the [ShapeManager.AddToLayer](../../api/flatredball/math/geometry/shapemanager/addtolayer.md) page.
