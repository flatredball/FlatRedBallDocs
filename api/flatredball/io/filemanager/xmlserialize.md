# xmlserialize

### Introduction

The XmlSerialize and XmlDeserialize methods are methods which can be used to easily convert a class to an XML file, or an XML file back into an instance of a given type. XmlSerialize and XmlDeserialize are often used to save and load game data, such as player progress. Internally the FileManager uses the System.Xml.Serialization.XmlSerializer for serialization and deserialization. This means that any XML file created by the FileManager can be deserialized using the XmlSerializer if FlatRedBall is not available. Similarly, FlatRedBall can deserialize files created in other applications which use the XmlSerializer to save XML files. XmlSerialize uses the [FileManager's RelativeDirectory](relativedirectory.md) when given relative paths to serialize.

### Example

As mentioned above, game data can be saved to disk as XML files. For example, the following class could be used to save information about the user's progress:

```lang:c#
public class ProfileSaveData
{
    public string Name { get; set; }
    public int Experience { get; set; }
    public int Gold { get; set; }
}
```

A screen can be modified to save and load the project:

```lang:c#
void CustomActivity(bool firstTimeCalled)
{
    if(InputManager.Keyboard.KeyPushed(Keys.S))
    {
        PerformSave();
    }
    if(InputManager.Keyboard.KeyPushed(Keys.L))
    {
        PerformLoad();
    }

}

private void PerformSave()
{
    string fileName = "PlayerSave.xml";

    // Normally you'd have the profile stored somewhere, but 
    // we'll just create one here
    var saveData = new DataTypes.ProfileSaveData();

    saveData.Name = "Cecil";
    saveData.Gold = 3000;
    saveData.Experience = 500;

    FlatRedBall.IO.FileManager.XmlSerialize(saveData, fileName);

    FlatRedBall.Debugging.Debugger.CommandLineWrite("Saved " + fileName);

}

private void PerformLoad()
{
    string fileName = "PlayerSave.xml";

    var doesFileExist = FlatRedBall.IO.FileManager.FileExists(fileName);

    if(doesFileExist)
    {
        var saveData = FlatRedBall.IO.FileManager.XmlDeserialize<DataTypes.ProfileSaveData>(fileName);

        FlatRedBall.Debugging.Debugger.CommandLineWrite("Loaded file!");
        FlatRedBall.Debugging.Debugger.CommandLineWrite("Name:" + saveData.Name);
        FlatRedBall.Debugging.Debugger.CommandLineWrite("Gold:" + saveData.Gold);
        FlatRedBall.Debugging.Debugger.CommandLineWrite("Experience:" + saveData.Experience);
    }
    else
    {
        FlatRedBall.Debugging.Debugger.CommandLineWrite("Could not find file " + fileName);
    }

}
```

&#x20;

![](../../../../media/2017-02-img\_58913fffc58ee.png)

&#x20;

### Customizing Serialization

The XmlSerialize internally uses [XmlSerializer](http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx) and [XmlWriter](http://msdn.microsoft.com/en-us/library/system.xml.xmlwriter.aspx) classes. This means that all XML attributes (such as [XmlIgnore](http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlattributes.xmlignore.aspx)) will apply normally.

### XmlSerialize can create a directory

If the path of the file to save does not exist, then the XmlSerialize method will attempt to create the appropriate directory before saving the XML file.

### "There was an error reflecting type"

The FileManager uses the [internally](http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx|XmlSerializer). Therefore if the type cannot be serialized by the internal XmlSerializer then the FileManager.XmlSerialize will throw an exception. For information on this error, [see this page](http://stackoverflow.com/questions/60573/xmlserializer-there-was-an-error-reflecting-type).

### Additional Information

* [Creating Save Classes](../../../../documentation/tutorials/code-tutorials/tutorials-save-classes.md) - Discusses the "Save" class coding pattern commonly used to save game data.
