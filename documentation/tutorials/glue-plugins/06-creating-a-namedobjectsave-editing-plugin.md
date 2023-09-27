## Introduction

A common plugin type is one that can modify NamedObjectSave instances. Thee types of plugins exist throughout Glue. For example, the Collision tab is a plugin which allows modifying NamedObjectSave instances which are collision relationships.

![](/media/2023-04-img_644745cc39879.png)

This tutorial shows how to create a plugin which can display and modify custom properties on a NamedObjectSave.

## Creating a Plugin

The first step is to create a new plugin. This tutorial skips these steps since earlier plugins explain how to create a new plugin. This tutorial uses a plugin called ExampleNamedObjectPlugin. The class name will follow the convention of prepending the word "Main", creating a class called MainExampleNamedObjectPlugin.

    [Export(typeof(PluginBase))]
    internal class MainExampleNamedObjectPlugin : PluginBase
    {
        public override string FriendlyName => "Example Named Object Plugin";

        public override void StartUp()
        {
        }
    }

## Plugin Classes

This Plugin contains the following classes:

-   ExampleView - a WPF view which lets the user view and edit properties on the selected NamedObjectSave
-   ExampleViewModel - the ViewModel which binds to ExampleView using standard MVVM. It inherits from PropertyListContainerViewModel which provides automatic saving of properties to disk.
-   MainExampleNamedObjectPlugin - this plugin is responsible for creating the view and viewmodel, and deciding when to show the view

### ExampleView

The ExampleView defines the UI for editing the properties on the selected NamedObjectSave. It contains a checkbox to edit a boolean property and a text box to edit a string property. The following is the XAML for this view:

        
    <UserControl x:Class="OfficialPlugins.ExampleNamedObjectPlugin.ExampleView"
     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
     xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
     xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
     xmlns:local="clr-namespace:OfficialPlugins.ExampleNamedObjectPlugin"
     mc:Ignorable="d" 
     d:DesignHeight="450" d:DesignWidth="800">
      <StackPanel>
        <CheckBox IsChecked="{Binding BoolProperty}">Example Bool Property</CheckBox>
        <StackPanel Orientation="Horizontal">
          <Label>String Property:</Label>
          <TextBox Text="{Binding StringProperty}" Width="150"></TextBox>
        </StackPanel>
      </StackPanel>
    </UserControl>

The preview for this view should look like the following image:

![](/media/2023-04-img_64474930d5649.png)

Note that this view expects a ViewModel with properties BoolProperty and StringProperty.

### ExampleViewModel

The ExampleViewModel should include the two properties mentioned above. If the plugin inherits from the PropertyListContainerViewModel class, it will provide the following functionality:

-   Automatic notification of property changes
-   Setting the property on the underlying NamedObjectSave
-   Automatic saving of the NamedObjectSave to disk

The syntax for using the PropertyListContainerViewModel is similar to using the built-in FlatRedBall ViewModel class.

    internal class ExampleViewModel : PropertyListContainerViewModel
    {
        [SyncedProperty]
        public string StringProperty
        {
            get => Get();
            set => SetAndPersist(value);
        }

        [SyncedProperty]
        public bool BoolProperty
        {
            get => Get();
            set => SetAndPersist(value);
        }
    }

### MainExampleNamedObjectPlugin

The main plugin class will respond to a selected tree node and decide whether it should create the view. Plugins can create views and viewmodels when first starting up, or they can do so lazily - only when needed. The following implementation shows how to create the view and viewmodel lazily:

    [Export(typeof(PluginBase))]
    public class MainExampleNamedObjectPlugin : PluginBase
    {
        public override string FriendlyName => "Example Named Object Plugin";

        ExampleViewModel ViewModel;
        PluginTab tab;

        public override void StartUp()
        {
            this.ReactToItemSelectHandler += HandleItemSelected;
        }

        private void HandleItemSelected(ITreeNode selectedTreeNode)
        {
            if(selectedTreeNode?.Tag is NamedObjectSave namedObjectSave)
            {
                // Let's show this only if the user selects a circle:
                var shouldShowUi =
                    namedObjectSave?.GetAssetTypeInfo() == AvailableAssetTypes.CommonAtis.Circle;

                if(shouldShowUi)
                {
                    if(ViewModel == null)
                    {
                        CreateViewAndViewModel();
                    }
                    ViewModel.GlueObject = namedObjectSave;
                    ViewModel.UpdateFromGlueObject();

                    tab.Show();

                }
                else
                {
                    tab.Hide();
                }
            }
        }

        private void CreateViewAndViewModel()
        {
            ViewModel = new ExampleViewModel();
            var view = new ExampleView();
            view.DataContext = ViewModel;
            tab = this.CreateTab(view, "Example Plugin");
        }
    }

The example above uses the ViewModel's null status to determine if the view and viewmodel have been created. If ViewModel is null, then CreateViewAndViewModel is called which performs a one-time initialization of the view and viewmodel. Assigning the ViewModel's GlueObject automatically associates the namedObjectSave with the ViewModel, resulting in its properties being used to populate StringProperty and BoolProperty - the two properties with the SyncedProperty attributes. Setting these properties through the bound UI automatically updates the JSON for the entity, as shown in the following gif: [![](/wp-content/uploads/2023/04/24_21-50-32.gif.md)](/wp-content/uploads/2023/04/24_21-50-32.gif.md) No additional work is needed to persist the properties to disk. Whenever the values are assigned, they are automatically saved to disk. If Glue is closed and re-opened, the values will be loaded from the Entity's JSON file and automatically displayed in the UI.  
