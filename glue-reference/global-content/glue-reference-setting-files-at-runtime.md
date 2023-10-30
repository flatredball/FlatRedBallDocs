# glue-reference-setting-files-at-runtime

### Introduction

All files in GlobalContent have a getter and a setter. This means that you are able to set files at runtime if you would like to update them in custom code. This section will discuss the details of setting files, and why you may want to do this in your projects.

### Example Scenario

Setting files in GlobalContent at runtime is usually done in situations where you would like the files in global content to be set according to some condition in your game such as being in a demo vs. fullly purchased mode, or if you are going to be downloading updated versions of files from a remote server. The example we will use here is a situation where your game has a demo and full version. Specifically, the demo version only provides access to a few levels, while the full version provides access to all levels in your game.

### Setting up a project

To create a new project, do the following:

1. Open Glue
2. Create a new XNA 4 PC project
3. Name the project CsvReloadTest

To create our CSV files:

1. Right-click on Global Content Files and select "Add File"->"New File"
2. Select "Spreadsheet (.csv)" as the file type
3. Name the file LevelInfo.csv
4. Repeat the above steps to create a new CSV file called DemoLevelInfo.csv

Next we'll want to make sure that both CSVs have the same columns - since one will replace the other they both need the same columns to be compatible. Mine look like this:

DemoLevelInfo.csv:

|                         |                   |
| ----------------------- | ----------------- |
| Name (string, required) | TimeLimit (float) |
| Level1                  | 100               |

LevelInfo.csv:

|                         |                   |
| ----------------------- | ----------------- |
| Name (string, required) | TimeLimit (float) |
| Level1                  | 100               |
| Level2                  | 125               |
| Level3                  | 125               |
| Level4                  | 160               |
| Level5                  | 200               |

We have two files - LevelInfo.csv (which contains all of our levels) and DemoLevelInfo.csv which will contain demo levels. If the game is in demo mode, we will replace LevelInfo with the contents of DemoLevelInfo at runtime.

### Setting Created Class

We want DemoLevelInfo.csv to use the same class as LevelInfo.csv. To do this:

1. Right-click on DemoLevelInfo.csv
2. Select "Set Created Class"
3. Click "New Class"
4. Enter the name "LevelInfo"
5. Select the newly-created LevelInfo class
6. Click Use This Class
7. Click "Yes" if asked if you should remove unused file
8. Click Done

For more info on Set Created Class, see [this page](../../../../frb/docs/index.php).

### Using LevelInfo in a Screen

First, let's create a Screen that uses LevelInfo to display which levels are currently available in the game:

1. In Glue, right-click on Screens
2. Select "Add Screen"
3. Name your Screen "LevelSelectScreen"

Now let's make a Text object in our Screen. This Text object will display available levels, as determined by looking at LevelInfo in GlobalContent:

1. Right-click on the LevelSelectScreen's "Objects"
2. Select "Add Object"
3. Verify "FlatRedBall or Custom Type" is selected
4. Select "Text"
5. Click OK

Now that we have a Text object, let's set its Text in CustomInitialize of our Screen:

1. Open your project in Visual Studio
2. Navigate to LevelSelectScreen.cs
3. Add the following code to CustomInitialize:

&#x20;

```
    string whatToWrite = "";

    foreach (var level in GlobalContent.LevelInfo.Values)
    {
        whatToWrite += level.Name + " (" + level.TimeLimit + ")\n";
    }

    this.TextInstance.DisplayText = whatToWrite;
```

If you run your game now you will see that the game has 5 levels (according to LevelInfo): ![FiveLevelsPrintedOut.PNG](../../../../media/migrated_media-FiveLevelsPrintedOut.PNG)

### Changing LevelInfo

All files in GlobalContent have setters. This means that you can simply set the properties and the rest of your project should use the new instance - assuming you do so before your project accesses these files. We'll add some code to Game1.cs to set our game into demo mode. To do this:

1. Open Game1.cs in your project in Visual Studio
2. Add the following code **after** GlobalContent.Initialize and **before** ScreenManager.Start in Game1.cs:

&#x20;

```
GlobalContent.LevelInfo = GlobalContent.DemoLevelInfo;
```

Now if you run your game you'll see that only the first level is available: ![DemoLevelOnly.PNG](../../../../media/migrated_media-DemoLevelOnly.PNG)

### Making the example more realistic

In this case our code is simply setting the LevelInfo to DemoLevelInfo - overwriting our LevelInfo without making any checks. If this were a real game, we might want to check if the game should really be in demo mode or not. Therefore, you would wrap this assignment in some checks. Also, we had to put our replacement in a very specific place in the Initialize function in Game 1:

* It had to be **after** GlobalContent.Initialize because we needed DemolevelInfo to already be loaded
* It had to be **before** the ScreenManager's Start function because this had to be set prior to the first Screen being initialized.

Although we assigned one CSV in GlobalContent to another CSV in GlobalContent, this is not a requirement. The LevelInfo could be assigned from a completely different file using the [CsvFileManager](../../../../frb/docs/index.php). This means that you could download a CSV from a server somewhere, and assign LevelInfo to a new Dictionary\<string, LevelInfo>, then deserialize the file into that dictionary using [CsvDeserializeDictionary](../../../../frb/docs/index.php). If you are doing any form of assignment on an object in GlobalContent, and you are assigning to something that is not part of GlobalContent, then you can assign the property in GlobalContent **before** GlobalContent is initialized. GlobalContent will respect this assignment and will not overwrite it when initializing.
