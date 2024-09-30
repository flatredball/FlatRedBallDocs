# Gum Properties Tab

### Introduction

The Gum Properties Tab provides access to common properties and actions for the entire Gum project. It can be accessed by selecting the Gum project (usually **GumProject.gumx** in **Global Content Files**), then selecting the **Gum Properties** tab.

![](../.gitbook/assets/2020-07-img\_5f18e9ed6e06d.png)

Note that if you do not have a GumProject.gumx in Global Content Files, you need to add a Gum project first. The easiest way to do this is to click the Gum icon in the toolbar.

### Automatically Create Gum Screens for Glue Screens

If checked, this property will automatically create a new Gum screen whenever a Glue screen is created. The newly-created Gum screen will be part of the Gum project and will be automatically added to the Glue screen. In other words, once created the screen is fully integrated into the project.

![](../.gitbook/assets/2020-07-img\_5f18ec04232d4.png)

The Gum screen will be named the same as the Glue screen with the word "Gum" appended. For example, if GameScreen is added, then it will contain GameScreenGum. **Gum Screens and Inheritance** Although both Glue and Gum screens support inheritance, Gum screens in derived Glue screens will not inherit from the base Gum screen. The reason for this is because the base screen will always load its Gum screen. If the derived Glue screen contained a derived Gum screen, then objects in the base Gum screen would be loaded twice. To understand this, we can consider an example with two Glue screens:

* GameScreen (the base Glue screen)
* Level1 (the derived Glue screen)

In this case, GameScreen will have a Gum screen called GameScreenGum, and it will always load this screen even if the actual screen created is the derived Level1. Therefore, if Level1 is loaded, then both of the Gum screens are loaded: GameScreenGum and Level1Gum. If Level1Gum inherited from GameScreenGum, then all of the contents in GameScreenGum would get created twice at runtime.
