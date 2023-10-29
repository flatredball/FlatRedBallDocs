# adding-wpf-to-an-existing-game

### Introduction

WPF controls can be added to any FlatRedBall PC game. This walkthrough shows how to add a floating control which will both display runtime information and also be used to add new entity instances.

### Setup

This tutorial uses a Glue project named "FrbAndWpf" as the starting point. This Glue project will contain the following:

1. An entity called "CircleEntity"
   1. CircleEntity will contain a single Circle named CircleInstance
2. A screen called GameScreen
   1. GameScreen will contain a [PositionedObjectList](../../../frb/docs/index.php) of CircleEntities named CircleEntityList

By default the game will not display anything since the CircleEntityList will be empty.

![FrbAndWpfStarting.PNG](../../../media/migrated\_media-FrbAndWpfStarting.PNG)

### Adding References

Before adding any code or XAML to the project you'll need to add a few library references. To do this:

1. Open your project in Visual Studio
2. Right-click on "References" under your project
3. Select "Add Reference..."
4. In the dialog that appears select the "Assemblies" option
5. Check the following assemblies:
   1. PresentationCore
   2. PresentationFramework
   3. System.Xaml
6. Click OK

### Creating a Window

To create a window:

1. Right-click on your project
2. Select "Add" -> "New Folder"
3. Name the folder "Wpf"
4. Right-click on the newly-created folder
5. Select "Add" -> "New Item..."
6. Select "User Control (WPF)"
7. Enter the name "DiagnosticWindow"
8. Click "Add"

For this tutorial we actually want DiagnosticWindow to be a Window and not a UserControl. We can change this by opening up the XAML for this and changing "UserControl" to "Window". The XAML should look like this:

```
<Window x:Class="FrbAndWpf.Wpf.DiagnosticWindow"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             mc:Ignorable="d" 
             Height="300" Width="300">
    <Grid>
            
    </Grid>
</Window>
```

The inheritance code in the codebehind needs to be modified to inherit Window as well. Modify the codebehind to look like this:

```
    public partial class DiagnosticWindow : Window
    {
        public DiagnosticWindow()
        {
            InitializeComponent();
        }
    }
```

### Adding the Window to the Game

Now that we have a Window called DiagnosticWindow we can instantiate and show it in Game1.cs. To do this:

1. Open Game1.cs in Visual Studio
2. Find the Initialize method
3. Modify the Initialize function to instantiate and show the DiagnosticWindow so it looks like:

&#x20;

```
protected override void Initialize()
{
    FlatRedBallServices.InitializeFlatRedBall(this, graphics);
    CameraSetup.SetupCamera(SpriteManager.Camera, graphics);
    GlobalContent.Initialize();

    FlatRedBall.Screens.ScreenManager.Start(typeof(FrbAndWpf.Screens.GameScreen));

    FrbAndWpf.Wpf.DiagnosticWindow window = new Wpf.DiagnosticWindow();
    window.Show();

    base.Initialize();
}
```

Also the use of WPF requires that the Main function has the STAThread attribute. To add this:

1. Open Program.cs
2. Add the STAThread to the Main method so it looks like:

&#x20;

```
[STAThread]
static void Main(string[] args)
{
    using (Game1 game = new Game1())
    {
        game.Run();
    }
}
```

At this point you'll want to make sure to save your project. You can do this by build/running it, or by using the "File" -> "Save All" menu item. Running the game shows the WPF window next to the FRB window: ![WpfNextToFrb.PNG](../../../media/migrated\_media-WpfNextToFrb.PNG)

### Adding elements to DiagnosticWindow

The DiagnosticWindow will have two elements:

1. A Label that will display how many PositionedObjects are in the engine
2. A button used to create entities

Modify the DiagnosticWindow XAML so it is as follows:

```
<Window x:Class="FrbAndWpf.Wpf.DiagnosticWindow"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             mc:Ignorable="d" 
             Height="300" Width="300">
    <StackPanel>
        <Label x:Name="PositionedObjectInfo">Number of PositionedObjects: 0</Label>            
        <Button Click="Button_Click">Add Entity Instance</Button>
    </StackPanel>
</Window>
```

**Note:** WPF is typically implemented with binding and MVVM. For brevity we won't use these patterns in this tutorial, but you should consider doing so as you expand your FRB/WPF application.

Of course you'll need to add a Button\_Click event to the DiagnosticWindow codebehind:

```
private void Button_Click(object sender, RoutedEventArgs e)
{

}
```

### Making the Button interactive

First we'll add logic for the button to be able to create entities when clicked. First we'll tell Glue to create a factory for us:

1. Switch to Glue
2. Select CreatedByOtherEntities to True

Next we'll use the factory to instantiate a CircleEntity whenever the button is clicked. To do this:

1. Switch to Visual Studio
2. Navigate to the Button\_Click method in the DiagnosticWindow
3. Modify Button\_Click so it looks like:

&#x20;

```
private void Button_Click(object sender, RoutedEventArgs e)
{
    var newInstance = Factories.CircleEntityFactory.CreateNew();

    newInstance.XVelocity = 100;
}
```

If you run the game now and click the button you'll see that you can create entities: ![CreatedInstances.PNG](../../../media/migrated\_media-CreatedInstances.PNG)

### Updating the Label

For a more complicated game we might update the label on a timer, or by using a view model. In this case we'll simply update the label whenever the user clicks the button. We can do this by modifying the Button\_Click method so it looks like:

```
private void Button_Click(object sender, RoutedEventArgs e)
{
    var newInstance = Factories.CircleEntityFactory.CreateNew();

    newInstance.XVelocity = 100;

    this.PositionedObjectInfo.Content = 
        "Number of PositionedObjects: " + 
        FlatRedBall.SpriteManager.ManagedPositionedObjects.Count;
}
```

Now clicking the button will instantiate an Entity and update the label to show how many objects are in the engine:

![OneInstance.PNG](../../../media/migrated\_media-OneInstance.PNG)

### Troubleshooting

#### TextBoxes not receiving input

For information on this problem, see [this post](http://stackoverflow.com/questions/1597655/problem-with-text-input-in-textbox-control).

### Summary

This tutorial showed how to add a WPF window to an existing FlatRedBall (Glue) project. It shows how to both display information as well as drive behavior using the UI. Of course, it implements the bare minimum for a working example but WPF can be added to games to create very powerful diagnostics and behavior.
