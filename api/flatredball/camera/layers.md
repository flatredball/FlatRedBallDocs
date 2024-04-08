# Layers

The Layers property contains all of the [Layers](../graphics/layer/) specific to this Camera. Layers which belong to a camera are drawn only on this camera. Camera-speicfic layers are useful when making split-screen games which should show visuals specific to one of the screens such as a player's HUD.

### Default Layer

Cameras will have one Layer in the Layers property by default. This can be accessed in one of two ways:

```csharp
var defaultLayer = CameraInstance.Layers[0];
```

or

```csharp
var defaultLayer = CameraInstance.Layer;
```

Notice that the first Layer in Layers is equivalent to the Layer property.&#x20;

This Layer is added for convenience, but it is not automatically used unless objects are placed on this Layer explicitly. In other words, objects (such as FlatRedBall Sprites) which are added to their respective managers are drawn _unlayered_ by default. Note that this differs from Gum, where all objects are always added to a Layer.
