## Introduction

The Emitter class creates particle [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") which are designed to be quickly created and destroyed with no memory allocation. Of course, any feature can slow a game down if overused. This section will discuss considerations when creating particles to keep your game running smoothly.

## FlatRedBall vs. \<insert other engine or demo\>

You may be wondering why particles in FlatRedBall are not as efficient as in another game engine or demo. The reason for this is because of where the particle system in FlatRedBall lies on the "Performance vs. Features" spectrum:

    Performance                         Lots of Features
    <-------------------------------------------------->
                                              ^
                                         FlatRedBall

Of course, this isn't a comparison of FlatRedBall's particle system to other engines; but rather, an indication of how we intended the particle system to behave when we designed it. The particle system is built on top of the [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite") class. Each particle that is created by an Emitter is actually a Sprite. That means that each particle has all of the functionality of a Sprite. That includes:

-   Velocity, Acceleration, Drag
-   Color and blend operations
-   Texture animation
-   Instructions
-   CustomBehavior
-   Attachments (if necessary)

That's a lot of functionality, and when you have hundreds of particles, each one gets that behavior!

## What can slow down my game?

Particle systems are very straight-forward. There aren't a lot of "gotchas" when it comes to particle performance in FlatRedBall. In short, more of anything means more time. Let's break it down a little bit:

### Particle Count

As mentioned earlier in this page, more [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") means more calls to [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite") behavior methods. You should keep an eye on your particle count, especially if you are creating your emitters in the [Particle Editor](/ParticleEditorWiki/index.php?title=Main_Page.md).

The number of particles in an Emitter can vary depending on its purpose, but if you are getting into Emitters that have over 500 live [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite"), you may want to reconsider if there is a way to achieve the effect you are looking for with fewer [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite").

Keep in mind that even though an Emitter is off-screen, emission will still create [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") which can impact performance.

### Texture Size

The size of the source Texture can have some impact on your particles, but not a huge one. Some versions of FlatRedBall perform mipmapping to eliminate "sizzling" and cache misses when rendering, so large textures are not a huge hit on performance...of course, if you are using 2048X2048 for particles, that is definitely a waste of space and it may have an impact on performance.

In short, you should try to match the size of your source texture to how large the particles will appear on screen.

### Fill rate (size on screen)

Fill rate is perhaps one of the biggest killers of performance when it comes to particles. The reason for this is because particles are by default "ordered". That means that the FlatRedBall engine draws Sprites back-to-front, and does not perform any kind of Z-Buffering between each particle.

That means that if you have 10 large particle [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite") which take up the entire screen, you are drawing an entire screen's-worth of pixels every frame!

If you anticipate that each particle will take up a lot of space on screen, you should consider reducing your particle count. Also, keep an eye on overlapping particles. If you are making a 2D game, you might have a good sense of how likely it is that particles will overlap. If you have a lot of particles overlapping, reduce the number of live particles to see improvements in performance.

### Instructions

While Instructions are very powerful, at the time of this writing they are **not pooled**. That means that every particle that is created will instantiate brand-new Instructions. This can make your application allocation heavy and cause the garbage collector to kick off.

Use Instructions sparingly.

### Removal

Of course, you should always make sure that your Emitter has a proper removal event to prevent a buildup of Sprites. Otherwise, you will essentially create an Emitter that continually creates Sprites which never die. You will sooner or later experience performance problems under this type of scenario.

However, even if you are using removal events, not all removal events are equal in performance.

The fastest is Alpha0. This removal event requires very little every-frame logic and results in no memory allocation.

The next fastest is OutOfScreen, which requires some memory allocation and every-frame logic.

The slowest is Timed removal, which requires an instantiation of an instruction.

## What doesn't matter?

There are some things which don't impact the performance of particles which may in other engines.

### Transparency

Transparency is essentially free in all of FlatRedBall. The shader which performs the color operation calculates alpha whether each pixel is fully opaque or not.
