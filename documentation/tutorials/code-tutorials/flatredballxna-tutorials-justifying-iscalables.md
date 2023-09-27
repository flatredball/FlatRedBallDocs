## Introduction

IScalable objects are objects which can be sized using ScaleX and ScaleY values. However, most IScalables are also positioned according to their center. This means that changing the ScaleX and ScaleY values results in the edges of a IScalable moving. This article discusses how to justify IScalables. Note that the Text object has its own properties for alignment, so you do not need to implement a custom solution for the Texts.

## Using Scale values to identify edges

The ScaleX and ScaleY values measure the distance from the center to the edge of an object. This means:

    float leftEdge = scalable.X - scalable.ScaleX:
    float rightEdge = scalable.X + scalable.ScaleX;
    float topEdge = scalable.Y + scalable.ScaleY;
    float bottomEdge = scalable.Y - scalable.ScaleY;

If we want to justify a scalable, that means we can use the formulas above to identify what the values should be. For example, if we wanted to left justify according to a value called leftPosition, we could do:

    scalable.X = leftPosition + scalable.ScaleX;

Of course, this value would need to be set whenever the Scalable's scale value has been changed.
