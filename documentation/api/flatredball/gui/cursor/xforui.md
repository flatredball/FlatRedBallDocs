## Introduction

The XForUI and YForUI members provide a coordinate system that can be used to interact with the default FlatRedBall GUI. There are a few things to keep in mind with the UI:

-   The values reported by XForUI and YForUI are rarely needed. Most interaction with the default FRB UI can be done through events and properties.
-   The default FlatRedBall UI is not intended to be used in final games. It is not cross-platform, not skinnable, and lacks flexibility in areas that a full game may need. Instead, we recommend using [Glue](/frb/docs/index.php?title=Glue "Glue") and creating a custom UI.
-   The FlatRedBall UI was written in the very early days of FlatRedBall; therefore, the interface is not as clear as we would like to see it. Due to its rare use in shipped games and the amount of legacy code in the FRBDK, the interface has gone mostly unchanged for a long time.

## Usage example

The following code shows how to create a [Window](/frb/docs/index.php?title=FlatRedBall.Gui.Window "FlatRedBall.Gui.Window") and have it move with the Cursor: Add the following using statement:

    using FlatRedBall.Gui;

Add the following at class scope:

    Window window;

Add the following in Initialize after initializing FlatRedBall:

    window = GuiManager.AddWindow();

Add the following to Update:

     Cursor cursor = GuiManager.Cursor;
     window.X = cursor.XForUI + GuiManager.XEdge;
     window.Y = GuiManager.YEdge - cursor.YForUI;

The XForUI and YForUI properties return a coordinate system which is centered at the center of the screen with positive Y pointing up. The GUI coordinate system is centered at the top left with positive Y pointing down. The modifications using GuiManager.XEdge and YEdge are necessary to convert the Cursor's GUI coordinates to the FRB Gui's coordinate system. This confusing requirement is a result of very old FlatRedBall code which cannot be changed for legacy reasons.
