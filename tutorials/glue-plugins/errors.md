# Errors

### Introduction

The Errors tab is a useful way to let the user know about a problem in their FlatRedBall project. Errors can be a more effective way to explain a problem compared to generating syntax errors or crashes at runtime. Plugins provide support for interacting with the Errors tab.

<figure><img src="../../.gitbook/assets/image (5).png" alt=""><figcaption><p>Error window displaying an error about a missing atlas</p></figcaption></figure>

### ErrorViewModel and ErrorReporterBase

Errors are reported using two objects. ErrorViewModel serves as a base class for all errors. Each entry in the error window is an instance of a type inheriting from ErrorViewModel. nThe ErrorViewModel typically provides the following information and functionality:

* Text describing the error
* The ability to check if the error is still occurring
* Action to perform when the error is double-clicked

The ErrorReporterBase class is responsible for scanning the entire FlatRedBall project and reporting any errors which are found. Typically each plugin defines its own class that inherits from ErrorReporterBase and it returns instances of classes inheriting from the ErrorViewModel.

### ErrorViewModel Example

An ErrorViewModel-inheriting class typically has the following parts:

* A UniqueId property - this can be the same as its Details property for simplicity
* Details - the information displayed to the user in the Errors window
* Glue References - references to the objects which have the errors. These can be GlueElements, ReferencedFileSaves, NamedObjectSaves, or other Glue types.
* HandleDoubleClick - a method which reacts to double-clicking. This usually selects the object which has the error

Note that the ErrorReporterBase class is responsible for instantiating ErrorViewModels, so making a static GetIfHasError method can be useful so it can be used both by the ErrorReporterBase when creating new errors and also by the ErrorViewModel to verify if the error has been fixed.

The following class is an example ErrorViewModel which reports whether a ReferencedFileSave has a missing AtlasName property.

```csharp
public class MissingAtlasErrorViewModel : ErrorViewModel
{
    public override string UniqueId => Details;

    public GlueElement? Element { get; }
    public ReferencedFileSave ReferencedFileSave { get; }

    public MissingAtlasErrorViewModel(GlueElement? element, ReferencedFileSave rfs)
    {
        this.Element = element;
        this.ReferencedFileSave = rfs;

        this.Details = $"Missing atlas for {rfs}";
    }

    public override void HandleDoubleClick()
    {
        GlueState.Self.CurrentReferencedFileSave = ReferencedFileSave;
    }

    public override bool GetIfIsFixed()
    {
        return !GetIfHasError(Element, ReferencedFileSave);
    }

    public static bool GetIfHasError(GlueElement? element, ReferencedFileSave rfs)
    {
        if( (element == null || element.ReferencedFiles.Contains(rfs)) && 
            rfs.GetAssetTypeInfo() == SpinePlugin.Managers.AssetTypeInfoManager.SpineDrawableBatchAssetTypeInfo)
        {
            var atlasProperty = rfs.GetProperty<string>("AtlasName");

            if(string.IsNullOrEmpty(atlasProperty))
            {
                return true;
            }
        }
        return false;
    }
}
```

### ErrorReporterBase Example

The ErrorReporterBase inheriting class is responsible for implementing the GetAllErrors method. This method scans the project and returns all errors related to the parent plugin. Note that this is not responsible for all possible errors, only errors which are related to the current plugin.

The ErrorViewModel can return an empty ErrorViewModel array if there are no errors reported. The following shows how to check all files in a project to see if an error should be created for any files. It uses the MissingAtlasErrorViewModel shown above to check if any error should be created.

```csharp
class SpineErrorReporter : ErrorReporterBase
{
    public override ErrorViewModel[] GetAllErrors()
    {
        var project = GlueState.Self.CurrentGlueProject;
        if (project == null) return new ErrorViewModel[0];

        List<ErrorViewModel> errors = new List<ErrorViewModel>();
        foreach(var screen in project.Screens)
        {
            foreach(var file in screen.ReferencedFiles)
            {
                if(MissingAtlasErrorViewModel.GetIfHasError(screen, file))
                {
                    errors.Add(new MissingAtlasErrorViewModel(screen, file));
                }
            }
        }
        foreach(var entity in project.Entities)
        {
            foreach(var file in entity.ReferencedFiles)
            {
                if(MissingAtlasErrorViewModel.GetIfHasError(entity, file))
                {
                    errors.Add(new MissingAtlasErrorViewModel(entity, file));
                }
            }
        }
        foreach(var file in project.GlobalFiles)
        {
            if (MissingAtlasErrorViewModel.GetIfHasError(null, file))
            {
                errors.Add(new MissingAtlasErrorViewModel(null, file));
            }
        }

        return errors.ToArray();
    }
}
```

An instance of the ErrorReporterBase inheriting class must be added to a plugin. This is typically done in the plugin's StartUp method as shown in the following code:

```csharp
public override void StartUp()
{
    AddErrorReporter(new SpineErrorReporter());
    // additional StartUp logic here
}

```
