[FlatRedBall.Gui.Cursor](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.md "FlatRedBall.Gui.Cursor")

## Introduction

The PrimaryPushTime property returns the amount of time since the Cursor's PrimaryPush was last set to true. This value will return 0 if the PrimaryPush was just set, or if the Cursor's PrimaryDown is false. Otherwise, this value will be greater than 0. This value can be used to detect how long the mouse button has been pressed or the touch screen touched.

## Code Example

    if(Cursor.PrimaryPushTime > 1)
    {
      // The cursor's primary state has been on for longer than 1 second
    }
