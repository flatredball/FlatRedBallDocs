# Rendering Sprites with Shaders

### Introduction

Sprite appearance can be modified through a number of properties including Texture, ColorOperation, and BlendOperation. Full rendering control can be achieved by using custom shaders, applied through an IDrawableBatch. This guide covers how to render a Sprite using a custom IDrawableBatch.

### Adding Files to FlatRedBall

Before writing any code, we’ll add a few files to our project. This requires an existing FlatRedBall project with at least one Screen.

To add a shader file:

1. Download this file: [Shader.fx](http://files.flatredball.com/content/Tutorials/Graphics/Shader.fx)
2. Add the file to your FlatRedBall screen (such as GameScreen)

To add an Image file:

1. Right-click on your FlatRedBall screen's Files folder (such as GameScreen)
2. Select **Add File** -> **New File**
3. Select **Texture (.png)**

Both files should now be in your Screen so that we can reference them in the code below.

<figure><img src="../../.gitbook/assets/image (4) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>

### **Creating an IDrawableBatch**

Next we’ll create a IDrawableBatch which will handle our rendering. To do this:

1. Add a new file to your project in Visual Studio
2. Name the file CustomShaderSprite
3. Replace your file with the following (you may need to change the namespace to match your project’s namespace:

```csharp
using FlatRedBall;
using FlatRedBall.Graphics;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderProject
{
    public class CustomShaderSprite : PositionedObject, IDrawableBatch
    {
        Sprite sprite;
        Effect effect;

        short[] indexData = new short[]
        {
            0,1,2,
            0,2,3
        };

        public Texture2D Texture { get; set; }

        public bool UpdateEveryFrame
        {
            get
            {
                return true;
            }
        }

        public CustomShaderSprite (Effect effect)
        {
            sprite = new Sprite();
            sprite.TextureScale = 1;
            this.effect = effect;
        }

        public void Destroy()
        {

        }

        public void Draw(Camera camera)
        {
            camera.SetDeviceViewAndProjection(effect, relativeToCamera: false);

            var textureParameter = effect.Parameters["CurrentTexture"];
            textureParameter.SetValue(Texture);

            effect.CurrentTechnique = effect.Techniques["TexturePixelShader_Point"];

            var graphicsDevice = FlatRedBallServices.GraphicsDevice;

            foreach(var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserIndexedPrimitives(
                     // Render a triangle:
                     PrimitiveType.TriangleList,
                     // The array of verts that we want to render
                     sprite.VerticesForDrawing,
                     // The offset, which is 0 since we want to start 
                     // at the beginning of the verts array
                     0,
                     4,
                     indexData,
                     0,
                     2);
            }
        }

        public void Update()
        {
            sprite.Position = this.Position;
            sprite.RotationMatrix = this.RotationMatrix;
            sprite.Texture = Texture;

            SpriteManager.ManualUpdate(sprite);
        }
    }
}
```

### Adding CustomShaderSprite to your Screen

To add an instance of CustomShaderSprite to your screen, modify your Screen’s code so its methods are as shown in the following code:

```csharp
public partial class GameScreen
{
    CustomShaderSprite customShaderSprite;

    void CustomInitialize()
    {
        customShaderSprite = new CustomShaderSprite(Shader);
        customShaderSprite.Texture = TextureFile;

        SpriteManager.AddDrawableBatch(customShaderSprite);
    }

    void CustomActivity(bool firstTimeCalled)
    {
    }

    void CustomDestroy()
    {
        SpriteManager.RemoveDrawableBatch(customShaderSprite);
    }

    static void CustomLoadStaticContent(string contentManagerName)
    {
    }
}
```

Running the project will result in the following being shown on screen:

<figure><img src="../../.gitbook/assets/image (11).png" alt=""><figcaption></figcaption></figure>
