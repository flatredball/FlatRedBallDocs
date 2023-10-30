# button

### Introduction

Button is a standard clickable object with states for enabled (default), hover, pressed, and disabled. 

<figure><img src="../../../../media/2017-12-2017-12-13_07-05-39.gif" alt=""><figcaption></figcaption></figure>



### Layout Requirements

The Button control has no requirements - an empty container is sufficient.

![](../../../../media/2017-12-img_5a485e78076db.png)

### TextInstance

The Button control can optionally include a Text instance named **TextInstance**. Setting the Button control's **Text** property changes the **TextInstance's** displayed string.

![](../../../../media/2017-12-img_5a485fa592a56.png)

### Code Example

Buttons provide events for Click and Push events. The following code shows how to handle these events on a button obtained from a gum runtime object named **ButtonInstance**:

```lang:c#
void CustomInitialize()
{

    var button = TutorialScreenGum
        .GetGraphicalUiElementByName("ButtonInstance")
        .FormsControlAsObject as Button;

    button.Click += HandleButtonClick;
    button.Push += HandleButtonPush;
}

private void HandleButtonClick(object sender, EventArgs e)
{
    // handle click logic here
}

private void HandleButtonPush(object sender, EventArgs e)
{
    // handle push logic here
}
```

### Code Example - Code-Only Creation

```lang:c#
void CustomInitialize()
{
    // This will construct a button using the default
    // visual which should be set-up by Glue, or which can be
    // manually set up in code.
    var button = new Button();
    button.Visual.AddToManagers();
    button.Text = "Hello";
    button.Click += HandleButtonClick;
    button.Push += HandleButtonPush;
}

private void HandleButtonClick(object sender, EventArgs e)
{
    // handle click logic here
}

private void HandleButtonPush(object sender, EventArgs e)
{
    // handle push logic here
}
```

&#x20;
