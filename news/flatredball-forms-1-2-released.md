# flatredball-forms-1-2-released

### Introduction

The latest release of FlatRedBall, Gum, and Gum plugin in Glue includes support for FlatRedBall.Forms version 1.2. This version adds the following functionality:

* New StackPanel control
* New AddChild method for all FrameworkElements (allowing parent/child relationship to be created without accessing the Visual object)
* Support for same-named Gum runtime objects in different folders with the addition of sub-namespaces (see breaking changes below)

### StackPanel

[![](../media/2018-08-2018-08-12\_17-31-35.gif)](../media/2018-08-2018-08-12\_17-31-35.gif) The StackPanel control allows stacking contained children either horizontally or vertically. Note that this functionality is not new, Glue has had stacking available before FlatRedBall.Forms 1.0. The StackPanel simply provides a control similar to the WPF StackPanel to simplify the creation of UI in code using a familiar interface. We can compare how to create a StackPanel in FlatRedBall.Forms 1.2 and compare it to how this would have been done in 1.1.

#### FlatRedBall.Forms 1.2

```lang:c#
var stackPanel = new StackPanel();
stackPanel.Visual.AddToManagers();
// now add 3 buttons
stackPanel.AddChild(new Button());
stackPanel.AddChild(new Button());
stackPanel.AddChild(new Button());
```

#### FlatRedBall.Forms 1.1

```lang:c#
var stackPanel = new UserControl(new InvisibleRenderable());
stackPanel.Visual.AddToManagers();
stackPanel.Visual.ChildrenLayout = ChildrenLayout.TopToBottomStack;
// add 3 buttons
var button = new Button();
button.Parent = stackPanel.Visual;
button = new Button();
button.Parent = stackPanel.Visual;
button = new Button();
button.Parent = stackPanel.Visual;
```

Notice that the AddChild function helps make StackPanels even simpler to work with, as opposed to setting the parent on the desired child - which is both wordy and also confusing. For additional information on the StackPanel control, see the [StackPanel](../documentation/api/flatredball-forms/controls/stackpanel.md) page.

### Folders and Sub-Namespaces

Previously all Gum runtime objects would be added to the project in the same folder and part of the same namespace - YourProjectName.GumRuntimes . The latest version of the Gum plugin for Glue adds controls to namespaces matching the folder structure in Gum. For example, consider a control called **ButtonPanel** which is part of a **ControlGalleryPanels** folder:

![](../media/2018-08-img\_5b70bcd01e71a.png)

The runtime object will be generated to be part of the YourProjectName.GumRuntimes.ControlGalleryPanels  namespace.

![](../media/2018-08-img\_5b70bd46b0f58.png)

This change allows for multiple controls with the same name to be added to a project, as long as they exist in different folders.

### Breaking Changes

Since components now include subfolders in their namespace, existing projects which have components in subfolders may no longer compile until some changes are made.

#### Fixing Partials

Any component with a matching partial will not compile because the partial may still be using the old namespace. To fix this problem:

1. Open the generated code for the given component
2. Copy the namespace
3. Open the custom code file for the given component
4. Paste the namespace

#### Fixing Code References

Any reference to a component which has had its namespace changed must be updated. Of course, generated code should update automatically, but custom code may need to have a qualifying namespace changed, or to have its using statements updated.

#### Fixing Gum References from Files

If you have accessed an object from within a Gum file in Glue, and that type is now in a subfolder, you may have compile errors in your generated code for your Glue Screen/Entity. For example, the following shows a Screen which is referencing two objects:

1. ListBoxInstanceGum
2. StartButtonGum

The components for these two types are in a subfolder:

![](../media/2018-08-img\_5b70f95f94897.png)

As is currently set up, the generated code is referencing the files in the incorrect namespace. Also notice that the initialization code is not generating properly:

![](../media/2018-08-img\_5b70f9ba42719.png)

These errors can be fixed by re-assigning the **SourceName** for the offending objects in Glue: [![](../media/2018-08-2018-08-12\_21-24-30.gif)](../media/2018-08-2018-08-12\_21-24-30.gif) Notice that the types **SourceName** dropdown has the correct type in parenthesis.   &#x20;
