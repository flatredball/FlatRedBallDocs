## Introduction

The IWindow interface is an interface that enables objects to be added to the GuiManager. Once an object is added to the GuiManager it will automatically be tested for Cursor events. The IWindow interface can be used to simplify the implementation of buttons, check boxes, and any other types of UI elements which may need to interact with the cursor.

## IWindow and Glue

Although IWindow can be implemented manually in code, the IWindow interface is most typically implemented by Glue in generated code. For more information on IWindow in Glue, see [this page](/documentation/tools/glue-reference/entities/glue-reference-entities-implements-iwindow.md "Glue:Reference:Entities:Implements IWindow").

## IWindow Members

-   [FlatRedBall.Gui.IWindow.CallClick](/frb/docs/index.php?title=FlatRedBall.Gui.IWindow.CallClick "FlatRedBall.Gui.IWindow.CallClick")
-   [FlatRedBall.Gui.IWindow.Enabled](/frb/docs/index.php?title=FlatRedBall.Gui.IWindow.Enabled "FlatRedBall.Gui.IWindow.Enabled")

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
