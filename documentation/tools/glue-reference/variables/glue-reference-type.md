## Introduction

The "Type" property on a variable defines what kind of data the variable can hold. For example, the "string" type would be used for variables which should hold words and sentences, "float" and "int" may be used for variables which should hold numbers, and the "bool" value is useful for variables which old true or false values.

## How to set Type

The type of the variable depends on whether the variable is an exposed, tunneled, or "new" variable:

-   If the variable is an exposed variable, then the type of the variable is set by the given element. For example, the X variable on Entities will always be a "float" type.
-   If the variable is a tunneled variable, then the type is defined by the variable being tunneled to. It is possible for a tunneled variable to convert the type to a new type.
-   If the variable is a new variable, then the type of the variable is defined by the new variable window.

## Available types

Variable types fall into one of three categories:

1.  Primitive types (int, float, string, bool)
2.  Non-primitive types used in tunneled variables (such as Color in a Circle)
3.  Project-specific types (types defined in spreadsheet files)

The default value for any variable of a primitive type can be set in Glue. Some non-primitive types can be set in Glue. Project specific types can (at the time of this writing) only be set in code.
