## Introduction

The ParentVelocityChangesEmissionVelocity determines whether the movement of the Emitter's parent changes the velocity of emitted particles. This value is true by default.

## Why does this value look at an Emitter's Parent?

A very common pattern in Glue is to create an Emitter and add it to an Entity. In this case the Emitter will be attached to a parent PositionedObject. When the parent moves, it will have Velocity, but the Emitter will not have a Velocity value. Therefore, the Emitter uses the parent's Velocity to modify the emitted particles.
