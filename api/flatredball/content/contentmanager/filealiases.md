# FileAliases

### Introduction

FileAliases is used to create aliases for files. The most common use case for FileAliases is to allow systems which expect to load files with extension to be able to access files that have been loaded by the content pipeline (which have no alias).

FileAliases can be added in code generation by the FlatRedBall Editor or manually in code.

### Code Example - Manually Adding a Content Pipeline Extension

For this example, assume that a PNG has been added to the Content directory using the content pipeline. At runtime, this file would be loaded using the following code:

```csharp
var texture = SomeContentManager.Load<Texture2D>("Content/MyPngFile");
```

Assuming that MyPngFile is built using the content pipeline, then the file MyPngFile.xnb should be included in the Content folder.

Some systems, such as Tiled or Gum, may expect that PNG files are loaded with their extension so they attempt to load the file using an extension such as "Content/MyPngFile.png". We can add a file alias to FlatRedBall to enable loading the file as shown in the following code. Note that the aliases use the FilePath type, so it's important to include the relative directory which is typically the .exe's directory:

```csharp
var relativeDirectory = FileManager.RelativeDirectory;
SomeContentManager.FileAliases[relativeDirectory + "Content/MyPngFile.png"] = 
    relativeDirectory + "Content/MyPngFile.png";
```

Since Gum and Tiled both route their file loading through FlatRedBall, then the alias will be used. Also, note that each ContentManager has its own FileAliases dictionary, so this code must be applied to the proper ContentManager.
