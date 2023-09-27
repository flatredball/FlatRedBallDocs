## Introduction

A screen's CustomInitialize  is the first method which is called when a screen is created. It is called before the screen performs any rendering, but after all of the screen's content has been loaded and after the screen's Glue objects have been initialized. CustomInitialize can be used to perform any logic-based initialization - as opposed to initialization which is always the same and can be performed in Glue. Examples of common types of initialization include:

-   Loading environment/background content such as a .png or Tiled level depending on the currently selected level.
-   Creating entities in a list which depend on game logic, such as the number of placers in a level or the number and placement of enemies
-   Loading content from disk, such as a player's profile at the start of a game
