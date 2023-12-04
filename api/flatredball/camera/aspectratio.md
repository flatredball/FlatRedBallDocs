# AspectRatio

### Introduction

The AspectRatio of the camera is the ratio of width to height. Usually the AspectRatio will match the aspect ratio of the displayable area. For example, if the displayable area has a width of 800 pixels and a height of 600 pixels, then the aspect ratio should be 800/600, or 1.333. The AspectRatio of a Camera is used to set how wide the field of view should be. Since it is not an absolute value, but rather a ratio, changing a Camera's [FieldOfView](../../../frb/docs/index.php) property will change the resulting viewable width. Of course, the actual AspectRatio value will be the same.

Note that the AspectRatio property is typically not modified in custom code. The most common way to control aspect ratio is by assigning the desird value in the FlatRedBall Editor's [Display Settings](../../../glue-reference/camera.md).

### Code Example

The following code adds a [Sprite](../../../frb/docs/index.php) then modifies the AspectRatio of the default Camera. This makes the regularly-circle graphic appear stretched out. Add the following code to Initialize after initializing FlatRedBall:

```csharp
SpriteManager.AddSprite("redball.bmp");

// Notice the ScaleX and ScaleY are not changed
// but changing the AspectRatio makes the ball appear
// wider.
Camera.Main.AspectRatio = .3f; // smaller makes things look wider
```

![AspectRatio.png](../../../media/migrated\_media-AspectRatio.png)
