## Introduction

Layers provide a way to force a particular order of drawing on a single [Camera](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera"). While the concept is fairly straight-forward, things can become more complicated when objects are moved from being layered to unlayered, or when objects have presence on multiple layers. Since there are a variety of ways to layer and unlayer objects, this article will present a number of small code blocks and explain what each one does.

## The setup

First, let's start with some common code that all samples below will use. Consider the following line of code:

    Layer firstLayer = SpriteManager.AddLayer();
    Layer secondLayer = SpriteManager.AddLayer();

Okay, so far we have two layers that have been added to the SpriteManager. Keep in mind that secondLayer will actually be drawn on top of firstLayer - they are drawn in the order that they are created, so first is drawn first, then second is drawn on top of first.

## A simple unlayered Sprite

Here's a very common setup (of course, assuming the lines above are still in the code).

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

As you may have guessed, the above code creates a Sprite which is managed and drawn, but not layered. We can show the membership as follows:

|                          |             |
|--------------------------|-------------|
| Category                 | Is a member |
| Managed by SpriteManager | X           |
| Drawn unlayered          | X           |
| Drawn on firstLayer      |             |
| Drawn on secondLayer     |             |

This table is just another way of showing what we mentioned before.

## Making a layered Sprite

There are two ways to make a layered [Sprite](/frb/docs/index.php?title=Sprite "Sprite"). The first is to use the AddToLayer method:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    SpriteManager.AddToLayer(sprite, firstLayer);

The AddToLayer method in the SpriteManager as well as all other Managers does two things:

1.  Adds the Sprite (or other object) to the argument Layer
2.  Removes the Sprite (or other object) from unlayered drawing

The result:

|                          |             |
|--------------------------|-------------|
| Category                 | Is a member |
| Managed by SpriteManager | X           |
| Drawn unlayered          |             |
| Drawn on firstLayer      | X           |
| Drawn on secondLayer     |             |

The SpriteManager provides a shortcut method for adding a [Sprite](/frb/docs/index.php?title=Sprite "Sprite") directly to a Layer:

    Sprite sprite = SpriteManager.AddSprite(
        "redball.bmp", 
        FlatRedBallServices.GlobalContentManager,
        firstLayer);

This code does the exact same thing **if used instead of the two lines of code above**. That is, this method **both adds the Sprite for membership as well as adds it to the firstLayer but not to unlayered drawing**.

|                          |             |
|--------------------------|-------------|
| Category                 | Is a member |
| Managed by SpriteManager | X           |
| Drawn unlayered          |             |
| Drawn on firstLayer      | X           |
| Drawn on secondLayer     |             |

## Multiple Layer membership

The AddToLayer method does remove the argument [Sprite](/frb/docs/index.php?title=Sprite "Sprite") from unlayered drawing, but it **does not remove the argument [Sprite](/frb/docs/index.php?title=Sprite "Sprite") from any other Layers that it belongs to**. Therefore, a [Sprite](/frb/docs/index.php?title=Sprite "Sprite") can be added to two Layers simply by calling AddToLayer twice:

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    SpriteManager.AddToLayer(sprite, firstLayer);
    SpriteManager.AddToLayer(sprite, secondLayer);

The result:

|                          |             |
|--------------------------|-------------|
| Category                 | Is a member |
| Managed by SpriteManager | X           |
| Drawn unlayered          |             |
| Drawn on firstLayer      | X           |
| Drawn on secondLayer     | X           |

## Removal from Layers

To remove a [Sprite](/frb/docs/index.php?title=Sprite "Sprite") (or any other object) from a Layer, simply call the Remove method. Keep in mind that calling Remove **will not re-add the object to unlayered drawing**.

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    SpriteManager.AddToLayer(sprite, firstLayer);
    firstLayer.Remove(sprite);

As shown below, this makes the [Sprite](/frb/docs/index.php?title=Sprite "Sprite") managed, but it will not be drawn.

|                          |             |
|--------------------------|-------------|
| Category                 | Is a member |
| Managed by SpriteManager | X           |
| Drawn unlayered          |             |
| Drawn on firstLayer      |             |
| Drawn on secondLayer     |             |

## Layered and Unlayered Drawing

Having an object be drawn layered an unlayered is not something supported by the FlatRedBall Engine. One reason for this is that in most cases, this is an undesirable behavior. It can hurt performance, as well as result in unexpected graphical behavior. But we're going to cover this anyway because it may help expose bugs that you are experiencing if you've tried this (or stumbled across it unintentionally).

    // DON'T DO THIS!!!!!!!
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    SpriteManager.AddToLayer(sprite, firstLayer);
    SpriteManager.AddSprite(sprite);

This code needs some explanation. The first line makes the [Sprite](/frb/docs/index.php?title=Sprite "Sprite") managed and drawn unlayered. The second line makes the [Sprite](/frb/docs/index.php?title=Sprite "Sprite") layered, but removes it from unlayered drawing. Now, you may be thinking "Ok, the last line just re-adds the Sprite to the SpriteManager so it is drawn unlayered." Well, you're half right. The second AddSprite call does add the [Sprite](/frb/docs/index.php?title=Sprite "Sprite") to be drawn, but it also has a nasty side-effect. The [Sprite](/frb/docs/index.php?title=Sprite "Sprite") will actually be added to the [SpriteManager](/frb/docs/index.php?title=SpriteManager "SpriteManager") twice. It was added once on the first line, and once again on the third line. This means that the [Sprite](/frb/docs/index.php?title=Sprite "Sprite") will have its every-frame management performed twice. Not only does this hurt performance, but it results in properties like Velocity and Acceleration applied twice. In other words, you may get very unexpected behavior if you do this.

|                          |             |
|--------------------------|-------------|
| Category                 | Is a member |
| Managed by SpriteManager | **X X**     |
| Drawn unlayered          | X           |
| Drawn on firstLayer      | X           |
| Drawn on secondLayer     |             |

## The AddToLayer behavior

The AddToLayer method has a little bit of inconsistent behavior. Let's explore it a little bit. FlatRedBall assumes that in most cases whenever you want an object drawn, you also want it managed. So, let's look at the following code:

    // Let's make the Sprite manually instead of through the SpriteManager
    Sprite sprite = new Sprite();
    sprite.Texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");
    // Now add it to a layer
    SpriteManager.AddToLayer(sprite, firstLayer);

So it's a safe bet that the [Sprite](/frb/docs/index.php?title=Sprite "Sprite") will be drawn on the firstLayer, but what about management? Is it managed by the [SpriteManager](/frb/docs/index.php?title=SpriteManager "SpriteManager")? We never called AddSprite. Drum roll please...

|                          |             |
|--------------------------|-------------|
| Category                 | Is a member |
| Managed by SpriteManager | X           |
| Drawn unlayered          |             |
| Drawn on firstLayer      | X           |
| Drawn on secondLayer     |             |

The [SpriteManager](/frb/docs/index.php?title=SpriteManager "SpriteManager") actually added the object both to the layer as well as to itself for management. This behavior is present because it's assumed that drawn objects should be managed. There is one exception, however. The [ShapeManager](/frb/docs/index.php?title=ShapeManager "ShapeManager")'s AddToLayer method. Shapes have somewhat unique behavior in that they are most often used for collision, and many times they can exist and be used, but not be managed by the [ShapeManager](/frb/docs/index.php?title=ShapeManager "ShapeManager") for performance reasons. Therefore, the [ShapeManager](/frb/docs/index.php?title=ShapeManager "ShapeManager") does not add a shape for management unless you explicitly tell it to do so. In other words, adding a shape to a layer, but not to the [ShapeManager](/frb/docs/index.php?title=ShapeManager "ShapeManager") results in the shape being drawn, but not managed. For more information on the reasoning behind this type of behavior, see the ["Why Limit Shape Management"](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.ShapeManager#Why_Limit_Shape_Management.3F "FlatRedBall.Math.Geometry.ShapeManager") section of the [ShapeManager](/frb/docs/index.php?title=ShapeManager "ShapeManager") page.
