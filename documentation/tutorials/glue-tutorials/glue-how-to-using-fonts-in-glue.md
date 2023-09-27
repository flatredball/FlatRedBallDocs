## Introduction

[Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text") object added through Glue will use the default FlatRedBall font. This section will show you how to change the font to a custom font file. Any font which is installed on your machine can be used as a font in the game. Fonts which are installed on your machine must be convered to [BitmapFonts](/frb/docs/index.php?title=FlatRedBall.Graphics.BitmapFont.md "FlatRedBall.Graphics.BitmapFont"). Bitmap fonts are represented as .fnt files.

Glue enables you to create bitmap fonts and to use them on Text objects with no code at all. Of course, anything that is done in Glue can also be done completely in code.

## Ways to create Text objects with custom fonts

FlatRedBall includes three common methods of creating Texts with custom fonts:

-   Creating Text objects and BitmapFont objects in Glue, and assigning the font through Glue.
-   Creating Text objects in the SpriteEditor (or other .scnx-editing tools), creating a Text in the .scnx, and assigning the BitmapFont.
-   Creating a Text instance in code, loading a BitmapFont from file, and assigning the Text's Font property.

This article will cover the first option - how to do everything through Glue's interface.

## Creating a Text object

To create a Text object:

1.  Select a Screen or Entity
2.  Right-click on the "Objects" item
3.  Selct "Add Object"
4.  Select the "FlatRedBall Type" option
5.  Select "Text" in the list![NewTextInstance.PNG](/media/migrated_media-NewTextInstance.PNG)
6.  Enter a name (or leave it to the default value) and click OK

## Creating a .fnt file

FlatRedBall uses the .fnt file format created by [Angelcode Bitmap Font Generator](http://www.angelcode.com/products/bmfont/). To create a .fnt file, see [this page](/frb/docs/index.php?title=FlatRedBall.Graphics.BitmapFont.md#Creating_a_BitmapFont "FlatRedBall.Graphics.BitmapFont").

Once you have created a .fnt file:

1.  Right-click on the Files item under the same Screen or Entity that contains the Text object.
2.  Select "Add File"-\>"Existing File"
3.  Select the saved .fnt file. If the file is not contained within your project's Content folder, glue will automatically copy it and any referenced image files to the proper location.

## Setting the Font Variable

After both a Text object and a .fnt file have been added to your project, you can assign the Font property on the Text. To do this:

1.  Select the Text object
2.  Find the "Font" variable
3.  Use the drop-down to change the value to the name of your font![SetFontVariable.png](/media/migrated_media-SetFontVariable.png)

Now your Text object will use the given Font both in your game as well as in GlueView.
