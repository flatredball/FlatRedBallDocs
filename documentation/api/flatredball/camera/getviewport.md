## Introduction

The GetViewport method can be used to get a reference to the current Microsoft.Xna.Framework.Graphics.Viewport with the calling Camera's properties applied.

## GetViewport returns a reference to the current Viewport

The GetViewport method does the following:

-   It first grabs the GraphicsDevice's Viewport
-   It sets the Viewport's X, Y, Width, and Height
-   It returns the reference to the GraphicsDevice's Viewport

Therefore, if you call GetViewport on two different Cameras, you will have the same Viewport:

    // Assuming Camera1 and Camera2 are valid Cameras
    Viewport viewport1 = Camera1.GetViewport();
    Viewport viewport2 = Camera2.GetViewport();

    if(viewport1 == viewport2)
    {
       // This will be true!
    }
