## Introduction

Multithreading applications can help improve performance - especially on modern multi-core PCs and the 360. Also, multithreading allows for animated loading sequences and can potentially eliminate loading altogether if used in a sophisticated streaming system.

## Multithreaded Loading

One of the most common areas to implement multithreading is in loading data such as textures or [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene "FlatRedBall.Scene"). To understand the process of loading a [Scene](/frb/docs/index.php?title=FlatRedBall.Scene "FlatRedBall.Scene"), you should probably first read the tutorial on [instancing, loading, and adding](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Instantiating,_Loading,_and_Adding "FlatRedBallXna:Tutorials:Instantiating, Loading, and Adding"). It is important to be able to distinguish between these actions when loading objects on a separate thread.

## What can be done on a second thread?

Loading Textures - or any other content from file - can be safely done on a second thread. This is because loading content such as Textures or creating a [SpriteEditorScene](/frb/docs/index.php?title=FlatRedBall.Content.SpriteEditorScene "FlatRedBall.Content.SpriteEditorScene") from file does not result in modifications of lists which the engine uses every frame.

However, adding things (such as [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite")) to managers is something that **must be done on the primary thread**. Therefore the approach, at a high level, is to load and instantiate objects on a secondary thread, then add those objects to the engine on the primary thread.

## Using an action list

The issue at hand is that objects may be instantiated on the second thread, but the must be added to the engine on the first thread.

There are a number of ways that this can be done, but most involve the same idea - create a list of actions that can be modified at any time by the second thread. The first thread then regularly checks this list and performs any necessary actions that are waiting.

In other words, this list will serve as a bridge between the two threads. The second thread adds things, and the first thread removes things. Of course, this list should be locked, but the process of adding and removing is very fast, so neither thread should stall for very long (if ever).

The list can be a very basic list, such as a List of [Sprites](/frb/docs/index.php?title=Sprite "Sprite") which should be added to the engine. A more general solution is to create a list of [Instructions](/frb/docs/index.php?title=FlatRedBall.Instructions.Instruction "FlatRedBall.Instructions.Instruction") which contain instructions that the first thread should execute. This approach gives the second thread the freedom to have the first thread do anything. In other words, it's a very general-purpose solution.

## Sample Code

The following code creates a spinning [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") in the top right corner of the screen. Pressing the space bar tells the program to load the FRB_logo.png file from disk to a Texture2D and create a Sprite using this Texture on the second thread. Then an instruction is created to add the Sprite to the engine on the first thread using the [InstructionQueue](/frb/docs/images/8/88/InstructionQueue.cs "InstructionQueue.cs").

Files used:![FRB logo.png](/media/migrated_media-FRB_logo.png), [InstructionQueue.cs (click to download)](/frb/docs/images/8/88/InstructionQueue.cs "InstructionQueue.cs")

Add the following using statements:

    using FlatRedBall.Instructions;
    using System.Threading;

Add the following at class scope:

    InstructionQueue mInstructionQueue;

Add the following in Initialize after initializing FlatRedBall:

    mInstructionQueue = new InstructionQueue();

    // This sprite will spin to show us that there are no skipped frames during loading
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.RotationZVelocity = 1;
    sprite.X = 20;
    sprite.Y = 15;

Add the following in Update:

    if (InputManager.Keyboard.KeyPushed(Keys.Space))
    {
        Thread thread = new Thread(new ThreadStart(LoadLogo));
        thread.Start();
    }

    // We can perform a lock here, but we actually don't have to with InstructionLists
    mInstructionQueue.ExecuteInstructions();

Add the following methods at class scope:

    private void LoadLogo()
    {
        Texture2D texture2D = FlatRedBallServices.Load<Texture2D>("FRB_logo.png");
        Sprite sprite = new Sprite();
        sprite.Texture = texture2D;
        sprite.PixelSize = .021f;

         // We can perform a lock here, but we actually don't have to with InstructionLists
        mInstructionQueue.AddInstruction(new MethodInstruction<Game1>(
            this, "AddLogoSprite", new object[] { sprite}, 0));
    }

    private void AddLogoSprite(Sprite spriteToAdd)
    {
        SpriteManager.AddSprite(spriteToAdd);
    }

![ThreadedLoading.png](/media/migrated_media-ThreadedLoading.png)

## Multithreaded Scene (.scnx) Loading

The task of loading a [Scene](/frb/docs/index.php?title=FlatRedBall.Scene "FlatRedBall.Scene") on a separate thread is similar to loading a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). Furthermore, most [FlatRedBall file type objects](/frb/docs/index.php?title=FlatRedBall_File_Types "FlatRedBall File Types") follow a very similar loading pattern. That means that once you're comfortable loading [Scenes](/frb/docs/index.php?title=FlatRedBall.Scene "FlatRedBall.Scene") then you should be able to load most other files fairly easily.

The general idea is the same - load from file and instantiate on a separate thread, add to engine on the first.

### Code Sample

The following loads a .scnx file and creates the [Scene](/frb/docs/index.php?title=FlatRedBall.Scene "FlatRedBall.Scene") on a separate thread, then adds it on the first thread.

Files used:[SplashScreen.zip](/frb/docs/images/2/2e/SplashScreen.zip "SplashScreen.zip"), [InstructionQueue.cs](/frb/docs/images/8/88/InstructionQueue.cs "InstructionQueue.cs")

Add the following using statements:

    using FlatRedBall.Instructions;
    using System.Threading;
    using FlatRedBall.Content;
    using System.Reflection;

Add the following at class scope:

    InstructionQueue mInstructionQueue;

Add the following in Initialize after initializing FlatRedBall:

    mInstructionQueue = new InstructionQueue();

    // This sprite will spin to show us that there are no skipped frames during loading
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.RotationZVelocity = 1;
    sprite.X = 20;
    sprite.Y = 15;

Add the following in Update:

    if (InputManager.Keyboard.KeyPushed(Keys.Space))
    {
        Thread thread = new Thread(new ThreadStart(LoadScene));
        thread.Start();
    }

    mInstructionQueue.ExecuteInstructions();

Add the following method at class scope:

    private void LoadScene()
    {
        bool usingContentPipeline = false; // false if from file
        string contentManagerName = "My content manager";
        Scene scene = null;

        if (usingContentPipeline)
        {
            scene = FlatRedBallServices.Load<Scene>(@"Content/splashScreen",
                contentManagerName);
        }
        else
        {
            SpriteEditorScene sceneSave = SpriteEditorScene.FromFile(@"splashScreen.scnx");
            scene = sceneSave.ToScene(contentManagerName);
        }

        // AddToManagers interacts with the engine, so we gotta do it through
        // our Instructions
        MethodInfo methodInfo = scene.GetType().GetMethod(
            "AddToManagers", new Type[0]);

        mInstructionQueue.AddInstruction(new MethodInstruction<Scene>(
            scene, methodInfo, new object[] { }, 0));
    }

![ThreadedLoadingScene.png](/media/migrated_media-ThreadedLoadingScene.png)

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
