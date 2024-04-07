# ListBox Templates

### Introduction

The ListBox type includes the ability to customize individual items using templates. Two properties exist on the ListBox for customization:

* VisualTemplate - this allows the usage of any Gum object as an item in a list box
* FrameworkTemplate - this allows the usage of a FrameworkElement as an item in a list box. Note that the type of FrameworkElement must inherit from ListBoxItem

The following screenshot shows an example of a customized ListBoxItem. It contains a list box which displays levels with images and a check box.

![Customized ListBoxItems used for level select in Battlecrypt Bombers](../../../media/2022-11-img\_637e23a9e9252.png)

Although the appearance of each item in the ListBox is different from the default appearance, the ListBox itself is still a standard ListBox with a custom VisualTemplate. VisualTemplates can be used for any type of modification to the ListBoxItem. Common examples include:

* Adding additional Text instances for more information, such as the name and price of an item as separate Text instances
* Adding images or icons to an object, such as a preview image in a level selection list box
* Adding additional controls to a list box, such as a check box for multi-selection

#### VisualTemplate vs. FrameworkTemplate

Most of the time games only need a VisualTemplate and do not need to use a FrameworkTemplate. Therefore, this tutorial convers the usage of VisualTemplate which should cover almost all cases. FrameworkTemplate can be used for rare situations where the same visual is used for list box items which have different functionality. Most of the time this different behavior can be achieved with a VisualTemplate and data binding.

### Creating a CustomListBoxItem in Gum

By default the ListBox creates one ListBoxItem for every instance in its Items property. The ListBoxItem is defined in the Gum project under the Controls folder as shown in the following screenshot:

![](../../../media/2023-08-img\_64d1b98838807.png)

The first step in replacing this ListBoxItem in our ListBox is to create a new component in Gum. The easiest way to do this is to copy/paste the existing ListBoxItem as a starting point. You can create a copy by using the CTRL+C, CTRL+V hotkeys or by right-clicking on the component and selecting the Duplicate option.

<figure><img src="../../../.gitbook/assets/02_06 51 15.gif" alt=""><figcaption><p>Creating a duplicate ListBoxItem</p></figcaption></figure>

This component can be structured however you want. There are no requirements for what it must contain, how it must be named, or what states it must contain. By copying the existing ListBoxItem, we bring over the ability for the ListBox to be selected. Even this is optional, so if you do not want your ListBoxItem to respond to selections visually, you can remove the states or modify them to have no impact on appearance.

For this tutorial we will be creating a new ListBoxItem which has two Text instances:

* InventoryNameTextInstance
* InventoryCountTextInstance

Note that by default ListBoxItems attempt to assign a Text object by the name of TextInstance. By changing our Text names, our new ListBoxItem no longer supports default Text display. If you are creating a new ListBoxItem which is intended to be used as a default ListBoxItem throughout your entire game, you should consider keeping a Text instance with th ename TextInstance. In this case we are creating a ListBoxItem to be used in a specific case so this name isn't required.

<figure><img src="../../../.gitbook/assets/image (1) (1).png" alt=""><figcaption><p>InventoryListBoxItem in Gum</p></figcaption></figure>

### Using the Custom ListBoxItem (InventoryListBoxItem)

To use the newly-created ListBoxItem, first you need a screen with a ListBox. For example, the following screenshot shows a single ListBox in the MainMenuGum screen.

![ListBoxInstance in MainMenuGum](../../../media/2023-08-img\_64d1bb63c3069.png)

Once this ListBox is added, the following code can be used to populate the ListBoxInstance, including using the new InventoryListBoxItem as the template:

```csharp
void CustomInitialize()
{
    var listBox = Forms.ListBoxInstance;
    listBox.VisualTemplate = new FlatRedBall.Forms.VisualTemplate(
        // Gum objects (such as InventoryListBoxItem) create generated
        // types with the name "Runtime" appended.
        () => new InventoryListBoxItemRuntime());
    for (int i = 0; i < 10; i++)
    {
        listBox.Items.Add(i);
    }
}
```

Running the game shows something similar to the following screenshot:

![Custom InventoryListBoxItem in ListBox](<../../../.gitbook/assets/02\_07 01 56.png>)

The ListBox contains ten (10) instances of the InventoryListBoxItemRuntime Gum component - one for each integer added to listBox.Items. The VisualTemplate assignment tells the ListBox that each Item should result in a new InventoryListBoxItemRuntime being created.

### Binding to Item ViewModels

The code above shows how to create instances of the InventoryListBoxItemRuntime component based on the contents of the ListBox.Items collection. This approach is good for testing how a custom ListBoxItem appears in your ListBox, but it won't work for a full game.

Typically each item in a ListBox needs more information than an integer. In the case of inventory, each item in the list box needs at least a name and count.

We'll create a new class which contains this information. We also want to create a class which will notify the ListBoxItem any time a property changes. To make this simpler, FlatRedBall provides a `ViewModel` class which can be used as the base for your custom classes. By using ViewModel, and the Get/Set methods, any changes to properties are automatically broadcasted to UI. In other words, this enables changing a property on the ViewModel-inheriting class, and that updating the UI immediately.

The term "ViewModel" comes from the MVVM pattern which is a common way to display and manage data in C# front ends such as WPF, .NET MAUI, and Avalonia. Classes which inherit from ViewModel are often referred to generally as "view models", and should have the "ViewModel" or "VM" suffix for clarity.

We can create a new ViewModel for our new custom list box items as shown in the following code:

```csharp
public class InventoryItemViewModel : ViewModel
{
    public string InventoryName
    {
        get => Get<string>();
        set => Set(value);
    }
    
    public int InventoryCount
    {
        get => Get<int>();
        set => Set(value);
    }
    
    [DependsOn(nameof(InventoryCount))]
    public string InventoryDisplay => $"x{InventoryCount}";
}
```

For more information on the specific syntax of ViewModels (such as Get/Set and DependsOn), see the [BindingContext Property](01-bindingcontext.md) page.

Each InventoryItemViewModel will correspond to an individual InventoryListBoxItemRuntime. We also need to create a ViewModel for the entire screen. This ViewModel contains a list of InventoryItemViewModels in an ObservableCollection. Our ViewModel for the entire screen should match the name of the screen, so we will create a class called MainScreenViewModel.

```csharp
// Even though we aren't using Get<> and Set (see below) yet, we should
// still inherit from ViewModel so that we have access to these methods if
// we need them as our game grows.
public class MainScreenViewModel : ViewModel
{
    // The Get<> and Set methods aren't used here because we do not intend to ever
    // change the ListBoxItems instance after it has been created. If we did, we would
    // want to use the Get<> and Set syntax    
    public ObservableCollection<InventoryItemViewModel> ListBoxItems { get; private set; }
        = new ObservableCollection<InventoryItemViewModel>();
}
```

Finally we can modify our MainMenu.cs class to use the MainScreenViewModel for its items, as shown in the following code:

```csharp
public partial class MainMenu
{
    // Declare the ViewModel as a member variable so we can access it
    // in CustomActivity:
    MainScreenViewModel viewModel;

    void CustomInitialize()
    {
        var listBox = Forms.ListBoxInstance;
        listBox.VisualTemplate = new FlatRedBall.Forms.VisualTemplate(
            // Gum objects (such as InventoryListBoxItem) create generated
            // types with the name "Runtime" appended.
            () => new InventoryListBoxItemRuntime());

        viewModel = new MainScreenViewModel();
        viewModel.ListBoxItems.Add(new InventoryItemViewModel
        {
            InventoryName = "Iron Ore",
            InventoryCount = 20
        });
        viewModel.ListBoxItems.Add(new InventoryItemViewModel
        {
            InventoryName = "Gold Ore",
            InventoryCount = 5
        });
        viewModel.ListBoxItems.Add(new InventoryItemViewModel
        {
            InventoryName = "Ruby",
            InventoryCount = 2
        });
        viewModel.ListBoxItems.Add(new InventoryItemViewModel
        {
            InventoryName = "Normal Pickaxe",
            InventoryCount = 1
        });

        // Assign the entire screen view model:
        Forms.BindingContext = viewModel;
        // Bind the Items in the ListBox to the Items in the ViewModel:
        listBox.SetBinding(nameof(listBox.Items), nameof(viewModel.ListBoxItems));
    }
    ...
```

If we run our game now, the ListBox shows four items (one for each InventoryItemViewModel instance). Notice that we do not directly add items to the ListBox.Items. Instead, we _bind_ the listBox.Items to the viewModel.ListBoxItems. This results in the ListBox automatically keeping in sync with the ViewModel.

We can observe this behavior by adding code to the MainMenu's CustomActivith to add a new item whenever the space bar is pressed.

```csharp
void CustomActivity(bool firstTimeCalled)
{
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        viewModel.ListBoxItems.Add(new InventoryItemViewModel
        {
            InventoryName = "New Item",
            InventoryCount = 1
        });
    }
}
```

<figure><img src="../../../.gitbook/assets/02_07 26 19.gif" alt=""><figcaption><p>Items added to a ListBox by modifying the ViewModel's ListBoxItems</p></figcaption></figure>

Note that removing items from the view model also results in removal of the matching item in the ListBox.

### Binding InventoryListBoxItem Text

Next we'll update our binding so that the Text instances in our InventoryListBoxItem display the name and count properties from our InventoryItemViewModel. To do this, open InventoryListBoxItemRuntime.cs and modify the contents as shown in the following code.

```csharp
public partial class InventoryListBoxItemRuntime
{
    partial void CustomInitialize () 
    {
        this.InventoryNameTextInstance.SetBinding(
            nameof(InventoryNameTextInstance.Text), 
            nameof(InventoryItemViewModel.InventoryName));

        this.InventoryCountTextInstance.SetBinding(
            nameof(InventoryCountTextInstance.Text), 
            nameof(InventoryItemViewModel.InventoryDisplay));
    }
}
```

Now if we run our application, each item displays the information from each InventoryItemView.

<figure><img src="../../../.gitbook/assets/image (1) (1) (1).png" alt=""><figcaption><p>Inventory items displaying information</p></figcaption></figure>

### Modifying the Selected ViewModel

Next we'll keep track of the selected item. We can do this by creating a new property on the MainScreenViewModel which has&#x20;

```csharp
public class MainScreenViewModel : ViewModel
{
    // The Get<> and Set methods aren't used here because we do not intend to ever
    // change the ListBoxItems instance after it has been created. If we did, we would
    // want to use the Get<> and Set syntax    
    public ObservableCollection<InventoryItemViewModel> ListBoxItems { get; private set; }
        = new ObservableCollection<InventoryItemViewModel>();

    // New: This property will be bound to the selected item in the ListBox
    public InventoryItemViewModel SelectedItem
    {
        get => Get<InventoryItemViewModel>();
        set => Set(value);
    }
}
```

We can bind to the SelectedItem in MainMenu.CustomInitialize. Modify the code to add the "New" code shown here:

```csharp
void CustomInitialize()
{
    var listBox = Forms.ListBoxInstance;
    listBox.VisualTemplate = new FlatRedBall.Forms.VisualTemplate(
        // Gum objects (such as InventoryListBoxItem) create generated
        // types with the name "Runtime" appended.
        () => new InventoryListBoxItemRuntime());

    viewModel = new MainScreenViewModel();
    viewModel.ListBoxItems.Add(new InventoryItemViewModel
    {
        InventoryName = "Iron Ore",
        InventoryCount = 20
    });
    viewModel.ListBoxItems.Add(new InventoryItemViewModel
    {
        InventoryName = "Gold Ore",
        InventoryCount = 5
    });
    viewModel.ListBoxItems.Add(new InventoryItemViewModel
    {
        InventoryName = "Ruby",
        InventoryCount = 2
    });
    viewModel.ListBoxItems.Add(new InventoryItemViewModel
    {
        InventoryName = "Normal Pickaxe",
        InventoryCount = 1
    });

    // Assign the entire screen view model:
    Forms.BindingContext = viewModel;
    // Bind the Items in the ListBox to the Items in the ViewModel:
    listBox.SetBinding(nameof(listBox.Items), nameof(viewModel.ListBoxItems));

    // New: Bind the SelectedObject of the ListBox to the SelectedItem in the ViewModel:
    listBox.SetBinding(nameof(listBox.SelectedObject), nameof(viewModel.SelectedItem));
}
```

Just like all other properties, the SelectedObject/SelectedItem properties stay synced, so we can use the ViewModel's SelectedItem in code. For example, we can modify CustomActivity to increase inventory on the selected item when the Enter key is pressed:

```csharp
void CustomActivity(bool firstTimeCalled)
{
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
    {
        viewModel.ListBoxItems.Add(new InventoryItemViewModel
        {
            InventoryName = "New Item",
            InventoryCount = 1
        });
    }

    // New: Add an item to the selected item's count when Enter is pressed
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Enter))
    {
        if(viewModel.SelectedItem != null)
        {
            viewModel.SelectedItem.InventoryCount++;
        }
    }
}
```

If we run the code, select an item, and press Enter, the inventory count increases.

<figure><img src="../../../.gitbook/assets/02_08 15 13.gif" alt=""><figcaption><p>Increasing inventory by pressing Enter while an item is selected</p></figcaption></figure>

### Conclusion

This tutorial shows how to bind a ListBox and ListBoxItems to view models. Interacting with the view models (adding or removing items, modifying properites on the view models) automatically update the view.
