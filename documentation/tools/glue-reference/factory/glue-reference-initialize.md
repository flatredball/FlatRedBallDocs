# glue-reference-initialize

### Introduction

Factories must have their Initialize method called before they are used. In many cases the Initialize method is automatically called in Glue generated code. This article explores when the Initialize method is called for you and when you must call it yourself. The Initialize method also controls which list is populated by a factory. This article also discusses this, specifically as it applies to inheritance. For an in-depth look at using Factories, see the [tutorial on "Created by Other Entities"](../../../../frb/docs/index.php)

### A simple situation

First we'll look at a very simple scenario. Consider an Entity called "Enemy". In this example, Enemy has its "CreatedByOtherEntities" set to true, meaning Glue will automatically generate a Factory called EnemyFactory. Let's say that there is also a Screen called GameScreen, and that GameScreen has a PositionedObjectList of Enemies. To summarize, if the following conditions are met, then Initialize will be called:

* An Entity has CreatedByOtherEntities set to true
* A Screen has a PositionedObjectList of the Entity mentioned in the previous point

Glue assumes that newly-created Enemies should be put in the PositionedObjectList in GameScreen (assuming GameScreen is the current Screen). In other words, the EnemyFactory can be used when GameScreen is live; the GameScreen will automatically call Initialize on the EnemyFactory. If GameScreen did not have a list of Enemies, Glue would not automatically Initialize the EnemyFactory. This means that if you intend to use EnemyFactory's CreateNew method in a Screen which does not contain a PositionedObjectList of Enemies, then you must manually call Initialize on EnemyFactory. Also, keep in mind that if you are manually calling Initialize, then you must manually call Destroy on the Factory. Destroy should probably be called in your Screen's CustomDestroy method.

### Lists in Other Entities

**PositionedObjectLists in Entities will not Initialize factories:** Entities that include PositionedObjectLists of Entities that have an associated factory will not Initialize the factory. In this case you must either place a PositionedObjectList in your Screen, or you must manually call Initialize on the factory passing in the PositionedObjectList in your Entity. Therefore, if working with a Bullet object in an Entity, your code might look like this:

```
BulletFactory.Initialize(this.BulletList, ContentManagerName);
```

### Initialize lasts one Screen

An Initialize call (whether in custom or generated code) will only put the Factory in a valid state for the given Screen. In other words, if GameScreen automatically calls Initialize on EnemyFactory, other Screens must still call Initialize (and Destroy) on EnemyFactory if your code calls EnemyFactory.CreateNew. The Initialize call expires at the end of the current Screen and must be called again (either manually or through generated code).

### Factories and inheritance

In the section above, we discussed that Glue will automatically generate code to call Initialize on a given Factory if the current Screen has a PositionedObjectList of the associated Entity. However, let's consider a more complicated situation: In this example we will use an Entity called Enemy which is the base Entity for three other Entities as shown in the following diagram:

* Enemy
  * Orc
  * Dragon
  * Troll

We'll assume that Orc, Dragon, and Troll are all Entities which have matching Factories - that is, they all have CreatedByOtherEntities set to true. As mentioned above, if there is a PositionedObjectList of Orc, Dragon, or Troll, then the associated Factory will automatically have Initialize called. However, it is common to create PositionedObjectLists of base types to simplify custom code. In other words, GameScreen may have a PositionedObjectList of type Enemy. In this case, Glue also assumes that you intend to associate the List of the base type (Enemy in this example) with any of the derived types (Orc, Dragon, and Troll). Therefore, if you have a PositionedObjectList of Enemy, then OrcFactory, DragonFactory, and TrollFactory will all be initialized automatically. Also, **they will be initialized using the PositionedObjectList of Enemies, so any Troll, Dragon, or Orc that you create will be put in that list.**

### Factories and inheritance chains

Next let's look at a situation where there are three entities in an inheritance chain:

* Enemy
  * Dragon
    * RedDragon

We'll assume RedDragon is an Entity that is CreatedByOtherEntities, so there is a RedDragonFactory. As explained above, RedDragonFactory will be automatically Instantiated in a Screen if:

* The screen includes a PositionedObjectList of type Enemy

\-- OR --

* The Screen includes a PositionedObjectList of type RedDragon

But what if the Screen only contains a PositionedObjectList of Dragon (the type "inbetween" Enemy and RedDragon)? In this situation, Glue does not assume you intend to have the RedDragonFactory instantiated. Glue will only automatically instantiate the RedDragonFactory if there is a PositionedObjectList of the most base Entity (Enemy in this case) or most derived (RedDragon in this case) in a given Screen. However, you can still customize how the behavior of the Factory works using the [EntitySpawned](../../../../frb/docs/index.php) Action and manually adding newly-created Entities to any List.

### Factories and Multiple Lists of the Same Type

If your screen contains multiple lists of the same type, Glue will generate code to add entities to all lists. For example, if your game has an entity called Enemy and you have two lists (GroundEnemies and AirEnemies), then any Enemy factory (or factory of entity deriving from Enemy) will insert into both lists. A list can be removed from automatic association with a factory in Glue (this requires GLUX version 3 or greater). This value is true by default, but can be set to false to prevent Glue from automatically associating any factories with the list.

![](../../../../media/2020-02-img\_5e438e9f4f62f.png)

&#x20; Factory-List association can also be adjusted in code by calling RemoveList. To remove the lists from the factory:

```lang:c#
Factories.EnemyFactory.RemoveList(GroundEnemies);
Factories.EnemyFactory.RemoveList(AirEnemies);
```

&#x20;     &#x20;
