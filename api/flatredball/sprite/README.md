# Sprite

### Introduction

The Sprite is a flat graphical object which is commonly used as the visuals for entities and for particles. Sprites can also be used to display tilemaps and UI, although Tiled and Gum provide more flexibility and performance. The Sprite class inherits from the [PositionedObject](../../../frb/docs/index.php) class.

Sprites are usually created through the FlatRedBall Editor when associated with entities, although Sprites can also be created in code when dynamic visuals are needed.

### Creating a Sprite in Code

In most cases, a Sprite can be created in code by instantiating it, assigning a texture, and adding it to the SpriteManager so that it is drawn. The following code assumes that `TextureFile` is a valid Texture2D:

```csharp
// Creates a new Sprite instance
var sprite = new Sprite();
// Assigns the texture to display. 
sprite.Texture = TextureFile;
// Sets the Sprite's scale so that it renders 1:1 relative to its source Texture
sprite.TextureScale = 1;
// Adds the Sprite to the SpriteManager so that it is shown, and so that it is
// "managed" (velocity, acceleration, and attachments are maintained)
SpriteManager.AddSprite(sprite);
```

### Sprite Scale

For information on Scale, see the [IScalable wiki entry](../../../frb/docs/index.php). To match the on-screen pixel dimensions of a Sprite to its referenced [Texture's](../../../frb/docs/index.php) pixel dimensions, see the [2D in FlatRedBall tutorial](../../../frb/docs/index.php).

### Texture

Sprites can be thought of as picture frames or canvases - they define how big a displayed image will be, its position, its rotation, and so on. However, the image or picture that they display is separate from the Sprite itself. This is an important realization because this often differs from other game engines where the image and the Sprite are one and the same at runtime. For more information, see the [Sprite.Texture](../../../frb/docs/index.php) page.

### Color and Alpha

For information on color and alpha operations (blending), see the [IColorable wiki entry](../../../frb/docs/index.php).

### Z Buffered Sprites

Using a Z Buffer allows Sprites to properly overlap. For more information, see the [Z Buffered Sprites wiki entry](../../../frb/docs/index.php).

### Particle Sprites

Particle Sprites are created through the [SpriteManager](../../../frb/docs/index.php) just like other Sprites. Particle Sprites are created from a pool of Sprites that is created when the engine is first initiated. The following code creates a particle Sprite:

```
Sprite newSprite = SpriteManager.AddParticleSprite();
```

Particle Sprites have all of the same functionality as regular Sprites - in fact, they are just Sprites. The only difference is that there is minimal memory allocation and garbage collection so they can be useful when creating particle effects. Particle Sprites are used by [Emitters](../../../frb/docs/index.php).

###

&#x20;
