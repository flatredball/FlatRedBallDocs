## Introduction

IsOn returns whether the calling Cursor is over a given object. This function will not behave properly if the Camera is not viewing down the Z axis (default). If you have a rotated Camera, then you should use IsOn3D. This function does a position check - it does not consider if anything is covering the argument, or if the Cursor is over any other UI component. For more information on checking of the Cursor is over UI (as a test before performing IsOn checks), see the [WindowOver](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.WindowOver "FlatRedBall.Gui.Cursor.WindowOver") page.

## IsOn(Layer)

The IsOn overload which takes a Layer will check if the Cursor is over the argument Layer in screen coordinates. In other words, this function will behave properly even if the Camera is rotated. This function will simply do a check of the Cursor's screen position against the bounds of the Layer. If a Layer occupies the full screen, then this function will return true.
