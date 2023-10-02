# emit

### Introduction

The Emit method performs a single emission from an Emitter. This method should be used if an Emitter should emit according to certain logic and not according to a timer.

### Code Example

You can manually tell an Emitter to emit by calling Emit on it:

```
EmitterInstance.Emit();
```

This will cause the Emitter to emit one time - which may be multiple particles if the [NumberPerEmission](../../../../../../frb/docs/index.php) property is set to a number greater than 1.

### Modifying Emitted Particles

While the Emitter provides a lot of properties to control the behavior of particles, it is impossible for us to provide properties for every case. Therefore, when you emit particles, you can put them in a list and modify them upon emission.

The Emit method can receive a SpriteList which it will populate with newly-emitted Sprites. The following code can be used to perform custom logic on emitted Sprites:

The SpriteList should be defined at class scope so it's not re-created every method call

```
SpriteList newlyEmittedSprites = new SpriteList();
SpriteList allEmittedSprites = new SpriteList();
```

In your emission logic code

```
// Clear the SpriteList so it will contain only newly-emitted Sprites for one-time logic.
newlyEmittedSprites.Clear();
// We don't clear allEmittedSprites

// Assuming myEmitter is a valid Emitter:
myEmitter.Emit(newlyEmittedSprites);
allEmittedSprites.AddRange(newlyEmittedSprites);

for(int i = 0; i < newlyEmittedSprites.Count; i++)
{
   // Perform some logic on all newlyEmittedSprites
   // This is one-time logic
}
```

The above code shows how to populate a list of newly emitted Sprites. A second SpriteList (allEmittedSprites) is created to store all emitted Sprites if you need to perform continual logic on these Sprites. The allEmittedSprites will automatically be cleaned of old Sprites due to the [two-way relationship between Sprites and SpriteLists](../../../../../../frb/docs/index.php#Two\_Way\_Relationships).
