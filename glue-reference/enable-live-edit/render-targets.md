---
description: >-
  At the time of this writing if you are rendering to a render target that is of
  different size than your game, then you may see that either:
---

# Render Targets

* Your game may not occup the entire screen
* Interacting with objects in your game may not align properly

You can solve this by disabling render targets in your game. For example, your draw code may look something like this:

```csharp
// make the engine draw to the buffer
GraphicsDevice.SetRenderTarget(buffer);

GeneratedDrawEarly(gameTime);
FlatRedBallServices.Draw();
GeneratedDraw(gameTime);

// reset the render target to null
GraphicsDevice.SetRenderTarget(null);

// draw the buffer to the screen
spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
var destinationRectangle = new Rectangle(0, 0, buffer.Width, buffer.Height);
spriteBatch.Draw(buffer, destinationRectangle, Color.White);
spriteBatch.End();

base.Draw(gameTime);
```

You can optionally render to a render target if not in edit mode. For example, after you change your code it might look like this:

```csharp
if(!ScreenManager.IsInEditMode)
{
    // make the engine draw to the buffer
    GraphicsDevice.SetRenderTarget(buffer);
}

GeneratedDrawEarly(gameTime);
FlatRedBallServices.Draw();
GeneratedDraw(gameTime);

if(!ScreenManager.IsInEditMode)
{
    // reset the render target to null
    GraphicsDevice.SetRenderTarget(null);

    // draw the buffer to the screen
    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
    //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, effect: activeEffect);
    var destinationRectangle = new Rectangle(0, 0, buffer.Width, buffer.Height);
    spriteBatch.Draw(buffer, destinationRectangle, Color.White);
    spriteBatch.End();
}

base.Draw(gameTime);
```

Note that future versions of FlatRedBall may provide options for handling render target scaling with the cursor, but as of the time of this writing this is not yet supported.
