# Z

### Introduction

The Z value of a LayeredTileMap controls the order that it is drawn relative to other objects such as FlatRedBall Entities. Each layer (MapDrawableBatch) on the LayeredTileMap is drawn at one Z value greater than the layer under. For example, consider a map with layers shown in the following image:

![](../../.gitbook/assets/2022-04-img\_6255b9186ee1f.png)

Assuming the map's Z value is set to 0, then the layers will have the following Z values:

* GameplayLayer Z = 0
* AboveLayer1 Z = 1
* AboveLayer2 Z = 2

### Shift Map to Move Gameplay Layer to Z0

The Map object (the default LayeredTileMap when using a wizard setup) provides the option to shift the map's Z value so the GameplayLayer's Z is at 0. If this option is checked, then any layer above GameplayLayer has a positive Z value and draws on top of entities at Z = 0. Similarly, if this option is checked then any layer below GameplayLayer has a negative Z value and draws under entities at Z = 0.
