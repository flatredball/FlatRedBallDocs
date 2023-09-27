## Introduction

CreatesDictionary is a property that tells Glue whether to deserialize a given CSV file to either a List or Dictionary. If you are accessing entries within a CSV according to some common key (such as the Name of an enemy type), then you should use the CreatesDictionary property to simplify access. The CreatesDictionary property is a property that only appears on CSV files, or TXT files which are treated as CSVs. You will be given the option to create a Dictionary or List when first adding new CSV files through Glue: ![SpreadsheetDictionaryOrList.PNG](/media/migrated_media-SpreadsheetDictionaryOrList.PNG)

## "required" keyword

Glue must know which property you want to use as the key for the dictionary. Glue does this by looking for the "required" keyword in the header of your CSV. For example, the following CSV marks the "Name" as required: ![CsvWithRequiredName.PNG](/media/migrated_media-CsvWithRequiredName.PNG)

**Name is common** The most common key for data is "Name". Unless you have a reason to not use this, consider using "Name" as your required property.

If you have a CSV without a "required" field, then Glue will not be able to create a Dictionary out of the CSV. Just like any other CSV, once you have saved this file, Glue will generate a class to match the CSV.

## Setting CreatesDictionary" to True

The next step is to set the CSV file's CreateDictionary property to True in Glue: ![CreatesDictionaryProperty.png](/media/migrated_media-CreatesDictionaryProperty.png)

## Accessing the Dictionary in code

Now that you have created a CSV that has CreatesDictionary set to true, you can access the file in code and get instances using the Name property: ![DictionaryInCode.png](/media/migrated_media-DictionaryInCode.png)

## Concerns about using strings as keys

You may be wondering if it is a good idea to access objects using strings as the key. For example, let's consider the following line:

    int damage = GlobalContent.TestCsv["Imp"].Damage;

As you may have realized, this can be an unsafe line of code. What if, for example, the CSV changes so that it no longer contains the "Imp" object? Then that code would compile, and the error would only be discovered if that particular piece of code was executed. In other words, there is a risk of having hidden bugs associated to this line of code. First, we should mention that the reason the code above uses the hardcoded "Imp" value is to show the connection between code and the CSV. In final game code this is not good practice. Fortunately this type of code is usually not necessary. Let's look at the two most common situations where values are retrieved:

### Values in Lists

It is common to use values form CSVs in Lists. For example, let's say that the TestCsv used above is being used in a screen where the user picks which enemies to take into battle. Your code may look something like this:

    foreach(var value in GlobalContent.TestCsv.Values)
    {
       CreateButtonFor(value);
    }

This would dynamically loop through the list and create UI elements for each item in the CSV. If an item is added or removed, your code would automatically adjust to this and only show which values are appropriately.

**Dictionary order is undefined**The order of entries in a dictionary is not always the same as the order of entries in a CSV. For more information on retrieving the order, see [this page](/frb/docs/index.php?title=Glue:Reference:Files:CSV:OrderedList.md "Glue:Reference:Files:CSV:OrderedList").

### Accessing values directly

In some cases you may need to access values directly. This can happen if:

-   You need to set a default value for something in code
-   You need to create a script in code, such as defining which enemies appear in a particular level

Fortunately the generated code creates const string values to allow you to access values in a compile-time-protected way. For example, the code above to access the imp could be more-safely done as follows:

    int damage = GlobalContent.TestCsv[TestCsv.Imp].Damage;

The TestCsv class has one constant for each entry in the CSV, so the code above will work without any other code.
