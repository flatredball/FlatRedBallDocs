# glue-reference-files-csv-orderedlist

### Introduction

The OrderedList property is a List of values which correspond to the order of values in a dictionary CSV. A given CSV must have its [CreatesDictionary](../../../frb/docs/index.php) property set to true for OrderedList to be generated.

**OrderedList is not dynamic**The OrderedList is a hardcoded list. It is not dynamic, meaning if you make any modifications to a CSV at runtime, the OrderedList property will not update according to these changes.

### Code Example

The OrderedList property can provide access to entries in a dictionary CSV when order is important. The reason this is necessary is because values in a Dictionary at runtime are not guaranteed to be in the same order as the values in a CSV. For more information, [see this page](http://stackoverflow.com/questions/4007782/the-order-of-elements-in-dictionary).

```
// The following code moves the calling object to the next level
public void SetNextLevel()
{
   // Assumes the object has a CurrentLevel type which is of type LevelInfo
   // (presumably from a CSV called LevelInfo.cs)
   // This also assumes that "Name" is the key used in the dictionary
   // OrderedList is a static property:
   int indexOfCurrent = LevelInfo.OrderedList.IndexOf(CurrentLevel.Name);

   if(index < LevelInfo.OrderedList.Count)
   {
      string nextLevelKey = LevelInfo.OrderedList[indexOfCurrent + 1];
      
      CurrentLevel = GlobalContent.LevelInfo[nextLevelKey];
   }
   else
   {
      // Last level, handle appropriately
   }
}
```
