# attachto

### Introduction

The AttachTo method can be used to attach a child PositionedObject to a parent. Since the Parent property is read-only, the AttachTo method must be used to set up parent/child relationships. Most FlatRedBall objects (Text, Sprite, and all shapes) inherit from PositionedObject. Also, all Glue entities inherit from PositionedObject.

### Code Example

The following code assumes that GunInstance is a valid Glue component, and ShipInstance is also a valid Glue component:

```lang:c#
GunInstance.AttachTo(ShipInstance, false);
// set the GunInstance to be positioned relative to the ShipInstance:
GunInstance.RelativeX = 100;
GunInstance.RelativeY = -20;
```

&#x20;

### Method Signature

```
public void AttachTo(PositionedObject newParent, bool changeRelative)
```

#### changeRelative

The changeRelative property controls whether the relative values are changed on the caller (the child) when the method is called. Setting this value to true will result in the child being located in the same absolute position before and after the attachment. If false is passed, then the relative values on the child will be applied and the caller may move according to its relative values and its new parent's absolute values.
