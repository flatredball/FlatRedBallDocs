# customvariable

### Introduction

The CustomVariable object is a variable directly contained inside of a Screen or entity. CustomVariables are not contained in NamedObjectSaves, but if a NamedObjectSave is an Entity, then the Entity's CustomVariables define which variables are available on an instance. CustomVariables can be one of the following three types:

* Exposed variables - These are variables which already exist on the base type of the object, such as the X, Y, and Z values on entities
* Tunneled variables - These are variables which exist on an object contained within the Screen or Entity, such as the Radius of a Circle contained within an entity
* Custom (new) variables - These are variables added to a GlueElement which are not tied to any exiting variable on the GlueElement, or on any object within the GlueElement, such as the Health of a Player entity.

These three types match the three options provided by the New Variable window.

![](../../../media/2023-04-img\_6445f9ab03d5c.png)

When the user adds a new variable to a GlueElement, a new CustomVariable instance is added to the GlueElement. Plugins can modify existing CustomVariables or add new CustomVariable instances to a GlueElement.

### Common Properties

The following properties are commonly accessed and modified in Glue:

* Name - the Name as displayed in Glue and in code. For example X, Health, or IsInvulnerable
* Type - the type of the variable, such as "float" or "int". The type informs Glue as to which UI to use when displaying the variable.
* DefaultValue - the default value of the variable. If unchanged, this value is assigned in code on all instances of the GlueElement. This is typed, so if the variable is a float, then the value assigned should be a float and not a string representation of the value
* CustomGetForcedOptionsFunc - A delegate which optionally defines which values can be set. This can be used to restrict options in the Glue UI. This is not serialized so plugins must assign this value every time a project is loaded.

&#x20; &#x20;
