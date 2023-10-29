## Introduction

UpdateDependencies is a method which updates absolute values (specifically position and rotation) according to the caller's relative values and Parent absolute values. The UpdateDependencies method is a method which is automatically called by the Engine on any PositionedObject or PositionedObject-inheriting object which is part of a FlatRedBall manager. In most cases you will never need to worry about dependencies being updated - this will be called automatically.

## UpdateDependencies called before Draw

UpdateDependencies is responsible for positioning an object according to its parents' position and rotation. Since attached objects must move together, then absolute positions must be set after all custom code is executed, but before the draw is called. Therefore, FlatRedBall managers call UpdateDepencies on contained PositionedObjects in the FlatRedBallServices.Draw method.
