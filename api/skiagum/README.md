# SkiaGum

### Introduction

The SkiaGum namespace contains classes which can be used to integrate SkiaSharp into your FlatRedBall game. This integration supports the following common scenarios:

1. Using Skia objects in your Gum screens. The Gum tool provides a plugin which enables Skia objects such as RoundedRectangle, ColoredCircle, and Svg.
2. Using SkiaSpriteCanvas to create FlatRedBall Sprites which can draw custom Skia graphics.
3. Using RenderableSkiaObject to create Gum objects which support custom Skia graphics.

### Skia Availability

As of April 2024, Skia is supported only in FlatRedBall MonoGame DesktopGL projects. You can verify that your project has the Skia libraries included by checking the linked assemblies as shown in the following screenshot:

<figure><img src="../../.gitbook/assets/image.png" alt=""><figcaption><p>Skia prebuilt libraries linked in a FlatRedBall project</p></figcaption></figure>

Projects which link to source can optionally include the Skia libraries, as shown in the following screenshot:

<figure><img src="../../.gitbook/assets/image (1).png" alt=""><figcaption><p>Including source can include Skia</p></figcaption></figure>

If you are targeting a different platform (such as Android), please join the FlatRedBall Discord to discuss extending platform availability.

