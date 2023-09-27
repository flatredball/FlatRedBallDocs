## Introduction

The RenderTargetRenderer class can be used to greatly increase the performance of FlatRedBall games which present complex scenes which never or rarely change. For static scenes a RenderTargetRenderer allows for near infinite complexity - specifically it allows for a very large number of visual elements to be drawn with almost no slowdown. Also, the RenderTargetRenderer is an easy way to render to a RenderTarget for post-processing.

## Performance Example

This example will show how to render a very large number of Entities with essentially no slowdown. To set up the project:

1.  Create a new Glue project
2.  Import the following Entity: [File:GraphicWithText.entz](/frb/docs/index.php?title=File:GraphicWithText.entz "File:GraphicWithText.entz")
3.  Create a new Screen. I'll call mine GameScreen

Before we add anything to the game we'll want to turn off any framerate throttling so we can see actual performance differences. To do this open Game1.cs and add the following code to the Game1 constructor:

    IsFixedTimeStep = false;
    graphics.SynchronizeWithVerticalRetrace = false;

Next we'll add code to our GameScreen. To do this, open the GameScreen.cs file and modify the CustomInitialize and CustomActivity methods as follows:

    void CustomInitialize()
    {
        // This was written in 2015 on a laptop
        // Increase this if using more powerful 
        // computers to cause serious slowdown:
        const int instances = 10000;
        for(int i = 0; i < instances; i++)
        {
            var instance = new Entities.GraphicWithText();

            Camera.Main.PositionRandomlyInView(instance, 40, 140);

            // goign to bring in the Y a little so we can read debug output:
            instance.Y *= .8f;
            instance.Y -= 30;

            instance.ConvertToManuallyUpdated();
        }
    }

    void CustomActivity(bool firstTimeCalled)
    {
        FlatRedBall.Debugging.Debugger.Write(1 / TimeManager.SecondDifference);
    }

This results in the game running around 7 frames per second (on my hardware at the time of this writing): ![LowFpsPart1.PNG](/media/migrated_media-LowFpsPart1.PNG) Notice that the entities are converted to being manually updated, which reduces the update load significantly. The low frame rate in this case comes almost purely from rendering. For more information on ConvertToManuallyUpdated, [see this page](/frb/docs/index.php?title=Glue:Reference:Code:ConvertToManuallyUpdated "Glue:Reference:Code:ConvertToManuallyUpdated"). In this case we'll assume that once the Entities have been placed they will not need to move or change otherwise. We can therefore take a "snapshot" of the screen using the RenderTargetRenderer and improve the performance significantly. Since the RenderTargetRender only creates a Texture2D, we will need to create an object to display it. To do this:

1.  Switch to Glue
2.  Right-click on the Objects folder under the GameScreen
3.  Select "Add Object"
4.  Verify "FlatRedBall or Custom Type" is selected
5.  Select the Sprite type
6.  Call the Sprite RenderTargetSprite

Now we can switch to code to create a Texture2D for the Sprite. To do this, replace the CustomInitialize function with the following:

    void CustomInitialize()
    {
        var renderer = new EntityToTexture.RenderTargetRenderer(
            Camera.Main.DestinationRectangle.Width, Camera.Main.DestinationRectangle.Height);

        // This was written in 2015 on a laptop
        // Increase this if using more powerful 
        // computers to cause serious slowdown:
        const int instances = 10000;
        for(int i = 0; i < instances; i++)
        {
            var instance = new Entities.GraphicWithText(ContentManagerName, false);

            instance.AddToManagers(renderer.Layer);

            Camera.Main.PositionRandomlyInView(instance, 40, 140);

            // goign to bring in the Y a little so we can read debug output:
            instance.Y *= .8f;
            instance.Y -= 30;

            instance.ConvertToManuallyUpdated();
        }

        renderer.PerformRender(ContentManagerName, "custom texture");

        RenderTargetSprite.Texture = renderer.Texture;
        RenderTargetSprite.Width = Camera.Main.OrthogonalWidth;
        RenderTargetSprite.Height = Camera.Main.OrthogonalHeight;
        
    }

The result is a much higher framerate which fluctuated into the 2000's: ![HighFps1.PNG](/media/migrated_media-HighFps1.PNG)

## Further optimizations

The example above shows how to perform a single render for all visuals and then to reuse that in a regular FRB Sprite for maximum performance. Of course, if the entities were being created only for a single render then we would want to destroy the entities after the render was finished. The CustomInitialize would be modified as follows:

    void CustomInitialize()
    {
        var renderer = new EntityToTexture.RenderTargetRenderer(
            Camera.Main.DestinationRectangle.Width, Camera.Main.DestinationRectangle.Height);

        var list = new List<Entities.GraphicWithText>();

        // This was written in 2015 on a laptop
        // Increase this if using more powerful 
        // computers to cause serious slowdown:
        const int instances = 10000;
        for(int i = 0; i < instances; i++)
        {
            var instance = new Entities.GraphicWithText(ContentManagerName, false);
            list.Add(instance);

            instance.AddToManagers(renderer.Layer);

            Camera.Main.PositionRandomlyInView(instance, 40, 140);

            // goign to bring in the Y a little so we can read debug output:
            instance.Y *= .8f;
            instance.Y -= 30;

            instance.ConvertToManuallyUpdated();
        }

        renderer.PerformRender(ContentManagerName, "custom texture");

        // Now that the render is finished we can destroy all the objects:
        foreach(var item in list)
        {
            item.Destroy();
        }

        RenderTargetSprite.Texture = renderer.Texture;
        RenderTargetSprite.Width = Camera.Main.OrthogonalWidth;
        RenderTargetSprite.Height = Camera.Main.OrthogonalHeight;
        
    }

The immediate destruction of the entities does not necessarily boost frame rate, but it does remove objects from the game which can reduce ram usage.

## ReRender

The ReRender function allows a render target to render itself again to the texture. The ReRender function has a number of conveniences built-in:

-   The initialization code does not need to be run again - the size of the texture, content managers, and name of the texture are all preserved
-   The Texture2D reference remains valid, so it does not need to be re-assigned
-   Objects do not need to be re-added to the RenderTargetRenderer's Layer - they are preserved.

The full code example for using ReRender is as follows:

    List<Entities.GraphicWithText> list = new List<Entities.GraphicWithText>();
    EntityToTexture.RenderTargetRenderer renderer;

    void CustomInitialize()
    {
        renderer = new EntityToTexture.RenderTargetRenderer(
            Camera.Main.DestinationRectangle.Width, Camera.Main.DestinationRectangle.Height);


        // This was written in 2015 on a laptop
        // Increase this if using more powerful 
        // computers to cause serious slowdown:
        const int instances = 10000;
        for(int i = 0; i < instances; i++)
        {
            var instance = new Entities.GraphicWithText(ContentManagerName, false);
            list.Add(instance);

            instance.AddToManagers(renderer.Layer);

            Camera.Main.PositionRandomlyInView(instance, 40, 140);

            // goign to bring in the Y a little so we can read debug output:
            instance.Y *= .8f;
            instance.Y -= 30;

            instance.ConvertToManuallyUpdated();
        }

        renderer.PerformRender(ContentManagerName, "custom texture");

        RenderTargetSprite.Texture = renderer.Texture;
        RenderTargetSprite.Width = Camera.Main.OrthogonalWidth;
        RenderTargetSprite.Height = Camera.Main.OrthogonalHeight;
        
    }

    void CustomActivity(bool firstTimeCalled)
    {
        FlatRedBall.Debugging.Debugger.Write(1 / TimeManager.SecondDifference);

        var keyboard = InputManager.Keyboard;
        
        if(keyboard.KeyPushed(Keys.Space))
        {
            foreach(var item in list)
            {
                item.RotationZ += .3f;
                // it's manually updated so we need to force an update
                item.ForceUpdateDependenciesDeep();
            }

            renderer.ReRender();
        }
    }

Since all objects receive a full update after rotation, updates can be expensive. However once updates are complete the game resumes at full framerate: ![RotatedHighFps.PNG](/media/migrated_media-RotatedHighFps.PNG)

## Integration with Glue

The examples above show how to create entity instances and manually place them on the RenderTargetRenderer Layer. These examples illustrate how to work with the RenderTargetRenderer, but they do not reflect real Glue scenarios where objects may be defined in Glue or in files (such as Tiled TMX files) and added to Layers also created in Glue. Fortunately existing Layers can be added to RenderTargetRenderer instances. The following example code shows how to take a LayerInstance defined in Glue and to add it to the RenderTargetRenderer:

    // assuming renderer is a valid RenderTargetRenderer:
    SpriteManager.RemoveLayer(LayerInstance);
    renderer.Camera.AddLayer(LayerInstance);

Now anything that is added to that Layer will be part of the RenderTargetRenderer. For more information see the [FlatRedBall.SpriteManager.RemoveLayer](/frb/docs/index.php?title=FlatRedBall.SpriteManager.RemoveLayer "FlatRedBall.SpriteManager.RemoveLayer") and [FlatRedBall.Camera.AddLayer](/frb/docs/index.php?title=FlatRedBall.Camera.AddLayer "FlatRedBall.Camera.AddLayer") pages.
