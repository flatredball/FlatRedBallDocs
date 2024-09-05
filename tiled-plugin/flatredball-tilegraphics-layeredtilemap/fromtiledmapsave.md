# FromTiledMapSave

### Introduction

FromTiledMapSave loads a TMX file into a LayeredTileMap. This method populates all internal properties including the LayeredTileMap's Layers and Collisions properties. Internally this method loads necessary PNG files using the argument contentManager.

Typically this method is called in generated code by adding a TMX file to a Level screen in the FlatRedBall Editor.

### Tile Layer Format

TMX files can be converted to LayeredTileMaps if they are using any of the following Tile Layer Formats:

* Base64 (uncompressed)
* Base64 (gzip compressed)
* Base64 (Zstandard compressed)
* CSV

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Tile Layer Format set to CSV in Tiled</p></figcaption></figure>

Note that Base64 zlib compressed can be used, but to do this you must:

1. Add a reference to the Ionic.Zlib.Core nuget package
2. Add `SUPPORTS_ZLIB` to your precompile directives&#x20;

Using an unsupported compression format will result in a runtime error:

```
Does not support zlib, try using GZIP compression or csv format
```

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Error message about using format that is unsupported</p></figcaption></figure>
