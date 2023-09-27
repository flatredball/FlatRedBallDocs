## The problem

For most users, the GuiManager.Cursor.WorldXAt and GuiManager.Cursor.WorldYAt serves their purpose. But, what if you want to reposition the camera. For example, in a top down shooter, you may have the camera to rotate with the player. Or, in an isometric game, you want to click on the ground to move a character or set a waypoint.

![IsometricWorldCoordinate.jpg](/media/migrated_media-IsometricWorldCoordinate.jpg)

## The Solution

This function will return the 3D point your mouse intersects with the passed in plane.

Add the following using statement:

    using Microsoft.Xna.Framework;

Add this method somewhere you can access it, such as your screen:

     private Vector3 GetWorldCoordinate(Plane CursorPlane)
     {
        //Get the distance to the intersetion point
        float? distance = GuiManager.Cursor.GetRay().Intersects(CursorPlane);
        Vector3 mousePosition = Vector3.Zero;

        //Make sure the cursor intersects
        if(distance.HasValue)
        {
           //Get the direction vector for the ray
           Vector3 translationVector = GuiManager.Cursor.GetRay().Direction;
           translationVector.Normalize();

           //Set the distance of the vector to the distance to the intersection point
           translationVector = Vector3.Multiply(translationVector, (float)distance);

           //Get the translation matrix
           Matrix translationMatrix = Matrix.CreateTranslation(translationVector);

           //Translate the mouse cursor point to the intersection point
           mousePosition = Vector3.Transform(GuiManager.Cursor.GetRay().Position, translationMatrix);
        }

        return mousePosition;
     }

## Applying the Function

You'll need to define the plane you want the cursor to be registered at. I'll provide 2 examples.

Plane for the ground in an Isometric game (XZ Plane):

    Plane mousePlane = new Plane(Vector3.Zero, new Vector3(0, 0, 1), new Vector3(1, 0, 0));

Plane for Top Down Shooter (XY Plane):

    Plane mousePlane = new Plane(Vector3.Zero, new Vector3(0, 1, 0), new Vector3(1, 0, 0));

Now, you can call the function in your CustomActivity method to get the 3D point the cursor is at.

Place in your screen's CustomActivity (or somewhere equivalent):

    Vector3 worldCoord = GetWorldCoordinate(mousePlane);

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
