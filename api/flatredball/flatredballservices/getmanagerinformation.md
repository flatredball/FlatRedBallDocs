# getmanagerinformation

### Introduction

The GetManagerInformation returns a string which includes information about objects which are being managed by the different FlatRedBall managers.

The GetManagerInformation method returns counts of all of the different types of objects managed by FlatRedBall. It is likely that over time this list will grow, so when using this method you may find more information than is shown in the code examples on this page.

### Code Example

The following code creates a [Text](../../../../frb/docs/index.php) object to display the result of the GetManagerInformation method. Even though there are no changes, the [Text](../../../../frb/docs/index.php) is updated every frame. If you are testing for accumulation errors (see below) then you will likely want to update the display frequently.

Add the following using statements:

```
using FlatRedBall.Graphics;
```

Add the following at class scope:

```
Text text;
```

Add the following to Initialize after initializing FlatRedBall:

```
text = TextManager.AddText("");
text.X = -10;
text.Y = 10;
```

Add the following to Update:

```
text.DisplayText = FlatRedBallServices.GetManagerInformation();
```

![GetManagerInformation.png](../../../../media/migrated\_media-GetManagerInformation.png)

### Accumulation Errors

Accumulation errors are bugs similar to memory leaks in unmanaged code. Accumulation errors occur when an object is added to the engine, but the object is not removed from the engine. For example, the method results in an accumulation error assuming that the created Sprite is not cleared at some other time:

```
public void CreateSpriteAndLoseReferenceToIt()
{
    Sprite sprite = SpriteManager.AddSprite("redball.bmp");

    // The next line will NOT get rid of the reference:
    sprite = null;
    // The Sprite is still being held by the SpriteManager
}
```

The GetManagerInformation method is a great way to check for accumulation errors.

One of the most indicative symptoms of having accumulation errors is if your game continually runs slower and slower over time. This often happens because more and more objects are being added to the engine. As more objects build up in the engine, the engine must manage more objects every-frame, and it can eventually get to a point where frame rate suffers.

To check for this, simply print out the result of the GetManagerInformation call and watch for steady increases over time. This method will not only verify if you are experiencing accumulation errors, but the growing category can also give you an idea of where to look for the bug.
