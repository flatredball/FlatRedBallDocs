## Introduction

DefaultFormsComponents is a static property in the FrameworkElement class which associates a FlatRedBall.Forms control to a default Gum component type. DefaultFormsComponent is used whenever code instantiated a FlatRedball.forms object, allowing the internal engine to automatically create visuals for it. In other words, this association defines the default appearance of a FlatRedBall.Forms object by associating it with a Gum type. For example, the following code shows how a simple button can be created without specifying a Visual for the button:

``` lang:c#
// Notice that a visual is not specified for the button
// The button will automatically create its own visual
// according to the association in DefaultFormsComponents
var button = new Button();
// Now the button has a visual which can be used:
button.Visual.AddToManagers();
// and of course the button is fully functional:
button.Click += HandleButtonClick;
```

Notice that in the code above there is no creation of a visual Gum object. The Button object uses the DefaultFormsComponent property automatically construct a Gum object.

## DefaultFormsComponents in Generated Code

The Gum plugin in Glue will automatically populate the DefaultFormsComponents dictionary according to behaviors assigned to components in the Gum project. Unmodified projects which include Forms components will have a standard component for each Forms control. The code for this is added to the GumIdb.Generated.cs file.  For example, the code may look like this:

``` lang:c#
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Button)] = typeof(ProjectName.GumRuntimes.DefaultForms.ButtonRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.CheckBox)] = typeof(ProjectName.GumRuntimes.DefaultForms.CheckBoxRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ComboBox)] = typeof(ProjectName.GumRuntimes.DefaultForms.ComboBoxRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ListBox)] = typeof(ProjectName.GumRuntimes.DefaultForms.ListBoxRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ListBoxItem)] = typeof(ProjectName.GumRuntimes.DefaultForms.ListBoxItemRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.RadioButton)] = typeof(ProjectName.GumRuntimes.DefaultForms.RadioButtonRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ScrollBar)] = typeof(ProjectName.GumRuntimes.DefaultForms.ScrollBarRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ScrollViewer)] = typeof(ProjectName.GumRuntimes.DefaultForms.ScrollViewerRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Slider)] = typeof(ProjectName.GumRuntimes.DefaultForms.SliderRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TextBox)] = typeof(ProjectName.GumRuntimes.DefaultForms.TextBoxRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ToggleButton)] = typeof(ProjectName.GumRuntimes.DefaultForms.ToggleButtonRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TreeView)] = typeof(ProjectName.GumRuntimes.DefaultForms.TreeViewRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TreeViewItem)] = typeof(ProjectName.GumRuntimes.DefaultForms.TreeViewItemRuntime);
FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.UserControl)] = typeof(ProjectName.GumRuntimes.DefaultForms.UserControlRuntime);
```

Keep in mind this association can be overridden. For example, you may add the following to your screen's CustomInitialize:

``` lang:c#
FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Button)] = 
    typeof(ProjectName.GumRuntimes.LargeMenuButtonRuntime);
```

The DefaultFormsComponents can be assigned and re-assigned any number of times, allowing a project to have per-screen or even per-function default behavior, rather than a global association.
