## Introduction

The Path object provides a way to define a 2D path using lines and arcs. Paths can be used for the movement of objects such as enemies in a shoot-em-up game (shmup). Paths can be created in code and the FlatRedBall Editor and can easily integrate with games in edit mode.

## Example - Defining a Path in the FlatRedBall Editor

To define a path in the FlatRedBall Editor:

1.  Add a new object to a Screen or Entity

2.  Select **Path** as the type

    ![](/media/2021-11-img_61927e51d938c.png)

3.  Select the newly-created Path and click on the Variables tab

    ![](/media/2021-11-img_61927e9eec6be.png)

4.  Click the Add to Path button to add segments to the path

    ![](/media/2021-11-img_61927eccef025.png)

## Example - Creating a Path in Code

Paths can also be created or modified in code. Paths are built through move, line, and arc calls. Every call will set the *end point* which serves as the starting point for the next call. The following methods are available for modifying the path:

-   MoveTo - Moves the end point to the absolute positions.
-   MoveToRelative - Moves the end point to the argument points relative to the current end point.
-   LineTo - Draws a line to the absolute position.
-   LineToRelative - Draws a line to the position relative to the current end point.
-   ArcTo - Draws an arc to the absolute position.
-   ArcToRelative - Draws an arc to the position relative to the current end point.

Typically the Relative methods are recommend over the absolute methods, as this allows paths to be shifted. The FlatRedBall Editor only provides access to the Relative methods. The following code shows how to construct a path in code:

    var pathInstance = new FlatRedBall.Math.Paths.Path();
    pathInstance.LineToRelative(50, 50);
    pathInstance.ArcToRelative(0, -100, -MathHelper.ToRadians(180));
    pathInstance.MoveToRelative(0, -100);
    pathInstance.LineToRelative(200, 0);

![](/media/2021-11-img_6193daaacff55.png)

## Example - Visualizing Paths in Edit Mode

Paths can be visualized using EditorVisuals when the game is in Edit Mode. This example assumes a path named PathInstance.

1.  Open the Screen or Entity which has the Path
2.  Add a partial CustomActivityEditMode with the following code:

&nbsp;

    partial void CustomActivityEditMode()
    {
        EditorVisuals.DrawPath(PathInstance);
    }

The Path will now update in realtime as it is edited. [![](/media/2021-11-15_08-43-00.gif)](/media/2021-11-15_08-43-00.gif)

## Example - Following a Path

Paths by themselves do not provide the ability to change the velocity of an object, but they do provide a method PointAtLength which can be used to position an object. Typically a variable is used to keep track of the distance that an object has moved along the path. This value can be modified every frame, then it can be used to determine the position of an object along the path. For example, the following code shows how to move a circle along a path. Pressing the space bar resets the distance value.

    float DistanceAlongPath = 0;
    float MovementSpeed = 80;
    void CustomActivity(bool firstTimeCalled)
    {
        DistanceAlongPath += TimeManager.SecondDifference * MovementSpeed;
        CircleInstance.Position = PathInstance.PointAtLength(DistanceAlongPath).ToVector3();

        if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
        {
            DistanceAlongPath = 0;
        }
    }

![](/media/2021-11-15_09-00-17.gif)

## Example - TangentAtLength

The TangentAtLength returns a Vector2 describing the unit vector parallel (tangent) to the path at the argument length. This can be used to determine the velocity of an object moving along the path. The following code shows how to draw a line displaying the tangent at length.

    Line line;
    void CustomInitialize()
    {
        line = new Line();
        line.Visible = true;

        Camera.Main.X = 100;
        Camera.Main.Y = -100;
    }

    float DistanceAlongPath = 0;
    float MovementSpeed = 80;
    void CustomActivity(bool firstTimeCalled)
    {
        DistanceAlongPath += TimeManager.SecondDifference * MovementSpeed;
        CircleInstance.Position = PathInstance.PointAtLength(DistanceAlongPath).ToVector3();

        var velocityEndpoint = PathInstance.TangentAtLength(DistanceAlongPath);
        line.SetFromAbsoluteEndpoints(CircleInstance.Position, 
            CircleInstance.Position + (velocityEndpoint * 50).ToVector3());

        if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
        {
            DistanceAlongPath = 0;
        }
    }

  [![](/media/2021-11-16_08-54-00.gif)](/media/2021-11-16_08-54-00.gif)
