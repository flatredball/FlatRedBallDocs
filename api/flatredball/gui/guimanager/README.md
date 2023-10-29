# guimanager

### Introduction

The GuiManager is a static object responsible for common UI element management as well as some UI creation. There are two categories of UI elements:

1. Default FlatRedBall GUI objects which are usually used for debugging and tools (these are used in all FRB graphical tools like the SpriteEditor, PolygonEditor, etc)
2. [Glue](../../../../../frb/docs/index.php) Entities inheriting from [IWindow](../../../../../frb/docs/index.php)

For a Default FlatRedBall UI element to be visible and functional it must either belong to the GuiManager or another UI element. [Glue](../../../../../frb/docs/index.php) Entities are drawn by the engine like normal Entities - the GuiManager simply handles the cursor-based activity (like clicks).

### Window Categories

When a [Window](../../../../../frb/docs/index.php) is created and added to the GuiManager, it can be added to one of three internal lists. These lists define the three categories. These categories are:

* Regular
* Dominant
* Perishable

The following sections define the characteristics of each category.

#### Regular

Adding a [Window](../../../../../frb/docs/index.php) by calling its constructor then passing it to the GuiManager's AddWindow method will add the [Window](../../../../../frb/docs/index.php) as a regular [Window](../../../../../frb/docs/index.php). Regular [Windows](../../../../../frb/docs/index.php) remain in memory until they are removed using the GuiManager's RemoveWindow method. Making a regular [Window](../../../../../frb/docs/index.php) invisible will not remove it from the GuiManager.

#### Dominant

Dominant [Windows](../../../../../frb/docs/index.php) are [Windows](../../../../../frb/docs/index.php) which consume [Cursor](../../../../../frb/docs/index.php) interaction while they are visible. In other words, if a dominant [Window](../../../../../frb/docs/index.php) is present, no other [Windows](../../../../../frb/docs/index.php) will receive input. Any [Window](../../../../../frb/docs/index.php) can be made dominant through the [AddDominantWindow](../../../../../frb/docs/index.php) method. Dominant [Windows](../../../../../frb/docs/index.php) are often used when the users attention is required on a particular [Window](../../../../../frb/docs/index.php). Examples include a [OkCancelWindow](../../../../../frb/docs/index.php) asking if the program should really exit after clicking the close button or a [FileWindow](../../../../../frb/docs/index.php) for selecting a file to load in an application. Dominant [Windows](../../../../../frb/docs/index.php) can be removed by either calling the GuiManager's RemoveWindow method or by setting the dominant [Window's](../../../../../frb/docs/index.php) Visible property to false. Setting the Visible property to false will result in the GuiManager automatically removing the [Window](../../../../../frb/docs/index.php) if [RemoveInvisibleDominantWindows](../../../../../frb/docs/index.php) is set to true.

#### Perishable

Perishable [Windows](../../../../../frb/docs/index.php) are [Windows](../../../../../frb/docs/index.php) which will automatically be removed by the GuiManager when the user clicks and the Cursor is not over the perishable [Window](../../../../../frb/docs/index.php). Perishable Windows are most commonly used for Windows which have a short life span. Examples include the drop-down ListBoxes that appear when clicking the [Button](../../../../../frb/docs/index.php) on [ComboBoxes](../../../../../frb/docs/index.php) or menus appearing when right-clicking on an object. If the user clicks on a perishable [Window](../../../../../frb/docs/index.php), the [Window](../../../../../frb/docs/index.php) will not automatically remove itself. The removal is usually handled in one of the [Window's](../../../../../frb/docs/index.php) events in this case.

### GuiManager Members

* [FlatRedBall.Gui.GuiManager.AddDominantWindow](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.BringsClickedWindowsToFront](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.BringToFront](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.MakeRegularWindow](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.RemoveWindow](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.ShowTextInputWindow](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.SortZAndLayerBased](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.TextHeight](../../../../../frb/docs/index.php)
* [FlatRedBall.Gui.GuiManager.Windows](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
