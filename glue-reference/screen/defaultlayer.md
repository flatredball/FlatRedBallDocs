# DefaultLayer

### Introduction

The DefaultLayer property is used when instantiating entities. It is useful if your game requires all entities to be layered as opposed to the default of being created _unlayered._ This can be useful if your game requires layers for functionality, such as if your main game must render to a render target.

DefaultLayer can be set in the FlatRedBall Editor by selecting a Screen and changing the DefaultLayer variable.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Setting a Screen's DefaultLayer in the Variables tab</p></figcaption></figure>

For more information on working with Layers in the FRB Editor, see the [Layer page](../objects/object-types/glue-reference-layer/).

### DefaultLayer Functionality

DefaultLayer affects the creation of new entities in the FRB Editor and at runtime. The sections below outline the specific behaviors of setting DefaultLayer

### DefaultLayer and New Entities in the FRB Editor

Once a DefaultLayer has been set, any new instance added to the screen or its derived screens automatically has its LayerOn property set.&#x20;

For example, consider a GameScreen with a DefaultLayer set to HudLayer (as shown in the picture above). If an Enemy instance is added either to the GameScreen or any Level screen, then its LayerOn is also set to HudLayer.

<figure><img src="../../.gitbook/assets/10_05 18 56.gif" alt=""><figcaption><p>Enemy added to Level1 automatically having its LayerOn assigned</p></figcaption></figure>

### DefaultLayer and Factories

All Factories which are part of a screen automatically have their DefaultLayer assigned to the Screen's DefaultLayer. Using the example above, we can look at GameScreen.Generated.cs and find the EnemyFactory instantiaton. The following shows the generated code for EnemyFactory:

```csharp
private void InitializeFactoriesAndSorting () 
{
    ...
    Factories.EnemyFactory.Initialize(ContentManagerName);
    Factories.EnemyFactory.DefaultLayer = this.DefaultLayer;
    ...
}
```

DefaultLayer is used when calling the CreateNew method without explicitly specifying a Layer. Note that the DefaultLayer can be overridden if a factory parameter is passed to CreateNew.

Note that the DefaultLayer is returned back to `null` when the Screen is destroyed. This means that if your code explicitly sets the DefaultLayer, this value may get lost when the Screen is destroyed. If your game relies on a DefaultLayer, be sure to explicitly set it in CustomInitialize rather than in Game1 or some other global context.

### Changing DefaultLayer

If a DefaultLayer is changed, then FRB checks all objects in the current and derived screens. If any use the old DefaultLayer, a window appears asking if they should be changed to use the new layer. For example, the following shows the DefaultLayer changing from HudLayer to the "Under Everything" layer.

<figure><img src="../../.gitbook/assets/10_05 26 13.gif" alt=""><figcaption><p>Changing the DefaultLayer results in a window asking if objects should be moved</p></figcaption></figure>

Notice that after the change has been made, the Player1's LayerOn property has changed to the Under Everything layer.

### Screen.DefaultLayer in Code

At runtime the Screen's DefaultLayer matches the DefaultLayer variable assigned in the FRB Editor. Note that changing this property at runtime does not change the layer used for entity creation in generated code, nor does it change the default layer for Factories.

Entity instantiation is hardcoded to use the Screen's DefaultLayer as set in the FRB Editor at the time when the code is generated. Therefore, changing the property at runtome has no impact on the generated code. Note, this behavior may change in the future, but as of April 2024 the Screen's DefaultLayer property should be treated as if it is read-only.
