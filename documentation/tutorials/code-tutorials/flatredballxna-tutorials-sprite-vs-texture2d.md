## Introduction

Many FlatRedBall users often mistake "Sprites", "image files", and "Textures". This misconception can be supported by the close relationship between the three, especially since Sprites can be created as follows:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

At first glance, the code above may look like it is "creating a Sprite from a bitmap." This is technically not true, and in some cases the details of what is happening behind the scenes in the above call are very important. This wiki entry discusses the differences between image files, Textures, and Sprites in an effort to reduce the confusion.

## Image, Texture2D, and Sprite

So far we've been using the more general "Texture" term to describe the [Texture2D](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") class. In FlatRedBall XNA, the [Texture2D](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") class is a class that is part of the XNA framework. This article will use this class in discussion, but many of the same concepts apply to FlatRedBall MDX's Texture2D class and the Texture2D class provided by SilverSprite used in FlatSilverBall. The Sprite class can be thought of as a canvas to display a Texture2D. A Texture2D can be swapped without changing the size, location, or any other property of the Sprite that is displaying the Texture2D - at least unless the PixelSize is set to a non-zero value. However, for this article we'll assume that PixelSize is not used. Textures are different from image files as well, although this distinction isn't quite as important as Sprite vs. Texture2D. Image files are loaded to create Texture2Ds out of them. The image file is the image that sits on disk while the Texture2D is the information sitting in RAM which Sprites and other objects can reference. One way to think about a Sprite is to imagine it as a [digital photo frame](http://en.wikipedia.org/wiki/Digital_photo_frame). The image it displays (Texture2D) can be swapped without modifying its size, position, or other property.

## Dissecting AddSprite

The following code is both very common but actually performs a lot of functinality "under the hood":

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

To understand what the above code does, consider the following block of code which is functionally identical:

    // Identify the image file that will be used to create the Texture
    string textureFileName = "redball.bmp";
    // Identify the content manager that will be used to create the Texture
    string contentManagerName = FlatRedBallServices.GlobalContentManager;
    // Use these two to create the texture
    Texture2D texture2D = FlatRedBallServices.Load<Texture2D>(
        textureFileName,
        contentManagerName);
    // Create the Sprite
    Sprite sprite = new Sprite();

    // Assign the Texture2D
    sprite.Texture = texture2D;

    // Finally, add the Sprite to the SpriteManager for manageemnt
    SpriteManager.AddSprite(sprite);

The Texture property is simply set inside the AddSprite method when passing a file name to the method. Almost all Sprites have a non-null Texture2D set to their Texture property so the SpriteManager provides the AddSprite(string textureFileName) method for convenience.

## Texture Caching

When Textures are created through FlatRedBallServices, they are cached to offer faster access in the future. For example, the following code loads the redball.bmp image just once, then uses the cached version for additional calls:

    // This line of code will load the redball.bmp texture from file
    Sprite firstSprite = SpriteManager.AddSprite("redball.bmp");

    // Now the texture created from redball.bmp is already cached, so additional
    // calls simply use the cached reference instead of loading from the hard drive:
    Sprite otherSprite = SpriteManager.AddSprite("redball.bmp");

    // In fact, even calling FlatRedBallServices.Load returns a reference to the 
    // cached Texture2D:
    Texture2D texture2D = FlatRedBallServices.Load<Texture2D>("redball.bmp");
    Sprite lastSprite = SpriteManager.AddSprite(texture2D);

## 
