# Left

### Introduction

The Left, Right, Top, and Bottom properties on AxisAlignedRectangle return the absolute position of the respective side.

### Code Example

The following code shows how to get the four values (Left, Right, Top, and Bottom):

```csharp
// This assumes your rectangle is called RectangleInstance
float left = RectangleInstance.Left;
float right = RectangleInstance.Right;
float top = RectangleInstance.Top;
float bottom = RectangleInstance.Bottom;

// Now you can use these four values for whatever you need in your code
```

### Setting values

Setting Left, Right, Top, and Bottom results in the X or Y values of the AxisAlignedRectangle changing. These values will not change the Width or Height of the AxisAlignedRectangle. To change dimensions use the Width and Height.

### Code Example - Setting Left

The following code makes an AxisAlignedRectangle named RectangleInstance position its bottom-left corner at the origin (0,0):

```csharp
RectangleInstance.Left = 0;
RectangleInstance.Bottom = 0;
```
