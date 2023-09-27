## Introduction

The BlendOperation enumeration defines possible blend operations which can be used by an [IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable") to modify how it draws over its background. For more information, see the [IColorable](/frb/docs/index.php?title=FlatRedBall.Graphics.IColorable.md "FlatRedBall.Graphics.IColorable") wiki entry.

## Example - Visualizing Blend Operations

The following image shows how the four blend operations impact a sprite drawn on top of a gray background:

![](/media/2017-05-img_5913ee3513468.png)

Notice that the alpha value does not result in transparency when using the Modulate2X BlendOperation. Note that the SubtractAlpha BlendOperation is not displayed above since it does not have an affect when rendering unless the object is placed on a RenderTarget.
