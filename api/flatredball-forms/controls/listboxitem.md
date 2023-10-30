# listboxitem

### Introduction

ListBoxItem is a selectable control used in the ListBox control or controls which contain a ListBox (such as ComboBox). ListBoxItem instances can be manually instantiated just like any control, or may be instantiated internally by the ListBox control. 

<figure><img src="../../../../media/2017-12-2017-12-13\_17-52-13.gif" alt=""><figcaption></figcaption></figure>



### Layout Requirements

The ListBoxItem control has no requirements – an empty container is sufficient. [![](../../../../media/2017-12-img\_5a485e78076db.png)](../../../../media/2017-12-img\_5a485e78076db.png)

### TextInstance

The ListBoxItem control can optionally include a Text instance named **TextInstance**. Setting the ListBoxItem control’s **Text** property changes the **TextInstance’s** displayed string. [![](../../../../media/2017-12-img\_5a485fa592a56.png)](../../../../media/2017-12-img\_5a485fa592a56.png)

### Creating ListBoxItems

ListBoxItem instances are typically created and added to a ListBox. For more information and examples on working with ListBoxItem instances in a ListBox, see the [ListBox](listbox.md) page.

### Reading Data From BindingContext

By default ListBoxItem instances have a single Text object to display information. Some games may require each ListBoxItem to display more than just text. For example, a list box used to display items that a player can buy may display the item name, item icon, and item price. The easiest way to display custom data in a ListBoxItem is to use data binding. Customizing controls doesn't require the creation of any new classes or inheritance - the binding can be performed in the Gum runtime's custom code. For this example, we will use a Gum item which has a Text object for the item description and another for the item cost, as shown in the following image:

![](../../../../media/2020-07-img\_5eff335943eb6.png)

Unlike our normal ListBoxItem, this item contains two text objects.

![](../../../../media/2020-07-img\_5eff33ad55915.png)

Also, note that this Gum item should the ListBoxItemBehavior added as well, as shown in the following image:

![](../../../../media/2020-07-img\_5eff33e926841.png)

Now that we have this set up, we need to do the following things:

1. Assign the ListBox.ListBoxItemGumType to use this ListBoxItem
2. Add our data to the ListBox for the store
3. Bind the visuals to the items in the StoreListBoxItemRuntime.cs file

#### Assigning ListBox.ListBoxItemGumType

First we need to assign the ListBoxGumType to the ListBox. This tells the ListBox which type of Gum visual to use for each item. Assuming you already have access to your ListBox forms object, your code should look similar to the following snippet:

```lang:c#
listBox.ListBoxItemGumType = typeof(GumRuntimes.StoreListBoxItemRuntime);
```

#### Add Data to the ListBox

Next we add items to our ListBox. The simplest way is to add items to the ListBox.Items property. These items can be any class because in the next step we'll write code to use that class to update the visuals on the ListBoxItem. For example, if your game defines inventory in a CSV file, you may have a dictionary of inventory items. Similarly, if your game defines states in an entity, then each state is also available in a dictionary. We'll assume that the data is stored in a CSV called GlobalContent.StoreData.

![](../../../../media/2020-07-img\_5eff418ebc5de.png)

We can access the values in the CSV in a foreach loop to fill the listBox.

```lang:c#
foreach(var item in GlobalContent.StoreData.Values)
{
    listBox.Items.Add(item);
}
```

At this point the ListBox should fill up with the data from the CSV, but it will not display any information about the store items - we'll set that up next.

![](../../../../media/2020-07-img\_5eff389a38df7.png)

#### Binding the Visuals

Next we can bind our visuals to display information from our StoreData. Binding is performed using the SetBinding function which exists on every Gum and Forms object. In this case we will bind the Text property on our two Text objects to the Name and Cost properties on our StoreData items. To do this, we will add the following code to our **StoreListBoxItemRuntime.cs** (the custom code file created for our Gum object).

```lang:c#
partial void CustomInitialize () 
{
    ItemDescriptionTextInstance.SetBinding(
        // The first value is the property on the ListBoxItem
        nameof(ItemDescriptionTextInstance.Text),

        // The second value is the name of the value on the data
        nameof(StoreData.Name));

    ItemCostTextInstance.SetBinding(
        nameof(ItemCostTextInstance.Text),
        nameof(StoreData.Cost));
}
```

Now our UI displays the values in the CSV.

![](../../../../media/2020-07-img\_5eff4122cc9a5.png)

### Inheriting from ListBoxItem

Above we covered how to use data binding to update the visuals on a ListBoxItem. Another option is to create a derived ListBoxItem and handling the visuals manually. This approach is useful if you are not comfortable with using binding.   For this example consider a racing game with a list of cars. We can create a CarListItem in Gum to display information about cars in a player's garage.

![](../../../../media/2017-12-img\_5a31ee2533d00.png)Notice that this list item does not have a single Text but instead four - for displaying the year, make and model, horsepower, and weight. This shows that list items can contain anything to display the necessary information or decoration.

For this example we'll use a data class called CarData, defined as shown in the following code:

```lang:c#
public class CarData
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Horsepower { get; set; }
    public int Weight { get; set; }
}
```

We need to create logic to assign the values from CarData instances to the text values in the CarListItem Gum component. For this we can create a new class which inherits from ListBoxItem, as shown in the following code:

```lang:c#
public class CarListBoxItem : FlatRedBall.Forms.Controls.ListBoxItem
{
    public override void UpdateToObject(object dataObject)
    {
        var asCarData = dataObject as DataTypes.CarData;

        if(asCarData == null)
        {
            throw new NotImplementedException("The CarListboxItem is only meant to displlay CarData");
        }

        (Visual.GetGraphicalUiElementByName("YearText") as GumRuntimes.TextRuntime).Text =
            asCarData.Year.ToString();

        (Visual.GetGraphicalUiElementByName("MakeModelText") as GumRuntimes.TextRuntime).Text =
            $"{asCarData.Make} {asCarData.Model}";

        (Visual.GetGraphicalUiElementByName("HPText") as GumRuntimes.TextRuntime).Text =
            $"{asCarData.Horsepower.ToString()} HP";

        (Visual.GetGraphicalUiElementByName("WeightText") as GumRuntimes.TextRuntime).Text =
            $"{asCarData.Weight.ToString()} lbs";

    }
}
```

Finally, we can get our ListBox instance and assign the desired Gum and Forms types, as shown in the following code:

```lang:c#
var listBox = TutorialScreenGum
    .GetGraphicalUiElementByName("ListBoxInstance")
    .FormsControlAsObject as ListBox;

listBox.ListBoxItemGumType = typeof(GumRuntimes.CarListItemRuntime);
listBox.ListBoxItemFormsType = typeof(Controls.CarListBoxItem);
```

Now if we add any objects that are not ListBoxItems, the ListBox will internally use the CarListBoxItem control and assign a CarListItemRuntime Gum runtime for its visual. For example, the following code could be used to populate the list box:

```lang:c#
// These cars could come from anywhere - CSV, XML, JSON, etc...
List<DataTypes.CarData> carDatas = new List<DataTypes.CarData>();
carDatas.Add(new DataTypes.CarData
    { Year = 1997, Make = "Ford", Model = "Taurus", Horsepower = 140, Weight = 3300 });
carDatas.Add(new DataTypes.CarData 
    { Year = 2002, Make = "Suzuki", Model = "Aeiro", Horsepower = 130, Weight = 2700 });
carDatas.Add(new DataTypes.CarData
    { Year = 2009, Make = "Pontiac", Model = "G6 GT", Horsepower = 200, Weight = 3400 });

foreach(var carData in carDatas)
{
    listBox.Items.Add(carData);
}
```

This creates a list of our cars.

![](../../../../media/2017-12-img\_5a31f90545230.png)
