## Introduction

Many FlatRedBall content file types (such as .scnx and .achx) reference other files (such as .png files for textures). This means that sharing files can be difficult - especially if the file being shared has a large number of referenced files which exist in multiple directories. The "Create Zip Package" command in Glue can simplify file sharing through the creation of a standard ZIP file which can also be imported through the "Add File" right-click option.

## Creating a Zip Package

To create a zip package:

1.  Right-click on any file
2.  Select "Create Zip Package" ![CreateZipPackage.png](/media/migrated_media-CreateZipPackage.png)

If the zip package was successfully created, you will see a confirmation popup:![CreateZipPackageSuccess.png](/media/migrated_media-CreateZipPackageSuccess.png) If the creation fails, you will also be notified. Failure usually happens because the file being packaged references other files which are not in the same directory or a subdirectory of the file being package. Note the following characteristics of a zipped file:

-   It is a proper ZIP file, meaning it can be unzipped and investigated by any regular unzipper or in code by unzipping libraries
-   It will be located in the same location as the packaged file
-   It will have an extension suggesting the type of file. This usually means the same file type, only with a 'z' instead of 'x' as the last letter (.scnx -\> .scnz, .emix -\> .emiz). The 'z' represents "zip" as opposed to "xml".

## Adding zipped files

Glue understands the zipped format of exported files. Therefore, you can simply right-click and select "Add File"-\>"Existing Files" then select the zipped package file. Glue will unzip the file and add it as a regular file.
