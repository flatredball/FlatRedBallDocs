# Layers

The Layers property contains all of the [Layers](../graphics/layer/) specific to this Camera. Layers which belong to a camera are drawn only on this camera. Camera-specific layers are useful when making split-screen games which should show visuals specific to one of the screens such as a player's HUD.

### Default Layer

Cameras have one Layer in the Layers property by default. This can be accessed in one of two ways:

```csharp
var defaultLayer = CameraInstance.Layers[0];
```

or

```csharp
var defaultLayer = CameraInstance.Layer;
```

The Layer property is just an alias for Layers\[0].&#x20;

This Layer is added for convenience, but it is not automatically used unless objects are placed on this Layer explicitly. In other words, objects (such as FlatRedBall Sprites) which are added to their respective managers are drawn _unlayered_ by default.
