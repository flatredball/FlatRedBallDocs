# enable-live-edit

### Introduction

The Live Edit feature in FlatRedBall enables making a change to your game when in _edit mode_ and applying those changes without restarting your application. It enables a variety of types of editing, and this list is continually growing.

### Enabling Live Edit

To enable Live Edit in your game:

1.  Click the Editor Settings button. This brings up the Editor Settings tab

    ![](../../../../media/2023-08-img\_64dc3d61e692a.png)
2.  Check the option to Enable Live Edit

    ![](../../../../media/2023-08-img\_64dc3dd4da7b9.png)

Once this option is checked, FlatRedBall generates the necessary code to enable Live Edit in your game. This includes a connection between the FlatRedBall Editor and your game, using the port specified in the Port Number text box. Usually you do not need to change this port, but it can be changed if it conflicts with other applications. Once Live Edit is enabled, you can run your game and enable live edit in a number of ways.

*   Run in Edit Mode - You can directly launch your game by clicking the **Run in Edit Mode** button

    ![](../../../../media/2023-08-img\_64dc3f5ac404a.png)
*   Alternatively, you can launch your game in the FRB Editor...

    ![](../../../../media/2023-08-img\_64dc3f84aec51.png)

    ... and then switch to edit mode

    ![](../../../../media/2023-08-img\_64dc3fb4045da.png)
* Run your game in Visual Studio. FRB automatically detects when the game is running and displays the edit mode button. You can run your game in edit mode even if you didn't launch it through FRB [![](../../../../media/2023-08-15\_21-18-51.gif)](../../../../media/2023-08-15\_21-18-51.gif)

As shown above, you can tell that your game is in edit mode if it displays a grid. You can switch between Edit and Play mode anytime by toggling the play and edit buttons. [![](../../../../media/2023-08-15\_22-16-16.gif)](../../../../media/2023-08-15\_22-16-16.gif)

### Selecting and Previewing

If in edit mode, the selected level displays in the game. You can change selections and the game will switch what is displayed in realtime.

* Select a Screen (or Level) [![](../../../../media/2023-08-15\_22-20-12.gif)](../../../../media/2023-08-15\_22-20-12.gif)

&#x20;

* Select an entity to view it in game. The game creates a preview screen allowing you to view and edit the entity by itself. [![](../../../../media/2023-08-15\_22-24-55.gif)](../../../../media/2023-08-15\_22-24-55.gif)

&#x20;

* Select an object in a Screen or Entity to highlight it [![](../../../../media/2023-08-15\_22-26-37.gif)](../../../../media/2023-08-15\_22-26-37.gif)

&#x20;

* Select a state to preview it [![](../../../../media/2023-08-15\_22-29-12.gif)](../../../../media/2023-08-15\_22-29-12.gif)

&#x20;

* States can also be previewed by selecting a state in the StateData editor grid to preview it as well [![](../../../../media/2023-08-15\_22-29-45.gif)](../../../../media/2023-08-15\_22-29-45.gif)

&#x20;

* Select an object in a screen by clicking on it in game and it will select in the tree view [![](../../../../media/2023-08-15\_22-30-47.gif)](../../../../media/2023-08-15\_22-30-47.gif)

&#x20;

* Double-click to _punch through_ and select overlapping objects [![](../../../../media/2023-08-15\_22-31-21.gif)](../../../../media/2023-08-15\_22-31-21.gif)

### Camera Controls

The Camera in Edit mode can be controlled using the following methods:

* Hold the middle mouse button to pan [![](../../../../media/2021-08-2021\_August\_10\_112219.gif)](../../../../media/2021-08-2021\_August\_10\_112219.gif)

&#x20;

* Hold the CTRL key and press the arrow keys. Holding the arrow keys will continue to pan. [![](../../../../media/2021-08-2021\_August\_10\_111520.gif)](../../../../media/2021-08-2021\_August\_10\_111520.gif)

&#x20;

* Push+hold the left mouse button and move to the edge of the screen [![](../../../../media/2021-08-2021\_August\_10\_111021.gif)](../../../../media/2021-08-2021\_August\_10\_111021.gif)

&#x20;

* Scroll the mouse wheel to zoom in and out [![](../../../../media/2021-08-2021\_August\_10\_114921.gif)](../../../../media/2021-08-2021\_August\_10\_114921.gif)

&#x20;

* Hold the CTRL key and press + or - to zoom in and out [![](../../../../media/2021-08-2021\_August\_10\_114022.gif)](../../../../media/2021-08-2021\_August\_10\_114022.gif)

### Moving and Changing Object Variables

Changes in FlatRedBall immediately apply if the game is in edit mode. The following edits are supported in Live Edit:

* Change a value (such as X or Y) in the Variables tab to see the change in your game [![](../../../../media/2023-08-15\_22-32-46.gif)](../../../../media/2023-08-15\_22-32-46.gif)

&#x20;

* Push+drag to move objects in the game - the variables will update automatically in Glue to match the new position [![](../../../../media/2023-08-15\_22-33-12.gif)](../../../../media/2023-08-15\_22-33-12.gif)

&#x20;

* Drag objects to the edge of the screen to pan the camera if they need to be placed off screen [![](../../../../media/2023-08-15\_22-34-13.gif)](../../../../media/2023-08-15\_22-34-13.gif)

&#x20;

* Multiple objects can be selected and moved at once by holding down the CTRL key and clicking each object [![](../../../../media/2023-08-15\_22-34-48.gif)](../../../../media/2023-08-15\_22-34-48.gif)
* Pushing the left mouse button in a blank space and dragging results in a rectangle which can be used to select multiple objects [![](../../../../media/2023-08-15\_22-35-38.gif)](../../../../media/2023-08-15\_22-35-38.gif)

&#x20;

* Math operations can be used to change numerical values [![](../../../../media/2023-08-15\_22-36-18.gif)](../../../../media/2023-08-15\_22-36-18.gif)

&#x20;

* Along with primitive types (such as numerical values), states can also be set on instances [![](../../../../media/2023-08-15\_22-38-42.gif)](../../../../media/2023-08-15\_22-38-42.gif)

### Creating New Objects

Creating a new object in FlatRedBall automatically updates the game with the new object. New objects can be added to levels or entities.

* New level objects can be added through the Add Object Quick Action [![](../../../../media/2023-08-15\_22-39-53.gif)](../../../../media/2023-08-15\_22-39-53.gif)

&#x20;

* Glue also supports Drag+drop to add objects to a level [![](../../../../media/2023-08-15\_22-40-29.gif)](../../../../media/2023-08-15\_22-40-29.gif)

&#x20;

* New objects can also be added by selecting their list and using the Quick Action button [![](../../../../media/2023-08-15\_22-41-37.gif)](../../../../media/2023-08-15\_22-41-37.gif)

&#x20;

* New objects can be created by using the CTRL+C, CTR+V shortcut in game. This is especially useful when placing multiple objects in game. When pasting a grabbed object, the new object will be placed at the location of the crusor. [![](../../../../media/2023-08-15\_22-42-59.gif)](../../../../media/2023-08-15\_22-42-59.gif)

&#x20;

* Objects added to Entities will automatically appear on instances of that entity [![](../../../../media/2023-08-15\_22-43-47.gif)](../../../../media/2023-08-15\_22-43-47.gif)

### Working with Files

FlatRedBall supports adding files at runtime and automatically updating to changes.

* New files can be added from the file system to Screens or Entities. If these files are then referenced by an object (such as a Sprite), they will be displayed in game. [![](../../../../media/2021-08-2021\_August\_10\_164735.gif)](../../../../media/2021-08-2021\_August\_10\_164735.gif)

&#x20;

* External changes to files are automatically reloaded [![](../../../../media/2021-08-2021\_August\_10\_160041.gif)](../../../../media/2021-08-2021\_August\_10\_160041.gif)

&#x20;

* Changes to TMX files which can create entities and collision will automatically update these objects so they can be tested immediately. For example, painting collision tiles immediately allows testing the new level without restarting. [![](../../../../media/2021-08-2021\_August\_10\_162846.gif)](../../../../media/2021-08-2021\_August\_10\_162846.gif)
