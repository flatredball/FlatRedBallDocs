## Introduction

As explained in the main [CsvFileManager page](/frb/docs/index.php?title=FlatRedBall.IO.Csv.CsvFileManager.md "FlatRedBall.IO.Csv.CsvFileManager"), you can easily create CSV files to define data classes such as:

    public class Car
    {
      public string Make;
      public string Model;
      public int Horsepower;
    }

But what if you wanted to also include a list of modifications on the car. In other words, something like this:

    public class Car
    {
      public string Make;
      public string Model;
      public int Horsepower;
      public List<string> Modifications = new List<string>();
    }

The CsvFileManager understands special syntax allowing for objects represented in a row to actually take up multiple rows, and to define lists.

## Preparing a CSV file

The class shown above for Car is all that you need to do code-side to prepare your class to take a list of strings. To create a CSV that can support rows, you would want to create a spreadsheet that looks like this:

|                 |         |                  |                                |
|-----------------|---------|------------------|--------------------------------|
| Make (required) | Model   | Horsepower (int) | Modifications (List\<string\>) |
| Ford            | Taurus  | 200              | Paint protection               |
|                 |         |                  | After-market stereo            |
| Toyota          | Corolla | 140              | Tinted windows                 |
|                 |         |                  | 4-way rear speakers            |
|                 |         |                  | Remote start system            |

If using the CSV plugin, the CSV would appear as shown in the following image:

![](/media/2017-05-img_59189f093974d.png)

In this case the Ford Taurus has 2 modifications ("Paint protection" and "After-market stereo"). The Toyota Corolla has 3 modifications ("Tinted Windows", "4-way rear speakers", and "Remote start system"). The spreadsheet displayed above has two things that are needed for lists. The first, which is quite obvious, is to declare the type for the appropriate header as a List\<string\> (or whatever other primitive type you are using). In this case, we're using List\<string\>, so the header is declared as follows:

    Modifications (List<string>)

This tells the CsvFileManager that the "Modifications" row should be treated as a List of strings, and that entries in the row may belong to the same object. However, this does raise one issue - how is the CsvFileManager to know when one list starts and when one ends. While it may seem obvious to you that the "After-market stereo" modification applies to the Taurus, it is entirely possible that the "After-market stereo" could also belong to a car with an empty Make, Model, and Horsepower. This is why the Make column has "(required)" after its name. This tells the CsvFileManager that this column has a required value, and that this column will define new instances. In other words, since there are two entries in the Make column, the CsvFileManager knows to make two instances when deserializing the CSV.

## For Glue Users

If you've used CSV files in Glue, then you probably know that Glue will automatically generate classes to match the given CSV format. Glue understands the List\<TYPE\> syntax described above. In other words, feel free to use this CSV syntax in your own files and Glue will automatically build classes that will match your CSVs.
