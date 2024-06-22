# Visual

### Introduction

The Visual property is the underlying Gum object used to render the Framework Element. The Visual object is of type [GraphicalUiElement](../../../gum-runtime-api/gum-wireframe-graphicaluielement/).

### Visual vs Forms Object

The Forms object can be thought of as a _wrapper_ to the underlying Visual object. The Visual object provides some unique functionality that is not available directly to the Forms object. The following is a brief summary of what each offers: The Forms object:

* Provides a standardized interface for performing common operations such as setting a Button's Text, adding items to a ListBox, and highlighting text in a TextBox.
* Provides basic controls for positioning and sizing through X, Y, Width, and Height
* Provides standard access to state properties such as IsEnabled, IsMouseOver, and parent/children relationships

By contrast, the Visual object provides:

* Full control over positioning using all Gum properties such as X, Y, XUnits, YUnits, XOrigin, YOrigin, and ChildrenLayout
* Full control over sizing using all Gum properties such as Width, Height, WidthUnits, and HeightUnits
* Full access to all custom properties (such as custom states) if converted to its specific type
* Animation support
* State interpolation support
* Property assignment through strings

Most cases require interacting only with the main Forms object, but if additional flexibility is needed then the Visual object can be accessed and modified. Note that some properties (such as a Button's state) are controlled by the Forms object, so modifying these values may result in the Forms object overriding the changes in response to runtime logic (such as the mouse hovering over a Button).

### Forms and Visual Two-Way Relationship

Forms and their Visuals have a two-way relationship. If you have access to one, you can get access to the other. For example, consider the following code:

```
var button = Forms.ButtonInstance;
var buttonVisual = button.Visual;
var buttonFromVisual = (FlatRedBall.Forms.Controls.Button)buttonVisual.FormsControlAsObject;
// will be true:
var areEqual = button == buttonFromVisual;
```
