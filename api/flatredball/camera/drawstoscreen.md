# DrawsToScreen

### Introduction

The DrawsToScreen property controls whether what the Camera draws is shown on screen. By default this property is true. This should be set to false if you are interested in obtaining the contents of the Camera (usually as a Texture) but you do not want these contents to be drawn to the screen. This property can also be set to false if you plan on drawing the contents to the screen manually instead of using FlatRedBall.

### Code Example

The following code sets DrawToScreen to false, gets the resulting render as a Texture2D, then renders this Texture2D using XNA's SpriteBatch class. Add the following at class scope:

```
SpriteBatch spriteBatch; // This is the XNA SpriteBatch object
```

Add the following to Initialize after initializing FlatRedBall:

```
SpriteManager.AddSprite("redball.bmp");
SpriteManager.Camera.DrawsToScreen = false;
spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
```

Modify your Draw method so it looks like this:

```
protected override void Draw(GameTime gameTime)
{
    FlatRedBallServices.Draw();
   
    // now that FRB is done, let's get the texture and draw it to the screen
    Texture2D texture = SpriteManager.Camera.GetRenderTexture(RenderMode.Default);

    // let's clear the background to show this is working ok
    graphics.GraphicsDevice.Clear(Color.Red);

    spriteBatch.Begin();
    // This is the top-left quarter of the screen under the default setup
    Rectangle destinationRectangle = new Rectangle(0, 0, 400, 300);

    spriteBatch.Draw(texture, destinationRectangle, Color.White);
    spriteBatch.End();
    base.Draw(gameTime);
}
```

![DrawsToScreen.png](../../../.gitbook/assets/migrated\_media-DrawsToScreen.png)
