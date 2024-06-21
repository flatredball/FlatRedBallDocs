# CollideAgainst

### Introduction

The CollideAgainst function returns whether one shape/ShapeCollection is touching another shape/ShapeCollection. CollideAgainst does not modify the positions or velocities of either of the callers, it simply returns true/false.

### Common Usage

CollideAgainst is often used in the following situations:

* Damage-dealing collision such as a player entity vs. a bullet entity.
* Game triggers, such as an area marking the end of a game.

### CollideAgainst and Z values

All shape collision for 2D shapes (that is, all shapes except AxisAlignedCube and Sphere) consider only X and Y values when testing for collision. This means that the Z value is ignored. Therefore two shapes which are at different Z values will trigger a collision. For example:

```csharp
Circle firstCircle = new Circle();
firstCircle.Radius = 16;

Circle secondCircle = new Circle();
secondCircle.Radius = 16;

// The two circles overlap at this point.
// Even if one of the circles has a different Z value...
firstCircle.Z = -1000;

// ... collision will still occur
if(firstCircle.CollideAgainst(secondCircle))
{
    // The if-statement will evaluate to true
}
```
