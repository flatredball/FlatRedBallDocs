## Introduction

An IMenuStripPlugin is a plugin that adds a menu strip item. ![GlueMenuStrip.png](/media/migrated_media-GlueMenuStrip.png) IMenuStripPlugins can create new top-level menus (such as a new menu to the right of "Glue View" in the image above) or can add items under existing menu items (such as under the "Project" menu item).

## Code Example

The following code example adds an option under the "Plugins" menu option which shows a simple message box when clicked.

    using FlatRedBall.Glue.Plugins.Interfaces;
    using System.ComponentModel.Composition;
    using System.Windows.Forms;

    // Make sure your plugin class inherits from IMenuStripPlugin and exports the IMenuStripPlugin interface:
    [Export(typeof(IMenuStripPlugin)) ]
    public class TortoiseMenuItems : IMenuStripPlugin
    {
        ToolStripMenuItem mMenuItem;
        MenuStrip mMenuStrip;

        public void InitializeMenu(System.Windows.Forms.MenuStrip menuStrip)
        {
            mMenuStrip = menuStrip;

            mMenuItem = new ToolStripMenuItem("Show Popup");
            ToolStripMenuItem itemToAddTo = GetItem("Plugins");

            itemToAddTo.DropDownItems.Add(mMenuItem);
            mMenuItem.Click += new EventHandler(mMenuItem_Click);
        }

        public bool ShutDown(PluginShutDownReason shutDownReason)
        {
            ToolStripMenuItem itemToAddTo = GetItem("Plugins");
            itemToAddTo.DropDownItems.Remove(mMenuItem);
            return true;
        }

        void mMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Popup!");
        }

        ToolStripMenuItem GetItem(string name)
        {
            foreach (ToolStripMenuItem item in mMenuStrip.Items)
            {
                if (item.Text == name)
                {
                    return item;
                }
            }
            return null;
        }

        // The following methods are all required for plugins:
        public string FriendlyName
        {
            get { return "MessageBox showing plugin"; }
        }

        public Version Version
        {
            get { return new Version(); }
        }

        public void StartUp()
        {
            // do nothing
        }

        public bool ShutDown(PluginShutDownReason shutDownReason)
        {
            // This plugin needs to be responsible and remove itself from Glue when shutting down
            ToolStripMenuItem itemToRemoveFrom = GetItem("Plugins");
            itemToRemoveFrom.DropDownItems.Remove(mMenuItem);
            return true;// We are okay to shut down
        }

    }
