# Model (.fbx)

### Introduction

The .fbx file format can be loaded into a MonoGame Model class which can be drawn to the screen. The FlatRedBall Camera provides matrices which simplify the drawing of a Model object. Since the Model object is a native MonoGame object, it must be draw either your Game1's Draw method or in an IDrawableBatch.

### Example: Loading and Drawing an .fbx file

Models can be loaded just like any other FlatRedBall file. For example, .fbx files can be dropped into Global Content Files.

<figure><img src="../../.gitbook/assets/image (24).png" alt=""><figcaption><p>Test .fbx file in Global Content Files</p></figcaption></figure>

Once the file has been added to global content, it can be drawn in Game1.cs as shown in the following code:

```csharp
protected override void Draw(GameTime gameTime)
{
    GeneratedDrawEarly(gameTime);
    FlatRedBallServices.Draw();
    GeneratedDraw(gameTime);

    var model = GlobalContent.Test;
    model.Draw(Matrix.Identity, Camera.Main.View, Camera.Main.Projection);

    base.Draw(gameTime);
}
```

