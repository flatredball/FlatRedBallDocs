# glue-reference-implements-iwindow

### Introduction

IWindow serves as an interface for creating button-like Entities in Glue. Using the IWindow enables you to do the following:

* Respond to clicks (release of mouse-button or touch screen)
* Respond to pushes (initial press of a mouse-button or touch screen)
* Respond to dragging
* Prevent click-throughs on overlapping IWindows

For initial information on how to use IWindows in Glue, check out the [IWindow in Glue tutorial page](../../../../../frb/docs/index.php). For more information on IWindow in raw code, check out the [IWindow code reference page](../../../../../frb/docs/index.php).

### Click Event

The most commonly-used event when using IWindows in Glue is the Click event. The Click event is an event that is raised whenever the user "clicks" on an IWindow. FlatRedBall considers a Click as occurring if:

* The user pushes on a button
* The user clicks (releases) while still on the button

When these two events occur, then a button's Click event is raised.

### IWindow.Enabled

Entities that implement IWindow automatically receive an Enabled property. The Enabled property controls whether the GuiManager's Cursor can interact with the Entity. Disabled Entities will not have their GUI events fired. This Enabled property uses [explicit implementation](http://msdn.microsoft.com/en-us/library/aa288461\(v=vs.71\).aspx) which means you can only access this property by casting an instance of your Entity to IWindow. In other words:

```
// Inside the Entity
((IWindow)this).Enabled = false;
// Outside of the Entity, assuming mEntityInstance is an instance:
((IWindow)mEntityInstance).Enabled = false;
```

### IWindow Members

* [Glue:Reference:Entities:IWindow:ClickNoSlide](../../../../../frb/docs/index.php)
* [Glue:Reference:Entities:IWindow:SlideOnClick](../../../../../frb/docs/index.php)
