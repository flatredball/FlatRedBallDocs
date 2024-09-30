# LayerOn

### Introduction

LayerOn controls which layer an object is rendered to. By default the value is **blank** which means that it will be sorted with all other objects with no layer. This value can be changed on an object's **Properties** tab.

![](../../.gitbook/assets/2016-12-img\_586661cc9c24f.png)

For an object to be on a Layer, a Layer must be defined in the same Screen/Entity that a given object is a part of. Once this occurs you can either use the LayerOn property to set the Layer, or you can drag+drop the object onto its desired Layer in the Glue UI.

### Available Values

The \*\*LayerOn \*\*property can be set to one of the following values:

* **\<None>** - Clears the LayerOn value
* **Under Everything (Engine Layer)** - A layer automatically created by the FlatRedBall engine for objects which should be drawn under everything, including objects with no layer.
* **Layer Objects** - Any Layer Object will appear in this list. If no Layers have been created in the current screen/entity, no layers will be shown here. The screenshot below shows **LayerInstance**, which is a Layer added to the **SpriteEntity** (shown in light green).
* **Top Layer (Engine Layer)** - A layer automatically created by the FlatRedball engine for objects which should be drawn above everything, including all other layers.

![](../../.gitbook/assets/2016-12-img\_5866651edd6c8.png)

### LayerOn and PositionedObjectList

At the time of this writing, only non-list objects can be added to layers. This is because lists do not have built-in support for layers in the FlatRedBall engine, and Glue is simply exposing default FlatRedBall object behavior for layering.
