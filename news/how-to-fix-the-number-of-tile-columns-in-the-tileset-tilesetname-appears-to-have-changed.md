FlatRedBall integrates closely with the fantastic tilemap program Tiled. If you've ever resized a PNG file, then you may have received a message notifying you that the number of columns in the tileset have changed. ![](/media/2022-01-img_61d06e29a3533.png) Tiled is notifying you that the tileset was originally created with a PNG which had a different size compared to its size now. Unfortunately, clicking **Yes** may result in unexpected (and broken) results. [![](/wp-content/uploads/2022/01/01_08-08-56.gif)](/wp-content/uploads/2022/01/01_08-08-56.gif) Fortunately a solution exists to this problem. If you have clicked **Yes** you will need to undo your changes by closing Tiled without saving your file. If you have saved your file, you will need to revert it in Git (or whatever version control program you are using). Unfortunately if you do not have a way to undo your changes, your file may be permanently corrupted. To solve the problem:

1.  Click **No** on the popup

    ![](/media/2022-01-img_61d06f18d7bb3.png)

2.  Select whichever tileset references the resized PNG

    ![](/media/2022-01-img_61d06f4febc16.png)

3.  Click the Edit button to edit the tileset

    ![](/media/2022-01-img_61d06f7ccd988.png)

4.  Make a change to the tileset. The change doesn't matter, as it will be undone- a change is needed so that Tiled will let you re-save the tileset (TSX) file. For example, change the Type of one of the tiles.

    ![](/media/2022-01-img_61d07002e74ab.png)

5.  Save the tileset (TSX) file

    ![](/media/2022-01-img_61d07035c2579.png)

6.  Undo the change to the Type (or whatever change you made earlier to save the file)

    ![](/media/2022-01-img_61d07070b406c.png)

7.  Save the tileset (TSX) file again

After performing these steps, your map will still look like it did before, but Tiled will no longer ask you about the number of columns changing. Also if you look at the TSX file in a diff program, you will some of the values in the TSX have changed.

![](/media/2022-01-img_61d0711be72ba.png)

Once this change has been made, the map should render correctly in FlatRedBall as well.

![](/media/2022-01-img_61d07153a56b7.png)

 
