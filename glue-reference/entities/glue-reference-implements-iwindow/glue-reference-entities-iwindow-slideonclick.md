## Introduction

The SlideOnClick event is an event that is raised when the user releases the cursor over a given IWindow, but only if the window was not initially clicked on. To contrast with Click, if the user both pushes and releases the cursor over an IWindow, then Click (or ClickNoSlide) will get raised. If the user pushes the cursor off of an IWindow, then releases it on the IWindow, then SlideOnClick is raised.

## Common usage

SlideOnClick is commonly used for drag+dropping elements onto an IWindow.
