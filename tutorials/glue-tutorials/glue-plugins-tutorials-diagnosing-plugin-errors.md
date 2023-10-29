## Introduction

This section will list common errors encountered while making plugins, and how to solve them.

## CompositionException

You will see this error if there is a mismatch between your plugin's base type and its export type. You may see an error like this:

![GluePluginCompositionException.png](/media/migrated_media-GluePluginCompositionException.png)

This can happen if your plugin export and base type don't match, such as:

        [Export(typeof(FlatRedBall.Glue.Plugins.Interfaces.INewObject))]
        public class MyPlugin : PluginBase

You can solve this by making sure the export type is the same as the base type:

        [Export(typeof(PluginBase))]
        public class MyPlugin : PluginBase
