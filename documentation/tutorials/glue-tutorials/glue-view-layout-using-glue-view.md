# glue-view-layout-using-glue-view

### Introduction

Glue View can help you create Entity layouts in Screens, such as when creating UI and HUD screens. Since Glue View will immediately react to changes made to an object's variables, you can treat it as a real-time editor.

### Creating a Layout

This tutorial will use the a Button Entity which can be found [here on GlueVault.com](http://www.gluevault.com/entity/24-2d-low-resolution-brown-button). For information on importing Entities, see [this page](../../../frb/docs/index.php). Once you have imported the Entity you will need to create a Screen. Once you have a Screen and the Button Entity in your game:

1. Click+drag the Button Entity into your Screen
2. Repeat the above step until you have four (4) Button instances in your Screen
3. Select your Screen
4. Launch Glue View
5. Change the view to "Default2D"

![ButtonsInGlueView.png](../../../media/migrated\_media-ButtonsInGlueView.png) Now that you have four buttons in your Screen, you can edit them and you should see changes immediately show up in GlueView. To modify the first Button:

1. Select "ButtonInstance"
2. Change X to 100
3. Change Y to 64
4. Change DisplayText to "Start Game"

To modify the second Button:

1. Select "ButtonInstance2"
2. Change X to 100
3. Change DisplayText to "Multi-Player"

To modify the third Button:

1. Select "ButtonInstance3"
2. Change X to 100
3. Change Y to -48
4. Change ScaleY to 16
5. Change DisplayText to "Options"

To modify the fourth Button:

1. Select "ButtonInstance4"
2. Change X to 100
3. Change Y to -80
4. Change ScaleY to 16
5. Change DisplayText to "Exit"

![ButtonLayoutGlueView.png](../../../media/migrated\_media-ButtonLayoutGlueView.png)
