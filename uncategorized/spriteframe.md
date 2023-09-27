## Tutorial

See [SpriteFrame Tutorial](/frb/docs/index.php?title=SpriteFrame_Tutorial.md "SpriteFrame Tutorial")

## Creating a SpriteFrame in code

The following code shows you how to create a SpriteFrame purely in code:

    Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp", contentManager);
    SpriteFrame spriteFrame = SpriteManager.AddSpriteFrame(texture, SpriteFrame.BorderSides.All);

## SpriteFrames and Layers

Just like [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") and [Text objects](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text"), SpriteFrames can be added to [Layers](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer.md "FlatRedBall.Graphics.Layer"). The following code creates two SpriteFrames. One is left at its default Z location of 0 while the other is placed further in the distance. Since the SpriteFrame which is further in the distance is placed on a [Layer](/frb/docs/index.php?title=FlatRedBall.Graphics.Layer.md "FlatRedBall.Graphics.Layer") it will still be drawn on top of the SpriteFrame that is closer to the [Camera](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera").

Add the following using statements:

    using FlatRedBall.ManagedSpriteGroups;

Add the following to Initialize after initializing FlatRedBall:

    string contentManager = "someContentManager";
     
    SpriteFrame spriteFrame = SpriteManager.AddSpriteFrame(
        FlatRedBallServices.Load<Texture2D>("redball.bmp", contentManager),
        SpriteFrame.BorderSides.All);

    // create the 2nd SpriteFrame and place it on a Layer
    Layer layer = SpriteManager.AddLayer();

    SpriteFrame layeredSpriteFrame = SpriteManager.AddSpriteFrame(
        spriteFrame.Texture, // might as well use the same Texture2D
        SpriteFrame.BorderSides.All);

    // To make it visibly distinguishable
    layeredSpriteFrame.ColorOperation = ColorOperation.Add;
    layeredSpriteFrame.Blue = 1;

    SpriteManager.AddToLayer(layeredSpriteFrame, layer);

    // To prove it worked, push the SpriteFrame back
    layeredSpriteFrame.Z = -25; // positive 25 in FRB MDX

![LayeredSpriteFrame.png](/media/migrated_media-LayeredSpriteFrame.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
