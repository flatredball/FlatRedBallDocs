# scrollviewer

### Introduction

The ScrollViewer control is a general-purpose control which can be used to display a scrollable area. The ScrollViewer exposes a control called InnerPanel which is the host for all content within the ScrollViewer. The InnerPanel is a Gum GraphialUiElement so its sizing and positioning rules are flexible and can be modified either in code or Gum.

### Layout Requirements

The ScrollViewer control requires:

* An object named **VerticalScrollBarInstance** which implements ScrollBarBehavior (is a ScrollBar)
* An object named **InnerPanelInstance** of any type (typically a Container)
* An object named **ClipContainerInstance** of any type (typically a Container with **ClipsChildren** set to true)

![](../../../../media/2017-12-img\_5a465ac0d252b.png)

### ClipContainerInstance Recommendations

The clip container is a container which will hold the InnerPanelInstance. The hierarchy of controls should be:

* ScrollViewerComponent
  * VerticalScrollBarInstance
  * ClipContainerInstance
    * InnerPanelInstance
      * Contents of the ScrollViewer - added at runtime through code

This hierarchy allows each control to serve a separate function. The clip container's purpose is to clip the drawing of all contained objects. The clip container prevents the inner panel (and all controls within the inner panel) from overlapping the vertical scroll bar and from spilling out of the scroll viewer. The clip container should be of standard type **Container** because this control is typically used for clipping children. The clip container should have its **ClipsChildren** variable set to true. For information on this property, see the Gum documentation on ClipsChildren: [http://vchelaru.github.io/Gum/generalproperties/Clips%20Children.html](http://vchelaru.github.io/Gum/generalproperties/Clips%20Children.html) The clip container will typically fill the most of the scroll viewer component, leaving room for the vertical scroll bar and any desired border. This can be accomplished by setting **WidthUnits** and **HeightUnits** to **RelativeToContainer**.

#### ScrollBarVisibility Category

ScrollViewer instances support hiding or showing the VerticalScrollBarInstance. This can impact the horizontal size of the ClipContainerInstance. In the case of a hidden VerticalScrollBarInstance, the ClipContainerInstance should extend to occupy space that would otherwise be used by the VerticalScrollBarInstance. To respond to the VerticalScrollBarInstance being hidden and shown, the ScrollViewer Gum object should have a state category titled **ScrollBarVisibility** with two states:

1. NoScrollBar
2. VerticalScrollVisible

![](../../../../media/2020-12-img\_5fe0bcaf3e58d.png)

These two states should adjust the visibility of the VerticalScrollBarInstance and the width of the ClipContainerInstance as shown in the following diagram:

![](../../../../media/2020-12-img\_5fe0c0267cc93.png)

Keep in mind that this category applies to any control which inherits from ScrollBar, such as ListBox. Also, these values should not be directly assigned in code, but rather are controlled through the ScrollBar's VerticalScrollBarVisibility property (see below).

### InnerPanelInstance Recommendations

The inner panel is used to provide the following behavior:

* Scrolls all contents in response to the vertical scroll bar events
* Provides size information to the vertical scroll bar to resize the thumb (see more information below)
* Provides a common parent to all custom content for scrolling

Currently the ScrollViewer control only supports vertical scrolling, so the inner panel should be configured to grow and shrink only on the Y axis. This can be accomplished by setting the following values on the InnerPanelInstance:

* X = 0
* X Units = PixelsFromLeft
* Y = 0
* Y Units = PixelsFromTop
* Width = 0
* Width Units = RelativeToContainer (makes the panel stretch horizontally to the width of the ClipContainerInstance)
* Height = 0
* Height Units = RelativeToChildren (makes the panel initially have no height, but makes it stretch vertically according to its contents)

Setting **HeightUnits** to **RelativeToChildren** results in the inner panel enables automatic resizing according to the inner panel's children (which are added at runtime).

![](../../../../media/2017-12-img\_5a46645375a35.png)

As additional controls are added to inner panel, it will expand vertically. Controls which fall outside of the clip container will not be rendered. The following diagram shows this, but has controls outside of the clip container dimmed for illustrative purposes:

![](../../../../media/2017-12-img\_5a47a33404776.png)

### InnerPanelInstance and Children Layout

The inner panel can be used to hold controls which are positioned in absolute pixel values or which are automatically stacked (such as a list box). If the controls within the inner panel are to be positioned in absolute terms, the **Children Layout** value should be set to **Regular**. If the controls within the inner panel are to be stacked automatically, the inner panel **Children Layout** value should be set to **TopToBottomStack**.

### VerticalScrollBarVisibility

The VerticalScrollBarVisibility property controls the behavior of the scrollbar in response to the number of items in the ScrollViewer. The three available values are:

* Auto - the vertical scrollbar will display only if the ScrollViewer requires scrolling to display all items. This is the default functionality
* Hidden - the vertical scrollbar will never show, but the ScrollViewer still supports scrolling with the mouse wheel or swiping on the touchscreen
* Visibile - the vertical scrollbar will always display



<figure><img src="../../../../media/2017-12-17\_07-34-31.gif" alt=""><figcaption></figcaption></figure>



### Example - Manually Sizing ScrollViewer in Code

When working with a ScrollViewer we need to consider two sizes:

1. Width and Height of the ScrollViewer itself, which can be explicitly in code or which can be set on the Gum runtime object in the Gum tool
2. The InnerPanel width and height, which also can be explicitly set in code or which can be set on the Gum runtime object in the Gum tool

&#x20; The following code shows how a manually sized ScrollViewer will behave:

```lang:c#
var scrollViewer = TutorialScreenGum
    .GetGraphicalUiElementByName("ScrollViewerInstance")
    .FormsControlAsObject as ScrollViewer;

scrollViewer.Visual.WidthUnits = 
    Gum.DataTypes.DimensionUnitType.Absolute;
scrollViewer.Visual.Width = 200;

scrollViewer.Visual.HeightUnits =
    Gum.DataTypes.DimensionUnitType.Absolute;
scrollViewer.Visual.Height = 400;

scrollViewer.InnerPanel.WidthUnits = 
    Gum.DataTypes.DimensionUnitType.Absolute;
scrollViewer.InnerPanel.Width = 70;

scrollViewer.InnerPanel.HeightUnits =
    Gum.DataTypes.DimensionUnitType.Absolute;
// Make the inner panel really tall:
scrollViewer.InnerPanel.Height = 1000;
```

When viewing the code above, keep in mind:

* At the time of this writing the ScrollViewer object only supports scrolling vertically (up and down).
* We set the scrollViewer.Visual's WidthUnits, Width, HeightUnits, and Height for the sake of making a clear example. This is not necessary (and often not desirable) in a real world example where layout is controlled by the Gum tool.

The code above adjusts the ScrollViewer such that the view displays 40% (400 / 1000) of the available height of the InnerPanel. The scroll bar can be used to to scroll through the container. 

<figure><img src="../../../../media/2017-12-2017-12-24\_14-54-40.gif" alt=""><figcaption></figcaption></figure>



### Example - Adding to InnerPanelInstance in Gum

Objects can be added to ScrollViewer instances in Gum, but it requires manually entering the suffix ".InnerPanelInstance" to the parent name of the child. For example, consider a page with a ScrollViewer in Gum:

![](../../../../media/2022-03-img\_623a6c4d39216.png)

To add an instance to the ScrollViewerInstance:

1.  Add an object as a child to the ScrollViewerInstance, by either drag+dropping the item in the tree view, or by manually setting the Parent of the child to ScrollViewerInstance.

    ![](../../../../media/2022-03-img\_623a6c8718e24.png)
2. Select the child
3. Scroll to find the Parent property
4.  Append **.InnerPanelInstance** to the parent name

    ![](../../../../media/2022-03-img\_623a6cd2209df.png)

Notice the dotted line shows the expansion of the InnerPanelInstance. Also, the reason we append **.InnerPanelInstance** is because we want to attach to the InnerPanelInstance inside the ScrollViewerInstance, and InnerPanelInstance is the name of the panel, as is shown if the ScrollViewer is selected in Gum.

![](../../../../media/2022-03-img\_623a6ddb9e16a.png)

### Example - Adding to InnerPanel in Code

Controls can be added to the InnerPanel in code. The following code shows how to create and add 20 ColoredRectangle of random color to an Inner Panel.

```lang:c#
var random = FlatRedBallServices.Random;

// It's common to have the InnerPanel
// automatically stack its children, so we'll
// set it to not stack. This isn't necessary
// If you've set the ChildrenLayout in Gum:
scrollViewer.InnerPanel.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;

for(int i = 0; i < 20; i++)
{
    var rect = new GumRuntimes.ColoredRectangleRuntime();
    rect.Width = 40;
    rect.Height = 40;

    rect.Red = random.Next(255);
    rect.Green = random.Next(255);
    rect.Blue = random.Next(255);

    rect.X = random.Next(50);
    rect.Y = i * 50;

    rect.Parent = scrollViewer.InnerPanel;
}
```

The code above will produce the following ScrollViewer: 

<figure><img src="../../../../media/2017-12-2017-12-24\_18-58-12.gif" alt=""><figcaption></figcaption></figure>



### Example - Expanding Stacking ScrollViewer in Code

ScrollViewers are often used to display a stack of UI. This can be accomplished by modifying the following InnerPanel variables:

* Height = 0 (or a small positive number for a border)
* HeightUnits = RelativeToChildren
* ChildrenLayout = TopToBottomStack

This can all be done in Gum or code. The following code example shows how to do this all in code:

```lang:c#
scrollViewer = TutorialScreenGum
    .GetGraphicalUiElementByName("ScrollViewerInstance")
    .FormsControlAsObject as ScrollViewer;

// Setting Height, HeightUnits, and ChildrenLayout can be done in Gum or code:
scrollViewer.InnerPanel.Height = 0;
scrollViewer.InnerPanel.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
scrollViewer.InnerPanel.ChildrenLayout = Gum.Managers.ChildrenLayout.TopToBottomStack;

for(int i = 0; i < 10; i++)
{
    var buttonRuntime = new GumRuntimes.ButtonRuntime();
    buttonRuntime.Text = $"Button number {i}";
    buttonRuntime.Parent = scrollViewer.InnerPanel;
}
```



<figure><img src="../../../../media/2017-12-2017-12-24\_19-18-14.gif" alt=""><figcaption></figcaption></figure>

 &#x20;
