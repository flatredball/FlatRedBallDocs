# flatredballxna-tutorials-game-overviews

### Introduction

The Game Overviews section is an area which looks at how games can be implemented using FlatRedBall at a high level. This section will not discuss how to write the code to implement the individual components, nor will it include tutorials on how to use the various tools. Of course, any FlatRedBall terminology in this article will be a link to relevant information, so feel free to explore and read around if you come across something that doesn't make sense.

If you're familiar with FlatRedBall but aren't sure how to piece things together to create your own game, then this section may be very helpful in giving you a higher-level view of how things work. Also, if you're just getting into FlatRedBall and you are interested in the types of features FlatRedBall includes from a whole-game point of view, this section will also be useful.

### Style vs. Standard

The organization of logic that will be presented in this section is the result of many years of game development with FlatRedBall. Naturally, some of the patterns that have emerged are a result of how FlatRedBall was coded as well as the way that the developers who have worked on these games think about code organization.

I expect that there may be disagreements about whether this is the cleanest and most scalable way to organize your code - this is not presented as the only solution to game development. However, I feel that presenting one way of cleanly creating a game will provide guidance to new users. Of course, this is the way that games are made internally at FlatRedBall as well, so I'm slightly biased!

### The Game

When selecting a game for this article I wanted to pick one which was well-known - that way you, the reader, have the best chance of knowing what I'm talking about. At the time of this writing the top selling game according to [VG Chartz](http://vgchartz.com/worldtotals.php) is [Super Mario Bros.](http://en.wikipedia.org/wiki/Super_Mario_Bros) This is both a good selection for its popularity as well as its inclusion of elements very common in many games, both retro and modern. Therefore, we will discuss how one would make Super Mario Bros. using FlatRedBall.

### High Level Categories

The first thing we should do is think about all of the things that we'll need at a very high level. I'll be taking a top-down approach of defining these categories and components. So, first let's list our very high-level categories. These categories would likely define the folder structure of our project.

| Category                             | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| ------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [Entities](../frb/docs/index.php)    | Objects which can be seen, require collision, and have some kind of behavior. This includes stars, mushrooms, enemies, and Mario himself. Entities such as Mario which require input will react to input in their Activity methods (or methods called by Activity).                                                                                                                                                                                                                      |
| Game [Screen](../frb/docs/index.php) | This is the [Screen](../frb/docs/index.php) which represents a game. For a game like Super Mario Bros., one Screen will be sufficient. Each Screen will have data that it loads, like [.scnx files](../frb/docs/index.php) for the level layout, [.plylstx](../frb/docs/index.php#Loading_Polygons_from_File_.28.plylstx.29) or [.shcx](../frb/docs/index.php#Loading_ShapeCollection_From_File) files for collision, and perhaps a custom file for enemies, items, and triggers. |
| UI [Screens](../frb/docs/index.php)  | This includes front-end UI like the number of player select at the beginning of the game, the lives count and level display at the start of a level, and the HUD that is always present when the player is playing through a level. Other games might also include screens for high scores, options, credits, and splash screens.                                                                                                                                                        |
| Data                                 | This category includes data which is specific to the game. This can include classes which define custom data, such as the level format that defines where enemies, items, and triggers are located. This section also usually includes static classes which include information like how many lives the player has, the player's score, and how many players are playing the game.                                                                                                       |
| Content                              | The Content project will include a variety of files such as level files ([.scnx](../frb/docs/index.php)), animation ([.achx](../frb/docs/index.php)), collision ([.plylstx](../frb/docs/index.php#Loading_Polygons_from_File_.28.plylstx.29) or [.shcx](../frb/docs/index.php#Loading_ShapeCollection_From_File)), textures (.png or other image format), and custom game-specific data files.                                                                                    |

### Entities

The Entity namespace contains some of the most critical logic for our game. The behavior of the entities defines the game mechanics. In other words, the Entities define what the player can do and how the player does it. Creating your Entities is often a good way to start developing your game - especially if your game depends heavily on mechanics.

#### Prototyping

Developing your mechanics in a simple, often content-less "level" or area is a great way to get to the core of your game quickly and playing through the many questions that arise in game design. Returning to the Super Mario Bros. example, this may initially be a long, flat level for testing running and perhaps rudimentary logic for keeping the camera on Mario.

Later floating blocks, power ups, and enemies may be added to this level to test how Mario interacts with these. These levels can help answer difficult questions such as "how fast should Mario accelerate?", "what is Mario's top speed?", "how high can Mario jump?", and "how much control should Mario have in the air?". If you have a sense of what the numbers mean, you may be able to guess at some initial numbers, but making these prototypes is the best way to answer these questions.

#### Activity Method

Most Entities have a public Activity method. This method contains the every-frame logic including:

* Movement - either based off of state, AI, local input (game controller), or remote input (instructions sent over a network).
* Visible representation update - The state of an Entity may impact its appearance. For example, the Character's AnimationChain depends on whether the character is running, jumping, or in the process of dying.
* Entity-specific state management - Some Entities will have logic which impacts the Entity's state. For example, Bloopers react to Mario's position, impacting their desired trajectory. This trajectory will likely be interpreted and converted to actual velocity in the Movement portion of Activity.

#### Entity List

The following classes would likely be created for Super Mario Bros.:

\[TABLE]

Of course, there are other objects which will likely need their own classes, but their behavior is fairly straightforward. Examples include:

* The bridge under Bowser
* The axe which disappears when touched - causing the bridge to disappear as well
* The end-of-level flagpole
* Toad and the Princess (potentially part of the .scnx if they have no special behavior)
* Springs
* Vines

### Game Screen

The game screen is the class that brings all of the Entities together and is responsible for conducting the logic between the Entities. In most cases Entities do not know about each other. Of course, if Entities need to be aware of other Entities, such as a homing missile following a space ship, then lists of Entities may need to be passed to the Activity method of other Entities. The only time this is necessary in Super Mario Bros. is in the behavior of the Bloopers (octopus) which follows Mario. Arguably, Bowser may also need to know Mario's position to determine where to throw his fire or whether he should throw his hammers.

There are a number of things which the game Screen is responsible for. These are likely to be separate functions called from within the Screen's Activity method:

\[TABLE]

### UI Screens

UI Screens are responsible for displaying information to the user. This information is usually retrieved through static data as it must exist between Screens. Furthermore, these UI screens should not contain necessary information as this binding of data to Screens makes it more difficult to achieve [Jumpable Execution](../frb/docs/index.php).

In short, these Screens will usually use Screens loaded from .scnx files to display and allow for editing of information in static data. Often these Screens will have a method which listens for input and reacts to it, either by modifying the Scene or progressing to another Screen.

### Data

The Data classes can be split into runtime data and the content definitions.

#### Runtime Data

Runtime data is usually stored in one static class or a number of classes which are all contained in one master static class. This class reports and provides access to common game information which should persist between Screens. Examples include:

* Score
* Number of lives
* Number of coins
* Number of continues (if applicable)
* Number of players playing
* Whose turn it is currently (for switching)
* Powerup State per player. This is either stored directly or indirectly. If the Character class is destroyed when the level ends, then this information must remain persistent so it will be in the runtime data class. If the Character persists between levels but simply has its visible representation and collision created and destroyed, then the Character (or list of Characters) will likely be stored in the runtime class (an indirect storage of state).
* Current level
* Whether the player has beaten the game - do you remember that after you finish world 8-4 the enemies change and the game becomes slightly harder.
* Other game options if applicable - this could include volume levels and input mapping.

#### Content Definitions

FlatRedBall offers a variety of file types for defining content; however, some games require custom content which is not available in the engine. We recommend making such data XML as it is very easy to save and load and is also human-readable which helps resolve content bugs much easier than if the data is binary.

If the data is in XML format then it is likely that there will be a class that the XML file can be deserialized to. Furthermore, if you are creating a tool such as a level editor, then this class will be included in your level editor so that the XML can be serialized from it.

As mentioned before, a likely candidate for custom content is the definition of enemy and power-up placement. Other options include the behavior of power-ups, the behavior of enemies, and scripted events such as Bowser's reaction when the bridge disappears or when Mario jumps on a flagpole. The main question here is what is the payoff of having everything at data level versus simply hard-coding this content. In general the larger and more complex the game, the more information should be placed in content data instead of in code.

### Content

The content is the stuff that the player will see, hear, and "touch" (collide against). Much of the content in your game will be created from a file type either defined by FlatRedBall or other common file formats. You may add extra content to your game. Types of content include:

\[TABLE]

### Conclusion

As you can see there is quite a bit to keep track of when making a game like Super Mario Bros., which may seem like it is very simple. I sincerely hope that this entry helps you understand how FlatRedBall games come together. As always, if you encounter any problems, errors, or questions about this article, please post in the forums and we will do our best to help.

Did this article leave any questions unanswered? Post any question in our [forums](../frb/forum.md) for a rapid response.
