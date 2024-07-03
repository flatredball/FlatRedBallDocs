# OpenDocument Spreadsheet (.ods)

### Introduction

OpenDocument Spreadsheet files can be loaded into your game similar to .csv files. Technically, .ods files are converted to .csv files by the FlatRedBall Editor and are loaded as if they are standard CSV files.

Using .ods files offers a number of benefits over .csv files:

* They can contain formulas
* They can contain styling and formatting, such as cell colors or bold text
* They can contain dropdowns and other formatted cell types

The .ods file format does add a small amount of complexity to your projct:

* .ods files must be converted to .csv which requires installing LibreOffice
* .ods file conversion to .csv is performed by the FlatRedBall Editor if the .ods file is newer than the .csv, or if the .csv is missing. This takes a short amount of time when first opening the project.

FRB creates a class for your .ods file using the same rules as .csv files. For information about the automatic generation of data for .csv files, see the [.csv page](glue-reference-csv/).

### Example - Adding an .ods File and Accessing Values

To add a new .ods file:

1. Decide where to keep the .ods file. Usually game data such as .ods and .csv files are stored in Global Content Files
2. Right-click on the desired location (such as Global Content Files) and select Add New File
3. Select the ods file type
4. Enter a name, such as EnemyData
5. Click OK

<figure><img src="../../.gitbook/assets/image (147).png" alt=""><figcaption><p>Adding EnemyData ods file type</p></figcaption></figure>

Confirm the conversion of .ods to .csv in the popup window by clicking OK.

<figure><img src="../../.gitbook/assets/image (148).png" alt=""><figcaption><p>Popup for confirming to use open office (soffice.exe)</p></figcaption></figure>

The newly-created file should appear in the tree view in FRB. Notice that the file is listed as a .csv file since it is converted from .ods to .csv.

<figure><img src="../../.gitbook/assets/image (149).png" alt=""><figcaption><p>EnemyData.csv in the tree view.</p></figcaption></figure>

You can confirm the original file is an .ods file by selecting the file and viewing its properties.

<figure><img src="../../.gitbook/assets/image (150).png" alt=""><figcaption><p>EnemyData.csv properties displays its source file and build tool (conversion executable)</p></figcaption></figure>

FlatRedBall automatically creates a backing data class for your file which matches the name of the .ods file. For example, the following screenshot shows the EnemyData class using the default contents of the .ods.

<figure><img src="../../.gitbook/assets/image (151).png" alt=""><figcaption><p>EnemyData class automatically created in generated code</p></figcaption></figure>

Similarly, the enemy data class is loaded in the object which contains the .ods file. Using the example from above, the EnemyData file would be loaded into GlobalContent and it can be accessed as shown in the following code:

```csharp
// This assumes that the data is loaded into a List, not a Dictionary
var firstItem = GlobalContent.EnemyData[0];
var health = firstItem.Health;
```
