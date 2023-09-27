## Introduction

If you've been working with Glue then you are already instantiating Screens. Most situations require no knowledge of how Screens work "under the hood", however you may be interested in understanding how Screens work if you are tracking down performance problems or if you simply are curious about how the system works.

Fortunately the entire Screen system is included in your project as source code. This means that you can add some breakpoints and follow the flow of how everything works. Of course, the Screen system is pretty large so this article will help you understand how it all works.

## Transitioning from one Screen to another

Screens are created in one of two ways:

1.  When the project first starts up
2.  When one Screen transitions to another with MoveToScreen or by setting its IsActivityFinished property to true.

We'll focus on \#2 as most Screens are created this way, and if you understand this flow then the start-up flow is easy to understand.

For this example we'll assume you are working with two Screens:

1.  MainMenuScreen
2.  InGameScreen

And we'll assume that you have code in your game which moves from the MainMenuScreen to InGameScreen based off of some event (like a button click). Therefore, you may have code like this in your MainMenuScreen:

    if(SomeCondition)
    {
       MoveToScreen(typeof(InGameScreen).FullName);
    }

## The role of IsActivityFinished

First we'll point out that MoveToScreen is equivalent to setting IsActivityFinished to true, then setting the NextScreen to the argument of MoveToScreen - check it out if you want to see for yourself.

Once IsActivityFinished is set to true, the current Screen will finish out its frame...or at least most of it. There are some details to when Screen execution will not continue but we'll skip that as it's not relevant to Screen construction.

The IsActivityFinished property for the current Screen is checked every frame by the ScreenManager in its Activity function:

    if (mCurrentScreen.IsActivityFinished)
    {
       ...

**Hold it!**You want to understand how the Screen instantiation system works right? Then you better have a project open, and you better be following along in code! Since the Screen and ScreenManager source are available in your project this article will assume you're following in the code. If you aren't, you may get lost as we continue to explain concepts and reference pieces of code.

The current Screen won't actually be destroyed until the next frame after IsActivityFinished is set to true in the Screen's CustomActivity call. Once that occurs, the ScreenManager kicks off a series of functions to clean-up the state of the engine, then it begins to create the next Screen. We'll assume for this example that you are not using async loading, therefore one Screen follows the next with no overlap. In other words, we're focusing on the block of code in this if statement:

     if (asyncLoadedScreen == null)
     {
        ...

Notice that this calls LoadScreen, which is ultimately what kicks off the creation of the next Screen.

## LoadScreen

LoadScreen is reponsible for performing the following actions:

1.  Instantiating the next Screen according to its screen argument.
2.  Calling Initialize
3.  Calling Activity for the first time (at least in the default situation as described here)

The instantiation calls the constructor of the particular Screen (InGameScreen in this example) which calls the base (Screen) constructor. This simply sets up some variables, and you can see the contents of the Screen's constructor if you're interested. However, this is always the same for every Screen and the contents of the constructor do not change according to Glue settings, so we'll skip over that.

Initialize is a very powerful and somewhat complicated method. The Initialize method can operate in one of two ways:

1.  Content can be loaded and instances of FRB types (Sprites, PositionedObjects, Texts, etc) can be added to the engine. This is considered a "full initialization"
2.  Only Content can be loaded - no instances of FRB types will be added to the engine. This is considered a "content load initialization".

Notice that the content load initialization is a subset of the full initialization. In this situation where we are loading from one Screen to another without using async loading, then the initialization of InGameScreen will be a full initialization. If we were using async loading, then the content load initialization would occur while MainMenuScreen was still active, then once the content load initialization finished, the rest of the initialization would happen.

The following graphic shows which functions are involved in the initialize call:

![InitializationBreakdown.png](/media/migrated_media-InitializationBreakdown.png)

## Activity

Once the Screen is initialized fully, AddToManagers will get called one time. Activity will get called the very first frame to allow SpriteGrids to populate the screen and to prevent popping-in of Sprites on the second frame.
