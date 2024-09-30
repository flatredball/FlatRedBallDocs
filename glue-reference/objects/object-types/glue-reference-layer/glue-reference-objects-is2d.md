# Is2D

### Introduction

The Is2D option can be used to make a Layer use 2D coordinates. Layers which are 2D can be used even if the current Camera is in 3D. Layers which are 2D are often used to create HUDs and UI Screens.

![](../../../../.gitbook/assets/2016-04-img\_572276954d277.png)

For information on how to use Layers in code, see [the Layer reference page](../../../../documentation/tools/glue-reference/objects/glue-reference-layer.md).

### Common Usage

The most common usage of the Is2D property is to create a 2D layer in a game which uses a 3D camera. Typically 3D games will have some type of 2D hud, so a 2D layer is needed to hold hud.

### 2D Layer on a 3D camera

This example shows a simple setup where a 2D layer can be used on a 3D graphic. First, the game is set up to use a 3D camera.

![](../../../../.gitbook/assets/2017-02-img\_58a1d6a552f4a.png)

Next, a Sprite is added to a GameScreen. It has the following variable values:

*   Texture = GroundTexture

    ![](../../../../.gitbook/assets/2017-02-img\_58a1d772cfa7e.png)
* Right Texture Pixel = 512
* BottomTexturePixel = 512
* Texture Address Mode = Wrap
* Y = -10
* Rotation X = 1.5708

![](../../../../.gitbook/assets/2017-02-img\_58a1d7a38142d.png)

The GameScreen has a layer named **Layer2D** for 2D objects.

![](../../../../.gitbook/assets/2017-02-img\_58a1d808956f8.png)

Finally the **GameScreen** has a Text instance called **GameOverText** which has been placed on **Layer2D.**

![](../../../../.gitbook/assets/2017-02-img\_58a1d84d86ed1.png)

The result is **SpriteInstance** is drawn in 3D, but the **GameOverText** is drawn and positioned in 2D.

![](../../../../.gitbook/assets/2017-02-img\_58a1d877b37d3.png)
