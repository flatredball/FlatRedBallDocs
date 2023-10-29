## Introduction

The Map object is a standard object created by the FlatRedBall Wizard. The Map object is defined in the GameScreen but is also available

## Map in GameScreen

Typically the Map object is a LayeredTileMap defined in the GameScreen and has its SetByDerived property to true.

![](/media/2021-10-img_617962df639e2.png)

If not using the wizard, the Map object is optionally created when adding a new GameScreen in a new project.

![](/media/2021-10-img_6179633f7273f.png)

Using a Map object is recommended, whether it is created through the wizard or the Add Screen dialog.

## Map in Level Screens

Level screens should also have a Map object. Each Level screen will automatically have a Map object since the Map object in the GameScreen has its **SetByDerived** set to **True**. By default new levels will have a TMX object added automatically.

![](/media/2021-10-img_617964cea8143.png)

When using the default options, a new level will have a TMX file in the Files folder and a Map object in the Map folder.

![](/media/2021-10-img_6179652d9aea5.png)

Under the default setup (as set up by the new screen dialog), the Map object in the level will reference the TMX file.

![](/media/2021-10-img_61796597f0fc4.png)

### Optional - Assigning Map to a TMX File

If your game does not have the Map object assigned to a TMX file you may need to manually make the connection between the object and the file. This can happen if you delete the default TMX file, or if you are manually adding the TMX file at a later time. To assign the Map object to use the TMX file, drag+drop the TMX File onto the Map object in your Level screen. [![](/media/2021-10-27_08-46-19.gif)](/media/2021-10-27_08-46-19.gif) Alternatively, you can assign the Source properties on the map object: ![](/media/2021-10-img_61796597f0fc4.png)
