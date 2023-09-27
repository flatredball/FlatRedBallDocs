## Introduction

If you are using a custom file format to instantiate Entities, then you may want to determine the type to instantiate based off of information held in the file. The easiest way to do this is to use reflection. This article will show how to instantiate Entities based off of their string list.

## Code Example

The following code shows how to instantiate an Entity based off of its string name. For simplicity we'll be using a List of strings, but this information could come form anywhere like a custom file or a .scnx if you are using .scnx as an entity placement file format.

**For reflection to be useful, the objects created must share a common base class**. Usually Entities which share a common base class are stored in a list of the base type. In this example we'll instantiate Entities which all share the Collectable base class.

    // First we'll get our list.  Again, this information could come from anywhere
    List<string> entitiesToInstantiate = new List<string>();
    entitiesToInstantiate.Add("YourGameName.Entities.Mushroom");
    entitiesToInstantiate.Add("YourGameName.Entities.Coin");
    entitiesToInstantiate.Add("YourGameName.Entities.Coin");
    entitiesToInstantiate.Add("YourGameName.Entities.Star");
    entitiesToInstantiate.Add("YourGameName.Entities.Flower");

    foreach(string entityTypeAsString in entitiesToInstantiate)
    {
       // The value passed here must be fully-qualified
       Type type = Type.GetType(entityTypeAsString);

       Collectable newEntity = (Collectable)Activator.CreateInstance(type);
     
       // We'll assume that the user has defined the following either in Glue or Custom Code:
       //   PositionedObjectList<Collectable> CollectableList;
       CollectableList.Add(newEntity);
    }
