## Introduction

The GuiManager is a static object responsible for common UI element management as well as some UI creation. There are two categories of UI elements:

1.  Default FlatRedBall GUI objects which are usually used for debugging and tools (these are used in all FRB graphical tools like the SpriteEditor, PolygonEditor, etc)
2.  [Glue](/frb/docs/index.php?title=Glue "Glue") Entities inheriting from [IWindow](/frb/docs/index.php?title=Glue:Tutorials:Using_IWindow "Glue:Tutorials:Using IWindow")

For a Default FlatRedBall UI element to be visible and functional it must either belong to the GuiManager or another UI element. [Glue](/frb/docs/index.php?title=Glue "Glue") Entities are drawn by the engine like normal Entities - the GuiManager simply handles the cursor-based activity (like clicks).

## Window Categories

When a [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") is created and added to the GuiManager, it can be added to one of three internal lists. These lists define the three categories. These categories are:

-   Regular
-   Dominant
-   Perishable

The following sections define the characteristics of each category.

### Regular

Adding a [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") by calling its constructor then passing it to the GuiManager's AddWindow method will add the [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") as a regular [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window"). Regular [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") remain in memory until they are removed using the GuiManager's RemoveWindow method. Making a regular [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") invisible will not remove it from the GuiManager.

### Dominant

Dominant [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") are [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") which consume [Cursor](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor "FlatRedBall.Gui.Cursor") interaction while they are visible. In other words, if a dominant [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") is present, no other [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") will receive input. Any [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") can be made dominant through the [AddDominantWindow](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.AddDominantWindow "FlatRedBall.Gui.GuiManager.AddDominantWindow") method. Dominant [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") are often used when the users attention is required on a particular [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window"). Examples include a [OkCancelWindow](/frb/docs/index.php?title=FlatRedBall.Gui.OkCancelWindow "FlatRedBall.Gui.OkCancelWindow") asking if the program should really exit after clicking the close button or a [FileWindow](/frb/docs/index.php?title=FlatRedBall.Gui.FileWindow "FlatRedBall.Gui.FileWindow") for selecting a file to load in an application. Dominant [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") can be removed by either calling the GuiManager's RemoveWindow method or by setting the dominant [Window's](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") Visible property to false. Setting the Visible property to false will result in the GuiManager automatically removing the [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") if [RemoveInvisibleDominantWindows](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.RemoveInvisibleDominantWindows&action=edit&redlink=1 "FlatRedBall.Gui.GuiManager.RemoveInvisibleDominantWindows (page does not exist)") is set to true.

### Perishable

Perishable [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") are [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") which will automatically be removed by the GuiManager when the user clicks and the Cursor is not over the perishable [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window"). Perishable Windows are most commonly used for Windows which have a short life span. Examples include the drop-down ListBoxes that appear when clicking the [Button](/frb/docs/index.php?title=FlatRedBall.Gui.Button "FlatRedBall.Gui.Button") on [ComboBoxes](/frb/docs/index.php?title=FlatRedBall.Gui.ComboBox "FlatRedBall.Gui.ComboBox") or menus appearing when right-clicking on an object. If the user clicks on a perishable [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window"), the [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") will not automatically remove itself. The removal is usually handled in one of the [Window's](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") events in this case.

## GuiManager Members

-   [FlatRedBall.Gui.GuiManager.AddDominantWindow](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.AddDominantWindow "FlatRedBall.Gui.GuiManager.AddDominantWindow")
-   [FlatRedBall.Gui.GuiManager.BringsClickedWindowsToFront](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.BringsClickedWindowsToFront "FlatRedBall.Gui.GuiManager.BringsClickedWindowsToFront")
-   [FlatRedBall.Gui.GuiManager.BringToFront](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.BringToFront "FlatRedBall.Gui.GuiManager.BringToFront")
-   [FlatRedBall.Gui.GuiManager.MakeRegularWindow](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.MakeRegularWindow "FlatRedBall.Gui.GuiManager.MakeRegularWindow")
-   [FlatRedBall.Gui.GuiManager.RemoveWindow](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.RemoveWindow "FlatRedBall.Gui.GuiManager.RemoveWindow")
-   [FlatRedBall.Gui.GuiManager.ShowTextInputWindow](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.ShowTextInputWindow "FlatRedBall.Gui.GuiManager.ShowTextInputWindow")
-   [FlatRedBall.Gui.GuiManager.SortZAndLayerBased](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.SortZAndLayerBased "FlatRedBall.Gui.GuiManager.SortZAndLayerBased")
-   [FlatRedBall.Gui.GuiManager.TextHeight](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.TextHeight "FlatRedBall.Gui.GuiManager.TextHeight")
-   [FlatRedBall.Gui.GuiManager.Windows](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.Windows "FlatRedBall.Gui.GuiManager.Windows")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
