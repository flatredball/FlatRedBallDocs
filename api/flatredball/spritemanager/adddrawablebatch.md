## Introduction

The AddDrawableBatch method is used to add an existing IDrawableBatch-implementing instance to the engine. Once an IDrawableBatch instance is part of the engine, then it will be automatically rendered.

## Code Example

The following code can be used to add a drawable batch to the engine, assuming that MyDrawableBatch is a valid DrawableBatch instance:

    SpriteManager.AddDrawableBatch(MyDrawableBatch);
