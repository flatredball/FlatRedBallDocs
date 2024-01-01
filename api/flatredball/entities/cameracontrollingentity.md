# CameraControllingEntity

### Introduction

The CameraControllingEntity is an object which provides convenient camera positioning and zooming functionality. It is included by default in the Top Down and Platformer projects when using the New Project Wizard.

### Moving Immediately to the Target

By default the CameraControllingEntity _interpolates_ from its current position to the target. This is normally desired as it can make the camera move smoothly. At times the Camera may need to be moved immediately to its target.&#x20;

The following code results in the CameraControllingEntity moving immediately.

```csharp
var target = CameraControllingEntityInstance.GetTarget();
// If true, the camera controlling entity will interpolate to its target
// position. If false, the camera controlling entity sets its position immediately.
var lerpSmooth = false;
CameraControllingEntityInstance.ApplyTarget(target, lerpSmooth);
```

Keep in mind that setting the Camera.Main's position to the target location will not immediately move the camera to the target position. If using a CameraControllingEntity, then the Camera's position becomes _read only_, so any changes to the camera position must be done through the CameraControllingEntity.

Additionally, when calling ApplyTarget, the value that is passed in should be obtained from the GetTarget method. The GetTarget method considers the bounds of the Map and the Camera size. Setting a value explicitly (such as by defining a Vector2 with constant X and Y values) may result in the CameraControllingEntity temporarily showing a region that is outside of the Map bounds.
