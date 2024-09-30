# Pulse

### Introduction

The Pulse method creates a recurring set of instructions used to change the argument [IScalable's](../../../../frb/docs/index.php) Scale and Scale Velocity. The result is a pulsing effect.

### Code Example

The following creates a [Sprite](../../../../frb/docs/index.php) which pulses using a set of defined parameters.

Add the following using statements:

```
 using FlatRedBall;
 using FlatRedBall.Instructions;
```

Add the following to Initialize after initializing FlatRedBall;

```
 Sprite sprite = SpriteManager.AddSprite("redball.bmp");

 float smallScaleX = 1;
 float smallScaleY = 1;
 float largeScaleX = 3;
 float largeScaleY = 3;
 double period = 1; // how many seconds the grow/shrink lasts

 InstructionManager.Pulse<Sprite>(
     sprite,
     smallScaleX,
     smallScaleY,
     largeScaleX,
     largeScaleY,
     period);
```

![InstructionManagerPulse.png](../../../../.gitbook/assets/migrated\_media-InstructionManagerPulse.png)
