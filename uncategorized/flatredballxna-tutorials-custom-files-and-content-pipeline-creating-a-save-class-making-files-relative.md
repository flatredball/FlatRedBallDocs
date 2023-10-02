# flatredballxna-tutorials-custom-files-and-content-pipeline-creating-a-save-class-making-files-relati

### Introduction

Many content file types often reference other files. For example, [Scenes](../frb/docs/index.php) reference image files which are used to texture their contained [Sprites](../frb/docs/index.php). In the case of our LevelSave class, we will be referencing a .scnx file and a .shcx file.

It is important that the referenced file paths are saved as relative paths rather than absolute paths. For example, consider saving a reference to a .scnx file with the following path:

```
C:\Documents and Settings\Victor\My Documents\Visual Studio 2008\Projects\WindowsGame1\
WindowsGame1\Content\scene.scnx
```

On your machine the .scnx should load just fine, but what happens when you move the project to a different machine? It's unlikely that everyone will have the same path structure as you. So, instead, it is better to reference the .scnx in a relative fashion.

The question then becomes "relative to what?" Two obvious choices are the .exe itself, or the LevelSave file. Saving relative to the .exe will make your game portable, but this becomes an issue if you have other .exes which work with the file. For example, you may want to create a level editor which can load the file as well as your game. Furthermore, if you decide to transfer your file to another user, then they have to make sure to recreate the folder structure relative to their .exe.

To use the .scnx file format as an example, we've decided that all files referenced by a .scnx will be relative to the .scnx itself. That way a user can send a .scnx (and referenced image files) to anyone, and regardless of where the .scnx is saved, it can be loaded by the engine or FRBDK.

Therefore, we encourage that all files referenced by a content file should be referenced relative to the content file itself.

### Making your file references relative

There are two steps to making your content files relative:

1. Create a method which converts all references to be relative to an argument directory or file name.
2. Call this method from your Save method.

Add the following to your LevelSave class:

```
private void MakeRelative(string fileToMakeRelativeTo)
{
    // this assumes that we're making all referenced files relative
    // to a file
    string directoryOfFile = FileManager.GetDirectory(fileToMakeRelativeTo);

    // Store off the old relative directory:
    string oldRelativeDirectory = FileManager.RelativeDirectory;

    // Set the new relative directory which will be used to make the
    // referenced files relative:
    FileManager.RelativeDirectory = directoryOfFile;

    // Now that the relative directory is set, we can easily set our files to be
    // relative to this, but only do so if they're absolute:
    if (FileManager.IsRelative(SceneFileName) == false)
    {
        SceneFileName = FileManager.MakeRelative(SceneFileName);
    }

    if (FileManager.IsRelative(ShapeCollectionFileName) == false)
    {
        ShapeCollectionFileName = FileManager.MakeRelative(ShapeCollectionFileName);
    }

    // Don't forget to set the relative directory back
    FileManager.RelativeDirectory = oldRelativeDirectory;
}
```

Add the following to your LevelSave's Save method before calling XmlSerialize:

```
MakeRelative(fileName);
```

Now your LevelSave will make sure that any referenced files are relative to the file itself.
