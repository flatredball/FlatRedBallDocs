# Tunneling Category Variables

### Introduction

State categories automatically create variables in Screens and Entities through generated code. These generated variables can also be accessed in the FRB editor so they can be set on instances, or to assign change events.

### Example - Tunneling a Category

For this example, consider an Entity named StateEntity which has a SizeCategory with three states: Small, Medium, and Large.

<figure><img src="../../.gitbook/assets/image (229).png" alt=""><figcaption><p>Entity with a SizeCategory</p></figcaption></figure>

This entity generates a variable called CurrentSizeCategoryState which can be accessed in code, as shown in the following code block:

```csharp
private void CustomInitialize()
{
    this.CurrentSizeCategoryState = SizeCategory.Large;
}
```

The CurrentSizeCategoryState can be tunneled on the entity which can be useful in a number of situations:

1. To set a default state for the entity
2. To set the state per-instance in the FRB Editor
3. To create events which is raised whenever a state is set to perform custom logic

To tunnel into a variable, drag+drop the category on the Variables folder.

<figure><img src="../../.gitbook/assets/31_10 28 17.gif" alt=""><figcaption><p>Tunneling to the CurrentSizeCategoryState</p></figcaption></figure>

The tunneled variable now behaves like any other variable. For example, an event can be added to the variable which is raised whenever the SizeCategory changes.

<figure><img src="../../.gitbook/assets/31_10 31 34.gif" alt=""><figcaption><p>Adding an Event for tunneled category variables</p></figcaption></figure>
