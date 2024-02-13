# Show

### Introduction

The Show method can be used to add a Forms to the necessary managers so that it is drawn and can respond to input events. This method should not be called on Forms instances which have been added through the Gum tool - it is only used on Forms which are added in code, and which do not have a parent.

### Code Example

The following code can be used to add a Button to a Screen in code:

```csharp
Button button;
void CustomInitialize()
{
    button = new Button();
    button.Text = "I am a button created in code";
    button.X = 100;
    button.Y = 100;
    button.Show();
}
```

Note that controls which are added in code through Show should be removed manually in the Screen's CustomDestroy.

```csharp
void CustomDestroy()
{
    button.Visual.RemoveFromManagers();
}
```
