## Introduction

The ContentManagerName property returns the Screen's ContentManagerName. For more information on ContentManagers, see the [ContentManager page](/frb/docs/index.php?title=FlatRedBall.Content.ContentManager "FlatRedBall.Content.ContentManager").

## Code Example

ContentManagerName can be used when manually loading files. For example, assuming that "Content/MyGraphic.png" is part of your project, you can load it as follows:

    // Assuming "this" is a screen (the code is in the Screen's custom code:
    Texture2D texture = FlatRedBallServices.Load<Texture2D>(
        "Content/MyGraphic.png", this.ContentManagerName);
