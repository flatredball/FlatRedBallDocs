## Introduction

Layers can be used to control the order of visual objects on screen. Typically objects with a larger Z value will appear behind objects with smaller Z values, but this relationship is only true if the objects are on the same layer. Layers take priority over the Z value of objects when performing rendering. Typically Layers are used to force groups of visual objects to draw on top of other objects. For example, a HUD layer can be used to force HUD UI such as score and health bars to appear on top of everything else in a game regardless of Z value. Layers can be added in the FlatRedBall Editor or in code through the SpriteManager. For information on how to use Layers in Glue, see [this article](/frb/docs/index.php?title=Glue:Tutorials:Using_Layers "Glue:Tutorials:Using Layers")

## Example - Creating a Layer in FlatRedBall Editor

To create a new Layer:

1.  Expand the Screen which should contain a layer. Note that layers are usually added to GameScreen and not Level screens unless you need to have a layer specific to a level.
2.  Right-click on the **Objects** folder and select **Add Object**
3.  Find the **Layer** type
4.  Enter a name for the Layer
5.  Click **OK**

[![](/wp-content/uploads/2016/01/01_12-19-51.gif)](/wp-content/uploads/2016/01/01_12-19-51.gif)

## Layer-able Types

The following types can be added to Layers:

-   [FlatRedBall.Graphics.IDrawableBatch](/frb/docs/index.php?title=FlatRedBall.Graphics.IDrawableBatch "FlatRedBall.Graphics.IDrawableBatch")
-   [FlatRedBall.Graphics.Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text")
-   [FlatRedBall.Math.Geometry.AxisAlignedCube](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedCube "FlatRedBall.Math.Geometry.AxisAlignedCube")
-   [FlatRedBall.Math.Geometry.AxisAlignedRectangle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.AxisAlignedRectangle "FlatRedBall.Math.Geometry.AxisAlignedRectangle")
-   [FlatRedBall.Math.Geometry.Capsule2D](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Capsule2D "FlatRedBall.Math.Geometry.Capsule2D")
-   [FlatRedBall.Math.Geometry.Circle](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Circle "FlatRedBall.Math.Geometry.Circle")
-   [FlatRedBall.Math.Geometry.Line](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Line "FlatRedBall.Math.Geometry.Line")
-   [FlatRedBall.Math.Geometry.Polygon](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Polygon "FlatRedBall.Math.Geometry.Polygon")
-   [FlatRedBall.Math.Geometry.Sphere](/frb/docs/index.php?title=FlatRedBall.Math.Geometry.Sphere&action=edit&redlink=1 "FlatRedBall.Math.Geometry.Sphere (page does not exist)")
-   [FlatRedBall.Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite")

## Ordering with Layers as opposed to Z values

Although ordering does normally obey objects' Z value, changing Z also changes an object's size (if not in orthogonal mode) and can place an object outside of the [Camera's](/frb/docs/index.php?title=FlatRedBall.Camera "FlatRedBall.Camera") NearClipPlane and FarClipPlane. Furthermore, some objects such as HUDs and in-game UI should not be overlapped by any other objects.

## Understanding the purpose of Layers

Layers are used **only** to control the drawing order of objects. This means that layers have nothing to do with the position of the objects that they contain. For example, consider the [Entity pattern](/frb/docs/index.php?title=Category:FlatRedBall_XNA_Tutorials#Entity_Tutorials "Category:FlatRedBall XNA Tutorials"). Entities usually are composed of 3 [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject"):

-   The Entity itself
-   The visible representation which is attached to the Entity
-   The collision object which is also attached to the Entity

Of these three, the **only** [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject "FlatRedBall.PositionedObject") which will get added to a Layer (if you want your Entity to be layered) is the visible representation. You **can** add the collision to a Layer, but this **does not have any impact on the behavior of your collision**. The only reason you might want to add the collision object to a layer is so it will be drawn if on the same layer as the visible representation if you desire to have it drawn for debugging reasons. To clarify, adding the collision to a Layer will **not** provide some form of categorization. Two entities on different Layers will still be able to have their collision objects collide. The collision objects do not consider Layers when performing collision.

## Using Layers

Layers are created through the [SpriteManager](/frb/docs/index.php?title=FlatRedBall.SpriteManager "FlatRedBall.SpriteManager"). The following code creates a layer and two [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite"). Although the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") named nearSprite is closer than the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") named farSprite, farSprite is not hidden by nearSprite.

     Layer layer = SpriteManager.AddLayer();

     Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp");

     Sprite nearSprite = SpriteManager.AddSprite(texture);
     nearSprite.Z = 20; // Brings it closer to the camera.

     Sprite farSprite = SpriteManager.AddSprite(texture);
     SpriteManager.AddToLayer(farSprite, layer); 

     // This puts the farSprite behind the nearSprite.
     farSprite.Z = -5;

![LayeredSpriteBehindUnlayered.png](/media/migrated_media-LayeredSpriteBehindUnlayered.png)

## AddToLayer Method

-   [SpriteManager.AddToLayer](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddToLayer "FlatRedBall.SpriteManager.AddToLayer") - Responsible for adding SpriteFrames, Sprites, and IDrawableBatches to Layers.
-   [TextManager.AddToLayer](/frb/docs/index.php?title=FlatRedBall.Graphics.TextManager.AddToLayer "FlatRedBall.Graphics.TextManager.AddToLayer") - Responsible for adding Texts to Layers.

### Adding PositionedModels to Layers

Similar to [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and [Texts](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text"), [PositionedModels](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel "FlatRedBall.Graphics.Model.PositionedModel") can also be layered. The following code creates a [PositionedModel](/frb/docs/index.php?title=FlatRedBall.Graphics.Model.PositionedModel "FlatRedBall.Graphics.Model.PositionedModel") and adds it to a layer.

     Layer layer = SpriteManager.AddLayer();

     PositionedModel model = ModelManager.AddModel(ModelShape.Sphere);
     ModelManager.AddToLayer(model, layer);

## Removing Objects from Layers

There are two ways to remove objects from Layers:

1.  Completely remove the object from the engine and its Layer(s)
2.  Remove the object **just from the Layer but keep it in the engine**

For reference, let's use the following setup to discuss this point:

    Texture2D texture = FlatRedBallServices.Load<Texture2D>("redball.bmp", "Global");
    Layer layer = SpriteManager.AddLayer();

    Sprite sprite = SpriteManager.AddSprite(texture, layer);
    Text text = TextManager.AddText("I'm on a layer", layer);

### 1. Completely remove the object

This is the most common method of removing an object. It's usually what you'll do if you're manually handling the removal of your objects (as opposed to letting Glue do it for you). To do this, simply use the manager removal methods:

    // Here's how to remove the Sprite
    SpriteManager.RemoveSprite(sprite);

    // Here's how to remove the Text object
    TextManager.RemoveText(text);
    // Everything is now gone from the engine and Layer

In other words, remove your objects just like normal - they'll automatically get removed from their Layers too.

### 2. Remove the object just from the Layer

Objects can be removed from Layers through the Remove method.

    layer.Remove(sprite);
    layer.Remove(text);

Now the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") and [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text "FlatRedBall.Graphics.Text") object are no longer on the layer, so they will not be drawn. However, the two objects have not been removed from their respective managers so they are still in memory and still managed every frame!

## Using Multiple Layers

Multiple layers can exist at a given time. Calling AddLayer multiple times creates multiple layers. The newest layer is always on top while the oldest is on bottom.

## Sorting objects within Layers

This section discusses sorting objects (such as [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite "FlatRedBall.Sprite") within a Layer. For information on how to control the order that Layers are drawn, see [the SpriteManager MoveToBack and MoveToFront page](/frb/docs/index.php?title=SpriteManager.MoveToBack&action=edit&redlink=1 "SpriteManager.MoveToBack (page does not exist)"). While Layers represent Lists in some ways, they cannot sort objects that they hold (like [SpriteLists](/frb/docs/index.php?title=FlatRedBall.SpriteList "FlatRedBall.SpriteList") or [PositionedObjectLists](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObjectList "FlatRedBall.Math.PositionedObjectList")). The reason for this is because the internal [SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList "FlatRedBall.SpriteList") that a Layer references is used directly by the engine to draw the Layer. The engine may perform sorting on this list to ensure proper overlapping and to improve runtime performance so user-controlled sorting of the SpriteList may disrupt this behavior. If objects in a Layer need to be sorted they should be added to a separate [SpriteList](/frb/docs/index.php?title=FlatRedBall.SpriteList "FlatRedBall.SpriteList") and sorted there.

## Camera Layers

See [FlatRedBall.Camera.Layer](/frb/docs/index.php?title=FlatRedBall.Camera.Layer "FlatRedBall.Camera.Layer").

## Adding an Entity to a Layer

If you are using [Glue](/frb/docs/index.php?title=Glue "Glue") then you can add an Entity to a Layer. See [this article](/frb/docs/index.php?title=Glue:Tutorials:Basic_coding_in_Glue#Adding_an_Entity_to_a_Layer "Glue:Tutorials:Basic coding in Glue") for information on this.

## Controlling Destination Rectangle

Layers will render to the full screen by default. Layers can be adjusted to only render to part of the Screen. For more information see [the LayerCameraSettings destination coordinate page](/frb/docs/index.php?title=FlatRedBall.Graphics.LayerCameraSettings.TopDestination "FlatRedBall.Graphics.LayerCameraSettings.TopDestination").

## Adding Gum Screens to Layers

For more information, see the [Adding Gum Components to Layers](/documentation/tools/gum/gum-how-to-add-gum-components-to-layers.md) page.

## 
