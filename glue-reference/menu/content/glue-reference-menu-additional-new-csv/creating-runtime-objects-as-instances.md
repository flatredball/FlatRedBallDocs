# creating-runtime-objects-as-instances

### Introduction

Objects can be instantiated directly inside the Objects folder of Screens or Entities. Typically these instances are of standard types such as Sprite or TileShapeCollection. Also, the type of instances can be entity types, such as an instance of a Player in the GameScreen. If your game includes a special type which is not an entity type, the FlatRedBall Editor can display this type by adding it to a custom type CSV.

### Example - Instantiating a Custom PositionedObject

As an example, consider a custom PositionedObject class. The class doesn't need to have any functionality, it just needs to be defined in your project so that generated code can work with it. Therefore, an empty class will do, as shown in the following snippet:

```
using FlatRedBall;

namespace CustomTypeProject
{
    public class CustomType : PositionedObject { }
}
```

Now we can add this type to a custom CSV.

1.  Select **Content** -> **Additional Content** -> **New Content CSV...**

    ![](../../../../../../media/2023-05-img_645d6d3eb725a.png)
2.  Enter the name ProjectSpecificContent and click OK

    ![](../../../../../../media/2023-05-img_645d6d7b58eb4.png)
3.  A folder should open displaying the newly-created ProjectSpecificContent.csv. Double-click it to open it in the default spreadsheet application installed on your machine

    ![](../../../../../../media/2023-05-img_645d6dc7d1061.png)
4. Enter the values for properties as specified below:

* Friendly Name: **CustomType**
* CanBeObject: **true**
* QualifiedRuntimeTypeName: **QualifiedType = CustomTypeProject.CustomType** (this should be your qualified name)
* AddToManagersMethod: **FlatRedBall.SpriteManager.AddPositionedObject(this)**
* DestroyMethod: **FlatRedBall.SpriteManager.RemovePositionedObject(this)**
* ShouldAttach: **true**
* IsPositionedObject: **true**
* AdjustRelativeZ: **this.RelativeZ += value**

For examples on how to work with this CSV file, see the ContentTypes.csv file which is located relative to the GlueFormsCore.exe project, or in the Visual Studio project if you are building from source. Once you have modified and saved the CSV, shut down and restart the FlatRedBall Editor. If the file was loaded correctly you will see output which looks similar to the following text:

```
4:43:31.7 - Loading content types from C:/Users/vchel/Documents/FlatRedBallProjects/CustomTypeProject/CustomTypeProject/GlueSettings/ProjectSpecificContent.csv and found 1 types
4:43:31.7 - Adding 1 content types
```

You can now right-click on the Objects under any Screen or Entity and you should see your type.

![](../../../../../../media/2023-05-img_645d6ff53da86.png)

Since this type is also a PositionedObject, your entities can use it as their base.

![](../../../../../../media/2023-05-img_645d703ba763d.png)

### VariableDefinitions

By default instances of new types that you create do not have any variables visible in the Variables tab. You can change this by adding variables which you would like automatically visible by modifying the VariableDefinitions column. The standard ContentTypes.csv file provides a great example of how to define VariableDefinitions. One of the largest set of variables is on the Sprite's VariableDefinitions column.

![](../../../../../../media/2023-05-img_645d711051472.png)

Add as many variables as you would like available. Also, you are not limited to PositionedObject properties. If you add new properties to your type in code, you can expose these to the FlatRedBall Editor by modifying the VariableDefinitions column. &#x20;
