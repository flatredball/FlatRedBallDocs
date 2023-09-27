## Introduction

This tutorial will show you how to take any Glue entity and render it to a single Texture. This tutorial will use render targets, multiple FlatRedBall cameras, and modification to Game1.cs, so it does require more-advanced programming.

## Why render to a texture?

You may want to render an Entity to a texture for a number of reasons:

-   Enable visual effects on an entire entity such as transparency or color operations
-   Enable scaling of an entire Entity by rendering it with a single Sprite
-   Improve performance by [reducing render breaks](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Render_State_Changes "FlatRedBallXna:Tutorials:Render State Changes")
-   Improve performance by [reducing the number of managed objects](/frb/docs/index.php?title=FlatRedballXna:Tutorials:Manually_Updated_Objects:Measuring_Automatic_Updates "FlatRedballXna:Tutorials:Manually Updated Objects:Measuring Automatic Updates")
-   Render FlatRedBall Entities in XNA SpriteBatch or other non-FlatRedBall rendering environment/engine.

## Setup

For this tutorial we will use a single Entity which contains a large number of Circles. We will render this Entity to a Texture, then use this Texture on a Sprite in a Screen.

### Create a new project

The first step is to create a new project in Glue:

1.  Open Glue
2.  Select File-\>New Project
3.  Select FlatRedBall XNA 4.0 (PC) as the project type
4.  Enter the name EntityToTexture
5.  Click "Make my project!"

### Add LotsOfCircles Entity

Next add the LotsOfCircles Entity:

1.  Right-click on Entites
2.  Select "Add Entity"
3.  Enter the name LotsOfCircles and click OK
4.  Add a new object to LotsOfCircles
5.  Select the type as PositionedObjectList
6.  Select the list type as Circle
7.  Enter the name CircleList

![CreateLotsOfCircles.gif](/media/migrated_media-CreateLotsOfCircles.gif)

### Add Circles in code

Next we'll add some Circle instances in code. We'll do it in code rather than in Glue because it will be faster to add a large number of circles in code. To do this:

1.  Select Project-\>View in Visual Studio
2.  Expand the Entities folder
3.  Double-click LotsOfCircles.cs
4.  Add the following code to CustomInitialize:

&nbsp;


    private void CustomInitialize()
    {
        const int numberOfCircles = 200;

        for(int i = 0; i < numberOfCircles; i++)
        {
            Circle circle = ShapeManager.AddCircle();

            circle.AttachTo(this, false);

            circle.Radius = 16;

            circle.RelativeX = (float)FlatRedBallServices.Random.NextDouble() * -400 + 200;
            circle.RelativeY = (float)FlatRedBallServices.Random.NextDouble() * -400 + 200;

            this.CircleList.Add(circle);
        }
    }

### Add a Screen which will contain a LotsOfCircles instance

Next add a Screen to contain the LotsOfCircles instance:

1.  Right-click on Screens
2.  Select "Add Screen"
3.  Enter the name MainScree and click OK
4.  Drag+drop the LotsOfCircles onto the MainScreen and click OK

![LotsOfCirclesInstanceInScreen.gif](/media/migrated_media-LotsOfCirclesInstanceInScreen.gif)

### You should see a lot of circles

If you run the game now you will see a lot of circles. Of course, these circles are all part of the LotsOfCircles entity.

![LotsOfCirclesRuntime.gif](/media/migrated_media-LotsOfCirclesRuntime.gif)

## Adding a new Camera

The next step will be to add a new Camera to your game. This Camera will be a special Camera which will we will manually render. This allows us to set a render target prior to rendering the Camera, which will serve as our texture.

**All code from here:** The remainder of this tutorial will be done in pure C# even though some of it could be done in Glue. The reason is to show you how everything works at a lower-level so you can come up with a solution that fits your particular game.

**Code in Game1?:** This tutorial will write code in Game1, and our Screen will access Game1. This is not recommended practice for a full game; however, we are going to write the code here to focus in the topic of this tutorial as opposed to setting up a proper structure for rendering and passing information from Game1 to your Screen.

Add the following code to your
