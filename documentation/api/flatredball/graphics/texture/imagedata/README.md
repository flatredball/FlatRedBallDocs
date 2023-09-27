## Introduction

The ImageData class represents modifiable data that can be created from a [Texture2D](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D "Microsoft.Xna.Framework.Graphics.Texture2D"), or be used to construct a [Texture2D](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D "Microsoft.Xna.Framework.Graphics.Texture2D"). The ImageData class can be used to easily interact with the [Texture2D](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D "Microsoft.Xna.Framework.Graphics.Texture2D") class, and also provides a cross-platform way of creating and modifying textures.

## Creating Textures

Add the following using statements:

    using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
    using Color = Microsoft.Xna.Framework.Graphics.Color;
    using FlatRedBall.Graphics.Texture;

Add the following to Initialize after initializing FlatRedBall:

    ImageData imageData = new ImageData(32, 32);

    imageData.Fill(Color.Blue);

    // let's plot some random pixels:

    for (int i = 0; i < 50; i++)
    {
        int randomX = FlatRedBallServices.Random.Next(
            imageData.Width);
        int randomY = FlatRedBallServices.Random.Next(
            imageData.Height);

        imageData.SetPixel(randomX, randomY, Color.Yellow);
    }

    // Create the texture
    Texture2D texture2D = imageData.ToTexture2D();
    // Give it a name.  Make sure this is unique!
    texture2D.Name = "MyDynamicTexture";

    // We will want to associate the created Texture2D with a
    // ContentManager.  If you're in a Screen, use the Screen's
    // ContentManager.  Here we'll just make one up:
    FlatRedBallServices.AddDisposable(
        texture2D.Name,
        texture2D,
        "MyContentManager");

    // Finally, let's use this Texture so we can actually see it
    Sprite sprite = SpriteManager.AddSprite(texture2D);

    // Set these numbers higher if using FSB or if you're in pixel
    // pixel coordinates:
    sprite.ScaleX = 10;
    sprite.ScaleY = 10;

![ImageDataToTexture2D.png](/media/migrated_media-ImageDataToTexture2D.png)

**Note:** This code uses the Color and Texture2D classes. Remember, if you are using a version of FlatRedBall other than FlatRedBall XNA, your using statements will be different. For more information, see:

-   [Microsoft.Xna.Framework.Graphics.Texture2D](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D "Microsoft.Xna.Framework.Graphics.Texture2D")
-   [Microsoft.Xna.Framework.Graphics.Color](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Color "Microsoft.Xna.Framework.Graphics.Color")

## Additional Information

-   [Fog of war using ImageData with source and in-browser FSB demo.](/frb/docs/index.php?title=FlatRedBall.Graphics.Texture.ImageData:Fog_of_War "FlatRedBall.Graphics.Texture.ImageData:Fog of War")

## ImageData Members

-   [FlatRedBall.Graphics.Texture.ImageData.ApplyColorOperation](/frb/docs/index.php?title=FlatRedBall.Graphics.Texture.ImageData.ApplyColorOperation "FlatRedBall.Graphics.Texture.ImageData.ApplyColorOperation")
-   [FlatRedBall.Graphics.Texture.ImageData.Fill](/frb/docs/index.php?title=FlatRedBall.Graphics.Texture.ImageData.Fill "FlatRedBall.Graphics.Texture.ImageData.Fill")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
