## Introduction

The RenderTargetSprite class provides a simple way to perform rendering using a RenderTarget2D. Although FlatRedBall provides support for using MonoGame render targets, the RenderTargetSprite simplifies the creation and management of render targets. RenderTargetSprite instances provide a FlatRedBall Layer for adding visual objects to the sprite.

## RenderTargetSprite Concepts

To understand how a RenderTargetSprite works, we can compare it with a normal FlatRedBall Layer. A FlatRedBall Layer can contain any visual objects such as FlatRedBall Sprites, MapDrawableBatch (Tiled), and Gum visual objects. The purpose of the Layer is to control the sorting of objects. It cannot modify the objects being drawn such as by applying additional rotation, position offsets, or blend operations. RenderTargetSprites provide additional control over how multiple objects are drawn. For example, a RenderTargetSprite can apply a blend operation to all rendered objects to create a darkness effect. Furthermore, RenderTargetSprites provide additional sorting support by providing sorting both on the Z axis as well as by-Layer.

### RenderTargetSprite vs Layer.RenderTarget

FlatRedBall provides a number of ways to render to a render target. The RenderTargetSprite allows you to perform rendering onto a FlatRedBall Sprite. This is useful if you would like that resulting RenderTarget (texture) to be drawn to screen using a FlatRedBall Sprite. This can make it easier to position the render target and perform standard color operations. If you would like to create a RenderTarget (texture) which you process yourself (such as by rendering using SpriteBatch) then the Layer's RenderTarget property can be used as a more lightweight option. For more information see the [Layer.RenderTarget](/documentation/api/flatredball/flatredball-graphics/flatredball-graphics-layer/rendertarget.md) page.

## Example Code - Darkness with Moving Lights

This example shows how to create a dark overlay on your game, with light sprites providing brightness. This approach does not over-saturate bright areas, nor does it produce rendering artifacts where lights overlap. It creates five sprites, one of which can be controlled with the keyboard. Note that this assumes:

-   The Screen has some other visuals to be drawn under the RenderTargetSprite
-   The WhiteLight Texture is available to the Screen, such as by being added to the Screen in Glue

&nbsp;

    public partial class TestScreen
    {
      // This is the RenderTargetSprite which will draw the darkness over the 
      // regular game.
      RenderTargetSprite renderTargetSprite;

      // All light sprites. This list is needed for cleanup when the Screen is destroyed
      PositionedObjectList<Sprite> lightSprites = new PositionedObjectList<Sprite>();

      void CustomInitialize()
      {
        renderTargetSprite = new RenderTargetSprite(
           // Internally the Sprite creates a RenderTarget
           // which must be disposed. Using the Screen's ContentManagerName
           // is recommended, unless the Screen uses a Global content - in that
           // case a custom RenderTarget should be used.
           this.ContentManagerName, 
           // The name of the Sprite and its internal RenderTarget. This is required
           // since all RenderTargets must be named if used as Textures in FRB.
           "Darkness");

        // Modulate is used to darken whatever is under the RenderTargetSprite.
        renderTargetSprite.BlendOperation = BlendOperation.Modulate;

        // We add the RenderTargetSprite to the top layer in FRB. We could also have
        // added it to a higher Z value, or a dedicated layer for darkening. 
        SpriteManager.AddToLayer(renderTargetSprite, SpriteManager.TopLayer);

        // By default the RenderTargetSprite is transparent after Refresh is called. 
        // We add a large, purely black Sprite to it for the darkness
        Sprite allBlackSprite = new Sprite();
        allBlackSprite.ColorOperation = ColorOperation.Color;
        allBlackSprite.Red = 0;
        allBlackSprite.Green = 0;
        allBlackSprite.Blue = 0;

        // this needs to be big enough to provide darkness over the entire level
        allBlackSprite.Width = 100000;
        allBlackSprite.Height = 100000;

        // To add anything to the RenderTargetSprite, it can be added to the 
        // RenderTargetSprite's DefaultInputLayer.
        SpriteManager.AddToLayer(allBlackSprite, renderTargetSprite.DefaultInputLayer);

        // Next we add all of the light Sprites to the RenderTargetSprite
        for(int i = 0; i < 5; i++)
        {
          var lightSprite = new Sprite();
          lightSprites.Add(lightSprite);

          // This texture is fully white, with the outer parts transparent
          lightSprite.Texture = WhiteLight;
          lightSprite.TextureScale = 2.5f;

          // Place it randomly so the lights don't all overlap
          Camera.Main.PositionRandomlyInView(lightSprite);

          // Just like above, we add the lightSprite to the RenderTargetSprite's
          // DefaultInputLayer.
          SpriteManager.AddToLayer(lightSprite, renderTargetSprite.DefaultInputLayer);
        }
      }

      void CustomActivity(bool firstTimeCalled)
      {
        // This tells the RenderTargetSprite to
        // refresh what it is displaying. This can
        // be called every frame if the game requires
        // updating every-frame, but it can be conditionally
        // called if the render target doesn't change freqently.
        // Since Sprite can be moved with the keyboard, we'll refresh
        // this every frame:
        renderTargetSprite.Refresh();

        var keyboard = InputManager.Keyboard;
        // This is a quick way to move the object around the screen.
        // A full game may position or attach light Sprites to other Entities
        // such as a player.
        keyboard.ControlPositionedObject(lightSprites[0], 150);

        // This lets us toggle the visibility of the RenderTargetSprite so we
        // can see the game with and without the dark effect.
        if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
        {
          renderTargetSprite.Visible = !renderTargetSprite.Visible;
        }
      }

      void CustomDestroy()
      {
        // don't forget to clean up
        foreach(var lightSprite in lightSprites)
        {
          SpriteManager.RemoveSprite(lightSprite);
        }
        SpriteManager.RemoveSprite(renderTargetSprite);
      }

      static void CustomLoadStaticContent(string contentManagerName)
      {
      }
    }

[![](/wp-content/uploads/2020/12/2020_December_18_113601.gif)](/wp-content/uploads/2020/12/2020_December_18_113601.gif)  

## Refresh

By default the RenderTargetSprite will draw itself, and it will respond to variable changes such as position and rotation. For performance reasons, the RenderTargetSprite does not automatically refresh its contents, even if contained objects are moved. The Refresh function can be called to update the visual appearance of the contents of the RenderTargetSprite. Note that calling Refresh every frame will not cause performance problems for most games. Of course if your game doesn't need it, you can improve performance by calling Refresh only as needed.
