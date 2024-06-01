# SpineDrawableBatch

### Introduction

The SpineDrawableBatch class is responsible for drawing Spine in your FlatRedBall game. If you have used Tiled in your FlatRedBall projects, you can think of the SpineDrawableBatch as being similar to a Tiled Layer. In other words, the SpineDrawableBatch has the following characteristics:

1. It can be positioned explicitly, although this is typically done through attachments in generated code
2. It has a Z value which controls its sorting
3. It produces a new render break (this may change in the future)

By contrast, normally Tiled maps are added to Screens; however, SpineDrawableBatches are typically added to Entities.&#x20;

### Adding Spine Files

Spine files are needed to draw a SpineDrawableBatch. Conceptually you can think of these files similar to how you might think of a .achx file - it needs to be loaded as part of an entity or screen before it can be used to display any graphics.

To add a SpineDrawableBatch to an entity:

1. Create an entity that will contain the SpineDrawableBatch. This example uses an Entity called Soldier
2. Drag+drop a Spine skeleton file (.json) into the Entity's files
3. Drag+drop an Atlas file (.atlas) into the Entity's files
4. Drag+drop the matching texture file (.png) into the Entity's files
5.  Select the Skeleton entry in FlatRedBall, click on the Spine tab, and change the Atlas property the desired Atlas file. It should appear in the dropdown.\


    <figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Setting an AtlasName on a Spine skeleton</p></figcaption></figure>

**Important**: At the time of this writing, the three files must be loaded in the proper order. The order is:

1. Texture file (.png)
2. Atlas (.atlas)
3. Skeleton (.json)

You can re-order the files by holding down the ALT key on the keyboard and pressing the up and down keys.

<figure><img src="../../.gitbook/assets/16_06 16 26.gif" alt=""><figcaption><p>Reordering files</p></figcaption></figure>

This requirement may go away in the future as the Spine plugin gets better at tracking dependencies.

Note that the texture file (.png) is loaded when the atlas is created and ultimately uses a FlatRedBall content manager. This means that if your png is already loaded (such as by being in Global Content Files), then you do not need to also have the png in your entity. This is especially useful if your atlas references a shared sprite sheet which is used by other screens and entities.

### Adding a SpineDrawableBatch Object

Now the Spine files have been added to the entity, we need to add them as an object. By adding an object we can control properties such as position (offset) and scale. Also, each individual object can be independently animated. To add and attach the SpineDrawableBatch:

1. Drag+drop the skeleton file from Files onto Objects
2. Change the Source name to **Entire File (SpineDrawableBatch)**
3. Enter a name such as SpineDrawableBatch
4. Click OK

<figure><img src="../../.gitbook/assets/16_06 18 35.png" alt=""><figcaption><p>Creating a new Object from a loaded Spine Skeleton</p></figcaption></figure>

You should now have all three files in your Entity as well as a SpineDrawableBatch in the Objects folder.

<figure><img src="../../.gitbook/assets/image (3) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Spine files and SpineDrawableBatch object</p></figcaption></figure>

### Adding an Entity Instance to a Screen

To see the entity instance in-game, drag+drop the entity onto a Screen, such as GameScreen. Run the game and the Spine Drawable Batch should appear.

<figure><img src="../../.gitbook/assets/image (4) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>SpineDrawableBatch in Game</p></figcaption></figure>

