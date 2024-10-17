# IsShared

### Introduction

The IsShared variable determines whether a given variable is shared among all instances of a given Entity. In code, a variable which is marked as **IsShared** is generated as static. A variable which is marked as IsShared has the following characteristics:

* All instances will always have the same value
* The value can be set or read in code even if no instances have been created, or if no instances are available in the current scope
* The value persists even when a Screen is switched or an instance of the entity is destroyed

### Setting IsShared

To set the IsShared property:

1. Expand the Variables tab on the Entity or Screen which contains the variable
2. Select the variable
3. Click the Properties tab
4. Change IsShared to True or False as desired

![Setting IsShared in the Properties tab](../../.gitbook/assets/2022-05-img\_62704ff8a40ca.png)

### Accessing a IsShared (static) Variable in Code

Once a variable has been marked as IsShared, it can be accessed from anywhere in code through the type. For example, to access the DebuggingVariables ShowTerrainCollision variable in code, the following snippet could be used:

```csharp
if(Entities.DebuggingVariables.ShowTerrainCollision == true)
{
   // do something to show the terrain collision
}
```

### IsShared and CreatesEvent

Variables which have IsShared set to true generate static events. For more information, see the [CreatesEvent](glue-reference-createsevent.md) page.
