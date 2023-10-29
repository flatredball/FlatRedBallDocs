## Introduction

The RemoveDrawableBatch method removes the argument IDrawableBatch from the engine. Specifically it removes it from being rendered if it's layered, unlayered, Z-buffered, or specific to a Camera Layer.

## Code Example

The following assumes a valid IDrawableBatch-implementing instance called DrawableBatchInstance:

    SpriteManager.RemoveDrawableBatch(DrawableBatchInstance);
