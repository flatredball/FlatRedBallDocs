## Introduction

This page outlines common FlatRedBall coding standards for consistency and clarity these should be followed when writing code for any FlatRedBall game, FRBDK, FlatRedBall Engine, or any other FlatRedBal application. In other words, if you are checking in any code to a FlatRedBall repository, follow these standards.

## General Programming

### Brackets

With the exception of single-line getters and setters in properties, brackets should be on their own lines. Correct:

    public float Weight
    {
       get { return mWeight;}
       set
       {
          // If there is more than one command in a setter
          // then don't keep it on one line.
          mWeight = value;
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

Incorrect:

    public float Weight
    {
       get { return mWeight;} // The getter is correct.
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

### 

### Incrementing and Decrementing Values

The ++ and -- operators for incrementing and decrementing should always occur on their own lines. Correct:

    while(!Party.IsEmpty)
    {
       index++;
       Party.Characters[index].SwitchParties();
    }

Incorrect:

    while(!Party.IsEmpty)
    {
       Party.Characters[++index].SwitchParties();
    }

Exception: Compound statements are ok in for-loops:

    for(int i = 0; i < List.Count; i++)
    {
       List[i].Activity();
    }

### Use temporary variables to avoid complex statements

Each line of code should do one thing. Do not use method calls inside of other method calls, or complex logic inside of other blocks of code. Correct:

    bool shouldPlayerBeDead = mPlayer.Health <= 0 && mPlayer.Type != PlayerType.Undead;
    if(shouldPlayerBeDead)
    {
        EndLevel();
    }

Incorrect:

    if(mPlayer.Health <= 0 && mPlayer.Type != PlayerType.Undead)
    {
        EndLevel();
    }

### Limit use of "value"

The "value" keyword in properties is necessary for setters, but it should be used as little as possible inside properties. The reason for this is because it makes migrating code outside of properties into separate methods more difficult. In practice this usually means that the field represented by the property should be set first, then it should be used in any code that follows. Correct:

    public int Age
    {
       get { return mAge; }
       set
       {
          mAge = value;  // set mAge first so it can be used

          if(mAge < 0)
          {
             throw new Exception("Age can't be less than 0");
          }
       }
    }

Incorrect:

    public int Age
    {
       get { return mAge; }
       set
       {
          if(value < 0) // mAge should have been set first and used here
          {
             throw new Exception("Age can't be less than 0");
          }
          mAge = value;
       }
    }

## Class Layout

### Access Modifiers and Static

Access modifiers should be listed prior to modifiers such as static. Correct:

    public static void Update()
    {
       // Method code
    }

Incorrect:

    static public void Update()
    {
       // Method code
    } 

### 

### Regions

For readability all members in a class should be organized by type and surrounded with the proper regions. The following skeleton region structure shows how classes should be organized:

    public class ExampleClass
    {
       #region Enums

       #endregion


       #region Fields

       #endregion


       #region Properties

       #endregion


       #region Events

       #endregion


       #region Event and Delegate Methods

       #endregion


       #region Methods

       #endregion

    }

### Structs as Fields

Structs should not be exposed as properties. Although most C# guidelines discourage exposing fields, structs are an exception because properties expose structs by value. Correct:

    // Position is public since it's a struct.
    // Capitalize it and don't begin with "m" since
    // it's exposed outside of the class.
    public Vector3 Position;

Incorrect:

    private Vector3 mPosition;

    public Vector3 Position
    {
       get{ return mPosition;}
       set{ mPosition = value;}
    }

Similarly automatic properties should not be used for structs. Incorrect:

    public Vector3 Position
    {
       get;
       set;
    }

The reason this is not permitted is because exposing structs through properties prevents the user from modifying the individual components of the struct. The following code is only valid if the Position member is a field:

    // Won't work if Position is a property:
    myPositionedObject.Position.X = 3;

#### Exceptions

The exception to this rule is if the member in question mirrors other members, and when one is changed, calculations must be performed to determine the other. For example, the PositionedObject's RotationMatrix property mirrors its RotationX, RotationY, and RotationZ properties. The two must always be synced. The only way to guarantee this is to force RotationMatrix to be a property. When it is changed, the individual rotation components are calculated. This is a very rare situation, so this exception is rarely used.

## Comments and Documentation

### XML Documentation

When adding methods to a class, triple-slash documentation should be added (type "///" on the line before a method and the XML skeleton will be added). This is especially important for public members within the engine, as this documentation will be compiled with the engine and used for intellisense hints.

    /// <summary>
    /// Here you would put a description on what this method does.
    /// </summary>
    /// <param name="firstParameter">Here you would put a description of what firstParameter does.</param>
    public void MethodName(int firstParameter)
    {
    }

### Comment code that deviates from expected structure

Comments should be used any time code deviates from what a programmer might expect. Also comment any time code is written a particular way to avoid a "gotcha" Correct:

    public void SetRankDisplay(int rankIndex)
    {
       // Players expect the first rank to be 1, even though
       // in code we use 0 as the first value.  Therefore we
       // add 1 to convert from what the code expects to what a
       // player expects
       this.TextObject.DisplayText = (rankIndex + 1).ToString();
    }

### Comment \*any\* change to already-written code

If code was written one way, then later changed, this \*must be commented\*. This is very important for maintainability. The reason for this is because any code that you are changing was written a certain way because the original author thought it was the best way. If you're changing code for whatever reason, then you're essentially saying "No, the code you have written is wrong." Any future reader will benefit from knowing the justification for the change. It's best to leave the old code there, but have it commented out so that future readers can see see what was changed along with why. Be sure to add the date of the change using a written-out month as opposed to numbers because different cultures have different order for numerical month and date (IE 1/2/10 may mean January 2 or February 1 depending on the culture).

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
          for(int i = 0; i < mBulletList.Count; i++)
          {
             if(player.Collision.CollideAgainst(mBulletList[i].Collision))
             {
                // COLLISION LOGIC
             }
          }
       }
    }

### Use the capitalized word UPDATE: when modifying already-modified code

If code has already been modified once but is being modified again, use the word UPDATE: with the date to indicate why it is being modified again. This enables future readers to have an immediate history of code changes when coming across the code.

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
          for(int i = 0; i < mBulletList.Count; i++)
          {
             if(player.Collision.CollideAgainst(mBulletList[i].Collision))
             {
                // COLLISION LOGIC
             }
          }
       }
    }

## Class, Enum, and Member Naming

The following section defines conventions when naming varaibles:

### 

### Properties and Methods should be capitalized

Correct:

    public int Count
    {
       get{ return mCount;}
       set{ mCount = value;}
    }

    public void Initialize()
    {
    }

Incorrect:

    public int count
    {
       get{ return mCount;}
       set{ mCount = value;}
    }

    public void initialize()
    {
    }

### Avoid abbreviations and non-descriptive variable names

With a few exceptions, variables should not be abbreviated. Err on the side of longer names when in doubt. Auto-complete will aid you when writing long variable names, and most if not all FRB users will be using an IDE with auto-complete support. Correct:

    int mIndex;
    float mWeight;
    double mBeginningTime;

Incorrect:

    int mIdx;
    float mWt;
    double mTime; // may not be descriptive enough, but depends on context

#### Exceptions

    // min and max are understood abbreviations
    private float mMin;
    private float mMax;

    // "num" is iffy - it's allowed but not encouraged.  Count is often a better choice
    private int mNum;

    for(int i = 0; i < Count; i++)
    {
       // i is a standard indexer so this is ok
    }

### Method arguments should be lower-case

Correct:

    public void Attack(Character characterToAttack)
    {
       ...
    }

Incorrect:

    public void Attack(Character CharacterToAttack)
    {
       ...
    }

    public void Heal(Character pCharacterToDefend)
    {
       ...
    }

### Consts and Enums should be upper-case like Properties

Correct:

    public const float MaximumWidth;

    public enum MonsterType
    {
       Ogre,
       RedDragon
    }

Incorrect:

    public const float MAXIMUMWIDTH; // Screaming Caps only ok in #defines
    public const float MAXIMUM_WIDHT;
    public const float maximum_width;

    public enum MONSTER_TYPE
    {
       OGRE,
       RED_DRAGON
    }

Exception: const variables inside methods can be lower-case.

### Variables should be nouns, Methods should be verbs

Naming your variables (fields, properties, method arguments) as nouns and naming methods as verbs will make your code read more like natural language, ultimately making it more expressive. Correct:

    float mRunningSpeed;

    public float Weight
    {
        get;
        set;
    }

    public void PerformCollisionOn(List<Entity> entityList)
    {
        // METHOD CONTENTS
    }

Incorrect:

    float mRun; // Run is normally a verb.  Also not very descriptive
    public float GetWeight
    {
       get;
       set;
    }

    // Collision is a noun, not a verb
    public void Collision(List<Entity> entityList)
    {
     
    }

Exception: "Activity" is understood as a common method name, although the word "activity" is a noun.

    public void Activity()
    {
        // METHOD CONTENTS
    }

## Patterns

### CustomActivity and CustomInitialize methods should contain no logic

Screens and Entities both have a number of standard methods in "custom code". These methods can provide an overview of the purpose of a class for programmers. For readability, the only code present in these methods should be other method calls. No logic should be present in the CustomActivity and CustomInitialize methods. Instead, these methods should only contain single calls to other methods. Correct:

    private void CustomActivity()
    {
       UpdateCharacters();

       UpdateEnemies();

       PerformCollision();

       UpdateUI();

       CheckForEndOfLevel();
    }

    private void UpdateCharacters()
    {
       // Character update logic goes here...
    }
    // remainder of methods goes here

Incorrect:

    private void CustomActivity()
    {
       // No for loops in Activity
       for(int i = 0; i < mCharacters.Count; i++)
       {
          mCharacters[i].Activity();
       }

       // The following methods could probably be organized clearly in a
       // wrapping method like UpdateEnemies()
       UpdateBoss();
       UpdateSmallEnemies();
       FollowPlayerWithSmallEnemies();

       // No if-statements in Activity
       if(IsActivityOver)
       {
          EndLevel();
       }
    }

### Methods should only have one exit point

Methods should not have return statements in the middle of the method. Incorrect:

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

Correct:

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

Exception: "Early-outs" are allowed if they are at the beginning of the method and marked with a very obvious comment:

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

## Information-adding Exceptions should be in DEBUG blocks

Exceptions can be added to help give the user additional information on why a piece of code is failing. However, these should be added in \#if DEBUG blocks. The reason is because additional if-statements can slow performance - especially in deep engine calls which may be executed in a tight loop. The exception will eventually be thrown in release, it may just be less informative than in DEBUG. But that's okay because the general pattern is that we exchange performance for information in debug, but release is intended to run as fast as possible. Incorrect:

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

Correct:

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
