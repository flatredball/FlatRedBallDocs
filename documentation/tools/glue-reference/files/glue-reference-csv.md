## Introduction

CSV (comma separated values) is a spreadsheet file format which has extensive support in FlatRedBall and Glue. For information on how to use CSVs in Glue, see the ["Using CSVs" article](/documentation/tutorials/glue-tutorials/glue-tutorials-using-csvs.md "Glue:Tutorials:Using CSVs"). For more information on how to combine CSVs with Entities, see ["How To Combine CSVs with Entities" article](/uncategorized/glue-how-to-combine-csvs-with-entities.md "Glue:How To:Combine CSVs with Entities").

## What is a CSV?

CSV stands for "comma separated values". If you are familiar with Microsoft Excel, then you may be familiar with the .xlsx or .xls file format. The .csv file format is similar to the .xlsx file format in that they are both spreadsheet file formats. One main difference between the two is that the .csv file format is much easier to read and edit in a text editor. For example, consider the following:

|          |            |            |
|----------|------------|------------|
| Column 1 | Column 2   | Column 3   |
| Value 1  | Value 2    | Value 3    |
| Next Row | Next Row 2 | Next Row 3 |

If this were a CSV file viewed in a text editor then it would appear as follows:

    Column 1,Column 2,Column 3
    Value 1,Value 2,Value 3
    Next Row,Next Row 2,Next Row 3

You can see above that the values (such as "Column 1" and "Column 2") are separated by commas. This is where the name "comma separated values" comes from.

## CSVs create data files

When you create or modify a CSV which is part of your Glue project, Glue will automatically create code files (classes) which can be used to store information that is loaded from a CSV in your project. These files/classes are often referred to as "data" files and classes because Glue places them in the Data namespace of your project. The data file will include a class with the same name as your CSV file. This will include members matching the headers of the columns of your CSV. For example, consider a file EnemyInfo.csv which contains the following:

|                 |               |         |
|-----------------|---------------|---------|
| Name (required) | Speed (float) | Texture |
| Bear            | 60            | Bear    |
| Slug            | 20            | Slug    |

If this file is added to a Screen, Entity, or Global Content, then Glue will automatically create a file called EnemyInfo.Generated.cs:

    public partial class EnemyInfo
    {
       public string Name;
       public float Speed;
       public string Texture;
    }

## Headers and Generated Class Definition

As mentioned above, Glue will automatically generate a file based on the CSV. Specifically, Glue looks at the top row (headers) of the CSV file to determine the class members. If a header does not specify a type, then it will default to a string type. For example, The example above has two string members: Name and Texture. Headers can also define the type of a class. For example, the header above **Speed (float)** results in a the EnemyInfo including a Speed property of type float. Glue supports comments for headers which tells Glue to exclude a particular member from the class. For example, the following CSV would include a single Name property, and the other column is ignored:

|                 |                  |
|-----------------|------------------|
| Name (required) | // Comment       |
| Bear            | Bears are strong |
| Slug            | Slugs are slow   |

For a full list of supported types, see the [CsvManager page](/documentation/api/flatredball/io/csv/csvfilemanager.md).

## CSVs and Lists

Columns in a CSV may be of a list type (such as List\<int\>). These types can be specified in parenthesis just like any other type. When a CSV includes a list, the **required** row defines how many entries are in the CSV. For example, the following CSV contains two car definitions, and each car has multiple features.

|                 |                           |
|-----------------|---------------------------|
| Name (required) | Features (List\<string\>) |
| Accord          | Power Windows             |
|                 | Power Locks               |
|                 | Anti-lock Brakes          |
| Leaf            | Electric Motor            |
|                 | Electric Motor            |

 

## The generated file is partial

The generated code file for the data class is marked as "partial". This means that you can add additional code files to add additional variables and functionality to data that is created by Glue. To do this:

1.  Find the data file in Visual Studio
2.  Right-click on the folder containing the Data file
3.  Select "Add"-\>"Class..."
4.  Enter the name of your CSV file without the extension. For example, if using EnemyInfo.csv, the new Class name would be EnemyInfo (so it matches the class name in the generated file)
5.  Once the file is selected, find the header of the file and make it partial. In other words, change:

&nbsp;

    class EnemyInfo

to

    partial class EnemyInfo

Now you can things to EnemyInfo to help you work with the generated class. Note that this approach of using partial classes is the same as what Glue automatically does for you when you create a Screen or Entity. Custom code is very common in Screens and Entities, so Glue automatically creates a custom code file for you. Custom code in data classes is less common so Glue does not automatically do this for you; however if you do it manually it will work the same way.
