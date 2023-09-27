## Introduction

The BringsClickedWindowsToFront property controls whether the GuiManager brings any clicked Window to the front of its internal list. **The internal GuiManager list does not control rendering, just the order that clicks are tested**. Windows at the front of the list are prioritized regarding Cursor input. This is desired behavior if the GuiManager controls the rendering order of these windows (as is the case with the default FRB GUI found in the FRB tools) but it is not desirable behavior if the GuiManager does not control the rendering order (as is the case for [Glue](/frb/docs/index.php?title=Glue.md "Glue") Entities implementing [IWindow](/frb/docs/index.php?title=Glue.md:Tutorials:Using_IWindow "Glue:Tutorials:Using IWindow").

In summary:

1.  If using default FlatRedBall Gui for a tool or debugging, leave BringsClickedWindowsToFront to its default BringsClickedWindowsToFront value.
2.  If using [Glue](/frb/docs/index.php?title=Glue.md "Glue") IWindow Entities, you should set BringsClickedWindowsToFront to false and control ordering through the [BringToFront](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.BringToFront.md "FlatRedBall.Gui.GuiManager.BringToFront") method)

## Usage

    // If using Glue and IWindow:
    FlatRedBall.Gui.GuiManager.BringsClickedWindowsToFront = false;
