## Introduction

The DependsOnAttribute class is used to define dependencies between properties on a view model. The DependsOnAttribute is used heavily when creating ViewModels for FlatRedBall.Forms objects, and it appears in all but the simplest of ViewModels. For an introduction into the MVVM pattern in FlatRedBall.Forms, see the [Data Binding tutorials](/documentation/tutorials/flatredball-forms/data-binding.md).

## Simple DependsOn Usage

The DependsOnAttribute (also referred to as DependsOn since C# allows the omission of the Attribute suffix) is used to indicate that one property depends on another. This attribute ultimately results in the property with the DependsOn attribute broadcasting that has changed whenever the property in the DependsOn definition changes. In the simplest (and most common) case, this requires two properties, one of which uses the Get and Set functions. For example, the following code shows how to create two properties:

-   Score - a numeric value which is the logic can directly assign or read when performing game logic.
-   ScoreDisplay - a string property used to display the score in the UI, usually through binding.

The following code shows a simple ViewModel which uses DependsOn:

    class GameScreenViewModel : ViewModel
    {
        public int Score
        {
            get => Get<int>();
            set => Set(value);
        }

        [DependsOn(nameof(Score))]
        public string ScoreDisplay => $"Points: {Score:N0}";
    }

In this case, the ScoreDisplay property will broadcast that it has changed whenever the Score value changes. Practically speaking, this means that any UI object can bind to the ScoreDisplay property and that UI will be updated whenever Score changes. Notice that the DependsOn is usually used with the nameof keyword. While this is not necessary, it reduces the chances of error (spelling a property incorrectly), enables automatic refactoring, and can help catch compile errors. Although not recommended, it is possible to use constant string values instead of the nameof keyword:

    class GameScreenViewModel : ViewModel
    {
        public int Score
        {
            get => Get<int>();
            set => Set(value);
        }

        // Not recommended, but it is possible to type strings here:
        [DependsOn("Score")]
        public string ScoreDisplay => $"Points: {Score:N0}";
    }

## Multiple Properties Using DependsOn

DependsOn can be used to create multiple properties which depend on a single value. For example, a Health value could be used as the root value for multiple properties which depend on it. The following shows how to create multiple properties which depend on one:

    class PlayerViewModel : ViewModel
    {
        public decimal Health
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [DependsOn(nameof(Health))]
        public string HealthDisplay => Health.ToString("N0");

        [DependsOn(nameof(Health))]
        public bool IsDead => Health <= 0;
    }

## Multiple DependsOn on a Single Property

A single property can depend on multiple properties. In this case, the property will change if either of its root properties change. For example, a health display could depend on both CurrentHealth and MaxHealth as shown in the following code:

    class PlayerViewModel : ViewModel
    {
      public decimal CurrentHealth
      {
        get => Get<decimal>();
        set => Set(value);
      }
      public decimal MaxHealth
      {
        get => Get<decimal>();
        set => Set(value);
      }

      [DependsOn(nameof(CurrentHealth))]
      [DependsOn(nameof(MaxHealth))]
      public string HealthDisplay => $"{CurrentHealth}/{MaxHealth}";
    }

 
