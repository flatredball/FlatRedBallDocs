## Introduction

The **Implements IDrawableBatch** tells the FlatRedBall Editor to generate code for custom rendering including:

-   All necessary properties for the IDrawableBatch interface
-   Empty implementation for IDrawableBatch.Update and IDrawableBatch.Destroy. These are are empty since entities already have update and destroy methods.
-   Addition of the entity to the SpriteManager as an IDrawableBatch
-   Removal of the entity to the SpriteManager as an IDrawableBatch

Setting ImplementsIDrawableBatch to true does not result in code generation writing a Draw method implementation, so this must be implemented in custom code.

## Implementation Example

The following instructions show how to use the ImplementsIDrawableBatch property to create an entity which is drawn using the SpriteBatch class. Before writing code, the following steps are needed to create an IDrawableBatch entity:

1.  Create an Entity, or select an existing entity which should have is own Draw method

2.  Set the Entity's **ImplementsIDrawableBatch** property to T**rue**

    ![](/media/2016-06-img_576b65577329a.png)

3.  Add a .png file to the entity. This will be used in the Draw call

Once the entity has been created, we must define a Draw  call in the entity's code file. Notice that the Draw  method has a Camera  parameter. This allows entities to perform rendering relative to the current Camera. In this example the entity ignores the Camera for simplicity.

``` lang:c#
public partial class PostProcessingEntity
{
    SpriteBatch spriteBatch;

    private void CustomInitialize()
    {
        spriteBatch = new SpriteBatch(FlatRedBallServices.GraphicsDevice);
    }

    private void CustomActivity()
    {
    }

    private void CustomDestroy()
    {
        spriteBatch.Dispose();
    }

    private static void CustomLoadStaticContent(string contentManagerName)
    {
    }

    public void Draw(Camera camera)
    {
        spriteBatch.Begin();

        spriteBatch.Draw(
            TilesImage, 
            new Rectangle(50, 50, TilesImage.Width, TilesImage.Height), 
            Color.White);

        spriteBatch.End();
    }
}
```

## Additional Information

For more information and code samples related to IDrawableBatch, see the [IDrawableBatch](/documentation/api/flatredball/flatredball-graphics/flatredball-graphics-drawablebatch/.md) page.
