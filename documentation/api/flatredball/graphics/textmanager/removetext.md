# removetext

### Introduction

The RemoveText method will remove the argument Text instance from the engine so it will no longer be drawn or have every-frame management applied. RemoveText also removes the Text from any [PositionedObjectList](../../../../../frb/docs/index.php) that it is a part of (assuming a two-way relationship).

### Code Example

```
// Assuming text is a valid Text which has been added to the TextManager
TextManager.RemoveText(text);
```

RemoveText can also remove entire lists:

```
PositionedObjectList<Text> textList = new PositionedObjectList<Text>();
// populate textList by adding Text objects to it.

// This will remove all Text objects contained in textList and also
// clear textList if it is a two-way list.
TextManager.RemoveText(textList);
```

For more information see [AttachableLists](../../../../../frb/docs/index.php).
