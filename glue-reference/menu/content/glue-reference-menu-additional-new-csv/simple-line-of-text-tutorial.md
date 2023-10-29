## Requirements for loading custom content

Each entry (usually one row) in a CSV defines how a file type is loaded into a runtime object. This code tells Glue how to generate code to load and interact with various file formats. Before creating an entry in a CSV, you will first need to create a new file format (or use an existing file format) which can be loaded along with an object that the file can be loaded into. For example, if you are using a custom XML file to define the layout of a level in a puzzle game, you may first create an XML file which can contain information about the level, then a class which can hold the information loaded from the XML file. Once you have created this file format and a class to hold its information, will want to test out the loading of this data in custom code first to verify that it is working correctly before you begin to integrate it into Glue.

**Note:** There are typically two types of objects that a file is loaded into in FlatRedBall. The general terms for these types of objects are "save objects" and "runtime objects". Save objects are objects which are typically not used directly in games. They serve as objects which can hold data in a format that is very similar to how the data is stored in a serialized (XML, CSV, or other format) state. Runtime objects are typically objects which are used in actual games. Runtime objects typically have some type of graphical component, often require a content manager to create, and have some component which is added to FlatRedBall managers.

## Tutorial plan

For an example, we'll use custom file format (.lin) and load it into a new class called LinesOfText which will be a class that contains a string array. The LinesOfText object is somewhat of a trivial class, but again we'll create and use this for the sake of keeping the tutorial simple.

## LinesOfText class

For this example we'll use the following LinesOfText class:

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FlatRedBall.IO;

    namespace ProjectNamespace.RuntimeTypes
    {
        public class LinesOfText
        {
            public List<string> Lines = new List<string>();

            public static LinesOfText FromFile(string fileName)
            {
                string entireText = FileManager.FromFileText(fileName);
                LinesOfText toReturn = new LinesOfText();
                toReturn.Lines.AddRange(entireText.Split('\n'));
                return toReturn;
            }
        }
    }

If you're following along, create a new class in your project called LinesOfText, then paste the text above into the newly-created class.

## Creating the CSV data

Now that we have the runtime type (the LinesOfText class) defined and in our project, we can information to a custom CSV file. To create the CSV file:

1.  Open Glue
2.  Select the Content-\>"Additional Content"-\>New Content CSV..." menu item
3.  Enter the name LinesOfTextContent. Typically you would call the CSV to indicate the library or game that is associated with the content types.
4.  Click OK

Next we'll add information to the new CSV:

1.  Open the newly-created CSV file in a spreadsheet program (such as Excel or OpenOffice Calc)
2.  Add data to the following columns:

|                         |                                                           |                                           |           |                                                                            |
|-------------------------|-----------------------------------------------------------|-------------------------------------------|-----------|----------------------------------------------------------------------------|
| FriendlyName (required) | QualifiedRuntimeTypeName                                  | QualifiedSaveTypeName                     | Extension | CustomLoadMethod                                                           |
| LineOfText (.lin)       | QualifiedType = ProjectNamespace.RuntimeTypes.LinesOfText | ProjectNamespace.RuntimeTypes.LinesOfText | lin       | {THIS} = ProjectNamespace.RuntimeTypes.LinesOfText.FromFile("{FILE_NAME}") |

The CSV file contains many fields which can be used to customize the way Glue interacts with your file and runtime types, but the list above is the minimum requirement for loading a custom file type. In other words, **we don't cover all available columns in this tutorial,** just the necessary ones. The columns are listed together in the table above to keep the example smaller, but they may be spaced out in the CSV. Let's look at the individual columns to understand what they mean.

## FriendlyName (required)

The "FriendlyName (required)" column specifies the name of the file type as it appears in the new file window's drop down. It is marked as "(required)" because each entry can contain multiple values for some of the add methods (which we don't cover in this tutorial). The most common format is to list the runtime class name along with its extension in parenthesis. In our case: "LineOfText (.lin)"

## QualifiedRuntimeTypeName

The QualifiedRuntimeTypeName column specifies the name of the runtime object that is created when the file is loaded. This is the type of the member that will be added to the Screen or Entity that contains the class. The name must be fully-qualified as to avoid conflicts with same-named types in different namespaces, and to enable Glue to add instances to generated code without generating compile errors. The reason "QualifiedType = " must be prefixed is because as of September 10, 2012 Glue supports platform-specific runtime types. We won't cover how to use that functionality in this tutorial.

## QualifiedSaveTypeName

The QualifiedSaveTypeName is the name of the class that is responsible for loading the file from its file format and creating an instance of the runtime object. In our case we simply use the same class (LinesOfText) as both the "Save" object as well as the runtime object, so the two types are the same. Some types (like Scene) have separate "Save" objcts (like SceneSave).

## Extension

The extension tells Glue which extensions to associate to the runtime type. This is used when creating new files, when adding existing files, and if multiple types use the same extension, to allow the user to specify the type. In our case the extension is "lin".

## CustomLoadMethod

This is the line of code (or multiple lines of code) which Glue will use to instantiate the runtime object. In this case two parts of the line are replaced. {THIS} is replaced by the name of the instance that is being created, and {FILE_NAME} is replaced by the file name to load.

## Adding a .lin file to your project

Once you have created/modified the content CSV file, you will need to restart Glue. After Glue starts, you can add a .lin file to your project as follows:

1.  Create a Screen or Entity to hold the new file
2.  Right-click on Files and select "Add File"-\>"New File"
3.  The drop-down under "Select the file type:" should include an entry for the .lin file type. Select "LineOfText (.lin)"
4.  Click OK

**How does Glue make new files?** Since Glue does not understand the structure of custom files, it will create an empty file with the given extension. Many applications will automatically open up when you create a file with extensions that they handle, so this is often desirable behavior.

## Accessing the LineOfTextFile object in code

Once a file has been added to your Screen or Entity it is immediately available in code. The instance added to code will match the name of the object in Glue - which by default will be LineOfTextFile. For example, to access each line of text in the loaded file, you could add the following code to the custom code of your Screen/Entity:

    foreach(string s in LineOfTextFile.Lines)
    {
       // do something with the line
    }

**File members are static:**By default files be static when added to Screens and Entities. Keep this in mind if typing "this" before the "LineOfTextFile".
