The latest templates and Glue plugin include support for FlatRedBall.Forms 1.1. This version adds the TreeView control, along with the TreeViewItem used within the TreeView control. [![](/wp-content/uploads/2018/07/2018-07-21_22-18-06-1.gif.md)](/wp-content/uploads/2018/07/2018-07-21_22-18-06-1.gif.md)

## Example Code

The latest Glue + Gum plugin includes default implementations for TreeView and TreeViewItem. This means that the TreeView can be created purely in Gum, purely in code, or any combination of the two. For example, the following code creates a TreeView and adds a **Monsters** category, then adds a few monster types embedded under **Monsters**.

``` lang:c#
var treeView = new TreeView();

var treeViewItem = new TreeViewItem();
treeViewItem.UpdateToObject("Monsters");

treeViewItem.Items.Add("Dragon");
treeViewItem.Items.Add("Slime");
treeViewItem.Items.Add("Bat");
treeViewItem.Items.Add("Ghost");

treeView.Items.Add(treeViewItem);

treeView.Visual.AddToManagers();
```

## Additional Improvements

Along with the TreeView control, the latest version of Glue + Gum adds:

-   Added support for font smoothing
-   Improvements to the Layout call, making certain types of changes happen more quickly
-   Glue plugin no longer crashes if standard elements (like Circle) are missing
-   Fixed scroll bars sometimes scrolling outside of their bounds
-   Fixed toggle buttons not defaulting to the unchecked state

## Additional Information

Check out the [TreeView](/documentation/api/flatredball-forms/controls/treeview.md) and [TreeViewItem](/documentation/api/flatredball-forms/controls/treeviewitem.md) pages for additional details.
