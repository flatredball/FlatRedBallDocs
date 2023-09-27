FlatRedBall Glue has always been a program for improving the speed of game development. The [latest version](/download.md) includes a wizard which greatly simplifies new project setup. Previously, even as recent as a month ago, setting up a new project with levels, a player entity, collision, and [tiled map files](https://www.mapeditor.org/) could take an experienced FlatRedBall user over an hour. For new users, this process could take days. The new wizard standardizes the setup, and new projects can be created in under a minute!

## Running the Wizard

To run the new Glue Wizard, you need to first create a new project. Once the project template has been downloaded, Glue has a **Run Glue Wizard** button.

![](/media/2021-03-img_603f033ac2687.png)

Just click the button and the wizard will open.

![](/media/2021-03-img_603f035fc1bac.png)

## Choosing Player Control Type

FlatRedBall projects include *entities* - game objects such as the player, enemies, and power ups. Most games include a *Player* entity, such as a platformer or top-down character. The new wizard provides a page dedicated to the creation of this Player entity. For the most part, the defaults can be left unchanged. The most important option is which type of entity control you would like. Currently the two options are **Top-down** and **Platformer**.

![](/media/2021-03-img_603f04aa5c9ab.png)

## What's Included?

Once you finish the wizard, Glue will apply all of the selected options and create a fully functional game. Games which accept all of the defaults will have:

-   A base GameScreen set up with collision and a common Map object which references the [Tiled map file](https://www.mapeditor.org/) for the current level. The Tiled program is used to create tile-based levels in your game.
-   Solid collision objects and a collision relationship between the solid collision and all Players. Solid collision prevents the player from moving beyond the bounds of the level and can be used as walls to control game play.
-   A fully-functional top-down or platformer entity. This is the Player entity which can be controlled with the keyboard or Xbox gamepad
-   Multiple levels, each with their own [Tiled map file](https://www.mapeditor.org/) and a standard gameplay tileset for quick level creation
-   [Gum](http://gumui.net/) and [FlatRedBall.Forms](/documentation/tutorials/flatredball-forms.md) for UI and HUD. Gum is a visual tool for creating UI and HUD, and FlatRedBall.Forms provides functionality for standard UI controls such as Button, TextBox, and ListBox.
-   A camera which follows all Players and stays within the bounds of the level. This behavior can be customized, but the defaults are good enough for starting most games.

![](/media/2021-03-img_603f0653c1e3f.png)

In other words, this has all of the pieces needed to get your game developed even faster.

## How Fast Can You Make a Game?

[![](/wp-content/uploads/2021/03/2021_March_03_104340.gif.md)](/wp-content/uploads/2021/03/2021_March_03_104340.gif.md) It's currently available in the latest build of FlatRedBall so download it and give it a shot!  
