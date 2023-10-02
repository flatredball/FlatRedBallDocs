# glue-tutorials-save-classes-and-glue

### Introduction

The tutorial on [proper information access](../frb/docs/index.php) discusses how to share information between different Screens and Entities in your game as well as how to have information persist after a Screen is destroyed. The tutorial suggested using "Save" classes to contain information. This pattern as it is used in the FlatRedBall Engine is discussed [here](../frb/docs/index.php). Save classes as they are commonly used with Glue and Entities will be discussed in this article.

### A common scenario

Consider a situation where you are making a game like Final Fantasy. The player will control a party of heroes which will change throughout the game. For this game you may create an Entity called "Hero" which loads the appropriate content depending on which hero the Entity is representing.

The Hero will also need properties which are used as coefficients in battle, as well as characteristics (such as Name) for the benefit of the player. For this example we'll say that each character has the following characteristics:

* Name
* Experience
* MaxHp

Even though MaxHp is impacted by Experience, we'll store it separately because there are also items which can be used which permanently increase the MaxHp.

### Information outlives Entities

The information that is mentioned above (Name, Experience, MaxHp) outlive the individual the Entity that uses it. The player may move from one part of the world to another, and may go to sub-menus or battles - all of which require Screen changes, resulting in Entities being destroyed and re-created. However, this information must persist through all creation and destruction. This information will be stored in a Save class for the character. Keep in mind that this example is simplified to keep things simple. In a real game, your Save class may have many more properties.

### Creating a Save class

We'll start by creating a Save class which we'll build upon throughout the tutorial. We'll be adding to it incrementally and discussing the logic behind why these changes are made, as this will be easier to understand rather than starting with a complete Save class.

First, let's create the Save class. The naming convention is the name of the Entity with "Save" appended. Therefore, if your Entity is called "Hero", the Save class would be called "HeroSave". If you named your Entity "HeroEntity", then you will still want to use the name "HeroSave" instead of "HeroEntitySave". At first your class may look like this:

```
public class HeroSave
{ 
   public string Name;
   public int Experience;
   public int MaxHp;
}
```

**Public Fields? Is that allowed?** Most sources will say that public fields are a bad idea. Instead, they say, you should use public properties (getters and setters). However, the exception in FlatRedBall coding is Save classes. The reason is because these classes are meant to only store information and (as we'll see later) code to create Entities. However; it is perfectly acceptable to create properties for fields if you'd like to perform error-checking on the data setters.

### Creating a ProfileSave class

We've created a HeroSave which represents the persistent information for a single Hero, but as we mentioned before, this game will contain a number of Heroes that the player can control. Therefore, we'll want to create a ProfileSave as follows:

```
public class ProfileSave
{
   // You may want to add other information here
   // to track progress that isn't necessarily associated
   // with the individual HeroSaves, such as which side-quests
   // have been completed.
   public List<HeroSave> Heroes = new List<Hero>();
}
```

### Making the ProfileSave instance

There's two ways that you can instantiate a ProfileSave:

* Create a new instance through "new"
* Load one from file

Ultimately, you will have to support both - a new game will need to create a ProfileSave, and the game should also support saving/loading.

Fortunately, the Saving/Loading is very easy to do. If you only include primitive types (int, string, long), Lists, and other Save objects, any Save object is automatically serializable to disk. This means you can simply do this to save a profile:

```
FileManager.XmlSerialize(profileSaveInstance, "FileName.xml");
```

and to load:

```
profileSaveInstance = FileManager.XmlDeserialize<ProfileSave>("FileName.xml");
```

Of course you may want to consider encryption and saving to a user-specific folder, but we won't cover how to do that in this tutorial.

As far as creating an initial profile, you may want to have a static method in the ProfileSave class as follows:

```
public static ProfileSave CreateProfileSave()
{
    ProfileSave profileSaveToReturn = new ProfileSave();

    HeroSave heroSave = new HeroSave();
    // do whatever to the first HeroSave here
    profileSaveToReturn.Heroes.Add(heroSave);

    // Create additional hero saves if necessary  
}
```

### Adding a ProfileSave to GlobalData

Of course you will want all of the ProfileSave information globally available because you will need to access it from a lot of places. To do this, simply add a instance to your GlobalData:

```
// Inside GlobalData:
public static ProfileSave
{
   get;
   private set;
}

// Instantiate in an initialize:
public static void Initialize()
{
   bool shouldLoadProfileFromFile = false; // this should be modified to load from file if appropriate
   if(shouldLoadProfileFromFile)
   {
       ProfileSave = FileManager.XmlDeserialize<ProfileSave>("fileName.xml");
   }
   else
   {
       ProfileSave = ProfileSave.CreateProfileSave();
   }
}
```

This code will need to be modified as you develop your game, but it should be enough to get you started on ProfileSave instantiation.

### Using Save classes in your Entity

It is likely that you will need your Hero Entity to have access to information contained in the HeroSave class. For example, in the battle Screen you may want to show the Hero's MaxHp so the user knows how much health the Hero has relative to its max. Therefore, you \*could\* do the following in your Hero's custom code:

```
// Inside the Hero Entity's custom code:
public string Name;
public int Experience;
public int MaxHp;
```

This is a little redundant considering we have this information already contained in the Hero class. Therefore, a common approach is to include the Save class in the Entity itself as follows:

```
// Inside the Hero Entity's custom code:
public HeroSave AssociatedSave
{
   get;
   set;
}
```

This approach is nice because it lets us reuse the fields we've already defined in the Save class. If we decide to add more save-able properties, we only have to do it to the Save class and the Entity will automatically get these properties.

Another benefit is that since the Save class is a class (as opposed to a struct) then the Entity and ProfileSave can both share the same instance. This means that your Hero Entity can modify its AssociatedSave (like adding to Experience) and the ProfileSave will automatically get updated.

### Creating Entities from Save instances

The last thing we need to think about is how to create Entities using the information in the Save class. The main point in this section is that the Save class pattern indicates that the Save object should create the "runtime" object - which is the Hero Entity in this case. This means that you will want to add the following method to the HeroSave class:

```
public Hero ToEntity(string contentManagerName)
{
    Hero newInstance = new Hero(contentManagerName);

    newInstance.AssociatedSave = this;

    return newInstance;
}
```

That's all you need to do to create an Entity using your Save class! Now you can easily create Entities in any Screen that uses them, and these Entities will automatically modify the ProfileSave's contained Hero instances.

### Creating the right "type" of Entity

As we'll show in a [later tutorial](../frb/docs/index.php), Glue supports optionally loaded content. This is important so that you can reuse your Entities even though they may use different content. In this particular case, we may want our Hero class to have a lot of common functionality, but the content should be different - in other words one Hero will probably use a different set of AnimationChains than the other.

However, which content is used should be determined inside the Hero class, and not outside of it. Therefore, the Save class should not store information like file names. Instead, it should only store values that should be used to load content internally in the Entity. Therefore, we may want to create an enumeration as follows:

```
public enum HeroType
{
   // Using the characters from Final Fantasy IV (II in the US)
   Cecil,
   Kain,
   Rydia,
   Rosa
   // and so on
}
```

This means you would want to add the following property to your Save class:

```
public HeroType HeroType;
```

And finally in the the ToEntity method:

```
public Hero ToEntity(string contentManagerName)
{
    Hero newInstance = new Hero(contentManagerName);

    newInstance.AssociatedSave = this;
    // This is a method you would write which would create
    // the content as appropriate
    newInstance.SetContentAccordingToHeroType(this.HeroType);
    return newInstance;
}
```

This will allow your Save class to fully create Entities according to its contained information. This flexibility will let you add Entities to any Screen that use the actual game data very easily.
