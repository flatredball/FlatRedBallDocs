# treeview

### Introduction

The TreeView control is a scrollable view which can contain a hierarchy of TreeViewItems. The TreeView is conceptually similar to the [ListBox](listbox.md) control, but allows items to be embedded within other items. 

<figure><img src="../../../media/2018-07-2018-07-21\_22-18-06.gif" alt=""><figcaption></figcaption></figure>



### Layout Requirements

The TreeView control requires:

* An object named **VerticalScrollBarInstance** which implements ScrollBarBehavior (is a ScrollBar)
* An object named **InnerPanelInstance** of any type (typically a Container)
* An object named **ClipContainerInstance** of any type (typically a Container with **ClipsChildren** set to true)

[![](../../../media/2017-12-img\_5a465ac0d252b.png)](../../../media/2017-12-img\_5a465ac0d252b.png) The requirements for the TreeView are identical to the requirements for the [ScrollViewer](scrollviewer.md) and [ListBox](listbox.md) controls.

### Items

The Items property represents the top-level data displayed in the TreeView. Items can contain regular types (such as strings, ints, or classes representing data in your game such as car data in a racing game) or TreeViewItem instances. When an object is added to the Items collection the TreeView will automatically update its visuals to display the newly-added object. If the newly-added object is a regular (non TreeViewItem) type, then the TreeView will construct a new TreeViewItem internally. If the newly-added object is already a TreeViewItem, then the TreeView will display the TreeViewItem as-is. Note that at the time of this writing, adding TreeViewItems is required to create a hierarchy.

### Items.Add

The following code shows how to create a hierarchy of objects. Notice that the code constructs a TreeViewItem, then uses the reference to add additional objects as sub-items of the TreeViewItem.

```lang:c#
var treeView = new TreeView();

// Tree view item reference is needed to 
// add to its Items
var treeViewItem = new TreeViewItem();
treeViewItem.UpdateToObject("Monsters");

// The individual monster types are added directly
// since we don't need to add sub-items to them
// in this example.
treeViewItem.Items.Add("Dragon");
treeViewItem.Items.Add("Slime");
treeViewItem.Items.Add("Bat");
treeViewItem.Items.Add("Ghost");

treeView.Items.Add(treeViewItem);

treeView.Visual.AddToManagers();
```



<figure><img src="../../../media/2018-07-2018-07-22\_11-08-33.gif" alt=""><figcaption></figcaption></figure>

 Note that the TreeView's Items property only contains the top-level item. In the example above, the treeView.Items property only contains a single entry - Monster. The specific monster types are contained in the Items property of the parent TreeViewItem.

### Customizing TreeViewItems

For information on creating a custom TreeViewItem, see the [TreeViewItem documentation](treeviewitem.md).

### Selection

#### SelectedObject

Returns the selected object, or null if nothing is selected. This returns the object as it was originally added to the TreeView or its parent TreeViewItem.

#### SelectedItem

SelectedItem returns the selected TreeViewItem, or null if one isn't selected. This property may return a nested item. Note that even if a non-TreeViewItem object is added to a TreeView, the SelectedItem for that added object will still be a TreeView. **SelectNextVisible/SelectPreviousVisible** Selects the next or previous visible object sequentially. This may select an object that above or below the hierarchy. This can be used to implement selecting items using a keyboard (up or down arrows) or game pad (up or down on dpad or analog stick). If no object is selected, these methods will throw an InvalidOperationException. The following example code could be used to move the selection using the arrow keys:

```lang:c#
if(treeView.SelectedItem != null)
{
    var keyboard = FlatRedBall.Input.InputManager.Keyboard;

    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up))
    {
        treeView.SelectPreviousVisible();
    }
    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down))
    {
        treeView.SelectNextVisible();
    }
}
```



<figure><img src="../../../media/2018-07-2018-07-22\_11-35-01.gif" alt=""><figcaption></figcaption></figure>


