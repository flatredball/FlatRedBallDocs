# flatredballxna-tutorials-custom-files-and-content-pipeline-creating-a-save-class

### Introduction

In the [previous tutorial](../frb/docs/index.php), we created a class called [Level](../frb/docs/images/d/d4/Level.cs). This class provides some basic actions which we will likely want to use at runtime. Now that we have an object that we know we want to deal with, the next step is to create a ["Save"](../frb/docs/index.php) class for this runtime object.

The [Save](../frb/docs/index.php) object provides the normal functionality of interfacing with a .XML. In short, it is an intermediary file that sits between the runtime [Level](../frb/docs/images/d/d4/Level.cs) class and the on-disk XML or binary content pipeline file. For more information on [Save](../frb/docs/index.php) objects, see [this article](../frb/docs/index.php).

### Save class Code

This section outlines the steps necessary to create a Save class which we'll call LevelSave.

#### Create the LevelSave Class

Create the LevelSave class by adding a new class to your FromFileProject called LevelSave. Be sure to make it public.

#### Add the Data

Our LevelSave class will contain links to which [Scene](../frb/docs/index.php) and [ShapeCollection](../frb/docs/index.php) to use.

Add the following inside the LevelSave class:

```
public string SceneFileName;
public string ShapeCollectionFileName;
```

#### Create FromFile and Save methods

Add the following code for saving and loading your LevelSave to/from XML.

Add the following using statement:

```
using FlatRedBall.IO;
using System.Xml.Serialization;
```

Add the following inside the LevelSave class:

```
[XmlIgnore]
public string FileName;

public static LevelSave FromFile(string fileName)
{
    LevelSave levelSave = FileManager.XmlDeserialize<LevelSave>(fileName);

    // FileName is used for know the relative directory to use when
    // loading referenced assets.
    levelSave.FileName = fileName;

    // FileName should be absolute
    if (FileManager.IsRelative(levelSave.FileName))
    {
        levelSave.FileName = FileManager.MakeAbsolute(levelSave.FileName);
    }

    return levelSave;
}

public void Save(string fileName)
{
    MakeRelative(fileName);
    FileManager.XmlSerialize(this, fileName);
}

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

The [FileManager](../frb/docs/index.php) provides one-line XML saving and loading methods which are used in most Save classes.

#### Create the to Runtime Method

The Save class should be able to create a Level instance. It's common to have a To\<RuntimeName> method which may take a [content manager](../frb/docs/index.php) name.

Add the following using statement:

```
using FlatRedBall;
using FlatRedBall.Math.Geometry;
```

Add the following methods in the LevelSave class:

```
public static LevelSave FromLevel(Level level)
{
    LevelSave levelSave = new LevelSave();
    levelSave.SceneFileName = level.Scene.Name;
    levelSave.ShapeCollectionFileName = level.ShapeCollection.Name;

    return levelSave;
}

public virtual Level ToLevel(string contentManagerName)
{
    if (SceneInstance != null || ShapeCollectionInstance != null)
    {
        Level level = new Level(SceneInstance, ShapeCollectionInstance);

        return level;
    }
    else
    {
        // remember, all asset names are realtive to the level, so set
        // the relative directory
        string directory = FileManager.GetDirectory(FileName);

        string oldRelativeDirectory = FileManager.RelativeDirectory;

        FileManager.RelativeDirectory = directory;

        Scene scene = FlatRedBallServices.Load<Scene>(
            SceneFileName, contentManagerName);

        ShapeCollection shapeCollection = FlatRedBallServices.Load<ShapeCollection>(
            ShapeCollectionFileName, contentManagerName);

        Level level = new Level(scene, shapeCollection);

        // We need to be proper and set the old relative directory back
        FileManager.RelativeDirectory = oldRelativeDirectory;

        return level;
    }
}
```

### Parameterless Constructor

Just like the runtime Level class, this class must have a no-argument (parameterless) constructor. Since we didn't define one explicitly, there is an implied no-argument constructor. Keep in mind that you will need to explicitly define a no-argument constructor if you decide to add a constructor that has arguments.

### Conclusion

At this point we have a class which can read from file, save to file, and instantiate a [Level](../frb/docs/images/d/d4/Level.cs). If you are only interested in doing from-file loading, then at this point you have a fully functional class which can perform the saving, loading, and instantiating tasks. All that's required to create a XML for a LevelSave is to simply instantiate a LevelSave, set the two fields, then call Save. This will create a file which can then be loaded easily.

For the full source, click here:

[LevelSave.cs](../frb/docs/images/b/b8/LevelSave.cs)
