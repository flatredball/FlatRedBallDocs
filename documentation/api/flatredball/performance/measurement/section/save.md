## Introduction

The Save function can be used to save a Section instance (and all of its contained sections) to an XML file. Saving a Section can be helpful in a number of situations:

-   To save a snapshot of performance before making changes so that the effectiveness of the changes can be measured
-   To send a file to another developer for assistance in improving performance
-   To save a file from a device (such as Android or iOS) for viewing on a PC

## Saving on Android

The following code can be used to save on Android:

    string path;
    path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
    string fileName = System.IO.Path.Combine(path, "Sections.xml");
    mSection.Save(fileName);

This will save to the following folder:

    /storage/emulated/0/Sections.xml

This file can be accessed using the FS File Explorer app on Android.
