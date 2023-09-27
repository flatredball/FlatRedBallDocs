## Introduction

If you are dynamically creating IDisposable (such as Texture2Ds), you will need to dispose them at some time. Adding them to a ContentManager is the easiest way to do this. The AddDisposable method can be used to add Texture2Ds (and any other IDisposable) to FlatRedBall for convenient caching and automatic unloading.

The AddDisposable method takes an IDisposable to add to a [Content Manager](/frb/docs/index.php?title=FlatRedBall_Content_Manager.md "FlatRedBall Content Manager") along with the name to use for the IDisposable and the [Content Manager](/frb/docs/index.php?title=FlatRedBall_Content_Manager.md "FlatRedBall Content Manager") to place the IDisposable in.

## When should this be used?

This is only needed if a piece of content comes from somewhere other than the ContentManager or [FlatRedBall.FlatRedBallServices.Load](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.Load.md "FlatRedBall.FlatRedBallServices.Load"). For example, the Texture created here does not need to be added to through the AddDisposable method:

    Texture2D texture = FlatRedBallServices.Load<Texture2D>("fileName.png", "ContentManagerName);

It will already be added to a content manager by the name "ContentManagerName". However, if you use something like [ImageData](/frb/docs/index.php?title=FlatRedBall.Graphics.Texture.ImageData.md "FlatRedBall.Graphics.Texture.ImageData") or some other method to create your texture that doesn't come from file or content pipeline, you'll want to add the texture with AddDisposable.

## Code Example

The following code creates a Texture2D using the Texture2D's FromFile method, then places the Texture2D in the [Content Manager](/frb/docs/index.php?title=FlatRedBall_Content_Manager.md "FlatRedBall Content Manager") named "SomeContentManager":

Add the following using statements:

    using FlatRedBall;
    using Microsoft.Xna.Framework.Graphics;

Add the following using statements:

    string fileName = "redball.bmp";
    Texture2D texture2D = Texture2D.FromFile(FlatRedBallServices.GraphicsDevice, "redball.bmp");
    string contentManagerName = "SomeContentManager";
    FlatRedBallServices.AddDisposable(fileName, texture2D, contentManagerName);
