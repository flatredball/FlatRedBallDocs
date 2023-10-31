## Conceptually Understanding Matrices

### Introduction

3D computer graphics rely heavily on the use of matrices. Unfortunately in pure mathematics, the conceptual understanding of what a matrix "does" or "means" isn't explicitly taught, and this understanding usually doesn't come about until a student has a good understanding of linear algebra.

Although an understanding of matrices is not necessary to make many FRB games, knowing what a matrix does and how to use it in code can help improve your efficiency as a programmer.

This section will discuss matrices at a conceptual level. Don't worry, you don't need to know a lot of math to understand what I am going to explain here.

### The Flat World

Although the world is round, and when you move north, the actual direction you are moving depends on your position, I will ignore this fact to keep things simple. That is, we can consider that moving north is always in the same direction and moving east is always in the same direction - much like people thought when they considered the world to be flat.

To begin our example, imagine standing on a large, flat area of land. There are no landmarks. In fact, there is nothing that you can use to determine whether you are facing north, south, east, or west. However, just because you don't know what is north doesn't necessarily mean there isn't a north (no, I'm not trying to get philosophical). In other words, there is a "true" north, only you don't know what it is.

Let's say you are given the command to walk a certain distance in a certain direction. That is, you are given the command, "Walk west 1 unit." In this situation, you have two problems. First, which way is west? Second, even if you knew which way west was, how long is one unit? Is it one foot? One meter? One mile?

To actually walk west 1 units, you will need two things. First, you'll need a compass to tell you which way you are moving. Second, you'll need some kind of measuring device to tell you how far one "unit" is.

### The Compass and the Measuring Stick

Continuing the previous example, let's say that you now have a compass and a measuring stick. The compass tells you which direction you are facing, and the stick can be placed on the ground to indicate the length of one "unit". Now that you have a measure of direction and distance, you can accurately follow directions.

With this new equipment in hand, you receive the following orders:

"Move west 1 unit. Move north 1 unit. Leave a mark in the ground. Move east 2 units. Leave a mark in the ground. Move south 2 units. Leave a mark in the ground. Move west 2 units. Leave a mark in the ground."

In this situation, you should have moved as shown in the following image.

![WalkInSquare.png](/media/migrated_media-WalkInSquare.png)

This of course assumes that north is up, east is right, and so on.

### Changing Directions and Distances

So far, we assume that the compass and the measuring stick are accurate. Or perhaps another way to look at it is that the person who gave you the two devices was honest. However, consider what would happen if the person who gave you the compass decided to play a joke. He modified the compass so that it is slightly inaccurate. That is, when the compass indicates that you are facing north, you are actually facing north-east. When the compass indicates east, you are actually facing south-east. South becomes south-west, and west becomes north-west.

![RotatedWalkAround.png](/media/migrated_media-RotatedWalkAround.png)

An important point to make is that the square still appears to be a regular "square" to you, but to someone who knows which way true north is, it appears rotated by 45 degrees. Another interesting point is that the directions that you received didn't change at all - the only thing that changed is the compass. In fact, by changing the way that the compass points, you can actually draw a square of any orientation. To you, you are simply moving north, south, east, and west according to the compass.

Although this would probably be something you (as a holder of the measuring stick) would realize, in terms of math or instructions it is also possible to change the length of the stick. A measuring stick twice as long would produce a square that is twice as large.

What is important to realize is that the "directions" are separate from orientation and size. Conceptually, it's important to understand that the directions can change while compass or stick stay the same, or vice versa.

This brings us to two terms: "world coordinates" and "object coordinates". These are also referred to as "world space" and "object space". World space is the "authority" on what north is. That is, in our previous example, in world space, north is straight up and east is to the right. Object space is subject to a "compass" and "measuring stick" which may or may not be aligned with world space. In the situation where your compass worked correctly and the measuring stick actually measured one unit, then you were travelling in world space and object space. Object space and world space were aligned perfectly. Once the compass changes, the world space and your object space are no longer aligned. Travelling north in object space may result in you actually travelling a different direction depending on the compass. Also, you may be travelling a further distance than you really think you are if the measuring stick is larger than one unit in world space.

### Combining Direction and Length

So far, we've treated direction and length as two separate things. That is, in the previous example, you are holding both a compass and a measuring stick. In this section, I will discuss how these two can be combined and represented mathematically.

Rather than using north, south, east, and west, I will use X and Y. Moving in the positive X direction is to the right, and positive Y direction is up.

You may recall first learning about the Cartesian plane in school. One of the first exercises students are given is to graph a series of points. When presented with a point such as (3,2), the students are told to move to the "right" 3 times, and "up" 2 times.

Another way to think about how to graph (3,2) is to use two "lines". That is, consider having one horizontal line of one unit in length and one vertical line also of one unit in length. To move to (3,2), you could use the horizontal line and place it end to end 3 times, then use the vertical line, start at the end of the 3rd horizontal line and move in the vertical line's direction the length of two lines.

![EndToEnd.png](/media/migrated_media-EndToEnd.png)

The idea is similar to the example from before. To find the point at (3,2), simply place 3 horizontal lines end to end, then 2 vertical lines. Notice that (3,2) no longer means "Move 3 units to the right and 2 units up", but rather "Move 3 units along the blue line and 2 units along the red line". The lines are now our compass and measuring stick and (3,2) are the instructions.

Just as before, we can rotate the lines so that they point to any direction. Also, the lines can be made longer or shorter to stretch or shrink how far away from the origin points appear. Using two lines rather than a compass and measuring stick gives us a few extra "abilities". One is that the lines can rotate independently. They don't have to form 90 degree angles, but can point in similar or even opposite directions. Another ability is that we can stretch or shrink the lines independently.

### Lines as Points (Vectors)

The next thing that we need to understand is how to define these "lines". So far I've used the word lines to describe the way to move when receiving an "instruction" such as (3,2). A more proper term is vector. Consider that any of the previous vectors that we used to define which way to move when receiving instructions can actually be represented by a coordinate system as well. That is, the horizontal blue line pointed to the right 1 unit and the vertical red line pointed up 1 unit. In terms of vectors, we can say that the horizontal line is a vector represented by (1,0) in world space. That is, in an "unmodified" coordinate system, moving along the blue line from the origin will take you to (1,0). Similarly, the horizontal red line can be represented as the vector (0,1).

This can bring us to the first understanding of what a matrix represents. In terms of how it affects coordinate systems, a matrix is nothing more than a collection of these vectors to define which way is "up" and which way is "right". Therefore, a matrix that represents the red and blue lines may be written as:

    1 0
    0 1

Where the first row ( 1 0 ) is the horizontal line and the second row ( 0 1 ) is the vertical line. Therefore when we are told to move 3 untis along the horizontal line and 2 units along the vertical, we could represent this movement as:

    3 * (1,0) + 2 * (0,1)

which becomes:

    (3,0) + (0,2)

which of course becomes:

    (3,2)

This matrix happens to "align" with the unmodified world coordinate system. That is, if we follow this matrix to find a point such as (3,2), the point will be in the same position as if we just moved along the x and y axis, as we learned in elementary. In fact, this will be the case for any point we can think of. Whenever a matrix is aligned with the world coordinate system, it is called the "identity matrix". Another way to quickly determine if a matrix is an identity matrix is to note that it has 1's diagonally starting at the top right, and 0's everywhere else. Here is a 4X4 identity matrix:

    1 0 0 0
    0 1 0 0
    0 0 1 0
    0 0 0 1

Although I haven't covered how to actually use matrices to change how things appear on the screen, you can probably imagine that switching the ( 1 0 ) and ( 0 1 ) will result in the Y and X coordinates of an object being switched.

### Matrices in Computer Graphics

Usually matrices are not as simple as:

    1 0
    0 1

That is, in 3D graphics, we are usually concerned with a 3rd axis: the Z axis. This is the direction that gives a scene depth. Therefore, a matrix that represents 3 axes will be 3X3. Here is an example of a 3X3 identity matrix:

    1 0 0
    0 1 0
    0 0 1

If the row ( 1 0 0 ) is the X axis, then you can see that moving along the X axis as defined by the matrix means to stay on the real world axis. Since the Y and Z components of ( 1 0 0 ) are both 0, regardless of what the X value is, it will always move you along the X axis. To return to the previous example, the row ( 1 0 0 ) is just a horizontal line of one unit in length. The extra 0's have no affect on it.

Usually in 3D graphics, we use 4 matrices. The 4th "dimension" also known as W is used to reposition the object so that it is not centered at the origin. This is not critical to understand, so I'm not going to get into it. Just remember that most - if not all - matrices you will deal with in FRB will be 4X4 matrices.

## When to use matrices in FRB

The most common usage of a Matrix in FRB is the Sprite's (or other PositionObject's) RotationMatrix property. This property is the matrix of the Sprite which defines the "compass" for the Sprite when drawing its 4 corners. Any time any of the rotation values are changed, this matrix is modified to reflect the changed rotation. An unrotated Sprite will have a 4X4 identity matrix as its RotationMatrix property.

### Position

The RotationMatrix can help you convert object coordinates to world coordinates. For example, consider making an asteroids game. When unrotated, your ship faces up. You decide that you'd like to have a Sprite which represents the booster of the ship appear at the back of the ship. Of course, you could use attachments, but I need an example, and this one works well.

As I mentioned, when unrotated, the ship faces up, so the flame Sprite should be positioned below the ship. Let's say the flame should appear 1 unit below the ship. In object space, the flame's coordinates should be (0, -1). However, that doesn't mean that the flame should always appear one unit below the ship since the ship may rotate. So, how do we set the position of the flame? The first step is to find the actual position of the flame relative to the ship by using the ship's RotationMatrix.

In mathematical terms, we are going to create a vector which represents the position of the flame relative to the ship in object space. Then we will translate the vector using the ship's rotation matrix.

    // assume ship and flame are defined

    // uses Microsoft.DirectX for Vector3

    // fist create the vector in relative object-space coordinates
    Vector3 relativePosition = new Vector3(0, -1, 0);

    // now convert it to relative world-space cordinates
    relativePosition.Vector3.Transform(ref relativePosition
                   ship.RotationMatrix, out relativePosition);

    // the relative position is, well, relative.  Make it absolute:
    flame.Position = relativePosition + ship.Position;

As the ship rotates, the ship.RotationMatrix chagnes, which results in a different relativePosition after the Transform call.

### Velocity

Vectors can also be used to represent velocity. Continuing the example from before, consider adding the ability to fire bullets from the ship. The bullets should fire the way that the ship is facing. In object space, this is along the positive Y axis. This could be represented by a vector (0, 10, 0), or rather, 10 units/second along the Y axis.

The following code will create a bullet which fires in the direction that the ship is facing.

    if(InputManager.Keyboard.KeyPushed(Keys.Space))
    {
       // again, assume ship is a valid reference
       Vector3 bulletVelocity = new Vector3(0, 10, 0); // change Y value to change speed
       Vector3.TransformCoordinate(
          ref bulletVelocity,
          ship.rotationMatrix,
          out bulletVelocity );

       Sprite bullet = SpriteManager.AddParticle("bulletTexture.png");
       bullet.Position = ship.Position; // may need to change
       bullet.Velocity = bulletVelocity;
    }

Note that unlike the bullet position example, the velocity doesn't need to be modified. However, you may want to add the ship's velocity if you want the bullet physics to be accurate.

Interestingly enough, if the ship was rotated on its x or y axis, the bullet velocity would take that into consideration and fire towards the camera or away into the distance.

### Acceleration

I'm not going to write an example as it would be very similar to the bullet velocity, but acceleration can also be calculated similarly. Simply take an acceleration vector, call Transform to rotate it by the RotationMatrix, then assign it. This could be used to actually implement the force that would be created by the ship's thruster in an asteroids-like game.
