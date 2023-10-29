## Introduction

The Slider control can be used to set a value between a minimum and maximum value. For example, Sliders can be used to set color values in a game tool. [![](/media/2017-12-2017-12-24_19-44-32.gif)](/media/2017-12-2017-12-24_19-44-32.gif)

## Layout Requirements

The Slider control requires:

-   An object named **ThumbInstance **which implements the ButtonBehavior (is a Button)

![](/media/2017-12-img_5a44622e8921e.png)

Note that the current implementation of FlatRedBall.Forms only supports a horizontal slider, so the Gum component should be laid out such that the thumb can move left and right.

## ThumbInstance and Container Relationship

The thumb represents the Slider's Value. It can be moved by clicking + dragging the thumb or by clicking on the *track* (the thumb's parent). The thumb's parent may be the component itself, or it may be a Container instance within the component. If an explicit track is used, we recommend naming it **TrackInstance**. While this is not required by the Slider control, Sliders may not behave correctly if not naming the track **TrackInstance**.

![](/media/2017-12-img_5a44634ad3d4a.png)

A track parent of the thumb can be used to control the visual bounds of the thumb by placing a padding between the min/max values and the edges of the component.

## X Origin and Thumb Position

The thumb's minimum and maximum X position will be defined by its parent's bounds. For example, the following diagram shows the minimum and maximum position of the thumb inside a Slider with no explicit track container:

![](/media/2017-12-img_5a443e7253393.png)

Notice that the thumb's width is not considered when setting the mins and maxes. The min and max positions can be made symmetric by changing the Thumb's **X Origin** to Center. Furthermore, the edges of the thumb can be kept within the bounds of the component by adding a track. Otherwise, parts of the thumb may fall outside of the component where the clicks are ignored. The following image shows the minimum and maximum position of a thumb using **X Origin** of **Center** and an explicit Track container:

![](/media/2017-12-img_5a443fa5901f9.png)

Keep in mind that the track need not be centered inside the component. It can be offset to account for an asymmetric thumb, or to allow for additional visuals besides the track.

## Using RaiseChildrenEventsOutsideOfBounds to Enable Grabbing the Thumb

As shown above, the thumb can be added as a child of a container to control its minimum and maximum X position. Doing so, along with setting the X Origin to Center is a common way to create a Slider, but this does introduce a subtle problem. By default, a cursor must overlap a visual element for its children to also be tested. If a child is not fully contained inside of its parent, then part of it may not receive cursor events. For example, consider the image above. Notice that the thumb is is not fully contained in its parent's bounds. Part of the thumb hangs over the edge of its parent as shown in green.

![](/media/2020-09-img_5f73cd5aaaa65.png)

The user may expect to be able to click+drag the thumb by grabbing it when it hangs over the container parent, but this will not work. To solve this problem, the parent's **RaiseChildrenEventsOutsideOfBounds** can be set to true in the gum runtime's custom code. For example, if your slider Gum object is called SliderRuntime , and if the thumb's parent is called ContainerInstance , the following code can be used to enable grabbing the thumb even if it hangs over the edge of its parent:

``` lang:c#
public partial class SliderRuntime
{
    partial void CustomInitialize () 
    {
        ContainerInstance.RaiseChildrenEventsOutsideOfBounds = true;
    }
}
```

## Minimum, Maximum, and Value

The Value variable represents the current value in the scroll bar, which falls between the Minimum and Maximum values inclusively. By default there is no visual representation of the value, so it can be printed out to screen using the FlatRedBall Debugger. The following code example shows how to set a a Slider to display values between 0 and 100, and to output them in real time.

``` lang:c#
Slider slider;

void CustomInitialize()
{
    slider = TutorialScreenGum
        .GetGraphicalUiElementByName("SliderInstance")
        .FormsControlAsObject as Slider;

    slider.Minimum = 0;
    slider.Maximum = 100;
}
void CustomActivity(bool firstTimeCalled)
{
    FlatRedBall.Debugging.Debugger.Write(slider.Value);
}
```

[![](/media/2017-12-2017-12-24_19-52-10.gif)](/media/2017-12-2017-12-24_19-52-10.gif)

## ValueChanged

The ValueChanged event is raised whenever the Value property is changed on a slider. The ValueChanged event enables writing logic to respond to the changed slider only when the value changes. The FlatRedBall Debugger.CommandLineWrite method is used to display the value when it changes.

``` lang:c#
Slider slider;
void CustomInitialize()
{
    slider = TutorialScreenGum
        .GetGraphicalUiElementByName("SliderInstance")
        .FormsControlAsObject as Slider;

    slider.Minimum = 0;
    slider.Maximum = 100;

    slider.ValueChanged += HandleValueChanged;
}

private void HandleValueChanged(object sender, EventArgs e)
{
    FlatRedBall.Debugging.Debugger.CommandLineWrite(slider.Value);
}
```

[![](/media/2017-12-2019_December_06_071242.gif)](/media/2017-12-2019_December_06_071242.gif)

## TicksFrequency

TicksFrequency can be used to snap values rather than allowing every value between Minimum and Maximum. TicksFrequency is a numeric value specifying the snapping value. It only applies if IsSnapToTickEnabled is set to true. The following code can be added to the example above to snap the values to whole numbers:

``` lang:c#
slider.IsSnapToTickEnabled = true;
slider.TicksFrequency = 1;
```

[![](/media/2017-12-2017-12-24_20-07-06.gif)](/media/2017-12-2017-12-24_20-07-06.gif)

## IsMoveToPointEnabled

If IsMoveToPointEnabled is set to true then clicking on the track will move the thumb to the clicked point, rather than moving the thumb up or down the Slider by the LargeChange value.

``` lang:c#
slider.IsSnapToTickEnabled = true;
slider.TicksFrequency = 1;
slider.IsMoveToPointEnabled = true;
```

[![](/media/2017-12-2017-12-24_20-13-28.gif)](/media/2017-12-2017-12-24_20-13-28.gif)

## SmallChange

The SmallChange property controls the change in value when pressing left or right when the Slider is focused and is controlled by a GamePad. For example, the following code produces the behavior shown in the animation:

    MusicSlider.Minimum = 0;
    MusicSlider.Maximum = 1;
    MusicSlider.SmallChange = .1;

[![](/media/2017-12-02_11-27-57.gif)](/media/2017-12-02_11-27-57.gif)
