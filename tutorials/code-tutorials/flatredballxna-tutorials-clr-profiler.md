# flatredballxna-tutorials-clr-profiler

### Introduction

The CLR Profiler (CLR meaning Common Language Runtime) is a program created by Microsoft which gives detailed information about memory allocation and method calls. It is an invaluable tool for identifying areas of code which allocate too much memory. The CLR Profiler can give you information about where your project is allocating memory, which is the first step in cleaning up the allocation. Memory allocation can cause performance problems because the allocation increases the frequency in which the garbage collector runs. The best way to prevent the garbage collector from running (or to reduce its impact) is to reduce memory allocations. Fewer allocations means that ram needs to be "cleaned" less frequently, so the user will not experience as many pops in frame rate as the garbage collector freezes execution.

### CLR Profiler vs. Visual Studio Profiler

Visual Studio 2015 and later includes a built-in profiler which can help you diagnose performance and memory problems. To measure memory allocations in Visual Studio, the profiler can take snapshots of the heap which can be compared to see what allocation is happening in a call. While this is useful if you suspect that a particular call is allocating memory, snapshots are not as useful when measuring memory allocation across multiple frames in a game. Therefore, even though the CLR Profiler is no longer maintained at the time of this writing, it is still a very valuable tool for improving your game's performance, and it can provide more insight into allocations compared to the Visual Studio memory profiler.

### What problems can too much memory allocation cause?

The allocation of memory itself isn't necessarily the problem. The problem is the clean-up (called garbage collection) that is triggered due to allocations. The .NET framework provides extremely fast memory allocation due to the way it eliminates memory fragmentation. However, the clean-up of unused objects is another story. During the time of garbage collection (at least as of the .NET Framework 3.5) the program execution must stop. Garbage collection can take enough time that your game will experience a noticeable stop in execution. This "pop" can disrupt game play and appear annoying to the user. Since suppressing the garbage collector is not an option, the solution is to eliminate or reduce memory allocation. Less memory allocation means less frequent cleanup by the garbage collector. Memory can be reduced enough that the garbage collector can run very infrequently. This, coupled with intelligent forced garbage collections by Screens can essentially eliminate pops in frame rate.

### Installing the CLR Profiler

To install the CLR Profiler:

1. Download **CLRProfiler45Binaries** at: [https://github.com/MicrosoftArchive/clrprofiler/releases](https://github.com/MicrosoftArchive/clrprofiler/releases)
2. Unzip the **CLRProfiler45Binaries.zip** file
3. It is recommended that you leave the default unzip folder c:\CLRProfiler
4. Open the **64** or \*\*32 \*\*folders depending on whether your application is 64 or 32 bit. At the time of this writing all FRB apps default to 32 bit.
5. Double-click CLRProfiler.exe to run the CLR Profiler.

![](../../../media/2017-10-img_59d1a638ba1d7.png)

If you get a "Waiting for application to start common language runtime" message in Vista, try running the CLR Profiler as an administrator.

### Creating a Sample Program

One of the best ways to test out the CLR Profiler is to use it on an application that you have written. That makes the results a little easier to understand because you can compare the CLR Profiler's log to the code that you've written. To create a sample program, create a new project using a FlatRedBall template, then add the following code: Add the following at class scope:

```
SpriteList mSpriteList = new SpriteList();
```

Add the following to Update:

```
 // Create a Sprite every frame
 Sprite sprite = SpriteManager.AddSprite("redball.bmp");
 sprite.XVelocity = -10 + (float)FlatRedBallServices.Random.NextDouble() * 20;
 sprite.YVelocity = 3;
 sprite.YAcceleration = -4;
 mSpriteList.Add(sprite);

 // See if we need to remove any Sprites.  Use a reverse for-loop
 for(int i = mSpriteList.Count - 1; i > -1; i--)
 {
     const float yToRemoveAt = -15;
     if(mSpriteList[i].Y < yToRemoveAt)
     {
         SpriteManager.RemoveSprite(mSpriteList[i]);
     }
 }
```

![FallingBunchOfSprites.png](../../../media/migrated_media-FallingBunchOfSprites.png)

### Profiling the demo

The CLR Profiler can now be used to test the application that you've created. To test the application:

1. Open the CLR Profiler.
2. Make sure **Calls** is unchecked (we'll only look at memory allocations in this tutorial)
3. Make sure **Allocations** is checked. This must be checked before the program starts (it seems to be a bug)
4.  Optionally - uncheck **Profiling active**, so you can check it later exactly when you want profiling to start

    ![](../../../media/2020-09-img_5f5e8dc97a428.png)
5. Click **Start Desktop App...**
6. Navigate to the folder where your .exe was built.
7. Select your .exe and click the "Open" button. If **Profiling active** is checked profiling will begin immediately. Otherwise, navigate to where you want the profiling to start, then check **Profiling active**.
8. Let your application run for a few seconds or minutes. The longer it runs the more allocations you'll have. It's good to let the application run for a while because the initialization of the engine causes some allocations to happen, and running for too short of a time period will result in the initialization being the majority of your allocations.
9. Once you're finished, simply close your application, or click the "Kill application" button.
10. Once the application ends, the CLR Profiler will generate a log. A window will appear which provides access to the information in the log.

![ClrProfilingResults.png](../../../media/migrated_media-ClrProfilingResults.png)

### Reading the results - Allocations by object type

The information in the log is interesting, but the most useful information can be found in the Histograms. First, click on the first "Histogram" button - the one to the right of "Allocated bytes:". You'll see a window appear: ![AllocatedBytesHistogram.png](../../../media/migrated_media-AllocatedBytesHistogram.png) According to the graph above, the most-allocated object by size is the Sprite class. This is expected as the example code written above was intentionally written to be heavy on allocations. We have a pretty good sense of where this allocation is happening by looking at our code...but what about the second most-allocated object? According to the graph above, it's the string object. But where is this happening? Fortunately, we can see exactly where our allocations happen.

### Allocations by method

To see where objects are being allocated , close the "Histogram by Size for Allocated Objects" window, then click the "Allocation Graph" to the right of the "Histogram" to the right of "Allocated bytes:". ![AllocationGraph.png](../../../media/migrated_media-AllocationGraph.png) This will bring up a window that shows the allocation by method call. You can easily trace where your allocations are happening using this. On the very left side you should see a rectangle tyat says

```
<root> X.X MB (100.00%)
```

This indicates that 100% of your allocations are originating from \<root> which is basically the very bottom of the call stack. Since \<root> is around as long as your program is running, it makes sense why it is responsible for all of the allocations in your program. The next method to the right is Main, where virtually all of my allocations were from (99.80%). You may be wondering where the other .2% went - well, you can actually find out if you increase the detail. While it might be interesting to see how the insides of how a .NET application runs, it's not very useful for profiling. In general, we're interested in knocking out the biggest allocators first, and keeping the detail to the default value of 1 helps eliminate some of the noise so we can focus on the most important calls. Scrolling to the very right shows the most allocated objects by type. The most-allocated by memory are on the top. You'll notice that just like the previous graph, the Sprite class sits at the very top, then next is System.String, then Graphics.SpriteVertex, then Graphics.VertexPositionColorTexture, and so on. What's interesting is that we can actually start to trace where these calls are coming from. If you click a rectangle, then anything that allocated it and anything that it allocates will be easily traceable because the curved lines will become a diamond pattern. You should use this graph to see exactly what methods are allocating the most memory. If a method that you didn't write is allocating memory (such as a FlatRedBall or .NET call), then you should look at the method that calls that one and see if you can reduce the number of times that the allocating method is being called ![HighlightedCall.png](../../../media/migrated_media-HighlightedCall.png)

### Skipping Initialization

A large portion of initialization comes from the initialization of FlatRedBall. For example, FlatRedBall pre-allocates a pool of [Sprites](../../../frb/docs/index.php) which it uses for particles. Not only can this allocation introduce noise in the results if you are focused on your every-frame execution, but since you can't impact the FlatRedBall initialization there's really no benefit to including the initialization in your report. To skip initialization, uncheck the "Profiling active" check box, then begin running your application. Once your application has started running for a second, check the "Profiling active" check box so that the CLR Profiler begins measuring. If you do this you will avoid recording the initialization allocations. Also, you'll notice that the Allocation Graph gives a much clearer picture of where your allocations are occurring. ![AllocationWithNoInitialization.png](../../../media/migrated_media-AllocationWithNoInitialization.png) It's clear from this graph that almost all allocations (98.23%) occur from calling AddSprite. This gives you a strong direction on where allocations could be improved. In this case, there are a number of options for reducing the memory footprint. As an exercise, consider some of the following:

* Cache off the Texture2D for "redball.bmp" and use that as an argument instead of calling Load.
* Try calling AddParticleSprite instead of AddSprite.
* Try creating your own pool of Sprites which you add and remove from the [SpriteManager](../../../frb/docs/index.php).

You can find more performance-enhancing solutions in the [Performance Tutorials](../../../frb/docs/index.php#Performance_Tutorials) section.

### Troubleshooting the CLR Profiler

Sometimes the CLR Profiler is a little tricky to get running. If you're having problems with the CLR profiler, try the following:

* Copy the CLR Profiler binary files (exes and dlls) to the location where your game's EXE is located and then try running the CLR Profiler
*   Right-click on each .dll and each .pdb used by the CLR Profiler, select "Properties", then click the "Unblock" button

    ![](../../../media/2017-10-img_59d1a955bbb87.png)
* Run the CLR Profiler as administrator
* Turn Memory Allocations on, but turn profiling off, then turn profiling back on when the app is running.
