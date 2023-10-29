## Introduction

IElement is the interface implemented by both Screens and Entities. If you are working on code which will apply to both Screens and Entities then your code should use IElement instead of ScreenSave or EntitySave. IElements are often referred to as "elements" in code and documentation.

## Finding Objects

Glue includes extension methods to make working with IElement easier. To use these extension methods, add the following using statements to your project:

    using FlatRedBall.Glue.SaveClasses;

One this using statement is added you can use numerous methods for finding objects. For example, to find a state by name:

    // Assuming elementInstance is a valid IElement instance
    StateSave state = elementInstance.GetState("StateName");

## "Recursive" finding

A recursive find is one which searches up the inheritance tree until an object is found. The following code performs a recursive find for a NamedObject:

    NamedObject namedObject = elementInstance.GetNamedObjectRecursively("ObjectName");

GetNamedObjectRecursively will first search in the calling element first. If an object by the argument name is not found, and if the calling element inherits from another element, then the code will look at the base element. This process will continue until either an object is found, or until there is no base element.
