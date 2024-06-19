# SourceType

### Introduction

The SourceType property determines the type of the Entity at the highest level. Changing the SourceType results in different options being available in the [SourceClassType](../../frb/docs/index.php). Available SourceTypes are:

* File
* FlatRedBallType
* Entity

### File

If an object's SourceType is File, then the object is defined by a file. If the object is created in a Screen, then the object is referencing either a part or the entirety of the file. If the object is an Entity then the object may be a reference to the file or a copy of the file if the file has a runtime type such as a Tiled TMX being loaded into a MapDrawableBatch.

For more information on File objects, see the [SourceFile](glue-reference-sourcefile.md) page.

### FlatRedBallType

FlatRedBallType means that the Object will be a standard FlatRedBall type such as Sprite, Circle, Layer, or PositionedObjectList. FlatRedBallType is usually used in the following situations:

1. An object which uses a FlatRedBall type (such as Sprite) but its definition is simple enough that it doesn't merit the creation of an entire file to define it. Glue can modify Object properties on FlatRedBall types through the object itself (it automatically exposes a small set of variables) or through tunneled variables.
2. An object which will be assigned to data from a file dynamically. This type may get set in reaction to a property being set on an Entity or Screen after initialization.
3. An object which will be assigned to a File in a derived Entity. The base Entity must define the type of the object, and using FlatRedBallType (along with the appropriate SourceType) can accomplish this.

### Entity

The Entity SourceType identifies the Object as an instance of an Entity created in your project.
