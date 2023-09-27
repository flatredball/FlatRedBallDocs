## Introduction

This article discusses how to modify your content CSV to support creating a "runtime object" from a file. A runtime object is an object which typically has the following characteristics:

-   It has every-frame activity
-   It has some kind of membership in the FlatRedBall managers (such as it adds Sprites to the SpriteManager, PositionedObjects to the SpriteManager, or Text instances to the TextManager)
-   It must be removed or destroyed

To distinguish between the two, a non-runtime object would be an object that simply represents the contents of a file such as a Texture2D or a "save" object. A runtime object is an object that is typically visible or has collision, and interacts with other runtime objects ( for example Sprites, Entities, or shapes).

## Initial setup

For this article we'll start with a very simple setup:

-   Create a Glue project
-   Create a single Screen in this Glue project
-   Create a file for the desired type you're working with
-   Place the file under your newly-created Screen's files folder on disk

For this article we'll assume your file is called MyFile.ext and the Screen is called MyScreen.

## Modifying the CSV

Next we'll add/modify the CSV to handle this new file. For this we'll assume that the runtime object made by MyFile.ext is "MyRuntimeObject" and the save object is "MyRuntimeSave". Therefore, the CSV should look like this:

|                         |                   |                                                               |                                          |           |                      |                                                                                         |                |             |                   |
|-------------------------|-------------------|---------------------------------------------------------------|------------------------------------------|-----------|----------------------|-----------------------------------------------------------------------------------------|----------------|-------------|-------------------|
| FriendlyName (required) | CanBeObject(bool) | QualifiedRuntimeTypeName                                      | QualifiedSaveTypeName                    | Extension | AddToManagersMethod  | CustomLoadMethod                                                                        | DestroyMethod  | CanBeCloned | CustomCloneMethod |
| MyRuntimeObject (.ext)  | TRUE              | QualifiedType = ProjectNamespace.RuntimeTypes.MyRuntimeObject | ProjectNamespace.SaveTypes.MyRuntimeSave | ext       | this.AddToManagers() | {THIS} = ProjectNamespace.SaveObjects.MyRuntimeSave.FromFile("{FILE_NAME}").ToRuntime() | this.Destroy() | TRUE        | this.Clone()      |

## Adding to a Screen

Now that you have MyScreen and MyFile.ext created:

1.  Right-click on your MyScreen's Files item
2.  Select "Add File"-\>"Existing File"
3.  Select MyFile.ext

At this point your object should be loaded, created as an instance, and added to managers. You can verify this by either looking in the generated code for "AddToManagers" or running the game (assuming AddToManagers will properly make your object visible).

**Note:** So far this example uses a Screen. The reason for this is because creating runtime objects from files is slightly easier to do in Screens. If an object that can be a runtime object is added as a file to a Screen, Glue assumes that you intend to add the object to managers. Therefore, no additional work is needed aside from simply adding the file to a Screen. Entites require a little more work, as we will see in the following section.

## Adding to an Entity

Entities require a small amount more of work to create objects. Specifically you must both add a file and also add an object to be created from this file. To do this:

1.  Create a new Entity. I'll use the name "MyEntity"
2.  Right-click on the Entity's "Files" item
3.  Select "Add File"-\>"Existing File"
4.  Select MyFile.ext
5.  Right-click on MyEntity's "Objects" item
6.  Select "Add Object"
7.  Select the "From File" option
8.  Select MyFile.ext (which will probably include a folder path"
9.  Name the object appropriately. I'll use the name "MyFileObject"
10. Change the newly-created Object's "SourceName" to "Entire File (MyRuntimeObject)
