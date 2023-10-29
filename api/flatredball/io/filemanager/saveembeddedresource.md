## Introduction

The SaveEmbeddedResource method can be used to save a file which has been compiled as an EmeddedResource to disk. This method is useful for PC tools, especially Gum plugins.

## Code Example

The following will save the redball.bmp image to the given target directory assuming it exists in the current assembly:

    var assembly = typeof(Game1).Assembly;
    string nameOfResource = "GameNamespace.Folder.Subfolder.redball.bmp";
    string locationOnDisk = "C:/Folder/redball.bmp";
    FileManager.SaveEmbeddedResource(
        assembly, 
        nameOfResource,
        locationOnDisk);
