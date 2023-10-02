# how-to-create-components-in-code

### Introduction

Gum components can be instantiated either by adding them to Screens in Gum, or in code. This guide discusses how to fully create a component in code.

### Code Example

The following steps can be used to instantiate a component in code:

1. Call the constructor
2. Call AddToManagers, optionally passing a layer for the component

For example, a component named Button in Gum would generate a class called ButtonRuntime. The following code would instantiate a ButtonRuntime:

```
ButtonRuntime instance = new ButtonRuntime();
instance.AddToManagers();
```

Of course, if adding a new object in code, it must be cleaned up. Therefore you will need to keep track of the object and remove it from managers in the Glue screen's CustomDestroy  method. For example, more complete code might look like the following snippet:

```lang:c#
// At the Glue screen level:
ButtonRuntime buttonInstance;

private void CustomInitialize()
{
    buttonInstance= new ButtonRuntime();
    buttonInstance.AddToManagers();
}

...

private void CustomDestroy()
{
    buttonInstance.RemoveFromManagers();
}
```

If adding a new instance as a child of another component, you do not need to call AddToManagers . See the section below for more information.

#### Adding a new instance as a child

The following code can be used to create a new item and add it to a parent as a child. Notice that the child (listItem ) does not have its AddToManagers  method called. It does not need to be called if the parent is already added to managers.:

```lang:c#
var listItem = new ListItem();
listItem.Parent = listContainerInstance;
```

Adding an instance to a Layer For information on adding a Gum runtime instance to a layer, see the [MoveToFrbLayer page](../../api/gum-runtime-api/gum-wireframe-graphicaluielement/movetofrblayer.md).   &#x20;
