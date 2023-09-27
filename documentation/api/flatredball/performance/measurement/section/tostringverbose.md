## Introduction

ToStringVerbose will return information about the Section that the function is being called on. This can be used to get information about the Section in a human-readable format similar to XML.

For an example on how to use ToStringVerbose in combination with Glue, see [this page](/frb/docs/index.php?title=FlatRedballXna:Tutorials:Identifying_Screen_Creation_Performance_Issues.md "FlatRedballXna:Tutorials:Identifying Screen Creation Performance Issues").

## depth parameter

You can use the depth parameter to limit how much information is being displayed. The following shows how this works:

    mSection.ToStringVerbose(1);

![ToStringVerboseDepth1.PNG](/media/migrated_media-ToStringVerboseDepth1.PNG)

    mSection.ToStringVerbose(2);

![ToStringVerboseDepth2.PNG](/media/migrated_media-ToStringVerboseDepth2.PNG)

    mSection.ToStringVerbose(3);

![ToStringVerboseDepth3.PNG](/media/migrated_media-ToStringVerboseDepth3.PNG)
