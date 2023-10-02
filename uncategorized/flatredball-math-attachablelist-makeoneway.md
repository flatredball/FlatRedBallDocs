# flatredball-math-attachablelist-makeoneway

### Introduction

The MakeOneWay method makes the calling AttachbleList a one-way list. In other words, it means that the AttachableList will still contain all of the objects that it contained before calling MakeOneWay; however, the contained elements will no longer know that they belong to this List. This essentially makes the AttachableList behave like a regular List - at least until new objects are added to the List, or until [MakeTwoWay](../frb/docs/index.php) is called.

### Usage Example

The MakeOneWay method is useful if you have a list of IAttachables (such as [Sprites](../frb/docs/index.php)) which you want to remove from their respective managers without having them removed from their List. In the following example, the element at index 0 will get removed:

```
// assuming MySpriteList is a valid SpriteList, which in inherits from AttachableList
SpriteManager.Remove(MySpriteList[0]);
```

To prevent the removal from the list, it can be made one way:

```
MySpriteList.MakeOneWay();
SpriteManager.Remove(MySpriteList[0]); // <- This call will not modify MySpriteList now
```
