# Adding File Format Support

### Introduction

Glue plugins can be used to load custom files beyond the standard files that can be loaded natively (such as .png). This document shows how to load a custom file format.

### AssetTypeInfo

Glue uses a type called AssetTypeInfo to define the types of objects that are recognized by Glue. The AssetTypeInfo contains a variety of information about how to work with a file. The following properties are needed when adding support for new file formats:

* QualifiedRuntimeTypeName - the qualified (includes namespace) runtime type of the class created when the file is loaded. For example `Microsoft.Xna.Framework.Graphics.Texture2D`
* Extension - the file extension of the file supported. For example `png`
* FriendlyName - a name shown to the user in the FRB Editor so they can select the type. For example `Texture2D`
* CustomLoadFunc - a method which returns the string which is injected in generated code to create the runtime object.
* AddToManagersFunc - a method which returns a string which is injected in generated code to add the runtime object to managers. This is only required if the object that is created is an object which can be added to managers. For example, a Texture2D is not added to managers, but a LayeredTileMap (Tiled map) is added to managers.

The CustomLoadFunc and AddToManagersFunc methods can return a single line of code or they can return a complex initialization block. For the sake of convenience for the user, if possible the generated code should return as few lines of code as possible. In other words, rather than creating a large block of code to load a file or to add the file to managers, this code should be contained in a class or method which can be called either in generated code or custom code. Some games require the flexibility of being able to load content in custom code, and users will appreciate any simplicity your plugin provides.

### Defining an AssetTypeInfo

In most cases a plugin defines and adds its AssetTypeInfo instances when the plugin first starts. In rare cases a plugin may add and remove AssetTypeInfo instances in response to projects being loaded and unloaded.

In the simplest case, an AssetTypeInfo can be added in a plugin's StartUp method. For example, code to add an AssetTypeInfo might look like the following code snippet:

```csharp
public override void StartUp()
{
    var assetTypeInfo = CreateAssetTypeInfo();
    this.AddAssetTypeInfo(assetTypeInfo);
}

private AssetTypeInfo CreateAssetTypeInfo()
{
    var assetTypeInfo = new AssetTypeInfo();
    // fill in the AssetTypeInfo properties here:
    // ...

    return assetTypeInfo;
}
```

todo: add example code
