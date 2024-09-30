# Code-Only Velcro Projects

### Introduction

The [Velcro (formerly Farseer) Physics Engine](https://github.com/Genbox/VelcroPhysics) is a .NET library which can be used to add more advanced physics beyond what is offered by FlatRedBall's shapes (such as Circle or Rectangle). Note that the Github page for Velcro states that sponsorship is required to use Velcro Physics in a commercial project, so consider this if you plan on selling your game.

### General Approach

In general, the following must be done to use Velcro Physics:

1. Instantiate a World object
2. Call the World instance's Step function every frame
3. Create one or more Body instances - A Body is created through Velcro's Factory classes. The Body must be added to the World.
4. Set properties on the Body instances - You can set properties such as size, orientation, velocity, and how the bodies respond to collisions (inertia, elasticity, friction).

This demo will create two Body instances which will perform the physics simulation. It also creates a FlatRedBall Circle and Polygon to display the visuals of the Velcro bodies.

### Adding Velcro Nuget Package

To add Velcro to your project:

1. Expand your game project's Dependencies
2.  Right-click on Packages and select **Manage NuGet Packages...**

    ![](../../.gitbook/assets/2023-05-img\_645b9201698a5.png)
3. Check the **Include prerelease** option
4. Search for **GenBox.VelcroPhysics.MonoGame**
5.  Add the Genbox.VelcroPhysics.MonoGame package to your project.

    ![](../../.gitbook/assets/2023-05-img\_645b92b86a8df.png)

### Code Example

Once you have added Velcro to your project, you can begin using the classes to perform physics simulations. The following is example code which could be added to a GameScreen to create a simple Velcro simulation:

```
using FlatRedBall;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;
using Genbox.VelcroPhysics.Dynamics;
using Genbox.VelcroPhysics.Factories;

namespace VelcroPhysicsTest.Screens;

public partial class GameScreen
{
    //Farseer Objects
    World mWorld;
    Body mBallBody;
    Body mPlatformBody;

    //FlatRedBall Objects
    Circle ball;
    Polygon mPlatformPolygon;

    void CustomInitialize()
    {
        // Farseer
        float gravity = -80;
        mWorld = new World(new Vector2(0, gravity));

        //Create a ball body with a radius of 32 and density of 1
        mBallBody = BodyFactory.CreateCircle(mWorld, 32, 1);
        mBallBody.Restitution = 1f;
        mBallBody.BodyType = BodyType.Dynamic;

        //Create a rectangle platform with a width of 400, height of 30,
        //density of 1, and position at 0, -12
        //Then set the position and rotation
        var rectangleWidth = 600;
        mPlatformBody = BodyFactory.CreateRectangle(mWorld, rectangleWidth, 30, 1, new Vector2(0, -120));
        mPlatformBody.Rotation = .1f;
        mPlatformBody.Restitution = 1f;
        mPlatformBody.BodyType = BodyType.Static;

        //FRB
        mPlatformPolygon = Polygon.CreateRectangle(rectangleWidth/2, 15f);
        mPlatformPolygon.X = mPlatformBody.Position.X;
        mPlatformPolygon.Y = mPlatformBody.Position.Y;
        mPlatformPolygon.RotationZ = mPlatformBody.Rotation;
        ShapeManager.AddPolygon(mPlatformPolygon);

        ball = new Circle();
        ball.Visible = true;
        ball.Radius = 32;
        ball.X = mBallBody.Position.X;
        ball.Y = mBallBody.Position.Y;

    }

    void CustomActivity(bool firstTimeCalled)
    {

        //Farseer: Only need to step (update) the world you added the objects to
        mWorld.Step(TimeManager.SecondDifference);

        //FRB: Don't forget to update the visual representations as well!!
        ball.X = mBallBody.Position.X;
        ball.Y = mBallBody.Position.Y;

        //mPlatformPolygon is static (doesn't move), so there is no need to update its position
    }

    void CustomDestroy()
    {

    }

    static void CustomLoadStaticContent(string contentManagerName)
    {
    }
}
```

![](../../.gitbook/assets/2016-11-10\_06-51-41.gif)

###

###
