## Introduction

The GlobalData class is a pattern for a class which serves as the access point for global information in your game. Examples of information that may go in GlobalData include:

-   The player's profile information
-   The current stage being played
-   Options such as sound and music volume levels
-   Cross screen information that you may want to cache, like information coming from a server

For an in-depth discussion about GlobalData and other ways to store global information, see [the "Proper Information Access" page](/frb/docs/index.php?title=Glue:Tutorials:Proper_Information_Access "Glue:Tutorials:Proper Information Access").

## Example of GlobalData class

The following shows an empty GlobalData class:

    public static class GlobalData
    {
        // Here you'd add properties to access information like the player's profile or current stage, etc.
    }
