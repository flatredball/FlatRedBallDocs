# CustomActivity Performance

### Introduction

This section discusses CustomActivity and its potential impact on performance. Although CustomActivity can have an impact on performance, more often than not performance problems are a result of having too many managed objects in the engine. Therefore, you should always check this first before looking at your custom code for performance problems. For information on checking the number of objects, see [this link](../../../documentation/tutorials/code-tutorials/tutorials-a-walkthrough-on-improving-performance/flatredballxna-tutorials-manually-updated-objects.md).

### Profiling with Visual Studio

If your game runs slow because of your code, this could be code which is located in a variety of places in custom code. It may not actually be part of the CustomActivity of your screen because the slowdown could be in an entity, event handler, async method, or instruction. Therefore, finding your slowdown may not be a simple matter of adding timing code around your Screen's CustomActivity. Visual Studio offers a powerful profiler which can be used to measure where your game's slowdown occurs.

### Setting up Your Screen

Your game may be experiencing performance problems only in a particular screen or a particular situation. Therefore, you will want to have your game in the "slow" state before beginning profiling so that the profiler returns the most relevant information. Once you have this situation set up, place a breakpoint at the beginning of your Screen's CustomActivity method. ![](../../../.gitbook/assets/2023-08-img\_64d0f7d03a390.png) Once your game hits the breakpoint, open Debug -> Windows -> Show Diagnostic Tools

![](../../../.gitbook/assets/2023-08-img\_64d0f8d3cc7e7.png)

Enable CPU profiling. Remove the breakpoint. Run your game. After enough time has passed, re-add the breakpoint. Once you hit this breakpoint, Visual Studio should show you which code is responsible for time spent since you started profiling.
