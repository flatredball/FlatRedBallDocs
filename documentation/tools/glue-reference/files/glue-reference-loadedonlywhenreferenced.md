## Introduction

LoadedOnlyWhenReferenced is a property which tells Glue to not load a file until it is referenced in code. This is can be used for optionally loaded content - that is, content which will only be loaded based off of certain conditions in the game (such as the current level being played).

## When to use LoadedOnlyWhenReferenced

LoadedOnlyWhenReferenced is very useful if you have content in your game which is optionally loaded depending on the state of your game. For example, you may have a game where levels are represented by .scnx files. You may add multiple .scnx files to your Screen and mark them as LoadedOnlyWhenReferenced. This means that by default no files will be loaded when your Screen is created. However, if you access any properties created for the files in the Screen, then the corresponding file will be loaded.

## Additional Information

-   [Optionally Loaded Content tutorial](/frb/docs/index.php?title=Glue:Tutorials:Optionally_Loaded_Content.md "Glue:Tutorials:Optionally Loaded Content") - Basic tutorial on how to use optionally loaded content.
-   [Optionally Loaded Scenes](/frb/docs/index.php?title=Glue:Tutorials:Optionally_Loaded_Scenes.md "Glue:Tutorials:Optionally Loaded Scenes") - Discusses how to create optionally loaded Scenes (.scnx files) to load levels dynamically.
