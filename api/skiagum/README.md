# SkiaGum

### Introduction

The SkiaGum namespace contains classes which can be used to integrate SkiaSharp into your FlatRedBall game. This integration supports the following common scenarios:

1. Using Skia objects in your Gum screens. The Gum tool provides a plugin which enables Skia objects such as RoundedRectangle, ColoredCircle, and Svg.
2. Using SkiaSpriteCanvas to create FlatRedBall Sprites which can draw custom Skia graphics.
3. Using RenderableSkiaObject to create Gum objects which support custom Skia graphics.

### Skia Availability

As of April 2024, Skia is supported only in FlatRedBall MonoGame DesktopGL projects. You can verify that your project has the Skia libraries included by checking the linked assemblies as shown in the following screenshot:

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Skia prebuilt libraries linked in a FlatRedBall project</p></figcaption></figure>

Projects which link to source can optionally include the Skia libraries, as shown in the following screenshot:

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Including source can include Skia</p></figcaption></figure>

If you are targeting a different platform (such as Android), please join the FlatRedBall Discord to discuss extending platform availability.

Note that Skia works on MonoGame DesktopGL, and with a little work it can work on mobile platforms, but it will not run on consoles without significant work. Practically speaking, Skia should not be used if your game will target consoles unless you are willing to make changes to Skia.

### Adding Skia Elements to Gum Projects

To add Skia controls to a Gum project:

1. Open your project in the FlatRedBall Editor
2. If your game wasn't created using the wizard, make sure you have added a Gum project
3. Open your Gum project by clicking the Gum icon at the top of FlatRedBall
4.  Click **Plugins** -> **Add Skia Standard Elements**\


    <figure><img src="../../.gitbook/assets/image (112).png" alt=""><figcaption><p>Add Skia Satandard Elements menu item in Gum</p></figcaption></figure>

You should now see the newly-added Skia elements under the Standard folder.

<figure><img src="../../.gitbook/assets/image (113).png" alt=""><figcaption><p>Skia standard elements in the Standard folder</p></figcaption></figure>

### Using Skia in Your Gum Screen

Once you have added Skia elements to your Screen you can use these elements in your Gum screens and components just like any other type of Gum object. For example, a ColoredCircle can be added to the MainMenuGum screen by drag+dropping the ColoredCircle standard into the workspace in Gum.

<figure><img src="../../.gitbook/assets/11_06 31 58.gif" alt=""><figcaption><p>Adding a ColoredCircle to the MainMenuGum screen</p></figcaption></figure>

The ColoredCircle is also shown in your game, assuming the matching Screen is the startup screen.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>A ColoredCircle in a FlatRedBall game</p></figcaption></figure>
