# texturescale

### Introduction

The TextureScale property can be used to size a Sprite according to its Texture and texture coordiantes. If a Sprite which is displaying its full texture is using a TextureScale of 1, then the Sprite's width will match its Texture's width, and the Sprite's height will match the Texture's Height. A TextureScale of 1 is the most common value, and this is the default for Sprites created in a 2D Entity in the FlatRedBall Editor. TextureScale works by changing a Sprite's Width and Height properties according to a Sprite's Texture and texture coordinate values. Therefore, whenever a Sprite's Texture or texture coordinates change, the Sprite's Width or Height may change if the Sprite is using a TextureScale. If TextureScale of 0, the Sprite will ignore this value and use its existing Width and Height values instead.

### When does TextureScale change Width and Height values values?

The TextureScale value changes the Width and Height values according to the Texture size. The Width and Height of a Sprite will change when the following occur (assuming TextureScale greater than 0):

* Setting TextureScale
* Setting Texture
* Setting [LeftTextureCoordinate](../../../../frb/docs/index.php), [RightTextureCoordinate](../../../../frb/docs/index.php), [TopTextureCoordinate](../../../../frb/docs/index.php), [BottomTextureCoordinate](../../../../frb/docs/index.php)
* When an animation frame changes (if the Sprite is using AnimationChains)

#### TextureScale can overwrite Scale/Width/Height values

Whenever TextureScale is not 0, it will overwrite Width/Height values when any of the values mentioned above change. For example:

```
// assuming mySprite is a valid Sprite
mySprite.TextureScale = 1f;
mySprite.Width = 10; // We'll assume this value is different than what is set by TextureScale
mySprite.Texture = SomeTexture; // This will reset the Width, overwriting the 10 value
```

### Code Example

The following example creates two Sprites. Their TextureScale is set to the same value. Therefore, their sizes relative to each other is the same as the sizes of their [Textures](../../../../frb/docs/index.php) relative to each other.

```
Sprite ball = SpriteManager.AddSprite("redball.bmp");
ball.TextureScale = 1;
ball.Y = 100;

Sprite logo = SpriteManager.AddSprite(@"Assets\Scenes\frblogo.png");
logo.TextureScale = 1;
logo.Y = 200;
```

![PixelSizeExample.png](../../../../media/migrated_media-PixelSizeExample.png)

### TextureScale and Power of Two

Some older video cards cards expect that all textures have a [power of two](../../../../frb/docs/index.php) width and height. In some cases, textures may even be re-sized to fit this requirement. For example, if the current graphics card requires a power of two, an image that is 100X300 may be re-sized to a texture that is 128X512 when loaded in the game. The resizing always increases the resolution of images. This can cause problems if your code uses TextureScale for Sprites which are displaying textures which are not a power of two. The reason is because you may see different behavior on different machines. Using the example above, if you were to load the 100X300 image and display it with a Sprite using a TextureScale of 1, then you would see the following results: _On a machine that doesn't resize:_

```
mySprite.ScaleX will be 50
mySprite.ScaleY will be 150
```

_On a machine that does resize:_

```
mySprite.ScaleX will be 64
mySprite.ScaleY will be 256
```

The solution to this problem is to make sure all of your images have [power of two](../../../../frb/docs/index.php) width and height.

### Animations "resetting" Scale

If you are using an Animation on your Sprite, and you are modifying the scale of your Sprite, then you must do one of two things:

* Change TextureScale instead of Width/Height (or ScaleX/ScaleY)

\-- or --

* Set TextureScale to 0, then manually adjust Width/Height (or ScaleX/ScaleY)

Let's consider an example to see why this is the case. For this example, let's consider a Sprite that is displaying an animation. For simplicity purposes, we'll assume that each frame in the animation is displaying a 32x32 image. So our code may look something like this:

```
Sprite sprite = new Sprite();
SpriteManager.AddSprite(sprite);
// This sets the TextureScale to 1, meaning it will have a width matching its animation frames:
sprite.TextureScale = 1;
// Now, let's force the Width to some value (other than what our animation will have)
sprite.Width = 200;

// Now we'll set the animation:
sprite.AnimationChains = SomeAnimationChainList;
// This will change the texture, meaning that it will immediately change the width
// to the width of the frame:
sprite.CurrentChainName = "AnimationName";
// The Sprite's width will now be the width of the frame instead of 200
```
