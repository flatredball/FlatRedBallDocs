# LocalizationManager

### Introduction

The LocalizationManager class can be used if your game is going to support localization (multiple languages). The LocalizationManager stores a Dictionary of string IDs and their corresponding values for different languages.

### Code Example - Translating a String ID using the Translate method

Typically the LocalizationManager uses localization CSVs which are set up in the FlatRedBall Editor. For information on how to create a localization CSV, see [the IsDatabaseForLocalizing page](../../../glue-reference/files/glue-reference-isdatabaseforlocalizing.md). Assuming you have set up your localization properly, the following code shows how to access localized files in code:

```csharp
// This assumes that T_Hello is a valid key in your localization database
string stringId = "T_Hello";
string translatedText = LocalizationManager.Translate(stringId);

// translatedText should now be the translated text in whatever language you're working in.
```

### Setting Language

The Translate method returns a string based on the current language. This language can be set by assigning the `CurrentLanguage` property. This is a 0-based integer representing the current column in the localization database. Typically the value of 0 represents the string ID column, so the first language is usually index 1. For example, the following code sets the language to the first index:

```csharp
LocalizationManager.CurrentLanguage = 1;
```

Assigning the language by setting CurrentLanguage is useful so you do not need to pass the language in every Translate call. If you would like to translate to a specific language regardless of the value of `CurrentLanguage` you can use the `TranslateForLanguage` method:

```csharp
// Assuming your localization database has at least 4 columns:
var translatedText = LocalizationManager.TranslateForLanguage("T_Hello", 3);
```
