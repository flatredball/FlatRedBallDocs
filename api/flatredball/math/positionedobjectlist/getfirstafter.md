# GetFirstAfter

### Introduction

The GetFirstAfter value can be used to get the index of the next object after a given position value. For example, if you are working with a group of Entities (such as Enemy) and are implementing some partitioning logic, you can use GetFirstAfter to find the index of the first instance in a list to begin your loop for partitioning.

Note that if you are using CollisionRelationships and you have set up partitioning on your list, this method is automatically used internally to improve collision performance.

### Code Example

Assuming you have an already-sorted list of PositionedObjects, the following code can be used to get the first index after X = 0.

```csharp
float xToLookAfter = 0;
Axis axis = Axis.X;
int lowBound = 0;
int highBound = EnemyList.Count;
int indexOfObject = EnemyList.GetFirstAfter(xToLookAfter, axis, lowBound, highBound);
```

Typically GetFirstAfter is used to determine the starting index in a loop, such as in a collision loop. In this case you may want to adjust the lowBound value by half of the width of the type of object in the list. If your list has objects of varying size, you will want to use half of the width of the largest item.

### Inserting in sorted lists

GetFirstAfter is used in already-sorted lists, and it is usually used to insert new items in a PositionedObjectList such that the PositionedObjectList remains sorted after the insertion. The following code can be used to create 15 Sprites which will be inserted in order of their X value:

Add the following using statements:

```csharp
using FlatRedBall.Math;
```

Add the following to Initialize after initializing FlatRedBall:

```csharp
string valueRecord = "";
PositionedObjectList<Sprite> sortedList = new PositionedObjectList<Sprite>();

for (int i = 0; i < 15; i++)
{
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    SpriteManager.Camera.PositionRandomlyInView(sprite, 40, 40);

    int indexToInsertAt = sortedList.GetFirstAfter(sprite.X, Axis.X, 0, sortedList.Count);
    sortedList.Insert(indexToInsertAt, sprite);
}

for (int i = 0; i < sortedList.Count; i++)
{
    if (i != 0)
    {
        valueRecord += ",\n";
    }
    valueRecord += sortedList[i].X;
}

FlatRedBall.Debugging.Debugger.CommandLineWrite(valueRecord);
```

![SortedInsertion.PNG](../../../../media/migrated\_media-SortedInsertion.PNG)
