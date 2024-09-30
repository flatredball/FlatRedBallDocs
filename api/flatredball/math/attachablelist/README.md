# AttachableList

### Introduction

An AttachableList is a list which contains instances to [IAttachables](../../../../frb/docs/index.php). Instances of [IAttachables](../../../../frb/docs/index.php) added to an AttachableList share a two-way relationship with the AttachableList by default. Common AttachableLists include the [PositionedObjectList](../../../../frb/docs/index.php) and [SpriteList](../../../../frb/docs/index.php) classes.

### A short discussion about two-way relationships

While this article goes into extensive detail about two-way relationships, this paragraph provides a quick explanation of what it means. In short, a two-way relationship means that IAttachables (this includes [PositionedObjects](../../../../frb/docs/index.php) such as [Sprite](../../../../frb/docs/index.php), [Shapes](../../../../frb/docs/index.php), and [Entities](../../../../frb/docs/index.php#Entities)) keep track of all [PositionedObjectLists](../../../../frb/docs/index.php) that they are a part of. The reason that this relationship exists is so that objects can remove themselves from all [PositionedObjectLists](../../../../frb/docs/index.php) that they are a part of automatically when removing them through the engine. **Any "Remove" method offered by FlatRedBall managers will remove the argument object from all of its lists - at least for all** [**PositionedObject**](../../../../frb/docs/index.php)**-inheriting objects.** A simple code example shows this functionality:

```
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
PositionedObjectList<Sprite> first = new PositionedObjectList<Sprite>();
PositionedObjectList<Sprite> second = new PositionedObjectList<Sprite>();
PositionedObjectList<Sprite> third = new PositionedObjectList<Sprite>();

first.Add(sprite);
second.Add(sprite);
third.Add(sprite);

// at this point, the Sprite is part of all 3 PositionedObjectLists.

SpriteManager.RemoveSprite(sprite);

// The RemoveSprite method removes the Sprite from the FlatRedBall engine,
// as well as any PositionedObjectLists that the Sprite is a part of:
bool isSpritePartOfAnyList = first.Contains(sprite) || second.Contains(sprite) || third.Contains(sprite);

// isSpritePartOfAnyList will be false
```

### Two Way Relationships

A two way relationship is a relationship between an object that implements the [IAttachable](../../../../frb/docs/index.php) interface and a class that inherits from the AttachableList class. Normally when objects are added to lists, the list stores any number of objects, but the objects themselves are not aware of which lists they belong to. These are known as "one-way" relationships: the knowledge of membership only exists in the list object. A two-way relationship, on the other hand, is one where the list stores all of its contained objects, and all of the contained objects are aware of all of the lists they belong to. When an [IAttachable](../../../../frb/docs/index.php) is added to an AttachableList, the following occurs:

* The [IAttachable](../../../../frb/docs/index.php) is added to the collection of items that the AttachableList stores.
* The [IAttachable](../../../../frb/docs/index.php) adds the AttachableList to its ListsBelongingTo list.

And similarly, when an [IAttachable](../../../../frb/docs/index.php) is removed from an AttachableList, the following occurs:

* The AttachableList is removed from the [IAttachable's](../../../../frb/docs/index.php) ListsBelongingTo.
* The [IAttachable](../../../../frb/docs/index.php) is removed from the AttachableList.

### Reason for Two-Way Relationships

Two way relationships exist to eliminate scope problems when removing an IAttachable completely. The FlatRedBall Engine often uses AttachableLists internally to categorize Sprites. For example, Sprites which belong to the SpriteManager can be either automatically updated or manually updated. Each is stored in a different array. Similarly, it is common practice to create AttachableLists to organize objects by their behavior. Common examples include placing Polygons which represent triggers in a level in a [PositionedObjectList](../../../../frb/docs/index.php) or to organize player bullets and enemies in separate [SpriteLists](../../../../frb/docs/index.php). A bullet and enemy [SpriteList](../../../../frb/docs/index.php) example clearly shows the kind of problems which can occur in the absence of two-way relationships. When a bullet collides with an enemy, it should be completely removed from the game. Not only does it have to be removed from any internal [SpriteLists](../../../../frb/docs/index.php) (such as lists in the [SpriteManager](../../../../frb/docs/index.php)), but also from the programmer-created list of bullets that it belongs to. In the absence of a two-way relationship, at least two calls would be required:

1. Remove the Sprite from the engine
2. Remove the Sprite from bullet list

This is inconvenient at best. It also requires code to be written in pairs (or more if an object is part of more lists). While the previous example highlights inconveniences, there is another practical reason for having two-way relationships. Sometimes the code that creates a PositionedObject and the code that destroys a PositionedObject may exist in two different areas of your project. The code that destroys a PositionedObject may not have access to all of the PositionedObjectLists that a given PositionedObject is a part of. The automatic removal enabled by two-way relationships enables removal without having to track down all lists. The two-way relationships between [IAttachables](../../../../frb/docs/index.php) and AttachableLists enables any method to remove objects from all lists both engine and user created through the use of globally-visible static managers such as the [SpriteManager](../../../../frb/docs/index.php) and [TextManager](../../../../frb/docs/index.php). Simply calling Remove on an object's manager automatically removes it from all lists that it shares two-way relationships with. The following code creates a [Sprite](../../../../frb/docs/index.php), adds it to the [SpriteManager](../../../../frb/docs/index.php), adds it to a [SpriteList](../../../../frb/docs/index.php), then removes it from the [SpriteManager](../../../../frb/docs/index.php). Next the [SpriteList](../../../../frb/docs/index.php) is checked to see if it still has a reference to the [Sprite](../../../../frb/docs/index.php). If it does, the application exits. Since it does not, your application will not exit.

```
Sprite sprite = SpriteManager.AddSprite("redball.bmp");
SpriteList spriteList = new SpriteList();

spriteList.Add(sprite);

SpriteManager.RemoveSprite(sprite);

// Because of the two-way relationship, the Sprite
// is removed from BOTH the SpriteManager and SpriteList.
bool isSpriteStillInList = spriteList.Contains(sprite);

if (isSpriteStillInList)
{
    Exit();
}
```

### One-Way Methods

[IAttachables](../../../../frb/docs/index.php) can also be added to AttachableLists creating one-way relationships using the AddOneWay method. In a one-way relationship, the AttachableList knows about its contained [IAttachables](../../../../frb/docs/index.php), but the [IAttachables](../../../../frb/docs/index.php) do not know about their list. This is similar to how normal Arrays and Lists work. Usually one way relationships are useful when the scope of an AttachableList is brief - usually one frame or non-Main method. There are two common situations in which one-way AttachableLists are used:

1. Methods wich return AttachableLists usually fill them using AddOneWay. The assumption is that these lists will have a short lifespan.
2. Short-lifespan AttachableLists created outside of the engine should have elements added to them using one-way methods. Any AttachableList which has a lifespan of one frame or less should usually be populated using AddOneWay.

The reason for two-way relationships is to remove unused [IAttachables](../../../../frb/docs/index.php) from all AttachableLists which reference them. However, if an AttachableList has a short lifespan, then it will likely fall out of scope before any [IAttachables](../../../../frb/docs/index.php) that it references are removed. One reason to use one-way relationships for short-lifespan AttachableLists is to reduce the overhead of creating and managing two-way relationships. The Add method is slightly slower than AddOneWay as two-way relationships require two Add calls to internal List<> objects. Another reason is that additional references reduce the efficiency of the garbage collector. A third reason to avoid two-way relationships for short-lifespan AttachableLists is exemplified by the following code. First, consider what occurs when the following code is executed.

```
{  // brackets to force scope
  SpriteList spriteList = new SpriteList(); // SpriteList inherits from AttachableList
  Sprite sprite = SpriteManager.AddSprite("redball.bmp");

  // The Sprite is referenced by the "sprite" instance as well as the engine.
  // The SpriteList is referenced only by the "spriteList" instance.
```

![TwoWay1.png](../../../../.gitbook/assets/migrated\_media-TwoWay1.png)

```
  spriteList.Add(sprite);
  // Notice the two-way relationship between the Sprite and SpriteList
```

![TwoWay2.png](../../../../.gitbook/assets/migrated\_media-TwoWay2.png)

```
}
// Scope of both instances ends.  However, since the Sprite continues
// to reference the SpriteList, we have a list which is probably not needed
// anymore, but it still remains in memory.
```

![TwoWay3.png](../../../../.gitbook/assets/migrated\_media-TwoWay3.png) Now, consider the result of using AddOneWay instead of Add:

```
{  // brackets to force scope
  SpriteList spriteList = new SpriteList(); // SpriteList inherits from AttachableList
  Sprite sprite = SpriteManager.AddSprite("redball.bmp");

  // The Sprite is referenced by the "sprite" instance as well as the engine.
  // The SpriteList is referenced only by the "spriteList" instance.
```

![TwoWay1.png](../../../../.gitbook/assets/migrated\_media-TwoWay1.png)

```
  spriteList.AddOneWay(sprite);
  // Notice the one-way relationship.  The Sprite doesn't know about the SpriteList
```

![OneWay2.png](../../../../.gitbook/assets/migrated\_media-OneWay2.png)

```
}
// Scope of both instances ends.  The only reference to the SpriteList was
// the "spriteList" instance which is no longer in scope.  Therefore, the 
// unused SpriteList is ready to be cleaned up.
```

![OneWay3.png](../../../../.gitbook/assets/migrated\_media-OneWay3.png)

### Converting Between Two-Way and One-Way

There are times when an AttachableList should be converted between a two-way and one-way AttachableList. One common scenario is when a one-way AttachableList returned from a method is going to be used for longer than one frame. In this example, all Sprites with the word "collision" in the first [SpriteList](../../../../frb/docs/index.php) are added to the second. Since FindSpritesWithNameContaining returns a one-way [SpriteList](../../../../frb/docs/index.php), two-way relationships are created for all [Sprites](../../../../frb/docs/index.php) in the the second [SpriteList](../../../../frb/docs/index.php).

```
// assume that firstSpriteList is a valid SpriteList
SpriteList secondSpriteList = firstSpriteList.FindSpritesWithNameContaining("collision");
secondSpriteList.MakeTwoWay();
```

Similarly, all AttachableLists have a MakeOneWay method which makes the relationship with all contained [IAttachables](../../../../frb/docs/index.php) one-way.

### "foreach" allocates memory

Using a foreach statement on an AttachableList will allocate memory. This is a very common gotcha when working with AttachableLists (and PositionedObjectLists). Consider the following to improve the performance of your application:

```
// Slowest:
foreach(Entity entity in EntityList)
{
   entity.PerformSomeAction();
}
// Faster:
for(int i = 0; i < EntityList.Count; i++)
{
   Entity entity = EntityList[i];
   entity.PerformSomeAction();
}
// Even faster:
int count = EntityList.Count;
for(int i = 0; i < count; i++)
{
   Entity entity = EntityList[i];
   entity.PerformSomeAction();
}
```

### AttachableList Members

* [FlatRedBall.Math.AttachableList.FindByName](../../../../frb/docs/index.php)
* [FlatRedBall.Math.AttachableList.MakeOneWay](../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../frb/forum.md) for a rapid response.
