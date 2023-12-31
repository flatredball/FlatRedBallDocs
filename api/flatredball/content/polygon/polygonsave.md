# polygonsave

### Introduction

The PolygonSave class is a "save" object which corresponds to the [FlatRedBall.Math.Geometry.Polygon](../../../../../frb/docs/index.php) runtime object.

For more information on the save pattern, see [this page](../../../../../frb/docs/index.php)

### Creating a PolygonSave

The following code shows how to create a PolygonSave from a Polygon:

```
// Assuming polygonInstance is a valid Polygon
PolygonSave polygonSave = PolygonSave.FromPolygon(polygonInstance);
```

### Creating a Polygon from a PolygonSave

The following code shows how to create a Polygon from a PolygonSave:

```
// Assuming polygonSave is a valid PolygonSave
Polygon polygon = polygonSave.ToPolygon();
```

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
