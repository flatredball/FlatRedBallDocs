## Introduction

By default CSVs added to Glue will create a matching class in the DataTypes folder of the game project. For example, adding a file EnemyInfo.csv will create a class GameName.DataTypes.EnemyInfo. While this behavior is convenient it is sometimes too restrictive. For example, games may benefit from fully-defining their data classes by hand - even in other projects completely - rather than letting Glue generate the data classes automatically. Setting Generate Data Class to false allows the code project to specify its own data class.

## Example

The following screen shot shows a CSV called EnemyInfo which is tied to a data class with the fully-qualified name of GameProject.DataTypes.EnemyDataClass: ![GenerateDataClassFalse.PNG](/media/migrated_media-GenerateDataClassFalse.PNG) The "Custom Namespace" field allows using classes defined outside of the GameName.DataTypes namespace. For example in the following image the class BuildingInfo is placed in the BaseDataTypes.Buildings namespace (resulting in the fully qualified name BaseDataTypes.Buildings.BuildingInfo): ![CustomNamespace.PNG](/media/migrated_media-CustomNamespace.PNG)
