# HorizontalAlignment

### Introduction

HorizontalAlignment determines how the text aligns itself according to the Text's X position. By default text is left justified, so the left side of the first letter will be placed at the Text's X value.

### Code Example

The Text object's X value marks the left side of the text object by default - that is, text is left justified by default. This justification or alignment can be changed. The following code creates three text objects with different HorizontalAlignment.

```
Text leftJustified = TextManager.AddText("Left justified");
leftJustified.Y = 30;

Text centerJustified = TextManager.AddText("Center Justified");
centerJustified.HorizontalAlignment = HorizontalAlignment.Center;

Text rightJustified = TextManager.AddText("Right Justified");
rightJustified.HorizontalAlignment = HorizontalAlignment.Right;
rightJustified.Y = -30;
```

![](../../../../.gitbook/assets/2019-06-img\_5d12e0b602322.png)

The dotted line above shows the X position of the Text objects.
