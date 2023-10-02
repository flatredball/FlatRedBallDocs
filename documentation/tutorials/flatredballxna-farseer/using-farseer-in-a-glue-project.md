## Introduction

This walkthrough shows how to add Farseer to a simple Glue project. We will create a diagonal stack of blocks which will fall and collide against a static surface. This tutorial uses the FlatRedBall desktop engine, which means it uses proper XNA (as opposed to MonoGame). MonoGame projects must use the MonoGame version of the Farseer .dll.

## Creating the Block Entity

We will begin with an empty Glue project:

![](/media/2016-11-img_583523104d726.png)

Add a new Block entity:

1.  Right-click on Entities
2.  Select **Add Entity**
3.  Enter the name Block
4.  Click **OK**

![](/media/2016-11-img_58352352c6f2c.png)

Next, we'll add a Sprite to the Block so we can see it in-game:

1.  Expand the Block entity

2.  Right-click on Objects

3.  Select **Add Object**

4.  Select Sprite

    ![](/media/2016-11-img_58352394527bd.png)

5.  Click **OK**

The Sprite needs to be modified so it will show up in game:

1.  Change the Sprite's **Color Operation** to **Color**. This allows us to use solid colors to draw the sprite instead of a texture.

2.  Set the **Red** value to **1**

3.  Delete the **Texture Scale** value

4.  Enter a **Width** of **32**

5.  Enter a **Height** of ****32****

    ![](/media/2016-11-img_583524551f2fb.png)

## Creating the GameScreen

Next we'll create a screen to hold our Block instances and the Farseer logic:

1.  Right-click on **Screens**
2.  Select **Add Screen**
3.  Enter the name **Game Screen**
4.  Click **OK**

![](/media/2016-11-img_583526c9914a3.png)

GameScreen needs a Block list so that we can construct the blocks in code and have them be automatically managed. To do this:

1.  Push and hold the right mouse button on the **Block** entity
2.  Drag the entity onto **GameScreen**
3.  Release the mouse button
4.  Select **Add Entity List**

![](/media/2016-11-img_58352798ddb2d.png)

## Adding Farseer to the Visual Studio Project

Now that our Glue project has been created, we'll add Farseer to the Visual Studio project:

1.  Download the Farseer precompiled .dll: <https://github.com/vchelaru/FlatRedBall/blob/master/Engines/FlatRedBallXNA/3rd%20Party%20Libraries/Farseer/FarseerPhysics%20XNA.dll?raw=true>
2.  Open the game project in Visual Studio
3.  Right-click on **References** in Visual Studio under your game project
4.  Select **Add Reference**...
5.  Click the **Browse** category
6.  Click the **Browse...** button
7.  Navigate to where you saved the Farseer dll file
8.  Select the file and click **Add**

![](/media/2016-11-img_583528ae9657b.png)

## Preparing the Block Entity for Farseer

We'll add the code to create a Farseer Body  instance in the Block.cs  file. Open the Block file and modify the class so it appears as shown in the following code:

``` lang:c#
public partial class Block
{
    Body physicsBody;

    /// <summary>
    /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
    /// This method is called when the Entity is added to managers. Entities which are instantiated but not
    /// added to managers will not have this method called.
    /// </summary>
    private void CustomInitialize()
    {
    }

    public void CreateFarseerPhysics(World world, Vector2 position, float conversionFactor)
    {
        position.X /= conversionFactor;
        position.Y /= conversionFactor;
        var width = SpriteInstance.Width / conversionFactor;
        var height = SpriteInstance.Height / conversionFactor;

        physicsBody = BodyFactory.CreateRectangle(
            world, width, height, 1, position);

        physicsBody.Restitution = .6f;
        physicsBody.SleepingAllowed = true;
        physicsBody.Friction = .5f;
        physicsBody.BodyType = BodyType.Dynamic;
    }
    private void CustomActivity()
    {

    }

    private void CustomDestroy()
    {

    }

    private static void CustomLoadStaticContent(string contentManagerName)
    {

    }

    internal void UpdateToFarseer(float conversionFactor)
    {
        this.X = physicsBody.Position.X * conversionFactor;
        this.Y = physicsBody.Position.Y * conversionFactor;
        this.RotationZ = physicsBody.Rotation;
    }
}
```

## Adding code to GameScreen

Finally we'll add code to our GameScreen . Modify your GameScreen.cs  file so it looks like the following code:

``` lang:c#
public partial class GameScreen
{
    World world;

    Body ground;

    private const float ConversionDivisor = 10; 
    private float ConversionFactor => SpriteManager.Camera.OrthogonalHeight / ConversionDivisor; //Conversion Factor: the screen's height corresponds to 10 meters

    private float ToFarseer(float pixels) => pixels / ConversionFactor;   

    private float FromFarseer(float meters) => meters * ConversionFactor;
    void CustomInitialize()
    {
        CreateFarseerWorld();

        CreateBlocks();

        CreateGround();
    }

    private void CreateFarseerWorld()
    {
        float gravity = -9.82f;
        world = new World(new Vector2(0, gravity));
    }

    private void CreateBlocks()
    {
        int blockCount = 6;
        for (int i = 0; i < blockCount; i++)
        {
            var block = new Entities.Block();

            var position = new Vector2(-80 + i * 15f, i * 40); //this position will be converted to Farseer Units inside block's CreateFarseerPhysics()

            block.CreateFarseerPhysics(world, position, ConversionFactor);

            BlockList.Add(block);
        }
    }

    private void CreateGround()
    {
        var frbRectangle = new AxisAlignedRectangle();
        frbRectangle.Width = 700;
        frbRectangle.Height = 13;
        frbRectangle.Y = -200;
        frbRectangle.Visible = true;

        ground = FarseerPhysics.Factories.BodyFactory.CreateRectangle(
            world,
            ToFarseer(frbRectangle.Width),
            ToFarseer(frbRectangle.Height), 
            1, 
            new Vector2(ToFarseer(0), ToFarseer(frbRectangle.Y)));

        ground.Restitution = .7f;
        ground.SleepingAllowed = true;
        ground.IsStatic = true;
        ground.Friction = .5f;
    }

    void CustomActivity(bool firstTimeCalled)
    {
        world.Step(TimeManager.SecondDifference);

        foreach (var block in BlockList)
        {
            block.UpdateToFarseer(ConversionFactor);
        }
    }

    void CustomDestroy()
    {

    }

    static void CustomLoadStaticContent(string contentManagerName)
    {

    }

}
```

If we run the game we'll see our blocks falling and colliding: [![fallingblocks](/media/2016-11-FallingBlocks.gif)](/media/2016-11-FallingBlocks.gif)    
