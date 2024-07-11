# Comma Separated Values (.csv)

### Introduction

CSV (comma separated values) is a spreadsheet file format which has extensive support in FlatRedBall.

### What is a CSV?

CSV stands for "comma separated values". If you are familiar with Microsoft Excel, then you may be familiar with the .xlsx or .xls file format. The .csv file format is similar to the .xlsx file format in that they are both spreadsheet file formats. One main difference between the two is that the .csv file format is much easier to read and edit in a text editor. For example, consider the following:

| Column 1 | Column 2   | Column 3   |
| -------- | ---------- | ---------- |
| Value 1  | Value 2    | Value 3    |
| Next Row | Next Row 2 | Next Row 3 |

If this were a CSV file viewed in a text editor then it would appear as follows:

```
Column 1,Column 2,Column 3
Value 1,Value 2,Value 3
Next Row,Next Row 2,Next Row 3
```

You can see above that the values (such as "Column 1" and "Column 2") are separated by commas. This is where the name "comma separated values" comes from.

### CSVs create data files

When you create or modify a CSV which is part of your FlatRedBall project, FRB automatically creates code files (classes) which can be used to store information that is loaded from a CSV in your project. These files/classes are often referred to as "data" files and classes because FRB generates them in the Data namespace of your project. The data file will include a class with the same name as your CSV file. This will include members matching the headers of the columns of your CSV. For example, consider a file EnemyInfo.csv which contains the following:

| Name (required) | Speed (float) | Texture |
| --------------- | ------------- | ------- |
| Bear            | 60            | Bear    |
| Slug            | 20            | Slug    |

If this file is added to a Screen, Entity, or Global Content, then FlatRedBall automatically creates a file called EnemyInfo.Generated.cs:

```csharp
public partial class EnemyInfo
{
   public string Name;
   public float Speed;
   public string Texture;
}
```

### Adding a CSV File

To add a CSV file:

1. Open the FlatRedBall Editor
2. Pick a place for your CSV file in your project. Usually CSV files are added to Global Content Files
3. Right-click on on the location which should contain the new CSV and select Add File -> New File
4. Enter the name for the new file. Although not necessary it's common to end the file name with "Data". For example, EnemyData if the file is to include data about enemies.

<figure><img src="../../../.gitbook/assets/image (1).png" alt=""><figcaption><p>Spreadsheet (.csv) selected in the new file window</p></figcaption></figure>

Once you have added a new CSV file you can edit it in any editor you prefer, such as Excel, Libre Office, or even a text editor.

### Accessing CSV Data in Code

CSV files which are added to the FRB Editor are automatically loaded. If your CSV is added to Global Content Files (as is usually the case), then its contents can be accessed through the GlobalContent object.

For example, consider an EnemyData.csv file added to Global Content Files.

<figure><img src="../../../.gitbook/assets/image (1) (2).png" alt=""><figcaption><p>EnemyData.csv file in Global Content Files</p></figcaption></figure>

This file can be accessed in code through the GlobalContent object in code as shown in the following code snippet:

```csharp
void CustomInitialize()
{
    var monsterData = GlobalContent.EnemyData["Monster"];
    var health = monsterData.Health;

    // You can use health or any other property in your game
}
```

The example above assumes a row for the "Monster" enemy and a column for Health as shown in the following image:

<figure><img src="../../../.gitbook/assets/image (2).png" alt=""><figcaption><p>CSV with a Monster row and a Health property from column B</p></figcaption></figure>

Note that if you add additional rows or columns you can access these in your code. Also note that this code assumes that the CSV is loaded into a dictionary. For more information on List vs Dictionary loading, see the [CreatesDictionary](createsdictionary.md) property.

### Headers and Generated Class Definition

As mentioned above, the FlatRedBall editor automatically generate a code file based on the CSV. Specifically, FRB looks at the top row (headers) of the CSV file to determine the class members. If a header does not specify a type, then it will default to a string type.

The example above has two string members: Name and Texture. Headers can also define the type of a class. For example, the header above **Speed (float)** results in the EnemyInfo class including a Speed property of type float. FRB supports comments for headers resultingin the exclusion of the property. For example, the following CSV would include a single Name property, and the other column is ignored:

| Name (required) | // Comment       |
| --------------- | ---------------- |
| Bear            | Bears are strong |
| Slug            | Slugs are slow   |

### CSVs and Lists

Columns in a CSV may be of a list type (such as List\<int>). These types can be specified in parenthesis just like any other type. When a CSV includes a list, the **required** row defines how many entries are in the CSV. For example, the following CSV contains two car definitions, and each car has multiple features.

| Name (required) | Features (List\<string>) |
| --------------- | ------------------------ |
| Accord          | Power Windows            |
|                 | Power Locks              |
|                 | Anti-lock Brakes         |
| Leaf            | Electric Motor           |
|                 | Electric Motor           |

### The generated file is partial

The generated code file for the data class is marked as "partial". This means that you can add additional code files to add additional variables and functionality to data that is created by FRB. To do this:

1. Find the data file in Visual Studio
2. Right-click on the folder containing the Data file
3. Select "Add"->"Class..."
4. Enter the name of your CSV file without the extension. For example, if using EnemyInfo.csv, the new Class name would be EnemyInfo (so it matches the class name in the generated file)
5. Once the file is selected, find the header of the file and make it partial. In other words, change:

```csharp
class EnemyInfo
```

to

```csharp
partial class EnemyInfo
```

Now you can things to EnemyInfo to help you work with the generated class. Note that this approach of using partial classes is the same as what FRB automatically does for you when you create a Screen or Entity. Custom code is very common in Screens and Entities, so FRB automatically creates a custom code file for you. Custom code in data classes is less common so FRB does not automatically do this for you; however if you do it manually it works the same way.
