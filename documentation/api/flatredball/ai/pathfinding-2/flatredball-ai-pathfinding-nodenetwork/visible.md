## Introduction

The Visible property controls whether the NodeNetwork has a visible representation. The visible representation for NodeNetworks can be useful in tools and during the development of a game.

## For Glue Users

There are a few considerations when working with NodeNetworks in Glue:

-   NodeNetworks are not visible by default. You will need to set their Visible property to true to show them.
-   When a NodeNetwork is set to Visible, it creates a variety of shapes and adds them to the [ShapeManager](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager.md "FlatRedBall.Math.Geometry.ShapeManager"). This means that if a NodeNetwork is visible when a Screen is destroyed, you will get an error that the Screen did not clean up after itself. To fix this, set the Visible property for the NodeNetwork to false in the Screen's CustomDestroy.

## Code Example

The following code shows how to make a NodeNetwork visible in code, and how to properly clean up the NodeNetwork when the containing Screen is destroyed.

``` lang:c#
private void CustomInitialize()
{
  // assuming the NodeNetwork is defined in Glue.
  // If not, you can create it in code too
  NodeNetworkInstance.Visible = true;
}

private void CustomDestroy()
{
  // Setting it to invisible automatically removes all shapes
  // from the ShapeManager.
  NodeNetworkInstance.Visible = false;
}
```

 
