# spriteeditor-file

### New Scene

* New Scene allows users to create a new scene. It clears everything out of the SpriteEditor's workspace.
* The SpriteEditor will prompt users to make sure that their course of action is the preferred one.

### Load Scene

* Load Scene loads a premade Scene into the SpriteEditor's workspace.
* Users will have the option of either replacing or inserting their premade Scene. Replacing causes the current workspace to be cleared, and inserting adds the premade content to the workspace.

### Load SpriteRig

* Load Sprite Rig loads a premade Sprite Rig into the SpriteEditor's workspace
* For more information on Sprite Rigs:
  * [http://www.flatredball.com/frb/docs/index.php?title=FlatRedBall.ManagedSpriteGroups.SpriteRig](../../../frb/docs/index.php)

### Save Scene

* Save Scene saves the current workspace of the SpriteEditor as a SpriteEditor XML Scene (.scnx) or as a SpriteEditor Binary Scene (.scn)
* If users have Sprites named the same, they are prompted to either leave the names as they are (which can cause attachment problems depending on what Sprites are in the workspace), automatically assign unique names to the Sprites, or cancel the save.

### Save SpriteRig

* Save Sprite Rig allows users to save the created Sprite Rig.
* Users will have the following options:
  * Include either the current group or the entire scene
  * Body Sprite Selection allows for the inclusion of either Name Includes (listing all of the desired inclusions by hand), By Texture, everything except Joints (All Not Joint), or everything (All).
  * Joint Sprite Selection allows for the inclusion of either Name Includes (listing all of the desired inclusions by hand), By Texture, everything except the body (All Not Body), or everything (All).
* Root Sprite allows the users to select the root of the desired Sprite Rig. Users can choose to either have no root selected, or select a root from an available Sprite.
* Lastly, users have the option to select the visibility levels of the Joints and Root.
