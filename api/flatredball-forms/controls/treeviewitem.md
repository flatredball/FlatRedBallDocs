# TreeViewItem

### Introduction

TreeViewItem is a selectable control used in the TreeView. TreeViewItem instances can be manually instantiated just like any control, or may be instantiated internally by the TreeView control.

### Layout Requirements

The TreeViewItem requires:

* An object named \*\*InnerPanelInstance \*\*of any type (typically a Container)

![](../../../.gitbook/assets/2018-07-img\_5b54f169e076a.png)

Typically the InnerPanelInstance has the following characteristics:

* Height units depending on children
* Stacks children vertically

### ToggleButtonInstance and ListBoxItemInstance

TreeViewItem controls can optionally include:

* An object named ToggleButtonInstance which implements the Toggle behavior
* An object named ListBoxItemInstance which implements the ListBoxItem behavior

If available, the ListBoxItemInstance is used to display selection, hover, and the backing data. If available, the ToggleButtonInstance is used to display whether the tree view item is expanded, and to allow the user to expand/collapse the TreeViewItem.

![](../../../.gitbook/assets/2018-07-img\_5b57f6fc53610.png)

### Customizing TreeViewItem

By default FlatRedBall.Forms will have a standard implementation for a TreeViewItem (this is added to Gum projects through the Gum plugin in Glue). FlatRedBall.Forms provides a number of ways to customize TreeViewItems.

#### Modifying Default TreeViewItem

Of course, the easiest way to customize TreeViewItems is to open the Gum project and modify the existing TreeViewItem, which is located in the DefaultForms folder.

![](../../../.gitbook/assets/2018-09-img\_5ba6b9e189dcb.png)

The standard TreeViewItem implementation includes all of the necessary components and characteristics to be used in FlatRedBall.Forms.

#### Creating a New Gum Component

Game projects can contain custom TreeViewItems, and can even contain different types of TreeViewItems for use in different situations. As shown above, custom TreeViewItems only need an InnerPanelInstance, but can include a toggle button to control collapsing/expanding and a ListBoxItemInstance for selection. For example, the following Component called **QuestCategory** is used to contain related quests.

![](../../../.gitbook/assets/2018-09-img\_5ba6bdbb007fc.png)

The Gum plugin will attempt to generate code for this type, but you can force the association between your custom type and the TreeViewItem in code. For example, the following code associates the **QuestCategory** control with the **TreeViewItem** forms control: Once a new TreeViewItem control has been created it can be used in code in a number of ways (see the next section).

### Selecting the TreeViewItem Type

The TreeViewItem added to a TreeView or added as a child of an existing TreeViewItem can be specified in a project-wide or very specific way.

#### Constructing a TreeViewItem

The most direct way to add a TreeViewItem to a TreeView or as a child of an existing TreeViewItem is to construct it and add it directly, as shown in the following code:

```lang:c#
// The CustomTreeViewItem may have its association
// set up through DefaultFormsComponents, or a Visual
// could be passed to the constructor.
var childTreeViewItem = new CustomTreeViewItem(); 
treeView.Items.Add(childTreeViewItem);
```

#### Automatic TreeViewItem Construction

The previous section shows how to add a TreeViewItem directly to a TreeView or another TreeView Item. If an object which is not a TreeViewItem is added to the Items list, the TreeView or TreeViewItem will attempt to construct a TreeViewItem internally. The order for determining which type of Gum object to construct is as follows:

1. Does the TreeView or TreeViewItem have its TreeViewItemGumType property set? If so, use that type.
2. Does the FrameworkElement.DefaultFormsComponents contain an entry for TreeViewItem? If so, use that type.
3. If none of the conditions above are true, and the TreeViewItem is being added as a child of another TreeViewItem, use the parent's type.

By default the visual will displayed by a FlatRedBall.Forms.Controls.TreeViewItem instance. This can be changed by setting the TreeView or parent TreeViewItem's TreeViewItemFormsType.
