# Implements IClickable

### Introduction

The Implements IClickable property tells the FlatRedBall Editor whether to generate a HasCursorOver method for a particular entity. In other words, Entities which are IClickable can be tested to see if the user has highlighed or clicked an object with the [Cursor](../../api/flatredball/gui/cursor/).

### Setting IClickable

Existing entities can be converted to IClickable in the Properties tab

1. Select the Entity
2. Click the **Properties** tab
3. Set **Implements IClickable** to **True**

![Setting an Entity's ImplementsIClickable to true](<../../.gitbook/assets/04_08 24 06.png>)

### Code Example - Clicking UI

This method returns whether the Cursor is over any visible part of the Entity. You could use this function to detect UI activity such as Cursor clicks. The following code can be used to perform logic if the user clicks on the Button:

```csharp
Cursor cursor = GuiManager.Cursor;

if (cursor.PrimaryClick && this.HasCursorOver(cursor))
{
    // Do something here:
}
```

### Code Example - Selecting Entities

HasCursorOver can be used to select entity instances in a RTS. The following code shows how to handle unit selection in an RTS. It assumes that UnitList is a list of entities which implement IClickable.

```csharp
// At class scope store the selected unit
Unit selectedUnit;

// Perform selection logic every-frame, 
void CustomActivity()
{
   DoSelectionLogic();
}

void DoSelectionLogic()
{
   if(GuiManager.Cursor.PrimaryPush)
   {
      for(int i = 0; i < UnitList.Count; i++)
      {
         if(UnitList[i].HasCursorOver(GuiManager.Cursor))
         {
            selectedUnit = UnitList[i];
            break;
         }
      }
   }
}
```

### IClickable Object Tests

Entities do not have a size, so their contents are used when HasCursorOver is called. The following objects are tested in the HasCursorOver method:

* Sprites (if Visible is true and Alpha > 0)
* Text (if Visible is true and Alpha > 0)
* ShapeCollections
* AxisAlignedRectangle
* Circle
* Polygon
* CapsulePolygon
* Sphere
* Children instances of entities which implement IClickable
