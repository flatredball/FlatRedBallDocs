# GameScreen

### Introduction

The GameScreen is where the main gameplay for a game takes place. FlatRedBall games are not required to have a screen named GameScreen, but most FlatRedBall games use this convention. If you have created your game using the New Project Wizard, then your game will have a GameScreen.

If a game has multiple levels, then the GameScreen serves as the base screen for each level. Each level would be its own Screen in the FlatRedBall Editor.

Games which do not have multiple levels (such as a chess game) would have the main gameplay take place in the GameScreen without any derived level Screens.

### Examples of GameScreen

The GameScreen/Level pattern makes it easy to add multiple levels to your game. If you have created a project using the platformer or top down template, then your game is already set up to have two levels: Level1 and Level2. Levels screens may map to actual levels in your game, or they may map to sections in the game which have their own Tiled map but which are not necessarily recognized as new levels by the player.

The word _level_ is used for convenience, but each level screen does not necessarily need to correspond to an actual level in your game. Typically each level screen references a single TMX file. Therefore, your game may have multiple level screens for a single game level. Some games may not even have explicit levels. For example, games like Super Metroid do not define their areas as _levels,_ but each area may be represented as a level screen in FlatRedBall.

Therefore, here are some examples of Level screens as they might exist in some popular Super Nintendo games:

Super Mario World - Levels could be broken up to be one Screen per actual level, or mulitple screens could be used per level for secret areas and underground sections

* YoshisHouse
* YoshisIsland1 (the level name, not to be confused with the game)
* DonutPlains1
* DonutGhostHouse
* YellowSwitchPalace

Super Metroid - Each level might be a section as broken up by doors. When transitioning through doors, one level is unloaded, and the next is loaded

* CrateriaOutdoor
* CrateriaBossStatueRoom
* BrinstarVerticalRoom
* NorfairCrocomireRoom

F-Zero - Each race would be one level Screen

* MuteCity1
* BigBlue
* SandOcean
* DeathWind1

### GameScreen Inheritance

Games which include multiple levels typically define one TMX per level. The GameScreen defines a Map object which indicates that a Tiled map will be loaded by each screen, but the individual level Screens specify which level to load.

Therefore, the Map object in a typical GameScreen has its SetByDerived property set to true, which means that the GameScreen expects the derived levels to assign this property using their respective TMX files.

<figure><img src="../../.gitbook/assets/image (186).png" alt=""><figcaption><p>Map SetByDerived</p></figcaption></figure>

Each Level should have a TMX file, and that TMX file should then be used to create the Map object. This can be observed by selecting the Map object in a Level screen and looking at its properties:

<figure><img src="../../.gitbook/assets/image (187).png" alt=""><figcaption></figcaption></figure>
