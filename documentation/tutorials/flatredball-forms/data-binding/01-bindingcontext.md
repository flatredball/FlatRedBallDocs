## Introduction

The BindingContext property is used for all data binding. This tutorial introduces the BindingContext property and creates a simple example using BindingContext to control the UI.

## Example Screen

For this tutorial we will create a Gum screen which contains the following:

-   Points Display
-   Health Bar
-   Button for awarding points
-   Button for taking damage
-   Button for healing

Normally the actions performed by the buttons listed above would occur through regular game logic (such as collision) but we will use buttons for the sake of simplicity. The specifics of the visuals do not matter, so your screen may look like the following:

![](/media/2020-08-img_5f2ac2ffa2a12.png)

A few details in the screen above are important:

-   The three buttons are FlatRedBall.Forms Button objects. In other words, the three buttons are created in Gum using components which implement the Button behavior. The most common of these is ButtonStandard.

    ![](/media/2023-08-img_64d11c2da310a.png)

-   The HealthBar (ColoredRectangle) is contained within a HealthContainer (Container) using the Percent Width Units

-   Each object in the screen is descriptively named. This will make data binding easier.

-   The screen is called GameScreenGum. This is the default Gum Screen name for a FlatRedBall Screen called GameScreen. If you have created a game with a GameScreen using the wizard, you will also have a GameScreenGum

    ![](/media/2022-01-img_61d634c5ae081.png)

## Creating a ViewModel

The first step in binding to your UI is to create a ViewModel object. ViewModel objects contain all of the properties which you would want to control on your UI programmatically. For the screen above, we will control the following properties:

-   The string displayed by the PointsTextInstance
-   The string displayed by the HealthTextInstance
-   The width of the HealthBar

The ViewModel class should implement the INotifyPropertyChanged interface. Fortunately, FlatRedBall provides a convenient class for this. View models are plain C# classes that are created in Visual Studio. We recommend creating a ViewModels folder in your project, but you can organize them however you like. The following code is an example of what the ViewModel class might look like:

    using FlatRedBall.Forms.MVVM;

    namespace MvvmProject.ViewModels
    {
        class GameScreenViewModel : ViewModel
        {
            public int Score
            {
                get => Get<int>();
                set => Set(value);
            }

            [DependsOn(nameof(Score))]
            public string ScoreDisplay => $"Points: {Score:N0}";

            public int MaxHealth
            {
                get => Get<int>();
                set => Set(value);
            }

            public int CurrentHealth
            {
                get => Get<int>();
                set => Set(value);
            }

            [DependsOn(nameof(CurrentHealth))]
            [DependsOn(nameof(MaxHealth))]
            public string HealthDisplay => $"{CurrentHealth}/{MaxHealth}";

            [DependsOn(nameof(CurrentHealth))]
            [DependsOn(nameof(MaxHealth))]
            // Add a check to make sure we don't divide by 0
            public float HealthPercentage => MaxHealth > 0 
                ? 100 * CurrentHealth / (float) MaxHealth
                : 100;
        }
    }

### ViewModel Base Class

The base ViewModel class provides common functionality for MVVM implementation - specifically the Get and Set functions and the DependsOn attribute. Using the ViewModel base class is not required, and any INotifyPropertyChanged implementation will work.

### Get and Set

The Get and Set functions provide a quick way to implement notification to the UI. When the Set function is called (such as when Score is assigned), internally the Score value will be stored, and any object watching for changes to the Score variable will be notified. Furthermore, any object watching properties which depend on Score will also be notified.

### DependsOn

The DependsOn attribute creates a dependency relationship between the property which has the attribute (such as ScoreDisplay) and the property which it depends on (such as Score). Once this dependency is established, changing the Score property will also notify the UI that ScoreDisplay has changed. Notice that a single property can depend on multiple properties, as is the case of HealthDisplay depending on both CurrentHealth and MaxHealth.

## Assigning BindingContext

The ViewModel establishes which properties can be assigned, and the dependency between properties. Once a ViewModel is created, it can be applied to a Gum object. Note that ViewModels can be applied to Gum objects (GraphicalUiElements) or Forms objects (such as Button). BindingContext assignments *cascade* - you only need to assign the BindingContext at the top level and all children will recursively receive the same BindingContext. Typically this is done at the GumScreen level in each FlatRedBall Screen. Once the BindingContext is assigned, each individual UI property needs to be bound to the corresponding ViewModel property. The following code shows how this type of binding would be done:

    GameScreenViewModel ViewModel;

    void CustomInitialize()
    {
        ViewModel = new GameScreenViewModel();

        GumScreen.BindingContext = ViewModel;

        GumScreen.PointsTextInstance.SetBinding(
            nameof(GumScreen.PointsTextInstance.Text), 
            nameof(ViewModel.ScoreDisplay));

        GumScreen.HealthTextInstance.SetBinding(
            nameof(GumScreen.HealthTextInstance.Text), 
            nameof(ViewModel.HealthDisplay));

        GumScreen.HealthBar.SetBinding(
            nameof(GumScreen.HealthContainer.Width),
            nameof(ViewModel.HealthPercentage));

        ViewModel.Score = 0;
        ViewModel.CurrentHealth = 600;
        ViewModel.MaxHealth = 600;

    }

### ViewModel Creation

The ViewModel object is defined at GameScreen class scope. This is required so that the game can make modifications to the ViewModel after the screen is initialized. FlatRedBall recommends that the ViewModel property is named ViewModel to standardize code across different pages and views.

### Assigning Binding

Once the ViewModel is created, we assign the BindingContext. This assignment tells the GumScreen and everything inside of the GumScreen to use this as its BindingContext. This assignment will also assign the BindingContext on any Forms objects in your screen, so you only need to do this assignment on the GumScreen. Once the BindingContext is assigned, the code establishes individual bindings between UI properties and ViewModel properties. This binding creates an automatic connection between the ViewModel property to the UI property, so that any changes to the ViewModel will automatically update the UI (assuming the Get and Set functions and DependsOn are written correctly in the ViewModel). Notice that the code uses the nameof keyword in C#. The code above could also be written as shown in the following snippet:

        GumScreen.PointsTextInstance.SetBinding(
            "Text" 
            "ScoreDisplay");

While this is less verbose, it produces code which is easier to break. Using nameof provides compile-time checks against referenced properties.

### Setting ViewModel Properties

Once the binding is set up, assigning properties on the ViewModel will automatically update the UI. For example, the values above initialize the score and health as shown in the following screenshot:

![](/media/2022-01-img_61d6411c3f082.png)

## Updating ViewModel Properties

The ViewModel properties can be updated at any time. Doing so automatically updates the bound UI. For example, the following code can be used to modify the properties in response to button clicks:

    void CustomInitialize()
    {
        ...
        Forms.AwardPointsButton.Click += (not, used) => ViewModel.Score += 50;
        Forms.HealButton.Click += (not, used) => ViewModel.CurrentHealth = ViewModel.MaxHealth;
        Forms.TakeDamageButton.Click += (not, used) =>
        {
            ViewModel.CurrentHealth = Math.Max(0, ViewModel.CurrentHealth - 25);
        };
    }

[![](/wp-content/uploads/2020/08/05_18-21-02.gif)](/wp-content/uploads/2020/08/05_18-21-02.gif) Notice that the click events on the buttons do not directly access any UI elements - only the properties on the ViewModel. This makes it much easier to maintain the UI and to continue to add dependencies.  
