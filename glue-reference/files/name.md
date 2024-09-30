# Name

### Introduction

A file's name represents its qualified location relative to the project's Content folder. By default, newly-created files will be added to a folder specific to the container Screen, Entity, or Gloabl Content Files. However, a file can exist outside of the default folder, so long as it is in the project's Content folder. For example, the following file is located in the Enemy entity, but its location on disk is **\<Project Content Folder>/Characters/Enemy\_Shooter.achx**:

![](../../.gitbook/assets/2019-07-img\_5d1b7eb97b57e.png)

### Renaming Files

Glue allows renaming of a file by changing the file's **Name** property. Renaming the file will perform the following actions:

1. Change the name of the file in the Glue project
2. Change the name of the file in the Visual Studio project (including all synced projects)
3. Change the name of the file on disk

Note that if the file is referenced by another file, Glue may not be able to update the reference. For example, changing a .PNG file which is referenced by a .TMX file may result in errors due to the .TMX file still referencing the old .PNG.

<figure><img src="../../.gitbook/assets/2019-07-2019-07-02_09-58-49.gif" alt=""><figcaption></figcaption></figure>
