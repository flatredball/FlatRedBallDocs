# scrollbar

### Introduction

Scrollbar is a common control used when scrolling is needed to display information. ScrollBars are included in other standard FlatRedBall.Forms controls such as ListBox and ComboBox, but they can be used in custom controls as well. [![](../../../../media/2017-12-2017-12-24\_07-28-34.gif)](../../../../media/2017-12-2017-12-24\_07-28-34.gif)

### Layout Requirements

The ScrollBar control requires:

* An object named **UpButtonInstance** which implements the ButtonBehavior (is a Button)
* An object named **DownButtonInstance** which implements the ButtonBehavior (is a Button)
* An object named **ThumbInstance** which implements the ButtonBehavior (is a Button)

Although not required, the following is strongly recommended:

* An object of any name (typically **TrackInstance**) which contains the **ThumbInstance**

![](../../../../media/2017-12-img\_5a4461d95f26f.png)

### ThumbInstance and TrackInstance

The thumb in a Slider visually represents the Value variable. FlatRedBall.Forms will automatically adjust the height of the thumb according to the ViewportSize, Minimum, and Maximum variables, therefore the thumb should use a visual element which does not distort when scaled vertically (such as a NineSlice or ColoredRectangle). The thumb will always be contained vertically within the track, and the thumb can move and extend to the edges of the track. Therefore, usually the track should not overlap the up and down buttons.

### Element Visibility

Although the thumb, up button, and down button are required, they do not need to be visible. Certain styles of scroll bars do not include up and down buttons - especially of the game is not controlled with a mouse. In this case the up and down buttons can be set to invisible.  If the buttons are invisible a track is not necessary - the thumb can be a direct child of the component. Unlike the Slider control, the track will always be fully contained within its parent object, so a track is only necessary to add padding between the track and the edge of the Slider control.

![](../../../../media/2017-12-img\_5a44668515c69.png)

### Minimum, Maximum, ViewportSize, and Value

The four values which are used to control the scrollbar behavior are:

* Minimum - The smallest number for Value
* Maximum - The largest number for Value
* ViewportSize - The size of the thumb, where the ViewportSize plus the value range equals the entire range (see below for an example)
* Value - The current value, with inclusive minimum and maximum values of Minimum and Maximum

For example, the four values can be set as shown in the following code:

```lang:c#
var scrollBar = TutorialScreenGum
    .GetGraphicalUiElementByName("ScrollBarInstance")
    .FormsControlAsObject as ScrollBar;

scrollBar.Minimum = 0;
scrollBar.Maximum = 100;
scrollBar.ViewportSize = 100;
scrollBar.Value = 100;
```

This can be visualized as shown in the following image:

![](../../../../media/2017-12-img\_5a3fe8c2bd996.png)

Keep in mind that these values do not change the height of the ScrollBar. This is controlled by the Height property just like every other FlatRedBall.Forms control, and it is subject to sizing variables just like all other Gum objects.

### SmallChange and LargeChange Values

SmallChange and LargeChange control how the ScrollBar's Value changes in response to UI events. SmallChange controls the change in Value when the up or down buttons are clicked. LargeChange controls the change in Value when the mouse is clicked on the track (the area between the up/down buttons and the thumb. The following example code shows how to assign the SmallChange and LargeChange variables:

```lang:c#
scrollBar.Minimum = 0;
scrollBar.Maximum = 100;
scrollBar.ViewportSize = 30;
scrollBar.Value = 100;
// This means it requires 10 button clicks to 
// go from the Minimum to Maximum values:
scrollBar.SmallChange = 10;

// This means that clicking the track will
// change the value approximately 1/3 of the
// way between the Minimum and Maximum
scrollBar.LargeChange = 30;
```

This code produces the behavior shown in the following animation: [![](../../../../media/2017-12-2017-12-24\_11-09-14.gif)](../../../../media/2017-12-2017-12-24\_11-09-14.gif)

###
