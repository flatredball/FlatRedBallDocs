# GlueSettingsSave

### Introduction

GlueSettingsSave provides global (not project specific) settings used by the FlatRedBall Editor. GlueSettingsSave includes properties that are not tied to a specific file in the project, but rather the entire project. Also, GlueSettingsSave is not used to store plugin-specific settings.

### Interacting With GlueSettingsSave

GlueSettingsSave can be accessed through GlueState. The following code shows how to set the BookmarkRowHeight. Note that setting this does not directly modify the UI, but instead modifies the settings which are used when restarting the FRB Editor.

```csharp
var settings = GlueState.Self.GlueSettingsSave;
settings.BookmarkRowHeight = desiredValue;
settings.Save(); // writes the file to disk in the standard location
```
