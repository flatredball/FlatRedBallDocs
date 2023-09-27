## Introduction

High level scripts are scripts which have a very simple interface. These scripts are so simple that in many cases even non-programmers can write them. However, despite their simplicity, these scripts are still C# code which are compiled and run just like any other C# code. This makes them easy to integrate, easy to debug, and relatively efficient to execute.

## What does a typical script look like?

Lines in scripts either start with the words "If" or "Do". For example, a script might look like this:

    If.True();
    int dialogId = 0;
    Do.ShowDialog("Welcome to the game", dialogId);

    If.DialogDismissed(dialogId);
    Do.MoveCharacterToLocation(MainCharacter, 10, 100);

A single If and all following Do's combine to create a single script. The code example above contains two scripts - one that starts with If.True and one that starts with If.DialogDismissed. In the example above, the Do's will execute only when the previous If's evalute to true. A single If can contain multiple Do's. For example, the following code shows multiple Do's following a single If:

    If.DelayExpired(DelayName);
    Do.AwardPoints(1000);
    Do.ShowCongrats();
    Do.SaveGame();

## What makes these scripts useful?

The classes included in the Game Scripting Plugin promote an approach which has two big benefits.

1.  Script is very easy to initially write. The syntax for scripts is intentionally intended to be as simple as possible. Despite being written in C#, which is an incredibly powerful and complex programming language, the syntax is as easy or easier to use than virtually any scripting language. In most cases scripters don't need to worry about brackets, writing functions, or even standard branching logic (such as if-statements). Visual Studio's auto-complete also makes writing If's and Do's very easily. ![IfAutoComplete.png](/media/migrated_media-IfAutoComplete.png)
2.  Scripting isolates high-level logic from the lower-level parts of your project (such as Entity behavior). This makes maintenance much easier as you develop your game.

## What downsides are there to using these scripts

Like every abstraction, using the game scripting plugin has a few downsides:

-   The script that is written is all executed at once, but the effects of the script may not occur until much later. "Do" execution may be dependent on time passing or on user activity. Therefore, debugging is not as simple as putting a breakpoint on the Do calls.
-   Scripts are stored and evaluated continually until they are needed. This means that the original If and Do calls will not be part of the call stack if you put a breakpoint inside your script functions or if your game throws an exception.
-   New functions require a definition in an interface class as well as in the actual script class. This double-definition takes a little extra work (but has benefits as we will discuss later).
-   Using scripts can take some discipline because new logic requires defining new If's and Do's. This can pull you out of your current task.
