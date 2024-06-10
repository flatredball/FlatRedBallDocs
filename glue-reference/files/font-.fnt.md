# Font (.fnt)

### Introduction

Font files (.fnt) are produced by AngleCode's Bitmap Font Generator ( [https://www.angelcode.com/products/bmfont/](https://www.angelcode.com/products/bmfont/) ). These files can be loaded through the FlatRedBall Editor and used on FlatRedBall Text objects. Note that the recommended approach for working with files is through Gum. If using Gum, you do not need to explicitly load font files in the FlatRedBall Editor.

### Working with .fnt Fiels in the FRB Editor

To load a font file:

1. Verify that you have the .fnt file and any referenced files already placed in the correct folder. This is important because both files must be part of the project.
2. Drag+drop the .fnt file into your Files folder - either in Global Content Files or the Files folder of a Screen or Entity

Your font file should appear in the Files folder.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Font file in an Entity's Files folder</p></figcaption></figure>

This file can now be referenced on a Text's Font property.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>TextInstance with a Font assigned</p></figcaption></figure>
