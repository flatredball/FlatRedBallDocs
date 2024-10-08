# IWindow

### Introduction

The IWindow interface is an interface that enables objects to be added to the GuiManager. Once an object is added to the GuiManager it will automatically be tested for Cursor events. The IWindow interface can be used to simplify the implementation of buttons, check boxes, and any other types of UI elements which may need to interact with the cursor.

### IWindow and Glue

Although IWindow can be implemented manually in code, the IWindow interface is most typically implemented by Glue in generated code. For more information on IWindow in Glue, see [this page](../../../../../documentation/tools/glue-reference/entities/glue-reference-implements-iwindow.md).
