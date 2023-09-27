## Introduction

The SpriteManager performs pooling on its particle [Sprites](/frb/docs/index.php?title=Sprite "Sprite") to prevent continual memory allocation. The MaxParticleCount property controls the size of the pool. A larger pool means that more particle [Sprites](/frb/docs/index.php?title=Sprite "Sprite") can live at one time; however, it also means that the game will require more memory at runtime to store extra [Sprites](/frb/docs/index.php?title=Sprite "Sprite").

## Code Example

MaxParticleCount defaults to a value of 2,900 at the time of this writing. This following code increases the maximum number of particles to 4,000.

    SpriteManager.MaxParticleCount = 4000;

## Why are particles pooled?

Particles generally have short lives and are created at a frequent interval. If all particles were allocated when needed and destroyed when not, this would result in a considerable amount of memory allocation and would cause the garbage collector to work more frequently than necessary. The garbage collector can cause significant hops in frame rate on the Xbox 360 and in Silverlight.

## Why doesn't the engine automatically grow MaxParticleCount?

Usually the only time you need to grow MaxParticleCount is if you have created more particles (or anticiapte creating more) than the default MaxParticleCount value. You may be wondering why the engine doesn't simply expand this list as more particles are needed. There are two main reasons:

1.  Expanding the list requires allocation. If the engine were to automatically expand the internal pool, this would likely be done in the middle of game play. All (or as much as possible) allocation should be done when a [Screen](/frb/docs/index.php?title=Screen "Screen") is loaded and not during its Activity to prevent the garbage collector from working.
2.  The MaxParticleCount can be used to catch bugs where particle [Sprites](/frb/docs/index.php?title=Sprite "Sprite") are created but not destroyed. For example, if you have a single [Emitter](/frb/docs/index.php?title=FlatRedBall.Graphics.Particle.Emitter "FlatRedBall.Graphics.Particle.Emitter"), but after 1 minute of emission you hit the MaxParticleCount, then it's likely that you are not removing emitted particles. If the engine automatically expanded the list, this bug would result in worse and worse frame rate - a symptom which doesn't lead you to the problem as quickly as an exception.
