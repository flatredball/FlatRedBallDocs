# RaiseChildrenEventsOutsideOfBounds

### Introduction

The RaiseChildrenEventsOutsideOfBounds property determines whether to check for children events outside of a control's bounds. By default this is false, which means that children will only be checked if the cursor is inside of the parent's bounds.

If this value is true on a parent, then its children are checked even if they are outside of its bounds. This is important if children are positioned outside of the bounds, but it can have a negative impact on performance.

Note that if this value is true, then out-of-bounds checks are only performed for the direct children of the parent - it does not result in recursive checking of bounds.

### Example - Checking Button Clicks

The following Gum layout shows a UI control UserControlInstance which has a button ButtonCloseInstance outside of its bounds.

<figure><img src="../../../.gitbook/assets/image (108).png" alt=""><figcaption><p>Control with a button outside of its bounds</p></figcaption></figure>

By default this button will not be clickable because it is not contained in the boudns of its UserControlInstance.

To enable clicking the button, the following code could be added to the FlatRedBall Screen's CustomInitialize:

```csharp
void CustomInitialize()
{
    GumScreen.UserControlInstance.RaiseChildrenEventsOutsideOfBounds = true;
}
```

<figure><img src="../../../.gitbook/assets/05_16 42 36.gif" alt=""><figcaption><p>Highlight and clicking working on a child positioned outside of its bounds</p></figcaption></figure>
