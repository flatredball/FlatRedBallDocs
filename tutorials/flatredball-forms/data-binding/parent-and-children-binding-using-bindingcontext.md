# Parent and Children Binding using BindingContext

### Introduction

Often times games include custom reusable Forms components. These components may have dedicated ViewModel classes which can also be reused across multiple screens. This walkthrough shows how to create a reusable component, a reusable ViewModel, and how to assign the binding context appropriately.

### Example View

For this view we will have a simple component which could be used for a game's settings. Note that if you actually need to create a view for settings, you should review the [SettingsView](../../../api/flatredball-forms/controls/games/settingsview.md) control as a starting point. We'll be creating our own for this tutorial to keep it shorter.

Keep in mind the contents of this control are purely to serve as an example. The actual contents of your control could vary. For this example, consider the following control:

<figure><img src="../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Sample view with 3 </p></figcaption></figure>

This control has two sliders and a checkbox, so our ViewModel should be built to support these controls. The following is an example ViewModel for this control:

```csharp
class CustomSettingsViewModel : ViewModel
{
    public float GammValue
    {
        get => Get<float>();
        set => Set(value);
    }

    public float UiScaleValue
    {
        get => Get<float>();
        set => Set(value);
    }

    public bool IsHighContrastChecked
    {
        get => Get<bool>();
        set => Set(value);
    }
}
```

To make the CustomSettingsView forms control reusable, we can set the binding on each of the controls in its custom code. To do this:

1. Open your project in Visual Studio
2. Open the CustomSettingsViewRuntime.cs file, which is located in the GumRuntimes folder. Note that if you added the control to a subfolder, you will find the runtime code in a subfolder as well.
3. Add the following code to CustomInitialize:

```csharp
public partial class CustomSettingsViewRuntime
{
    // This can be used to simplify nameof calls, or even to access in event handlers
    // Note that the ViewModel instance is not actually set in CustomInitialize, so we
    // can only use it for nameof in this method.
    CustomSettingsViewModel ViewModel => (CustomSettingsViewModel)BindingContext;

    partial void CustomInitialize () 
    {
        var forms = this.FormsControl;

        forms.GammaSlider.SetBinding(
            nameof(forms.GammaSlider.Value),
            nameof(ViewModel.GammValue));

        forms.UiScaleSlider.SetBinding(
            nameof(forms.UiScaleSlider.Value),
            nameof(ViewModel.UiScaleValue));

        forms.HighContrastCheckBox.SetBinding(
            nameof(forms.HighContrastCheckBox.IsChecked),
            nameof(ViewModel.IsHighContrastChecked));
    }
}
```

Note that this does not actually instantiate the CustomSettingsViewModel - it simply sets the binding so that the contained Forms components (sliders and checkbox) will be bound once the BindingContext is assigned. It is up to the parent container or screen to instantiate and assign the ViewModel.

### Assigning the BindingContext

Now our CustomSettingsViewRuntime is set up to bind its contained object's properties to a ViewModel's properties. Next we need to assign the view model.&#x20;

This assignment can happen either directly by setting the BindingContext, or it can also be done by binding the BindingContext property. We'll cover both scenarios below and discuss why you might want to use one approach or another.

### Direct Assignment

The simplest approach is to directly assign the BindingContext to an instance of the CustomSettingsViewModel.&#x20;

For this example we'll consider a FlatRedball Screen called MainMenu which has an instance of the CustomSettingsView in its Gum screen. Even though we won't create it in this tutorial, the MainMenu may also have a corresponding MainMenuViewModel which would be assigned to Forms.BindingContext. We can override the BindingContext on the contained CustomSettingsViewInstance as shown in the following code:

```csharp
void CustomInitialize()
{
    // This assigns the main ViewModel which cascades down to all controls
    Forms.BindingContext = 
        new MainMenuViewModel();

    // We can override the implicit cascading assignment by explicitly 
    // assigning the ViewModel:
    Forms.CustomSettingsViewInstance.BindingContext = 
        new CustomSettingsViewModel();
}
```

This approach will correctly assign the BindingContext to the CustomSettingsView, but it does require explicit assignment of view models at the Screen level. The next section shows how to set up binding in a way that does not require multiple assignments at the screen level.

### Assigning BindingContext through Binding

The BindingContext property is itself bindable. For simple situations this is not used very frequently, but if you have more advanced UI you may benefit from having binding context. For example, consider a situation where the CustomSettingsView is a child of another view, such as a PauseMenu.

In this situation, the PauseMenu may be part of the GameScreen and have its own binding context. Of course, it would be possible to access the internals of the PauseMenu in the GameScreen as shown in the following code:

```csharp
// This code would be in GameScreen:
Forms.BindingContext = new GameScreenViewModel();

// But we might also want to assign the PauseMenuViewModel...
GumScreen.PauseMenu.BindingContext = new PauseMenuViewModel();

// ... and also the CustomSettingsViewInstance's BindingContext...
GumScreen.PauseMenu.CustomSettingsViewInstance.BindingContext = new CustomSettingsViewModel();
```

This code begins to create a maintenance problem - if the Screen must explicitly assign all children BindingContext properties, then the children (PauseMenu) reusability goes down. Rather, we would want the PauseMenu to be responsible for assigning all of its children's binding context.

Therefore, we could modify our code to support this.

The first step is to modify the PauseMenuViewModel (the ViewModel of the parent component) to contain a CustomSettingsViewModel as shown in the following code:

```csharp
class PauseMenuViewModel : ViewModel
{
    // It can also contain instances of ViewModel types made for
    // any custom children controls:
    public CustomSettingsViewModel CustomSettingsViewModel 
    {
        get => Get<CustomSettingsViewModel>();
        set => Set(value);
    } 

    // Any other properties which might be needed...

    public PauseMenuViewModel()
    {
        CustomSettingsViewModel = new CustomSettingsViewModel();

        // assign any other properties here
    }
}
```

The next step is to modify the PauseMenuRuntime's code to set the CustomSettingsView's BindingContext. As mentioned above, when CustomInitialize is called the view will not yet have a BindingContext assigned. Therefore, we cannot directly assign the CustomSettingViewInstance's BindingContext, but must bind to it:

```csharp
class PauseMenuRuntime
{
    PauseMenuViewModel ViewModel => (PauseMenuViewModel)BindingContext;

    void CustomInitialize()
    {
        var forms = this.FormsControl;

        forms.CustomSettingsViewInstance.SetBinding(
            nameof(forms.CustomSettingsViewInstance.BindingContext),
            nameof(ViewModel.CustomSettingsViewModel));

    }
}
```

Now, the GumScreen does not need to directly assign the CustomSettingsViewInstance's BindingContext. The code has become simpler:

```csharp
// This code would be in GameScreen:
Forms.BindingContext = new GameScreenViewModel();

// But we might also want to assign the PauseMenuViewModel...
GumScreen.PauseMenu.BindingContext = new PauseMenuViewModel();
```

By assigning the PauseMenu's BindingContext, the internal CustomSettingsViewInstance looks for a property on the PauseMenuViewModel with the name "CustomSettingsViewModel. Since the PauseMenuViewModel has this property, this will automatically be bound.

For this particular example it may seem like a pointless tradeoff - the binding context assignment was removed from the GameScreen, but additional code was added to the PauseMenuRuntime and PauseMenuViewModel. This extra code becomes more valuable if the PauseMenu (or any other container) were to be reused across multiple screens.

Notice that the code above has reduced the explicit assignments from three to two. We could further reduce this code by moving the PauseMenuViewMode inside the GameScreenViewModel and similarly binding the PauseMenu's BindingContext inside of the GameScreenGumRuntime. The amount of embedded ViewModel assignment you perform depends on the level of reusability your game needs.
