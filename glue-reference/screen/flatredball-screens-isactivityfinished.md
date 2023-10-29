## Introduction

The IsActivityFinished property is a property which can be set to true to tell the given Screen that it should no longer be active. Setting IsActivityFinished to true can do a number of things depending on the state of the Screen:

-   If the Screen is the ScreenManager's CurrentScreen, then this method will result in the ScreenManager moving to the Screen's NextScreen.
-   If the Screen is a Popup Screen, then the Screen will simply destroy itself and remove itself from its parent's mPopups list.
-   If the Screen is loading another Screen asynchronously, then setting IsActivityFinished to true will destroy the current Screen and move to the asynchronously-loaded Screen.
