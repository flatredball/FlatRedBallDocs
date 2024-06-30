# Visible

### Introduction

The Visible property controls whether the NodeNetwork has a visible representation. The visible representation for NodeNetworks can be useful in tools and during the development of a game.

### Code Example

The following code shows how to make a NodeNetwork visible in code, and how to properly clean up the NodeNetwork when the containing Screen is destroyed.

```csharp
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

Keep in mind that you do not need to set the Visible to false if you are setting a NodeNetwork's visiblity to true in the FlatRedBall Editor - generated code handls that automatically.
