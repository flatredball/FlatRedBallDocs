## Introduction

Glue provides very powerful integration with the CSV file format. The CSV file format is a simple text format which is compatible with all major spreadsheet programs (such as Excel, Open Office, and Google Drive). This article discusses why CSVs are so useful.

## CSV editing is easy

CSV editing is very easy to do because it is supported by all major spreadsheet programs. This means that you can edit a CSV in any of these programs and get very clean formatting. By comparison, XML files are usually edited in text programs, and navigating through a large XML file can be difficult.

## CSV files are very compact

The CSV file format is incredibly efficient. CSV files are usually used to contain lists of information (such as stats for different enemies in a game). In this case CSV files are much smaller than equivalent XML files - they're even smaller than JSON files.

## Classes are generated automatically by Glue

Glue will automatically create classes to contain information from CSV files. Typically when you create a file (such as an XML file) you must create a class to "deserialize" the file into. Glue automatically takes care of this for you. You simply create the CSV file and Glue will generate a class that corresponds with the CSV you've created.

## Glue handles the loading (deserialization) for you automatically

If you have a CSV file that is part of your project, not only will Glue create classes to contain the information of the CSV, but it will also load the file into a List or Dictionary for you. This requires no code from you, and Glue uses standard CSV loaders which can even be done asynchronously just like all other file loading in Glue.

## Glue provides consts for accessing entries inside dictionaries

This can make your code much easier to maintain as if a value that is being accessed by code is removed, you will have a compile error. Furthermore, it makes code writing much easier because you have Visual Studio's auto complete (Intellisense) helping you identify valid options.

## CSVs support inheritance inside lists

This is something that is difficult to do with standard XML deserialization in .NET.

## Glue supports CSV editing through plugins

You can edit CSVs in Glue without exiting the application using the [Glue CSV Plugin](http://www.gluevault.com/plug/50-csv-editor-plugin-glue)

## Types defined in CSVs can be used by objects in Glue

Since Glue creates classes from your CSVs, it is aware of those types and allows custom variables to be created of those types. In other words, if you were to create a EnemyStats.csv file, then you could add a new variable to your Enemy entity, and it could be of type EnemyStats. Simply doing this enables your Enemy to have all stats created in a CSV automatically. This is very memory-efficient because multiple instances which use the same variable will share the same instance.

## CSV variables support events

CSV variables are the same as other Glue variables in terms of supporting events when set. This means that custom code can be run according to the type of CSV value set. This code can even be parsed and viewed in real-time in GlueView.
