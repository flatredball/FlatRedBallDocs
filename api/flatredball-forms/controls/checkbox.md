# checkbox

### Introduction

CheckBox is a component which can be used to represent a bool value (true or false) at runtime. 

<figure><img src="../../../../media/2017-12-2017-12-13_07-13-04.gif" alt=""><figcaption></figcaption></figure>



### Layout Requirements

The CheckBox control has no requirements – an empty container is sufficient. [![](../../../../media/2017-12-img_5a485e78076db.png)](../../../../media/2017-12-img_5a485e78076db.png)

### TextInstance

The CheckBox control can optionally include a Text instance named **TextInstance**. Setting the CheckBox control’s **Text** property changes the **TextInstance’s** displayed string.

![](../../../../media/2017-12-img_5a49250c06a00.png)

### IsChecked

A nullable bool indicating whether the CheckBox is checked. Note that the value is a bool? , but the current implementation of FlatRedBall.Forms does not support the \*indeterminate \*value (a value of null ). IsChecked can be read from the control or can be explicitly set on the control as shown in the following example:

```lang:c#
checkbox.IsChecked = true;
```

### CheckBox Events

CheckBox provides events for when it is checked and unchecked as shown in the following example:

```lang:c#
void CustomInitialize()
{
    var checkbox = TutorialScreenGum
        .GetGraphicalUiElementByName("CheckBoxInstance")
        .FormsControlAsObject as CheckBox;

    checkbox.Checked += HandleCheckboxChecked;
    checkbox.Unchecked += HandleCheckboxUnchecked;
}

private void HandleCheckboxChecked(object sender, EventArgs e)
{
    // Perform checked-related logic
}

private void HandleCheckboxUnchecked(object sender, EventArgs e)
{
    // Perform unchecked-related logic
}
```

CheckBox also exposes the more general Click event which can be used to handle any click regardless of IsChecked state, as shown in the following example:

```lang:c#
void CustomInitialize()
{
    var checkbox = TutorialScreenGum
        .GetGraphicalUiElementByName("CheckBoxInstance")
        .FormsControlAsObject as CheckBox;

    checkbox.Click += HanleCheckboxClick;
}

private void HanleCheckboxClick(object sender, EventArgs e)
{
    // Perform click-related logic
}
```

&#x20;
