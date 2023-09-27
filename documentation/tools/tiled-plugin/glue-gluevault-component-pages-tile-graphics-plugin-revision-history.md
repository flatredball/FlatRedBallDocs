### Updated November 22, 2015

-   Plugin now properly closes its tabs when the project closes.

### Update July 15, 2015

-   Added scrollbars to the tileset preview window.

### Update June 26, 2015

-   Fixed bug where tilesets wouldn't get saved when changing names or adding properties.

### Update June 16, 2015

-   Improved tile rotation support

### Update May 9, 2015

-   Added support for TileShapeCollection solid collisions vs. Circle and Polygon

### Updated May 7, 2015

-   Improved handling of CopyImages = false - the images are now kept in their original location.
-   Fixed bug where changing command line parameters wouldn't update the file itself
-   Fixed bug where changing command line parameters wouldn't save the .glux
-   Image copying now attempts 5 times on failure in case it's locked by another image copy
-   Image copying now checks dates, which will eliminate continual copy loops and will improve performance

### Updated April 28, 2015

-   Generate fully-qualified names for classes since Glue generated code no longer has using statements.

### Updated April 17, 2015

-   Updated to latest change where Model namespace and all contained objects have been removed
-   Fixed a bug where animations would not get generated correctly if running in a locale where the ',' character is used as a decimal separator.

### Updated April 11, 2015

-   Updated to latest TMX-\>SCNX conversion which used to crash if individual images were used per-tile. Now an error message is printed

### Updated March 30, 2015

-   Updated to removal of the XnaInitialize event which caused the plugin to crash.

### Updated February 26, 2015

-   Updated to latest Glue build which defines the core Gum .dlls instead of requiring plugins to do it.

### Updated January 22, 2015

-   Fixed crash bug when generating object TMX with no objects.

### Updated January 18, 2015

-   Fixed lots of bugs with animation.

### Updated January 17, 2015

-   Fixed various crashes and less-than-helpful errors occurring when a .tmx file uses an external tileset that can't be found.
-   Fixed external tileset references being made incorrectly when two .tmx files are in different folders.
-   Fixed incorrect positioning of entities

### Updated January 15, 2015

-   Updated to the breaking Task changes in Glue, to make everything async but run in series.

### Updated Decmeber 29, 2014

-   Now works for Windows RT projects

### Updated Decmeber 22, 2014

-   Improved support for picking tile set from other map
-   Fixed (I think) a weird texture coordinate bug in tile maps.

### Updated November 20, 2014

-   Added improved creation of .shcx files from TMX. Now supports rotation and circles/ovals.

### Updated November 11, 2014

-   Removed unneeded .dlls

### Updated October 22, 2014

-   Added support for new animations in Tiled 0.10.x
-   Added functionality that automatically assigns names to tiles in tile sets when the user adds properties but doesn't name them. This makes working with animations easier.
-   Fixed bug where plugin would ask you about tileset properties when selecting a .tsx
-   Added UI to specify tile dimensions when creating a new TMX file through the level UI.

### Updated October 5, 2014

-   Fixed bug where maps wouldn't work properly with z buffering. The reason for this was layers were offset and contained quads were also offset.

### Updated September 8, 2014

-   Improvements to level creation.

### Updated July 11, 2014

-   .exe builders are added right when a project is loaded instead of after. This means that files which are built will no longer try to build before the .exe is there to handle the build.
-   Changing a .tsx file will result in all TMX files using it being rebuilt.

### Updated May 22, 2014

-   Updated to latest renderer code so it can coexist with latest Gum plugin.

### Updated May 9, 2014

-   Embedded code no longer uses SpriteEditorScene - it instead uses SceneSave to remove warnings from the project.

### Updated April 8, 2014

-   TILB files now obey Z value offsets
-   Fixed TileShapeCollection not having a Name property - this is needed for Glue generation, and is useful to have for debugging anyway.

### Updated March 24, 2014

-   Fixed bug where new projects would be broken because of missing TileInfo class.
-   Lots of new functionality for shared TSX files. More to come here.

### Updated February 24, 2014

-   Added support for .tilb files to contain layer name information. The resulting MapDrawableBatch will now have Layers which match the names of the Layers in Tiled.
-   MapDrawableBatch now stores its Layers in a PositionedObjectList. This means that calling Destroy on an individual Layer will now remove it from the MapDrawableBatch.
-   Added TileShapeCollection.CollideAgainst - one override for AxisAlignedRectangle and one for Circle
-   TileShapeCollection is now smarter about sorting.

### Updated February 23, 2014

-   Added support for editing/saving external tileset files (.tsx)

### Updated February 14, 2014

-   Plugin now properly tracks file references for .tilb files.
-   Plugin adds TileShapeCollection as a possible object type to Glue so you can instantiate TileShapeCollections through Glue as an object in a Screen.

### Updated February 10, 2014

-   Fixed a crash issue related to a missing .dll

### Update February 7, 2014

-   Standardized the Name and HasCollision properties by making the plugin UI
-   Fixed a few more issues with calculating the \# of tiles wide of a tile set

### Updated January 26, 2013

-   CSVs will now be generated with rows for every tile whether it has a Name or not. If not, then it will apply a default name to it.
-   Fixed a bug where "Name (required)" and "Name (string)" were not recognized as the same key in the CSV converter.
-   Fixed a bug where .scnx files would be generated incorrectly because of the wrong calculated tile width. This was happening because margin wasn't being subtracted from left and right sides.
-   Fixed some issues with how tilesets were displayed in the tileset visualizer in Glue.

### Updated December 30, 2013:

-   Added to the latest TMX to SCNX:
    -   Added support for copyimages=false

### Updated October 16, 2013:

-   Updated to the latest TMX to SCNX converter which supports terrain functionality.

### Updated October 3, 2013:

-   Fixed a number of rendering offset issues.
-   Fixed a bug where properties wouldn't show up on any tilesets after the first.
-   Updated to the latest Gum rendering engine which fixes various minor bugs.

### Updated September 1, 2013:

-   Added TileShapeCollection - a object specifically made for tile based collision to address snagging, provide a simpler interface, and significantly improved performance over using a ShapeCollection for tile based collision.

### Updated August 18, 2013:

-   Improved error reporting when a tile map references a missing file.
-   Fixed crash occurring when a tile map references a missing file.
-   Fixed startup error caused by the latest rendering library.

### Updated June 8, 2013:

-   Added TMX to NNTX support for this plugin. It was forgotten, and a bug on redmine reminded me.

### Updated June 5, 2013:

-   Removed debug code causing a crash.
-   Added the .tmx as an embedded resource to be used when adding a new tmx file through right-click Glue.

### Updated June 4, 2013:

-   Fixed some types not showing up when creating a new file.

### Updated May 8, 2013:

-   Uses the latest Glue fixes to re-enable output on both successful and failed conversions.
-   Adds support for new TILB file which can be loaded into a LayeredTileMap. This reduces file sizes to 1/33 of previous sizes, and load times are much faster.

### Update April 14, 2013:

-   The MapDrawableBatch no longer applies Z values to contained objects. The reason for this is the Z value of the entire IDB itself should be used. This allows it to sort the same with both z buffered and ordered objects.

### Update January 19, 2013:

-   Updated to the latest TMX converter which fixes lots of bugs
-   Added new editor allowing you to view properties on tilesheets (editing will be coming)
-   Added new editor allowing you to view and edit properties on layers

### Update December 22, 2012:

-   Each layer in the LayeredTileMap now updates its position according to the entire map. This allows the map to be moved around by using its X,Y,Z
-   Fixed a problem where each layer was not properly ordering - related to the fix above.
