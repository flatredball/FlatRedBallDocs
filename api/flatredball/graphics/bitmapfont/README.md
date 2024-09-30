# BitmapFont

### Introduction

The BitmapFont class defines the texture and rendering values used to render a bitmap font. The [Text object](../text/) uses BitmapFonts when drawing itself. Note that the recommended approach for displaying production-ready text to the screen (including with custom fonts) is to use [Gum](../../../../gum/), which automates the creation of font files and simplifies loading these files.

The main benefit of the FRB Text object is that it can sort with other visual objects and it can have better performance than Gum text objects in some cases.

### Creating a BitmapFont

Bitmap Fonts require two files - a texture file and a .fnt file. Both can be created with [AngelCode.com's Bitmap Font Generator](http://www.angelcode.com/products/bmfont/). The following steps outline the creation of the two files used in BitmapFonts:

1. Open Bitmap font generator.\
   &#x20;![SearchBMFont.png](../../../../.gitbook/assets/migrated\_media-SearchBMFont.png)![BitmapFontGenerator.PNG](../../../../.gitbook/assets/migrated\_media-BitmapFontGenerator.PNG)
2.  Click or push+drag to select the letters that you'd like included in your exported font. Selected letters will highlight.\


    <figure><img src="../../../../.gitbook/assets/migrated_media-SelectedLettersInBFG.PNG" alt=""><figcaption><p>Select the desired characters. This screenshot shows 0-9, A-Z, and a-z selected.</p></figcaption></figure>
3. Click Options->Font Settings
   1. Select the font that you'd like to use in the "Font" drop down. All fonts installed on your machine will appear here.
   2. Enter the font size that you want next to "Size (px)": The larger this is, the larger each letter will be in your game. If you are using Photoshop, you can test font sizes there (see next item)
   3. Check the "Match char height" option. This will make the resulting font match sizes in Photoshop
   4. Press Ok. The font display will update to the newly-selected font.
4. Select Options->Export Options.
   1. Select a Bit depth of 32 (or else transparencies won't come through).
   2. Select the texture width and height. Ideally you should select a texture size large enough to fit all characters, but small enough to minimize empty space. This may require some trial and error.
   3. Change the "Textures:" option to "png - Portable Network Graphics"
   4. Press Ok.
5. Select Options->Visualize. If you see "No Output!" then you need to select characters to export. See the above step for more information.
6. Return to change the width/height if necessary. Verify that your font fits on one image by seeing if View->Next Page is disabled in the preview. If everything does not fit in one page consider decreasing the size of your font or increasing the source image size. Remember to keep your texture dimension a power of 2.
7. Click Options->Save bitmap font as... to save your .fnt and .png files.
8. Copy the files to their appropriate locations for your application.

### Using a BitmapFont in the FRB Editor

For information on how to use BitmapFonts in the FRB Editor, see the [Font (.fnt) page](../../../../glue-reference/files/font-.fnt.md).

### Adding custom letters to a .fnt file

BitmapFontGenerator supports adding custom images to a font file. This can be used in the following situations:

* Inserting images in the middle of text, such as "Press the \<A button image> to continue"
* Using custom images for letters instead of having BitmapFontGenerator generate them from True Type Fonts

To add a custom image to a font:

1. Open Bitmap Font Generator
2. Select "Edit"->"Open Image Manager"
3. In the Image Manager window, select "Image"->"Import Image..."
4. Navigate to the image that you want to import and click "Open". Notice that as of BMFont 1.13 you cannot import PNGs as custom glyphs. See the "Troubleshooting BMFont"
5. Enter the information for the new letter
   1. Id refers to the unicode character. A full list of unicode characters can be found here. For reference, the capital letter 'A' has an ID of 65; the lower case 'a' has an ID of 97.
   2. X advance refers to how much horizontal space is taken up by the letter. The default of 0 means that the size of the image defines the space taken up.

#### Known BMFont Bugs

BMFont 1.13 includes a number of bugs which can make glyph creation more difficult. Fortunately workarounds exist for these bugs:

* BMFont will crash if a .bmcc file is saved in the same folder as a referenced image. To solve this, save the .bmfc file in a different folder, or update to the 1.14 beta build of BMFont.
* BMFont will not allow .png files to be added as glyphs through the steps outlined above. To work around this, the .bmfc file can be modified manually.

### Manually Adding a BitmapFont to Your Project

Note that if you are using Glue you may not have to add fonts to your project manually, as Glue will manage the project and generate the code to load the font. However, to manually add a bitmap font to your Visual Studio project:

1. Create or download a .fnt file and matching image file (.png is typical)
2.  Drag+drop the files into your project's **Content** folder

    ![](../../../../.gitbook/assets/2019-06-img\_5d09a2256425b.png)
3.  Mark both files as **Copy if Newer** in their properties

    ![](../../../../.gitbook/assets/2019-06-img\_5d09a2636c758.png)

### Loading a BitmapFont

Once the files are created they need to be loaded into a BitmapFont. The following code loads a BitmapFont and assigns it to a Text object. **Files used:** [font18arial\_0.png](../../../../content/Tutorials/Graphics/font18arial\_0.png), [font18arial.fnt](http://files.flatredball.com/content/Tutorials/Graphics/font18arial.fnt) Add the following using statement

```
using FlatRedBall.Graphics;
```

Add the following in your Initialize method after initializing FlatRedBall

```
string fontPatternFile = "font18arial.fnt";
// If managing assets for unloading use your content manager name
// or the current Screen's ContentManager property instead of Global.
string contentManagerName = "Global";
 
BitmapFont customFont = new BitmapFont( fontPatternFile, contentManagerName);

Text text = TextManager.AddText("Hi. I use a custom font", customFont);
```

A Text's font can also be changed after it has been created. Assuming customFont is still in scope:

```
Text text = TextManager.AddText("Hi, I'm another text.");
otherText.Font = customFont;
```

![CustomFontExample.png](../../../../.gitbook/assets/migrated\_media-CustomFontExample.png)

#### Loading a BitmapFont through the Content Pipeline

The .fnt file is simply a text file which must be copied to build folder, while the referenced texture must be built through the content pipeline. Therefore, each file must be handled slightly differently. The following steps outline how to add a BitmapFont to a project through the content pipeline:

1. Add the two font files to the Content folder. You can simply drag them into the Solution Explorer and they will be added. ![FontInContentPipeline.png](../../../../.gitbook/assets/migrated\_media-FontInContentPipeline.png)
2. Highlight the .fnt file and press F4 to bring up the Properties window. Make sure that its "Build Action" is "None" and its "Copy to Output Directory" is "Copy if newer" ![FntProperties.png](../../../../.gitbook/assets/migrated\_media-FntProperties.png)
3. Add the following code to load the bitmapFont:

Add the following using statements:

```
using FlatRedBall.Graphics;
```

Add the following wherever you are loading your font:

```
BitmapFont bitmapFont = new BitmapFont(
    @"Content\CustomFont",  // No extension since it's been run through the content pipeline
    @"Content\CustomFont.fnt", // Use extension here since it's simply copied straight over
    FlatRedBallServices.GlobalContentManager);
```

### Bitmap and Text size

While it may not be immediately obvious, there is a difference between BitmapFonts and [Texts](../../../../frb/docs/index.php) (the [FlatRedBall.Graphics.Text](../../../../frb/docs/index.php) class). A [Text](../../../../frb/docs/index.php) contains information such as location, rotation, and the string to write out. The BitmapFont contains the texture information to use which represents the font. Specifically, it contains a Texture2D as well as the texture coordinates for each character. One notable consideration is that the properties in both the BitmapFont class as well as the [Text](../../../../frb/docs/index.php) class can contain the size of the letters in a Text object. Let's investigate why this is the case. Ultimately, there are three properties which are related to the size that a [Text](../../../../frb/docs/index.php) takes up when it is rendered:

* Scale
* Spacing
* NewlineDistance

Information and code samples on these properties can be found [here](../../../../frb/docs/index.php#Text\_Size). These three properties ultimately control the absolute size and spacing of each letter in the Text object. However, a BitmapFont that has letters at a higher resolution will result in a larger Text on screen. The reason for this is because the [TextManager](../../../../frb/docs/index.php) adjusts these three values according to the current [Camera](../../../../frb/docs/index.php) setup when the AddText method is called so that the Text is drawn to-the-pixel. This means that a Text that is created through the TextManager which is displaying a large BitmapFont will have higher Scale, Spacing, and NewlineDistance values than one displaying a smaller BitmapFont. This behavior simply exists as a convenience, and it can be easily overridden if necessary by changing these values.
