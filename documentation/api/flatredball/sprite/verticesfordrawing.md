## Introduction

The VerticesForDrawing member that is sometimes used internally by FlatRedBall to draw Sprites. This member can be used to perform custom drawing in [IDrawableBatches](/frb/docs/index.php?title=FlatRedBall.Graphics.IDrawableBatch.md "FlatRedBall.Graphics.IDrawableBatch").

## When is the VerticesForDrawing member valid?

The VerticesForDrawing is used to store vertices for one of two reasons:

1.  To prevent every-frame calculation of vertices when it is not needed
2.  To provide vertex information for custom drawing

If a Sprite is automatically updated and drawn by FlatRedBall (the default behavior), then the engine **will not** create or maintain this member. This is because the engine assumes that automatically updated, drawn Sprites will not be used for custom drawing. Also, the vertices will be re-calculated every frame so there is no need to store this information.

## Creating Sprites for custom rendering

The first step in creating a Sprite for custom rendering is to use the SpriteManager to create a Sprite. This can be done with the AddManagedInvisibleSprite Sprite:

    Sprite newSprite = SpriteManager.AddManagedInvisibleSprite();

This will instantiate a Sprite and add it to the engine for every-frame updates so that properties like Velocity and Acceleration are applied and so that attachments work properly. However, this Sprite will not be drawn by FlatRedBall. This Sprite can now be used in [IDrawableBatches](/frb/docs/index.php?title=FlatRedBall.Graphics.IDrawableBatch.md "FlatRedBall.Graphics.IDrawableBatch") for custom rendering.

## Updating VerticesForDrawing

To update a Sprite's VerticesForDrawing, its ManualUpdate method must be called. In general this should be called inside your [IDrawableBatch's](/frb/docs/index.php?title=FlatRedBall.Graphics.IDrawableBatch.md "FlatRedBall.Graphics.IDrawableBatch") Update method:

    SpriteManager.ManualUpdate(spriteToDraw);

Assuming the Sprite is not drawn by the engine (it was created with AddManagedInvisibleSprite), then this Sprite's VerticesForDawing will be usable in rendering code.

## Rendering with VerticesForDrawing

The VerticesForDrawing array is an array of four [VertexPositionColorTextures](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.graphics.vertexpositioncolortexture.aspx) which can be used internally for rendering. Notice that there are only four vertices, although Sprite rendering is done with triangles (which would require six vertices). If you are using VerticesForDrawing, you will need to duplicate the vertices if using a triangle list, or use an index buffer.

## Code Example

For an example on how to perform custom Sprite rendering, see [this page](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Custom_Sprite_Effects.md "FlatRedBallXna:Tutorials:Custom Sprite Effects").
