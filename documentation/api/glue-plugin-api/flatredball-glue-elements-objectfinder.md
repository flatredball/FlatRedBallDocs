## Introduction

The ObjectFinder is a globally-available object which can help return instances of various elements in the currently loaded Glue project. The ObjectFinder can help you find:

-   EnitySaves
-   ScreenSaves
-   ReferencedFileSaves

## Common Usage

Since the ObjectFinder is a singleton it can be accessed anywhere. The following code shows how to get an IElement instance from the currently loaded glue project:

    IElement element = ObjectFinder.Self.GetIElement("Entities\\EntityName");
