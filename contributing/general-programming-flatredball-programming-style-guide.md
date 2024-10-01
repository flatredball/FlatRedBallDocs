# Programming Style Guide

### Introduction

This page outlines common FlatRedBall coding standards for consistency and clarity these should be followed when writing code for any first-part FlatRedBall game, FRB Editor, FRB Engine, or any other FRB application. In other words, if you are checking in any code to a FlatRedBall repository, follow these standards.

### General Programming

#### Brackets

With the exception of single-line getters and setters in properties, brackets should be on their own lines.&#x20;

Correct:

```csharp
public float Weight
{
   get { return weight;}
   set
   {
      // If there is more than one command in a setter
      // then don't keep it on one line.
      weight = value;
      UpdateAccordingToWeight();
   }
}

public void TryPieceCreation()
{
   if( ShouldCreatePiece() )
   {
      CreatePiece();
   }
}
```

Incorrect:

```csharp
public float Weight
{
   get { return weight;} // The getter is correct.
   // Too many commands for a single line in the setter!
   set {  mWeight = value; UpdateAccordingToWeight();}
}

public void TryPieceCreation()
{
   // Brackets do not belong on the same line as the if.
   // We recognize that this is something that some prefer
   // to do, but to match consistency of the rest of the FRB
   // engine this practice is discouraged.
   if( ShouldCreatePiece() ){
      CreatePiece();
   }
}
```

####

#### Incrementing and Decrementing Values

The ++ and -- operators for incrementing and decrementing should always occur on their own lines. Correct:

```csharp
while(!Party.IsEmpty)
{
   index++;
   Party.Characters[index].SwitchParties();
}
```

Incorrect:

```csharp
while(!Party.IsEmpty)
{
   Party.Characters[++index].SwitchParties();
}
```

Exception: Compound statements are ok in for-loops:

```csharp
for(int i = 0; i < List.Count; i++)
{
   List[i].Activity();
}
```

#### Use temporary variables to avoid complex statements

Each line of code should do one thing. Do not use method calls inside of other method calls, or complex logic inside of other blocks of code.&#x20;

Correct:

```csharp
bool shouldPlayerBeDead = Player.Health <= 0 && Player.Type != PlayerType.Undead;
if(shouldPlayerBeDead)
{
    EndLevel();
}
```

Incorrect:

```csharp
if(Player.Health <= 0 && Player.Type != PlayerType.Undead)
{
    EndLevel();
}
```

#### Limit use of "value"

The "value" keyword in properties is necessary for setters, but it should be used as little as possible inside properties. The reason for this is because it makes migrating code outside of properties into separate methods more difficult. In practice this usually means that the field represented by the property should be set first, then it should be used in any code that follows.&#x20;

Correct:

```csharp
public int Age
{
   get { return age; }
   set
   {
      age = value;  // set mAge first so it can be used

      if(age < 0)
      {
         throw new Exception("Age can't be less than 0");
      }
   }
}
```

Incorrect:

```csharp
public int Age
{
   get { return age; }
   set
   {
      if(value < 0) // mAge should have been set first and used here
      {
         throw new Exception("Age can't be less than 0");
      }
      age = value;
   }
}
```

### Class Layout

#### Access Modifiers and Static

Access modifiers should be listed prior to modifiers such as static.&#x20;

Correct:

```csharp
public static void Update()
{
   // Method code
}
```

Incorrect:

```csharp
static public void Update()
{
   // Method code
} 
```

####

#### Regions

For readability all members in a class should be organized by type and surrounded with the proper regions. The following skeleton region structure shows how classes should be organized. Note, this is not required for smaller classes:

```csharp
public class ExampleClass
{
   #region Enums

   #endregion


   #region Fields/Properties

   #endregion

   #region Events

   #endregion


   #region Event and Delegate Methods

   #endregion


   #region Methods

   #endregion

}
```

#### Structs as Fields

Structs should not be exposed as properties. Although most C# guidelines discourage exposing fields, structs are an exception because properties expose structs by value.&#x20;

Correct:

```csharp
// Position is public since it's a struct.
// Capitalize it and don't begin with "m" since
// it's exposed outside of the class.
public Vector3 Position;
```

Incorrect:

```csharp
private Vector3 position;

public Vector3 Position
{
   get{ return position;}
   set{ position = value;}
}
```

Similarly automatic properties should not be used for structs. Incorrect:

```csharp
public Vector3 Position
{
   get;
   set;
}
```

The reason this is not permitted is because exposing structs through properties prevents the user from modifying the individual components of the struct. The following code is only valid if the Position member is a field:

```csharp
// Won't work if Position is a property:
myPositionedObject.Position.X = 3;
```

**Exceptions**

The exception to this rule is if the member in question mirrors other members, and when one is changed, calculations must be performed to determine the other. For example, the PositionedObject's RotationMatrix property mirrors its RotationX, RotationY, and RotationZ properties. The two must always be synced. The only way to guarantee this is to force RotationMatrix to be a property. When it is changed, the individual rotation components are calculated. This is a very rare situation, so this exception is rarely used.

### Comments and Documentation

#### XML Documentation

When adding methods to a class, triple-slash documentation should be added (type "///" on the line before a method and the XML skeleton will be added). This is especially important for public members within the engine, as this documentation will be compiled with the engine and used for intellisense hints.

```csharp
/// <summary>
/// Here you would put a description on what this method does.
/// </summary>
/// <param name="firstParameter">Here you would put a description of what firstParameter does.</param>
public void MethodName(int firstParameter)
{
}
```

#### Comment code that deviates from expected structure

Comments should be used any time code deviates from what a programmer might expect. Also comment any time code is written a particular way to avoid a "gotcha" Correct:

```csharp
public void SetRankDisplay(int rankIndex)
{
   // Players expect the first rank to be 1, even though
   // in code we use 0 as the first value.  Therefore we
   // add 1 to convert from what the code expects to what a
   // player expects
   this.TextObject.DisplayText = (rankIndex + 1).ToString();
}
```

#### Comment \*any\* change to already-written code

If code was written one way, then later changed, this \*must be commented\*. This is very important for maintainability. The reason for this is because any code that you are changing was written a certain way because the original author thought it was the best way. If you're changing code for whatever reason, then you're essentially saying "No, the code you have written is wrong." Any future reader will benefit from knowing the justification for the change. It's best to leave the old code there, but have it commented out so that future readers can see see what was changed along with why. Be sure to add the date of the change using a written-out month as opposed to numbers because different cultures have different order for numerical month and date (IE 1/2/10 may mean January 2 or February 1 depending on the culture).

```csharp
public void PerformPlayerVsBulletCollision(Player player)
{
   // June 4, 2011
   // When the Player dies, the Entity will still be
   // around so that it can be revived.
   // Even though the Player is dead, we still want to do
   // bullet collision so that the bullets don't pass through the
   // dead Player, so I'm going to comment out this if-check
   // if(player.Health > 0)
   {
      for(int i = 0; i < BulletList.Count; i++)
      {
         if(player.Collision.CollideAgainst(BulletList[i].Collision))
         {
            // COLLISION LOGIC
         }
      }
   }
}
```

#### Use the capitalized word UPDATE: when modifying already-modified code

If code has already been modified once but is being modified again, use the word UPDATE: with the date to indicate why it is being modified again. This enables future readers to have an immediate history of code changes when coming across the code.

```csharp
public void PerformPlayerVsBulletCollision(Player player)
{
   // June 4, 2011
   // When the player dies the Entity will still be
   // around so that it can be revived.
   // We want it to stop bullets, because it looks weird
   // when bullets move through the Player even if dead.    
   // if(player.Health > 0)
   // UPDATE: June 26, 2011
   // We now want to treat dead players a little differently
   // so we have them as part of a separate list that does its
   // own collision.  Therefore, we want to have the health check
   // here once again
   if(player.Health > 0)
   {
      for(int i = 0; i < BulletList.Count; i++)
      {
         if(player.Collision.CollideAgainst(BulletList[i].Collision))
         {
            // COLLISION LOGIC
         }
      }
   }
}
```

### Class, Enum, and Member Naming

The following section defines conventions when naming variables:

#### Properties and Methods should be capitalized

Correct:

```csharp
public int Count
{
   get{ return count;}
   set{ count = value;}
}

public void Initialize()
{
}
```

Incorrect:

```csharp
public int count
{
   get{ return _count;}
   set{ _count = value;}
}

public void initialize()
{
}
```

#### Avoid abbreviations and non-descriptive variable names

With a few exceptions, variables should not be abbreviated. Err on the side of longer names when in doubt. Auto-complete will aid you when writing long variable names, and most if not all FRB users will be using an IDE with auto-complete support.&#x20;

Correct:

```csharp
int index;
float weight;
double beginningTime;
```

Incorrect:

```csharp
int Idx;
float Wt;
double Time; // may not be descriptive enough, but depends on context
```

**Exceptions**

```csharp
// min and max are understood abbreviations
private float min;
private float max;

// "num" is iffy - it's allowed but not encouraged.  Count is often a better choice
private int num;

for(int i = 0; i < Count; i++)
{
   // i is a standard indexer so this is ok
}
```

#### Method arguments should be lower-case

Correct:

```csharp
public void Attack(Character characterToAttack)
{
   ...
}
```

Incorrect:

```csharp
public void Attack(Character CharacterToAttack)
{
   ...
}

public void Heal(Character pCharacterToDefend)
{
   ...
}
```

#### Consts and Enums should be upper-case like Properties

Correct:

```csharp
public const float MaximumWidth;

public enum MonsterType
{
   Ogre,
   RedDragon
}
```

Incorrect:

```csharp
public const float MAXIMUMWIDTH; // Screaming Caps only ok in #defines
public const float MAXIMUM_WIDHT;
public const float maximum_width;

public enum MONSTER_TYPE
{
   OGRE,
   RED_DRAGON
}
```

Exception: const variables inside methods can be lower-case.

#### Variables should be nouns, Methods should be verbs

Naming your variables (fields, properties, method arguments) as nouns and naming methods as verbs will make your code read more like natural language, ultimately making it more expressive.&#x20;

Correct:

```csharp
float runningSpeed;

public float Weight
{
    get;
    set;
}

public void PerformCollisionOn(List<Entity> entityList)
{
    // METHOD CONTENTS
}
```

Incorrect:

```csharp
float run; // Run is normally a verb.  Also not very descriptive
public float GetWeight
{
   get;
   set;
}

// Collision is a noun, not a verb
public void Collision(List<Entity> entityList)
{
 
}
```

Exception: "Activity" is understood as a common method name, although the word "activity" is a noun.

```csharp
public void Activity()
{
    // METHOD CONTENTS
}
```

### Patterns

#### Methods should only have one exit point

Methods should not have return statements in the middle of the method.&#x20;

Incorrect:

```csharp
public Weapon FindEquippedWeapon()
{
   // This method has return methods sprinkled throughout. 
   if(this.RightHand.Weapon != null)
   {
      return this.RightHand.Weapon;
   }
   else if(this.LeftHand.Weapon != null)
   {
      return this.LeftHand.Weapon;
   }
}
```

Correct:

```csharp
public Weapon FindEquippedWeapon()
{
   Weapon foundWeapon = null;

   if(this.RightHand.Weapon != null)
   {
      foundWeapon = this.RightHand.Weapon;
   }
   else if(this.LeftHand.Weapon != null)
   {
      foundWeapon = this.LeftHand.Weapon;
   }

   return foundWeapon;
}
```

Exception: "Early-outs" are allowed if they are at the beginning of the method and marked with a very obvious comment. Early outs should be self-contained and should not carry over into code with else statements:

```csharp
public Person FindMayor(Town townInstance)
{
   ///////////EARLY OUT/////////////
   if(townInstance.IsAbandoned)
   {
      return null;
   }
   /////////END EARLY OUT///////////

   Person foundMayor = null;
   for(int i = 0; i < townInstance.Inhabitants.Count; i++)
   {
      if(townInstance.Inhabitants[i].IsMayor)
      {
         foundMayor = townInstance.Inhabitants[i];
         break;
      }
   }
   return foundMayor;
}
```

### Information-adding Exceptions should be in DEBUG blocks

Exceptions can be added to help give the user additional information on why a piece of code is failing. However, these should be added in #if DEBUG blocks. The reason is because additional if-statements can slow performance - especially in deep engine calls which may be executed in a tight loop. The exception will eventually be thrown in release, it may just be less informative than in DEBUG. But that's okay because the general pattern is that we exchange performance for information in debug, but release is intended to run as fast as possible.&#x20;

Incorrect:

```csharp
public bool SetAllToAsleep(Family family)
{
    if(family == null)
    {
       throw new ArgumentNullException("The Family argument in SetAllToAsleep must not be null.");
    }
    foreach(var person in family)
    {
       person.IsAsleep = true;
    }
}
```

Correct:

```csharp
public bool SetAllToAsleep(Family family)
{
#if DEBUG
    if(family == null)
    {
       throw new ArgumentNullException("The Family argument in SetAllToAsleep must not be null.");
    }
#endif
    foreach(var person in family)
    {
       person.IsAsleep = true;
    }
}
```
