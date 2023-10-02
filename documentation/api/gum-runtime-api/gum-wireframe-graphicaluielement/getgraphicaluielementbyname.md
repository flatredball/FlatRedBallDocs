# getgraphicaluielementbyname

### Introduction

GetGraphicalUiElementByName returns the instance of a contained element by name, or null if a matching element isn't found.

### Code Example

The following code can be used to find the "Score" component and disable it from being a clickable UI element:

```
// Assuming the current code has a EntireGumScreen object:
EntireGumScreen.GetGraphicalUiElementByName("Score").Enabled = false;
```

For more information on the Enabled property, see [the IWindow.Enabled page](../../../../frb/docs/index.php).
