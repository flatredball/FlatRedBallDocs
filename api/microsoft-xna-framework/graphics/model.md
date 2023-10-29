# model

### Introduction

Xna's Model class is the class that's used to draw 3D geometry. Usually in FlatRedBall this object is contained within a [PositionedModel](../../../../frb/docs/index.php) and is accessed by the [PositionedModel's](../../../../frb/docs/index.php) XnaModel property.

### Setting Effects

To set individual effects on a model, set the effects within the model's meshparts, like so:

```
// Load the effect to use
Effect newEffect = FlatRedBallServices.Load<Effect>(@"Content\myEffect");

// Replace the effects by looping
foreach (ModelMesh mesh in myPositionedModel.XnaModel.Meshes)
{
    foreach (ModelMeshPart part in mesh.MeshParts)
    {
        part.Effect = newEffect;
    }
}
```

Note that if you use the same effect in multiple places, the parameters may be changed on every use. You may want to Clone() the effect after loading it to ensure it is unique, then set the parameters.

### Getting Textures

Models store the Texture that they reference in their effect. Therefore, the Texture used on individual mesh parts can be retrieved and set through effects.

Did this article leave any questions unanswered? Post any question in our [forums](../../../../frb/forum.md) for a rapid response.
