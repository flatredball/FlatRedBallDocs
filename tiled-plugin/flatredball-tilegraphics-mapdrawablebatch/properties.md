# Properties

### Introduction

The Properties list contains properties on a MapDrawableBatch obtained from Layer properties in tiled.

Properties can be added to Layers in Tiled to be accessed at runtime.

<figure><img src="../../.gitbook/assets/24_09 42 40.png" alt=""><figcaption><p>Layer properties in Tiled</p></figcaption></figure>

### Code Example - Accessing Layer Properties

The following code shows how to access layers in Tiled. It assumes that the Tiled layer has the following properties:

* StringProperty
* FloatProperty
* IntProperty

<figure><img src="../../.gitbook/assets/24_09 45 08.png" alt=""><figcaption><p>Properties in Tiled</p></figcaption></figure>

```csharp
var layer = this.Map.MapLayers.FindByName("GameplayLayer");
var layerProperties = layer.Properties;
var stringProperty = layerProperties
    .First(item => item.Name == "StringProperty");
var intProperty = layerProperties
    .First(item => item.Name == "IntProperty");
var floatProperty = layerProperties
                .First(item => item.Name == "FloatProperty");

var stringValue = stringProperty.Value;
// all values come in as strings, so they must be parsed:
var intValue = int.Parse((string)intProperty.Value);
var floatValue = float.Parse((string)floatProperty.Value);
```
