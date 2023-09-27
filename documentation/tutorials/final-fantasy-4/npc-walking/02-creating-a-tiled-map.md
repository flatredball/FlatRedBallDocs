## Introduction

Next we'll be creating a map for our NPCs. This tutorial will begin with a map which already has visuals from Final Fantasy 4. We will import this map and add solid collision to prevent the NPCs from walking through walls and buildings.

## Downloading the Map

Normally we begin working with Tiled map files (.tmx extension) created for us by the Glue Wizard. This time, we'll replace the file in Level1 with one we download. This level requires downloading three files:

1.  [tiles.png](https://github.com/vchelaru/FlatRedBall/blob/NetStandard/Samples/FinalFantasy2/tiles.png?raw=true) - The PNG containing the tiles for our map
2.  [FinalFantasyTileset.tsx](https://raw.githubusercontent.com/vchelaru/FlatRedBall/NetStandard/Samples/FinalFantasy2/FinalFantasyTileset.tsx) - The tileset referenced by the main visual layer in the map
3.  [CustomTown.tmx](https://raw.githubusercontent.com/vchelaru/FlatRedBall/NetStandard/Samples/FinalFantasy2/CustomTown.tmx) - The Tiled Map File

Download all three files to the same location - we will need all of them or the TMX will not load properly.

## Replacing the Existing Map

The Glue Wizard from the previous tutorial added a file called Level1Map to our Level1 Screen.

![](/media/2021-03-img_6057aada391cc.png)

We will be replacing this with the CustomTown.tmx file downloaded earlier. To do this:

1.  Right-click on **Level1Map.tmx**

2.  Select ****Remove from Screen****

    ![](/media/2021-03-img_6057ab34b61e4.png)

3.  If notified about the broken Map object, click OK - we'll fix this in the next few steps

    ![](/media/2021-03-img_6057ab79561f1.png)

4.  Drag+drop the downloaded **CustomTown.tmx** file into **Level1** **Files** in Glue. Glue will automatically copy the other files which are referenced by CustomTown.tmx to your project, so you only need to include that one file. [![](/wp-content/uploads/2021/03/2021_March_21_142825.gif.md)](/wp-content/uploads/2021/03/2021_March_21_142825.gif.md)

5.  Drag+drop CustomTown.tmx from the Files folder onto the Map object in Level1 [![](/wp-content/uploads/2021/03/2021_March_21_141127.gif.md)](/wp-content/uploads/2021/03/2021_March_21_141127.gif.md)

The game now runs and will display this map.

![](/media/2021-03-img_6057ac52c97e4.png)

## Adding Solid Collision

The map that we dropped into our game (**CustomTown.tmx)** does not have any collision. We need to add collision to it so that our NPCs are prevented from walking through walls, buildings, and trees. To do this:

1.  Double-click the TMX file to open it in Tiled

2.  Return to Glue and click the Folder icon to open the project folder

    ![](/media/2021-03-img_6057adfc033c6.png)

3.  Open the **Content** folder for your project

    ![](/media/2021-03-img_6057ae385faf8.png)

4.  Drag+drop StandardTileset.tsx onto Tiled to access this tileset in your map [![](/wp-content/uploads/2021/03/2021_March_21_140637.gif.md)](/wp-content/uploads/2021/03/2021_March_21_140637.gif.md)

5.  Add a new layer to the map called **GameplayLayer [![](/wp-content/uploads/2021/03/2021_March_21_144339.gif.md)](/wp-content/uploads/2021/03/2021_March_21_144339.gif.md)**

6.  Use the solid collision tile (top left tile) to paint solid collision on the map to block the NPC from walking over walls, buildings, pots, and trees. Make sure to add these tiles to the Gameplay layer - adding them to the existing visual layer will remove the visuals and will also cause the game to crash. FlatRedBall does not support multiple tilesets on a single layer.

    ![](/media/2021-03-img_6057afb736a34.png)

Don't forget to save the TMX after adding the solid collision. Since we used the standard tileset file, and since we drag+dropped the TMX file onto our Map object, the game will automatically create solid collision for us wherever we add brick tiles. We can verify this by checking the Visible property on the SolidCollision in our GameScreen.

![](/media/2021-03-img_6057b0a3b822e.png)

If we run the game we'll see the white squared representing the SolidCollision object.

![](/media/2021-03-img_6057b0c8de3cc.png)

## Conclusion

This tutorial showed how to add a custom map to our game, add GameplayLayer for standard tiles, and verify that solid collision has been created. The next tutorial will add an NPC with random walking behavior.  
