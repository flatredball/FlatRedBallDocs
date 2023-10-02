## Introduction

Tiled files (.tmx) can be included in entities to create visuals which are tile-based. When used in entities, .tmx files are loaded into LayeredTileMap instances which are attached to the entity. This means that the entire tile map inherits the following from the entity that it is a part of:

-   Position
-   Rotation
-   Layer
-   Visibility

## Adding a .tmx File to An Entity

To add a .tmx file to an entity, follow these steps:

1.  Create a .tmx file using the Tiled program. Make sure this .tmx file is saved in the folder structure of your project's content folder.

    ![](/media/2017-09-img_59cae5f4e8a70.png)

2.  Create an Entity

3.  Drag+drop the .tmx file onto the entity [![](/media/2017-09-2017-09-26_17-28-57.gif)](/media/2017-09-2017-09-26_17-28-57.gif)

4.  Drag+drop the file from inside the entity's **Files** folder onto the entity's **Objects** folder

5.  Select **Entire File (Layered TileMap)** in the **Source Name** dropdown

6.  Click OK [![](/media/2017-09-2017-09-26_17-33-51.gif)](/media/2017-09-2017-09-26_17-33-51.gif)

The entity will now display the contents of the .tmx file when included in a screen. ![](/media/2017-09-img_59cae57528f71.png)

![](/media/2017-09-img_59cae5a9912b2.png)

## Entity and LayeredTileMap Origin

LayeredTileMap objects use their top-left corner as their origin. This means that the center of the entity will align with the top-left corner of the map. We can observe this by adding a Circle object to an entity which also has a Tiled object.

![](/media/2017-09-img_59cae6bc94570.png)

CircleInstance is centered on the entity, so we can see that the tiled object's top-left corner aligns with the center of the entity. ![](/media/2017-09-img_59cae6fe1d451.png) We can further observe the impact of the origin by rotating the entity. We'll do this by adding the following code to the entity's CustomActivity  method:

``` lang:c#
private void CustomActivity()
{
    // This will rotate at 1 radian/second
    this.RotationZ += 1 * TimeManager.SecondDifference;
}
```

[![](/media/2017-09-2017-09-26_17-49-07.gif)](/media/2017-09-2017-09-26_17-49-07.gif) We can center the tiles on the center of the entity by following these steps:

1.  Open the .tmx file in Tiled

2.  Resize the map so that it there is no empty space around the object

    ![](/media/2017-09-img_59caea24d5420.png)

3.  Save the file

4.  Add the following code to the entity's CustomInitialize :

    ``` lang:c#
    private void CustomInitialize()
    {
        this.EntireFile.RelativeX = -this.EntireFile.Width / 2;
        this.EntireFile.RelativeY = this.EntireFile.Height / 2;

    }
    ```

Now the center of the tilemap will align with the center of the entity. [![](/media/2017-09-2017-09-26_18-04-51.gif)](/media/2017-09-2017-09-26_18-04-51.gif)

## Optionally Loading .tmx Files

Tiled files added to entities can also be optionally loaded. Games may need to optionally load .tmx files if a single entity can have different visuals, such as a Boss entity which may be drawn by one of many .tmx files. To add an optionally .tmx file to an entity, follow these steps:

1.  Drag+drop the .tmx file into the entity

2.  Select the .tmx file in the **Files** folder

3.  Change its **LoadedOnlyWhenReferenced** to ****True****

    ![](/media/2017-09-img_59caeeb437173.png)

4.  If your entity has a LayeredTileMap object (which we called **EntireFile** earlier) remove it - it needs to be created in code instead.

5.  Modify your entity so that its custom code creates and destroys the entity in CustomInitialize  and CustomDestroy  as shown in the following code:

    ``` lang:c#
    public partial class TiledEntity
    {
        FlatRedBall.TileGraphics.LayeredTileMap EntireFile;

        private void CustomInitialize()
        {
            // We could directly access TiledFile.Clone as follows:
            //EntireFile = TiledFile.Clone();
            // Or we can use a string. We'll use a string to show how
            // to load a file based on some data (like CSV)
            // We also call Clone() in case we want to have multiple entities
            // using this file. If we're absolutely certain that only one of
            // these will exist at any time, then we don't need to call Clone().
            EntireFile = (GetFile("TiledFile") as FlatRedBall.TileGraphics.LayeredTileMap).Clone();
            EntireFile.AddToManagers(this.LayerProvidedByContainer);

            EntireFile.AttachTo(this, false);
            this.EntireFile.RelativeX = -this.EntireFile.Width / 2;
            this.EntireFile.RelativeY = this.EntireFile.Height / 2;

        }

        private void CustomActivity()
        {
            // This will rotate at 1 radian/second
            this.RotationZ += 1 * TimeManager.SecondDifference;
        }

        private void CustomDestroy()
        {
            // Don't forget to destroy the LayeredTileMap when destorying the entity
            EntireFile.Destroy();
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
    ```

## LayeredTileMap and Render Breaks

The LayeredTileMap implements the IDrawableBatch interface, which means it is rendered outside of the FlatRedBall engine. This means that adding an instance of a LayeredTileMap to your game will add at least one render break, and possibly two if it is drawn inbetween standard FlatRedBall objects. Furthermore, each instance of an entity using a LayeredTileMap will introduce additional render breaks. Therefore, you may consider other ways to render your entity visuals if you plan on having a large number of entity instances in your game at the same time - especially for mobile platforms.
