## Introduction

ContentLoadBatch is designed to make loading multiple assets more simple. It does this by allowing you to group together all of the resources associated with a single event (ex. all of the [Textures](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") for a single level) to be loaded at once. ContentLoadBatch also provides a method for loading these assets in a separate thread on both the PC and Xbox360, making asynchronous loading less to worry about.

## Content Tutorial

[FlatRedBall Content Manager](/frb/docs/index.php?title=FlatRedBall_Content_Manager.md "FlatRedBall Content Manager")

## Using ContentLoadBatch

### Order of Operation

Loading and Unloading assets using ContentLoadBatch consists of four primary steps.

1.  Add the filename of each asset to the ContentLoadBatch object.
2.  Call the ContentLoadBatch's Load() method to load the content.
3.  Use the object's Get method to retrieve the loaded asset.
4.  Call ContentLoadBatch's Unload() method to unload the provided Content Manager when you are finished with the loaded assets.

The ContentLoadBatch is meant to operate in this order and will throw exceptions if you, for example, try to call Get() to retrieve an asset after calling contentLoadBatch.Unload().

### Code Example

Before running this example, be sure to follow the following steps to ensure the sample runs as intended.

-   Download this file ([FrblogoHighRes.png](/frb/docs/images/9/97/FrblogoHighRes.png.md "FrblogoHighRes.png")) and then drag it into the Content section of the Solution Explorer. It's a larger version of what already exists there, so go ahead and overwrite the file that's currently in the project.

&nbsp;

-   Select Frblogo.png in the Solution Explorer to view its properties. Change the Build Action to â€œNoneâ€?, and next to Copy to Output Directory select â€œCopy if Newer.â€?

The following is an example that demonstrates how to use ContentLoadBatch for both regular and asynchronous asset loading, and demonstrates the difference between the two. Press 1 to load the logo through regular loading, and press 2 to load the logo asynchronously. Pressing 3 will simply remove the logo from the screen.

    //Add this in the Game1 class scope
           ContentLoadBatch contentBatch;
           Sprite redBall;
           Sprite background;

           private void LoadFinished()
           {
               background.Texture = contentBatch.Get<Texture2D>(@"Content\Frblogo.png");
           }

    //Replace Initialize with this
           protected override void Initialize()
           {

               FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);
               base.Initialize();

               background = new Sprite();
               background.ScaleX = 10;
               background.ScaleY = 5;
               SpriteManager.AddSprite(background);

               redBall = SpriteManager.AddSprite(@"redball.bmp", "Global");
               redBall.X = -10;
               redBall.XVelocity = 20;

               redBall.Y = 0;
               redBall.YVelocity = 20;

               contentBatch = new ContentLoadBatch();
               contentBatch.Add<Texture2D>(@"Content\Frblogo.png");
           }

    //Replace Update with this
           protected override void Update(GameTime gameTime)
           {
               FlatRedBallServices.Update(gameTime);
               FlatRedBall.Screens.ScreenManager.Activity();

               if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D1))
               {
                   if (background.Texture != null)
                       background.Texture = null;

                   if (contentBatch.HasFinishedLoading)
                       contentBatch.Unload();

                   if (!contentBatch.IsLoading)
                   {
                       contentBatch.Load("BackgroundManager");
                       background.Texture = contentBatch.Get<Texture2D>(@"Content\Frblogo.png");
                   }

               }
               else if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D2))
               {

                   if (background.Texture != null)
                       background.Texture = null;

                   if (contentBatch.HasFinishedLoading)
                       contentBatch.Unload();

                   if (!contentBatch.IsLoading)
                       contentBatch.LoadAsync("BackgroundManager", LoadFinished);
               }
               else if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D3))
               {
                   background.Texture = null;

                   if (contentBatch.HasFinishedLoading)
                       contentBatch.Unload();
               }

               if (redBall.X >= 10) redBall.XVelocity = -20;
               else if (redBall.X <= -10) redBall.XVelocity = 20;

               if (redBall.Y >= 10) redBall.YVelocity = -20;
               else if (redBall.Y <= -10) redBall.YVelocity = 20;

               base.Update(gameTime);
           }

When you run this example, the result should be a blank screen with a single moving ball. Pressing 1 to load the FlatRedBall logo pauses the ball's motion while loading, and pressing 2 loads the image in a separate thread without interrupting the ball's motion.

![ContentLoadBatchScreenShot.png](/media/migrated_media-ContentLoadBatchScreenShot.png)

## ContentLoadBatch.Load() vs FlatRedBallServices.Load()

Before ContentLoadBatch, the most common way of loading assets would have been to use multiple calls to [FlatRedBall.FlatRedBallServices.Load](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.Load.md "FlatRedBall.FlatRedBallServices.Load")(). For example, if you wanted to simply load a [Texture](/frb/docs/index.php?title=Microsoft.Xna.Framework.Graphics.Texture2D.md "Microsoft.Xna.Framework.Graphics.Texture2D") and apply it in your code, you could do something like the following:

    Texture2D ballTexture = FlatRedBallServices.Load<Texture2D>(â€œredball.bmpâ€, â€œContentManagerNameâ€);
    Sprite ballSprite = new Sprite();
    ballSprite.Texture = ballTexture;

This method works great for loading just a few assets, or for when you absolutely have to load something on the fly. However, more often than not all of the assets for a scenario will be loaded at once before the user views it. The above code could have to be repeated dozens of times to load additional textures, sounds and other assets.

Alternatively, you can add the filenames of all assets to be loaded to a ContentLoadBatch and then load them all with one call to ContentLoadBatch.Load() or ContentLoadBatch.LoadAsync(). This allows for a more organized approach to managing content for different scenarios. All benefits of using [FlatRedBall.FlatRedBallServices.Load](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.Load.md "FlatRedBall.FlatRedBallServices.Load"), including content caching for previously loaded resources, are maintained as well.

## Related Reading

-   [FlatRedBall Content Manager](/frb/docs/index.php?title=FlatRedBall_Content_Manager.md "FlatRedBall Content Manager")
-   [FlatRedBall.FlatRedBallServices.Load](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.Load.md "FlatRedBall.FlatRedBallServices.Load")
-   [FlatRedBall XNA Content Pipeline](/frb/docs/index.php?title=FlatRedBall_XNA_Content_Pipeline.md "FlatRedBall XNA Content Pipeline")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
