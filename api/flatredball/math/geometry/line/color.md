# Color

### Introduction

The Color property controls the color value used when drawing a visible Line.&#x20;

### Code Exampe - Creating a red line

The following code creates a visible red line:

```csharp
var line = ShapeManager.AddLine();
line.Color = Color.Red;
line.Visible = true;
line.SetFromAbsoluteEndpoints(Camera.Main.Position.AtZ(0), 
    Camera.Main.Position.AtZ(0) + new Vector3(100, 100, 0));
```

<figure><img src="../../../../../.gitbook/assets/image (361).png" alt=""><figcaption><p>A red diagonal line</p></figcaption></figure>

### Code Example - Transparent Lines

The following shows a transparent white line. Note that colors are pre-multiplied so all color values must be multiplied by the alpha value.

The following code creates a half-transparent red line:

```csharp
var line = ShapeManager.AddLine();
var alpha = 0.5f;
line.Color = new Color(1 * alpha, 0 * alpha, 0 * alpha, alpha);
line.Visible = true;
line.SetFromAbsoluteEndpoints(Camera.Main.Position.AtZ(0), 
    Camera.Main.Position.AtZ(0) + new Vector3(100, 100, 0));
```

<figure><img src="../../../../../.gitbook/assets/image (363).png" alt=""><figcaption><p>Half transparent line over a light blue square</p></figcaption></figure>

The transparency can be difficult to see without zooming in. The following image shows the corner of the blue rectangle zoomed in.

<figure><img src="../../../../../.gitbook/assets/image (364).png" alt=""><figcaption><p>Transparent line overlapping a rectangle</p></figcaption></figure>
