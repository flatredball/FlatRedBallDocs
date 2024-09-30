# vector

### Introduction

Vectors are commonly used for motion, collision, and other physics-related behavior. While the basic concept of a vector is easy to understand, vectors enable us to create realistic and complicated behavior.

### What is a Vector?

In mathematics, a Vector is a set of values which can simplify common physics calculations. Vectors are usually used to represent:

* Position
* Velocity
* Acceleration

FlatRedBall uses the Vector3 type for position, velocity, and acceleration. The **3** in Vector3 means that the vector has 3 components: X, Y, and Z. In some cases FlatRedBall also uses Vector2, which is a type which only has X and Y values. By default, all objects in FlatRedBall have a Position value of (0,0,0), where the three values represent the X, Y, and Z components of position. Since the Camera in FlatRedBall also has an X and Y of 0, then by default all objects will be positioned at the center of the screen. For example, a new circle (whether added through the FRB editor or code) will be positioned at the center of the screen.

![](../../.gitbook/assets/2021-02-img\_60390522c59ac.png)

We can modify the position of an object by changing its X, Y, or Z values (although Z values may not have a visual impact on the object in 2D). For example, the Circle above can be moved to the right by setting its X to 100, which will move it 100 pixels to the right of the center of the screen. CircleInstance.Position.X = 100;

![](../../.gitbook/assets/2021-02-img\_603905764868e.png)

In the image above, the (X,Y,Z) values are (100, 0, 0).

### Adding Vectors

The addition of vectors is a common operation in game development. When two vectors are added, each component of the vector is added together. For example, consider the following code:

```
var firstVector = new Vector3(100, 30, 0);
var secondVector = new Vector3(60, -10, 0);
var thirdVector = firstVector + secondVector;
```

The code above would result in thirdVector containing values (160, 20, 0). This is the result of adding the X components (100 + 60), Y components (30 - 10), and Z components (0 + 0). When a vector is added to the position of an object, the object is _moved by_ the values contained in the adding vector. For example, the following code would move the player to the right ten units:

```
PlayerInstance.Position += new Vector3(10, 0,0);
```

### Vectors as Direction

A vector can represent a direction which can be used to rotate or move an object. For example, a game which shoots bullets at the player would need to calculate the direction from the enemy shooting the bullet to the player shooting the bullet. This direction can be determined by subtracting the position from one object to another. For example, to determine the vector from the enemy to player, the following code can be used:

```
var vectorToPlayer = player.Position - enemy.Position;
```

Notice that the order of subtraction is (destination - source). If the enemy is represented by a red circle and the player by a green circle, then the subtraction would produce a vector visualized by the red arrow in the following image:

![](../../.gitbook/assets/2021-11-img\_61967362c3312.png)

### Moving Toward a Direction

To move toward a direction you'll need a few pieces of information:

* What position is your object currently at?
* What is the target position?
* What speed (in units per second) would you like to move at.

To find the proper velocity, you will first want to calculate the vector from the object's current position to the target position, normalize the vector (make it a unit vector), then finally multiply it by the desired speed (also referred to as magnitude). Here's some code to get you started:

```
Vector3 position = myObject.Position;
Vector3 target = new Vector3(10, 15, 0); // can be anything
Vector3 connectingVector = target - position;
connectingVector.Normalize();
float magnitude = 10; // in units per second
connectingVector *= magnitude;
```

### Dot Products

Dot Products are useful when performing collisions using vectors. For more information, see: [http://www.sparknotes.com/physics/vectors/vectormultiplication/section1.html](http://www.sparknotes.com/physics/vectors/vectormultiplication/section1.html) And for an interactive visualization tool: [http://www.falstad.com/dotproduct/](http://www.falstad.com/dotproduct/)

### Cross Product

The following link gives the basics about cross products: [http://www.physics.uoguelph.ca/tutorials/torque/Q.torque.cross.html](http://www.physics.uoguelph.ca/tutorials/torque/Q.torque.cross.html) Interactive visualization tool: [http://physics.syr.edu/courses/java-suite/crosspro.html](http://physics.syr.edu/courses/java-suite/crosspro.html)

### Point Relative to Line and Polygon

One use of the cross product is to determine which side of a line a point is on. This is the core math behind polygon collision. Consider the following example. ![CrossProductTutorial1.png](../../.gitbook/assets/migrated\_media-CrossProductTutorial1.png) Using the cross product we can determine which side of the line C is on. However, before we can do that, we need to identify characteristics of the line formed by the points A and B - specifically which point is "first". That is, if a person were standing at point A and looking towards B, to him C would be to the "left" of the line. However, if the person were standing at point B and looking toward point A, C would be to the "right" of the line. Selecting A or B as the first point or origin really doesn't matter as long as the effect is understood and the same ordering is used consistently. For this example, I'll consider A as the first point and use this when creating the vectors to be used in the cross product. Therefore, our two vectors when calculating the cross product will be AB and AC (this is a right handed coordinate system as is used in XNA, but not in Managed DirectX). ![CrossProductTutorial2.png](../../.gitbook/assets/migrated\_media-CrossProductTutorial2.png) If AB and AC are considered to be on the Z=0 plane, then the cross of AB and AC is a vector with a positive Z value. So long as the vector is on the "left" side of the line when viewing from A to B, the Z component of the cross of AB and AC will always be positive. If the point is on the right side of the line in the same situation, the Z component of the cross of AB and AC will always be negative. Using this information, we can find out if a point is inside a polygon. In the following image, the point F is inside a polygon formed by points A, B, C, D, E. ![CrossProductTutorial3.png](../../.gitbook/assets/migrated\_media-CrossProductTutorial3.png) Each side has a matching vector with which it would be crossed and in all cases the Z component of the cross would be positive. Keep in mind that this is only the case if the polygon is convex. Determining if a point is inside of a concave polygon requires a different method.

### Moving a Point to a Line

If we have a point and a line (which is represented by two points), the dot product enables us to move the point to the line by the shortest distance possible. This is common when writing collision and physics code. In summary, to move a point to a line the following steps need to be performed:

1. Find the unit vector parallel to the line.
2. Perform the dot product of the vector from one point on the line to the point in question and the unit vector parallel to the line.
3. Multiply the unit vector parallel to the line by the result of the previous dot product to get the projection of the vector from the first point in the line to the point in question.
4. Subtract the newly created projection vector from the vector from the first point in the line to the vector. This will result in a vector that is perpendicular to the line which is the lenth of the distance of the point from the line.
5. Subract the vector from the point and it will now be on the line.
