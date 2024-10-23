# TiledMapSave

### Introduction

TiledMapSave is a serializable class which is used by FlatRedBall when loading a .tmx file. TiledMapSave is an intermediary class loading a tmx file into a runtime LayeredTileMap. It can also be used to inspect the contents of a .tmx file or to make modifications and save a .tmx to disk.

Most games do not need to use this class in their own code.

### Loading a TMX

The following code can be used to load a tmx file into a TiledMapSave:

```csharp
// If false, then the source PNG files are not loaded
// This can make loading faster, and suppresses exceptions
// if referenced PNGs are not found. Set this to true if you
// intend to eventually convert the TiledMapSave to a runtime 
// object
Tileset.ShouldLoadValuesFromSource = false;
var tiledMapSave = TiledMapSave.FromFile(absoluteFile);
```
