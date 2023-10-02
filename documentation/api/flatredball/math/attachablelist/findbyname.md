# findbyname

### Introduction

The FindByName method returns the first object in the list with the name matching the argument. The signature for the method is:

```
public T FindByName(string nameToSearchFor)
```

### Common Usage

The FindByName method is most commonly used on AttachableLists which are populated by data which is loaded from file (or through the content pipeline), such as lists contained in [Scenes](../../../../../frb/docs/index.php) or [ShapeCollections](../../../../../frb/docs/index.php). For example, a .scnx may be created as the level for a platform game. The goal of the level is to reach a door, which is a [Sprite](../../../../../frb/docs/index.php) in the .scnx. This requires special logic (collision tests, then advancing to the next level on a successful collision). To perform this logic, the code that's loading the .scnx needs to have reference to the door Sprite. To accomplish this, the person assembling the .scnx should appropriately name the door and communicate this to the programmer. We'll assume that the door is named "door". Add the following code to get a handle to this object:

```
// likely at class scope
Sprite mDoor;

// After loading the .scnx into a Scene:
mDoor = scene.Sprites.FindByName("door");
// now mDoor can be used however needed
```
