# PrimaryClick

### Introduction

The PrimaryClick property returns whether the Cursor has been clicked this frame. A click is defined as:

* [PrimaryDown](../../../../frb/docs/index.php) was true last frame and...
* PrimaryDown is false this frame

This occurs if the user pushes and releases the left moue button or touches and lifts on the touch screen. If developing games which may use a touch screen, you should consider [PrimaryClickNoSlide](../../../../frb/docs/index.php) to differentiate between when the user touches and releases in the same spot vs. when the user touches, slides, then releases.

### Example

The cursor can be checked to see if a click occurred in any CustomActivity code. The following code creates a Circle wherever the user clicks:

```csharp
if(GuiManager.Cursor.PrimaryClick)
{
    var circle = new Circle();
    circle.Visible = true;
    circle.X = GuiManager.Cursor.WorldXAt(0);
    circle.Y = GuiManager.Cursor.WorldYAt(0);
}
```

<figure><img src="../../../../.gitbook/assets/2016-01-2017-12-14_08-49-02-1.gif" alt=""><figcaption><p>Creating circles by clicking the cursor primary button</p></figcaption></figure>
