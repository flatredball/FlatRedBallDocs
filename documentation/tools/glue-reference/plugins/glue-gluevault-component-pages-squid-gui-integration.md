## Introduction

Squid GUI is a UI framework by IONSTAR Studios. It provides functionality for a number of common controls like buttons, check boxes, labels, drop down lists, and much more. You can even expand on it by creating your own custom controls. For information regarding the Squid GUI library, please refer to their website here: [http://www.ionstar.org/?page_id=4](http://www.ionstar.org/?page_id=4)

A simple layout system has been created to make developing your GUIs as easy as possible. Keep in mind that this is fairly bare-bones and will be expanded upon over time.

## Sample Project

You can download a sample project here: [Download](/frb/docs/images/e/e2/FRBSquid.zip.md)

This sample project includes several things:

1.  Graphics for the controls provided by IONSTAR's SquidGUI package
2.  An Arial10 Spritefont
3.  A sample XML layout
4.  Code which handles most of the internal plumbing of getting the UI to draw on the screen.
5.  A sample "GUI Logic" entity which demonstrates how to hook your GUI interaction events back to your screen.

This sample project will let you dive right in and see how everything works. However, if you need a more hands-on tutorial please keep reading to learn how this all works.

## Creating a GUI

There's essentially three steps to creating a GUI:

1.  Create the XML layout
2.  Create the GUI interaction logic class
3.  Add the interaction class to your screen

This guide will take you through each of these steps with a simple example. To start, we'll create a window with an "Exit Button" inside it. When this button is clicked, a confirmation box will appear. If the user confirms, the entire application will shut down.

## Creating an XML Layout

Each layout must contain at least one window. Components such as buttons, check boxes, and labels are contained inside of the window.

We'll use this layout for this example.

    <?xml version="1.0" encoding="utf-8"?>
    <UILayout xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <Components>
        <UIComponent>
          <ComponentType>Window</ComponentType>
          <Visible>true</Visible>
          <Name>MainMenuWindow</Name>
          <SizeX>600</SizeX>
          <SizeY>500</SizeY>
          <PositionX>0</PositionX>
          <PositionY>0</PositionY>
          <Title>Main Menu</Title>
          <Text></Text>
          <Resizeable>false</Resizeable>
          <Anchor>None</Anchor>
          <CursorType>default</CursorType>
          <Children>
            <UIComponent>
              <ComponentType>Button</ComponentType>
              <Name>btnExit</Name>
              <SizeX>425</SizeX>
              <SizeY>40</SizeY>
              <PositionX>0</PositionX>
              <PositionY>50</PositionY>
              <Text>Exit</Text>
              <Anchor>None</Anchor>
            </UIComponent>
          </Children>
        </UIComponent>
      </Components>
    </UILayout>

This sample layout will create a window with a button labeled "Exit". The button will be 425 pixels wide and 40 pixels tall.

When working with position, it's important to keep in mind that all controls start at the origin of its parent window. So in this case, the button will be 50 pixels down from the center of the window.

Here's a screenshot of how the screen should look:

![Demo exit.png](/media/migrated_media-Demo_exit.png)

## Supported Component Types

These are the currently supported component types:

1.  Window
2.  Label
3.  Textbox
4.  Button
5.  Checkbox

Note that you can add additional types to the SquidLayoutManager class file.

## Creating the GUI Interaction Logic

Now that we have a layout, we need to provide interaction logic to the UI. In other words, when the user clicks the "Exit Button" we want a pop-up to appear.

To start, let's look at the class called MainMenuLogic in the example project.

    using System;
    using FlatRedBall;
    using FRBSquid.SquidGUI;
    using FRBSquid.SquidGUI.Enumerations;
    using Squid;

    namespace FRBSquid.Entities.GUI
    {
        public class MainMenuLogic : GUIDrawableBatch
        {
            #region Controls

            private UIWindow Window { get; set; }
            private Button ExitButton { get; set; }

            #endregion

            public MainMenuLogic()
                : base("MainMenu")
            {
                LoadControls();
                HookEvents();
            }

            private void LoadControls()
            {
                Window = GetControl("MainMenuWindow") as UIWindow;
                ExitButton = GetControl("btnExit") as Button;
            }

            private void HookEvents()
            {
                ExitButton.MouseClick += ExitButton_MouseClick;
            }

            private void ExitButton_MouseClick(Control sender, MouseEventArgs args)
            {
                MessageBox box = MessageBox.Show(new Point(200, 150), "Really Exit?", "Are you sure you want to exit?", MessageBoxButtonTypeEnum.YesNo, _desktop);
                box.OnYesClicked += ExitConfirmClicked;

            }

            private void ExitConfirmClicked(object sender, EventArgs e)
            {
                FlatRedBallServices.Game.Exit();
            }
        }
    }

This class is deriving from GUIDrawableBatch, which is used for all GUI interaction classes. This abstracts all of the lower level drawing and input logic, so you can focus on making the UI actually do stuff.

Let's look at the constructor.


    public MainMenuLogic()
        : base("MainMenu")
    {
        LoadControls();
        HookEvents();
    }

It's very important to note the constructor is passing "MainMenu" into the base constructor. This is actually a reference to the file name of the layout which is MainMenu.xml

Next, refer to the LoadControls() method.


    private void LoadControls()
    {
        Window = GetControl("MainMenuWindow") as UIWindow;
        ExitButton = GetControl("btnExit") as Button;
    }

Here, we're loading the window and button into memory based on the component's "Name" field which is defined in the XML layout.

The rest is fairly straightforward. The HookEvents subscribes the method ExitButton_MouseClick to the MouseClick event provided by Squid. This calls a pop-up message box.


    MessageBox box = MessageBox.Show(new Point(200, 150), 
        "Really Exit?", 
        "Are you sure you want to exit?", 
        MessageBoxButtonTypeEnum.YesNo, 
        _desktop);

        box.OnYesClicked += ExitConfirmClicked;

![Demo popup.png](/media/migrated_media-Demo_popup.png)

Finally, when the pop up menu's "Yes" button is clicked, it will fire the ExitConfirmClicked method which shuts down the game.

## Add the interaction class to your screen

Now that we have the interaction class created, we need to instantiate it on the screen. For the example project, we're using the screen named "DemoScreen".

This next part is super easy - check out our DemoScreen code.


    public partial class DemoScreen
    {
        private MainMenuLogic GUI { get; set; }

        void CustomInitialize()
        {
            this.GUI = new MainMenuLogic();
        }

        void CustomActivity(bool firstTimeCalled)
        {
        }

        void CustomDestroy()
        {
        }

        static void CustomLoadStaticContent(string contentManagerName)
        {
        }
    }

And that's all there is to it! You could start doing some more complicated things like raising events from the MainMenuLogic class and responding to them from the screen. However, that is outside the scope of this guide.

## Conclusion

Squid GUI offers a great way to develop user interfaces in FlatRedBall. You can really do a lot with its simple XML configuration and it can be expanded upon fairly easily.
