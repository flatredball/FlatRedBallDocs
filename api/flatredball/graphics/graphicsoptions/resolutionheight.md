# resolutionheight

### Introduction

The ResolutionWidth and ResolutionHeight members can be used to get and set the resolution of the game. If you are setting both ResolutionWidth and ResolutionHeight, consider using [SetResolution](../../../../../frb/docs/index.php) instead of setting each value independently to avoid a double-resize.

### Code Example

```
int screenWidth = FlatRedBallServices.GraphicsOptions.ResolutionWidth;
int screenHeight = FlatRedBallServices.GraphicsOptions.ResolutionHeight;
```
