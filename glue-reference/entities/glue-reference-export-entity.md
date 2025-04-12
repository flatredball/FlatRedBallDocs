# Export Entity

### Introduction

Screens and Entities can be exported through the FlatRedBall Editor to be imported later. For importing, see the [Importing Entity page](glue-reference-import-entity.md).

### Exporting a Screen/Entity

Once you have a Screen/Entity that you are ready to export, you can:

1.  Right-click on the Screen/Entity and select **Export Screen** or **Export Entity**

    <figure><img src="../../.gitbook/assets/12_09 44 07.png" alt=""><figcaption><p>Export Entity right click option</p></figcaption></figure>
2. Navigate to the folder where you would like to save the exported element and click OK
3. An Explorer window appears showing you your exported file

### What does an Exported Screen/Entity contain?

Exported Screens and Entities create .scrz (Screen zip) or .entz (Entity zip) files, respectively. These files are standard zip files which can be unzipped with any unzipper. Exported Screens and Entities contain the following:

* An XML file containing the information set in Glue
* A C# code file containing custom code
* All referenced files (such as .pngs) and any files that the referenced files include, recursively
