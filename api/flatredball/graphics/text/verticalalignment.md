# VerticalAlignment

### Introduction

VerticalAlignment determines how the text aligns itself according to the Text's Y position. By default text uses VerticalAlignment.Center, so the center of Y value of the Text will represent its center vertically.

### Code Example

The Text object's Y value determines the position of the Text along with the Text's VerticalAlignment. Changing the VerticalAlignment will change the visible Y position of the text even though the Y value will be the same. The following code creates three Text objects with different VerticalAlignments.

```
Text topJustified = TextManager.AddText("Top justified");
topJustified.X = -5;
topJustified.VerticalAlignment = VerticalAlignment.Top;

Text centerJustified = TextManager.AddText("Center Justified");
centerJustified.VerticalAlignment = VerticalAlignment.Center;;

Text bottomJustified = TextManager.AddText("Bottom Justified");
bottomJustified.VerticalAlignment = VerticalAlignment.Bottom;
bottomJustified.X = 6;
```

![TextVerticalAlignment.png](../../../../.gitbook/assets/migrated\_media-TextVerticalAlignment.png)
