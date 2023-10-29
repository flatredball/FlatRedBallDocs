# visible

### Introduction

The Visible property controls whether a particular shape is drawn. Setting Visible to false will make a shape no longer be drawn. Setting Visible to true will make the shape drawn - even if it is not part of the ShapeManager.

### Under the hood

All visible shapes are stored in lists in the [ShapeManager](../../../../../../frb/docs/index.php) for drawing. If a visible shape is made invisible (its Visible is set to false) then it is removed from the shape that stores all to-be-drawn shapes of that particular type. This characteristic of the Visible property improves the speed of drawing shapes, but can have a small performance impact on the Visible property.
