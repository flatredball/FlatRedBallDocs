# Spline

### Introduction

A Spline is a curved path that you can use to create curved motion.

### Creating a Spline in code

The following example instantiates a Spline, adds four points, calculates the velocity and acceleration values, then finally makes the Spline visible. Visibility is usually used for tools and debugging. **Add the following using statement:**

```csharp
using FlatRedBall.Math.Splines;
```

**Add the following to your Screen's CustomInitialize:**

```csharp
 // Create a new spline
 Spline spline = new Spline();

 // Let's add 4 points.
 SplinePoint point = new SplinePoint();
 point.Position = new Vector3(0, 0, 0);
 spline.Add(point);

 // The first point's Time defaults to zero.  Set non-zero
 // times for all additional SplinesPoints.
 point = new SplinePoint();
 point.Position = new Vector3(30, 30, 0);
 point.Time = 2;
 spline.Add(point);

 point = new SplinePoint();
 point.Position = new Vector3(-40, 60, 0);
 point.Time = 4;
 spline.Add(point);

 point = new SplinePoint();
 point.Position = new Vector3(-80, -110, 0);
 point.Time = 6;
 spline.Add(point);

 // CalculateVelocities must be called before
 // CalculateAccelerations is called.
 spline.CalculateVelocities();
 spline.CalculateAccelerations();

 // Let's make it visible so we can see our creation.
 spline.Visible = true;
```

![SplineExample1.png](../../../../../.gitbook/assets/migrated_media-SplineExample1.png)

### Positioning objects using a Spline

Objects can be positioned using a Spline. The GetPositionAtTime method returns a Vector3. It takes a time argument which is the amount of time from the beginning of the Spline. The following code positions a Sprite according to how much time has passed since the user has pressed the space bar. This code example also skips over the steps to create a valid Spline and [Sprite](../../../sprite/). **Add the following at class scope:**

```csharp
double mTimeSplineMovementStarted = 0;
```

**Add the following in Update:**

```csharp
// This code assumes that mySprite is a valid Sprite and mySpline is a valid Spline
if(InputManager.Keyboard.KeyPushed(Keys.Space))
{
   mTimeSplineMovementStarted = TimeManager.CurrentTime;
}

mySprite.Position = mySpline.GetPositionAtTime(
   TimeManager.SecondsSince(mTimeSplineMovementStarted));
```

### Splines are ILists

Even though Splines provide a variety of methods and properties to treat the Spline as a single object, the Spline object also implements the IList\<SplinePoint> interface. That means that you can directly work with a Spline as a set of points. For example, to move the SplinePoint at index 2 to the right by 4 units, you would write:

```csharp
mySpline[4].X += 2;
```

Of course, if you ever make changes to a Spline like moving its points you will also want to recalculate velocities and accelerations:

```csharp
mySpline.CalculateVelocities();
mySpline.CalculateAccelerations();
```
