# Using CSVs Tutorial

### Introducing CSV

CSV is a powerful file format which allows for the creation of data in your game. Using CSVs is convenient because you can use any spreadsheet editor to create CSVs. FlatRedBall automatically generates classes for your CSVs (also known as data-first), and these CSVs are loaded automatically in generated code. The CSV format is typically used to define data using a custom format such:

* Stats and coefficients, such as damage, price, and weight of weapons in an RPG
* Dialog and scripting data

This article will show you how to create instances of objects based off of information in a CSV. CSV stands for "comma separated values". In its raw format it is simply a text file which contains values separated by commas and new lines. For example, the contents of a CSV might appear as follows:

```
X, Y, Z
2, 13, 0
44, 2, 0
0, 22, 0
```

If you were to create a new file, enter that information, and change the extension to a .csv, you'd have a valid CSV file. However, the true power of CSV comes from their standardization. CSV files are most commonly used as a very simple spreadsheet format. Therefore, CSV files can be opened and created by virtually every spreadsheet program including Microsoft Excel, Open Office, and Google Docs.

**Note:** Need a spreadsheet app? You can get Open Office for free at this website. [www.openoffice.org](http://www.openoffice.org/)

Not only can you edit CSV files in a spreadsheet, but FlatRedBall also has code to simplify working with CSV files. Furthermore, when you use CSV files in Glue, as we're about to do, Glue will automatically generate the code necessary to load CSV files into your project into a very easy-to-use list. To find out how, keep reading:

### Adding a CSV file

The first step in creating your custom data is to add a CSV file to your project. To do this:

* Expand your Screens item.
* Expand your GameScreen item.
* Right-click on your File item under GameScreen.
* Select "Add File"->"New File"
* Select "Spreadsheet (.csv)" as the file type and enter "EnemyLocationFile" as the file's name![GlueAddCsvFile.png](../../../media/migrated\_media-GlueAddCsvFile.png)

Now your project has a new CSV file. The next step is to enter the information we want to use in our game in the CSV file.

### Editing the CSV

The CSV file can be edited just like any other file in Glue by double-clicking it. This will open the CSV file with the default editor. If you would like to override the default file association that can also be done through the Settings->"File Assocation" menu item. The images of the CSV contents will show Microsoft Excel 2007; however, as mentioned above other spreadsheet applications can be used. Initially the CSV file contains four Entries![DefaultSpreadsheet.png](../../../media/migrated\_media-DefaultSpreadsheet.png) These default values simply provide an example of how data can exist in a spreadsheet. CSV files have a fairly simple format. The first row defines the properties that will be used for each instance. The default CSV file has two properties:

1. A property called StringMember. This member doesn't define a type, so it defaults to string.
2. A property called TypedMember. This member defines a type in parentheses which is float.

As suggested above, if a property does not define its type, then Glue will default the type as string. However, if you want to make the data a specific type (such as float or bool), then you need to explicitly set the type next to the member name in the same cell. What follows is any number of rows - each one defining an instance of your custom data type. The csv currently has just one instance. This instance has its StringMember set to "StringMemberValue" and its TypedMember set to 100. Let's change the data so that it can be used to specify starting locations for Enemies. To do this:

1. Change the first member from StringMember to "X (float)"
2. Change the second member from "TypedMember (float)" to "Y (float)". At this point you could continue to add more variables but for this example we only need X and Y.
3. Change the value of the first column in the second row from "StringValueMember" to 10.
4. Change the value of the second column from 100 to 10.![GlueChangedSpreadsheetValues.png](../../../media/migrated\_media-GlueChangedSpreadsheetValues.png)

At this point we've specified that we are going to create a new data type that has X and Y variables. We've also created one instance with the values of 10, 10. Additional rows can be added to the spreadsheet to add more instances. Also, additional properties can be added as new columns in the spreadsheet. Simply changing and saving the CSV file will result in the data being updated automatically. To make things more interesting, I'll add one more row to the spreadsheet file.![GlueExtraRowInSpreadsheet.png](../../../media/migrated\_media-GlueExtraRowInSpreadsheet.png)

### The flexibility of the CSV file format

One very important thing to remember regarding CSV files is that they can be used for **any type of data**. In this particular case we used CSV files just to define the number of enemies and their individual locations. You could easily add additional information to the CSV file, such as the direction that enemies are facing or the amount of gold the player earns when defeating the enemies. You can also use CSV files for information not necessarily related to Entities. For example, you could define point values for completing various missions in a game. The CSV file can be used to organize and consolidate information that could normally sit in Screen and Entity variables in Glue, but may be easier to edit and compare when used in a spreadsheet. Another useful benefit of using spreadsheets is that values in one cell can included references to other cells and formulas. The CSV file format does not maintain these references and formulas; however, you can save your files as a native format for the application you are working in, then "export" the file to CSV to get the raw values for your game.

### How to use the CSV file in your game

Once you save your CSV file, Glue performs actions:

1. It creates/updates a code file which defines the format of each instance in your CSV
2. It creates the code to automatically load your CSV file in the Screen or Entity that it is a part of

Since CSV files can define any information, there is no standardized way of converting this data into Entities; however, despite its flexibility the code needed to create Entities from the CSV information is very straight-forward. Since we added the CSV file to our "GameScreen", then this is where we need to add the code to process it. To do this:

1. Open your project in Visual Studio
2. In Visual Studio, expand your Screens folder![GlueExpandScreensInVisualStudio.png](../../../media/migrated\_media-GlueExpandScreensInVisualStudio.png)
3. Double-click "GameScreen.cs" to open the code file in the code view window![GlueDoubleClickScreenInVS.png](../../../media/migrated\_media-GlueDoubleClickScreenInVS.png)
4. Scroll down in the file until you find a function called "CustomInitialize". This is a function which gets called when the Screen is first created. This is where you want to perform any one-time game logic such as setting the initial placement of your enemies.![CustomInitializeFunction.png](../../../media/migrated\_media-CustomInitializeFunction.png)
5. Add the following code inside of your CustomInitialize function:

```
 foreach (DataTypes.EnemyLocation enemyLocation in EnemyLocationFile)
 {
     Entities.Enemy enemy = new GlueTutorials.Entities.Enemy(ContentManagerName);
     enemy.X = enemyLocation.X;
     enemy.Y = enemyLocation.Y;
     Enemies.Add(enemy);
 }
```

There are a few things to note in the code above:

* We used the "EnemyLocationFile" variable which is the same name as the class you've created.
* We used the data type "EnemyLocation" which is a class automatically generated for you by Glue. It is the same name as the EnemyLocationFile except it removes the "File" off of the end. It is recommended that you have "File" at the end of your file names so Glue can perform this modification to differentiate between your file and your individual data type.
* We created a new Enemy, then set its X and Y positions using the EnemyLocation's X and Y values.
* Finally we add the the newly-created Enemy to the Enemies list.

![GlueEnemiesInGame.png](../../../media/migrated\_media-GlueEnemiesInGame.png)

### Additional Information

This tutorial covers the basics of using CSVs. There's a lot of functionality in CSVs and special syntax that you can use to achieve things like Lists of primitives inside each instance that is deserialized. For more information, check out the [CsvFileManager page](../../../frb/docs/index.php).

### Conclusion

Now you have worked through the process of adding a list of Entities to your Screen and using CSV files to populate that list, you can create games which have an undefined or large number of Entities. You've also learned how to use CSV files to create custom data quickly through Glue.
