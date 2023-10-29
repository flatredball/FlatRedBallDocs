## Introduction

Render breaks (which sometimes are called render state changes) can be the source of significant slowdown in situations where a large number of Sprites are being rendered. The Windows Phone 7 platform is especially sensitive to render breaks, so reducing render breaks can significantly increase performance.

## What is a render break?

Before we get into the specifics, let's discuss what a render break is. A render break occurs whenever the graphical device (the core XNA object which is responsible for rendering) must change a rendering state. A rendering state is essentially a value that gets set on the graphics device which is used for rendering.

To understand render states we need to discuss the way that rendering works in XNA (and other graphical APIs like DirectX and OpenGL). The general idea when rendering 3D graphics is that first the code must set up the render states, then it draws "primitives" (lines, triangles, and in some cases quads).

Obviously the actual implementation is more complicated, but the code might be something along the lines of:

-   Set the texture to redball (this is a state change)
-   Render triangle1
-   Render triangle2
-   Render triangle3
-   Render triangle4
-   Set the texture to greenball (this is a state change)
-   Render triangle5
-   Render triangle6
-   Render triangle7
-   Render triangle8
-   Set the texture to redball (this is a state change)
-   Render triangle9
-   Render triangle10
-   Render triangle11
-   Render triangle12

In the example above, we render 4 triangles, then change a state. On most platforms (especially Windows Phone 7), the state changes are the most time-consuming calls, while the individual render calls to the triangles are very fast!

## How to make it faster

If we look at the examples above, we notice that the redball texture is used on triangles 1-4 and 9-12. The greenball texture is used on triangles 5-8. This means that if all we were interested in is speed, we could reduce render breaks by rendering 1-4 and 9-12 together, then switching to green for the remaining four triangles:

-   Set the texture to redball (this is a state change)
-   Render triangle1
-   Render triangle2
-   Render triangle3
-   Render triangle4
-   Render triangle9
-   Render triangle10
-   Render triangle11
-   Render triangle12
-   Set the texture to greenball (this is a state change)
-   Render triangle5
-   Render triangle6
-   Render triangle7
-   Render triangle8

Notice that after the reordering, we can render the same number of triangles with only two state changes instead of three. While this may seem like a small performance boost, it can make a very large difference when dealing with hundreds of sprites on mobile platforms.

## Why not always order to reduce render breaks?

If reducing render breaks improves performance, why doesn't the FlatRedBall Engine automatically reorder the Sprites that it renders to reduce state changes?

If it did, it is true that performance would improve significantly; however, this is something that the engine can't do because the order in which objects are drawn can impact how they appear. FlatRedBall sprites support partial transparency, and when objects are partially transparent, they must be drawn in a specific order to appear correctly. This means that while render performance would greatly increase if the engine automatically reordered Sprites according to render breaks, it actually is forced to order them by their Z value so that they are drawn properly.

Fortunately we're not completely at the mercy of the Z value of Sprites. The following tutorials will explain how to reduce render breaks.
