# editing-flatredballxna-tutorials-custom-files-and-content-pipeline-creating-a-runtime-class

### Introduction

The first class needed in getting custom content in your game is a runtime class. Having a runtime class makes handling your content (especially in a tool) much easier.

Our runtime class will be called "Level". Later, we'll be creating the other object types necessary for supporting form-file and through content pipeline loading.

### Level Format Purpose

Our Level class will contain references to common FRB objects. One way to think of it is as a container for all content related to a level. In these tutorials we'll use two common FRB objects:

* [Scene](../frb/docs/index.php)
* [ShapeCollection](../frb/docs/index.php)

This Level class could be expanded upon to support other types as well. The two types we're using here lay the groundwork.

### Level Code

The code for the Level class can be found here:

[Level.cs](../frb/docs/images/d/d4/Level.cs)

Add the Level class to the FromFileProject (the project created in the [previous article](../frb/docs/index.php)).

### Level Introduction

Our Level class does some basic things including:

* Adding itself to Managers
* Controlling Shape visibility
* Destroying itself

This class could also serve as the starting point for a more complicated level, perhaps by adding other things such as [NodeNetworks](../frb/docs/index.php), but for now we'll keep things simple.

### Parameterless Constructor

This tutorial provides the Level.cs class as a download rather than providing a step-by-step discussion of how to create the level. The reason for this is because we want to focus on the loading and content pipeline classes.

However, the Level (or any runtime object) **must have a no-argument constructor**. A no-argument constructor allows the [ObjectReader](../frb/docs/index.php) to invoke a new instance of the object when loading through the content pipeline. In other words, since the runtime class will be instantiated through reflection rather than by directly calling the constructor, the object must have no arguments in its constructor. This restriction will also hold for the "Save" object created in a later tutorial.
