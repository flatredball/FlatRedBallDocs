# removelayer

### Introduction

The RemoveLayer function removes the current Layer from the SpritManager. This function can be used to remove Layers once they are no longer needed (such as Layers created in custom code), or to move Layers between different [Cameras](../../../../frb/docs/index.php).

### Code Example

The following code shows how to create and destroy a Layer in custom code. This code is similar to code created by Glue in generated code when a Layer is added to a Screen:

```
// At class scope:
Layer myLayer;

// In CustomInitialize:
myLayer = SpriteManager.AddLayer();

// In CustomDestroy:
SpriteManager.RemoveLayer(myLayer);
```

### Moving Layers between containers

Layers can be contained in [Cameras](../../../../frb/docs/index.php) and in the SpriteManager (not associated with any Camera). For example the following code would remove a Layer from the SpriteManager and move it to a [Camera](../../../../frb/docs/index.php):

```
SpriteManager.RemoveLayer(LayerInstance);
Camera.Main.AddLayer(LayerInstance);
```

Note that the above code will result in an exception if the Layer is not manually removed from the [Camera](../../../../frb/docs/index.php) when the Screen is destroyed.
