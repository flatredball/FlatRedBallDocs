# bmfc-file

### Introduction

The BMFC file format (which stands for "bitmap font configuration") is a file that can be loaded and saved by the [Bitmap Font Generator](http://www.angelcode.com/products/bmfont/), which also produces the .fnt file format that the FlatRedBall engine natively works with. The .bmfc file format is a powerful file format because it can be saved and loaded later to make changes to an existing font. Furthermore, Glue can use the Bitmap Font Generator to automatically create a .fnt file from a .bmfc file.

### How to create a .bmfc file

A .bmfc file can be created in the Bitmap Font Generator. To create a .bmfc file:

1. Open the Bitmap Font Generator
2. Set up a bitmap font - for more information see [this page](../../../../../frb/docs/index.php)
3. Click Options->"Save configuration as..."
4. Enter a name for the file and click OK

### How to use a .bmfc file in Glue

The .bmfc file is a file which must be converted into a .fnt file. This can be done by using Glue and the Bitmap Font Generator.

**Note:** Glue uses command line arguments to convert a .bmfc file into a .fnt file. This is not the only way to convert a .bmfc file into a .fnt. You can also manually run a command line yourself, or you can simply open the Bitmap Font Generator program, load the configuration, then manually save out the font file.

First, you must make sure Glue is set up to use the Bitmap Font Generator as a build tool. To add the Bitmap Font Generator as a build tool:

1. Open Glue
2. Select Settings->"File Build Tools"
3. Click "Add new build tool"
4. Navigate to the location of the Bitmap Font Generator. If you installed it to the default location on Windows 7, it should be located at"C:\Program Files (x86)\AngelCode\BMFont\bmfont.exe"
5. Set the SourceFileType to bmfc
6. Set the DestinationFileType to fnt
7. Set the SourceFileArgumentPrefix to -c
8. Set the DestinationFileArgumentPrefix to -o (lower-case letter 'o')
9. Click OK

![BitmapFontGeneratorBuildSettings.PNG](../../../../../media/migrated\_media-BitmapFontGeneratorBuildSettings.PNG)

Once you have set up the Bitmap Font Generator as a builder in Glue, you can add .bmfc files as externally built files. To do this:

1. Create a .bmfc file as shown above
2. Right-click on the Files tree item under a Screen or Entity or Global Content Files
3. Select "Add Externally Built File"
4. Select the .bmfc file. Be sure that this file is located in a subfolder of your project.
5. Select the bmfont.exe builder in the drop-down in the window that appears
6. Enter a name for your font (or leave it as default)![AddExternalFileOptions.PNG](../../../../../media/migrated\_media-AddExternalFileOptions.PNG)
7. Click OK

Your project will now include a .fnt file which can be loaded by code into a BitmapFont, which can be used in Glue, or which can be used in a .scnx file. ![FontFileInGlue.png](../../../../../media/migrated\_media-FontFileInGlue.png)
