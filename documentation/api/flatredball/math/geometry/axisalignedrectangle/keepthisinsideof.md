## Introduction

The KeepThisInsideOf method repositions the calling AxisAlignedRectangle (or its TopParent if it is attached to another PositionedObject) so that it is not outside of the argument AxisAlignedRectangle. This method will do a one-time re-position of the calling instance, so it must be called every frame if the moving AxisAlignedRectangle.

This method can only be used to keep AxisAlignedRectangles inside of other AxisAlignedRectangles - other shapes are not supported.
