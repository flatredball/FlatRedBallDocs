## Introduction

Storing shapes (or Entities which have collision shapes) in a list is very common. You can collide all objects in a list all other objects using doubly-nested for loops:

    // Assuming myList is a valid List of shapes
    for(int firstIndex = 0; firstIndex < myList.Count; firstIndex++)
    {
       for(int secondIndex = 0; secondIndex < myList.Count; secondIndex++)
       {
          // Make sure a shape doesn't collide against itself
          if(firstIndex != secondIndex && 
             myList[firstIndex].CollideAgainst(myList[secondIndex]))
          {
             // do whatever you need to do to respond to collisions here
          }
       }
    }
