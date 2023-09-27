## Introduction

RenderableSkiaObject provides common implementation for rendering Skia graphics in the Gum rendering system. This class simplifies the implementation of interfaces necessary to render Skia objects. It also provides implementation for interfaces so it can be used as a renderable object by Gum objects (GraphicalUiElement). Custom classes can inherit from RenderableSkiaObject to provide custom Skia rendering code, which is useful for custom situations which are not supported by Gum.

## Code Example - Rendering a Circle in Code

The following class provides an example of how to inherit from RenderableSkiaObject to provide custom rendering:

    public class CustomRenderable : RenderableSkiaObject
    {
        public override void DrawToSurface(SKSurface surface)
        {
            // Any skia code works here, but we'll draw an orange circle as an example:
            var canvas = surface.Canvas;

            using var paint = new SKPaint();
            paint.Color = SKColors.Orange;

            var radius = Width/2;
            canvas.DrawCircle(new SKPoint(radius, radius), radius, paint);
        }
    }

This object can be used as a standalone object or it can be added to a Gum GraphicalUiElement. Adding to a GraphicalUiElement is easier and provides more layout flexibility so we'll do that. The following code can be added to a Screen to draw the CustomRenderable:

    // Add this at class scope so it can be removed in CustomDestroy:
    GraphicalUiElement container;

    void CustomInitialize()
    {
        var renderable = new CustomRenderable();
        container = new GraphicalUiElement(renderable, null);
        // This acts as the size of the canvas:
        container.Width = 300;
        container.Height = 300;
        container.AddToManagers();
    }

    void CustomActivity(bool firstTimeCalled)
    {
    }

    void CustomDestroy()
    {
        container.RemoveFromManagers();
    }

This code results in an orange circle with width and height of 300 (radius of 150) being drawn at the top left of the screen.

![](/media/2023-01-img_63d7ca3bd82ef.png)
