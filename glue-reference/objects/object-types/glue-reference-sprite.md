# Sprite

### Introduction

Sprites are used to render a texture to the screen. Sprites are one of the most common types of FlatRedBall objects. Examples of Sprites include:

* Character graphics (static or animated)
* Backgrounds
* Particles
* Bullets

Sprites are often contained in Entities or created in code as particles.

### Sprite vs Texture

Many new developers confuse the terms Sprite and Texture so it's worth discussing the difference. A Sprite is an object that is added to an Entity which can display a texture or a portion of a texture. A Sprite can have a size, rotation, transparency, and a color tint.

A texture (technically a Texture2D) is an image which is usually loaded from a .png file. The texture has pixel data which is used by a Sprite to draw to the screen. A texture can contain a single image (such as a coin or bullet), or it can contain multiple images. When it contains multiple images it is often referred to as a _sprite sheet_.

You can think of the Sprite as something which displays texture data - like a digital picture frame. The texture is the picture that is being displayed in the digital picture frame.&#x20;

### Creating an Entity With a Sprite

When you are creating a new entity, you can check the option to add a Sprite in the **Add Entity Window**.

1. Right-click on the Entities folder
2. Select **Add Entity**
3. Check the **Sprite** option
4. Click **OK**

![](../../../media/2019-06-img\_5d18bae01c0a8.png)

### Adding a Sprite

Sprites can be added to FlatRedBall screens or entities, although most games don't include Sprites directly in screens. To add a Sprite to an entity:

1. Create or select an existing entity or screen
2. Right-click on the **Objects** node
3. Select **Add Object**
4. Select the **FlatRedBall or Custom Type** category
5. Select the **Sprite** type
6. Click **OK**

<figure><img src="../../../.gitbook/assets/18_07 49 33.gif" alt=""><figcaption></figcaption></figure>

### Sprite Texture

Sprites usually display textures, which are created from image files such as .png files. To add and display a texture on a Sprite:

1. Create a Sprite in a screen or entity as shown above
2. Find a .png which you would like to use
3. Drag+drop the .png file onto your screen or entity's **Files** folder in FlatRedBall
4. Select the Sprite in the same screen or entity with the newly-added file
5. Change its **Texture** property to the newly-added file

<figure><img src="../../../.gitbook/assets/18_07 51 43.gif" alt=""><figcaption></figcaption></figure>

For more information about working with textures, see the [Texture2D page](../../files/texture2d.md).
