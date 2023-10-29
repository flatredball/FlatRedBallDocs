# glue-reference-objects-layers-destinationrectangle

### Introduction

The DestinationRectangle can be used to make a Layer only draw to part of a Screen. This is often referred to as "masking" or "creating a mask". The DestinationRectangle property in Glue functions the same as in code. For a technical discussion on destination rectangles for Layers, see [this page](../../../../../frb/docs/index.php).

### Example Usage

The DestinationRectangle can control the area of the screen where a Layer is drawn. By default the DestinationRectangle is blank in Glue, meaning that the Layer will occupy the same area on screen as the main Camera. ![GlueDestinationRectangleDefault.png](../../../../../media/migrated\_media-GlueDestinationRectangleDefault.png) This destination rectangle can be changed in Glue. To do this:

1. Right-click on "DestinationRectnagle" in Glue.
2. An option for "Use Custom Rectangle" should appear![UseCustomRectangleOption.png](../../../../../media/migrated\_media-UseCustomRectangleOption.png)
3. Select this option and the Layer will be given a custom rectangle:![CustomDestinationRectangleLayer.png](../../../../../media/migrated\_media-CustomDestinationRectangleLayer.png)

Now that the DestinationRectangle value is there, we can modify it easily by changing one of the four values, or by expanding the DestinationRectangle and modifying each value independently: ![ExpandedDestinationRectangle.png](../../../../../media/migrated\_media-ExpandedDestinationRectangle.png) Consider a Sprite which takes up nearly the entire screen:![FullScreenNoLayer.PNG](../../../../../media/migrated\_media-FullScreenNoLayer.PNG) If this Sprite were put on the Layer, it would look like this:![FullScreenWithLayer.PNG](../../../../../media/migrated\_media-FullScreenWithLayer.PNG)
