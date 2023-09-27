## Introduction

The CloneObject method performs a deep clone of an object. This uses XML serialization so the object that is to be cloned must be XML serializable. This can be used to clone any "save" object, but should not be used on runtime objects such as Sprite.

Example of "save" objects include:

1.  Engine objects with the name "Save" at the end like SpriteSave, SceneSave, and AnimationChainSave
2.  Instances of objects that come from CSVs
3.  Objects which do not contain references to other objects, like Vector3. Although these may not technically be considered "save" objects, they can be properly cloned using CloneObject.

## Code Example

    // assuming EmitterSaveInstance is a valid EmitterSave:
    var cloned = FileManager.CloneObject(EmitterSaveInstance);
    // cloned can now be used
