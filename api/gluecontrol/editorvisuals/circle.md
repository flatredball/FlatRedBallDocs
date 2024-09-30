# Circle

### Introduction

The Circle method draws a circle of the argument radius at the argument position.

### Code Example: Drawing a Circle at the Cursor

```csharp
float radius = 10;
EditorVisuals.Circle(radius, GuiManager.Cursor.WorldPosition.ToVector3());
```

<figure><img src="../../../.gitbook/assets/image (10).png" alt=""><figcaption><p>Circle drawn at the cursor position</p></figcaption></figure>
