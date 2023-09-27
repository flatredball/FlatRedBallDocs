## Introduction

The SortZAndLayerBased function is a function which can be called to sort the GuiManager's [Windows](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.Windows.md "FlatRedBall.Gui.GuiManager.Windows") by their Z value and Layer membership. Layers take first priority, then IWindows which are on the same Layer will be sorted by their Z. The higher the Z value of an IWindow, or the further in-front a Layer is, the later in the list the IWindow will appear.

## Code Example

The following can be called to update the order:

``` lang:c#
GuiManager.SortZAndLayerBased();
```

 
