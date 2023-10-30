# glue-reference-sprite

### Introduction

Sprites are used to render a texture to the screen. Sprites are one of the most common types of FlatRedBall objects. Examples of Sprites include:

* Character graphics (static or animated)
* Backgrounds
* Particles
* Tile graphics
* Bullets

### Creating an Entity With a Sprite

If you know that your entity needs a Sprite, you can check the Sprite option in the **Add Entity Window**.

1. Right-click on the Entities folder
2. Select **Add Entity**
3. Check the **Sprite** option
4. Click **OK**

![](../../../../media/2019-06-img_5d18bae01c0a8.png)

### Adding a Sprite

Sprites can be added to Glue screens or entities, although most games don't include Sprites directly in screens. To add a Sprite to an entity:

1. Create or select an existing entity or screen
2. Right-click on the **Objects** node
3. Select **Add Object**
4. Select the **FlatRedBall or Custom Type** category
5. Select the **Sprite** type
6. Click **OK**



<figure><img src="../../../../media/2016-01-2019-05-02_06-51-56.gif" alt=""><figcaption></figcaption></figure>



### Sprite Texture

Sprites usually display textures, which are created from image files such as .png files. To add and display a texture on a Sprite:

1. Create a Sprite in a screen or entity as shown above
2. Find a .png which you would like to use
3. Drag+drop the .png file onto your screen or entity's **Files** folder in Glue
4. Select the Sprite in the same screen or entity with the newly-added file
5. Change its **Texture** property to the newly-added file



<figure><img src="../../../../media/2016-01-2019-05-02_06-56-48-1.gif" alt=""><figcaption></figcaption></figure>

 For more information about working with textures, see the [Texture2D page](../files/texture2d.md). The Sprite will now display the texture in the preview window and in game. &#x20;

![](../../../../media/2019-05-img_5ccae9f711f3f.png)
