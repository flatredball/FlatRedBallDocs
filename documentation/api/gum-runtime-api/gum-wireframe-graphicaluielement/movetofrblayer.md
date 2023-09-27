## Introduction

MoveToFrbLayer can be used to move a GraphicalUiElement to a FlatRedBall layer. For information on moving objects to a layer in Glue, see the [Adding Gum Components to Layers](/documentation/tools/gum/gum-how-to-add-gum-components-to-layers.md) page. At the time of this writing, Gum objects can only exist on one FlatRedBall/Gum layer.

## Gum Layers vs FlatRedBall Layers

Gum and FlatRedBall use two completely separate rendering systems. Visual objects in Gum cannot be directly added to FlatRedBall layers. To address this, the Gum plugin provides some methods to allow Gum objects to exist on FlatRedBall layers using the MoveToFrbLayer method. Internally, this is supported by Glue generating a Gum layer for every Glue layer. This association is stored in the current Gum screen (of type GumIdb ).

## Code Example

The following code shows how to move an object named ButtonInstance to a FlatRedBall Layer named UiLayer. This code assumes that GumScreen is a valid Gum screen (which is of type GumIdb ).

``` lang:c#
ButtonInstance.MoveToFrbLayer(UiLayer, GumScreen);
```

   
