# Circle

### Introduction

The Circle represents a PositionedObject which can be used to draw circles or conduct efficient circular collision. Circles are created and removed through the [ShapeManager](../../../../../frb/docs/index.php).

### Simple Circle Example

The following example creates two circles and controls one of them with the [Keyboard](../../../../../frb/docs/index.php).

Add the following using statement

```csharp
using FlatRedBall.Math.Geometry;
using FlatRedBall.Input;
```

At Class Scope:

```csharp
Circle controlledCircle;
Circle idleCircle;
```

In Initialize:

```csharp
controlledCircle = ShapeManager.AddCircle();
controlledCircle.Radius = 8;
controlledCircle.X = 64;

idleCircle = ShapeManager.AddCircle();
idleCircle.Radius = 24;
```

In Update:

```csharp
InputManager.Keyboard.ControlPositionedObject(controlledCircle);
if (controlledCircle.CollideAgainst(idleCircle))
{
   controlledCircle.Color = Microsoft.Xna.Framework.Graphics.Color.Blue;
}
else
{
   controlledCircle.Color = Microsoft.Xna.Framework.Graphics.Color.Red;
}
```

![TwoCirclesOverlapping.png](../../../../../media/migrated\_media-TwoCirclesOverlapping.png)
