## Introduction

If you have a screen which seems to take a long time to load then this can be the cause of either long load times in generated code or a slow CustomInitialize function. The first step in fixing the problem is to identify whether it is custom or generated code.

## Measuring time in CustomInitialize

CustomInitialize can be measured easily by using the [TimeManager's SystemCurrentTime](/frb/docs/index.php?title=FlatRedBall.TimeManager.SystemCurrentTime.md "FlatRedBall.TimeManager.SystemCurrentTime") property along with the [Debugger's CommandLineWrite](/frb/docs/index.php?title=FlatRedBall.Debugging.Debugger.CommandLineWrite.md "FlatRedBall.Debugging.Debugger.CommandLineWrite") function. For this example, let's assume a simple CustomInitialize which looks like this:

    void CustomInitialize()
    {
        for(int i = 0; i < 20000; i++)
        {
            AxisAlignedRectangle newRectangle = ShapeManager.AddAxisAlignedRectangle();
            newRectangle.X = i * 10;
        }
    }

The actual contents of CustomInitialize don't really matter - this is just some sample code that we can use to show how to measure CustomInitialize time. To measure and output the time, we'll need to do 3 things:

1.  Record the current time at the start of the function
2.  Record the current time at the end of the function
3.  Print out how long the initialize took by subtracting the beginning time from the end time

CustomInitialize can be modified to do this as follows:

    void CustomInitialize()
    {
        // 1:
        double timeBefore = TimeManager.SystemCurrentTime;

        for (int i = 0; i < 20000; i++)
        {
            AxisAlignedRectangle newRectangle = ShapeManager.AddAxisAlignedRectangle();
            newRectangle.X = i * 10;
        }

        // 2:
        double timeAfter = TimeManager.SystemCurrentTime;

        // 3:
        double timeTook = timeAfter - timeBefore;
        FlatRedBall.Debugging.Debugger.CommandLineWrite(
            "The number of seconds that CustomInitialize took is: " + timeTook);
    }

![MeasuringCustomInitialize.PNG](/media/migrated_media-MeasuringCustomInitialize.PNG)

## Measuring all Initialization including generated code

The example above tells us how long CustomInitialize takes, but it doesn't tell us how long generated code took to execute. This is important if your CustomInitialize code is fast (like less than 1 second) but the Screen still takes a long time to load. We can ask Glue to give us more detailed information to solve this. The steps to solve this are:

1.  Turning on detailed performance logging in Glue
2.  Modifying your code to output load times

### Turning on detailed performance logging in Glue

To do this:

1.  Switch to glue
2.  Select "Settings"-\>"Performance Settings"
3.  Set "RecordInitializeSegments" to "True"
4.  Click "Done"

Now Glue will generate code to measure Screen initialization time. Next we'll output this information on-screen.

### Modifying your code to output load times

To do this:

1.  Switch to Visual Studio
2.  Open your Screen that you want to measure the initialization times on
3.  Go to CustomActivity (not CustomInitialize)
4.  Add the following code in CustomActivity:

&nbsp;

    if(firstTimeCalled)
    {
        string toString = mSection.ToStringVerbose();
        FlatRedBall.Debugging.Debugger.CommandLineWrite(toString);
    }

Your game should now output information about initialization time: ![RecordSegmentsOutput.PNG](/media/migrated_media-RecordSegmentsOutput.PNG) Notice that this output method uses exponential notation for very small values. For example in the image above GameScreenPooled PostInitialize took "4E-07". This is the equivalent of 4 \* 10^(-7), or in other words 0.0000004. Typically if you see exponential notation you are dealing with time values which are so small that they will not have much if any of an impact on performance, so they can be treated as if they're 0. If the output from ToStringVerbose is too large to view on screen you can also output this to the Visual Studio output window as follows:

    if(firstTimeCalled)
    {
        string toString = mSection.ToStringVerbose();
        System.Console.Write(toString);
    }

![VerboseToOutputWindow.PNG](/media/migrated_media-VerboseToOutputWindow.PNG)

## Where is the slowdown?

So far we've discussed how to measure where slowdowns are occurring.

-   If the slowdown is in CustomLoadStaticContent or LoadStaticContent (notice the name of your screen will be prefixed), then you can solve the problem either by loading less content or by using a loading screen. For more information on using loading screens, see [this page](/frb/docs/index.php?title=Glue:Reference:Screens:IsLoadingScreen.md "Glue:Reference:Screens:IsLoadingScreen").
