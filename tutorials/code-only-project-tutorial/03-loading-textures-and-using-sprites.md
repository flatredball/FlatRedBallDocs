# Loading Textures and Using Sprites

### Introduction

Textures (which use the type `Microsoft.Xna.Framework.Graphics.Texture2D`) are used to draw graphics on the screen. A Texture is a resource which is usually loaded from .png and is drawn to the screen using the Sprite type. This **code-only** tutorial shows how to load a PNG to disk and how to draw it on screen using a FlatRedBall Sprite.

### Adding a PNG to Your Project in Visual Studio

Before a PNG can be loaded, it must be added to your project. Normally the management of content files is handled by the FlatRedBall Editor, but this is something that must be done manually in a code-only project.&#x20;

You can add files to your project by manually editing the .csproj or you can add a file through Visual Studio (or your current IDE).

To add a file to the project through Visual Studio:

1. Find or create a PNG file that you would like to use
2.  Drag+drop the file into your Visual Studio project. Usually content is added to the Content folder, or a subfolder inside of the Content folder. \\

    <figure><img src="../../.gitbook/assets/2022-08-17_16_47_41.gif" alt=""><figcaption></figcaption></figure>
3.  Right-click on the file and select **Properties**

    ![](../../.gitbook/assets/2022-08-img\_62fd70599f0a8.png)
4.  Set the **Copy to Output Directory** item to **Copy if Newer**

    <figure><img src="../../.gitbook/assets/2022-08-img_62fd70994f0f8.png" alt=""><figcaption></figcaption></figure>

This tells Visual Studio to copy the Bear.png file to the output directory (where the .exe is created) while maintaining the folder structure. For example, if your .exe is built to \<Project Root>\bin\DesktopGL\x86\Debug\CodeOnly.exe, then the Bear.png file will be copied to \<Project Root>\bin\DesktopGL\x86\Debug\Content\Bear.png.

### Adding a PNG to Your Project in Visual Studio Code

To add a PNG to your project in Visual Studio Code:

1. Find or create a PNG file that you would like to use
2.  Drag+drop the file from an explorer window into your project's Content folder

    <figure><img src="../../.gitbook/assets/2022-08-13_08-11-58.gif" alt=""><figcaption></figcaption></figure>

We need to add an entry for the newly-added TextureFile so that it is copied to our project. We will need to do this for any PNG file (or other content file) that we add to our project in the future. To do this:

1.  Select your .csproj file to display its contents

    ![](../../.gitbook/assets/2023-08-img\_64d8e5b6f2b8c.png)
2.  Look for a section of the .csproj where existing content is already handled

    ![](../../.gitbook/assets/2023-08-img\_64d8e5f37d97b.png)
3.  Copy/paste one of the **None** blocks to copy the newly-added TextureFile.png

    ![](../../.gitbook/assets/2023-08-img\_64d8e63ce8f41.png)

### Adding a File by Modifying Your .csproj File

To modify your .csproj file, you can open it and add the referenced file, similar to adding a file in Visual Studio Code. Note that you can also add wildcards. For example:

```markup
<None Update="Content\*.png">
  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
</None>
```

### Creating a Texture2D

Next we'll create a Texture2D. Normally a Texture2D instance might be added to a Screen or Entity object, but we'll do all of our code in Game1 to keep things simple. Also, this example doesn't store a reference to the Texture2D at class scope, but you may want to do so in a real game so Texture2D reference can be reused outside of the initialization function. In this case we'll modify Game1.Initialize. The following code is the default for Initialize:

```csharp
protected override void Initialize()
{
    #if IOS
    var bounds = UIKit.UIScreen.MainScreen.Bounds;
    var nativeScale = UIKit.UIScreen.MainScreen.Scale;
    var screenWidth = (int)(bounds.Width * nativeScale);
    var screenHeight = (int)(bounds.Height * nativeScale);
    graphics.PreferredBackBufferWidth = screenWidth;
    graphics.PreferredBackBufferHeight = screenHeight;
    #endif

    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    GlobalContent.Initialize();
    GeneratedInitialize();

    base.Initialize();
}
```

Since we are not using any generated code from the FlatRedBall Editor and we are not targeting iOS, we can remove most of the code, as shown in the following snippet:

```csharp
protected override void Initialize()
{
    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    base.Initialize();
}
```

Now we can add code to load our PNG:

```csharp
protected override void Initialize()
{
    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    // Use the name of your file, which might be Bear.png or TextureFile.png or whatever yours was called
    var bearTexture = FlatRedBallServices.Load<Texture2D>("Content/Bear.png");

    base.Initialize();
}
```

Now that the texture is loaded, we can draw it with Sprites. For example, the following code adds a Sprite to the center of the screen:

```csharp
protected override void Initialize()
{
    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    // Use the name of your file, which might be Bear.png or TextureFile.png or whatever yours was called
    var bearTexture = FlatRedBallServices.Load<Texture2D>("Content/Bear.png");

    var sprite = SpriteManager.AddSprite(bearTexture);
    sprite.TextureScale = 1;

    Camera.Main.UsePixelCoordinates();

    base.Initialize();
}
```

The game now loads a Bear and shows it in the center of the screen.

![](../../.gitbook/assets/2022-08-img\_62fd72dc705cd.png)

### Modifying a Sprite

Sprites inherit from the PositionedObject class, just like the Circle type used in the previous tutorial. Therefore, Sprites have many of the same properties as Circles including Position, Velocity, and Acceleration. We can create multiple Sprites in a loop, changing their position by setting X and Y as shown in the following code snippet:

```csharp
protected override void Initialize()
{
    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    var bearTexture = FlatRedBallServices.Load<Texture2D>("Content/Bear.png");

    for(int i = 0; i < 5; i++)
    {
        var sprite = SpriteManager.AddSprite(bearTexture);
        sprite.TextureScale = 1;
        sprite.X = -100 + 40 * i;
        sprite.Y = i * 10;
    }


    Camera.Main.UsePixelCoordinates();

    base.Initialize();
}
```

This code creates five sprites, each using the same Texture2D.

![](../../.gitbook/assets/2022-08-img\_62fd7890cbed7.png)
