## Introduction

The SourceType property determines the type of the Entity at the highest level. Changing the SourceType results in different options being available in the [SourceClassType](/frb/docs/index.php?title=Glue:Reference:Objects:SourceClassType&action=edit&redlink=1 "Glue:Reference:Objects:SourceClassType (page does not exist)"). Available SourceTypes are:

-   File
-   FlatRedBallType
-   Entity

## Common File Usage

File is a very common SourceType for Objects. If an Object's SourceType is File, then the Object represents an element within the file (such as a Sprite inside a .scnx file) or the entire object contained in the file (such as the entire Scene in the File). File is often used when you want to create content for an Entity through one of the standard FRB file types, or when you want to create content for a Screen, and want to give that content specific functionality.

## FlatRedBallType

FlatRedBallType means that the Object will be a standard FlatRedBall type such as Sprite, Circle, Layer, or PositionedObjectList. FlatRedBallType is usually used in the following situations:

1.  An object which uses a FlatRedBall type (such as Sprite) but its definition is simple enough that it doesn't merit the creation of an entire file to define it. Glue can modify Object properties on FlatRedBall types through the object itself (it automatically exposes a small set of variables) or through tunneled variables.
2.  An object which will be assigned to data from a file dynamically. This type may get set in reaction to a property being set on an Entity or Screen after initialization.
3.  An object which will be assigned to a File in a derived Entity. The base Entity must define the type of the object, and using FlatRedBallType (along with the appropriate SourceType) can accomplish this.

## Entity

The Entity SourceType identifies the Object as an instance of an Entity created in your project.
