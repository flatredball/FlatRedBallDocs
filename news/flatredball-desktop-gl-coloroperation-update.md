## Introduction

The latest version of FlatRedBall Desktop GL (the recommended replacement for FlatRedBall XNA) includes full support for all FlatRedBall color operations. Specifically, today's release adds the following color operations which were previously unavailable:

-   Add
-   InterpolateColor
-   InverseTexture
-   Modulate2X
-   Modulate4X
-   Subtract

These new color operations can be used to add more flexibility to how your sprites are rendered, and no longer requires custom code when moving from XNA to Desktop GL.

## Using the Color Operations

Color operations can be previewed quickly through the Glue preview window (aka GlueView). The best way to learn about how these work is to create a sprite and test out different combinations of color operations and color values. ![](/media/2018-07-2018-07-28_12-14-42.gif)

## Breaking Changes

This change introduces a few minor breaking changes. If your project is experiencing any problems see the sections below for fixes.

### Adding shader.xnb

Your project may have a crash when first running because of a missing file. The error message my look like:

``` wrap:true
Microsoft.Xna.Framework.Content.ContentLoadException: 'The content file was not found.'

Inner Exception
FileNotFoundException: Could not find file 'YourProjectDirectory\bin\DesktopGL\x86\Debug\Content\shader.xnb'.
```

The new color operations are implemented using a custom shader (the same shader file used in FlatRedBall XNA). Desktop GL projects created prior to this release will not have this file, so it needs to be added manually. To do this:

1.  Create a brand new DesktopGL project
2.  Open the new project's Content folder
3.  Find the shader.xnb file
4.  Open your existing project in Visual Studio
5.  Drag+drop the **shader.xnb** file into your project's **content** folder
6.  Change the newly-created file's **Build Action** to **Content**
7.  Change **Copy to Output Directory** to **Copy if newer**

[![](/media/2018-07-2018-07-28_09-39-36.gif)](/media/2018-07-2018-07-28_09-39-36.gif)

### 'ColorOperation' does not contain a definition for 'None'

The (confusing) ColorOperation.None  has been completely removed from FlatRedBall. Conceptually, every graphical object must have a color operation, and ColorOperation.None  was internally treated as ColorOperation.Texture . If your code uses ColorOperation.None , you can either convert it to ColorOperation.Texture , or you can make the ColorOperation a nullable if you need to distinguish between a specifically set value and an uninitialized value.

## Learn More

The ColorOperation documentation provides additional information and examples. Check it out [here](/documentation/api/flatredball/graphics/coloroperation.md) to see what kind of visual effects you can add to your game.
