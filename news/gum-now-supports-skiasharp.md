SkiaSharp is a wrapper over the powerful [Skia graphics engine](http://skia.org). The latest version of FlatRedBall adds support for rendering Skia objects efficiently in your game. The current implementation of Skia provides a number of new primitives fully integrated with Gum.

![](/media/2022-12-img_63af1c180b9bd.png)

## New Primitives and Effects

The current version (as of this writing) adds support for three new primitive types: RoundedRectangle, ColoredCircle, and Arc. Let's take a look at each of the three independently.

### RoundedRectangle

RoundedRectangle is similar to ColoredRectangle, but adds support for rounded corners and effects as described below. As the name implies, RoundedRectangle supports rounded corners which are controlled by the CornerRadius property. [![](/wp-content/uploads/2022/12/30_10-18-42.gif.md)](/wp-content/uploads/2022/12/30_10-18-42.gif.md)

### ColoredCircle

ColoredCircle provides the ability to fill a circle with a solid color. It also supports effects as shown below. It fills the width of its bounding rectangle when its size changes. [![](/wp-content/uploads/2022/12/30_10-21-41.gif.md)](/wp-content/uploads/2022/12/30_10-21-41.gif.md)

### Arc

The Arc object can be used to draw an arc shape which can be used to draw timers, speedometers, and health. The Arc object exposes a number:

-   Start Angle - the angle (in degrees) where the angle begins. A value of 0 is equivalent to the 3 o'clock position, and positive values move counterclockwise (just like normal Gum and FlatRedBall rotation).
-   Sweep Angle - the angle controlling the angle drawn by the arc, following the same unit and direction as Start Angle.
-   Is End Rounded - Whether the end caps are round or a straight line.

[![](/wp-content/uploads/2022/12/30_10-28-57.gif.md)](/wp-content/uploads/2022/12/30_10-28-57.gif.md)

### Future Primitives

Gum currently also supports SVG and Lottie animations. Future versions of FlatRedBall will be adding these as well, but this first version is limited to these 3 primitives.

## Effects

These three new primitives also add new effects which can be assigned and previewed in Gum.

### Gradients

Gradients can be added to shapes. Gradients are specified using the following values:

-   Gradient Type - Whether to use a linear or radial gradients
-   Use Gradient - whether to use a gradient or solid color
-   Gradient X1 and Y1 - the X and Y position of the first color on the gradient
-   Gradient X2 and Y2 - the X and Y position of the second color on the gradient
-   Red/Green/Blue 1 - the color values used for the first color on the gradient
-   Red/Green/Blue 2 - the color values used for the second color on the gradient
-   Gradient X1 and Y1 Units - the Units used to position the first color values
-   Gradient X2 and Y2 Units - the Units

As shown in the following animation, gradients can be modified and previewed in the editor: [![](/wp-content/uploads/2022/12/30_10-39-22.gif.md)](/wp-content/uploads/2022/12/30_10-39-22.gif.md) Gradient units are useful if you want the gradients to respond to width or height changes, as shown in the following animation: [![](/wp-content/uploads/2022/12/30_10-48-08.gif.md)](/wp-content/uploads/2022/12/30_10-48-08.gif.md)

### Dropshadow

Dropshadows can be added using the Has Dropshadow property. When enabled, drop shadows have a number of variables controlling their appearance:

-   Dropshadow Offset X/Y - The X/Y offset in pixels of the drop shadow relative to the shape.
-   Dropshadow Blur X/Y - The number of pixels to blur the drop shadow. Note that drop shadow blurring uses a normal distribution dropoff. The value indicated here may not precisely contain the drop shadow but it is a fairly close approximation. A value of 0 results in no blur. The blurring for the drop shadow can be controlled independently on the X and Y axes.
-   Dropshadow Alpha - Controls the transparency of the drop shadow.
-   Dropshadow Red/Green/Blue - Allows the drop shadow to be colored. By default the color is black.

Note that the drop shadow renders outside of the shapes bounding rectangle. [![](/wp-content/uploads/2022/12/30_10-55-57.gif.md)](/wp-content/uploads/2022/12/30_10-55-57.gif.md)

### Stroke and Fill

Stroke and Fill control whether a shape is filled-in or if it only draws its outline. [![](/wp-content/uploads/2022/12/30_10-58-47.gif.md)](/wp-content/uploads/2022/12/30_10-58-47.gif.md)

### Future Effects

Skia supports may additional effects. Over time, additional ones will be added to Gum and they will automatically be available in your games.

## Adding Skia to Your Game

Skia can be added to your game in a number of ways:

1.  Add Skia Gum objects to your Gum Screens and Components
2.  Instantiate Skia Gum objects in code
3.  Manually render Skia objects to a Texture2D which is rendered by a Sprite

Working with Skia objects in code provides the ultimate flexibility and enables accessing additional Skia types and effects; however, for this document we'll focus on working with the Gum tool since it requires minimal additional code. Important: Skia is still considered to be in beta support. Therefore, some of the steps shown below may change as the feature matures. Furthermore, Skia is not currently part of the FlatRedBall build tools, so to use Skia in your project, you must be linked against FlatRedBall Source. These steps will be shown below.

1.  Verify that you have the Gum and FlatRedBall repositories checked out to your machine. The source is currently required since pre-built Skia FlatRedBall dlls are not yet in distribution at the time of this writing.

2.  Create or open a Desktop GL .NET 6 (or newer) project. Currently Skia Gum requires using the latest version of FlatRedBall. It is possible to add Skia Gum to earlier versions of FlatRedBall (and FlatRedBall iOS/Android projects), but the performance is significantly reduced.

    ![](/media/2022-12-img_63af2942b3c6f.png)

3.  Add FlatRedBall source files to your project. This can be done manually, or you can use the built-in command in the FlatRedBall Editor.
    1.  Select **Project** -\> **Link Game to FRB Source**

        ![](/media/2022-12-img_63af2a2c1cf0c.png)

    2.  Verify that the root folders are correct and check the **Include Gum Skia** checkbox

        ![](/media/2022-12-img_63af2a74e73f0.png)

    3.  Click **Link to Source. **If successful, the **Add FRB Source** tab will disappear.

Now your project is set up to support Skia objects in Gum. To add a Skia object to your Gum project:

1.  Open your project in Gum

    ![](/media/2022-12-img_63af2bdaea5be.png)

2.  In Gum, select **Plugins** -\> **Add Skia Standard Elements**

    ![](/media/2022-12-img_63af2c155d141.png)

3.  Your Standard folder should now contain the Skia elements

    ![](/media/2022-12-img_63af2c46050ad.png)

4.  Add Standard instances to your Screens or Components just like any other type of Standard object [![](/wp-content/uploads/2022/12/30_11-23-00.gif.md)](/wp-content/uploads/2022/12/30_11-23-00.gif.md)

After adding these instances, they will appear in your game.

![](/media/2022-12-img_63af2f403fd5e.png)

## More to Come!

Stay tuned, Skia introduces a huge set of new features which we'll be adding to Gum over time.
