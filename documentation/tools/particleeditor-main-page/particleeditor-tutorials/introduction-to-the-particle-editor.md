# introduction-to-the-particle-editor

### Introduction

The ParticleEditor plugin for Glue makes it easy to create emitter files (.emix) and add them to your FlatRedBall game. Emitter files can be used to create visual effects requiring multiple sprites. Examples include:

* Rain
* Smoke
* Sparks
* Debris from explosions
* Dust

### What is a particle?

In game development a particle is a single element which makes up a "particle effect" or "particle system". In FlatRedBall, all particles are Sprites. Usually particles and particle systems have the following characteristics:

* There are usually more than one particle visible at a time
* Particles are created frequently - often many particles per second
* Particles have a short life - such as 5 seconds
* Particles may or may not have an impact on game play - sometimes particles are used for game play such as for bullets fired from a weapon but they can also be purely for effect such as smoke rising from a smokestack in the distance.

### What is an Emitter?

Emitters create particles. Emitters store information about how a particle should look and behave once it is created (such as setting its scale or velocity). Emitters have a number of characteristics, but here are some basics:

* Emitters have a position - this defines where all particles are created from
* Emitters can have a size - this allows for area effects, such as rain or smoke emitting from a larger area
* Emitters can be attached to other objects - this allows for easy control such as putting an emitter at the tip of a weapon

### What is an .emix file?

The ParticleEditor is used to create .emix files. The .emix extension stands for Emitter List XML. Keep in mind that a .emix can store a list of Emitters. Therefore, you can create multiple emitters in one file which the programmer can select and interact with by name.

### How can I run the ParticleEditor?

The ParticleEditor plugin can be installed [from this location on GlueVault](http://www.gluevault.com/plug/62-particle-editor-plugin-glue). For information on installing plugins, see [this page](../../../../frb/docs/index.php).

Once installed, the plugin will automatically appear whenever a .emix file is selected.
