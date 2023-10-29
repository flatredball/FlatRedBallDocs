# Introduction

Files can be added to Entities, Screens, and to Global Content Files (if a file is to be shared and never unloaded throughout execution of your program). Files can be added in one of three ways:

1. New files - Glue supports creating brand new files of certain types which. Typically once these files are added they are edited to include content for the game. Examples of these file types include Scene files (.scnx) and AnimationChainList files (.achx)
2. Existing files - Glue supports adding existing files to Entities. Some file types (such as .png and .wav) cannot be created as new files in Glue, but instead must be created externally then added to Glue.
3. Externally built files - Glue supports files which may not be natively understood by FlatRedBall or your program. These files can be built with a separate program to be converted into a file format understood by your game. For example Tiled (.tmx) files can be built to a Scene (.scnx).

&#x20;
