# Adding UI to FlatRedBall

### Introduction

FlatRedBall plugins can add custom UI to Glue which are hosted in tabs. Tabs can be always visible or in response to events (such as when a file is selected). This tutorial will show how to create a tab that displays information about the selected file.

### Defining a Control

First we will create a WPF user control in our project:

1. Right-click on your project and select **Add** -> **New** **Folder**
2.  Name the folder **Controls**

    ![](../../media/2018-02-img\_5a8061301231f.png)
3. Right-click on the newly-created folder
4. Select **Add** -> **New Item...**
5. Select the **Installed** -> **Visual C# Items** -> **WPF** category
6.  Select **User Controls (WPF)**

    ![](../../media/2018-02-img\_5a8062529e30e.png)
7. Enter the name **MainControl** (more complicated plugins may have multiple controls)
8. Click **Add**

### Showing the Control

To test the control, we will add a TextBlock at first. Modify the XAML code as shown in the following code:

```lang:c#
<UserControl x:Class="TutorialPlugin.Controls.MainControl"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:TutorialPlugin.Controls"
             mc:Ignorable="d" 
             d:DesignHeight="300" d:DesignWidth="300">
    <Grid>
        <TextBlock>This is a plugin!</TextBlock>
    </Grid>
</UserControl>
```

Now we'll show the control whenever the user selects a file, but hide it whenever another object is selected. To do this, modify the **MainTutorialPlugin.cs** file as shown in the following snippet:

```lang:c#
using FlatRedBall.Glue.Plugins;
using FlatRedBall.Glue.Plugins.ExportedImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorialPlugin
{
    [System.ComponentModel.Composition.Export(typeof(FlatRedBall.Glue.Plugins.PluginBase))]
    public class MainTutorialPlugin : FlatRedBall.Glue.Plugins.PluginBase
    {
        Controls.MainControl mainControl;

        public override string FriendlyName => "Tutorial Plugin";

        public override void StartUp()
        {
            this.ReactToItemSelectHandler += HandleItemSelected;
        }

        private void HandleItemSelected(TreeNode selectedTreeNode)
        {
            var currentFile = GlueState.Self.CurrentReferencedFileSave;

            if(currentFile == null)
            {
                this.RemoveTab();
            }
            else
            {
                if(mainControl == null)
                {
                    mainControl = new Controls.MainControl();
                    this.AddToTab(PluginManager.CenterTab, mainControl, "Tutorial Plugin");
                }
                else
                {
                    this.AddTab();
                }
            }
        }
    }
}
```

Let's break down some of the parts of the code above.

#### ReactToItemSelectHandler

This is a delegate which is raised whenever an item is selected. Subscribing to this allows a plugin to perform custom logic when the user selects an item in the tree view. In this case, we will call the HandleItemSelected method. Glue plugins define dozens of delegates such as when a project is loaded, a file changes, or an object is added to an entity.

#### GlueState.Self

GlueState.Self  provides information about the current state of Glue, including which objects are selected in the tree view. In this case we are checking if a file is selected, which would be represented by the CurrentReferencedFileSave  member.

#### RemoveTab

Removes the tab associated with this plugin from Glue - the tab will still be held in memory but it will not display.

#### AddToTab and AddTab

AddToTab  adds the argument control to the argument tab. In this case we are adding our main control to the center tab control. We only need to call this method once - after that the tab is associated with the center tab and we can call AddTab .

### Testing the Plugin

Rebuilding the plugin (make sure to build solution or explicitly select Build on the plugin project) will result in the tab being shown when a file is selected.

![](../../media/2018-02-img\_5a807055eaa60.png)
