# relationships

### Introduction

The Relationships list contains all of the relationships being managed by the CollisionManager. In most cases, FlatRedBall games (using Glue) will not modify this list, but it is exposed publicly for:

* Plugins to add new types of relationships
* Debugging
* Manual removal of collision relationships

### Code Example - Clearing Relationships

The Relationships property is a standard List so it can be modified just like any other list. Collisions can be cleared by calling the Clear function:

```lang:c#
CollisionManager.Self.Relationships.Clear();
```

Note that Glue will automatically clear relationships when a screen is destroyed, so this does not need to be called in most games. &#x20;
