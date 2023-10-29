## Introduction

The BinarySerialize function is a function which can save a binary file representing an instance of an object. This function is similar to FlatRedBall.IO.FileManager.XmlSerialize, but the resulting file is a binary file rather than a text XML file.

## Benefits of BinarySerialize

Binary files have the following benefits:

-   Binary files cannot be opened and edited as easily as XML files. This makes binary serialization a good choice for files which you do not want users to be able to modify.
-   Binary files are often smaller on disk than XML files. For smaller files this doesn't matter much, but it can have a large impact on file size when dealing with larger files.
-   Binary files can be faster to load.

## Downsides of BinarySerialize

Binary files have the following downsides:

-   Binary files are more difficult to debug - you can't simply look at the file and identify issues.
-   Binary serialization is not supported on every platform.
-   Binary files created on one platform may not be usable on another platform.
-   Binary files do not use a standard structure, therefore any area where the binary file is needed requires a custom loader. Most non-C# technology includes XML parsing libraries.

## 'TYPE' is not marked as serializable

Any type that is run through the BinarySerialize function must be marked as serializable. For example:

    [Serializable]
    public class PlayerProfileSave
    {
      public string Name;
      public int Experience;
    }

However, the
