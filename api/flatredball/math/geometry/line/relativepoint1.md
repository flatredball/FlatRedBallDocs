## Introduction

The RelativePoint1 and RelativePoint2 values define the shape of a line relative to its absolute position. These values can be set to modify how a line will draw - specifically its angle and length. For simplicity the RelativePoint1 can be set to (0,0), so simply modifying the second point will adjust the line.

## Relative Point Positions vs Position

RelativePoint1 and RelativePoint2 are used to define the line in combination with the absolute point. The most common, and recommended, approach to create a line is to have RelativePoint1 be (0,0) and have RelativePoint2 define the direction of the line relative to its position. For example, consider the following code and image:

    Line line = new Line();
    line.RelativePoint1 = new Point3D(0,0);
    line.RelativePoint2 = new Point3D(300,300);

![](/media/2023-05-img_6470aee1f1135.png)

Although not recommended, RelativePoint1 and RelativePoint2 can be set such that the Line's position is not the Line.

    Line line = new Line();
    line.RelativePoint1 = new Point3D(0,100);
    line.RelativePoint2 = new Point3D(300,300);

![](/media/2023-05-img_6470b01c0e734.png)

Although FlatRedBall allows this kind of Line, and in some cases it may be beneficial for custom logic, it is not recommended for standard collision, and some methods (such as CollideAgainstClosest) will throw exceptions if the Position does not coincide with RelativePoint1. Therefore, unless your game has special requirements, RelativePoint1 should always have a Value of (0,0).

## Examples

The following code creates a vertical line. The bottom-end of the line will be located at the line's absolute Position. The top-end of the line will be located 100 units up.

    Line line = ShapeManager.AddLine();
    line.RelativePoint1.X = 0;
    line.RelativePoint2.X = 0;

    float verticalLineLength = 100;
    line.RelativePoint1.X = 0;
    line.RelativePoint2.X = 100;

The following code creates a horizontal line. The left-end of the line will be located at the line's absolute Position. The right-end of the line will be located 100 units up.

``` lang:c#
Line line = ShapeManager.AddLine();
line.RelativePoint1.X = 0; 
line.RelativePoint2.X = 0; 
float verticalLineLength = 100; 
line.RelativePoint1.X = 100; 
line.RelativePoint2.X = 0;
```

## 3D Lines

The Line class supports 3D lines (lines with non-zero relative points or absolute positions). The following shows how to create a grid of 3D lines. Note that it requires a 3D camera:

``` lang:c#
for(int x = 0; x < 10; x++)
{
    for(int y = 0; y < 10; y++)
    {
        var line = ShapeManager.AddLine();

        line.RelativePoint1 = new Point3D(0, 0, 0);

        line.RelativePoint2 = new Point3D(0, 0, -10);
        line.X = -20 + x*4;
        line.Y = -20 + y*4;
    }

}
```

![](/media/2016-04-img_571e4d873c8c5.png)
