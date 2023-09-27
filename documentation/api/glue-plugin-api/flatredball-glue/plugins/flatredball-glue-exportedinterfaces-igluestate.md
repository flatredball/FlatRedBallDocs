## Introduction

The IGlueState interface provides a centralized way to get information about the current state of Glue. IGlueState is very similar to [IGlueCommands](/frb/docs/index.php?title=FlatRedBall.Glue.Plugins.ExportedInterfaces.IGlueCommands.md "FlatRedBall.Glue.Plugins.ExportedInterfaces.IGlueCommands") in that an instance of IGlueState can be provided to your plugin automatically through the plugin system (see below for more details).

## Using IGlueState

Any plugin can get access to an instance of IGlueState . To do so, add the following to your plugin class:

           [Import("GlueState")]
           public IGlueState GlueState 
           {
               get;
               set;
           }

That's all you have to do. The plugin system that Glue uses will automatically assign an instance to this interface. That means that your class can immediately start using the GlueState instance in its code with no additional hookup.
