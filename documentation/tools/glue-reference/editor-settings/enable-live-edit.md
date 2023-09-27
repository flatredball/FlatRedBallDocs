## Introduction

The Live Edit feature in FlatRedBall enables making a change to your game when in *edit mode* and applying those changes without restarting your application. It enables a variety of types of editing, and this list is continually growing.

## Enabling Live Edit

To enable Live Edit in your game:

1.  Click the Editor Settings button. This brings up the Editor Settings tab

    ![](/media/2023-08-img_64dc3d61e692a.png)

2.  Check the option to Enable Live Edit

    ![](/media/2023-08-img_64dc3dd4da7b9.png)

Once this option is checked, FlatRedBall generates the necessary code to enable Live Edit in your game. This includes a connection between the FlatRedBall Editor and your game, using the port specified in the Port Number text box. Usually you do not need to change this port, but it can be changed if it conflicts with other applications. Once Live Edit is enabled, you can run your game and enable live edit in a number of ways.

-   Run in Edit Mode - You can directly launch your game by clicking the **Run in Edit Mode** button

    ![](/media/2023-08-img_64dc3f5ac404a.png)

-   Alternatively, you can launch your game in the FRB Editor...

    ![](/media/2023-08-img_64dc3f84aec51.png)

    ... and then switch to edit mode

    ![](/media/2023-08-img_64dc3fb4045da.png)

-   Run your game in Visual Studio. FRB automatically detects when the game is running and displays the edit mode button. You can run your game in edit mode even if you didn't launch it through FRB [![](/wp-content/uploads/2023/08/15_21-18-51.gif.md)](/wp-content/uploads/2023/08/15_21-18-51.gif.md)

As shown above, you can tell that your game is in edit mode if it displays a grid. You can switch between Edit and Play mode anytime by toggling the play and edit buttons. [![](/wp-content/uploads/2023/08/15_22-16-16.gif.md)](/wp-content/uploads/2023/08/15_22-16-16.gif.md)

## Selecting and Previewing

If in edit mode, the selected level displays in the game. You can change selections and the game will switch what is displayed in realtime.

-   Select a Screen (or Level) [![](/wp-content/uploads/2023/08/15_22-20-12.gif.md)](/wp-content/uploads/2023/08/15_22-20-12.gif.md)

&nbsp;

-   Select an entity to view it in game. The game creates a preview screen allowing you to view and edit the entity by itself. [![](/wp-content/uploads/2023/08/15_22-24-55.gif.md)](/wp-content/uploads/2023/08/15_22-24-55.gif.md)

&nbsp;

-   Select an object in a Screen or Entity to highlight it [![](/wp-content/uploads/2023/08/15_22-26-37.gif.md)](/wp-content/uploads/2023/08/15_22-26-37.gif.md)

&nbsp;

-   Select a state to preview it [![](/wp-content/uploads/2023/08/15_22-29-12.gif.md)](/wp-content/uploads/2023/08/15_22-29-12.gif.md)

&nbsp;

-   States can also be previewed by selecting a state in the StateData editor grid to preview it as well [![](/wp-content/uploads/2023/08/15_22-29-45.gif.md)](/wp-content/uploads/2023/08/15_22-29-45.gif.md)

&nbsp;

-   Select an object in a screen by clicking on it in game and it will select in the tree view [![](/wp-content/uploads/2023/08/15_22-30-47.gif.md)](/wp-content/uploads/2023/08/15_22-30-47.gif.md)

&nbsp;

-   Double-click to *punch through* and select overlapping objects [![](/wp-content/uploads/2023/08/15_22-31-21.gif.md)](/wp-content/uploads/2023/08/15_22-31-21.gif.md)

## Camera Controls

The Camera in Edit mode can be controlled using the following methods:

-   Hold the middle mouse button to pan [![](/wp-content/uploads/2021/08/2021_August_10_112219.gif.md)](/wp-content/uploads/2021/08/2021_August_10_112219.gif.md)

&nbsp;

-   Hold the CTRL key and press the arrow keys. Holding the arrow keys will continue to pan. [![](/wp-content/uploads/2021/08/2021_August_10_111520.gif.md)](/wp-content/uploads/2021/08/2021_August_10_111520.gif.md)

&nbsp;

-   Push+hold the left mouse button and move to the edge of the screen [![](/wp-content/uploads/2021/08/2021_August_10_111021.gif.md)](/wp-content/uploads/2021/08/2021_August_10_111021.gif.md)

&nbsp;

-   Scroll the mouse wheel to zoom in and out [![](/wp-content/uploads/2021/08/2021_August_10_114921.gif.md)](/wp-content/uploads/2021/08/2021_August_10_114921.gif.md)

&nbsp;

-   Hold the CTRL key and press + or - to zoom in and out [![](/wp-content/uploads/2021/08/2021_August_10_114022.gif.md)](/wp-content/uploads/2021/08/2021_August_10_114022.gif.md)

## Moving and Changing Object Variables

Changes in FlatRedBall immediately apply if the game is in edit mode. The following edits are supported in Live Edit:

-   Change a value (such as X or Y) in the Variables tab to see the change in your game [![](/wp-content/uploads/2023/08/15_22-32-46.gif.md)](/wp-content/uploads/2023/08/15_22-32-46.gif.md)

&nbsp;

-   Push+drag to move objects in the game - the variables will update automatically in Glue to match the new position [![](/wp-content/uploads/2023/08/15_22-33-12.gif.md)](/wp-content/uploads/2023/08/15_22-33-12.gif.md)

&nbsp;

-   Drag objects to the edge of the screen to pan the camera if they need to be placed off screen [![](/wp-content/uploads/2023/08/15_22-34-13.gif.md)](/wp-content/uploads/2023/08/15_22-34-13.gif.md)

&nbsp;

-   Multiple objects can be selected and moved at once by holding down the CTRL key and clicking each object [![](/wp-content/uploads/2023/08/15_22-34-48.gif.md)](/wp-content/uploads/2023/08/15_22-34-48.gif.md)
-   Pushing the left mouse button in a blank space and dragging results in a rectangle which can be used to select multiple objects [![](/wp-content/uploads/2023/08/15_22-35-38.gif.md)](/wp-content/uploads/2023/08/15_22-35-38.gif.md)

&nbsp;

-   Math operations can be used to change numerical values [![](/wp-content/uploads/2023/08/15_22-36-18.gif.md)](/wp-content/uploads/2023/08/15_22-36-18.gif.md)

&nbsp;

-   Along with primitive types (such as numerical values), states can also be set on instances [![](/wp-content/uploads/2023/08/15_22-38-42.gif.md)](/wp-content/uploads/2023/08/15_22-38-42.gif.md)

## Creating New Objects

Creating a new object in FlatRedBall automatically updates the game with the new object. New objects can be added to levels or entities.

-   New level objects can be added through the Add Object Quick Action [![](/wp-content/uploads/2023/08/15_22-39-53.gif.md)](/wp-content/uploads/2023/08/15_22-39-53.gif.md)

&nbsp;

-   Glue also supports Drag+drop to add objects to a level [![](/wp-content/uploads/2023/08/15_22-40-29.gif.md)](/wp-content/uploads/2023/08/15_22-40-29.gif.md)

&nbsp;

-   New objects can also be added by selecting their list and using the Quick Action button [![](/wp-content/uploads/2023/08/15_22-41-37.gif.md)](/wp-content/uploads/2023/08/15_22-41-37.gif.md)

&nbsp;

-   New objects can be created by using the CTRL+C, CTR+V shortcut in game. This is especially useful when placing multiple objects in game. When pasting a grabbed object, the new object will be placed at the location of the crusor. [![](/wp-content/uploads/2023/08/15_22-42-59.gif.md)](/wp-content/uploads/2023/08/15_22-42-59.gif.md)

&nbsp;

-   Objects added to Entities will automatically appear on instances of that entity [![](/wp-content/uploads/2023/08/15_22-43-47.gif.md)](/wp-content/uploads/2023/08/15_22-43-47.gif.md)

## Working with Files

FlatRedBall supports adding files at runtime and automatically updating to changes.

-   New files can be added from the file system to Screens or Entities. If these files are then referenced by an object (such as a Sprite), they will be displayed in game. [![](/wp-content/uploads/2021/08/2021_August_10_164735.gif.md)](/wp-content/uploads/2021/08/2021_August_10_164735.gif.md)

&nbsp;

-   External changes to files are automatically reloaded [![](/wp-content/uploads/2021/08/2021_August_10_160041.gif.md)](/wp-content/uploads/2021/08/2021_August_10_160041.gif.md)

&nbsp;

-   Changes to TMX files which can create entities and collision will automatically update these objects so they can be tested immediately. For example, painting collision tiles immediately allows testing the new level without restarting. [![](/wp-content/uploads/2021/08/2021_August_10_162846.gif.md)](/wp-content/uploads/2021/08/2021_August_10_162846.gif.md)
