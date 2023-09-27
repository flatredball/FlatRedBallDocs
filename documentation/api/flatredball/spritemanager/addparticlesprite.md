## Introduction

The AddParticleSprite returns a Sprite from the SpriteManager's internal particle pool. AddParticleSprite is internally used in the Emitter's Emit method, but can also be used if your game needs to create Sprites but you do not want to incur memory allocation during runtime.
