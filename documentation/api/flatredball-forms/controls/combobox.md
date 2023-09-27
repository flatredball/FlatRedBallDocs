## Introduction

The ComboBox control (also often referred to as a drop-down control) allows the user to select a value from a list of options. It expands and collapses in response to user activity. [![](/wp-content/uploads/2017/12/2017-12-13_07-47-12.gif)](/wp-content/uploads/2017/12/2017-12-13_07-47-12.gif)

## Layout Requirements

The ComboBox control requires:

-   An Text named **TextInstance**
-   An object named **ListBoxInstance** which implements ListBoxBehavior (is a ListBox)

![](/media/2018-01-img_5a4b0fd700175.png)

## ListBoxInstance Details

The ListBoxInstance is the part of the combo box which appears when the user clicks on the main body. The ListBoxInstance hides when the user selects an item in the list box, clicks on the combo box main body, or clicks outside of the combo box. The combo box gum component can have the list box default to visible, but the ComboBox controll will control its visibility at runtime. The ListBoxInstance is typically positioned outside of the bounds of the ComboBox. The ComboBox control does not control the size of the list box when it is visible (when the ComboBox is expanded) - this is controlled by the Gum component.

## Similarities with ListBox

The ComboBox class provides a similar interface to the ListBox class.  This includes the following properties:

-   Items
-   SelectedIndex
-   SelectedItem
-   ListBoxItemGumType
-   ListBoxItemFormsType

Furthermore, the ComboBox class provides the following event:

-   SelectionChanged

For more information on working with these properties and events, see the ListBox page: http://flatredball.com/documentation/api/flatredball-forms/controls/listbox/

## ListBoxItemGumType

The ListBoxItemGumType property is used to automatically instantiate [ListBoxItem](/documentation/api/flatredball-forms/controls/listboxitem.md) instances as needed whenever new objects are added to the Items property. This property is not needed if adding ListBoxItem instances to Items. The ListBoxItemGumType should be a Gum runtime type which implements the ListBoxItem behavior. The following example shows how to use the ListBoxItemType. property:

``` lang:c#
void CustomInitialize()
{
    var comboBox = TutorialScreenGum
        .GetGraphicalUiElementByName("ComboBoxInstance")
        .FormsControlAsObject as ComboBox;

    // This code assumes ListBoxItemGumRuntime is a Gum runtime with the
    // ListBoxItem behavior
    comboBox.ListBoxItemGumType = typeof(GumRuntimes.ListBoxItemRuntime);

    comboBox.Items.Add("Nintendo");
    comboBox.Items.Add("Super Nintendo");
    comboBox.Items.Add("Nintendo 64");
    comboBox.Items.Add("GameCube");
}
```

For more information on using the ListBoxItemType, see the [ListBox](/documentation/api/flatredball-forms/controls/listbox.md) and [ListBoxItem](/documentation/api/flatredball-forms/controls/listboxitem.md) pages.

## Items

The ComboBox's Items collection exposes the Items collection of the Listbox which appears when the ComboBox expands. For information on working with Items, see the [ListBox](/documentation/api/flatredball-forms/controls/listbox.md) page.

## 
