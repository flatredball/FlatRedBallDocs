## Introduction

The AddManagedInvisibleSprite method can optionally create and add a Sprite or simply add an already-created Sprite to a list which receives full every-frame updates without being rendered. In other words, any Sprite that has passed through the AddManagedInvisibleSprite method will be fully functional (velocity, attachments, animation, instructions), but will not pass through the rendering code. This can be used if you are rendering your own Sprites using [IDrawableBatches](/frb/docs/index.php?title=FlatRedBall.Graphics.IDrawableBatch "FlatRedBall.Graphics.IDrawableBatch").

## When to use AddManagedInvisibleSprite

AddManagedInvisibleSprite is usually used in the following situations:

1.  Sprites which require management but will not be drawn for a long time (perhaps their entire life).
2.  Sprites which will be drawn using custom rendering code.
