# sorttype

### Introduction

Each Layer can have its own SortType which controls how [Sprites](../../../../../frb/docs/index.php), [Text](../../../../../frb/docs/index.php), and [IDrawableBatches](../../../../../frb/docs/index.php) sort. This property allows each Layer to have its own Sort type. By default objects on Layers will be sorted by their Z values - objects with smaller Z values (which are in the distance) will draw behind objects which have larger Z values (which are closer to the Camera).

### General information

For general information abou tthe SortTypes property, see the [SpriteManager's OrderedSortType property article](../../../../../frb/docs/index.php). This article will discuss how sorting can be modified. Keep in mind that the SpriteManager article linked here discusses object sorting and uses the SpriteManager's OrderedSortType property which only controls how **unlayered objects** sort. In other words, changing the SpriteManager's OrderedSortType will not impact how Layers sort. Unlayered objects can sort differently than Layered objects, and each Layer can specify its own SortType.

### Layer SortType and Camera rotation

If a Camera is unrotated, then the default SortType (Z) will work well. However, if your game uses a camera which can be rotated, then the default SortType may no longer produce desired results. For example, in a typical 3D game the Camera can face in any direction. When this occurs, objects with larger Z values are not guaranteed to be closer to the Camera than objects with smaller Z values. This is very noticeable when working with UI elements which are attached to the Camera. This is the main reason for the DistanceAlongForwardVector SortType. In most you can resolve ordering issues on UI/HUD elements which are attached to a rotated Camera by setting the Layer's SortType to DistanceAlongForwardVector:

```
UiLayer.SortType = SortType.DistanceAlongForwardVector;
```
