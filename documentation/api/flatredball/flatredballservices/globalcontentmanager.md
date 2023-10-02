# Introduction

The GlobalContentManager is a value which can be used to load content using a "global" content manager. Not only is this content manager available globally, but it is never unloaded. Therefore, any content loaded using GlobalContentManager will not be unloaded until the game exits.

Using a GlobalContentManager is useful for content which appears frequently in games (such as fonts) or for content which may take a long time to load/process, and should be kept in RAM to improve load times despite occupying space permanently.

For information on global content in Glue, see the [GlobalContentFiles page](../../../../frb/docs/index.php) and the [UseGlobalContent page](../../../../frb/docs/index.php).
