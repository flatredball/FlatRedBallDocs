# localizationmanager

### Introduction

The LocalizationManager is a class that can be used if your game is going to support localization (multiple languages). The LocalizationManager stores a Dictionary of string IDs and their corresponding values for different languages.

### Code Example

Typically the LocalizationManager uses localization CSVs which are set up in the FlatRedBall Editor. For information on how to create a localization CSV, see [the IsDatabaseForLocalizing page](../../../documentation/tools/glue-reference/files/glue-reference-isdatabaseforlocalizing.md). Assuming you have set up your localization properly, the following code shows how to access localized files in code:

```
// This assumes that T_Hello is a valid key in your localization database
string stringId = "T_Hello";

string translatedText = LocalizationManager.Translate(stringId);

// translatedText should now be the translated text in whatever language you're working in.
```

&#x20;
