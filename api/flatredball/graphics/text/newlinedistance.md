# newlinedistance

### Introduction

The NewlineDistance property sets the amount of spacing between lines on a Text object. This value is set according to the Camera/Layer settings automatically when the Text is added to managers, but it can be modified after the fact to adjust spacing.

### Code Example (2D Camera/Layer)

The default setup for FlatRedBall is to be in 2D coordinates. If so, then NewlineDistance will be measured in pixels. The following code creates two Text objects and shows how to adjust their NewlineDistance:

```
// Assuming a 2D camera:
Text text = TextManager.AddText("Regular\nnewline");

Text otherText = TextManager.AddText("Modified\nnewline");
otherText.X = 150;
otherText.NewLineDistance = 30;
```

![NewlineDistance2D.PNG](../../../../../media/migrated_media-NewlineDistance2D.PNG)

### Code Example (3D Camera/Layer)

The following code creates two Text objects and shows how to adjust their NewlineDistance. Note that this example was made with a 3D camera.

```
Text text = TextManager.AddText("Regular\nnewline");
// In a 3D camera, we need to set this to false if we want accurate NewlineDistances
text.AdjustPositionForPixelPerfectDrawing = false;

Text otherText = TextManager.AddText("Modified\nnewline");
otherText.X = 10;
otherText.NewLineDistance = 3;
otherText.AdjustPositionForPixelPerfectDrawing = false;
```

![NewlineDistance.PNG](../../../../../media/migrated_media-NewlineDistance.PNG)

### NewlineDistance rounds to whole numbers if AdjustPositionForPixelPerfectDrawing is true

Text object are designed to work in 2D coordinates by default. Therefore, NewlineDistance will round to the nearest integer value. To change this, you can set the Texts' [AdjustPositionForPixelPerfectDrawing](../../../../../frb/docs/index.php) to false. The reason this happens is because if you are dealing with Text that has multiple lines and it is going to scroll vertically (like on a credits screen), then individual lines may appear to jitter when the text scrolls. If you are using 3D text, then you most likely do not want it to be adjusted for pixel perfect drawing anyway, so setting AdjustPositionForPixelPerfectDrawing to false will both resolve this issue and potential other issues with rendering te a Text object on a 3D Camera/Layer.
