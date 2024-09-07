# Live Edit

### Introduction

The Live Edit feature in FlatRedBall enables making a change to your game when in _edit mode_ and applying those changes without restarting your application. It enables a variety of types of editing, and this list is continually growing.

### Enabling Live Edit

To enable Live Edit in your game:

1.  Click the Editor Settings button. This brings up the Editor Settings tab

    ![](../../media/2023-08-img\_64dc3d61e692a.png)
2.  Check the option to Enable Live Edit

    ![](../../media/2023-08-img\_64dc3dd4da7b9.png)

Once this option is checked, FlatRedBall generates the necessary code to enable Live Edit in your game. This includes a connection between the FlatRedBall Editor and your game, using the port specified in the Port Number text box. Usually you do not need to change this port, but it can be changed if it conflicts with other applications. Once Live Edit is enabled, you can run your game and enable live edit in a number of ways.

*   Run in Edit Mode - You can directly launch your game by clicking the **Run in Edit Mode** button

    ![](../../media/2023-08-img\_64dc3f5ac404a.png)
*   Alternatively, you can launch your game in the FRB Editor...

    ![](../../media/2023-08-img\_64dc3f84aec51.png)

    ... and then switch to edit mode

    ![](../../media/2023-08-img\_64dc3fb4045da.png)
* Run your game in Visual Studio. FRB automatically detects when the game is running and displays the edit mode button. You can run your game in edit mode even if you didn't launch it through FRB

<figure><img src="../../media/2023-08-15_21-18-51.gif" alt=""><figcaption></figcaption></figure>

As shown above, you can tell that your game is in edit mode if it displays a grid. You can switch between Edit and Play mode anytime by toggling the play and edit buttons.

<figure><img src="../../media/2023-08-15_22-16-16.gif" alt=""><figcaption></figcaption></figure>

### Selecting and Previewing

If in edit mode, the selected level displays in the game. You can change selections and the game will switch what is displayed in realtime.

* Select a Screen (or Level)

<figure><img src="../../media/2023-08-15_22-20-12.gif" alt=""><figcaption></figcaption></figure>

* Select an entity to view it in game. The game creates a preview screen allowing you to view and edit the entity by itself.

<figure><img src="../../media/2023-08-15_22-24-55.gif" alt=""><figcaption></figcaption></figure>

* Select an object in a Screen or Entity to highlight it

<figure><img src="../../media/2023-08-15_22-26-37.gif" alt=""><figcaption></figcaption></figure>

* Select a state to preview it

<figure><img src="../../media/2023-08-15_22-29-12.gif" alt=""><figcaption></figcaption></figure>

* States can also be previewed by selecting a state in the StateData editor grid to preview it as well

<figure><img src="../../media/2023-08-15_22-29-45.gif" alt=""><figcaption></figcaption></figure>

* Select an object in a screen by clicking on it in game and it will select in the tree view

<figure><img src="../../media/2023-08-15_22-30-47.gif" alt=""><figcaption></figcaption></figure>

* Double-click to _punch through_ and select overlapping objects

<figure><img src="../../media/2023-08-15_22-31-21.gif" alt=""><figcaption></figcaption></figure>

### Camera Controls

The Camera in Edit mode can be controlled using the following methods:

* Hold the middle mouse button to pan

<figure><img src="../../media/2021-08-2021_August_10_112219.gif" alt=""><figcaption></figcaption></figure>

* Hold the CTRL key and press the arrow keys. Holding the arrow keys will continue to pan.

<figure><img src="../../media/2021-08-2021_August_10_111520.gif" alt=""><figcaption></figcaption></figure>

* Push+hold the left mouse button and move to the edge of the screen

<figure><img src="../../media/2021-08-2021_August_10_111021.gif" alt=""><figcaption></figcaption></figure>

* Scroll the mouse wheel to zoom in and out

<figure><img src="../../media/2021-08-2021_August_10_114921.gif" alt=""><figcaption></figcaption></figure>

* Hold the CTRL key and press + or - to zoom in and out

<figure><img src="../../media/2021-08-2021_August_10_114022.gif" alt=""><figcaption></figcaption></figure>

### Moving and Changing Object Variables

Changes in FlatRedBall immediately apply if the game is in edit mode. The following edits are supported in Live Edit:

* Change a value (such as X or Y) in the Variables tab to see the change in your game

<figure><img src="../../media/2023-08-15_22-32-46.gif" alt=""><figcaption></figcaption></figure>

* Push+drag to move objects in the game - the variables will update automatically in Glue to match the new position

<figure><img src="../../media/2023-08-15_22-33-12.gif" alt=""><figcaption></figcaption></figure>

* Drag objects to the edge of the screen to pan the camera if they need to be placed off screen

<figure><img src="../../media/2023-08-15_22-34-13.gif" alt=""><figcaption></figcaption></figure>

* Multiple objects can be selected and moved at once by holding down the CTRL key and clicking each object

<figure><img src="../../media/2023-08-15_22-34-48.gif" alt=""><figcaption></figcaption></figure>

* Pushing the left mouse button in a blank space and dragging results in a rectangle which can be used to select multiple objects

<figure><img src="../../media/2023-08-15_22-35-38.gif" alt=""><figcaption></figcaption></figure>

* Math operations can be used to change numerical values

<figure><img src="../../media/2023-08-15_22-36-18.gif" alt=""><figcaption></figcaption></figure>

* Along with primitive types (such as numerical values), states can also be set on instances

<figure><img src="../../media/2023-08-15_22-38-42.gif" alt=""><figcaption></figcaption></figure>

### Creating New Objects

Creating a new object in FlatRedBall automatically updates the game with the new object. New objects can be added to levels or entities.

* New level objects can be added through the Add Object Quick Action

<figure><img src="../../media/2023-08-15_22-39-53.gif" alt=""><figcaption></figcaption></figure>

* Glue also supports Drag+drop to add objects to a level

<figure><img src="../../media/2023-08-15_22-40-29.gif" alt=""><figcaption></figcaption></figure>

* New objects can also be added by selecting their list and using the Quick Action button

<figure><img src="../../media/2023-08-15_22-41-37.gif" alt=""><figcaption></figcaption></figure>

* New objects can be created by using the CTRL+C, CTR+V shortcut in game. This is especially useful when placing multiple objects in game. When pasting a grabbed object, the new object will be placed at the location of the crusor.

<figure><img src="../../media/2023-08-15_22-42-59.gif" alt=""><figcaption></figcaption></figure>

* Objects added to Entities will automatically appear on instances of that entity

<figure><img src="../../media/2023-08-15_22-43-47.gif" alt=""><figcaption></figcaption></figure>

### Working with Files

FlatRedBall supports adding files at runtime and automatically updating to changes.

* New files can be added from the file system to Screens or Entities. If these files are then referenced by an object (such as a Sprite), they will be displayed in game.

<figure><img src="../../media/2021-08-2021_August_10_164735.gif" alt=""><figcaption></figcaption></figure>

* External changes to files are automatically reloaded

<figure><img src="../../media/2021-08-2021_August_10_160041.gif" alt=""><figcaption></figcaption></figure>

* Changes to TMX files which can create entities and collision will automatically update these objects so they can be tested immediately. For example, painting collision tiles immediately allows testing the new level without restarting.

<figure><img src="../../media/2021-08-2021_August_10_162846.gif" alt=""><figcaption></figcaption></figure>

### Editing Polygons

Polygons can be edited in real time when your game is running in live edit.

*   Change the number of points by clicking the rectangle button or the button to create an equilateral polygon of a given number of points.\


    <figure><img src="../../.gitbook/assets/07_06 37 42.gif" alt=""><figcaption><p>Set the number of points using the rectangle or set points button</p></figcaption></figure>
*   Push+drag on a point to change its position or type in a desired value by selecting the point. The selected point has an animated rectangle selector.\


    <figure><img src="../../.gitbook/assets/07_06 40 20.gif" alt=""><figcaption><p>Change point positions in the game window or by typing in new values in the Points tab</p></figcaption></figure>
*   Reorder points by using the up and down arrow buttons.\


    <figure><img src="../../.gitbook/assets/07_06 43 30.gif" alt=""><figcaption><p>Reorder polygon points with the up and down buttons</p></figcaption></figure>
*   Adjust the size of a polygon by using the scale button. X and Y scaling can be performed independently.\


    <figure><img src="../../.gitbook/assets/07_06 44 57.gif" alt=""><figcaption><p>Resizing polygon height and width</p></figcaption></figure>
*   Points can be deleted by clicking on a particular point then pressing the delete key.\


    <figure><img src="../../.gitbook/assets/07_07 47 48.gif" alt=""><figcaption><p>Delete points with the delete key</p></figcaption></figure>
*   Hold the plus (+) key then click to add points to a polygon\


    <figure><img src="../../.gitbook/assets/07_07 51 41.gif" alt=""><figcaption><p>Add points by holding down the plus key and clicking</p></figcaption></figure>

