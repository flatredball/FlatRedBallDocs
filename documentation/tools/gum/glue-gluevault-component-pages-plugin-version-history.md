## Gum plugin history no longer maintained, see github repository.

## August 26, 2016

-   Added support for Gum behaviors
-   Updated to latest Glue plugin changes.

## January 2, 2016

-   Added support for playing and stopping animations through the animation itself, rather than dealing with the instructions.
-   Added a Destroy method which will both remove components from managers but also will stop all animations.

## May 12, 2015

-   Fixed bug where incorrect camera values were set if the FRB Camera is 3D.

## May 10, 2015

-   Fixed order of Parent assignment causing objects to draw in the wrong order.

## March 17, 2015

-   Big improvements in UpdateLayout performance
-   Big improvements in content caching - both textures and .fnt files
-   Added nineslice spritesheet support
-   Removed duplicate updating of the engine
-   Added support for standalone components without a backing screen - IDB is automatically created
-   Removed the creation/destruction of the IDB for Gum, it now persists the entire project

## February 26, 2015

-   Updated plugin to latest Glue which defines the .dlls for all the Gum plugin dlls.

## December 5, 2014

-   Generated classes are now public to fix possible compile errors.
-   Exposed state variables now generate correctly.
-   Gum file types are now hidden from "Add New File" option.
-   Plugin can survive trying to open bad XML files for file reference tracking (it used to crash).

## December 4, 2014

-   Fixed bug caused by deleting .gumx file after adding it to the project.
-   Removed the ability to add new gumx, gucx, and gusx files to a Glue project by right-clicking on files. It's all done through the new menu items provided by the plugin now.

## September 24, 2014

-   (Bug) Fixed possible error on startup.

## September 18, 2014

-   (Feature) Added support for relative animations
-   (Feature) StandardElement Runtime objects now have states generated for them
-   (Bug) CustomInitialize on Gum runtime objects now gets called after AddToManagers - which matches Glue Entity behavior.
-   (Bug) Fixed lots of code generation issues related to state and state variables
-   (Bug) Fixed lots of code generation issues related to exposing SourceFile variable

## August 29, 2014

-   Added support for RollOn, RollOver, and RollOff events
-   More fixes to the new animation system
-   Fixed a bug when generating DimensionUnit variables
-   Fixed a bug when generating exposed variables with spaces.
-   Sprites of width 0 now actually go to width 0 (needed in animations)

## August 23, 2014

-   LOTS of fixes to code generation generating the wrong variable names.
-   Added animation support.

## August 9, 2014

-   Updated to the latest version of Glue which now includes the RenderingLibrary and ToolsUtilities dlls as part of core Glue. This resolves the issue of this plugin having .dlls that conflict with the Tile Map Graphics Plugin and AnimationEditor plugin.
-   Made Text texture generation more intelligent - the Texture will no longer be re-generated unless the dimensions of the Text object have changed in response to a layout update.

## July 20, 2014

-   Added state InterpolateBetween function (same as Glue)
-   Added state InterpolateTo using tweeners (same as Glue)
-   This plugin now has the StateInterpolation plugin embedded in it, so users don't need to install that first to use the state interpolation mentioned above.
-   Fixed a rendering issue caused by text objects rendering to render targets.

## July 13, 2014

-   If an instance sets states the generated code will now properly handle them

## July 11, 2014

-   Plugin will no longer add GumCore code to projects that don't have .gumx files as part of them.

## July 8, 2014

-   Fixed some texture creation bugs for Text objects introduced by the last release.
-   Fixed a lot of bugs related to setting States on GraphicalUiElements. It works much better.

## June 29, 2014

-   Gum plugin will update code files if they are out of date automatically - no need to manually delete code files anymore.
-   Removing objects from Gum will be properly removed from the Visual Studio project - no need to manually delete these files.
-   Text generation is **much** faster now.
-   Simple project works on iOS!

## June 22, 2014

-   Gum plugin now properly handles container instances
-   Gum plugin no longer causes compile errors for children stacking.
-   Containers will now draw according to the settings for drawing lined rectangles
-   Stacking, wrapping, and clipping are now set on GUE's according to what's in the gum file.

## June 12, 2014

-   Fixed a bug that would cause error messages in Glue.

## June 8, 2014

-   Added support for Gum objects to be on FRB Layers. Can be set in code and Glue.

## May 31, 2014

-   Gum runtime objects are now partial.

## May 28, 2014

-   Fixed a bug where code generation would at times not assign instances when they come from file.
-   Fixed rendering bug where Gum would write to the depth buffer preventing things on top from rendering.

## May 26, 2014

-   Fixed bug where code would not compile if text included a "\\"

## May 25, 2014

-   Fixed compile and runtime errors introduced by adding SortableLayers for clipping children.

## May 22, 2014

-   Added support for Font Scaling
-   Fixed a number of code gen bugs related to the latest changes in Gum allowing users to set Texture Address and scale values.

## May 18, 2014

-   Lots of fixes on making code generation and runtime object creation still work when dealing with Gum projects with missing Entities and invalid source
-   Fixed code generation issues related to instances with spaces
-   Fixed code generation issues related to variables existing after renames

## May 13, 2014

-   Added support for the new tiling system for Sprites introduced in Gum v.0.5.1
-   Added support for setting texture coordinates in code and through states
-   Matched the version numbers of Gum to make it easier to identify if the plugin is out of date or not

## May 10, 2014

-   Sprite Blend is now properly handled in states.

## May 9, 2014

-   Fixed file reference tracking bug that would occur when switching between multiple projects that had gum projects.

## May 5, 2014

-   Empty Glue project with Gum no longer generates any warnings when compiling.

## May 4, 2014

-   Fixed "OutlineThickness" variable causing compile errors
-   Fixed various errors related to the plugin not refreshing code when it should
-   Runtime objects now obey Visible property in XML
-   Plugin no longer tries to generate elements if there is no .gumx loaded.
-   Fixed more compile errors in state code generation
-   Instances now use \_'s instead of spaces in their names.

## April 27, 2014

-   Added support for states and state categories.
-   Fixed a bug where code would generate for old version of file when file change was detected by Glue.
-   Added support for custom fonts.
