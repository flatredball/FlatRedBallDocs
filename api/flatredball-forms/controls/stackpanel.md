# StackPanel

### Introduction

The StackPanel control is a container which can be used to hold children elements which can be stacked either horizontally or vertically.

![](../../../.gitbook/assets/2018-08-img\_5b70b62069463.png)

### Layout Requirements

Unlike other FlatRedBall.Forms controls, the StackPanel does not use a Gum runtime object from the existing project. Rather, the StackLayout is itself an invisible control which can contain other objects. Note that even though the StackLayout doesn't use a component defined in your Gum project, it still has a backing Visual object so it can be added to any other FlatRedBall.Forms object and it has full support for all Gum variables such as position and size.

### Code Example

The following code creates a StackLayout, sets it to be drawn (meaning its children will be drawn), then uses AddChild to add four buttons.

```csharp
var stackPanel = new StackPanel();
stackPanel.Visual.AddToManagers();

stackPanel.AddChild(new Button());
stackPanel.AddChild(new Button());
stackPanel.AddChild(new Button());
stackPanel.AddChild(new Button());
```

Note that the above code creates Button instances using the Button constructor. In a normal project this would instantiate the Buttons using the default Gum visual object as specified on the [DefaultFormsComponents](frameworkelement/defaultformscomponents.md) static property.

### Orientation

The Orientation property sets whether children stack horizontally or vertically. The default value is Orientation.Vertical. The following code shows how to change the orientation to Horizontal.

```csharp
var stackPanel = new StackPanel();
stackPanel.Visual.AddToManagers();
stackPanel.Orientation = Orientation.Horizontal;

stackPanel.AddChild(new Button());
stackPanel.AddChild(new Button());
```

![](../../../.gitbook/assets/2018-08-img\_5b70b85ea9907.png)
