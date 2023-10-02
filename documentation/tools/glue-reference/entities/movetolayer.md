# movetolayer

### Introduction

The MoveToLayer method will place the entity on a Layer (if it is not already on a Layer) or will remove the entity from its current Layer and place it on the argument Layer. This method will assign the entity's LayerProvidedByContainer property, and will move all contained visual elements (such as Sprites) to the new layer.

### Example Code

The following code moves an entity to a layer called HudLayer :

```lang:c#
EntityInstance.MoveToLayer(HudLayer);
```

&#x20;
