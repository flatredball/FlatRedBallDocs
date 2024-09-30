# Adding Gum Screens to FlatRedBall

### Introduction

Many games include a Gum screen for every FRB screen. Gum screens can be used for UI such as buttons and textboxes (usually using FlatRedBall.Forms) or can be used for read-only UI such as score and health display. Screens can be added in a variety of ways, depending on the state of your project.

### Automatic Gum Screen Addition on New FRB Screen

If you have an existing project which already has a Gum project, then by default your project will receive a new Gum screen any time you add a new FRB screen.

<figure><img src="../.gitbook/assets/2021-05-2021_May_13_112104.gif" alt=""><figcaption></figcaption></figure>

This behavior is default, and it can be controlled by selecting the .gumx file.

![](../.gitbook/assets/2021-05-img\_609d5c7e6a6e3.png)

### Adding New Gum Screens to Existing FRB Screens

If you have a FRB screen which does not have an associated Gum screen (for example, if the Screen was created before adding Gum to your project), then you can tell FRB  to add a new Gum screen. To do this, select and right-click on the screen, and select the option to create a new Gum screen.

![](../.gitbook/assets/2021-05-img\_609d5d0248fe5.png)

This option will create a new Gum screen and add it both to your Gum project and to the current FRB screen. FRB follows the standard naming convention by appending the word "Gum" to your FRB screen name.

![](../.gitbook/assets/2021-05-img\_609d5d335f9a9.png)

### Adding an Existing Gum Screen to an Existing FRB Screen

If your project already has a Gum screen and a FRB screen and you would like to add the Gum Screen to the FRB screen, you can right-click on the Files and select the option to add the screen.

![](../.gitbook/assets/2021-05-img\_609d754e5fb91.png)
