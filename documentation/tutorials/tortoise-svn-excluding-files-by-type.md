## Introduction

There are many file types which should not be included in your project. In some cases these files are organized by folder, so simply excluding a folder from the project (such as the bin folder) is sufficient. Other times the files that you want to exclude are mixed in with files that you want to include. For example, if you are using Glue you will want to exclude generated code files.

## Excluding files by type

To exclude files by type:

1.  Right-click anywhere in a Windows Explorer window
2.  Select "Tortoise SVN"-\>"Settings"
3.  Verify that the "General" category is selected
4.  Enter the different file patterns to exclude separated by spaces![SvnGlobalIgnorePattern.png](/media/migrated_media-SvnGlobalIgnorePattern.png)

Here is an example of what a Global Ignore Pattern may look like:

    *.o *.lo *.la *.al .libs *.so *.so.[0-9]* *.a *.pyc Thumbs.db
    *.pyo *.rej *~ #*# .#* .*.swp .DS_Store *.Generated.cs *.Generated.*.cs 
    *.suo *. *.metaproj *.metaproj.tmp bin obj *.userprefs

Note that the ignore pattern above is split by multiple lines. When pasting this in the Tortoise SVN text box, make sure to remove all newlines or else Tortoise SVN won't pick up all of the ignores.
