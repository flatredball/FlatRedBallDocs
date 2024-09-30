# IAnimationChainAnimatable

### Introduction

The IAnimationChainAnimatable interface defines methods and properties for objects which can be animated by [AnimationChains](../../../../../frb/docs/index.php) (which are stored in a [AnimationChainList](../../../../../frb/docs/index.php)). Examples of classes which implement the IAnimationChainAnimatable interface include the [Sprite](../../../../../frb/docs/index.php) and [SpriteFrame](../../../../../frb/docs/index.php).

### Setting AnimationChains

The following shows various ways to set a [Sprite's](../../../../../frb/docs/index.php) current [AnimationChain](../../../../../frb/docs/index.php). The reason there are so many examples is because Sprites and AnimationChains can be created many different ways. What follows are examples which cover the most common scenarios. For information on how to create [AnimationChains](../../../../../frb/docs/index.php), see the [Creating AnimationChains wiki Entry](../../../../../frb/docs/index.php#Creating\_AnimationChains).

#### If the Sprite and .achx are created in Glue

Normally the Sprite's AnimationChains can be set in Glue; however, to set them manually in code:

```
SpriteInstance.AnimationChains = AnimationChainFile;
SpriteInstance.Animate = true;
SpriteInstance.CurrentChainName = "WalkUp";
```

#### If the Sprite is already created (usually the case when using Glue), and you have an AnimationChain variable

IAnimationChainAnimatables like [Sprites](../../../../../frb/docs/index.php) can also have their AnimationChains set after they are created:

```
// This code assumes that animationChain is a valid AnimationChain and
// sprite is a valid Sprite.
sprite.SetAnimationChain(chainToSet);
sprite.Animate = true; // still have to set animate to true
```

#### If creating the Sprite in Code

```
// This code assumes animationChain is a valid AnimationChain.
Sprite sprite = SpriteManager.AddSprite(animationChain);
sprite.Animate = true;
// So details can be seen
sprite.ScaleX = sprite.ScaleY = 10;
```

#### If the Sprite has already had its AnimationChains property set (usually done through Glue)

If the Sprite has had its AnimationChains value set, either in code or in Glue, then you can simply select which animation to play:

```
sprite.CurrentChainName = "WalkNorth";
```

Calling [SetAnimationChain](../../../../../frb/docs/index.php) or setting the CurrentChainName needs to only be called when the [AnimationChain](../../../../../frb/docs/index.php) is changing or being set. It does not need to be called every frame to keep the animation going.

### Manually Setting Frames

See [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.CurrentFrameIndex](../../../../../frb/docs/index.php).

### Detecting When an AnimationFrame Changes

When an IAnimationChainAnimatable changes the AnimationFrame that it is displaying, its JustChangedFrame property is true for that frame.

```
// assume mySprite is a valid Sprite that is animating
if(mySprite.JustChangedFrame)
{
   switch(mySprite.CurrentFrameIndex)
   {
       case 0:
           // do something
           break;
       case 1:
           // do something else
           break;
   }
}
```

![AnimatedDrone.png](../../../../../.gitbook/assets/migrated\_media-AnimatedDrone.png)

### Internal AnimationChainList and Common Usage

Objects which implement the IAnimationChainAnimatable interface hold an AnimationChainList reference internally. This AnimationChainList is referenced by IAnimationChainAnimatables to standardize the setting of [AnimationChains](../../../../../frb/docs/index.php) according to state or behavior. The game Warcraft 2 will be used as an example of how the internal storage of [AnimationChains](../../../../../frb/docs/index.php) can standardize code and simplify development. ![Warcraft2 Screenshot.jpg](../../../../../.gitbook/assets/migrated\_media-Warcraft2\_Screenshot.jpg) Warcraft 2 has numerous characters which share similar behavior. All ground units have the following behavior:

* Walk North
* Walk South
* Walk West
* Walk East
* Attack (likely also has directions, but not included to save space)
* Die

Since these behaviors share many similarities they should be put in a base class. However, setting [AnimationChains](../../../../../frb/docs/index.php) becomes a problem. If each type of object (human peasant, orc peasant, ogre) references different [AnimationChains](../../../../../frb/docs/index.php) the the code cannot fully be standardized if references are used to set the current animation. That is, if methods are called when a state change occurs, there will need to be virtual methods that can be called by the base class to set the current [AnimationChain](../../../../../frb/docs/index.php) to the appropriate reference. While this will work, it is not very convenient or readable - for a new user to understand the behavior he will have to traverse multiple files and follow the execution path up and down the inheritance tree. The alternative is to recognize early on that this similarity between objects exists and design for this standard behavior both in content and in code. In other words, if the behaviors previously listed in bullet points are recognized early on before content creation begins, then this pattern can be used when all AnimationChainLists are created. Once the textures for all animations are created, the .achx file created in the [AnimationEditor](../../../../../AnimationEditorWiki/index.php) can use the same names for their [AnimationChains](../../../../../frb/docs/index.php). Therefore, the humanPeasant.achx file and the orc.achx file will both reference different textures, and can even have a different number of textures or frame times, but they should include a set of same-named [AnimationChains](../../../../../frb/docs/index.php). What the [AnimationChain](../../../../../frb/docs/index.php) holds internally is insignificant from the programmer's point of view, just the name. Once these [AnimationChains](../../../../../frb/docs/index.php) are created, the code simply loads the appropriate .achx file in the derived class' constructor. The base class can set the current [AnimationChains](../../../../../frb/docs/index.php) using the Name property. As an example, the following code would work for all objects which have walking and dying animations:

```
// Assumes all types like BaseEntityState have been defined
void SetState(BaseEntityState state)
{
    // Assumes that the object has a reference to a Sprite called mSprite
    switch(state)
    {
        case BaseEntityState.WalkNorth:
            mSprite.CurrentChainName = "WalkNorth";
            break;

        case BaseEntityState.WalkSouth:
            mSprite.CurrentChainName = "WalkSouth";
            break;

        case BaseEntityState.WalkWest:
            mSprite.CurrentChainName = "WalkWest";
            break;

        case BaseEntityState.WalkEast:
            mSprite.CurrentChainName = "WalkEast";
            break;

        case BaseEntityState.Attack:
            mSprite.CurrentChainName = "Attack";
            break;

        case BaseEntityState.Die:
            mSprite.CurrentChainName = "Die";
            break;
    }
}
```

So long as all objects which inherit from the class containing this code have AnimationChains named WalkNorth, WalkSouth, WalkWest, WalkEast, Attack, and Die, this code will handle all [AnimationChain](../../../../../frb/docs/index.php) setting with no regard to the actual contents of the [AnimationChain](../../../../../frb/docs/index.php) being set.

### Adding AnimationChains to an IAnimationChainAnimatable

The previous section discusses how to set AnimationChains on an IAnimationChainAnimatable. Of course, for the CurrentChainName property to work, the IAnimationChainAnimatable must have a reference to an AnimationChain with a matching name. Another way of looking at it is that if you are going to toggle between AnimationChains, then the object that is going to have its AnimationChain set must have references to multiple AnimationChains. How can this be done? The most common and data-driven approach is to load a .achx file created in the AnimationEditor or some other tool. The .achx file can contain multiple AnimationChains so this greatly simplifies the process. However, it's also possible to set up your IAnimationChainAnimatable to use multiple AnimationChains if you are creating the AnimationChains by hand. To do this, you can simply add each AnimationChain to the AnimationChains property. For example, assuming that animationChain1, animationChain2, and animationChain3 are valid AnimationChains:

```
// Also assuming that mySprite is a valid Sprite (which implements IAnimationChainAnimatable)
mySprite.AnimationChains.Add(animationChain1);
mySprite.AnimationChains.Add(animationChain2);
mySprite.AnimationChains.Add(animationChain3);
```

### Additional Information

* [Animation and Timing](../../../../../frb/docs/index.php)

### IAnimationChainAnimatable Members

* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.Animate](../../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.AnimationChains](../../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.AnimationSpeed](../../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.CurrentChainName](../../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.CurrentFrameIndex](../../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.JustChangedFrame](../../../../../frb/docs/index.php)
* [FlatRedBall.Graphics.Animation.IAnimationChainAnimatable.JustCycled](../../../../../frb/docs/index.php)

Did this article leave any questions unanswered? Post any question in our [forums](../../../../../frb/forum.md) for a rapid response.
