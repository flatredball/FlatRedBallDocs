# lineheightinpixels

### Introduction

The LineHeightInPixels represents the height of a line of text in pixels. A line of text includes the tallest letters (such as capital letters) as well as letters which have pixels that fall below the base of the line (such as the lower-case letters 'p', 'q', and 'y').

### Relation to Text size

The LineHeightInPixels is the value used by FlatRedBall when determining the size of text in the [SetPixelPerfectScale](../../../../../frb/docs/index.php). A Text object which is drawn in 2D mode (where one unit equals one pixel) will have the following relationship to the LineHeightInPixels property of its BitmapFont:

```
Text.Scale = BitmapFont.LineHeightInPixels/2
Text.Spacing = BitmapFont.LineHeightInPixels/2 (Scale and Spacing are usually equal)
Text.NewLineDistance = BitmapFont.LineHeightInPixels * 1.5
```
