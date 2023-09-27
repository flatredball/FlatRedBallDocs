## Introduction

How to share information between Screens and Entities is a very common problem. There are a lot of ways to solve this problem, but each has its downsides. While this problem may seem trivial, this article will talk about the preferred way to share object references between Screens (the owner) and Entities (contained objects that need the information).

## A common scenario

Let's imagine you are creating a multi-player game where the players work together to defeat groups of enemies. Based off of this simple description of a game we can identify a few things:

-   The Screen will have a PositionedObjectList\<Player\>
-   The Screen will have a PositionedObjectList\<Enemy\>
-   Each enemy will need to know about the PositionedObjectList\<Player\> so that it can make decisions about where to move and where/when to attack.

Naturally you will want to make the two PositionedObjectLists (for Player and Entity types) in Glue in your Screen. This means that the Screen has access to the two PositionedObjectLists. For proper encapsulation, the logic for the Enemy AI should exist in the Enemy code (as opposed to the Screen code). However, the Enemy's AI logic will need access to the PositionedObjectList\<Player\> that exists in the Screen.

## Sharing the list - a step by step walk-through

At a high level the steps required to share the information are:

1.  Create a public PositionedObjectList\<Player\> property in the Enemy custom code (not through Glue)
2.  Assign this property in the Screen class whenever a new Enemy is created
3.  Use this property in your AI logic in Enemy.cs

### 1. Create a public PositionedObjectList\<Player\> property in the Enemy custom code (not through Glue)

Open your Enemy.cs file and add the following code at class scope:

    public PositionedObjectList<Player> PlayerList
    {
       get;
       set;
    }

That was easy!

### 2. Assign this property in the Screen class whenever a new Enemy is created

Locate where you create your Enemy instances and add the following code:

    // Assuming you simply use the constructor, your code might look like this:
    Enemy enemy = new Enemy(ContentManagerName);
    enemy.PlayerList = this.PlayerList; // assumes the PositionedObjectList<Player> in your Screen is called PlayerList

### 3. Use this property in your AI logic in Enemy.cs

You may have a method like AiActivity in your Enemy.cs file. If so, it would look like this:

    void EnemyActivity()
    {
       // Do something with PlayerList
       for(int i = 0; i < PlayerList.Count; i++)
       {
          Player player = PlayerList[i];
          // code code code...
       }
    }
