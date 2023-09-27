## Introduction

So far we've talked about what types of plugins you can create for Glue, and then we covered a basic plugin that modifies newly-created Objects using the NamedObjectSave class. This tutorial covers the parts of the IPlugin interface - the interface which every plugin must implement.

## IPlugin properties and methods

The IPlugin interface is a fairly straightforward interface. The parts as defined in Glue are:

    string FriendlyName {get;}
    Version Version {get;}
    void StartUp();
    bool ShutDown(PluginShutDownReason shutDownReason);

Let's look at each part individually.

## FriendlyName

The FriendlyName property is what will show up in the Plugins Window in Glue. This name should provide the user with information about what the plugin does. There's not much else to this property.

## Version

The Version property defines the version of your plugin. This can be used to identify what version of plugin you have compared to what is publicly available online.

## StartUp

The StartUp method is a method which Glue calls when a plugin is first started. This will be called in one of three situations:

-   The user has just started Glue
-   The user has re-enabled your plugin
-   The user has loaded a new GLUX file

The StartUp method should do any one-time initialization logic which is not tied to events in the plugin. For example, if your plugin creates some permanent UI (such as a floating window or menu item), then the logic to create and add this to Glue should be done in StartUp.

## ShutDown

The ShutDown method is the most complicated of the IPlugin members. As you might expect, the ShutDown method is a method which is called by Glue whenever the app is shut down. The ShutDown method should undo anything that the StartUp method does. For example, if the StartUp method creates a floating window, then the ShutDown should close it.

The ShutDown method has a PluginShutDownReason argument which specifies why the Plugin was shut down. The possible reasons are:

-   UserDisabled - The user has disabled the plugin through the Plugin window
-   PluginException - The plugin has thrown an exception at some point, so Glue is shutting it down
-   PluginInitiated - The plugin has called PluginManager.ShutDownPlugin (explained in the next tutorial)
-   GluxUnload - The .glux file (GlueProjectSave) is being unloaded
-   GlueShutDown - The user is exiting Glue

Depending on the reasoning behind the requested ShutDown, you may decide to prevent the plugin from being closed. To prevent the plugin from being shut down, return 'false' instead of 'true'. Of course, this behavior should not be used very often as the user may find it frustrating that a plugin that should shut down isn't. If your plugin decides to not shut down, you should clearly explain to the user (perhaps through a MessageBox) why the plugin is not shutting down.

Alternatively, if shutting down the plugin may result in loss of data or work, then the plugin may warn the user, and if the user decides to not disable the plugin, then the plugin may return 'false'.

## Conclusion

Now that we've covered the basics on what the IPlugin interface is all about, the next tutorial will move on to a more powerful plugin example - one that uses Windows Forms.
