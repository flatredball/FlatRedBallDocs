The latest version of the Tiled plugin adds per-layer Alpha and Color (Red, Green, and Blue) values, enabling even more flexibility in rendering .tmx files.

## Alpha From TMX

The Tiled program supports alpha values on each layer. Setting the alpha on a layer will automatically apply that alpha when the game runs. [![](/wp-content/uploads/2018/09/2018-09-30_13-28-22.gif.md)](/wp-content/uploads/2018/09/2018-09-30_13-28-22.gif.md)

## Changing Color/Alpha in Code

The latest plugin also adds the ability to change the color/alpha values in code. Since each layer is drawn independently, each layer can be adjusted on its own. For example, the following code shows how to adjust the alpha and color values of a map with 2 layers.

``` lang:c#
void CustomInitialize()
{
    var firstLayer = Level1File.MapLayers[0];

    // 1 means to show the color as-is in the TMX
    firstLayer.Red = 1;
    firstLayer.Green = 0;
    firstLayer.Blue = 0;

    var secondLayer = Level1File.MapLayers[1];
    secondLayer.Alpha = .75f;
}
```

This code will produce the following when the game runs:

![](/media/2018-09-img_5bb124aa4dc72.png)

The above image and code use the following tilemap:

![](/media/2018-09-img_5bb12512acd4b.png)

When adjusting layer color and alpha values, keep in mind:

-   Each layer can be adjusted independently
-   Alpha values in code will overwrite the **Opacity** value set in Tiled
-   Color values apply a *Modulate* (also called *multiply*) effect. For information on how Modulate works, see the [Modulate page](/documentation/api/flatredball/flatredball-graphics/flatredball-graphics-coloroperation/flatredball-graphics-coloroperation-modulate/.md).
-   Color values of 1 will result in the map being drawn without any modifications. A value of 0 will remove the particular color. In the example above, Green and Blue are set to 0, which is why the map draws red.
-   Values can be greater than 1 to make maps draw with additional brightness

Version 1.7.0 of the [Tiled plugin is available now](http://www.gluevault.com/plug/94-tiled-plugin), so you can start modifying your game's tile map color and alpha values right away.
