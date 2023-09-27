## Introduction

Any file added to a Screen or Entity will have a corresponding member in code which represents the already-loaded file. You can access this object in custom code without having to worry about whether it has been loaded or when to load it (at least under default settings).

## Example

To see how a file is accessed in code:

1.  Create a new Screen called "TestScreen"
2.  Find a .png through windows explorer
3.  Drag+drop the .png into your TestScreen's Files in Glue
4.  Notice that the newly-added File will indicate which type it will load to at runtime![Texture2DRuntimeType.png](/media/migrated_media-Texture2DRuntimeType.png)
5.  Open TestScreen.cs in Visual Studio
6.  Add the following code to CustomInitialize:

&nbsp;

    // My file was called "Slug.png" so my member name is Slug
    // You may need to change the member name to match your file name
    Sprite sprite = SpriteManager.AddSprite(Slug);

Note:Since the purpose of the code above is to simply show that the file added to TestScreen can be accessed in code, it does not cover removal of the Sprite. In an actual game you would want to keep track of the Sprite at Screen level and remove it in the Screen's CustomDestroy. Not doing so would result in your game crashing when you transition to a different Screen.
