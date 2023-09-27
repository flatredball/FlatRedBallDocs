## Introduction

The RenderToTexture2D method renders a given line and instantiates a Texture2D. The Texture2D will not be part of a ContentManager; therefore, you must add it to a content manager or manually dispose it when you are finished with it to prevent accumulation errors.

## Code Example

The following code shows how to create a Texture and display it on screen:

    // Assumes that bitmapFont is a valid BitmapFont
    Texture2D texture = bitmapFont.RenderToTexture2D("Hello");
    Sprite sprite = SpriteManager.AddSprite(texture);
    SpriteManager.Camera.UsePixelCoordinates();
    sprite.PixelSize = .5f;
