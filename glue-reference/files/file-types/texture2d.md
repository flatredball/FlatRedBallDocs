# Texture2D (.png)

### Introduction

Texture2D instances can be created through the FlatRedBall Editor by adding image files to entities, screens, or Global Content Files. By default, any image file added to FlatRedBall is loaded when the containing screen/entity is created. Files added to Global Content can be accessed as soon as the game launches from any screen or entity.

### Example - Adding a Texture2D For a Sprite

Texture2D's which are added to a screen or entity can be accessed by objects in the same screen or entity. The following steps show how to add a Texture2D to an entity and reference it on a sprite:

1.  Create an entity with a Sprite object. See the [Sprites in Glue page](../../objects/object-types/glue-reference-sprite.md) for more information.

    ![Add a new new Entity with a Sprite](../../../.gitbook/assets/2019-06-img_5d18b9a876102.png)
2. Drag+drop a .png file from any location on your computer onto the entity's Files object. Note that if the file is not located outside of your game's Content folder, the file is copied.

<figure><img src="../../../.gitbook/assets/2016-07-2019-06-30_07-32-33.gif" alt=""><figcaption></figcaption></figure>

3. Select the Sprite object
4. Locate the "Texture" property
5.  Use the drop-down to select the desired texture

    ![](../../../.gitbook/assets/2016-07-img_57881ea9e2cbc.png)

The Sprite now uses the selected texture.

### Example - Accessing a Texture2D in code

Texture2D instances added to FlatRedBall can be accessed in code. If a Texture2D is added to a screen then the custom code for that screen can access the Texture2D variable name matching the name of the file (excluding extension). Similarly, if a Texture2D is added to an entity, then the custom code for that entity can access the Texture2D as well. If a Texture2D is added to Global Content files, then any code in the entire game can access the Texture2D at any time. For this example, consider the CharacterEntity shown in the example above. The custom code for CharacterEntity can access the Character PNG as follows:

```csharp
private void CustomInitialize()
{
    // This is a redundant set, since the SpriteInstance
    // already uses the Character texture. It simply shows
    // that custom code can access the Texture2D by file name
    // in a type-safe way.
    SpriteInstance.Texture = Character;
}
```

Similarly, files added to global content can be accessed in code through the GlobalContent object. For example, consider a file Background.png which could be added to global content:

![png file in Global Content Files](../../../.gitbook/assets/2016-07-img_57882064ea554.png)

This file could be accessed in code as shown in the following snippet:

```csharp
private void CustomInitialize()
{
    SpriteInstance.Texture = GlobalContent.Background;
}
```

### Loading Texture2Ds in Web Projects

PNG files can be loaded into Texture2Ds on web projects just like any other project; however, file loading on web is typically much slower than on desktop platforms.
