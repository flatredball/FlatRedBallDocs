## Introduction

The patterns and code created by Glue encourage proper information encapsulation. For example, Entities do not by default have access to the Screens that created them. Objects inside entities are by default private. Also, since the ScreenManager.CurrentScreen is casted as a Screen, you do not immediately know the current Screen's type. This limit to information can help encourage you to write cleaner code, but it can also make transferring information between objects a little more difficult. This article will talk about common methods of transferring information between different Screens and also between different Entities. It will present a few approaches to sharing information, and explain which should be used in which case.

## GlobalData

The simplest approach to sharing information is to make it global. In C#, that means to define it as "public static". The broadest form of global data is generally placed in a class called GlobalData. The GlobalData class is commonly used to provide **access** to data in your game. For information on how to write a public static GlobalData class, see [this page](/frb/docs/index.php?title=Glue:Reference:Code:GlobalData.md "Glue:Reference:Code:GlobalData"). First, let's consider the type of data we would want to put in GlobalData. The general rule is that information should be accessible through GlobalData if all of the following are true:

-   It outlives Screens and Entities
-   It is used in multiple places in your game - often for different reasons

Let's look at these points individually.

### It outlives Screens and Entities

The first point is about how long information lives. This is similar to asking if information is owned by Screens or Entities. Some data is obviously owned by Sceens or Data. For example, if you are making a fighting game, then each enemy Entity should probably contain its current health. Similarly, a car in a game might store its own current velocity. This type of information belongs to the Entity that uses it because when an Entity is Destroyed, then that information does not matter anymore. If you are in the main menu, it doesn't make sense to get access to a car's current velocity - because there is no car to get the velocity of. On the other hand, if you are making an RPG, then should the player Entity "own" its experience? Likely not, because experience will exist even if the Entity (the Sprite and collision object and animation) is Destroyed when the Screen changes. If the player goes into a new village or exits to the main menu the profile's experience should not be lost. This information should outlive any Entity or Screen in the game. Examples of information that outlive Entities and Screens are:

-   Current profile name
-   Experience points
-   Quests complete
-   Money earned
-   Options such as controller sensitivity, inverted axis settings, and audio options.

### It is used in multiple places in your game - often for different reasons

If information is used in a variety of areas, then it should be globally accessible. For example, a player's experience points may be used in a variety of areas. The character may need to know experience points to calculate its current level which may determine damage dealt in battle. A menu screen may need experience points to display them in a status screen. The battle screen may need to access experience points so that it can award them when defeating all enemies. Experience is an example of information which is used and changed in a variety of areas.

## Properly Encapsulating GlobalData

If you have information which meets both criteria above, then it should be accessed through GlobalData. However, this information **should still be encapsulated in instanced classes. If the data you are working with is data that will be saved to XML (or some other format to disk or over a network), then you should use the "Save" pattern. If you'd like to read about the Save pattern, check out [this general purpose tutorial](/frb/docs/index.php?title=Tutorials:Save_Classes.md "Tutorials:Save Classes") or keep reading as we'll cover it as it applies specifically to Glue in a later tutorial.** In this example, we'll use a class called PlayerSave which is a class that stores information that will be later saved to disk, but during runtime is as a global storage of data for the player profile. The code for this might look like:

    // Define the PlayerSave class in its own file
    public class PlayerSave
    {
       public string Name
       {
          get;
          set;
       }

       public int ExperiencePoints
       {
          get;
          set;
       }

       // To be a Save class, the class should be able to go to/from XML:
       public static PlayerSave FromFile(string fileName)
       {
          return FileManager.XmlDeserialize<PlayerSave>(fileName);
       }
       public void Save(string fileName)
       {
          FileManager.XmlSerialize(this, fileName);
       }
    }

    // In a different file, define the GlobalData
    public static class GlobalData
    {
       // Naming the property the same name as the class is preferred - easier to remember.  This might
       // seem weird if you're coming from a C++ background, but is fairly common in C#
       public static PlayerSave PlayerSave
       {
          get;
          private set;
       }

       public static void Initialize()
       {
          PlayerSave = new PlayerSave();
       }
    }

Notice that the above code still limits access to prevent undesirable changes. For example, the GlobalData does not allow the code to change to a different PlayerSave. The PlayerSave class does provide access to Name and ExperiencePoints, but you can easily add private data to the PlayerSave if necessary. The following is the wrong way to store this information:

    public static class GlobalData
    {
       public static string PlayerName
       {
          get;
          set;
       }

       public static string PlayerExperience
       {
          get;
          set;
       }
    }

The code listed above is not good because it isn't creating classes to store information. As your game grows you will likely add more information to GlobalData and you will want to approach the GameData class in such a way that it is **only an access point** and does not store any information itself. Furthermore, using a Save class makes it very easy to save progress information to the disk, as we'll cover in the later "Save" tutorial.

## Storing runtime-only information

The above example using PlayerSave shows how to store information that may get saved to disk. You can similarly store information that may be needed but not stored to disk. The pattern is virtually the same; however, you should **not** have your data storage class end in "Save" as this would imply that your data implements the Save pattern.

    public class LevelInformation
    {
       public string LevelName
       {
           get;
           set;
       }

       // This should probably be an enumeration to be more expressive, but we'll use an enum here for brevity
       public int DifficultyLevel
       {
           get;
           set;
       }

    }

    // In a different file, define the GlobalData
    public static class GlobalData
    {
       public static LevelInformation LevelInformation
       {
          get;
          private set;
       }

       public static void Initialize()
       {
          LevelInformation = new LevelInformation();
       }
    }

## How to use GlobalData

Global data is defined above as a static class. Therefore you do not need to ever create an instance of GlobalData. Instead, you can simply access the GlobalData class in any part of your code (as long as you have the proper using statements). Of course, if GlobalData contains objects which must be instantiated, then you will need to call Initialize on GlobalData before accessing it. If not, you will get a null reference exception:

    GlobalData.Initialize();

Once instantiated you can access the objects in GlobalData. For example, we'll consider a case where GlobalData contains an instance of LevelInformation (as shown above). The code to set the value might be:

    // Assuming this code is inside a function which is called when the user changes or selects the difficulty level
    // Also assuming that you have added the proper "using" statements
    // Also assuming that "difficultyToSet" is the difficulty to be set:
    GlobalData.LevelInformation.DifficultyLevel = difficultyToSet;

Once this value is set, another piece of code may use it (which can be anywhere in your code such as a different Screen):

    if(GlobalData.LevelInformation.DifficultyLevel == 0)
    {
       // Do something with the difficulty level
    }

## Screen State Information

The above example explains how to store and provide access to data which needs the widest type of reach: Across different Screens and different Entities. Not all global information should exist in GlobalData. You may encounter situations where information is needed in many Entities, but belongs just in one Screen. For example, consider making a game where you simulate the actions of people based on events and their environment - like The Sims. In this game, you may want people to behave differently depending on the weather. Specifically, you decide to add rain to your game. Where should the information of whether it is raining reside? Since it only makes sense to consider rain when in the game Screen, you will want to tie that information to your game Screen. That is, it might not make sense to have information about whether it is raining stored in the main menu, or credits screen, or loading screen. At this point we have a number of options available to us. The option that is generally used with FlatRedBall projects is to create a public static property in the given Screen. For example, we could put the following property in our OutdoorScreen class:

    // Assuming WeatherType is a valid enumeration
    public static WeatherType CurrentWeather
    {
        get;
        set; // could make this private if we don't want anyone but the Screen to set this
    }

This means that any object could simply look at whether it is raining and perform appropriate actions:

    // Inside any other object
    if(OutdoorScreen.CurrentWeather == WeatherType.Raining)
    {
        this.ReactToRainingWeather();
    }

## Conclusion

One thing that may stand out in the recommended approach for information sharing is that it is very open. If you are looking to build a more modular game, or reuse elements in future games, then you may consider more advanced information sharing systems such as messaging systems, or using interfaces. In our experience developing games with Glue, we've seen that the approaches provided above balance clarity, simplicity, and proper scope. If you decide to implement a more advanced system, keep in mind that over-engineering can kill productivity just as much as messy code.
