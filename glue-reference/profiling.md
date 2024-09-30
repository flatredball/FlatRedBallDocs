# Profiling

### Introduction

The Profiling tab provides high-level information about your game related to runtime performance. This can be used to determine what kind of optimizations may have an impact on your game's FPS.

<figure><img src="../.gitbook/assets/image (296).png" alt=""><figcaption><p>Profiling tab displaying information about a game</p></figcaption></figure>

The profiling tab provides the following information about a game:

* Managed PositionedObject breakdown
* Instruction count
* Render breaks (rendering state changes)
* Collision count

### Enabling the Profiling Tab

The Profiling tab obtains information from the game by communicating with it through generated code. This code is only available if **Enable live edit** is checked and if the game is running.

For more information about enabling live edit, see the [Live Edit](enable-live-edit/) page.

If your game does not have live edit enabled, if it is not running, or if the connection to the game has been lost, then the Summary and Collision tabs will display this information.

### Snapshots

The Profiling tab supports taking snapshots on command by clicking the Take Snapshot button or by checking the **Auto Take Snapshot** button which takes snapshots once per second.

If you are interested in a snapshot at a particular time, the Take Snapshot button takes a snapshot and leaves information about the snapshot in each tab so you can inspect it later. If you are interested in seeing trends or identifying particularly expensive parts of your game then the Auto Take Snapshot continually refreshes the values.

### Summary Tab

The Summary Tab displays information obtained from the [GetFullPerformanceInformation](../api/flatredball/debugging/debugger/getfullperformanceinformation.md) method, so this information can also be obtained at runtime.

The first section displays the number of positioned objects which are managed by the engine. If the number of managed positioned objects is large (over a few hundred), this can slow your game down unnecessarily. If your game includes a large number of managed entities, you can reduce this by using the [Entity Performance](entities/entity-performance.md) tab. For a discussion about manaul objects in FlatRedBall, see the [Manually Updated Objects](../tutorials/code-tutorials/tutorials-a-walkthrough-on-improving-performance/flatredballxna-tutorials-manually-updated-objects/) tutorials.

InstructionCount indicates the number of live instructions in your game. This is rarely a performance problem, so it is included only for the very rare situation where these could accumulate or reach very high numbers.

The Render Breaks section lists the number of times rendering batches stopped to swap some render state value. The most common reasons for render breaks are to swap to a different texture, but they may also be caused by changing color operations, blend operations, or by switching between different rendering systems which implement IDrawableBatch, such as moving between native FlatRedBall Sprite rendering, Tiled maps, and Gum. (todo - need a good tutorial discussing how to fix this problem)

The Summary tab provides a high-level overview of which collision relationships are the most expensive. Note that this does not give a deep dive into the collision relationships used in your game, so you may need to look at the Collision tab for more information.

Total Memory indicates how much ram is used by your game. Note that this does not include texture memory in video memory. This value may not be particularly useful when obtained through the FlatRedBall Editor because running in debug mode with live edit enabled results in a considerable amount of overhead. Memory allocation information is more accurately obtained through Visual Studio's profiler.



