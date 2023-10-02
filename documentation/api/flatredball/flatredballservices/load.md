# load

### Introduction

The Load method is a method which can be used to load content either from a XNB (if using content pipelines) or from raw file if FlatRedBall supports the file format. For more information on the Load method and how FlatRedBall caches content, see the [FlatRedBall Content Manager](../../../../frb/docs/index.php) wiki entry.

### File locations

The Load method supports either absolute or relative file names. In other words, both are valid (assuming the files exist):

```
Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
```

\--or--

```
Texture2D texture = FlatRedBallServices.Load<Texture2D>("C:\MyGame\bin\x86\debug\content\redball.bmp");
```

The Load method will prepend [FileManager.RelativeDirectory](../../../../frb/docs/index.php) if the argument file is relative. In other words, the following two are equivalent:

```
Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
```

\--and--

```
Texture2D texture = FlatRedBallServices.Load<Texture2D>(FileManager.RelativeDirectory + "redball.bmp");
```

[FileManager.RelativeDirectory](../../../../frb/docs/index.php) defaults to the project's Content directory (the location where the Content project copies/builds files if using XNA). Therefore, if redball.bmp were present at the root of the content folder, then "content\redball.bmp" would be used to load the file.

#### Files and Folders

If using an XNA project, most files are added to a Content project. Any file added to the Content project must be loaded with the "content/" prefix. For example, if a file "redball.bmp" is added to the root of the Content project, then the call to load it would be:

```
// If added as a file:
FlatRedBallServices.Load<Texture2D>("content/redball.bmp");
// If added through the content pipeline:
FlatRedBallServices.Load<Texture2D>("content/redball");
```

### Load and Caching

The Load method supports caching and returning cached content to improve speed and reduce memory usage. To understand this, consider the following

```lang:c#
// Assuming this code is written in a Glue screen:
var contentManager = this.ContentManagerName;
var loadedTexture = FlatRedBallServices.Load<Texture2D>("Character.png", contentManager);
// loadedTexture is now a valid texture
```

The Load call performs the following logic:

1. Look for a [ContentManager](../content/contentmanager.md) with a name matching the contentManager  argument.
   1. If no contentManager  is specified, the "global" [ContentManager](../content/contentmanager.md) is used.
   2. If no matching [ContentManager](../content/contentmanager.md) is found, create one.
2. Search the ContentManager for an instance that has a matching name.
   1. If the content is found, return the existing instance. This saves time loading content and reduces RAM usage.
   2. If the content is not found, attempt to load it.

For more information on how file names are stored, see the [ContentManager.IsAssetLoadedByName page](../content/contentmanager/isassetloadedbyname.md).

### Load can return IDisposables added through AddDisposable

The Load method can give you disposables that have been added through AddDisposable. This means that you can use FlatRedBallServices as a cache for content that comes from disk **as well as content created dynamically**. For example, the following method would work:

```
Texture2D texture2D = CreateTextureDynamically();
FlatRedBallServices.AddDisposable("UniqueTextureName", texture2D, ContentManagerName);
// later you can get the texture as follows:
Texture2D sameTexture = FlatRedBallServices.Load<Texture2D>("UniqueTextureName", ContentManagerName);
```
