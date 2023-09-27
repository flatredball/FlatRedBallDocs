## Introduction

The easiest way to create a Texture2D is to load a graphical file and create a Texture2D using FlatRedBallServices as follows:

    Texture2D myTextre = FlatRedBallServices.Load<Texture2D>("redball.bmp");

While this code addresses many common scenarios, you may want to create your own textures programatically. This section discusses various topics on how to create Texture2Ds in code.

## Creating a simple Texture2D

The following code creates a Texture2D which is all red, then displays the Texture2D using a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite").

Add the following using statement:

    Microsoft.Xna.Framework.Graphics.Texture2D;

    // Define the properties of the to-be-created Texture2D
    int textureWidth = 32;
    int textureHeight = 32;
    int numberOfMipmapLevels = 0;

    // Create the Texture
    Texture2D texture2D = new Texture2D(
        FlatRedBallServices.GraphicsDevice,
        textureWidth,
        textureHeight,
        numberOfMipmapLevels,
        TextureUsage.AutoGenerateMipMap,
        SurfaceFormat.Color);

    // Now let's modify the contents
    Color[] colorData = new Color[textureWidth * textureHeight];
    texture2D.GetData<Color>(colorData);
    for (int i = 0; i < colorData.Length; i++)
    {
        colorData[i] = Color.Red;
    }
    texture2D.SetData<Color>(colorData);

    // The Texture should probably be added to a ContentManager
    string nameOfTextureInContentManager = "Generated Texture";
    string contentManagerName = FlatRedBallServices.GlobalContentManager;
    FlatRedBallServices.AddDisposable(
        nameOfTextureInContentManager,
        texture2D,
        contentManagerName);

    // Finally create a Sprite to show the Texture2D
    SpriteManager.AddSprite(texture2D);

![GeneratedTexture.png](/media/migrated_media-GeneratedTexture.png)
