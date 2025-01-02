# FromFileText

### Introduction

FromFileText returns text content from the argument file path. The file path can be absolute or relative to the FileManager's [RelativeDirectory](relativedirectory.md).

FromFileText can be used on all FlatRedBall platforms safely. Internally it uses TitleContainer if required for a particular platform.

### Example - Loading JSON Contents

The following code shows how to load a file called EnemyData.json.

```csharp
var jsonContents = FlatRedBall.IO.FileManager.FromFileText(
    "Content/GlobalContent/EnemyData.json");
```

This code assumes that the file EnemyData.json is located in the Content/GlobalContent folder, and that it is marked to copy if newer. The FlatRedBall Editor can manage this if you add the file to Global Content.
