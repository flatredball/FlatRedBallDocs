# 02-creating-level1-map

### Introduction

Now that we have a basic project (with a Player instance falling off the screen) we can create our map. Our map will have:

* Solid collision to keep the player on screen
* Graphics so our tutorial project looks like a real game
* Tiles defining where to place our breakable Block instances

### Downloading the Map

The Glue Wizard created a Map in our Level1 screen, which is useful if we were going to make our levels from scratch. Instead, we'll use a TMX file to speed things up. Download the following three files to the same folder (such as your downloads folder):

1. [FRBPlatformer.png](https://github.com/vchelaru/FlatRedBall/raw/NetStandard/Samples/Platformer/BreakingBlocks/FRBPlatformer.png) - the PNG containing the art for our game
2. [FRBPlatformerTileset.tsx](https://github.com/vchelaru/FlatRedBall/raw/NetStandard/Samples/Platformer/BreakingBlocks/FRBPlatformerTileset.tsx) - the tileset for the visuals in our game
3. [Level1Map.tmx](https://github.com/vchelaru/FlatRedBall/raw/NetStandard/Samples/Platformer/BreakingBlocks/Level1Map.tmx) - the map for our game which has the pre-made visuals

### Replacing the Existing Map

Our game already contains a file named Level1Map.tmx - this is the default name of the TMX added to our Level1 Screen. We can replace this file on disk with the downloaded file. We need to remember to also copy over the other two files. To do this:

1. In Glue, expand **Level1 Files**
2. Right-click on **Level1Map.tmx**
3. Select **View in explorer** to open the containing folder

![](../../../../media/2021-04-img\_6074e12729024.png)

Once open, drag+drop the three downloaded files into the Level1 content folder. If asked, replace the existing file. [![](../../../../media/2021-04-2021\_April\_07\_232506.gif)](../../../../media/2021-04-2021\_April\_07\_232506.gif) Now our game will run and display the level, but our character still falls through the screen. We'll fix this next.

![](../../../../media/2021-04-img\_606e8fa420c15.png)

### Adding SolidCollision

Our map already has visuals for a platformer game, but no tiles are marked as solid collision. We will add the standard tileset to our map and create a new layer which defines solid collision. To do this:

1. Double-click the new Level1Map.tmx - either in the file explorer or in Glue
2. Return to Glue and click the Folder icon to open the project folder ![](../../../../media/2021-03-img\_6057adfc033c6.png)
3.  Open the **Content** folder

    ![](../../../../media/2021-04-img\_6074fe68b1397.png)
4. Drag+drop the StandardTileset.tsx in the Content folder onto Tiled to access this tileset in Level1Map.tmx [![](../../../../media/2021-04-2021\_April\_07\_234011.gif)](../../../../media/2021-04-2021\_April\_07\_234011.gif)
5. Add a new layer to the map called **GameplayLayer** [![](../../../../media/2021-04-2021\_April\_07\_235312.gif)](../../../../media/2021-04-2021\_April\_07\_235312.gif)
6.  Outline the solid collision areas in the level using the top-left brick tile to mark the SolidCollision tiles. Be sure to place these tiles on the GameplayLayer

    ![](../../../../media/2021-04-img\_606e9163bed38.png)

Don't forget to save the TMX file after adding the collision. Since we used the StandardTileset.tmx file, our game automatically uses these tiles for the SolidCollision TileShapeCollection, and our player can walk around the level. [![](../../../../media/2021-04-2021\_April\_07\_235518.gif)](../../../../media/2021-04-2021\_April\_07\_235518.gif) The GameplayLayer visibility can be toggled in Tiled. You may want this off at times to see the art of the game without the solid collision tiles blocking the visuals, or you may want it on to help diagnose issues.

![](../../../../media/2021-04-img\_606e92b32e2ac.png)

### Conclusion

Now that we have a functional level, we will create the Block entity. &#x20;
