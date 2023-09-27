## Introduction

CsvDeserializeList can be used to load a CSV into a list of objects, where the type of the object is passed in to the method call.

## Code Example - Loading a List of String\[\]

The CsvFileManager can be used to load a list of specific types (such as weapon data for an RPG) or a list of strings if there is no appropriate class to deserialize to. The following code can be used to deserialize a CSV to a list of strings:

``` lang:c#
var list = new List<string[]>();
CsvFileManager.CsvDeserializeList(typeof(string[]), "content/myfile.csv", list);
```

   
