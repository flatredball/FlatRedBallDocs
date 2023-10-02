# 02-sections-tab

### Introduction

The **Sections** tab provides timing information about the last screen loaded in your game. This hierarchical display can help you identify where to work to reduce load times for maximum effectiveness. ![](../../../media/2017-07-img\_596ba382a0905.png)

### Enabling Loading Sections

Measuring load times can add a small amount of overhead to screen creation so it is not automatically enabled. To enable measuring loading sections:

1. Open your project in Glue
2. Select **Settings** -> **Performance Settings**
3.  In the **Performance Settings** window, set **RecordInitializeSegments** to **True**

    ![](../../../media/2017-07-img\_5970cfffdd9eb.png)

Now Glue will generate code in your game to record sections.

### Viewing Load Times

Once you have enabled the RecordInitializeSegments variable, screens will automatically record their load times. These times can be viewed in the profiler by clicking the Pull From Screen button. The profiler will automatically display the last-loaded screen, so you can navigate to any screen in your game then press the Pull From Screen button to view load times.

### Inspecting Load Time in Code

The FlatRedBall Profiler provides a tree view to quickly identify the slow parts of your screen's loading code. This information can also be obtained at runtime. To obtain this information (assuming **RecordInitializeSegments** is true):

1. Place a breakpoint in the CustomActivity method of the screen you wish to time
2. Start your game, and if necessary navigate to the desired screen
3. Once the breakpoint has been hit, add this.mSection  to the watch window.
4.  Each section has a list of children which can be expanded to break down the calls

    ![](../../../media/2017-07-img\_5970da931cfb4.png)

&#x20;
