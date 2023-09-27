## Introduction

The IsAssetLoadedByName method returns whether a file of a given type is already loaded and stored in RAM by the given [ContentManager](/documentation/api/flatredball/flatredball-content/flatredball-content-contentmanager/.md).

## Code Example

The following code can be used to check if a file Background.png  is loaded as a [Texture2D](/documentation/api/microsoft-xna-framework/microsoft-xna-framework-graphics/microsoft-xna-framework-graphics-texture2d/.md) in the current screen's content manager:

``` lang:c#
var contentManagerName = this.ContentManagerName;
var contentManager = FlatRedBallServices.GetContentManagerByName(contentManagerName);
bool isAlreadyLoaded = contentManager.IsAssetLoadedByName<Texture2D>("content/background.png");
```

## Name Details

IsAssetLoadedByDetail processes the assetName parameter before checking if it has been loaded. Specifically, the following modifications are made:

1.  If the argument is relative (such as content/background.png ), then it is converted to an absolute path (such as c:/MyGame/bin/debug/content/background.png ).
2.  The file is standardized using the [FileManager.Standardize](/documentation/api/flatredball/flatredball-io/flatredball-io-filemanager/standardize/.md) method.
3.  The content type is appended to the file name. This allows the same file to be loaded into multiple types.

For example, loading "content\Background.png" may result in the string "c:/folder/content/background.pngTexture2D"  being stored in the ContentManager.
