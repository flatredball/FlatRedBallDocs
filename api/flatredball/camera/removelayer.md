## Introduction

The RemoveLayer method removes the argument layer from the calling Camera. This method should be called on any Layers manually added to a Camera in custom code.

## Code Example

The following code shows how to add and remove a Layer from a Camera (the Camera.Main, specifically):

    // In the Screen - add the Layer as member
    Layer myLayer;

    // Create the Layer in CustomInitialize:
    myLayer = Camera.Main.AddLayer();

    // Remove the Layer in CustomDestroy:
    Camera.Main.RemoveLayer(myLayer);
