## Introduction

The PolygonEditor can load .scnx files. These files are the standard way of representing collections of FlatRedBall objects including Sprites, SpriteFrames, and PositionedModels. The [SpriteEditor](/SpriteEditorWiki/index.php?title=Main_Page.md) is one of the many applications that can create .scnx files.

## Loading a .scnx File

To load a .scnx file:

-   Select File-\>Load Scene
-   Select the file to load

The .scnx File will appear in the PolygonEditor.

## Saving a .scnx File

The PolygonEditor does include the option to save .scnx files; however, **.scnx files do not store any shape information!**. In other words, if you have added polygons, circles, and rectangles while a .scnx is open, then you save the .scnx, the .scnx will not contain any of the added shapes. You must save either a .plylstx or .shcx file.
