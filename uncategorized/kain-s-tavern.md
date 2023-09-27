## Welcome

Welcome to my tavern! I have been eagerly awaiting your arrival. Come, join me... we have much to discuss. If you don't get what you need here, you can always email me at [ddatti@gmail.com](mailto:ddatti@gmail.com)

## Spriter Integration Plugin

A lot of blood, sweat, and tears of unfathomable sadness have gone into my next contribution. There is a tool for 2D animations called [Spriter](http://brashmonkey.com/). About a year ago or more, I decided to start developing an integration plugin that would allow loading animations created by Spriter into Glue, and thus FlatRedBall games. The goal is to make the process as seamless and easy as possible, with little to no code required to have a Spriter animation play in game. While it is not perfect and is not nearly as complete as I want it to be, today is the day I released what I have in plugin form on GlueVault. Click here to download the plugin: [http://www.gluevault.com/plug/79-spriter-integration-plugin](http://www.gluevault.com/plug/79-spriter-integration-plugin)

### General overview

This plugin offers a much tighter integration with Glue than the TMXGlue tool offered in the past (before Victor turned it into a plugin). Essentially, all you have to do is install the plugin, and Glue understands enough about the files Spriter saves (SCML files) to be able to add existing animation files, copy all the sprite contents internal to the project, and generate a runtime object that you can add as an Entity to a screen like you would any other FlatRedBall type.

### Tutorials

To be continued...

## Tiled Map Editor, TMX, Glue and you.

To begin, for your enjoyment, I have an offering of substantial value for you. My creation and first contribution to the FRB community: [TMXGlue](http://www.gluevault.com/plug/44-tiled-map-editor-tmx-scnxnntxshcx-glue-integration-toolkit). This [open source](https://github.com/kainazzzo/TiledMap-FlatRedBall-Conversion) tool integrates the popular and stable [Tiled Map Editor](http://www.mapeditor.org/) into [Glue](/frb/docs/index.php?title=Glue "Glue")

[Download TMXGlue here](http://www.gluevault.com/plug/44-tiled-map-editor-tmx-scnxnntxshcx-glue-integration-toolkit)

### General overview

This is a tool that is designed to integrate directly into [Glue](/frb/docs/index.php?title=Glue "Glue") which will let you specify Tiled Map Editor files (.tmx) with the "Add Externally Built File" option in [Glue](/frb/docs/index.php?title=Glue "Glue"). Once you have the tool installed, you just add an external file, pick the .tmx file you saved from the map editor, and [Glue](/frb/docs/index.php?title=Glue "Glue") does the rest! Glue will automatically run the tmx file through the build tool, and generate a .scnx, .nntx, or .shcx file in your Glue project based on your dialog selection. All changes to the .tmx file will automatically trigger Glue to rebuild the destination (scnx/nntx/shcx) file.

### Installation instructions

Simply unzip the contents of the file found on GlueVault somewhere useful to you (it doesn't matter where), and in Glue do the following:

1.  Click the settings menu, and choose File Build Tools
2.  Click "Add new build tool"
3.  In the primary arguments:
    -   Build Tool: Path to the exe
    -   SourceFileType: tmx
    -   DestinationFileType: scnx
    -   In the list on the left, you should see: \*.tmx -\> TmxToScnx.exe -\> \*.scnx
4.  Click ok.

-   Repeat the process for nntx, shcx, and csv files, using TmxToNntx.exe and TmxToShcx.exe, and TmxToCsv.exe

The tool is now integrated into Glue. In order to use it, follow these steps:

1.  Using Glue, in any screen (or other object type), right click on "files"
2.  Select Add Externally Built File
3.  Select the .tmx file

## Scenes (TMX -\> SCNX)

-   [Kain's Tavern:TMX to SCNX](/frb/docs/index.php?title=Kain%27s_Tavern:TMX_to_SCNX "Kain's Tavern:TMX to SCNX")

## Tiled Binary (TMX -\> TILB)

-   [Kain's Tavern:TMX to TILB](/frb/docs/index.php?title=Kain%27s_Tavern:TMX_to_TILB "Kain's Tavern:TMX to TILB")

## Node Networks (TMX -\> NNTX)

-   [Kain's Tavern:TMX to NNTX](/frb/docs/index.php?title=Kain%27s_Tavern:TMX_to_NNTX "Kain's Tavern:TMX to NNTX")

## ShapeCollections (TMX -\> SHCX)

-   [Kain's Tavern:TMX to SHCX](/frb/docs/index.php?title=Kain%27s_Tavern:TMX_to_SHCX "Kain's Tavern:TMX to SHCX")

## Comma Separated Values (TMX -\> CSV)

-   [Kain's Tavern:TMX to CSV](/frb/docs/index.php?title=Kain%27s_Tavern:TMX_to_CSV "Kain's Tavern:TMX to CSV")
