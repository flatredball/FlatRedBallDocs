## Introduction

Variables in Glue are not automatically ordered alphabetically. The reason for this is because the order that variables appear in Glue impacts the order that they are set in Glue's generated code. Instead, variables can be reordered through the "Move" commands when right-clicking on a variable in Glue: ![MoveCommandsRightclick.png](/media/migrated_media-MoveCommandsRightclick.png)

## When does order matter

The order of variables does not matter in most cases; however, it can matter in some. For example consider an object that contains an object that is an Entire Scene. In this situation one Sprite in the entire Scene has a special purpose and will at times be visible when the entire Scene is invisible, or will be invisible when the entire scene is visible. To accomplish this, you would need two tunneled variables - one that tunnels into the Scene's Visibility, one that tunnels into the the Sprite's visibility. However, setting the Scene's Visible property is just a shortcut way of setting the visibility of all objects. Therefore, the special Sprite (which is part of the Scene) must have its Visible property set **after** the Scene's Visible property is set.
