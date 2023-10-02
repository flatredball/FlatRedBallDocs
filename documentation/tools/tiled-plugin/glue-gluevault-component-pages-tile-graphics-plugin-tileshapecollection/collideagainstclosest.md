## Introduction

The CollideAgainstClosest method can be used to perform collision between a Line and a TileShapeCollection. The method returns whether a collision has occurred. Also, it marks the closest collision point. Line vs TileShapeCollection closest collision can be used for a variety of gameplay purposes such as:

-   Laser vs. level
-   Grappling hook vs. level
-   Fast-traveling bullet vs level

Other types of shapes usually are checked over the course of multiple frames as a collidable object moves, and these shapes have a fixed size. However, lines can be of infinite size, and often times are checked just once, such as when a bullet is fired.

## Code Example - Marking the Closest Point

The following code can be added to a GameScreen to draw a line from the camera's position to the cursor's position. CollideAgainstClosest is used to find the last collision point which is used to draw a circle. This code assumes that your screen (such as GameScreen or Level1) contains a TileShapeCollection named SolidCollision.

![](/media/2023-05-img_646e09dec8499.png)

    // add the following using at the to of your file to access EditorVisuals:
    using GlueControl.Editing;

    Line line;
    void CustomInitialize()
    {
        line = new Line();
        line.Visible = true;

    }

    void CustomActivity(bool firstTimeCalled)
    {
        line.SetFromAbsoluteEndpoints(
            Camera.Main.Position.AtZ(0),
            GuiManager.Cursor.WorldPosition.ToVector3(), 
            // Must have position at endpoint 1
            Line.SetFromEndpointStyle.PositionAtEndpoint1);

        if(SolidCollision.CollideAgainstClosest(line))
        {
            var collisionPoint = line.LastCollisionPoint.ToVector3();

            EditorVisuals.Circle(8, collisionPoint);
        }
    }

    void CustomDestroy()
    {
        line.Visible = false;
    }

  [![](/media/2023-05-24_06-09-22.gif)](/media/2023-05-24_06-09-22.gif)
