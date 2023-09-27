## Introduction

This section will walk you through identifying how many Sprites you have in your game, and how you can reduce this number to improve performance. If you haven't yet, you should first read the article about measuring all PositionedObjects. This article can be found [here](/frb/docs/index.php?title=FlatRedballXna:Tutorials:Manually_Updated_Objects:Measuring_Automatic_Updates.md "FlatRedballXna:Tutorials:Manually Updated Objects:Measuring Automatic Updates").

## If Sprites are the majority

If you've used WriteAutomaticallyUpdatedObjectInformation and have identified that Sprites are causing performance issues, then the next step is to figure out where your Sprites are coming from. Of course, if your game is simple, or if your Sprites do not come from diverse sources, then you may already know where your Sprites are coming from. For example, if you have a level with a very large Scene (.scnx file) then it's likely that many of your Sprites are coming from this file. However, let's assume that you're not sure where your Sprites are coming from.

## FlatRedBall Debugger to the rescue

Just like in [the general PositionedObject measuring tutorial](/frb/docs/index.php?title=FlatRedballXna:Tutorials:Manually_Updated_Objects:Measuring_Automatic_Updates.md "FlatRedballXna:Tutorials:Manually Updated Objects:Measuring Automatic Updates"), the FlatRedBall Debugger provides functions that can help us identify where our Sprites are coming from. To use this function:

1.  Open your project in Visual Studio

2.  Navigate to your Game class (which is by default called Game1 in Game1.cs)

3.  Navigate to the Update method

4.  Add the following code \*after\* FlatRedBallServices.Update:

        FlatRedBall.Debugging.Debugger.WriteAutomaticallyUpdatedSpriteBreakdown();

5.  Run your game

Here is an example of what output might look like: ![BaronSpriteOutput.PNG](/media/migrated_media-BaronSpriteOutput.PNG)

## Understanding the output

The image shown above was taken from Baron when it was late in its development. At this point a considerable amount of optimization had already been performed. The first line tells us the total number of Sprites which are automatically updated by the engine. In this case, the engine is managing 111 Sprites. Assuming you want to reduce this number, the next step is to identify where all of your Sprites are being used. What follows are lines indicating how many Sprites are being used by which entity, or marked as Unparented if the Sprites are not associated with any entities. For example, we can see that in this screen shot 51 of the Sprites are being used in the OverworldLevel entity. This represents almost half of our updated Sprites. If we were to try to reduce the number of Sprites here, then OverworldLevel would be a good place to start.
