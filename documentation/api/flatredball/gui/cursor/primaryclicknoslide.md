## Introduction

The PrimaryClickNoSlide property returns whether the Cursor has clicked (the primary button was down last frame, not this frame) and if the cursor has not moved more than [ClickNoSlideThreshold](/frb/docs/index.php?title=FlatRedBall.Gui.Cursor.ClickNoSlideThreshold "FlatRedBall.Gui.Cursor.ClickNoSlideThreshold") during the time the button was down. This property is often used on touch screens so that the game can differentiate between when the user intended to touch and release a UI element versus when a slide-release was performed.
