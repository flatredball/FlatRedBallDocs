# flatredball-content-math-shapecollectionsave

### Introduction

The ShapeCollectionSave class is a ["save"](../../../../../../frb/docs/index.php) class. Save classes are classes which allow you to load XML files to runtime objects as well as to save data contained in runtime objects to XML files. For more information on Save files, check [this article](../../../../../../frb/docs/index.php).

You do not need to use the ShapeCollectionSave class in most cases since the FlatRedBallServices' Load method can load ShapeCollections. If you are simply looking to load a ShapeCollection, see [this page](../../../../../../frb/docs/index.php#Loading_a_ShapeCollection).

You can use ShapeCollectionSave if you are making a tool that works with the .shcx file format.

### Loading a .shcx file

You can load load a ShapeCollectionSave as follows:

```
ShapeCollectionSave saveInstance = ShapeCollectionSave.FromFile("fileName.shcx");
```

### Saving a .shcx file

Sha'eCollectionSaves can be saved through the Save method. Therefore, the process of saving an existing ShapeCollectionSave is very simple:

```
string fileName = "c:/folder/fileName.shcx"; // The .shcx extension is the standard extension for ShapeCollectionSaves
shapeCollectionSaveInstance.Save(fileName);
```

The more complicated process is to construct the ShapeCollectionSave. You can construct a ShapeCollectionSave by creating a ShapeCollectionSave from an existing [ShapeCollection](../../../../../../frb/docs/index.php) or manually (by instantiating and adding instances to it).

#### Creating a ShapeCollectionSave from a [ShapeCollection](../../../../../../frb/docs/index.php)

The following code saves a .shcxfile named MyShapeCollection.shcx. It assumes that shapeCollection is a valid .

Add the following using statements:

```
using FlatRedBall.Math.Geometry;
using FlatRedBall.Content.Math.Geometry;
```

Assumes shapeCollection is a valid [ShapeCollection](../../../../../../frb/docs/index.php):

```
 ShapeCollectionSave save =
    ShapeCollectionSave.FromShapeCollection(shapeCollection);
 string fileName = "MyShapeCollection.shcx";
 save.Save(fileName);
```

#### Creating a ShapeCollectionSave manually

The steps for creating a ShapeCollectionSave manually are:

1. Instantiate a ShapeCollectionSave
2. Add "save" instances to the ShapeCollectionSave (such as [PolygonSave](../../../../../../frb/docs/index.php) and [CircleSave](../../../../../../frb/docs/index.php))
3. Save using the Save method.

### Creating a [ShapeCollection](../../../../../../frb/docs/index.php) from a ShapeCollectionSave

You can convert ShapeCollectionSaves into runtime ShapeCollections: Add the following using statements:

```
using FlatRedBall.Math.Geometry;
using FlatRedBall.Content.Math.Geometry;
```

Assumes "save" is a valid ShapeCollectionSave:

```
ShapeCollection newShapeCollection = save.ToShapeCollection();
// You can make the ShapeCollection visible if desired:
newShapeCollection.AddToManagers();
```

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../../frb/forum.md) for a rapid response.
