# destroying-entity-instances

### Introduction

In many cases the destruction of Entity instances (which appear under the Objects category of a Screen or Entity in Glue) is handled for you automatically by Glue; however, there are situations when you will need to manually destroy these instances. This tutorial discusses when you will need to destroy Entity instances and when you don't. We'll also explore common bugs that can occur when destroying Entity instances. For brevity we'll refer to Entity instances as "instances" (or instance if talking about single Entity instances) for the rest of this tutorial.

In short, if you are manually adding an instance from the game then you should almost always call Destroy on the instance. Other methods of destroying an instance (such as removing an instance from a PositionedObjectList without calling Destroy) may incompletely remove it from the game, causing accumulation errors and Screen cleanup bugs.

### Instances added through Glue

The simplest scenario is when an instance exists as an Object in a Screen or Entity. The following image shows an instance called "CharacterInstance" under the GameScreen:

![CharacterInstanceInScreen.png](../../../media/migrated\_media-CharacterInstanceInScreen.png)

In this situation, the generated code will automatically handle calling Destroy. We can look at the GameScreen's Destroy method to verify:

![CharacterInstanceDestroy.png](../../../media/migrated\_media-CharacterInstanceDestroy.png)

### Instances added to PositionedObjectLists which are created in Glue

The second situation is slightly more complicated, but still requires no manual destruction of instances. Consider a situation where a PositionedObjectList is added to Glue, and this PositionedObjectList's type is an Entity (like Character). If instances are added to this PositionedObjectList, they will automatically be cleaned up as well. Let's look at an example:

First we'll need a PositionedObjectList in Glue:

![CharacterListInGlue.png](../../../media/migrated\_media-CharacterListInGlue.png)

Now instances created in custom code can be added to this list. For example, the following code could be used in CustomInitialize of GameScreen:

```
for(int i = 0; i < 4; i++)
{
    Character character = new Character(ContentManagerName);
    this.CharacterList.Add(character);
}
```

Since the CharacterList is a PositionedObjectList added in Glue, there is no need to manually destroy the Character instances added to CharacterList. Let's look at the generated code to verify:

![GeneratedCodeDestroyList.png](../../../media/migrated\_media-GeneratedCodeDestroyList.png)

#### How does the Generated code work?

You may be wondering how the generated code shown above works. The reason this code clears the list (and destroys all contained instances) is because all Entities inherit from PositionedObject. This means that they share a [two-way relationship](../../../frb/docs/index.php#Two\_Way\_Relationships) with any PositionedObjectList that they are added to. When an Entity instance is destroyed, it removes itself from any PositionedObjectLists that it is a part of. Therefore, when a Character instance it is destroyed, it removes itself from the CharacterList.

### Destroying instances created in custom code

As you are developing your game you may find that you need to create an Entity instance in custom code. For example, you may do something like this:

At class scope:

```
Character mCharacterInstance;
```

In your Screen's CustomInitialize:

```
mCharacterInstance = new Character(ContentManagerName);
```

At this point there is a Character instance in custom code; however, since it was completely created in custom code, Glue doesn't know about this object at all. This means that you must:

* Call Activity on mCharacterInstance in the Screen's CustomActivity
* Call Destroy on mCharacterInstance in the Screen's CustomDestroy

These two requirements didn't exist above because both in the case of an individual instance as well as a PositionedObjectList of Characters Glue called Activity and Destroy in generated code. Therefore, you will need the following code:

In your Screen's CustomActivity:

```
mCharacterInstance.Activity();
```

In your Screen's CustomDestroy:

```
mCharacterInstance.Destroy();
```

WARNING: Unless you have a very good reason to do this, you should not call RemoveSelfFromListsBelongingTo on an Entity - calling Destroy will do this for you, plus it will take care of all necessary destruction.

### Destroying instances in a PositionedObjectList prior to the Screen's Destruction

As mentioned above, instances that are added to a PositionedObjectList which is part of Glue will automatically be destroyed when the Screen is destroyed. However, you may be creating a Screen which includes Entities which will be destroyed before the Screen itself has been destroyed.

If you are creating and destroying Entities during the life of a Screen (such as bullets fired by a character or score entries in a high-score table) then you will need to call Destroy on instances manually. Fortunately if your instances are part of a PositionedObjectList, you can simply call Destroy on any instance that needs to be destroyed and it will automatically be removed from any PositionedObjectLists that it belongs to.

For example, if you want to destroy Bullet instances which exist in a BulletList when they collide with CharacterInstance, you could do so as follows:

```
// Loop backwards because the List may have elements removed in this loop
for(int i = BulletList.Count - 1; i > -1; i--)
{
   if(BulletList[i].Collision.CollideAgainst(CharacterInstance.Collision))
   {
       BulletList[i].Destroy();
   }
}
```

Notice that the code uses a "reverse for-loop". For more information on this, see [this page](../../../frb/docs/index.php#Reverse\_For\_Loops)

WARNING: Unless you are otherwise accounting for Entities in a PositionedObjectList which has been created in Glue, you should **never** call methods on the List itself which remove elements from it. In other words:

```
BulletList.RemoveAt(i); // NO NO NO!
BulletList.Remove(BulletList[i]); // Also NO NO NO!
BulletList.Clear(); // You guessed it:  NO NO NO!
```

The reason for this is because the instances in the list will be removed from the list, but won't be Destroyed. Later when containing Screen is destroyed, it won't contain the instances added to it earlier, and those instances will never get destroyed. The result will be that you'll get a cleanup exception when the Screen is destroyed because you'll have Entity instances floating around in the engine.

### Calling Destroy from within an Entity

The great thing about the Destroy method and its ability to remove instances from any PositionedObjectList that it belongs to is that you never have to worry about having container Lists in scope when destroying an Entity. For example, consider a situation where a Bullet Entity keeps a timer of how long it has been alive, and destroys itself after a given number of seconds. This logic can take place inside the Bullet Entity's CustomActivity method:

In Bullet's CustomActivity:

```
// Assuming mTimeCreated is set in the Bullet's CustomInitialize, and TimeToStayAlive
// is a valid variable (probably defined in Glue as a "New Variable"
if(TimeManager.SecondsSince(mTimeCreated) > TimeToStayAlive)
{
   this.Destroy(); // This will remove the Bullet from any PositionedObjectLists that it is a part of
}
```

If your game has a BulletList in the GameScreen, the code above will automatically remove the instance from the BulletList - even though your code never explicitly removes the object from that list.

This means that Destroy can be called at any point by any object (Screen, the instance itself, or even other Entities that may have a reference to the instance that should be destroyed) and all lists will automatically be maintained for you.

Of course, be sure that if you do this inside of a loop that depends on the size of a list that will be modified, the loop should be reverse (as shown above). In the rare situation where a call may destroy more than one instance of an Entity, you will need to have additional checks on your loop, or you will need to modify the index integer.

### Destroy and Activity

While this may seem counter-intuitive, Entities which are Destroyed can still have their Activity methods called. The reason for this is because the Destroy method removes the Entity from any PositionedObjectLists, but does not alter the logical state of an Entity. If your Entity has been added through a PositionedObjectList in Glue, then you don't need to worry about this. If you have a standalone instance of an Entity inside another Entity or Screen, then you may encounter this problem.

This means that if you intend to destroy an Entity before the containing Screen is destroyed, you must do one of the following things:

1. Add the Entity to a PositionedObjectList through the Glue UI
2. Create a IsDestroyed bool in the custom code for the Entity which gets set to true in CustomDestroy and is checked in CustomInitialize. Be careful of this approach as generated code may still get executed
