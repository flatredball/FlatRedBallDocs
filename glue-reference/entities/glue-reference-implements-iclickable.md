# glue-reference-implements-iclickable

### Introduction

The Implements IClickable property is a property that controls whether the Entity has a HasCursorOver  method. In other words, Entities which are IClickable can be tested to see if the user has highlighed or clicked an object with the [Cursor](../../../../frb/docs/index.php)

### Setting IClickable

Entities can be created as IClickable in the add entity window.

![](../../../../media/2022-02-img\_61fb3a85b6f71.png)

Existing entities can be converted to IClickable in the Properties

1. Select the entity in Glue
2. Click the **Properties** tab
3. Set\*\* Implements IClickable\*\* to T**rue**

![](../../../../media/2019-04-img\_5caa9bbeb7bba.png)

### Code Example - Clicking UI

This method returns whether the Cursor is over any visible part of the Entity. You could use this function to detect UI activity such as Cursor clicks. The following code can be used to perform logic if the user clicks on the Button:

```
Cursor cursor = GuiManager.Cursor;

if (cursor.PrimaryClick && this.HasCursorOver(cursor))
{
    // Do something here:
}
```

### Code Example - Selecting Entities

HasCursorOver can be used to select entity instances in a RTS. The following code shows how to handle unit selection in an RTS. It assumes that UnitList is a list of entities which implement IClickable.

```lang:c#
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
