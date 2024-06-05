# Improving Performance

### HELP! My game runs slow!

So you're working on a FlatRedBall game and you're having performance problems? Don't worry, it happens to almost everyone. Performance issues can happen at any point throughout the development process. Fortunately, many methods exist for diagnosing. If you're having any problems with performance, or if you'd like to take some preventative measures in making sure your game runs quickly, then this is a great place to start.

### Identifying the type of performance issues you're having

The first step in solving performance problems is to identify which type of performance problem you're having. Let's loo at the most common:

1. My game takes a long time to load
2. My game runs smoothly, but then seems to freeze or drop frames every once in a while
3. My game constantly runs slowly in a particular situation (such as in a particular level, or when lots of enemies are on screen)

Let's look at each one individually and explain what may be happening:

#### My game takes a long time to load

If your game takes a long time to load, it may be one of the following:

1. If your game takes a long time to load before anything shows on-screen, then it may be related to how much content is in your Global Content Files. \<under construction>
2. If your game loads fine initially, but it takes a long time to transition between screens then your screen may suffer from either long load times or a long CustomInitialize function. For more information, see [this page](flatredballxna-tutorials-identifying-screen-creation-performance-issues.md).

#### My game drops frames every once in a while

If your game seems to run slow, but the slowdown is no consistent then it is likely that you are experiencing slowdown from the garbage collector. Visual Studio offers a tool for measuring memory allocation. For more information, see the Visual Studio documentation for analyzing memory usage: https://learn.microsoft.com/en-us/visualstudio/profiling/dotnet-alloc-tool?view=vs-2022

#### My runs slowly

If your game is constantly running slowly, the reason may be one of the following:

1. Number of objects in the engine. This one is fairly easy to diagnose. We can find out if the problem is related to the number of objects in your engine simply by asking the engine to tell us how many objects it is managing. To identify if this is the problem, you should start with teh Profiling tab in the FlatRedBall Editor. For more information, see the [Profiling tab](../../../glue-reference/profiling.md) page.
2. Complicated logic in Custom code. This means that your CustomActivity code is causing problems. It could be in your Screen or it could be in your entities. For information on detecting and fixing complicated logic in custom code, see [this link](flatredballxna-tutorials-customactivity-performance.md)
3. Rendering issues. This means that you have too many graphical objects on screen. This is possible, however it is not as common of a problem as the first two, so you should look here only after you have eliminated the first two options. For information on detecting and fixing complicated logic in custom code, see [this link](flatredballxna-tutorials-rendering-performance.md)
