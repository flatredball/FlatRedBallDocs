## Introduction

This tutorial continues our look at working with events on Gum objects. The previous tutorial covered the most basic situation - a clickable button in a screen. We'll expand upon the previous tutorial by creating a more complicated example - handling events on a popup container which displays a message and allows the user to click **OK** or **Cancel**. This tutorial covers the second property for controlling events: **ExposeChildrenEvents**.

## HasEvents and ExposeChildrenEvents

**HasEvents** and **ExposeChildrenEvents** decide whether a component and its children are recognized as UI objects by the FlatRedBall engine. More specifically, they decide whether instances of these components are added to the GuiManager's windows list, and whether the GuiManager.Cursor can interact with these instances. Since each value can be independently set, then there are four possible combinations of values. \[row\] \[column md="3"\] **HasEvents / ExposeChildrenEvents** \[/column\] \[column md="4"\] **Description** \[/column\] \[column md="5"\] **Example** \[/column\] \[/row\] \[row\] \[column md="3"\] True/False \[/column\] \[column md="4"\] The entire component is clickable, but individual parts of the component are not independently clickable. \[/column\] \[column md="5"\] A button made up of multiple sub-components (such as a NineSlice background, Text instance, and icon Sprite) which does not need each sub-component to be clickable. \[/column\] \[/row\] \[row\] \[column md="3"\] True/True \[/column\] \[column md="4"\] The entire component is clickable, as are individual sub-components. \[/column\] \[column md="5"\] A pop-up which should block clicks and also contains buttons which can be clicked. \[/column\] \[/row\] \[row\] \[column md="3"\] False/True \[/column\] \[column md="4"\] Only individual sub-components of the component will receive clicks. \[/column\] \[column md="5"\] A component which is used to perform layout on a collection of buttons, but the component as a whole has no visual component and should not receive clicks (or block clicks from receiving underlying UI). Only the individual buttons will receive clicks. \[/column\] \[/row\] \[row\] \[column md="3"\] False/False \[/column\] \[column md="4"\] The UI is completely ignored in the FlatRedBall UI system. \[/column\] \[column md="5"\] A decorative collection of UI which may overlap underlying UI elements but should not interfere with their click events. \[/column\] \[/row\]  

## Creating the Components

This tutorial uses three components:

1.  Button - a clickable component
2.  Label - a non-clickable component used to display a message to the user
3.  Popup - a component containing a label and two buttons

### Creating the Button Component

The Button component will need some kind of visual (such as a ColoredRectangle). We will include a Text object for the button, but it is not necessary for this tutorial. When finished your Button should look similar to the following image:

![](/media/2017-03-img_58cd81643eb36.png)

The only important detail for this component is to make sure the **HasEvents** value is set to true. We will look at **ExposeChildrenEvents** later.

![](/media/2023-08-img_64d8d90945476.png)

### Creating the Label Component

The label component is only a container with a single Text object. Functionally we could skip creating a Label component and add a Text object directly to the Popup component. We will be creating a Label component to show how to include some components in events (Buttons) and exclude others (Label). When finished your Label should look similar to the following image:

![](/media/2017-03-img_58cd840b932af.png)

For this tutorial we want to make sure Label instances are not clickable, so make sure the HasEvents property is set to false.

![](/media/2023-08-img_64d8d9858fc06.png)

### Creating the Popup Component

Finally, we'll create our Popup Component. It should contain the following instances:

-   Label
-   Button OkButton
-   Button CancelButton
-   ColoredRectangle (or other visual objects) for the background

When finished, the popup will appear as shown in the following image:

![](/media/2017-03-img_58cd866b0b6d3.png)

Let's consider the event behavior we want for our popup object:

-   We want each of the buttons in the popup to be clickable
-   We do not want the label to be clickable
-   We do not want the entire popup to raise events when it is clicked - only its buttons

This can be summarised as - the popup itself should not raise events, but its children should. We can get this combination of behaviour by setting the **HasEvents** value to false and the **ExposeChildrenEvents** value to true.

![](/media/2023-08-img_64d8da78f2ecb.png)

## Adding a Popup to Our Game

Now that we have a fully-functional Popup instance, we can add it to our Gum screen (such as MainMenuGum). [![](/wp-content/uploads/2017/03/13_07-31-43.gif)](/wp-content/uploads/2017/03/13_07-31-43.gif) Now that our popup is in our MainMenuGum, we can access it in our MainMenu.cs file in Visual Studio. For example, we can respond to click events on the OK and Cancel buttons by hiding the popup and displaying some debug text.

    void CustomInitialize()
    {
        var popup = GumScreen.PopupInstance;
        popup.OkButton.Click += HandleOkButtonClick;
        popup.CancelButton.Click += HandleCancelButtonClick;

    }

    private void HandleOkButtonClick(IWindow window)
    {
        GumScreen.PopupInstance.Visible = false;
        FlatRedBall.Debugging.Debugger.CommandLineWrite("OK clicked");
    }

    private void HandleCancelButtonClick(IWindow window)
    {
        GumScreen.PopupInstance.Visible = false;
        FlatRedBall.Debugging.Debugger.CommandLineWrite("Cancel clicked");
    }

## 

## Troubleshooting

The previous tutorial showed how to control whether Gum objects are considered objects which the cursor can interact with. Displaying the Cursor.WindowOver property can give clues about why events are not firing. As a reminder, the following code can be added to your Glue Screen's CustomActivity method:

``` lang:c#
FlatRedBall.Debugging.Debugger.Write(FlatRedBall.Gui.GuiManager.Cursor.WindowOver);
```

This code produces the following behavior in our game: [![](/wp-content/uploads/2017/03/13_07-42-11.gif)](/wp-content/uploads/2017/03/13_07-42-11.gif) Now that we've covered events related to contained objects (a Button inside of a Popup), we can look at other ways to diagnose event problems.

### Parent Container Receives Events

One of the most common event-related bugs is when the container of a set of instances receives input events instead of the contained instances. If the parent of an object does not have its ExposeChildrenEvents set to true, then children will not raise their events. For screens with deep hierarchies, any object in the parent/child, then any object in the chain can break events by having this set to false. For example, consider a button which is part of a standard Container:

![](/media/2017-05-img_5908a5918a41b.png)

If the Container Standard object does not have its **ExposeChildrenEvents** value checked, then the Button will not raise events. ![](/media/2017-05-img_5908a60746056.png) This can be fixed by checking the **ExposeChildrenEvents** value.

![](/media/2017-05-img_5908a65d704fe.png)

If a particular component acts purely as a container but should never receive events itself, then its HasEvents should be set to false.

## Children and Parent Bounds

By default a parent will only check events on its children if the children are contained within the bounds of the parent. This restriction exists primarily for performance reasons - it allows parents to perform an initial bounding-box check against the cursor and if the test fails, the parent will not perform "deep" collision (testing every contained child). However, sometimes children are not contained within their parents' bounds, and if those children have events (such as click events), they will not raise these events by default. This can be corrected in one of two ways:

1.  Expand the bounds of the parent to contain the child - this may make sense conceptually and it's the easiest and most efficient solution to the problem.
2.  Change the parent instance's RaiseChildrenEventsOutsideOfBounds  value to true. This will enable "deep" checking against all contained children. Of course, be careful when setting this on a large number of parents as it can increase the amount of time that cursor checks take.

 

## Conclusion

This tutorial has shown how to work with events on Gum component instances which are contained in other instances. [\<- 4. Events on Gum Objects](/documentation/tools/gum/gum-tutorials/tutorials-gum-events-on-gum-objects.md) -- [6. Exposed Variables -\>](/documentation/tools/gum/gum-tutorials/tutorials-gum-exposed-variables.md)
