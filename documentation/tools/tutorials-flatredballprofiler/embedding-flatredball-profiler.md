## Introduction

The FlatRedBall Profiler can be added as part of an existing FlatRedBall PC (desktop) game to provide in-depth, real time performance information. The FlatRedBall Profiler provides the following information:

-   The load time of the last screen (if enabled in Glue)
-   Current render breaks
-   Breakdown of all automatically managed objects.

## Adding profiler

The following steps can be used to add the FlatRedBall Profiler to an existing FlatRedBall PC (desktop) project:

### Adding FlatRedBall Profiler References

First we'll need to add the necessary references to the game project:

1.  Right-click on the "References" node in Visual Studio

2.  Select "Add Reference..." ![AddReferenceRightClick.png](/media/migrated_media-AddReferenceRightClick.png)

3.  Select the **Browse** category

4.  Click the **Browse** button

5.  Navigate to the location of the FlatRedBall Profiler (if you've built the profiler from source you will need to select the build folder for the FlatRedBallProfiler instead):

        C:\Program Files (x86)\FlatRedBall\FRBDK\Xna 4 Tools\FlatRedBallProfiler

6.  Select "FlatRedBall.PropertyGrid.dll" and "FlatRedBallProfiler.exe" (no need to add FlatRedBall.dll) and click "Add" ![AddReferencesFileWindow.PNG](/media/migrated_media-AddReferencesFileWindow.PNG)

7.  Expand the "Assemblies" category and select "Framework"

8.  Select "System.Windows.Forms" ![AddSystemWindowsFormsReference.PNG](/media/migrated_media-AddSystemWindowsFormsReference.PNG)

9.  Click OK to close the Reference Manager window

### Adding necessary code

Now that the project has the necessary references we'll add code to launch the FlatRedBall Profiler. Open Game1.cs and add the following code at the end of Initialize:

    // Profiler can only be launched from Windows desktop projects
    // DESKTOP_GL can indicate Windows Desktop as well as Mac and Linux
    // so this needs to be commented out, or a special compilation symbol is needed
    #if WINDOWS || DESKTOP_GL
                FlatRedBallProfiler.MainWindow window = new FlatRedBallProfiler.MainWindow();
                window.Show();
    #endif

Finally, open Program.cs  and add the STAThread attribute to the Main method:

    [STAThread]
    static void Main(string[] args)
    {
        using (Game1 game = new Game1())
        {
            game.Run();
        }
    }

If the STAThread is not added, then your game will throw an exception as shown in the following image: ![](http://i.imgur.com/0wssX9b.png)

The profiler will automatically show when the game runs:

![ProfilerRunning.PNG](/media/migrated_media-ProfilerRunning.PNG)
