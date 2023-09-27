## Introduction

SpriteBatch allows games to render 2D graphics to screen. Unlike FlatRedBall's Sprite class, SpriteBatch performs *immediate rendering* - drawing with SpriteBatch results in graphics appearing for only one frame. To keep SpriteBatch graphics on screen for an extended amount of time, Draw must be called every frame. By contrast, FlatRedBall Sprites can be created one time and they will continue to appear on screen until removed from the engine. Three calls are required to render graphics using SpriteBatch:

1.  SpriteBatch.Begin - sets initial values to be used for all Draw calls until End is called
2.  SpriteBatch.Draw - draws a single sprite to the screen. Draw can be called multiple times between Begin and End, and performing multiple Draw calls between a Begin and End call can improve performance when compared to repeatedly calling Begin and End.
3.  SpriteBatch.End - ends the drawing and presents the visuals on-screen or on the current RenderTarget2D.

## Code Example

The SpriteBatch.Draw method is used to render a Texture2D to screen. The Texture2D used can come from anywhere, including Texture2D instances loaded through Glue. The following code shows how to draw an image on screen.   FINISH HERE after Entities support IDrawableBatch
