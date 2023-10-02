# children

### Introduction

The Children property contains a list of PositionedObjects which are attached to this. Initially the list is empty, but it is automatically populated when one PositionedObject is attached to another using the [AttachTo](../../../../frb/docs/index.php) method.

### Code Example

Add the following using statement:

```
using FlatRedBall.Graphics;
```

Add the following to Initialize after initializing FlatRedBall:

```
// we'll use PositionedObjects here, but could be anything - Sprite, Text, or custom Entity class
PositionedObject first = new PositionedObject();
PositionedObject second = new PositionedObject();

int countBefore = first.Children.Count;
second.AttachTo(first, false);
int countAfter = first.Children.Count;
second.Detach();
int finalCount = first.Children.Count;

string displayString = 
   string.Format("Before:{0}\nAfter:{1}\nFinal:{2}", countBefore, countAfter, finalCount);

TextManager.AddText(displayString);
```

![ChildrenTutorial.png](../../../../media/migrated\_media-ChildrenTutorial.png)
