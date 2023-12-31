# glue-reference-sourcefile

### Introduction

The SourceFile property is a property which controls which file a given object is defined in. This value is only available if the object's [SourceType](../../../../frb/docs/index.php) is set to "File". If this value is available, then the drop-down will list all files in the Entity. The selected SourceFile will determine the available [SourceName](../../../../frb/docs/index.php).

### Clone vs. Reference

An object which has a SourceFile may simple be a reference to the file, or it may be a clone of it - however cloning only occurs in Entities and not Screens. Whether an object in an Entity is cloned or not is determined by the presence of a Clone method in the CSV for the given file type. For example, Glue does not include code for cloning a Texture2D, so Objects which reference a Texture2D will simply reference the same object as the static Texture2D created for the file. Scenes, on the other hand, include a Clone method, so creating a Scene object from a .scnx file will create a clone of the original Scene. Usually the presence of a Clone method is tied to whether the object created from a file is usually modified after being loaded. Texture2Ds are usually left unmodified after being loaded from file; however Scenes which are loaded and used as objects are usually attached to their containing Entity. The result is that whenever the Entity moves, all objects in the Scene will change their Position values. Therefore Scenes are cloned so that the original can remain unmodified and can be ued whenever new instances of the given Entity are created.
