# Localization

## Introduction

Gum supports localization using CSV files. Gum projects with localization can be loaded and used in FlatRedBall projects. Since FlatRedBall supports its own localization, a wrapper class can be used to share the same localization with Gum at runtime.

For information on setting up localization in the Gum tool, see the Gum Localization docs: [https://docs.flatredball.com/gum/gum-tool/localization](https://docs.flatredball.com/gum/gum-tool/localization)

## Code Example - Sharing Localization

The following code shows how to share localization with Gum using the `LocalizationManagerWrapper` class:

```csharp
// The following code could be called after initializing FlatRedball:
private static void InitializeLocalization()
{
    // Set your language index in FlatRedBall
    LocalizationManager.CurrentLanguage = 4;
    // LocalizationManagerWrapper uses FlatRedBall's LocalizationManager
    CustomSetPropertyOnRenderable.LocalizationService = 
        new LocalizationManagerWrapper();
}

```
