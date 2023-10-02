# glue-reference-isscrollableentitylist

### Important

This property is no longer supported in newer versions of FlatRedBall as of version 16. Information about file versions can be found in the [GLUJ version page](../glujglux.md). Newer projects should use FlatRedball.Forms for scrolling lists and UI.

### Introduction

The IsScrollableEntityList option on Entities allows for the quick creation of Entities which represent a scrollable list of other Entities. For example, this property could be used to create a list of high scores or a list of levels which the user can click on to select.

### Benefits of IsScrollableEntityList

When using the IsScrollableEntityList you automatically have the following functionality:

* Automatic positioning of Entities in a vertical list
* Event raising whenever a new Entity is created due to scrolling
* Min and max scrolling values
* Automatic updates according to an assigned IList

The IsScrollableEntityList property takes care of a lot of the hard work when creating a scrollable Entity list.

### Importing a Button Entity

The first step in creating a scrollable Entity list is to create an Entity that will be used in the List. In this case we'll use the low-resolution brown button available [here on GlueVault.com](http://www.gluevault.com/entity/24-2d-low-resolution-brown-button). To use this button:

1. Download the .entz file
2. Open Glue and create a new project or use an existing project
3. Right-click on the Entities tree item
4. Select "Import Entity"
5. Select the .entz file and select OK. For more information on importing, see [the Importing Entities tutorial here](../../../../frb/docs/index.php).

![ImportedButtonEntity.png](../../../../media/migrated\_media-ImportedButtonEntity.png)

### Creating a ButtonList Entity

To create a ButtonList Entity:

1. Right-click on the Entities tree item
2. Select "Add Entity"
3. Enter the name "ButtonList" and press OK
4. Select the newly-created ButtonList entity
5. Set the "IsScrollableEntityList" to "True"

![IsScrollableEntityList.png](../../../../media/migrated\_media-IsScrollableEntityList.png)

### Setting the scrollable Entity list variables

Next we'll need to tell the ButtonList that it should create instances of a Button class:

1. Select the Button Entity
2. Set its "CreatedByOtherEntities" to "True"
3. Set its "PooledByFactory" to "False"![ButtonCreatedByOtherEntities.png](../../../../media/migrated\_media-ButtonCreatedByOtherEntities.png)
4. Select the "ButtonList" Entity
5. Change its ItemType to "Entities\Button"
6. Set the "ListTopBound" to 256
7. Set the "ListBottomBound" to -256
8. Set the "SpacingBetweenItems to 64![ScrollableListVariables.png](../../../../media/migrated\_media-ScrollableListVariables.png)

### Creating ButtonScreen and Layer

Now we'll create a Screen that will store an instance of our ButtonList. We'll also create a 2D Layer since the Button Entity and the ButtonList Entity have been designed to be used in a 2D coordinate system. To do this:

1. Right-click on Screens
2. Select "Add Screen"
3. Enter "ButtonScreen" and click OK
4. Expand ButtonScreen
5. Right-click on the Objects tree item
6. Select "Add Item"
7. Enter "Layer2D" and click OK
8. Select the Layer2D Object
9. Set its "SourceType" to "FlatRedBallType"
10. Set its "SourceClass" to "Layer"
11. Set its "Is2D" to "True"![2DLayerSettings.png](../../../../media/migrated\_media-2DLayerSettings.png)

### Adding a ButtonList Instance to the ButtonScreen

Next we'll create an instance of ButtonList in ButtonScreen. To do this:

1. Select the ButtonList Entity
2. Push and drag the ButtonList Entity onto the ButtonScreen
3. Glue will ask if you'd like to create a ButtonList instance. Click Yes.
4. Push and drag the newly-created ButtonListInstance onto the Layer2D Object to add it to that Layer. The "LayerOn" property should automatically update![ButtonListOn2DLayer.png](../../../../media/migrated\_media-ButtonListOn2DLayer.png)

### Populating the ButtonList

At this point our ButtonList is fully set up in Glue. We now need to set up the code to tell the ButtonList what it should display. To do this:

1. Open your project in Visual Studio
2. Navigate to ButtonScreen.cs
3. Add the following code to ButtonScreen.cs's CustomInitialize method:

&#x20;

```
List<int> intList = new List<int>();
for (int i = 0; i < 100; i++)
{
    intList.Add(i);
}
ButtonListInstance.ListShowing = intList;
```

In this case we're creating a simple List of integers to help keep the tutorial shorter. In an actual game you may use a list of scores, level information from a CSV, or any other list data that you'd like to display. If you run the game you should see the list of buttons. This list is scrollable by clicking+dragging with the mouse or on the touch screen. ![ButtonListInGame.png](../../../../media/migrated\_media-ButtonListInGame.png)

### Displaying information from items in the List

So far we're creating Entities based off of items in a List, but there's nothing on Screen to show that. Next, let's modify the Text on the Button to display the integer value that the Button instance represents. To do this:

1. Add the following code to ButtonScreen.cs:

&#x20;

```
// At the beginning of CustomInitialize:
ButtonListInstance.ScrollItemModified = UpdateButtonToInteger;

// At class scope add the UpdateButtonToInteger method:
void UpdateButtonToInteger(GlueTestbed.Entities.Button button)
{
    int indexInList = ButtonListInstance.GetAbsoluteIndexForItem(button);
    button.DisplayText = ButtonListInstance.ListShowing[indexInList].ToString();
}
```

![ButtonsWithNumbers.png](../../../../media/migrated\_media-ButtonsWithNumbers.png)

### Understanding the scrollable Entity list values

Scrollable Entity lists present a few properties which can control how the Entity list draws.

#### ListTopBound positions the first element

The ListTopBound value is a good place to begin understanding now scrollable Entity lists work because it controls the starting location of the first Entity in the list. In other words, if ListTopBound is 256 (as it is in our example) then the very first button created will be at Y = 256. Graphically this means: ![ListBoundsExplanation1.png](../../../../media/migrated\_media-ListBoundsExplanation1.png)

**Entity Position Matters** We mentioned above that the position of the first Entity in the list will be at ListTopBound (which is 256 in this case). However, the position is actually ListTopBound + Y. In other words, if you expose or tunnel in to the ButtonList's Y value, or if you modify the ButtonList's Y value in custom code, this will impact the position of the first Entity in the list - and as a result every Entity that follows. However, for simplicity this article assumes that the ButtonList is at Y = 0.

Try modifying the ListTopBound value. You will notice that the first item will appear lower on screen if you reduce the value.

#### SpacingBetweenItems controls the vertical distance between items

The SpacingBetweenItems controls how Entities in the list are positioned relative to each other. In this case our SpacingBetweenItems value is 64. This means that each Entity is positioned 64 units from each Entity below and above. Increasing this value will increase how far apart they are (creating a gap between the Entities). Decreasing this value decreases how far apart the Entities are (which may cause them to overlap). ![SpacingBetweenItems.png](../../../../media/migrated\_media-SpacingBetweenItems.png)

**Why did we use 64?** You may be wondering why the spacing is set to 64, or put another way - if you were to create a new scrollable Entity list, how would you know what to set the value to? In this particular case we were able to accurately set the scrollable Entity list value because the Entity we're using (Button) has a ScaleY variable:![ButtonScaleY.png](../../../../media/migrated\_media-ButtonScaleY.png) **But the ScaleY is 32. Why did we use 64?** The word "Scale" has a special meaning in FlatRedBall. Scale means "the distance from center to edge". In other words, if our ScaleY value is 32, that means the distance from the center of our Entity to the edge of our Entity is 32. Therefore, the height is 2 times the ScaleY. Since 2 \* 32 = 64, we used a value of 64 for SpacingBetweenItems. You can read more information about Scale in the [IScalable page here](../../../../frb/docs/index.php)

#### Bounds values and when Entities disappear

You may not have noticed it, but Entities will disappear when scrolling the list. To make this more obvious, you may want to change the ListTopBound and ListBottomBound values to 128 (and -128) instead of 256. This will lower the top bound and raise the bottom bound so that fewer items are visible on screen ![ReducedList.png](../../../../media/migrated\_media-ReducedList.png) If you reduce the bounds and then try scrolling the list, you will notice that as you scroll it up, new Entities are created at the bottom of the list (with increasing values) and existing Entities are removed off of the top of the List. This is desirable for a number of reasons:

1. It keeps the number of live Entities small to improve performance and keep memory usage low
2. It allows you to place Entities within a container instead of having the list always extend to the top and bottom of the Screen

The ListTopBound and ListBottomBound values control how high (or low) an Entity must be before it disappears. In strictly numerical terms, an Entity will disappear from the the top when its Y value is greater than (ListTopBound + SpacingBetweenItems). An Entity will disappear from the bottom when its Y value is less than (ListBottomBound - SpacingBetweenItems). In our specific case our values are:

* ListTopBound = 128
* ListBottomBound = -128
* SpacingBetweenItems = 64

This means that an Entity will disappear from the top when its Y is greater than 128 + 64 = 196. An Entity will disappear from the bottom when its Y is less than -128 - 64 = -196. Grapically this looks like this: ![RemovalZone.png](../../../../media/migrated\_media-RemovalZone.png)

**Why is Button "5" not removed?** You may be looking at the list and wondering why button #5 is present. The reason for this is because the scrollable Entity list has no idea how large the Button is - the logic for creating and removing Entities does not work based off of size. Instead, it works based off of position. Therefore, an Entity is removed **if its center is within the striped pink area**. Of course, you may be wondering why Button "5" isn't removed - it appears as if its position falls within the area. The reason is because its position is right on the border. Due to floating point inaccuracy, it's difficult to predict whether an Entity will be included or excluded when it falls right on the border. The important thing, however, is that you understand that once it moves into the area, it will be removed.

### Applying a Mask

Although the scrollable Entity list functionality is very useful, the removal and addition of Entities may be a little jarring. Your game may instead want to use this with a display region - in other words, to have Entities disappear pixel by pixel as they move beyond a set area. The scrollable Entity list does not have functionality for this built in; however, scrollable Entity lists can be used in combination with [Layers](../../../../frb/docs/index.php) in Glue. Furthermore, the [DestinationRectangle property on Layers](../../../../frb/docs/index.php) can be set in Glue to implement masking without any code.
