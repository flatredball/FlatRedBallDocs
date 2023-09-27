## Introduction

The ReadsGestures variable controls whether the FlatRedBall TouchScreen instance automatically reads gestures from the [XNA/MonoGame TouchPanel](http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.input.touch.touchpanel.aspx). This value is true by default. This means that game code will not be able to read from the native MonoGame's TouchPanel since FlatRedBall has already read the gestures (a read clears out the information). If you would like to use MonoGame code to read gestures, then set the ReadGestures to false.

## Code Example

You can read gestures either from XNA or FRB. The following two blocks of code show the two options you have for reading gestures:

### Reading gestures from FlatRedBall InputManager

    // ReadsGestures is true by default, but we'll include it here
    // to explicitly show that it must be true for LastFrameGestures
    // to contain anything.
    FlatRedBall.Input.InputManager.TouchScreen.ReadsGestures = true;
    foreach (var gesture in InputManager.TouchScreen.LastFrameGestures)
    {
        switch (gesture.GestureType)
        {
           // Add your code to react to gestures here...
        }
    }

### Reading gestures from MonoGame TouchPanel

      FlatRedBall.Input.InputManager.TouchScreen.ReadsGestures = false;
      while (TouchPanel.IsGestureAvailable)
      {
          GestureSample gesture = TouchPanel.ReadGesture();

          switch (gesture.GestureType)
          {
              // Add your code to react to gestures here...
          }
      }
