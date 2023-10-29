## Introduction

Enums are a very common type of object used in dictionaries. Unfortunately there is a hidden behavior in dictionaries that use enums as their keys which can cause performance problems - usually resulting from memory allocation.

## Our example

Consider the following simple example:

    public enum Day
    {
       Monday,
       Tuesday,
       Wednesday
    }

    // later we define a Dictionary:
    Dictionary<Day, int> mSomeDictionary = new Dictionary<Day, int>();

    // and finally you may want to check the dictionary for whether it contains a key:
    Day day = Day.Monday;
    if(mSomeDictionary.ContainsKey(day))
    {
       // do something
    }

While that may seem like code that shouldn't case problems, unfortunately under the hood .NET casts the enum to an object to perform the equality check. This cast takes far more time than an integer comparison, and it also creates garbage, which can be fatal on the Xbox 360. If you'd like to read more, check [this blog post](http://beardseye.blogspot.com/2007/08/nuts-enum-conundrum.html).

## How to fix it

The easiest way to fix this problem is to simply use ints and cast your enums as follows:

    public enum Day
    {
       Monday,
       Tuesday,
       Wednesday
    }

    // later we define a Dictionary:
    Dictionary<int, int> mSomeDictionary = new Dictionary<int, int>();

    // and finally you may want to check the dictionary for whether it contains a key:
    Day day = Day.Monday;
    if(mSomeDictionary.ContainsKey((int)day))
    {
       // do something
    }

This will completely eliminate any allocation that will occur in your ContainsKey call.
