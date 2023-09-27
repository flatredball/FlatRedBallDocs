## Introduction

The InitializeUserFolder is a method which prepares a user-specific storage area for saving and loading game content. The user folder can contain information such as game settings (audio volume), progress (how far the player has made it through the game), and debug information (such as call stacks if the application crashes).

The user folder has both read and write access on every device, and using the user folder is the preferred way to save data when using FlatRedBall as it enables cross-platform IO support.

## Code Example

The InitializeUserFolder method must be called before any other methods which use the user folder. This method initializes the user folder, gets its location, and saves a text file.

    string userName = "FlatRedBall User"; // this could be anything - can be a Xbox profile name, or could be "global"
    FileManager.InitializeUserFolder(userName);
    string userFolder = FileManager.GetUserFolder(userName);
    FileManager.SaveText("This is some text that will be saved", userFolder + "fileName.txt");
