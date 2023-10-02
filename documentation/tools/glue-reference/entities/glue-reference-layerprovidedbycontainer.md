# glue-reference-layerprovidedbycontainer

### Introduction

The LayerProvidedByContainer property gives you access to the layer that the containing Screen or Entity has passed to this through Glue or through the AddToManagers method call. For more information on working with Layers in code, see the [Layer page](../../../../frb/docs/index.php).

### Usage

You can access the Layer simply by using the LayerProvidedByContainer property:

```
Layer layer = this.LayerProvidedByContainer;
// Do whatever with layer
```

The LayerProvidedByContainer can be used to add additional objects to the same Layer. The following code shows how to create a new Sprite using an existing entity's LayerProvidedByContainer:

```lang:c#
Sprite sprite = new Sprite();
SpriteManager.AddToLayer(sprite, this.LayerProvidedByContainer);
```

The following code shows how to create new entities using an existing entity's LayerProvidedByContainer:

```
int numberOfOtherEntitiesToCreate = 5;
for(int i = 0; i < numberOfOtherEntitiesToCreate; i++)
{
   EntityType childEntity = new EntityType(ContentManagerName, false);
   childEntity.AddToManagers(LayerProvidedByContainer);
}
```
