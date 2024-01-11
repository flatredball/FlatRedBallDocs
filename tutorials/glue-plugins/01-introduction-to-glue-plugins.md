# Introduction to FlatRedBall Plugins

### Introduction

FlatRedBall Plugins are powerful and flexible, allowing custom code to be used to modify how the editor behaves. Plugins can be used to perform almost any type of custom behavior in FRB. Examples of what can be done with plugins include:

* Adding new tabs with Custom UI. This UI can include WPF text boxes, buttons, and even SkiaSharp windows.
* Defining new file and object types using AssetTypeInfos
* Injecting custom code into generated code files, including in Screens, Entities, and Game1
* Defining file dependencies which FRB can use to manage Visual Studio project files and to notify the user of missing dependencies
* Adding entire code files and .dlls directly in a project
* Directly access the file system, FRB project files, Visual Studio project, and code files for any purpose
* Checking for and reporting errors.

If you've run the FlatRedBall Editor, then you've already used functionality provided by the plugin system. In fact, almost the entirety of FRB is now constructed through plugins. Every red rectangle in the following picture represents a different plugin.

![Plugins in the FRB Editor](../../media/2023-04-img\_6444b3c9c3fa9.png)

Note that the code project for the FRB Editor is called Glue, so the plugin documentations use the terms "FlatRedBall Editor" and "Glue" interchangeably.

### How are Plugins Created?

Typical Glue plugins are created as a regular .NET class library. This class library will need to reference Glue libraries so that it can access Glue objects. A Glue plugin can contain one or more .dll files, and any additional files such as icons or code/content which may be injected into a project. Although not necessary, plugin .dll files can also include embedded resources. The easiest way to create a plugin (as will be shown in later tutorials) is to download the FlatRedBall source and create a copy of the Glue .sln file. This will allow you to compile and debug your plugin against Glue source while Glue is running.

### How are Plugins Distributed?

Typically when developing a plugin, the plugin .dll files will be copied to a location where Glue will automatically load them when it starts up. Any loaded plugin can then be exported to a .plug file through Glue (as will be shown in a later tutorial). These .plug files can be distributed however you like - including through email, hosting on a website, or on github.
