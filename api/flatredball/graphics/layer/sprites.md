# Sprites

### Introduction

The Sprites collection provides access to all ordered Sprites stored within this layer. This is a read-only collection so it cannot be directly modified through the layer. Note that this list only contains ordered sprites. Z-buffered sprites are stored in the Layer's ZBufferedSprites property.

### Code Example

The Sprites property can be used to check if a Sprite is being displayed on a layer. The following code shows how to check if a Sprite is on a Layer.

```csharp
if(LayerInstance.Sprites.Contains(SpriteInstance))
{
    // The sprite is contained on LayerInstance
}
```
