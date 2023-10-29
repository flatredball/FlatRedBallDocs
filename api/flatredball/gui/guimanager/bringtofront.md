# bringtofront

### Introduction

The GuiManager keeps track of the order of IWindows that it is storing. For default-drawn Windows, this ordering is reflected in the draw order. However, for [Glue](../../../../../frb/docs/index.php) Entities, the ordering of the Entities in the GuiManager may not match the ordering that the Entities are drawn. The order of IWindow Entities only matters if Entities overlap. In this case, you will need to manually control the order of Entities by using BringToFront. The GuiManager will also automatically bring clicked windows to the front. This is desirable when using default-drawn Windows, but usually not desirable when working with Entities. Therefore, if you are using IWindow Entities in [Glue](../../../../../frb/docs/index.php) you will want to set the [GuiManager's BringsClickedWindowsToFront](../../../../../frb/docs/index.php) property to false in your game's initialization.

### [Glue](../../../../../frb/docs/index.php) Entity example

If you have IWindow Entities which are overlapping, you will want to control the order of your Entities using the BringToFront method. For example, consider an Entity called ButtonFrame which contains three Buttons. To bring the three Buttons to the front so that they are clickable, you might want to add the following code:

```
private void CustomInitialize()
{
   BringButtonsToFront();
}
private void BringButtonsToFront()
{
   GuiManager.BringToFront(ButtonInstance1);
   GuiManager.BringToFront(ButtonInstance2);
   GuiManager.BringToFront(ButtonInstance3);
}
```
