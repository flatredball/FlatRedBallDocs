# ClickNoSlideThreshold

The ClickNoSlideThreshold value is measured in pixels which determines if a releasing the mouse or touch screen should be treated as a ClickNoSlide. If the distance moved since the last push is less than ClickNoSlideThreshold, then the PrimaryClickNoSlide property is true for that frame. Otherwise, only the Click property is true.

If this value is increased, then the Cursor reports clicks even if the user has moved the cursor slightly since pushing the cursor (or touching the screen). If this value is reduced, then clicks will not register as often if the cursor has moved slightly since touch. This value primarily exists to help distinguish between actual push/release vs. push+slide. Since this value is in pixels it may need to be increased for high-resolution touch screens.
