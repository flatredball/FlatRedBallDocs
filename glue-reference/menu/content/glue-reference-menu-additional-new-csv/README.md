# glue-reference-menu-additional-new-csv

### Introduction

CSV files are used by Glue to control which file types are available, and to tell Glue how to generate code to load them and create instances in code. Standard FlatRedBall types (such as Scene and AnimationChainList) are represented in a CSV file which is stored in the following location: **Global content types:**

```
<Glue EXE Location>/Content/ContentTypes.csv
```

**Project-specific types:**

```
<.GLUX folder>/GlueSettings/ProjectSpecificContent.csv
```

Glue allows for the creation of additional CSVs which can define how to load and generate code for custom content types. The New Content CSV menu option creates a new CSV file which Glue will automatically load on startup (Glue must be restarted for new or changed files to be used).

### Creating a new Csv

To create a new CSV file:

1. Select the Content->"Additional Content"->"New Content CSV..." menu option
2. Enter the name of the CSV to add. Since Glue can support any number of CSVs we recommend creating new CSVs for categories of objects rather than continually appending to existing CSVs.
3. Select whether you would like this new CSV to apply to all projects or only your current project. This will impact the location of where the CSV is saved.
4. An explorer window will appear displaying the newly created CSV (along with any other existing CSVs)

### Subsections

1. [Simple Line of Text Tutorial](../../../../../../frb/docs/index.php)
2. [Runtime Object Charateristics](../../../../../../frb/docs/index.php)
3. [Creating Runtime Objects](../../../../../../frb/docs/index.php)
