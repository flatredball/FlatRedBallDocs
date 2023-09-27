## Introduction

The UseGlobalContent property tells an Entity/Screen to use the "Global" content manager when loading its content. This means that its content will only be loaded the first time it is accessed and it will never be unloaded. The UseGlobalContent is not the same thing as [Global Content Files](/frb/docs/index.php?title=Glue:Reference:Files:GlobalContent "Glue:Reference:Files:GlobalContent"). Global Content Files is a collection of files which by default are pre-loaded when the application starts and are never unloaded. Files which are part of Screens and Entities which UseGlobalContent will not be preloaded, but will never be unloaded once they are loaded. It is possible for a file to both be part of an Entity as well as Global Content Files, as shown [here](/frb/docs/index.php?title=Glue:Reference:Entities:UseGlobalContent#Using_both_UseGlobalContent_and_.22Global_Content_Files.22 "Glue:Reference:Entities:UseGlobalContent").

## What is the default behavior

The default value for UseGlobalContent is false. Entities will (by default) use the ContentManager given to them by their containing Screen. Screens will by default use a content manager unique to the given Screen. This means that any time a Screen is unloaded, all content referenced by that given Screen and any contained Entities will automatically be unloaded. This unloading behavior reduces the likelihood of accumulating too much memory through content loading, meaning simpler games will be able to ignore content loading and unloading. However, this also means that content may be unnecessarily loaded and unloaded. For example, consider a game which has a number of UI screens which use the same font files. If this font is used in a lot of Screens, it may be beneficial to always keep it in memory rather than to unload and re-load it on every Screen transition. If this font exists in a Text object Entity which is reused in multiple Screens, then the Entity's UseGlobalContent property can be set to true, resulting in it never being unloaded.

## Setting UseGlobalContent

UseGlobalContent can be set by:

1.  Selecting an Entity/Screen
2.  Changing the "UseGlobalContent" property to "True"![UseGlobalContent.png](/media/migrated_media-UseGlobalContent.png)

Your Entity/Screen will no longer unload files that it uses.

## UseGlobalContent and "Global Content Files"

Setting the UseGlobalContent tells an Entity to use the "Global" ContentManager which means it won't unload. If you are familiar with the ["Global Content Files" tree item in Glue](/frb/docs/index.php?title=Glue:Reference:Files:GlobalContent "Glue:Reference:Files:GlobalContent") then you are aware that you can also make files global by adding them to Global Content Files. You may be wondering what the difference between the two approaches is. Here are some characteristics which may help you identify when to use UseGlobalContent and when to use "Global Content Files".

-   Files added in "Global Content Files" will be loaded immediately when your game begins to run (or asynchronously if the LoadAsynchronously property is set to true). Files which are a part of an Entity that has UseGlobalContent to true will only be loaded when the Entity is first instantiated, or if the Entity's LoadStaticContent method is manually called.
-   Files added in "Global Content Files" are accessible through the GlobalContent class, which is a standard way to access global content. Files added to an Entity that has UseGlobalContent set to true will be associated specifically with that Entity. This can improve the organization of your project.
-   As suggested above, files added through "Global Content Files" can be loaded asynchronously. This means you can avoid long load times and delay in application startup by putting files in "Global Content Files".

### Using both UseGlobalContent and "Global Content Files"

There may be situations when a file should both be part of "Global Content Files" as well as part of an Entity which has UseGlobalContent set to true. The most common case is if a piece of content is associated with a particular Entity, but should be asynchronously loaded. For example, you may be working on a game that does not load some in-game content (such as the main character's content). If this is the case, making the main character's content exist in "Global Content Files" allows you to begin loading this content at the very beginning of execution. Depending on the menu flow of your game, you may end up loading your character before the player gets to the game Screen. This could improve load times when going into game. If you set an Entity to UseGlobalContent, and also add its files to the "Global Content Files", then the generated code for the Entity will use the GlobalContent class to get reference to the appropriate files. This means that it will obey the async loading, and even update the [content lock record](/frb/docs/index.php?title=Glue:Reference:Files:GlobalContent#RecordLockContention "Glue:Reference:Files:GlobalContent") if appropriate.
