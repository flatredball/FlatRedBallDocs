## Local (Object) Coordinates

All PositionedObjects have a local coordinate system. This local coordinate system is defined as being identical to the world coordinate system when the object is not rotated. As an object rotates, its coordinate system rotates along with its physical representation.

Local coordinates are most often used with attachments. For example, if there are two PositionedObjects named Child and Parent, and Child is attached to Parent, the location of the child relative to the parent is determined by the child's relative position values in the parent's local coordinates.

If the parent is not rotated, then the relative values will match the world coordinate system. Mathematically, the relative values will move along the coordinate system defined by the Parent PositionedObject's RotationMatrix.

## Why are local axes important?

Behavior which depends on the orientation of an object is quite common in games. This could include a car accelerating in the direction it is facing or a space ship firing guns in the direction it is facing. From the point of view of the car, it is simply driving "forward". Similarly, the space ship is firing "straight ahead". However, if the car or spaceship is rotated, we need to be able to translate "forward" or "straight ahead" into world coordinates.

## How to convert Local to World Coordinates

For this section, I'll use two different situations where local coordinates need to be transformed to world coordinates. One example is a space ship which can rotate freely and fires bullets in the direction that it is facing. The other example is a situation where you need to determine the vector that is perpendicular to a surface (the normal to a surface) so you can accurately perform bouncing.

### Using attachments

As I mentioned before, relative values are applied in the coordinate space of the parent object. Therefore, it is possible to simply attach a child object to a parent object, set the relative values to the desired local coordinates, then take the difference between the child's absolute position and the parent's position.

First, consider the space ship example. For simplicity, the space ship may simply be a single Sprite. Rotating the space ship simply sets the z rotational velocity (RotationZVelocity) variable. However, there are two problems. The first is where the bullets should originate, and the second is which direction the bullets should fly. Fortunately, we can solve both of these problems using attachments.

The first step is to determine the orientation of the ship when not rotated. This isn't too difficult - simply look at the graphic outside of the engine, or load it up in the SpriteEditor or in code. In my example, as shown in the following graphic, the ship is facing "up" or along the positive Y axis.

![Ship](/media/migrated_media-Ship)

For simplicity's sake, we'll say the ship has a ScaleY of 1 (or a total height of 2 units), and that we want the bullets to appear at the tip of the nose of the ship. Therefore, when the ship is not rotated, bullets will appear with the same X value as the ship, and their Y value will equal the ships Y value plus 1. Or in other words, the relative X position of new bullets is 0, and the relative Y position of new bullets is 1.

To make things easier, a common technique in such a situation is to create a PositionedObject, attach it to the Ship, and set the relative values to their desired values. Then whenever a new bullet is fired the attachment needs to be updated and then the relative positioning can be used. The code to do this would be:

At class scope PositionedObject shipNose;

This code will only be called once - perhaps when the ship is initialized.

    shipNose = new PositionedObject();

    // 2nd argument to AttachTo can be true or false - doesn't matter since
    // we will be manually setting the relative values
    shipNose.AttachTo(ship, false);

    // now set the relative values
    shipNose.RelativeX = 0;
    shipNose.RelativeY = 1;
    shipNose.RelativeZ = 0; // may not be needed, but might as well to be sure

Whenever we want to fire a bullet, it would be done as follows

    // to bring the ship nose to the proper position
    shipNose.UpdateDependencies(TimeManager.CurrentTime);
    // Create the Sprite
    Sprite bulletSprite = SpriteManager.AddSprite("bulletTexture.bmp");
    bulletSprite.Position = shipNose.Position;

With this code, the bullets will automatically be created and placed at the ship's nose, regardless of the ship's position or orientation. How handy!

The next question is how to set the velocity of the bullets. There are two things which are require before the velocity can be set. First is to determine the speed of the bullets. The speed doesn't have anything to do with the direction. If a car is driving at 30 miles per hour, that doesn't tell you whether the car is heading north or south. It just gives a magnitude. Similarly, we need to determine the speed of our bullets. That's easy - pick a number, and if it doesn't feel right in-game, adjust it.

The next step is to find the direction that the bullet will travel. To do this, we can simply subtract the positions of the ship from the nose. This will give us a unit vector indicating the velocity of the ship. Then the vector needs to be scaled, then the bullet can use it as its velocity. The code to do this is as follows:

    float speed = 5; // in units per second
    Vector3 velocityVector = shipNose.Position - ship.Position;
    Vector3.Multiply(ref velocityVector, speed, out velocityVector);
    bulletSprite.Velocity = velocityVector;

And that will get you the desired effect. As simple as this method is, there are a few problems. First, this method may not be practical in all situations. For a ship, it makes sense to keep track of the location of the nose. But a more abstract object like the surface of a platform wouldn't be a good place to use this technique. Not only is it uncommon to associate a separate object with the surface of a platform, but it is conceivable to have dozens or even hundreds of individual platforms in a level. Representing the surface normals with attached doubles the number of Sprites in a level which results in runtime inefficiency and unnecessary clutter. Fortunately, a cleaner and more efficient solution is available.

### Using the RotationMatrix to determine local axes

PositionedObjects provide two ways to get and set rotational orientation. One is the more common RotationX, RotationY, and RotationZ properties. When only one axis is modified, the results are relatively predictable. Sprites are usually only rotated on one axis, so this method of applying rotation is acceptable.

When rotating on multiple axes, rotation can become difficult to predict. Complex rotations are usually represented as rotational matrices rather than a series of RotationX, RotationY, and RotationZ values. However, this is not the primary reason for the RotationMatrix property.

As mentioned previously, child relative values are applied using the parent's local coordinate system. A PositionedObject's local coordinates are represented using the RotationMatrix property. Therefore, we can use this matrix to get a PositionedObject's local coordinates and translate a position in local coordinates to absolute coordinates.

One way to do this is simply to take a vector relative to the object in local coordinates, and translate it by the object's RotationMatrix. This will return a vector (or position) relative to the object.

The following code results in the shipNose being in the same position as using the attachment code, but is slightly more efficient.

    // we could either create a PositionedObject to store the location of the nose
    // or just calculate the value whenever it's needed.  Assuming there are frames
    // where the player is neither firing nor putting any input it, just
    // calculating the direction when needed can make things more efficient.

    // the relativePosition is the position in local coordinates.
    // Make it 0,1,0 to make the position be 1 unit infront of the ship:
    Vector3 relativePosition = new Vector3(0, 1, 0);
    Matrix rotationMatrix = ship.RotationMatrix;
    Vector3.Transform(ref relativePosition, ref rotationMatrix, out relativePosition);

    Sprite bulletSprite = SpriteManager.AddSprite("bulletTexture.bmp");
    bulletSprite.Position = ship.Position + relativePosition;

    float speed = 5; // in units per second
    Vector3.Multiply(ref relativePosition, speed, out relativePosition);
    bulletSprite.Velocity = relativePosition;

One benefit of this code, as mentioned before, is there is no overhead when the code is not needed. If no bullet is fired, then these operations are not performed. Keep in mind that attachments do have very little overhead, so if you are using them, there's no need to feel guilty. This alternative method can be useful in situations where performance is very important - such as physics simulations or if there are many instances using this method to determine direction facing.

### Reading individual axes from the rotationMatrix property

In situations where we are concerned with particular axes such as just the local Y axis or the local X axis, we can avoid the Vector3.Transform call and creation of Vector3s. Each row in the rotationMatrix represents one of the axes in the objects coordinate space.

Consider the example of needing to determine the normal of a surface for bouncing. Generally, bouncing is done with the projection of matrices onto the surface to determine the parallel and perpendicular components of the matrix. As a surface is defined by its normal, the normal of the surface needs to be calculated.

In this example, the surface is represented by a red Sprite. When unrotated, the top of the Sprite is a flat surface - that is, its normal is aligned with the Y axis.

![Surface with Normal](/media/migrated_media-Surface_with_Normal)

When rotated, the normal obviously rotates with the object itself.

![Rotated surface with Normal](/media/migrated_media-Rotated_surface_with_Normal)

Since we know the normal to the surface aligns with the local Y axis, we can simply read the 2nd row of values from the rotationMatrix to retrieve the Y axis. The following code would create a new Vector3 representing the direction pointed by the red arrow:

    // assume surface is the red surface Sprite
    Vector3 surfaceNormal =  surface.RotationMatrix.Up;

    // or
    Vector3 surfaceNormal = new Vector3( 
        surface.RotationMatrix.M21,
        surface.RotationMatrix.M22,
        surface.RotationMatrix.M23);

If the axis of interest were the X axis, then the values would be M11, M12, and M13 (in DirectX/XNA, the rows represent the indiviudal axes, rather than the columns as in "regular math").
