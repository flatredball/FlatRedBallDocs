# AnimationChainList

### Introduction

Asesprite files (.aseprite) can be used in FlatRedBall projects to create AnimationChainLists. Each tag creates an AnimationChain with a matching name. FlatRedBall natively supports .aseprite files so no additional integration (nuget packages or plugins) are needed.

Support for .aseprite files is available for projects which link to source code as of April 6, 2024. Supprort will be availble as of the May 2024 release for binaries.

### Adding an .aseprite File to a FlatRedBall project.

To add an .aseprite file to FlatRedBall, drag+drop the file the same as if adding any other file such as a .png or .wav.

<figure><img src="../.gitbook/assets/06_19 39 19.gif" alt=""><figcaption><p>Drag+dropping an .aseprite file into Global Content Files</p></figcaption></figure>

.aseprite files added to FlatRedBall projects are loaded as AnimationChainLists.

<figure><img src="../.gitbook/assets/image (110).png" alt=""><figcaption><p>.aseprite loaded as an AnimationChainList</p></figcaption></figure>

Once a .aseprite file is loaded, it can be used just like any AnimationChainList. This includes:

1. Referencing the file in a Sprite
2. Referencing its animations in a top down or platformer entity
3. Using the loaded AnimationChainList in code

Note that the .aseprite file generates its own texture used by the AnimationChainLists.

### Aseprite Files and Texture Breaks

Each .aseprite file generates its own texture. Therefore, if two .aseprite files are added to a FlatRedBall project, each creates its own Texture2D. Projects should attempt to put as many animations (tags) into a single .aseprite file to reduce render breaks. Unless memory considerations require otherwise, the most performant approach is to use a single large .aseprite file which contains all animations.

### Tags and Animations

Each tag creates an AnimationChainList with one animation for each tag. If tags overlap, then multiple animations may be created, each containing AnimationFrames which share texture coordinates.

For example, consider the following timeline:

<figure><img src="../.gitbook/assets/image (111).png" alt=""><figcaption><p>Aseprite timeline</p></figcaption></figure>

A file with this timeline would load as an AnimationChainList with the following animations:

* idle
* movement
* jump
* Prejump
* Rise
* Jump Crest
* Fall
* Landing
* Dash

The naming of the tags carries over exactly as the tag is written, including spacing and capitalization. Each frame is created with the appropriate time and references the atlas.

### Current Limitations

The following features in AnimationChainLists are not supported through .aseprite files:

* XOffset and YOffset
* Collision shapes
* FlipHorizontal and FlipVertical

These may be added in future updates.
