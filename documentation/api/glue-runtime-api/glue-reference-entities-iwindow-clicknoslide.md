## Introduction

The ClickNoSlide event is an event which is raised when the user presses and releases the mouse button or presses and releases on a touch screen without sliding. This method is useful for touch screen games which use sliding as a valid form of input. If a regular Click method is used instead of ClickNoSlide, then pushing, sliding, and releasing on a UI element may be mistakenly interpreted as a click.

## Additional Information

The ClickNoSlide method uses the [Cursor's PrimaryClickNoSlide](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.PrimaryClickNoSlide "FlatRedBall.Gui.Cursor.PrimaryClickNoSlide") property.
