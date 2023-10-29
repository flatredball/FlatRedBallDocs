# instantiating-custom-types

### Introduction

As of the December 2011 release of FlatRedBall the CsvFileManager supports entries which are not basic types, but rather full classes and structs. This tutorial will show how to add structs and classes to your CSV file.

### Why use non-primitive types?

Many games require data types which are more complex than can be identified with simple primitives. For example, you may be creating a game which needs enemy types defined. Each row in your CSV may represent an enemy type; however each instance may also need a non-primitive type to define the type of attack damage it does. If these classes were laid out in code, they might look like this:

```
// EnemyInfo does not need to be manually defined if you're using Glue
public class EnemyInfo
{
   public string Name;
   public int HP;
   public AttackInfo AttackInfo;
}
// AttackInfo *does* need to be manually defined if you're using Glue.  See below for more info on this
public class AttackInfo
{
   public int Damage;
   public float AreaOfEffect;
}
```

As we'll see later in the tutorial, using classes and structs also allows for your CSV to benefit from inheritance.

### Creating the CSV

First we'll start by creating the CSV that contains our information, then we'll explain the syntax. The following is a screenshot from Excel, but you can use any spreadsheet editing program (such as OpenOffice or Google Docs): ![CsvWithClasses1.PNG](../../../../../../media/migrated\_media-CsvWithClasses1.PNG) There's a few things to note here:

1. The Name property is marked as "required". This is common practice so that the CSV can be deserialized to a Dictionary. For more info on deserializing to Dictionaries in Glue, see [this page](../../../../../../frb/docs/index.php).
2. The type for AttackInfo must be fully-qualified - in other words we use "MyGame.DataTypes.AttackInfo", not just "AttackInfo". This requirement may be eased in a future version of Glue.
3. Each parameter can be assigned to any value valid for the type. Note that order does not matter (AreaOfEffect could be assigned before Damage), and it is not necessary to assign variables. For example, you could simply have "Damage=4" and AreaOfEffect would remain as its default value.

**Types used by the CSV must be defined manually** Glue will automatically define the type that the entire CSV is using - in this case "EnemyInfo", however types used inside the CSV (such as AttackInfo) must be manually defined inside your current project. This condition may change in future versions of Glue.

Now you can either load this CSV through the CsvFileManager, or you can use the automatically-loaded member created in Glue for the given CSV file.

### Creating classes for Inheritance

Objects in CSVs also support inheritance. Inheritance allows you to define a base type for a property on your objects, but then specifying derived types in each individual row. First, we'll modify our data classes as follows:

```
// No changes on EnemyInfo - just adding for reference
public class EnemyInfo
{
   public string Name;
   public int HP;
   public AttackInfo AttackInfo;
}

public class AttackInfo
{
   public int Damage;
   public float AreaOfEffect;
   public virtual void ApplyDamage()
   {
      // This should get overriden by specific types
   }
}
// Let's create a SlashingAttackInfo derived class:
public class SlashingAttackInfo : AttackInfo
{
   public float CriticalHitChance;
   public override void ApplyDamage()
   {
       //Do logic specific to SlashingAttackInfo here
   }
}
// Let's create one more class: a FireAttackInfo
public class FireAttackInfo : AttackInfo
{
    public float ExtraBurnDamage;
    public override void ApplyDamage()
    {
        // Do logic specific to FireAttackInfo here
    }
}
```

### Defining a CSV that supports inheritance

Using the code above, we now have FireAttackInfo and SlashingAttackInfo, both of which inherit from AttackInfo. We can now instantiate any of those three types in our AttackInfo column. The following shows a CSV that instantiates different types: ![CsvSupportingInheritance.PNG](../../../../../../media/migrated\_media-CsvSupportingInheritance.PNG) When using inheritance we must specify the type that we want to use in each column. The syntax for this is the same as it is when instantiating an object in code - use the keyword "new" followed by the type. The contents of the parenthesis are the same as as before. You can assign values defined in the derived class as well as the base class. You can also leave out assignments that you want to keep as the default. For example the EndBoss enemy does not define the AreaOfEffect - it defaults to 0.

### Using Existing Types

The CsvFileManager doesn't differentiate between types that you have defined and types that are defined by other libraries (such as types in the XNA libraries). This means that you can immediately add a lot of types of objects to your CSV without ever having to define them in your project. For example, the following shows how to define a column of XNA Rectangles:

|                                                |
| ---------------------------------------------- |
| Boundaries (Microsoft.Xna.Framework.Rectangle) |
| X=0, Y=0, Width=64, Height=64                  |
| X=40, Y=30, Width=80, Height=55                |

Microsoft.Xna.Framework
