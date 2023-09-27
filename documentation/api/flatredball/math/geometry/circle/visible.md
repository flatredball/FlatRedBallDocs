## Introduction

The Visible property on a Circle controls whether the Circle is rendered or not. Invisible Circles will still perform collision properly, so this property does not need to be set if using Circles purely for collision. Rendered circles will render their outline using their [Color](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle.Color&action=edit&redlink=1.md "FlatRedBall.Math.Geometry.Circle.Color (page does not exist)") property. Circles cannot be filled-in, only their outline will render. Setting Visible to true may result in a Circle being added to the [ShapeManager](/documentation/api/flatredball/flatredball-math/flatredball-math-geometry/flatredball-math-geometry-shapemanager.md). For more information about how Visible results in [ShapeManager](/documentation/api/flatredball/flatredball-math/flatredball-math-geometry/flatredball-math-geometry-shapemanager.md) membership, see the [ShapeManager page](/documentation/api/flatredball/flatredball-math/flatredball-math-geometry/flatredball-math-geometry-shapemanager.md).