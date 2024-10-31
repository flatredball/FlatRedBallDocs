# SetFromAbsoluteEndpoints

### Introduction

The SetFromAbsoluteEndpoints method can be used to set a line so that its endpoints are located at the argument locations. This method assigns:

* RelativePoint1
* RelativePoint2
* Position
* RotationZ

{% hint style="info" %}
SetFromAbsoluteEndpoints updates a Line's Position property. If the line is attached to another object (such as a line in an Entity) then this method will not properly set the line's values.
{% endhint %}

### Conceptual Example

Consider the following code:

```csharp
Vector3 firstPoint = new Vector3(0, 0, 0);
Vector3 secondPoint = new Vector3(100, 0, 0)
line.SetFromAbsoluteEndpoints(firstPoint, secondPoint);
```

The code above shows how to create a line using the SetFromAbsoluteEndpoints. To help explain what SetAbsoluteEndpoints does, we can consider how to create the same line without using SetFromAbsoluteEndpoints. To do the same as above, the following assignments would be necessary:

* RelativePoint1 = (-50, 0, 0)
* RelativePoint2 = (50, 0, 0)
* Position = (50, 0, 0)
* RotationZ = 0

### Code Example

The following code creates a line which connects the points X=0,Y=0 and X=100,Y=200:

```csharp
Line line = ShapeManager.AddLine();
Vector3 firstPoint = new Vector3(0, 0, 0);
Vector3 secondPoint = new Vector3(100, 200, 0)
line.SetFromAbsoluteEndpoints(firstPoint, secondPoint);
```
