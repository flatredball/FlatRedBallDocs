## Introduction

The Polygon class overrides the [base ForceUpdateDependencies implementation](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ForceUpdateDependencies.md "FlatRedBall.PositionedObject.ForceUpdateDependencies"). The Polygon's ForceUpdateDependencies method does the same thing as the [base ForceUpdateDependencies implementation](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ForceUpdateDependencies.md "FlatRedBall.PositionedObject.ForceUpdateDependencies") (updates the instance's absolute Position and Rotation values according to attachments); however, it \*also\* updates the Polygon's internal vertices.

## When should ForceUpdateDependencies be called?

In most situations you will not need to call ForceUpdateDependencies. Polygons will automatically update the internal vertices when performing any collision methods (such as CollideAgainst), or right before rendering a Polygon.

Since these two situations are common whenever a Polygon is used, you will usually not need to worry about calling ForceUpdateDependencies. However, if you are creating a Polygon and immediately wanting to use it with any method that may need to use its absolute vertices (such as [GetPointsInside](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon.GetPointsInside&action=edit&redlink=1.md "FlatRedBall.Math.Geometry.Polygon.GetPointsInside (page does not exist)"), then you will need to manually call ForceUpdateDependencies after instantiation.
