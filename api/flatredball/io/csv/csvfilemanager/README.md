# csvfilemanager

### Introduction

The CsvFileManager is a class which provides functionality for working with [.csv files](http://en.wikipedia.org/wiki/Comma-separated_values). The CSV file format is a simple file format that can be loaded and saved by spreadsheet programs. Glue provides a lot of functionality for working with CSV files. For information on working with CSV and Glue, see the [using CSVs in Glue tutorial](../../../../../../frb/docs/index.php).

### Benefits of CSV

FlatRedBall engines are built to work well with the XML format. The [FileManager](../../../../../../frb/docs/index.php) provides methods for serializing to and deserializing from XML files, and most [FlatRedBall file types](../../../../../../frb/docs/index.php) are actually XML files for simplified readability, debugging, and to be cross-platform. However, despite its merits, the XML file type has a few disadvantages:

* XML files tend to be bloated for the data contained. In many cases most of the data in the XML file comes from the tags rather than the data.
* XML files can be difficult to maintain by hand. Despite being human readable, adding new entries without copying/pasting other entries is tedious and error prone.
* XML files do not have a standard editor. While there are likely options for specifically editing XML files, most by-hand XML editing is performed in text editors. These editors do not provide any support for the file format.

The CSV format is a human readable format which while still being a text format can be very compact compared to XML files and can be edited in a number of common editors such as [Google Docs](http://docs.google.com/), [Open Office](http://www.openoffice.org/), and Microsoft Excel. These editors are very easy to use, support advanced editing such as the use of formulas, and the first two are completely free!

### What is a CSV?

CSV stands for Comma Separated Values. CSV files can be displayed in spreadsheet programs, or be used as data files in FlatRedBall and Glue. CSV files can also be opened in text editors. Investigating the contents of a CSV file is often not necessary but can be helpful when debugging problems related to CSVs. A typical CSV file may look like this in a text editor:

```
Header1,Header2,Header3
FirstValue,SecondValue,ThirdValue
```

This file would appear as follows in a spreadsheet program:

|            |             |            |
| ---------- | ----------- | ---------- |
| Header1    | Header2     | Header3    |
| FirstValue | SecondValue | ThirdValue |

#### Commas inside cells

The comma is the most common separator of cells (although other separators such as tabs and the | character are supported). Commas are also common in regular written English as well. The CSV format supports commas inside cells. Quotes are used to distinguish between a comma within a cell and a comma separating cells. For example, the following text shows the contents of a CSV file which includes commas.

```
Morning Greeting, Regular Greeting
Good morning, "Hello, how are you?"
```

This would result in the following CSV (notice the quotes do not appear)

|                  |                     |
| ---------------- | ------------------- |
| Morning Greeting | Regular Greeting    |
| Good morning     | Hello, how are you? |

Notice that single-quotes around a cell are not included in the contents of a CSV cell. Therefore, quotes may appear around cells even if they do not include a comma (this is the default behavior of OpenOffice):

```
"Morning Greeting", "Regular Greeting"
"Good morning", "Hello, how are you?"
```

### Creating CSV Files

The CsvfileManager provides methods for loading CSV files and creating lists of items. The code included in this article defines a simple struct which contains properties used to initialize newly-created [Sprites](../../../../../../frb/docs/index.php). But before getting to the code, we will explain how to create CSV files in [Google Docs](http://docs.google.com/). The following lists how to create a CSV file using [Google Docs](http://docs.google.com/).

1. Go to the Google Docs website: [http://docs.google.com/](http://docs.google.com/).
2. Log in to Google Docs. If you have never logged in before, but have a GMail address, use your GMail address and password to log in. Otherwise, you will need to create a new account.
3. Select New->Spreadsheet: ![NewSpreadsheet.png](../../../../../../media/migrated_media-NewSpreadsheet.png)
4. Enter the headers for the spreadsheet. These headers will be the fields of the class that we'll be creating later in this article: ![PropertiesInSpreadsheet.png](../../../../../../media/migrated_media-PropertiesInSpreadsheet.png)
5. Enter values for each of the structs. Each row represents an item in the list that will be created when the CSV file is deserialized. In this case I'll create four entries: ![SpreadsheetWithValues.png](../../../../../../media/migrated_media-SpreadsheetWithValues.png)
6. Export the files to a .csv file. ![ExportToCsv.png](../../../../../../media/migrated_media-ExportToCsv.png)
7. Depending on your browser the CSV file may open right in the browser. If that's the case, save the file out from the browser through the File menu: ![SaveFromBrowser.png](../../../../../../media/migrated_media-SaveFromBrowser.png)

At this point you should have a CSV file saved on your computer. The file should be similar to: [Export.csv](../../../../../../frb/docs/images/3/38/Export.csv) Either save this file in the the same folder as your project's EXE file, or add it to the solution and set the file to copy.

### Code Example

The following code uses the CSV file from the previous section to create a group of Sprites. Create the following struct:

```
public struct SpriteProperties
{
    public float X;
    public float Y;
    public float ScaleX;
    public float ScaleY;
}
```

Add the following to Initialize after initializing FlatRedBall

```
// This used ArrayList in older versions of FRB
List<object> list = FlatRedBall.IO.Csv.CsvFileManager.CsvDeserializeList(
    typeof(SpriteProperties), "export.csv");

foreach (SpriteProperties spriteProperties in list)
{
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

    sprite.X = spriteProperties.X;
    sprite.Y = spriteProperties.Y;
    sprite.ScaleX = spriteProperties.ScaleX;
    sprite.ScaleY = spriteProperties.ScaleY;
}
```

![SpritesFromCsv.png](../../../../../../media/migrated_media-SpritesFromCsv.png)

### Supported Types

The following table shows the supported types.

|                                                                 |                                                 |                                                          |
| --------------------------------------------------------------- | ----------------------------------------------- | -------------------------------------------------------- |
| Type                                                            | Member Example                                  | CSV Entry Example                                        |
| bool _(A)_                                                      | public bool IsHungry;                           | true                                                     |
| double                                                          | public double LengthOfTime;                     | 3.244                                                    |
| Enum _(B)_                                                      | public BorderSides Sides;                       | Top                                                      |
| float                                                           | public float X;                                 | 1                                                        |
| int                                                             | public int CurrentLevel;                        | 3                                                        |
| Matrix                                                          | public Matrix OrientationMatrix;                | 1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1                          |
| string                                                          | public string FirstName;                        | Martin                                                   |
| Texture2D _(C)_                                                 | public Texture2D TextureToUse;                  | redball.bmp                                              |
| Vector2                                                         | public Vector2 GoalPosition;                    | 23,18                                                    |
| Vector3                                                         | public Vector3 DirectionToFace;                 | 11,0,-14                                                 |
| Vector4                                                         | public Vector4 FourDimentionalVector;           | 24,18,0,1                                                |
| List\<string> (or lists of any primitive)                       | public List\<string> Names = new List\<string>; | See [this article](../../../../../../frb/docs/index.php) |
| Color                                                           | public Color PaintColor;                        | See [this article](../../../../../../frb/docs/index.php) |
| Custom types (such as classes and structs defined in your game) | public SpecialAbility AbilityInstance;          | see [this article](../../../../../../frb/docs/index.php) |

_(A)_ Some applications like OpenOffice Calc convert "true" to "TRUE". FlatRedBall will parse bool values regardless of capitalization. In other words, "TRUE" will be parsed correctly. _(B)_ CSVs support enumerations. If using enumerations in Glue, you need to fully-qualify the enumeration in the type. For example, for a color operation, the header might read:

```
ColorOp (FlatRedBall.Graphics.ColorOperation)
```

You do not need to qualify the value. For example, you can simply use "Modulate" instead of "ColorOperation.Modulate" in the cell for a value under a ColorOperation header. _(C)_ FlatRedBall needs a content manager to load Texture2Ds. The CsvFileManager will automatically use FlatRedBallServices.GlobalContentManager if not content manager is explicitly set. You can set the content manager as follows:

```
CsvFileManager.ContentManagerName = SomeContentManager; // use the Screen's ContentManagerName if using Screens
```

### Additional Information

* [Cells with multiple lines](../../../../../../frb/docs/index.php)
* [Instantiating custom types](../../../../../../frb/docs/index.php)
* [Rows with lists](../../../../../../frb/docs/index.php)

### CsvFileManager Members

\[subpages depth="1"]
