# how-to-work-with-screens-in-code

### Introduction

Gum screens which are part of a FlatRedBall project generate a custom class. This custom class provides access to all contained objects within the screen. While it is possible to also interact with the elements in a general way (by name), using the typed properties in a screen is usually safer and more convenient.

### Initial Setup

To write code against a Gum screen, you must first have:

* A Glue project
* A Gum project inside the Glue project
* A Glue screen (we'll call it GameScreen)
* A Gum screen (we'll call it GameScreenGum)
* The Gum screen file referenced by the Glue screen

Note: Once you add a Gum project to your Glue project, Glue will automatically add new Gum screens for each Glue screen. This functionality can be controlled by selecting the .gumx file in Glue:

![](../../../media/2020-02-img\_5e43122d7e020.png)

If you have already created Glue screens and Gum screens, but the two are not associated, you can right-click on the Files of any Screen to add an existing Gum screen: ![](../../../media/2020-02-img\_5e431272d0637.png) Regardless of which method is used, the result is a Gum screen that is using a specific, generated class, as can be seen in Glue:

![](../../../media/2020-02-img\_5e43145966d3f.png)

### Accessing Objects in Code

The Gum screen object can be accessed in code just like any other object. All contained objects in a Gum screen are accessible through properties on the Gum screen. For example, consider the following Gum screen:

![](../../../media/2020-02-img\_5e4313383de58.png)

These can be accessed in code using the names of the objects from Gum:

![](../../../media/2020-02-img\_5e4313fdc956a.png)

&#x20; &#x20;

###
