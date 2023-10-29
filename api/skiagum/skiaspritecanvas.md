## Introduction

The SkiaSpriteCanvas type provides a Skia canvas which can be used to render any Skia graphics. All rendering performed on the canvas is efficiently converted to a Texture2D. SkiaSpriteCanvas inherits from the standard FlatRedBall Sprite, so it provides all of the common Sprite functionality including:

-   Attachment to entities
-   Sorting according to the SpriteManager settings
-   Rotation, position, and size
-   Velocity and acceleration values

## Adding SkiaSharp

At the time of this writing, SkiaSharp must be manually added to your project as explained in this blog post: https://flatredball.com/news/gum-now-supports-skiasharp/ Future versions of FlatRedBall may automatically include SkiaSharp as part of new projects.
