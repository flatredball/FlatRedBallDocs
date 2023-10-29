# glue-reference-export-entity

### Introduction

Screens and Entities can be exported through Glue [and later imported](../../../../frb/docs/index.php). An exported Screen/Entity can be easily transferred to other projects, sent to other developers, or uploaded to [GlueVault.com](http://www.gluevault.com) to be shared with the community.

### Exporting a Screen/Entity

Once you have a Screen/Entity that you are ready to export, you can:

1. Right-click on the Screen/Entity and select "Export Screen"/"Export Entity"![ExportScreen.png](../../../../media/migrated\_media-ExportScreen.png)
2. Navigate to the folder where you would like to save the exported element and click OK
3. An Explorer window will appear showing you your exported file

You can share the exported Screen/Entity on [GlueVault.com](http://www.gluevault.com)

### What does an Exported Screen/Entity contain?

Exported Screens and Entities create .scrz (Screen zip) or .entz (Entity zip) files, respectively. These files are standard zip files which can be unzipped with any unzipper. Of course, Glue understands these files as well so there is no reason to unzip these files if you plan on using them in Glue. Exported Screens and Entities contain the following:

* An XML file containing the information set in Glue
* A C# code file containing custom code
* All referenced files (such as .scnx or .shcx) and any files that the referenced files include
