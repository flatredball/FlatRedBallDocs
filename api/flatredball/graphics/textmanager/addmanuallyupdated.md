# addmanuallyupdated

### Introduction

The AddManuallyUpdated method adds the argument Text to the TextManager to be drawn. A manually updated Text does not have any of its ever-frame behavior performed by the TextManager, so changes to the Text must be manually applied. Manually updated Texts can be used in situations where a Text does not change after it has been created, or where only a small subset of properties change every frame, so manual updating can selectively update these variables for a performance boost.

### Code Example

The following code shows how to create 1000 manually updated Texts. It uses a large number of Text instances to show the performance benefit of using manually updated Texts.

```lang:c#
int numberOfTexts = 1000;
for(int i = 0; i < numberOfTexts; i++)
{
    var manuallyUpdatedText = new Text();

    // Position the text randomly in view so all Text instances are
    // scattered
    Camera.Main.PositionRandomlyInView(manuallyUpdatedText, 40, 40);

    // Shift to the left 150 pixels to make room for FPS display
    manuallyUpdatedText.X -= 150;

    // Set the DisplayText
    manuallyUpdatedText.DisplayText = "Text " + i;

    // Set the size of the text so it renders at pixel-perfect resolution
    manuallyUpdatedText.SetPixelPerfectScale(Camera.Main);

    // Add the text to the TextManager, using AddManuallyUpdated
    // so that the text is only drawn, and not automatically updated
    TextManager.AddManuallyUpdated(manuallyUpdatedText);

    // Call ForceUpdateDependencies to apply all changes
    // (such as position, size, and DisplayText) to the text
    manuallyUpdatedText.ForceUpdateDependencies();
}
```

On an i7 (in 2018) this code renders at around 464 frames per second, as shown in the following screenshot:

![](../../../../../media/2018-08-img_5b7cbd967850d.png)

By contrast, calling AddText instead of AddManuallyUpdated  results in a framerate of around 150 frames per second.

#### ForceUpdateDependencies

The ForceUpdateDependencies  call is required to update a Text  object according to its properties so that it renders properly. Normally this call is not needed because the engine calls it automatically, but in the code above we must call it after setting all properties to apply the values to the Text object. Notice that any changes made to the Text object after calling ForceUpdateDependencies  will not apply on manually-updated Text  instances. For example, changing the DisplayText  after calling ForceUpdateDependencies  will not change the string that the Text  object is displaying.

#### UpdateInternalRenderingVariables

FlatRedBall introduced a new method to the Text object: UpdateInternalRenderingVariables . This function will update the internal rendering values just like ForceUpdateDependencies without also updating the object according to its parent's position and rotation. Using UpdateInternalRenderingVariables  can be slightly faster if the Text being updated is not attached to another object (such as an entity).
