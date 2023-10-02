# runtime-object-charateristics

### Introduction

Files loaded by Glue can be used to either create "save objects" and "runtime objects". Save objects are objects which can be loaded directly from file. Save objects are typically not added to the FlatRedBall Engine, nor do they require loading other files which use content managers (such as Texture2Ds). Runtime objects are typically used in games. Runtime objects can be used for one or more of the following purposes:

* To render graphics to the screen
* To perform collision
* To position or manage other runtime objects

### Runtime Objects and FlatRedBall Managers

Runtime objects are often either directly added to FlatRedBall managers (if they inherit from the [PositionedObject](../../../../../../frb/docs/index.php) or include objects which are added to managers). In this case the runtime object needs two calls:

1. An "add to managers" method which is responsible for adding the object and any contained objects to the FlatRedBall Engine
2. A "remove from managers" or "destroy" method which removes the object and all contained objects from FlatRedBall managers

Objects which follow a number of guidelines regarding add to managers and destroy can be used in Glue in advanced and useful scenarios. This article discusses these guidelines which can be used when constructing runtime objects to be loaded by glue.

### Instantiation and AddToManagers should be separate methods

The code which adds an object and its contained objects to FlatRedBall managers should:

1. Be a separate call from the code that instantiates the runtime object
2. Should either not be called by the code that instantiates the runtime object, or should be optionally called
3. Should be a public method.
4. Should not load any data from-file. All from-file loading should be done in instantiation/initialization. .

The reason for the separation between initialization and add to managers enables Glue to do the following when your runtime object is contained in a Screen or Entity:

* Instantiation of Screens and Entities on a non-primary thread.
* Pooling of Entities.
* The ability to be added to a Layer (instantiation and layering are typically done on two separate calls for FlatRedBall objects)

### Destroy

All runtime objects should have some type of destroy method/logic. The destroy method is responsible for removing the object and all contained objects from FlatRedBall managers.

### Clone

Runtime objects which are created from files should support a Clone method. The reason for this is because a single instance may be loaded from file, but then multiple instances may be needed if multiple Entities use the same file.
