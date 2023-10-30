# 03-templates

### Introduction

The ListBox type includes the ability to customize individual items using templates. Two properties exist on the ListBox for customization:

* VisualTemplate - this allows the usage of any Gum object as an item in a list box
* FrameworkTemplate - this allows the usage of a FrameworkElement as an item in a list box. Note that the type of FrameworkElement must inherit from ListBoxItem

The following screenshot shows a list box which displays levels with images and a check box.

![](../../../../media/2022-11-img_637e23a9e9252.png)

Although the appearance of each item in the ListBox is different from the default appearance, the ListBox itself is still a standard ListBox with a custom VisualTemplate. VisualTemplates can be used for any type of modification to the ListBoxItem. Common examples include:

* Adding additional Text instances for more information, such as the name and price of an item as separate Text instances
* Adding images or icons to an object, such as a preview image in a level selection list box
* Adding additional controls to a list box, such as a check box for multi-selection

#### VisualTemplate vs. FrameworkTemplate

Most of the time games will use a VisualTemplate and do not need to use a FrameworkTemplate. Therefore, this tutorial will cover the usage of VisualTemplate which should cover almost all cases. FrameworkTemplate can be used for rare situations where the same visual is used for list box items which have different functionality. Most of the time this different behavior can be achieved with a VisualTemplate and data binding.

### Creating a CustomListBoxItem in Gum

By default the ListBox creates one ListBoxItem for every item in its Items property. The ListBoxItem is defined in the Gum project under the Controls folder as shown in the following screenshot:

![](../../../../media/2023-08-img_64d1b98838807.png)

The first step in replacing this ListBoxItem in our ListBox is to create a new component in Gum. This component can be structured however you want. There are no requirements for what it must contain, how it must be named, or what states it must contain. If you would like your custom list box item to be selectable, then you will want to implement the ListBoxBehavior. This is optional, and if you do not intend to have list box selection behavior, then you do not need to implement this behavior. This tutorial will not provide step-by-step instructions for creating a custom CustomListBoxItem, so feel free to structure this component however you like. However, if you would like to follow along , the code in this tutorial will assume two Text objects:

* MainTextInstance
* SubtextInstance

![](../../../../media/2023-08-img_64d1bb0594b14.png)

&#x20;

### Using CustomListBoxItem

To use the CustomListBoxItem, first you will need a screen which contains a ListBox. For example, the following screenshot shows a single ListBox in the MainMenuGum screen.

![](../../../../media/2023-08-img_64d1bb63c3069.png)

Once this ListBox is added, the following code can be used to populate the ListBoxInstance, including using the new CustomListBoxItem as the template:

```
void CustomInitialize()
{
    var listBox = Forms.ListBoxInstance;
    listBox.VisualTemplate = new FlatRedBall.Forms.VisualTemplate(() => new CustomListBoxItemRuntime());
    for (int i = 0; i < 10; i++)
    {
        listBox.Items.Add(i);
    }
}
```

This code produces the following screenshot when the application runs:

![](../../../../media/2023-08-img_64d1bbee8ad3d.png)

The ListBox contains ten (10) instances of the CustomListBoxItemRuntime Gum component - one for each integer added to the listBox.Items. the VisualTemplate assignment tells the ListBox that each Item should result in a new CustomListBoxItemRuntime being created.

### Binding to Item ViewModels

The code above shows how to create instances of the CustomListBoxItemRuntime component based on the contents of the ListBox.Items collection. Next we'll look at how to customize each instance based on the specific item it represents. First, we'll change the code so that the listBox.Items contains instances of ViewModel-inheriting objects rather than a list of integers. By creating a custom ViewModel, we can control the properties displayed by each item in the ListBox.

```
class ListBoxItemViewModel : ViewModel
{
    public string MainText
    {
        get => Get();
        set => Set(value);
    }
    public string Subtext
    {
        get => Get();
        set => Set(value);
    }
}

class MainMenuViewModel : ViewModel
{
    public ObservableCollection Items
    {
        get => Get<ObservableCollection>();
        private set => Set(value);
    }

    public MainMenuViewModel()
    {
        Items = 
            new ObservableCollection();
    }
}


public partial class MainMenu
{

    void CustomInitialize()
    {
        var listBox = Forms.ListBoxInstance;
        
        var viewModel = new MainMenuViewModel();


        for(int i = 0; i < 10; i++) 
        { 
                var item = new ListBoxItemViewModel(); 
                item.MainText = "Item " + i; item.Subtext = "Subtext " + i; 
                viewModel.Items.Add(item); 
        } 
        listBox.VisualTemplate = new FlatRedBall.Forms.VisualTemplate(() => new CustomListBoxItemRuntime());
        Forms.BindingContext = viewModel;
        listBox.SetBinding(nameof(listBox.Items), nameof(viewModel.Items));

    }
    ...
```

&#x20; If we execute the code, our application should still look the same. We are still adding 10 instances, but this time we are adding them to a ViewModel, and binding the listBox's Items to the ViewModel's Items property. Finally, we can modify our CustomListBoxItemRuntime to bind its Text objects to the appropriate ViewModel properties. To do this:

1. Open CustomListBoxItemRuntime.cs in Visual Studio
2. Modify the code as shown in the following snippet:

&#x20;

```
public partial class CustomListBoxItemRuntime
{
    partial void CustomInitialize () 
    {
        MainTextInstance.SetBinding(
            nameof(MainTextInstance.Text), 
            nameof(ListBoxItemViewModel.MainText));
        SubtextInstance.SetBinding(
            nameof(SubtextInstance.Text), 
            nameof(ListBoxItemViewModel.Subtext));
    }
}
```

Now if we run our application, each item will display the text specified in each ViewModel.

![](../../../../media/2023-08-img_64d1be5cbbf49.png)

&#x20;
